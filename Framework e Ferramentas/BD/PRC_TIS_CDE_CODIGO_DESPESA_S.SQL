CREATE OR REPLACE PROCEDURE "PRC_TIS_CDE_CODIGO_DESPESA_S"
  (
     pTIS_CDE_CD_CODIGO_DESPESA IN TB_TIS_CDE_CODIGO_DESPESA.TIS_CDE_CD_CODIGO_DESPESA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CDE_CODIGO_DESPESA_S
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *    Data Alteração:  21/03/2014  Por: Andréa Cazuca
  *    Alteração:  Inclusão dos campos TIS_CDE_CDE_CODIGO_DESPESA_V3 E TIS_CDE_DS_OBSERVACAO
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_CDE_CD_CODIGO_DESPESA,
       TIS_CDE_DS_DESCRICAO_DESPESA,
       TIS_CBE_DT_INI_VIGENCIA,
       TIS_CBE_DT_FIM_VIGENCIA,
       TIS_CBE_FL_STATUS,
       TIS_CBE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       TIS_CDE_CD_CODIGO_DESPESA_V3,
       TIS_CDE_DS_OBSERVACAO
    FROM TB_TIS_CDE_CODIGO_DESPESA
    WHERE
        (pTIS_CDE_CD_CODIGO_DESPESA is null OR TIS_CDE_CD_CODIGO_DESPESA = pTIS_CDE_CD_CODIGO_DESPESA);
    io_cursor := v_cursor;
  end PRC_TIS_CDE_CODIGO_DESPESA_S;
 