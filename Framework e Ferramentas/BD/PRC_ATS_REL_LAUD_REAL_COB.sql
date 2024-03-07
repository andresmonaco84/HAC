CREATE OR REPLACE PROCEDURE "PRC_ATS_REL_LAUD_REAL_COB"(
pMES IN Tb_Fat_Cci_Conta_Consu_Item.Fat_Cci_Mes_Fechamento%type,
pANO IN Tb_Fat_Cci_Conta_Consu_Item.Fat_Cci_Ano_Fechamento%type,
PCAD_UNI_ID_UNIDADE IN TB_ATS_ATE_ATENDIMENTO_SADT.CAD_UNI_ID_UNIDADE_LIBERACAO%type DEFAULT NULL,
PCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATS_ATE_ATENDIMENTO_SADT.CAD_UNI_ID_LOCAL_LIBERACAO%type DEFAULT NULL,
PAUX_EPP_CD_ESPECPROC IN TB_ATS_ATE_ATENDIMENTO_SADT.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
PFILTRAREXAMESNAOLANCADOSFAT VARCHAR2 DEFAULT NULL,
io_cursor        OUT PKG_CURSOR.t_cursor
   -- , teste OUT LONG
) is
  /********************************************************************
  *    Procedure: PRC_ATS_REL_LAUD_COB
  *
  *    Data Criacao:  17/11/2014   Por: Pedro H.A.C.
  *
  *    Funcao:
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT  varchar2(20000);
  V_HAVING varchar2(500);
  begin
V_WHERE := NULL;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE := V_WHERE || ' AND S.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND S.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
IF pAUX_EPP_CD_ESPECPROC IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATS.AUX_EPP_CD_ESPECPROC = ' ||CHR(39)|| pAUX_EPP_CD_ESPECPROC ||CHR(39);    END IF;    
V_HAVING:=NULL;
IF PFILTRAREXAMESNAOLANCADOSFAT IS NOT NULL THEN V_HAVING := V_HAVING || '  HAVING NVL(COUNT(LANCADO.QTD), 0) = 0 ';    END IF;    
--      AND ( (PFILTRAREXAMESNAOLANCADOSFAT IS NOT NULL AND LANCADO.QTD IS  NULL) 
  --     OR PFILTRAREXAMESNAOLANCADOSFAT IS NULL)
 V_SELECT := '
 SELECT  ATS.ATS_ATE_CD_INTLIB,
                    ATS.ATS_ATE_IN_INTLIB,
                    ATS.CAD_PRD_ID,
                    PRD.CAD_PRD_CD_CODIGO,
                    PRD.CAD_PRD_NM_MNEMONICO,
                    PRD.CAD_PRD_DS_DESCRICAO,
                    EPP.AUX_EPP_DS_DESCRICAO,
                    TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, ''MM'') MES,
                    TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, ''yyyy'') ANO,
                    PES_PAC.CAD_PES_NM_PESSOA NM_PACIENTE,
                    PES_PAC.CAD_PES_DT_NASCIMENTO,
                    PAC.CAD_PAC_NR_PRONTUARIO,
                    decode(pla.cad_pla_cd_tipoplano,
                           ''FU'',
                           ''FUNCIONARIO'',
                           ''PA'',
                           ''PA'',
                           ''GB'',
                           ''GLOBAL'',
                           ''PL'',
                           ''PESSOA FISICA'',
                           ''SP'',
                           ''SERVICOS PRESTADOS'',
                           ''TODOS'') tipo_empresa,
                    CNV.CAD_CNV_CD_HAC_PRESTADOR,
                    PLA.CAD_PLA_CD_PLANO_HAC,
                    UNI.CAD_UNI_DS_UNIDADE,
                    LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                    COUNT(ATS.ATS_ATE_CD_INTLIB)  QTD_REALIZADA
                    ,
                   --  COUNT(CCI.ATS_APL_ID)  QTD_COBRADA
                   NVL(COUNT(LANCADO.QTD), 0) QTD_COBRADA
      FROM TB_ATS_ATE_ATENDIMENTO_SADT ATS
      LEFT JOIN TB_ATS_APL_ATEN_PROCED_LAUDO APL
                  ON APL.ATS_ATE_ID = ATS.ATS_ATE_ID
                 AND APL.ATS_ATE_CD_INTLIB = ATS.ATS_ATE_CD_INTLIB
                 AND APL.ATS_ATE_IN_INTLIB = ATS.ATS_ATE_IN_INTLIB
                 AND APL.AUX_EPP_CD_ESPECPROC = ATS.AUX_EPP_CD_ESPECPROC
                 AND APL.CAD_PRD_ID = ATS.CAD_PRD_ID
                 AND APL.TIS_MED_CD_TABELAMEDICA = ATS.TIS_MED_CD_TABELAMEDICA
                 AND APL.ATS_APL_STATUS_LAUDO IN (''L'',''P'')
      JOIN TB_CAD_PRD_PRODUTO PRD        ON PRD.CAD_PRD_ID = ATS.CAD_PRD_ID
      JOIN TB_AUX_EPP_ESPECPROC EPP        ON EPP.AUX_EPP_CD_ESPECPROC = ATS.AUX_EPP_CD_ESPECPROC
                                           AND EPP.TIS_MED_CD_TABELAMEDICA = ATS.TIS_MED_CD_TABELAMEDICA
      JOIN TB_CAD_PAC_PACIENTE PAC        ON PAC.CAD_PAC_ID_PACIENTE = ATS.CAD_PAC_ID_PACIENTE_INT
      JOIN TB_CAD_PES_PESSOA PES_PAC        ON PES_PAC.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
      JOIN TB_CAD_PLA_PLANO PLA        ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
      JOIN TB_CAD_CNV_CONVENIO CNV        ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
      JOIN TB_CAD_SET_SETOR S  ON S.CAD_SET_ID = ATS.CAD_SET_ID_ATEN
      JOIN TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = S.CAD_UNI_ID_UNIDADE
      JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = S.CAD_LAT_ID_LOCAL_ATENDIMENTO
    --  JOIN TB_ATD_ATE_ATENDIMENTO ATE ON ATE.ATD_ATE_ID = ATS.ATS_ATE_CD_INTLIB
    --  AND ATE.ATD_ATE_FL_STATUS=''A''
      /*LEFT JOIN TB_FAT_CCI_CONTA_CONSU_ITEM CCI
      ON CCI.ATD_ATE_ID = ATS.ATS_ATE_CD_INTLIB
      AND CCI.ATS_APL_ID = APL.ATS_APL_ID
      AND CCI.FAT_CCI_FL_STATUS = ''A''
      AND CCI.CAD_TAP_TP_ATRIBUTO = ''EXA''*/
 LEFT JOIN (SELECT DISTINCT CCI.ATD_ATE_ID ATENDIMENTO, 1 QTD
                   FROM TB_ATD_ATE_ATENDIMENTO ATE
                   JOIN TB_FAT_CCI_CONTA_CONSU_ITEM CCI
                     ON CCI.ATD_ATE_ID = ATE.ATD_ATE_ID
                    AND CCI.CAD_TAP_TP_ATRIBUTO = ''EXA''
                    AND to_char(CCI.FAT_CCI_DT_INICIO_CONSUMO, ''YYYY'') = '||CHR(39)|| pANO ||CHR(39)||'
                    AND to_number(to_char(CCI.FAT_CCI_DT_INICIO_CONSUMO, ''MM'')) = '||CHR(39)|| pMES ||CHR(39)||'
                    and ate.atd_ate_fl_status = ''A''
                 --and ate.atd_ate_tp_paciente in (''I'',''E'')
                 ) LANCADO
        ON LANCADO.ATENDIMENTO = ATS.ATS_ATE_CD_INTLIB
     WHERE TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, ''YYYY'') = '||CHR(39)|| pANO ||CHR(39)||'
       AND to_number(TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, ''MM'')) = '||CHR(39)|| pMES ||CHR(39)||'
       AND ATS.ATS_ATE_FL_STATUS = ''A''
       AND ATS_ATE_FL_REPETICAO = ''N''
       AND ATS.AUX_EPP_CD_ESPECPROC NOT IN (''23'',''30'',''39'',''40'')
       ' || V_WHERE || '
      GROUP BY ATS.ATS_ATE_CD_INTLIB,
                    ATS.ATS_ATE_IN_INTLIB,
                    ATS.CAD_PRD_ID,
                    PRD.CAD_PRD_CD_CODIGO,
                    PRD.CAD_PRD_NM_MNEMONICO,
                    PRD.CAD_PRD_DS_DESCRICAO,
                    EPP.AUX_EPP_DS_DESCRICAO,
                    TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, ''MM'') ,
                    TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, ''yyyy'') ,
                   --, LANCADO.ATS_APL_ID
                    PES_PAC.CAD_PES_NM_PESSOA ,
                    PES_PAC.CAD_PES_DT_NASCIMENTO,                    
                    PAC.CAD_PAC_NR_PRONTUARIO,
                    decode(pla.cad_pla_cd_tipoplano,
                           ''FU'',
                           ''FUNCIONARIO'',
                           ''PA'',
                           ''PA'',
                           ''GB'',
                           ''GLOBAL'',
                           ''PL'',
                           ''PESSOA FISICA'',
                           ''SP'',
                           ''SERVICOS PRESTADOS'',
                           ''TODOS'') ,
                    CNV.CAD_CNV_CD_HAC_PRESTADOR,
                    PLA.CAD_PLA_CD_PLANO_HAC,
                    UNI.CAD_UNI_DS_UNIDADE,
                    LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO
'
|| V_HAVING;
   --  teste:= v_select;
OPEN v_cursor FOR
     V_SELECT ;
    -- select 1 from dual;
    io_cursor := v_cursor;
end PRC_ATS_REL_LAUD_REAL_COB;
