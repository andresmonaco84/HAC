create or replace procedure PRC_AGS_OPR_ORIENTACAO_PROD_S
  (

     pCAD_PRD_ID IN TB_AGS_OPR_ORIENTACAO_PROD.CAD_PRD_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_OPR_ORIENTACAO_PROD_S
  *
  *    Data Criacao:   29/09/2008   Por: Pedro Henrique A. de Carvalho
  *    Data Alteracao:  27/10/2008  Por: Pedro Henrique A. de Carvalho
  *	   Alteração: Selecionando pelo id do procedimento  
  *
  *    Data Alteracao:  31/10/2008  Por: Pedro Henrique A. de Carvalho
  *	   Alteração: inclusão do   AGS_ORS_TP_FINALIDADE no Select
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       ORS.AGS_ORS_DS_ORIENTACAO_SADT,
       PRO.CAD_PRD_DS_DESCRICAO,
       OPR.AGS_OPR_ID,
       OPR.AGS_ORS_ID,
       OPR.AGS_OPR_DT_ULTIMA_ATUALIZACAO,
       OPR.SEG_USU_ID_USUARIO,
       OPR.CAD_PRD_ID,
       decode(ORS.AGS_ORS_TP_FINALIDADE,'A','Agendamento','T','Todos','P','Paciente') AGS_ORS_TP_FINALIDADE,
       OPR.AGS_OPR_FL_STATUS
    FROM TB_AGS_OPR_ORIENTACAO_PROD OPR
    inner join tb_ags_ors_orientacao_sadt ORS
    on ORS.AGS_ORS_ID = OPR.AGS_ORS_ID
    INNER JOIN TB_CAD_PRD_PRODUTO PRO
    ON PRO.CAD_PRD_ID = OPR.CAD_PRD_ID
    WHERE
        (pCAD_PRD_ID is null OR PRO.CAD_PRD_ID = pCAD_PRD_ID);
    io_cursor := v_cursor;
  end PRC_AGS_OPR_ORIENTACAO_PROD_S;
