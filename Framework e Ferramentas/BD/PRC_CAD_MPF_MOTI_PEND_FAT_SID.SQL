create or replace procedure PRC_CAD_MPF_MOTI_PEND_FAT_SID
  (
     pCAD_MPF_ID IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MPF_MOTI_PEND_FAT_SID
  *
  *    Data Criacao:  data da  criac?o   Por: Nome do Analista
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_MPF_ID,
       CAD_MPF_DS_MOTI_PEND_FATURAR,
       CAD_MPF_FL_STATUS,
       CAD_MPF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_MPF_FL_MOTIVO
    FROM TB_CAD_MPF_MOTI_PEND_FATURAR
    WHERE
        CAD_MPF_ID = pCAD_MPF_ID;
    io_cursor := v_cursor;
  end PRC_CAD_MPF_MOTI_PEND_FAT_SID;
/
