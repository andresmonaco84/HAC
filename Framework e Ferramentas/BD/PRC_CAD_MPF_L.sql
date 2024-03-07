CREATE OR REPLACE PROCEDURE SGS."PRC_CAD_MPF_L"
(
    pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_MPF_ID IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_ID%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_FAT_MPF_L
*
*    Data Criacao:   13/6/2011   Por: PEDRO
*    Data Alteracao:  data da alterac?o  Por: Nome do Analista
*
*    Funcao: Descric?o da funcionalidade da Stored Procedure
*
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT SUBQUERY.*, UNI.CAD_UNI_DS_UNIDADE
  FROM TB_ATD_ATE_ATENDIMENTO ATE,
       TB_CAD_UNI_UNIDADE UNI,
       (SELECT cci.*,
               PES.CAD_PES_NM_PESSOA,
               PRD.CAD_PRD_CD_CODIGO,
               PRD.CAD_PRD_DS_DESCRICAO,
               PRO.CAD_PRO_NR_CONSELHO,
               PRO.CAD_PRO_NM_NOME
          FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI,
               TB_CAD_PAC_PACIENTE         PAC,
               TB_CAD_PRD_PRODUTO          PRD,
               TB_CAD_PRO_PROFISSIONAL     PRO,
               TB_CAD_PES_PESSOA           PES
         WHERE CCI.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
           AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
           AND CCI.CAD_PRD_ID = PRD.CAD_PRD_ID
           AND CCI.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
           AND CCI.FAT_CCP_ID IS NULL
           AND CCI.CAD_MPF_ID = pCAD_MPF_ID
           AND CCI.FAT_CCI_FL_STATUS = 'A'
           AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)) SUBQUERY
 WHERE SUBQUERY.ATD_ATE_ID = ATE.ATD_ATE_ID
   AND ATE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
   AND UNI.CAD_UNI_FL_FATURA_UNID_OK = 'S';
  io_cursor := v_cursor;
end PRC_CAD_MPF_L;
