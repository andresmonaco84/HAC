create or replace procedure PRC_AGS_ORS_ORIENTACAO_SADT
  (
     pAGS_ORS_ID IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_ID%type DEFAULT NULL,

     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_ORS_ORIENTACAO_SADT
  *
  *    Data Criacao:   data da  criação: 13/01/2009   Por: Pedro
  *
  *    Funcao: Alimentar a Impressão da ORS no cadastro da mesma
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       AGS_ORS_ID,
       AGS_ORS_DS_ORIENTACAO_SADT,
       AGS_ORS_TP_FINALIDADE,
       AGS_ORS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_AGS_ORS_ORIENTACAO_SADT
    WHERE
        (pAGS_ORS_ID is null OR AGS_ORS_ID = pAGS_ORS_ID) 
       ;
    io_cursor := v_cursor;
  end PRC_AGS_ORS_ORIENTACAO_SADT;
/
