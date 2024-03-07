create or replace procedure PRC_CAD_LAT_LOCAL_UNID_S
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULO_UNID_LOCAL.CAD_UNI_ID_UNIDADE%type,
     pASS_ULO_FL_STATUS IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_FL_STATUS%type default null,
     pCAD_LAT_FL_ATIVO_OK IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_FL_ATIVO_OK%type default null,
     pASS_ULO_FL_LIBERA_AGENDA_OK IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_FL_LIBERA_AGENDA_OK%type default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_LAT_LOCAL_UNID_S
  *
  *    Data Criacao: 	 11/07/2007   Por: Carlos
  *    Funcao: Lista os Locais de Atendimentos por Unidade e/ou Status
  *
  *    Data Alteracao: 28/08/2007   Por: Carlos Araujo
  *    Alteracao: Inclusão de filtro por status da associação entre Local e Unidade
  *
  *    Data Alteracao: 26/10/2007   Por: Carlos Araujo
  *    Alteracao: Inclusão de parametro opcional FL_LIBERA_AGENDA
  *
  *    Data Alteracao: 25/03/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do campo CAD_LAT_FL_PERMITE_ATEND (tarefa 8107)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
       LAT.CAD_LAT_FL_ATIVO_OK,
       LAT.CAD_LAT_DT_ULTIMA_ATUALIZACAO,
       LAT.SEG_USU_ID_USUARIO,
       LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,
       LAT.CAD_LAT_FL_PERMITE_ATEND
    FROM TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
         TB_ASS_ULO_UNID_LOCAL ULO
    WHERE
        LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO
    AND (ULO.CAD_UNI_ID_UNIDADE          = pCAD_UNI_ID_UNIDADE)
    AND (pCAD_LAT_FL_ATIVO_OK is null OR LAT.CAD_LAT_FL_ATIVO_OK = pCAD_LAT_FL_ATIVO_OK)
    AND (pASS_ULO_FL_STATUS is null OR ULO.ASS_ULO_FL_STATUS = pASS_ULO_FL_STATUS)
    AND (pASS_ULO_FL_LIBERA_AGENDA_OK is null OR ULO.ASS_ULO_FL_LIBERA_AGENDA_OK = pASS_ULO_FL_LIBERA_AGENDA_OK)

    ORDER BY CAD_LAT_DS_LOCAL_ATENDIMENTO;
    io_cursor := v_cursor;
  end PRC_CAD_LAT_LOCAL_UNID_S;
/
