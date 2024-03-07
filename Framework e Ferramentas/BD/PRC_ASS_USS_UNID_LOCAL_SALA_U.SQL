create or replace procedure PRC_ASS_USS_UNID_LOCAL_SALA_U
  (
     pASS_USS_ID IN TB_ASS_USS_UNID_LOC_SET_SALA.ASS_USS_ID%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_SET_ID%type,
     pAGE_SAU_ID IN TB_ASS_USS_UNID_LOC_SET_SALA.AGE_SAU_ID%type,
     pASS_USS_FL_STATUS IN TB_ASS_USS_UNID_LOC_SET_SALA.ASS_USS_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_USS_UNID_LOC_SET_SALA.SEG_USU_ID_USUARIO%type     
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_USS_UNID_LOCAL_SALA_U
  *
  *    Data Criacao: 	15/01/2008           Por: Davi S. M. dos Reis
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Alterar as Associacoes de Unidade x Local x Setor x Sala
  *
  *******************************************************************/
  begin
    UPDATE TB_ASS_USS_UNID_LOC_SET_SALA
    SET
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO,
        ASS_USS_FL_STATUS = pASS_USS_FL_STATUS,
        AGE_SAU_ID = pAGE_SAU_ID,
        ASS_USS_DT_ULTIMA_ATUALIZACAO = sysdate,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_SET_ID = pCAD_SET_ID
    WHERE
        ASS_USS_ID = pASS_USS_ID;
  end PRC_ASS_USS_UNID_LOCAL_SALA_U;
/
