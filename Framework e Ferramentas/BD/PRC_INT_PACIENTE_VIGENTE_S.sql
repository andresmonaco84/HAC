create or replace procedure PRC_INT_PACIENTE_VIGENTE_S 
(
   pATD_ATE_ID IN TB_ASS_PAT_PACIEATEND.ATD_ATE_ID%type,
   io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_INT_PACIENTE_VIGENTE_S
* 
*    Data Criacao:   09/09/2009   Por: Caio H. B. Chagas
*    Data Alteracao:              Por: 
*
*    Funcao: Pesquisar o paciente vigente para a internação, 
*            que não possui data de saída
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
  SELECT  
     PAT.ATD_ATE_ID,
     PAT.CAD_PAC_ID_PACIENTE,
     PAT.ASS_PAT_DT_ENTRADA,
     PAT.ASS_PAT_HR_ENTRADA,
     PAT.ASS_PAT_DT_SAIDA,
     PAT.ASS_PAT_HR_SAIDA,
     PAT.ASS_PAT_FL_STATUS,
     PAT.SEG_USU_ID_USUARIO,
     PAT.ASS_PAT_DT_ULT_ATUALIZACAO,
     PAT.ASS_PAT_NR_CONTA,
	 PAT.CAD_CNV_ID_CONVENIO,
	 PAT.CAD_PLA_ID_PLANO,
	 PAT.CAD_PAC_CD_CREDENCIAL,
	 PAT.ASS_PAT_DS_OBSERVACAO
  FROM 
      TB_ASS_PAT_PACIEATEND PAT
  WHERE
      PAT.ATD_ATE_ID = pATD_ATE_ID
  AND 
      PAT.ASS_PAT_DT_SAIDA IS NULL;
  io_cursor := v_cursor;
end PRC_INT_PACIENTE_VIGENTE_S;

