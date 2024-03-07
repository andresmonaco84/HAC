CREATE OR REPLACE PROCEDURE "PRC_INT_GUIAATEND_DATA_INT_S"
  (
     pCAD_PAC_NR_PRONTUARIO IN TB_CAD_PAC_PACIENTE.CAD_PAC_NR_PRONTUARIO%TYPE DEFAULT NULL,
     IO_CURSOR OUT PKG_CURSOR.T_CURSOR
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_GUIAATEND_DATA_INT_S
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
  begin
    OPEN V_CURSOR FOR

 SELECT DISTINCT ATD.ATD_ATE_DT_ATENDIMENTO, PES.CAD_PES_NM_PESSOA
   FROM TB_ATD_ATE_ATENDIMENTO ATD,
        TB_ASS_PAT_PACIEATEND  PAT,
        TB_CAD_PAC_PACIENTE    PAC,
        TB_ATD_AIC_ATE_INT_COMPL AIC,
        TB_CAD_PES_PESSOA PES
  WHERE ATD.ATD_ATE_ID = PAT.ATD_ATE_ID
    AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
    AND AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
    AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
    AND PAC.CAD_PAC_NR_PRONTUARIO = pCAD_PAC_NR_PRONTUARIO
    ORDER BY ATD.ATD_ATE_DT_ATENDIMENTO;
    
   IO_CURSOR := V_CURSOR;
  end PRC_INT_GUIAATEND_DATA_INT_S;
 