create or replace procedure PRC_TIS_TVA_TP_VIA_ACESSO_S
  (
     pTIS_TVA_CD_VIAACESSO IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_CD_VIAACESSO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TVA_TP_VIA_ACESSO_S
  *
  *    Data Criacao:  11/04/2007   Por: Andrea Cazuca
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Seleciona Tipo de Via de Acesso
  *
  *    Data Alterac?o:  21/03/2014  Por: Andrea Cazuca
  *    Alterac?o:  Inclus?o do campo TIS_TVA_CD_VIAACESSO_V3
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_TVA_CD_VIAACESSO,
       TIS_TVA_DS_VIAACESSO,
      TIS_TVA_FL_STATUS,
       TIS_TVA_CD_VIAACESSO_V3,
       TIS_TVA_DT_CRIACAO,
      SEG_USU_ID_USUARIO_CRIACAO,
      TIS_TVA_DT_ULT_ATUALIZACAO,
      SEG_USU_ID_USU_ULT_ATUALIZ
       
    FROM TB_TIS_TVA_TP_VIA_ACESSO
    WHERE
        (pTIS_TVA_CD_VIAACESSO is null OR TIS_TVA_CD_VIAACESSO = pTIS_TVA_CD_VIAACESSO)
    ORDER BY TIS_TVA_CD_VIAACESSO;
    io_cursor := v_cursor;
  end PRC_TIS_TVA_TP_VIA_ACESSO_S;
 