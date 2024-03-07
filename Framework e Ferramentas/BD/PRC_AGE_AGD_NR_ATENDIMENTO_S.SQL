create or replace procedure PRC_AGE_AGD_NR_ATENDIMENTO_S
(
 pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE,
 pAGE_AGD_DT_ATENDIMENTO IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%TYPE,
 pAGE_AGD_HR_ATENDIMENTO IN TB_AGE_AGD_AGENDA.AGE_AGD_HR_ATENDIMENTO%TYPE,
 io_cursor OUT PKG_CURSOR.t_cursor
) 
  /********************************************************************
  *    Procedure: PRC_AGE_AGD_NR_ATENDIMENTO_S
  *
  *    Data Criacao: 18/10/2007   Por: Andrea Cazuca
  *
  *    Funcao: Recuperar o nº do atendimento
  *
  *******************************************************************/
is
  v_cursor PKG_CURSOR.t_cursor;
begin

  OPEN v_cursor FOR
  SELECT AGD.AGE_AGD_CD_INTAMB ATENDIMENTO
  FROM   TB_AGE_AGD_AGENDA AGD
  WHERE  AGD.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
  AND    AGD.AGE_AGD_DT_ATENDIMENTO = pAGE_AGD_DT_ATENDIMENTO
  AND    AGD.AGE_AGD_HR_ATENDIMENTO = pAGE_AGD_HR_ATENDIMENTO;
  io_cursor := v_cursor;
end PRC_AGE_AGD_NR_ATENDIMENTO_S;
/
