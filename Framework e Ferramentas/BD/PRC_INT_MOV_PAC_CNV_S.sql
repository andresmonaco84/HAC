create or replace procedure PRC_INT_MOV_PAC_CNV_S
  (
     pATD_ATE_ID            IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,  
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_MOV_PAC_CNV_S
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

SELECT PAT.ASS_PAT_DT_ENTRADA,
       PAT.ASS_PAT_HR_ENTRADA,
       PAT.ASS_PAT_DT_SAIDA,
       PAT.ASS_PAT_HR_SAIDA,
       CNV.CAD_CNV_CD_HAC_PRESTADOR,
       CNV.CAD_CNV_NM_FANTASIA,
       USU.SEG_USU_DS_NOME,
       PAT.ASS_PAT_DT_ULTIMA_ATUALIZACAO,
       PAT.CAD_PAC_ID_PACIENTE,
       PAC.CAD_CNV_ID_CONVENIO,
       PAC.CAD_PLA_ID_PLANO,
       PAC.CAD_PAC_CD_CREDENCIAL
  FROM TB_ASS_PAT_PACIEATEND PAT,
       TB_CAD_PAC_PACIENTE   PAC,
       TB_CAD_CNV_CONVENIO   CNV,
       TB_SEG_USU_USUARIO    USU
 WHERE ATD_ATE_ID = pATD_ATE_ID 
   AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE   
   AND USU.SEG_USU_ID_USUARIO(+) = PAT.SEG_USU_ID_USUARIO
   AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
 ORDER BY ASS_PAT_DT_ENTRADA, ASS_PAT_HR_ENTRADA;

    io_cursor := v_cursor;
  end PRC_INT_MOV_PAC_CNV_S;
/
