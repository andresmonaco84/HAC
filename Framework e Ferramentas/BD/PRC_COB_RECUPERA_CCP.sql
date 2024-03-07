CREATE OR REPLACE PROCEDURE "PRC_COB_RECUPERA_CCP"
(
     pCAD_PES_ID_PESSOA IN TB_COB_TXT_COBRANCA.CAD_PES_ID_PESSOA%type,
     pNOME_BENEFICIARIO VARCHAR2,
    -- TESTE OUT  LONG,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/*****************************************************************************
*    Procedure: PRC_COB_RECUPERA_CCP
*
*    Data Criacao:   25/07/2012    Por: PEDRO
*    Data Alteracao:
*
*    Funcao: Lista POSSIBILIDADES DE PARCELAS PARA ASSOCIAR AO TXT DO CONVENIO
*******************************************************************************/
v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(1500);
  V_SELECT  varchar2(8000);
  idtConvenio number  ;
begin
  V_WHERE := NULL;
 select cnv.cad_cnv_id_convenio into idtConvenio from tb_cad_cnv_convenio cnv where cnv.cad_pes_id_pessoa = pCAD_PES_ID_PESSOA and rownum=1;
  --SULAMERICA
  IF idtConvenio in ( 921, 922, 1001, 1002 ) THEN V_WHERE:= V_WHERE || 'CNV.CAD_CNV_ID_CONVENIO IN ( 921, 922, 1001, 1002 ) ' ; END IF;
  --PETROBRAS
  IF idtConvenio in ( 876, 740, 3422 ) THEN V_WHERE:= V_WHERE || 'CNV.CAD_CNV_ID_CONVENIO IN ( 876, 740, 3422 ) ' ; END IF;
  --BRADESCO
  IF idtConvenio in ( 370, 731, 892 ) THEN V_WHERE:= V_WHERE || 'CNV.CAD_CNV_ID_CONVENIO IN ( 370, 731, 892 ) ' ; END IF;
  --CASSI
  IF idtConvenio = 487 THEN V_WHERE:= V_WHERE || 'CNV.CAD_CNV_ID_CONVENIO = ' || idtConvenio; END IF;
 IF LENGTH(pNOME_BENEFICIARIO) = 3 THEN V_WHERE:= V_WHERE || ' AND SUBSTR(CCP.CAD_PES_NM_PESSOA,1,3) = '||CHR(39)|| pNOME_BENEFICIARIO ||CHR(39) ; 
 ELSE V_WHERE:= V_WHERE || ' AND CCP.CAD_PES_NM_PESSOA = '||CHR(39)|| pNOME_BENEFICIARIO ||CHR(39) ; 
 END IF;
 IF LENGTH(pNOME_BENEFICIARIO) = 3 THEN V_WHERE:= V_WHERE || 'AND TO_CHAR(CCP.COB_CCP_DT_PARCELA,'||CHR(39)||'MMyyyy'||CHR(39)||') between TO_CHAR(sysdate-150,'||CHR(39)||'MMyyyy'||CHR(39)||') AND TO_CHAR(sysdate,'||CHR(39)||'MMyyyy'||CHR(39)||')' ; 
 ELSE V_WHERE:= V_WHERE || ' AND CCP.COB_CCP_DT_PARCELA between TRUNC(sysdate-210) AND TRUNC(sysdate)' ;
 END IF;
   V_SELECT := '
SELECT    
          CCP.ATD_GUI_CD_CODIGO,
          CCP.ATD_GUI_CD_SENHA,
          TRUNC(CCP.ATD_GUI_DT_VALIDADE) ATD_GUI_DT_VALIDADE,
          CCP.CAD_PAC_CD_CREDENCIAL,
          CCP.ATD_ATE_ID,
          CCP.COB_CCP_ID,
          CCP.CAD_PES_NM_PESSOA,
          CCP.COB_CCP_VL_TOT_CONTA  ,
          SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0)) OVER (PARTITION BY CCP.FAT_NOF_ID, CCP.ATD_ATE_ID, CCP.COB_CCP_ID,
                                               CCP.CAD_PAC_ID_PACIENTE,CCP.COB_COC_ID,CCP.ATD_GUI_CD_CODIGO,
                                               TRUNC(CCP.ATD_GUI_DT_VALIDADE)  ) SALDO_PAGO,
          CCP.COB_CCP_VL_TOT_CONTA - SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0)) OVER (PARTITION BY CCP.FAT_NOF_ID, CCP.ATD_ATE_ID, CCP.COB_CCP_ID,
                                               CCP.CAD_PAC_ID_PACIENTE,CCP.COB_COC_ID,CCP.ATD_GUI_CD_CODIGO,
                                               TRUNC(CCP.ATD_GUI_DT_VALIDADE)  ) SALDO_DEVEDOR,              
          DECODE(CCP.ATD_ATE_TP_PACIENTE,'||CHR(39)||'I'||CHR(39)||','||CHR(39)||'INTERNADO'||CHR(39)||','||CHR(39)||'E'||CHR(39)||','||CHR(39)||'EXTERNO'||CHR(39)||','||CHR(39)||'AMB/PS'||CHR(39)||') ATD_ATE_TP_PACIENTE,
          UNI.CAD_UNI_ID_UNIDADE || '||CHR(39)||' - '||CHR(39)||'|| UNI.CAD_UNI_DS_UNIDADE CAD_UNI_DS_UNIDADE,
          CCP.COB_CCP_NR_REMESSA,
          CCP.COB_CCP_DT_PARCELA_INI,
          CCP.COB_CCP_DT_PARCELA,
          CCP.FAT_NOF_ID,
          NOF.FAT_NOF_NR_NOTAFISCAL,
          NOF.FAT_NOF_TP_SERIEFISCAL,
          NOF.CAD_UNI_ID_UNIDADE,
          NOF.FAT_NFO_DT_EMISSAO,
          NOF.FAT_NFO_DT_VENCIMENTO,
          NOF.FAT_NOF_PC_ISS,
          NOF.FAT_NOF_VL_ISS,
          NOF.FAT_NOF_PC_IR,
          NOF.FAT_NOF_VL_IR,
          NOF.FAT_NOF_PC_CSLL,
          NOF.FAT_NOF_VL_CSLL,
          NOF.FAT_NOF_PC_PIS,
          NOF.FAT_NOF_VL_PIS,
          NOF.FAT_NOF_PC_COFINS,
          NOF.FAT_NOF_VL_COFINS,
          CCP.COB_COC_ID,
          CCP.CAD_PAC_ID_PACIENTE,
           CNV.CAD_CNV_CD_HAC_PRESTADOR ||'||CHR(39)||' - '||CHR(39)||'|| CNV.CAD_CNV_DS_RAZAOSOCIAL CAD_CNV_DS_RAZAOSOCIAL
FROM      TB_COB_CCP_CONTA_CONS_PARC CCP
JOIN      TB_FAT_NOF_NOTA_FISCAL     NOF ON CCP.FAT_NOF_ID          = NOF.FAT_NOF_ID
JOIN      TB_CAD_CNV_CONVENIO        CNV ON NOF.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
JOIN      TB_CAD_UNI_UNIDADE         UNI ON NOF.CAD_UNI_ID_UNIDADE  = UNI.CAD_UNI_ID_UNIDADE
LEFT JOIN TB_COB_MGC_MOV_GUIA_COBRANCA MGC  ON  MGC.FAT_NOF_ID          = CCP.FAT_NOF_ID
                                            AND MGC.ATD_ATE_ID          = CCP.ATD_ATE_ID
                                            AND MGC.COB_CCP_ID          = CCP.COB_CCP_ID
                                            AND MGC.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
                                            AND MGC.COB_COC_ID          = CCP.COB_COC_ID
                                            AND MGC.ATD_GUI_CD_CODIGO   = CCP.ATD_GUI_CD_CODIGO
                                            AND TRUNC(MGC.ATD_GUI_DT_VALIDADE) = TRUNC(CCP.ATD_GUI_DT_VALIDADE)
WHERE     ' || V_WHERE || '
ORDER BY CCP.CAD_PES_NM_PESSOA, CCP.COB_CCP_DT_PARCELA '    ;
  --  TESTE :=   V_SELECT  ;
     OPEN v_cursor FOR
          V_SELECT;
     io_cursor := v_cursor;
end PRC_COB_RECUPERA_CCP;
 