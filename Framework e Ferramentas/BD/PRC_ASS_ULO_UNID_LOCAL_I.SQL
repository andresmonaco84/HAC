create or replace procedure PRC_ASS_ULO_UNID_LOCAL_I
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULO_UNID_LOCAL.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULO_UNID_LOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pASS_ULO_FL_STATUS IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_FL_STATUS%type,
     pASS_ULO_FL_LIBERA_AGENDA_OK IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_FL_LIBERA_AGENDA_OK%TYPE,
     pSEG_USU_ID_USUARIO IN TB_ASS_ULO_UNID_LOCAL.SEG_USU_ID_USUARIO%type,
     pASS_ULO_HR_INICIAL_ATEND IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_HR_INICIAL_ATEND%type DEFAULT NULL,
     pASS_ULO_HR_FINAL_ATEND IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_HR_FINAL_ATEND%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_ULO_UNID_LOCAL_I
  *
  *    Data Criacao: 	27/06/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 02/10/2007  Por: Guilherme Holdack
  *    Alterac?o:      Inclus?o de campo ASS_ULO_FL_LIBERA_AGENDA_OK
  *
  *    Funcao: Inclui Associac?o de Unidade com Local de Atendimento
  *
  *    Data Alteracao: 24/03/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao dos campos ASS_ULO_HR_INICIAL_ATEND e ASS_ULO_HR_FINAL_ATEND (tarefa 8107)
  *
  *******************************************************************/
  begin

    INSERT INTO TB_ASS_ULO_UNID_LOCAL
    (
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ASS_ULO_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_ULO_DT_ULTIMA_ATUALIZACAO,
       ASS_ULO_FL_LIBERA_AGENDA_OK,
       ASS_ULO_HR_INICIAL_ATEND,
       ASS_ULO_HR_FINAL_ATEND
    )
    VALUES
    (
	     pCAD_UNI_ID_UNIDADE,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
       pASS_ULO_FL_STATUS,
	     pSEG_USU_ID_USUARIO,
	     sysdate,
       pASS_ULO_FL_LIBERA_AGENDA_OK,
       pASS_ULO_HR_INICIAL_ATEND,
       pASS_ULO_HR_FINAL_ATEND
    );

  end PRC_ASS_ULO_UNID_LOCAL_I;
/
