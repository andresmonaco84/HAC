create or replace procedure PRC_ASS_ULO_UNID_LOCAL_U
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULO_UNID_LOCAL.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULO_UNID_LOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pASS_ULO_FL_LIBERA_AGENDA_OK IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_FL_LIBERA_AGENDA_OK%TYPE,
     pASS_ULO_FL_STATUS IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_ULO_UNID_LOCAL.SEG_USU_ID_USUARIO%type,
     pASS_ULO_HR_INICIAL_ATEND IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_HR_INICIAL_ATEND%type DEFAULT NULL,
     pASS_ULO_HR_FINAL_ATEND IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_HR_FINAL_ATEND%type DEFAULT NULL

  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_ULO_UNID_LOCAL_U
  *
  *    Data Criacao: 	 27/06/2007   Por: Cristiane Gomes da Silva
  *    Funcao: Altera Associac?o de Unidade com Local de Atendimento
  *
  *    Data Alteracao: 11/07/2007   Por: Carlos Eduardo
  *    Alterac?o: Alterac?o de tabela, retirada de Vigencia
  *
  *
  *    Data Alteracao: 02/10/2007  Por: Guilherme Holdack
  *    Alterac?o:      Inclus?o de campo ASS_ULO_FL_LIBERA_AGENDA_OK
  *
  *    Data Alteracao: 24/03/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao dos campos ASS_ULO_HR_INICIAL_ATEND e ASS_ULO_HR_FINAL_ATEND (tarefa 8107)
  *
  *******************************************************************/
  begin
    UPDATE TB_ASS_ULO_UNID_LOCAL
    SET
        ASS_ULO_FL_STATUS            = pASS_ULO_FL_STATUS,
        ASS_ULO_FL_LIBERA_AGENDA_OK  = pASS_ULO_FL_LIBERA_AGENDA_OK,
        SEG_USU_ID_USUARIO           = pSEG_USU_ID_USUARIO,
        ASS_ULO_DT_ULTIMA_ATUALIZACAO = sysdate,
        ASS_ULO_HR_INICIAL_ATEND     = DECODE(pASS_ULO_HR_INICIAL_ATEND, NULL, ASS_ULO_HR_INICIAL_ATEND, pASS_ULO_HR_INICIAL_ATEND),
        ASS_ULO_HR_FINAL_ATEND       = DECODE(pASS_ULO_HR_FINAL_ATEND, NULL, ASS_ULO_HR_FINAL_ATEND, pASS_ULO_HR_FINAL_ATEND)
    WHERE
        CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
    AND CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO;
  end PRC_ASS_ULO_UNID_LOCAL_U;
/
