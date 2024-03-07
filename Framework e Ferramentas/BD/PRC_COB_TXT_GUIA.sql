CREATE OR REPLACE PROCEDURE "PRC_COB_TXT_GUIA"
(
PCOB_TXT_ID IN TB_COB_TXT_COBRANCA.COB_TXT_ID%TYPE,
PCAD_PES_ID_PESSOA IN TB_COB_TXT_COBRANCA.CAD_PES_ID_PESSOA%TYPE
--,IO_CURSOR OUT PKG_CURSOR.T_CURSOR
) IS
---- CAD_PES_ID_PESSOA 3521 PETOBRAS (SP33)
---- CAD_PES_ID_PESSOA 3572 BRADESCO (SZ87)
---- CAD_PES_ID_PESSOA 353011 SUL AMERICA (SW72)
---- CAD_PES_ID_PESSOA 2271 CASSI (SW60)
V_CURSOR PKG_CURSOR.T_CURSOR;
--BEGIN
--OPEN V_CURSOR FOR
--SELECT 1 FROM DUAL;
CURSOR ATU IS
    SELECT
           COB_TXT_ID,
           COB_TXT_FL_STATUS,
           CAD_PES_ID_PESSOA,
           COB_TXT_SEQ_GERAL,
           COB_TXT_CD_BENEF,
           COB_TXT_NM_BENEF,
           TRIM(COB_TXT_NR_GUIA) COB_TXT_NR_GUIA,
           COB_TXT_NR_LOTE_TISS,
           COB_TXT_DT_ATEND,
           COB_TXT_CD_SERVICO,
           upper(COB_TXT_DS_SERVICO)  cob_txt_ds_servico,
           COB_TXT_VL_MOVIMENTO,
           NVL(COB_TXT_VL_COFINS,0) COB_TXT_VL_COFINS,
           NVL(COB_TXT_VL_PIS,0) COB_TXT_VL_PIS,
           NVL(COB_TXT_VL_CSLL,0) COB_TXT_VL_CSLL,
           NVL(COB_TXT_VL_IR,0) COB_TXT_VL_IR,
           NVL(COB_TXT_VL_ISS,0) COB_TXT_VL_ISS,
           COB_TXT_DT_PAGTO,
           COB_TXT_DT_ATUALIZA_MGC,
           ASS_BCT_ID,
           COB_CCP_ID,
           COB_COC_ID,
           ATD_ATE_ID,
           CAD_PAC_ID_PACIENTE,
           FAT_NOF_ID,
           ATD_GUI_CD_CODIGO,
           TRUNC(ATD_GUI_DT_VALIDADE) ATD_GUI_DT_VALIDADE,
           COB_TXT_NR_SEQ_PAGTO,
           COB_TXT_NR_ANEXO,
           COB_TXT_VL_ITEM,
           COB_TXT_VL_GLOSA,
           COB_TXT_CD_GLOSA,
           COB_TXT_CD_ITEM,
           COB_TXT_QT_SEPAG,
           COB_TXT_VL_MOVIMENTO_ORIGEM
      FROM TB_COB_TXT_COBRANCA      TXT
     WHERE TXT.CAD_PES_ID_PESSOA  = PCAD_PES_ID_PESSOA
       AND TXT.COB_TXT_ID         = PCOB_TXT_ID
      -- AND TXT.FAT_NOF_ID IS NULL
       AND TXT.COB_TXT_FL_STATUS  = 'A'
       AND TXT.COB_TXT_DT_ATUALIZA_MGC IS NULL
       AND (TXT.COB_TXT_FL_PROCESSAR = 'S' OR TXT.COB_TXT_FL_PROCESSAR IS NULL)
  ORDER BY TXT.COB_TXT_ID, TXT.COB_TXT_SEQ_GERAL;
---
---
qtd  number(5);
QTD_GUIAS NUMBER(3);
---
aux_fat_ccp_id          tb_cob_ccp_conta_cons_parc.cob_ccp_id%TYPE;
aux_fat_coc_id          tb_cob_ccp_conta_cons_parc.cob_coc_id%TYPE;
aux_atd_ate_id          tb_cob_ccp_conta_cons_parc.atd_ate_id%TYPE;
aux_cad_pac_id_paciente tb_cob_ccp_conta_cons_parc.cad_pac_id_paciente%TYPE;
aux_fat_nof_id          tb_cob_ccp_conta_cons_parc.fat_nof_id%TYPE;
aux_atd_gui_cd_codigo   tb_cob_ccp_conta_cons_parc.atd_gui_cd_codigo%TYPE;
aux_atd_gui_dt_validade tb_cob_ccp_conta_cons_parc.atd_gui_dt_validade%TYPE;
---
aux_pc_ir               tb_fat_nof_nota_fiscal.FAT_NOF_PC_IR%type;
aux_pc_iss              tb_fat_nof_nota_fiscal.FAT_NOF_PC_iss%type;
aux_pc_pis              tb_fat_nof_nota_fiscal.FAT_NOF_PC_pis%type;
aux_pc_cofins           tb_fat_nof_nota_fiscal.FAT_NOF_PC_cofins%type;
aux_pc_csll             tb_fat_nof_nota_fiscal.FAT_NOF_PC_csll%type;
---
aux_vl_ir               tb_cob_txt_cobranca.COB_TXT_VL_IR%type;
aux_vl_iss              tb_cob_txt_cobranca.COB_TXT_VL_ISS%type;
aux_vl_pis              tb_cob_txt_cobranca.COB_TXT_VL_PIS%type;
aux_vl_cofins           tb_cob_txt_cobranca.COB_TXT_VL_COFINS%type;
aux_vl_csll             tb_cob_txt_cobranca.COB_TXT_VL_CSLL%type;
aux_vl_movimento        tb_cob_txt_cobranca.COB_TXT_VL_MOVIMENTO%type;


------------------------------------------------------------------
-------***********************************************************
--- subprocedure
--- calcula imposto para petrobras por guia
--- percentual esta fixo
---- 0.0120 IR ,
---- 0.0065 PIS,
---- 0.0300 COFINS,
---- 0.0100 CSLL
----
----
procedure calcula_imposto
    ( PCOB_TXT_ID IN TB_COB_TXT_COBRANCA.COB_TXT_ID%TYPE,
      PCAD_PES_ID_PESSOA IN TB_COB_TXT_COBRANCA.CAD_PES_ID_PESSOA%TYPE  )
   is
  begin
    DECLARE
CURSOR IMPOSTO IS
SELECT  TXT.CAD_PES_ID_PESSOA,
            TXT.COB_TXT_ID ,
            txt.cob_txt_nr_guia,
            txt.cob_txt_cd_benef,
            txt.cob_txt_nm_benef,
            TXT.COB_TXT_NR_LOTE_TISS,
            txt.cob_txt_seq_geral    linha ,
      --- sum ( TXT.COB_TXT_VL_MOVIMENTO_ORIGEM) VL_MOV_ORIGINAL,
       ( ( TXT.COB_TXT_VL_MOVIMENTO_ORIGEM)) * 0.00 VL_IR ,
       ( ( TXT.COB_TXT_VL_MOVIMENTO_ORIGEM)) * 0.00 VL_PIS,
       ( ( TXT.COB_TXT_VL_MOVIMENTO_ORIGEM)) * 0.00 VL_COFINS,
       ( ( TXT.COB_TXT_VL_MOVIMENTO_ORIGEM)) * 0.00 VL_CSLL

---  desativado  calcula imposto  para SP33
----
--- 09/03/2022 10:35 Amanda Tavares Dos Passos
--- entao eles nao estao mais retendo impostos de nada
---  a cintia falou pra deixar assim e conciliar da forma que eles pagam
---
---
/*
--- calcula imposto ajustando a terceita casa decimal
--- ir
case
when to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.0120), '99999.999'),10,1)) > 5 then
    to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.0120), '99999.999'),1,9)) + 0.01
else
   to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.0120), '99999.999'),1,9))
end  vl_ir,
----- pis
case
when to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.0065), '99999.999'),10,1)) > 5 then
    to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.0065), '99999.999'),1,9)) + 0.01
else
   to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.0065), '99999.999'),1,9))
end  vl_pis,
---- cofins
case
when to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.03), '99999.999'),10,1)) > 5 then
    to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.03), '99999.999'),1,9)) + 0.01
else
   to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.03), '99999.999'),1,9))
end   vl_cofins,
----csll
case
when to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.01), '99999.999'),10,1)) > 5 then
    to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.01), '99999.999'),1,9)) + 0.01
else
   to_number(substr( to_char( (txt.cob_txt_vl_movimento_origem * 0.01), '99999.999'),1,9))
end   vl_csll
----
*/
----
FROM TB_COB_TXT_COBRANCA      TXT
WHERE TXT.CAD_PES_ID_PESSOA  = PCAD_PES_ID_PESSOA
  AND TXT.COB_TXT_ID         = PCOB_TXT_ID
  and txt.cob_txt_vl_movimento_origem  > 0
  AND TXT.COB_TXT_FL_STATUS  = 'A'
  AND ( TXT.COB_TXT_FL_PROCESSAR = 'S' OR TXT.COB_TXT_FL_PROCESSAR IS NULL );
-----group by  TXT.CAD_PES_ID_PESSOA, TXT.COB_TXT_ID ,  txt.cob_txt_nr_guia ;
LINHA NUMBER(15);
BEGIN
FOR A IN IMPOSTO LOOP
---
---
 ---- select  max( txt2.cob_txt_seq_geral)  into linha
 ----     from    TB_COB_TXT_COBRANCA TXT2
 ----     where  TXT2.CAD_PES_ID_PESSOA  = A.CAD_PES_ID_PESSOA
 ----         AND TXT2.COB_TXT_ID        = A.COB_TXT_ID
 ----          and txt2.cob_txt_nr_guia  = a.cob_txt_nr_guia
 ----          and txt2.cob_txt_vl_movimento_origem > 0;
   update   TB_COB_TXT_COBRANCA TXT3
    set  txt3.cob_txt_vl_ir   =  A.VL_IR  ,
      txt3.cob_txt_vl_cofins =  A.VL_COFINS ,
      txt3.cob_txt_vl_csll     =  A.VL_CSLL  ,
      txt3.cob_txt_vl_pis      =  A.VL_PIS,
      cob_txt_vl_movimento =
           txt3.cob_txt_vl_movimento_origem - a.vl_ir - a.vl_cofins - a.vl_csll - a.vl_pis
      WHERE TXT3.CAD_PES_ID_PESSOA       =  a.CAD_PES_ID_PESSOA
          AND TXT3.COB_TXT_ID            =  a.COB_TXT_ID
           and txt3.cob_txt_nr_guia      =  a.cob_txt_nr_guia
           and txt3.cob_txt_cd_benef     =  a.cob_txt_cd_benef
           and txt3.cob_txt_nm_benef     =  a.cob_txt_nm_benef
           and NVL(TXT3.COB_TXT_NR_LOTE_TISS,0) =  NVL(a.cob_txt_nr_lote_tiss,0)
           and txt3.cob_txt_seq_geral    =  a.linha;
---
---
END LOOP;
    ------- para valores negativos nao calcular imposto
        update TB_COB_TXT_COBRANCA      TXT
        set  txt.cob_txt_vl_movimento =  txt.cob_txt_vl_movimento_origem ,
             txt.cob_txt_vl_ir    =  0 ,
             txt.cob_txt_vl_cofins = 0 ,
             txt.cob_txt_vl_csll   = 0 ,
             txt.cob_txt_vl_pis    = 0
        WHERE TXT.CAD_PES_ID_PESSOA  = PCAD_PES_ID_PESSOA
        AND TXT.COB_TXT_ID         = PCOB_TXT_ID
        and txt.cob_txt_vl_movimento_origem  < 0
        AND TXT.COB_TXT_FL_STATUS  = 'A'
        AND ( TXT.COB_TXT_FL_PROCESSAR = 'S' OR TXT.COB_TXT_FL_PROCESSAR IS NULL );
     --------
    commit;
end;
end calcula_imposto;
--- fim subprocedure
----********************************************************************
------------------------------------------------------------------------------------------------
----
---- inicio do processamento
----
----
BEGIN
  OPEN v_cursor FOR
select 1 from dual;
if PCAD_PES_ID_PESSOA = 3521 THEN
   ---- calcular imposto de orgao plubico para petrobras
     calcula_imposto( PCOB_TXT_ID, PCAD_PES_ID_PESSOA );
end if;
--------------------------------------------------------------

for a in atu
loop
---
aux_fat_nof_id :=  null;
---
---*********************************************************************************************
--- Bradesco CNV ID = 740,876,3422
IF A.CAD_PES_ID_PESSOA = 3572  THEN
   QTD_GUIAS := 0;
   ---- PARA INTERNADO CONTAR QTD DE PARCELAS QUE TEM A MESMO NUMERO DE GUIAS
   ---- QUANDO TEM MAIS DE UMA PARCELA DEIXAR COMO DIVERGENCIA PARA ESCOLHA MANUAL
   SELECT COUNT(*) INTO QTD_GUIAS
      FROM TB_COB_CCP_CONTA_CONS_PARC PARC
      WHERE PARC.ATD_ATE_TP_PACIENTE = 'I'
        AND TRIM(PARC.ATD_GUI_CD_SENHA) =TRIM(A.COB_TXT_NR_GUIA);
   AUX_FAT_NOF_ID :=  NULL;
   IF QTD_GUIAS < 2 THEN
        BEGIN
         SELECT COB.COB_CCP_ID, COB.COB_COC_ID, COB.ATD_ATE_ID, COB.CAD_PAC_ID_PACIENTE, COB.FAT_NOF_ID, COB.ATD_GUI_CD_CODIGO, TRUNC(COB.ATD_GUI_DT_VALIDADE), NVL(NOF.FAT_NOF_PC_IR,0) , NVL(NOF.FAT_NOF_PC_ISS,0), NVL(NOF.FAT_NOF_PC_PIS,0), NVL(NOF.FAT_NOF_PC_COFINS,0), NVL(NOF.FAT_NOF_PC_CSLL,0)
           INTO AUX_FAT_CCP_ID, AUX_FAT_COC_ID, AUX_ATD_ATE_ID, AUX_CAD_PAC_ID_PACIENTE, AUX_FAT_NOF_ID, AUX_ATD_GUI_CD_CODIGO, AUX_ATD_GUI_DT_VALIDADE, AUX_PC_IR, AUX_PC_ISS, AUX_PC_PIS , AUX_PC_COFINS, AUX_PC_CSLL
           FROM   TB_COB_CCP_CONTA_CONS_PARC COB,
                  TB_FAT_NOF_NOTA_FISCAL NOF
           WHERE  ---- QUANDO FOR INTERNADO PROCURAR PELO CODIGO DA SENHA
                   ---- QUANDO FOR AMBULATORIO E  PS  PROCURAR PELO ATENDCIMENTO + 2 DIGITOS DA PARCELA
             NOF.CAD_CNV_ID_CONVENIO IN (740,876,3422)
             AND (( COB.ATD_ATE_TP_PACIENTE = 'I'
                AND TRIM(COB.ATD_GUI_CD_SENHA) =TRIM(A.COB_TXT_NR_GUIA)
                AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID)
              OR
             ( COB.ATD_ATE_TP_PACIENTE <> 'I'
               AND COB.ATD_ATE_ID||TRIM(TO_CHAR(COB.COB_CCP_ID, '09'))= A.COB_TXT_NR_GUIA
               AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID) ) ;
           EXCEPTION
           WHEN TOO_MANY_ROWS THEN
               AUX_FAT_NOF_ID :=  NULL;
           WHEN NO_DATA_FOUND THEN
           BEGIN
               SELECT COB.COB_CCP_ID, COB.COB_COC_ID, COB.ATD_ATE_ID, COB.CAD_PAC_ID_PACIENTE, COB.FAT_NOF_ID, COB.ATD_GUI_CD_CODIGO, TRUNC(COB.ATD_GUI_DT_VALIDADE), NVL(NOF.FAT_NOF_PC_IR,0) , NVL(NOF.FAT_NOF_PC_ISS,0), NVL(NOF.FAT_NOF_PC_PIS,0), NVL(NOF.FAT_NOF_PC_COFINS,0), NVL(NOF.FAT_NOF_PC_CSLL,0)
                 INTO AUX_FAT_CCP_ID, AUX_FAT_COC_ID, AUX_ATD_ATE_ID, AUX_CAD_PAC_ID_PACIENTE, AUX_FAT_NOF_ID, AUX_ATD_GUI_CD_CODIGO, AUX_ATD_GUI_DT_VALIDADE, AUX_PC_IR, AUX_PC_ISS, AUX_PC_PIS , AUX_PC_COFINS, AUX_PC_CSLL
               FROM   TB_COB_CCP_CONTA_CONS_PARC COB,
                      TB_FAT_NOF_NOTA_FISCAL NOF
               WHERE  ---- QUANDO FOR INTERNADO PROCURAR PELO CODIGO DA SENHA
                       ---- QUANDO FOR AMBULATORIO E  PS  PROCURAR PELO ATENDCIMENTO + 2 DIGITOS DA PARCELA
                    NOF.CAD_CNV_ID_CONVENIO IN (740,876,3422)
                AND (( COB.ATD_ATE_TP_PACIENTE = 'I'
                      AND COB.ATD_ATE_ID||TRIM(TO_CHAR(COB.COB_CCP_ID))= A.COB_TXT_NR_GUIA
                      AND A.COB_TXT_DT_ATEND BETWEEN TRUNC(COB.COB_CCP_DT_PARCELA_INI) AND TRUNC(COB.COB_CCP_DT_PARCELA)
                      AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID)
               OR
                 ( COB.ATD_ATE_TP_PACIENTE <> 'I'
                   AND COB.ATD_ATE_ID||TRIM(COB.COB_CCP_ID)= A.COB_TXT_NR_GUIA
                   AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID)) ;
                EXCEPTION
             WHEN NO_DATA_FOUND THEN
                  AUX_FAT_NOF_ID :=  NULL;
              WHEN TOO_MANY_ROWS THEN
                  AUX_FAT_NOF_ID :=  NULL;
             END; --- DO  ATENDIMENTO + PARCELA 1 DIGITO
           END; --- DO  ATENDIMENTO + PARCELA 2 DIGITO;
      IF A.ATD_ATE_ID IS NOT NULL THEN  --SE O USUARIO ACHOU O ATENDIMENTO/PARCELA NA TELA
        BEGIN
           SELECT COB.COB_CCP_ID ,
                 COB.COB_COC_ID,
                 COB.ATD_ATE_ID ,
                 COB.CAD_PAC_ID_PACIENTE,
                 COB.FAT_NOF_ID,
                 COB.ATD_GUI_CD_CODIGO,
                 TRUNC(COB.ATD_GUI_DT_VALIDADE) ATD_GUI_DT_VALIDADE,
                 NOF.FAT_NOF_PC_IR ,
                 NOF.FAT_NOF_PC_ISS,
                 NOF.FAT_NOF_PC_PIS,
                 NOF.FAT_NOF_PC_COFINS,
                 NOF.FAT_NOF_PC_CSLL
            INTO
                AUX_FAT_CCP_ID , AUX_FAT_COC_ID,
                AUX_ATD_ATE_ID , AUX_CAD_PAC_ID_PACIENTE, AUX_FAT_NOF_ID,
                AUX_ATD_GUI_CD_CODIGO,
                AUX_ATD_GUI_DT_VALIDADE,
                AUX_PC_IR  ,
                AUX_PC_ISS ,
                AUX_PC_PIS ,
                AUX_PC_COFINS,
                AUX_PC_CSLL
             FROM   TB_COB_CCP_CONTA_CONS_PARC COB,
                    TB_FAT_NOF_NOTA_FISCAL NOF
             WHERE
                    NOF.CAD_CNV_ID_CONVENIO IN (740,876,3422)
                AND COB.COB_CCP_ID          = A.COB_CCP_ID
                AND COB.COB_COC_ID          = A.COB_COC_ID
                AND COB.ATD_ATE_ID          = A.ATD_ATE_ID
                AND COB.CAD_PAC_ID_PACIENTE = A.CAD_PAC_ID_PACIENTE
                AND COB.FAT_NOF_ID          = A.FAT_NOF_ID
                AND COB.ATD_GUI_CD_CODIGO   = A.ATD_GUI_CD_CODIGO
                AND TRUNC(COB.ATD_GUI_DT_VALIDADE) = TRUNC(A.ATD_GUI_DT_VALIDADE)  ;
             EXCEPTION
             WHEN NO_DATA_FOUND THEN
                  AUX_FAT_NOF_ID :=  NULL;
             WHEN TOO_MANY_ROWS THEN
                  aux_fat_nof_id :=  null;
             END;
           END IF;
     END IF;
   end if; --- fim da bradesco
---
---**********************************************************************************************
--- SUL AMERICA(CNV_ID=921) OR PETROBRAS(CNV_ID=731) OR CASSI(CNV_ID=487) OR CESP(CNV_ID=411) OR GOLDEN(CNV_ID=720) --2942=correios
--cabesp SP54 idPES=3627    petrobras tem tbem SP99 cnv_id=3462
IF A.CAD_PES_ID_PESSOA IN (353011, 3521, 2271, 1849, 3448, 2942, 1566500, 3627 ) THEN
   BEGIN   --- COM 2 DIGITOS DA PARCELA
   SELECT COB.COB_CCP_ID, COB.COB_COC_ID, COB.ATD_ATE_ID, COB.CAD_PAC_ID_PACIENTE, COB.FAT_NOF_ID, COB.ATD_GUI_CD_CODIGO, TRUNC(COB.ATD_GUI_DT_VALIDADE), NVL(NOF.FAT_NOF_PC_IR,0) , NVL(NOF.FAT_NOF_PC_ISS,0), NVL(NOF.FAT_NOF_PC_PIS,0), NVL(NOF.FAT_NOF_PC_COFINS,0), NVL(NOF.FAT_NOF_PC_CSLL,0)
     INTO AUX_FAT_CCP_ID, AUX_FAT_COC_ID, AUX_ATD_ATE_ID, AUX_CAD_PAC_ID_PACIENTE, AUX_FAT_NOF_ID, AUX_ATD_GUI_CD_CODIGO, AUX_ATD_GUI_DT_VALIDADE, AUX_PC_IR, AUX_PC_ISS, AUX_PC_PIS , AUX_PC_COFINS, AUX_PC_CSLL
     FROM TB_COB_CCP_CONTA_CONS_PARC COB,
          TB_FAT_NOF_NOTA_FISCAL     NOF
    WHERE
     ((A.CAD_PES_ID_PESSOA = 353011 AND NOF.CAD_CNV_ID_CONVENIO in (1002,922,1001,921, 551)) OR
              (A.CAD_PES_ID_PESSOA = 3521 AND NOF.CAD_CNV_ID_CONVENIO in (731,892,370, 3462)) OR
              (A.CAD_PES_ID_PESSOA = 2271 AND NOF.CAD_CNV_ID_CONVENIO =487) OR
              (A.CAD_PES_ID_PESSOA = 1849 AND NOF.CAD_CNV_ID_CONVENIO =411) OR
              (A.CAD_PES_ID_PESSOA = 3448 AND NOF.CAD_CNV_ID_CONVENIO =720) OR
              (A.CAD_PES_ID_PESSOA = 2942 AND NOF.CAD_CNV_ID_CONVENIO =626) OR
              (A.CAD_PES_ID_PESSOA = 1566500 AND NOF.CAD_CNV_ID_CONVENIO =2702) OR
              (A.CAD_PES_ID_PESSOA = 3627 AND NOF.CAD_CNV_ID_CONVENIO =752) )
     AND (( COB.ATD_ATE_TP_PACIENTE = 'I'  ---- QUANDO FOR INTERNADO  COMPARAR TAMBEM  PERIODO DA PARCELA
              AND COB.ATD_ATE_ID||TRIM(TO_CHAR(COB.COB_CCP_ID, '09'))= TO_NUMBER(A.COB_TXT_NR_GUIA)
              --- inativo 15/06/2016 neide AND A.COB_TXT_DT_ATEND BETWEEN TRUNC(COB.COB_CCP_DT_PARCELA_INI)AND TRUNC(COB.COB_CCP_DT_PARCELA)
              AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID)
            OR
           ( COB.ATD_ATE_TP_PACIENTE <> 'I'
             AND COB.ATD_ATE_ID||TRIM(TO_CHAR(COB.COB_CCP_ID, '09'))= TO_NUMBER(A.COB_TXT_NR_GUIA)
             AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID  )) ;
   EXCEPTION
      WHEN NO_DATA_FOUND THEN
      BEGIN    ---- COM 1 DIGITO DA PARCELA
      SELECT COB.COB_CCP_ID, COB.COB_COC_ID, COB.ATD_ATE_ID, COB.CAD_PAC_ID_PACIENTE, COB.FAT_NOF_ID, COB.ATD_GUI_CD_CODIGO, TRUNC(COB.ATD_GUI_DT_VALIDADE), NVL(NOF.FAT_NOF_PC_IR,0) , NVL(NOF.FAT_NOF_PC_ISS,0), NVL(NOF.FAT_NOF_PC_PIS,0), NVL(NOF.FAT_NOF_PC_COFINS,0), NVL(NOF.FAT_NOF_PC_CSLL,0)
               INTO AUX_FAT_CCP_ID, AUX_FAT_COC_ID, AUX_ATD_ATE_ID, AUX_CAD_PAC_ID_PACIENTE, AUX_FAT_NOF_ID, AUX_ATD_GUI_CD_CODIGO, AUX_ATD_GUI_DT_VALIDADE, AUX_PC_IR, AUX_PC_ISS, AUX_PC_PIS , AUX_PC_COFINS, AUX_PC_CSLL
               FROM TB_COB_CCP_CONTA_CONS_PARC COB,
                    TB_FAT_NOF_NOTA_FISCAL     NOF
              WHERE  ((A.CAD_PES_ID_PESSOA = 353011 AND NOF.CAD_CNV_ID_CONVENIO IN (1002,922,1001,921 , 551)) OR
                    (A.CAD_PES_ID_PESSOA = 3521 AND NOF.CAD_CNV_ID_CONVENIO IN (731,892,370, 3462)) OR
                    (A.CAD_PES_ID_PESSOA = 2271 AND NOF.CAD_CNV_ID_CONVENIO =487) OR
                    (A.CAD_PES_ID_PESSOA = 1849 AND NOF.CAD_CNV_ID_CONVENIO =411) OR
                    (A.CAD_PES_ID_PESSOA = 3448 AND NOF.CAD_CNV_ID_CONVENIO =720) OR
                    (A.CAD_PES_ID_PESSOA = 2942 AND NOF.CAD_CNV_ID_CONVENIO =626) OR
                    (A.CAD_PES_ID_PESSOA = 1566500 AND NOF.CAD_CNV_ID_CONVENIO =2702) OR
                    (A.CAD_PES_ID_PESSOA = 3627 AND NOF.CAD_CNV_ID_CONVENIO =752))
              AND   (( COB.ATD_ATE_TP_PACIENTE = 'I'
                         AND COB.ATD_ATE_ID||TRIM(TO_CHAR(COB.COB_CCP_ID))= TO_NUMBER(A.COB_TXT_NR_GUIA)
                          AND A.COB_TXT_DT_ATEND BETWEEN TRUNC(COB.COB_CCP_DT_PARCELA_INI) AND TRUNC(COB.COB_CCP_DT_PARCELA)
                          AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID )
                         OR
                       ( COB.ATD_ATE_TP_PACIENTE <> 'I'
                         AND COB.ATD_ATE_ID||TRIM(TO_CHAR(COB.COB_CCP_ID))= TO_NUMBER(A.COB_TXT_NR_GUIA)
                         AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID ));
      EXCEPTION
          WHEN NO_DATA_FOUND THEN
          BEGIN  ---- SOMENTE ATENDIMENTO
          SELECT COB.COB_CCP_ID, COB.COB_COC_ID, COB.ATD_ATE_ID, COB.CAD_PAC_ID_PACIENTE, COB.FAT_NOF_ID, COB.ATD_GUI_CD_CODIGO, TRUNC(COB.ATD_GUI_DT_VALIDADE), NVL(NOF.FAT_NOF_PC_IR,0) , NVL(NOF.FAT_NOF_PC_ISS,0), NVL(NOF.FAT_NOF_PC_PIS,0), NVL(NOF.FAT_NOF_PC_COFINS,0), NVL(NOF.FAT_NOF_PC_CSLL,0)
               INTO AUX_FAT_CCP_ID, AUX_FAT_COC_ID, AUX_ATD_ATE_ID, AUX_CAD_PAC_ID_PACIENTE, AUX_FAT_NOF_ID, AUX_ATD_GUI_CD_CODIGO, AUX_ATD_GUI_DT_VALIDADE, AUX_PC_IR, AUX_PC_ISS, AUX_PC_PIS , AUX_PC_COFINS, AUX_PC_CSLL
               FROM TB_COB_CCP_CONTA_CONS_PARC COB,
                    TB_FAT_NOF_NOTA_FISCAL     NOF
              WHERE ((A.CAD_PES_ID_PESSOA = 353011 AND NOF.CAD_CNV_ID_CONVENIO IN (1002,922,1001,921, 551)) OR
                    (A.CAD_PES_ID_PESSOA = 3521 AND NOF.CAD_CNV_ID_CONVENIO IN (731,892,370, 3462)) OR
                    (A.CAD_PES_ID_PESSOA = 2271 AND NOF.CAD_CNV_ID_CONVENIO =487) OR
                    (A.CAD_PES_ID_PESSOA = 1849 AND NOF.CAD_CNV_ID_CONVENIO =411) OR
                    (A.CAD_PES_ID_PESSOA = 3448 AND NOF.CAD_CNV_ID_CONVENIO =720)OR
                    (A.CAD_PES_ID_PESSOA = 2942 AND NOF.CAD_CNV_ID_CONVENIO =626) OR
                    (A.CAD_PES_ID_PESSOA = 1566500 AND NOF.CAD_CNV_ID_CONVENIO =2702) OR
                    (A.CAD_PES_ID_PESSOA = 3627 AND NOF.CAD_CNV_ID_CONVENIO =752))
               AND (( COB.ATD_ATE_TP_PACIENTE = 'I'
                    AND TRIM(TO_CHAR(COB.ATD_ATE_ID))= TO_NUMBER(A.COB_TXT_NR_GUIA)
                    AND A.COB_TXT_DT_ATEND BETWEEN TRUNC(COB.COB_CCP_DT_PARCELA_INI) AND TRUNC(COB.COB_CCP_DT_PARCELA)
                    AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID )
                  OR
                    ( COB.ATD_ATE_TP_PACIENTE <> 'I'
                   AND TRIM(TO_CHAR(COB.ATD_ATE_ID))= TO_NUMBER(A.COB_TXT_NR_GUIA)
                   AND COB.FAT_NOF_ID = NOF.FAT_NOF_ID ));
          EXCEPTION
              WHEN NO_DATA_FOUND THEN
                  AUX_FAT_NOF_ID :=  NULL;
                  IF A.ATD_ATE_ID IS NOT NULL THEN  --SE O USUARIO ACHOU O ATENDIMENTO/PARCELA NA TELA
                      BEGIN
                      SELECT COB.COB_CCP_ID, COB.COB_COC_ID, COB.ATD_ATE_ID, COB.CAD_PAC_ID_PACIENTE, COB.FAT_NOF_ID, COB.ATD_GUI_CD_CODIGO, TRUNC(COB.ATD_GUI_DT_VALIDADE), NVL(NOF.FAT_NOF_PC_IR,0) , NVL(NOF.FAT_NOF_PC_ISS,0), NVL(NOF.FAT_NOF_PC_PIS,0), NVL(NOF.FAT_NOF_PC_COFINS,0), NVL(NOF.FAT_NOF_PC_CSLL,0)
                         INTO AUX_FAT_CCP_ID, AUX_FAT_COC_ID, AUX_ATD_ATE_ID, AUX_CAD_PAC_ID_PACIENTE, AUX_FAT_NOF_ID, AUX_ATD_GUI_CD_CODIGO, AUX_ATD_GUI_DT_VALIDADE, AUX_PC_IR, AUX_PC_ISS, AUX_PC_PIS , AUX_PC_COFINS, AUX_PC_CSLL
                         FROM TB_COB_CCP_CONTA_CONS_PARC COB,
                              TB_FAT_NOF_NOTA_FISCAL NOF
                        WHERE ((A.CAD_PES_ID_PESSOA = 353011 AND NOF.CAD_CNV_ID_CONVENIO IN (1002,922,1001,921 , 551)) OR
                                    (A.CAD_PES_ID_PESSOA = 3521 AND NOF.CAD_CNV_ID_CONVENIO IN (731,892,370, 3462)) OR
                                    (A.CAD_PES_ID_PESSOA = 2271 AND NOF.CAD_CNV_ID_CONVENIO =487) OR
                                    (A.CAD_PES_ID_PESSOA = 1849 AND NOF.CAD_CNV_ID_CONVENIO =411) OR
                                    (A.CAD_PES_ID_PESSOA = 3448 AND NOF.CAD_CNV_ID_CONVENIO =720) OR
                                    (A.CAD_PES_ID_PESSOA = 2942 AND NOF.CAD_CNV_ID_CONVENIO =626) OR
                                    (A.CAD_PES_ID_PESSOA = 1566500 AND NOF.CAD_CNV_ID_CONVENIO =2702) OR
                                    (A.CAD_PES_ID_PESSOA = 3627 AND NOF.CAD_CNV_ID_CONVENIO =752))
                           AND COB.COB_CCP_ID          = A.COB_CCP_ID
                          AND COB.COB_COC_ID          = A.COB_COC_ID
                          AND COB.ATD_ATE_ID          = A.ATD_ATE_ID
                          AND COB.CAD_PAC_ID_PACIENTE = A.CAD_PAC_ID_PACIENTE
                          AND COB.FAT_NOF_ID          = A.FAT_NOF_ID
                          AND COB.ATD_GUI_CD_CODIGO   = A.ATD_GUI_CD_CODIGO
                          AND TRUNC(COB.ATD_GUI_DT_VALIDADE) = TRUNC(A.ATD_GUI_DT_VALIDADE)  ;
                      EXCEPTION
                      WHEN NO_DATA_FOUND THEN AUX_FAT_NOF_ID :=  NULL;
                      WHEN TOO_MANY_ROWS THEN aux_fat_nof_id :=  null;
                      END;
                  END IF;
             WHEN TOO_MANY_ROWS THEN AUX_FAT_NOF_ID :=  NULL;
              END; --- DO SOMENTE ATENDIMENTO
          WHEN TOO_MANY_ROWS THEN AUX_FAT_NOF_ID :=  NULL;
      END; --- DO 1 DIGITO
   END; --- DO 2 DIGITOS
END IF; ---  FIM SUL AMERICA OR PETROBRAS OR CASSI
 ---**********************************************************---
 --- gravar atendimento/conta/parcela/paciente/nota fiscal

 ---- quando for nota de credito nao calcular impostos
     if AUX_FAT_NOF_ID > 0  and  a.cob_txt_ds_servico = 'NOTA DE CREDITO' then
          AUX_PC_IR     := 0;
          AUX_PC_ISS    := 0;
          AUX_PC_PIS    := 0;
          AUX_PC_COFINS := 0;
          AUX_PC_CSLL   := 0;
      ELSE
         NULL;
      end if;
--------------------------------------------------------------------


       IF AUX_FAT_NOF_ID > 0 THEN
          IF A.CAD_PES_ID_PESSOA = 353011
            or  a.CAD_PES_ID_PESSOA = 2271   THEN
            ------- SUL AMERICA   , CALCULAR RETENCOES E DEDUZIR DO VALOR PAGO
             AUX_VL_IR     := NVL( ( A.COB_TXT_VL_MOVIMENTO_ORIGEM * AUX_PC_IR     ) ,0) /100 ;
             AUX_VL_ISS    := NVL( ( A.COB_TXT_VL_MOVIMENTO_ORIGEM * AUX_PC_ISS    ) ,0) /100 ;
             AUX_VL_PIS    := NVL( ( A.COB_TXT_VL_MOVIMENTO_ORIGEM * AUX_PC_PIS    ) ,0) /100 ;
             AUX_VL_COFINS := NVL( ( A.COB_TXT_VL_MOVIMENTO_ORIGEM * AUX_PC_COFINS ) ,0) /100 ;
             AUX_VL_CSLL   := NVL( ( A.COB_TXT_VL_MOVIMENTO_ORIGEM * AUX_PC_CSLL   ) ,0) /100 ;
            -----
             AUX_VL_MOVIMENTO := A.COB_TXT_VL_MOVIMENTO_ORIGEM -
                                 (AUX_VL_IR + AUX_VL_ISS + AUX_VL_PIS + AUX_VL_COFINS + AUX_VL_CSLL);
             UPDATE TB_COB_TXT_COBRANCA
                 SET COB_CCP_ID          = AUX_FAT_CCP_ID,
                     COB_COC_ID          = AUX_FAT_COC_ID,
                     ATD_ATE_ID          = AUX_ATD_ATE_ID,
                     CAD_PAC_ID_PACIENTE = AUX_CAD_PAC_ID_PACIENTE,
                     FAT_NOF_ID          = AUX_FAT_NOF_ID,
                     ATD_GUI_CD_CODIGO   = AUX_ATD_GUI_CD_CODIGO,
                     ATD_GUI_DT_VALIDADE = TRUNC(AUX_ATD_GUI_DT_VALIDADE),
                     ---
                     COB_TXT_VL_MOVIMENTO =  AUX_VL_MOVIMENTO ,
                     COB_TXT_PC_COFINS    =  AUX_PC_COFINS ,
                     COB_TXT_PC_PIS       =  AUX_PC_PIS    ,
                     COB_TXT_PC_CSLL      =  AUX_PC_CSLL   ,
                     COB_TXT_PC_IR        =  AUX_PC_IR     ,
                     COB_TXT_PC_ISS       =  AUX_PC_ISS    ,
                     ---
                     COB_TXT_VL_COFINS    = AUX_VL_COFINS,
                     COB_TXT_VL_PIS       = AUX_VL_PIS,
                     COB_TXT_VL_CSLL      = AUX_VL_CSLL,
                     COB_TXT_VL_IR        = AUX_VL_IR,
                     COB_TXT_VL_ISS       = AUX_VL_ISS,
                     COB_TXT_FL_PROCESSAR = DECODE(AUX_ATD_ATE_ID,NULL,'S','N') --PROCESSAR SEMPRE QUE N?O ACHAR O ATENDIMENTO
                 WHERE COB_TXT_ID         = A.COB_TXT_ID
                   AND CAD_PES_ID_PESSOA  = A.CAD_PES_ID_PESSOA
                   AND COB_TXT_SEQ_GERAL  = A.COB_TXT_SEQ_GERAL
                   AND COB_TXT_DT_PAGTO   = A.COB_TXT_DT_PAGTO
                   AND ASS_BCT_ID         = A.ASS_BCT_ID
                   AND COB_TXT_FL_STATUS  = A.COB_TXT_FL_STATUS;
          ELSE
             UPDATE TB_COB_TXT_COBRANCA
                 SET COB_CCP_ID          = AUX_FAT_CCP_ID,
                     COB_COC_ID          = AUX_FAT_COC_ID,
                     ATD_ATE_ID          = AUX_ATD_ATE_ID,
                     CAD_PAC_ID_PACIENTE = AUX_CAD_PAC_ID_PACIENTE,
                     FAT_NOF_ID          = AUX_FAT_NOF_ID,
                     ATD_GUI_CD_CODIGO   = AUX_ATD_GUI_CD_CODIGO,
                     ATD_GUI_DT_VALIDADE = TRUNC(AUX_ATD_GUI_DT_VALIDADE),
                     ---
                    -- COB_TXT_VL_MOVIMENTO =  AUX_VL_MOVIMENTO ,
                     COB_TXT_PC_COFINS    =  AUX_PC_COFINS ,
                     COB_TXT_PC_PIS       =  AUX_PC_PIS    ,
                     COB_TXT_PC_CSLL      =  AUX_PC_CSLL   ,
                     COB_TXT_PC_IR        =  AUX_PC_IR     ,
                     COB_TXT_PC_ISS       =  AUX_PC_ISS   ,
                     COB_TXT_FL_PROCESSAR = DECODE(AUX_ATD_ATE_ID,NULL,'S','N') --PROCESSAR SEMPRE QUE N?O ACHAR O ATENDIMENTO
                 WHERE COB_TXT_ID         = A.COB_TXT_ID
                   AND CAD_PES_ID_PESSOA  = A.CAD_PES_ID_PESSOA
                   AND COB_TXT_SEQ_GERAL  = A.COB_TXT_SEQ_GERAL
                   AND COB_TXT_DT_PAGTO   = A.COB_TXT_DT_PAGTO
                   AND ASS_BCT_ID         = A.ASS_BCT_ID
                   AND COB_TXT_FL_STATUS  = A.COB_TXT_FL_STATUS;
          END IF;
       END IF;   --- FIM DA GRAVACAO
QTD := NVL(QTD,0) + 1;
IF QTD > 50 THEN
  COMMIT;
  QTD := 1;
END IF;
------
END LOOP;
---
commit;
---
 --io_cursor := v_cursor;
END PRC_COB_TXT_GUIA;
