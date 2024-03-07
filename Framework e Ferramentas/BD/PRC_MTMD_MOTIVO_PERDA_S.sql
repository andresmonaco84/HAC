create or replace procedure PRC_MTMD_MOTIVO_PERDA_S(
  pMTMD_ID_MOTIVO      IN TB_MTMD_MOTIVO_PERDA.MTMD_ID_MOTIVO%TYPE DEFAULT NULL,
  pMTMD_DS_MOTIVO      IN TB_MTMD_MOTIVO_PERDA.MTMD_DS_MOTIVO%TYPE DEFAULT NULL,
  pMTMD_FL_OBRIGA_OBS  IN TB_MTMD_MOTIVO_PERDA.MTMD_FL_OBRIGA_OBS%TYPE DEFAULT NULL,
  pMTMD_FL_DEVOLUCAO   IN TB_MTMD_MOTIVO_PERDA.MTMD_FL_DEVOLUCAO%TYPE DEFAULT NULL,
  io_cursor OUT PKG_CURSOR.t_cursor
) IS

  /********************************************************************
  *    Procedure: PRC_MTMD_MOTIVO_PERDA_S
  *
  *    Data Criacao:  17/11/2010  Por: RICARDO COSTA
  *    Data Alteracao: 26/05/2023 Por: Andre
  *
  *    Funcao: Retorna listagem de motivos
  *
  *******************************************************************/

  v_cursor PKG_CURSOR.t_cursor;

BEGIN

    OPEN v_cursor FOR
    SELECT
         MTMD_ID_MOTIVO,
         MTMD_DS_MOTIVO,
         MTMD_FL_OBRIGA_OBS
    FROM TB_MTMD_MOTIVO_PERDA
    WHERE (pMTMD_FL_DEVOLUCAO IS NULL OR NVL(MTMD_FL_DEVOLUCAO,0) = pMTMD_FL_DEVOLUCAO)
    ORDER BY MTMD_DS_MOTIVO;
    io_cursor := v_cursor;

END PRC_MTMD_MOTIVO_PERDA_S;