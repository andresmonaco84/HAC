CREATE OR REPLACE PROCEDURE "PRC_CAD_LAT_LOCAL_ATEND_S" (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_LAT_FL_ATIVO_OK IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_FL_ATIVO_OK%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_LAT_LOCAL_ATEND_S
  *
  *    Data Criacao: 	23/04/2007   Por: Andréa
  *    Data Alteracao:	01/06/2007  Por: Silmara
  *    Alteracao: inclusao de parametro para listar locais de atendimento
  *    ativos.
  *    Data Alteracao:	05/06/2007  Por: Silmara
  *    Alteracao: alteracao do parametro para listar locais de atendimento
  *    ativos para default null
  *    Funcao: Lista os Locais de Atendimentos
  *
  *    Data Alteracao: 25/03/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do campo CAD_LAT_FL_PERMITE_ATEND (tarefa 8107)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_LAT_DS_LOCAL_ATENDIMENTO,
       CAD_LAT_FL_ATIVO_OK,
       CAD_LAT_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_LAT_CD_LOCAL_ATENDIMENTO,
       CAD_LAT_FL_PERMITE_ATEND
    FROM TB_CAD_LAT_LOCAL_ATENDIMENTO
    WHERE
        (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null OR CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
    AND ( pCAD_LAT_FL_ATIVO_OK IS NULL OR CAD_LAT_FL_ATIVO_OK = pCAD_LAT_FL_ATIVO_OK)
    ORDER BY CAD_LAT_DS_LOCAL_ATENDIMENTO;
    io_cursor := v_cursor;
  end PRC_CAD_LAT_LOCAL_ATEND_S;
/
