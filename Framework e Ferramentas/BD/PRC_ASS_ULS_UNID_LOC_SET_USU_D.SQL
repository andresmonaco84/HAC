create or replace procedure PRC_ASS_ULS_UNID_LOC_SET_USU_D
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_SET_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_ULS_UNID_LOC_SET_USU_D
  *
  *    Data Criacao: 	21/01/2008           Por: Fabiola R. Lopesv
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  begin
    DELETE TB_ASS_ULS_UNID_LOC_SET_USU
    WHERE
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_SET_ID = pCAD_SET_ID;
  end PRC_ASS_ULS_UNID_LOC_SET_USU_D;
/
