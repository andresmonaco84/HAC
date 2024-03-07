create or replace procedure PRC_CAD_MPF_MOTI_PEND_FAT_S
  (
     pCAD_MPF_ID IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_ID%type DEFAULT NULL,
     pCAD_MPF_DS_MOTI_PEND_FATURAR IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_DS_MOTI_PEND_FATURAR%type DEFAULT NULL,
     pCAD_MPF_FL_STATUS IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_FL_STATUS%type DEFAULT NULL,
     pCAD_MPF_DT_ULTIMA_ATUALIZACAO IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_MPF_MOTI_PEND_FATURAR.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_MPF_FL_MOTIVO IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_FL_MOTIVO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MPF_MOTI_PEND_FAT_S
  *
  *    Data Criacao:  data da  criac?o   Por: Nome do Analista
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *    Data Alteracao:  23/12/2010           Por: Davi Silvestre M. dos Reis
  *    Alteracao:       Inclusao do retorno CAD_MPF_DS_MOTIVO_DESCRICAO (somente retorno)
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
       CAD_MPF_FL_MOTIVO, 
       DECODE (CAD_MPF_FL_MOTIVO, 'J', 'JUSTIFICATIVA', 'P', 'PENDENTE', '') CAD_MPF_DS_MOTIVO_DESCRICAO
    FROM TB_CAD_MPF_MOTI_PEND_FATURAR
    WHERE
        (pCAD_MPF_ID is null OR CAD_MPF_ID = pCAD_MPF_ID) AND
        (pCAD_MPF_DS_MOTI_PEND_FATURAR is null OR CAD_MPF_DS_MOTI_PEND_FATURAR = pCAD_MPF_DS_MOTI_PEND_FATURAR) AND
        (pCAD_MPF_FL_STATUS is null OR CAD_MPF_FL_STATUS = pCAD_MPF_FL_STATUS) AND
        (pCAD_MPF_DT_ULTIMA_ATUALIZACAO is null OR CAD_MPF_DT_ULTIMA_ATUALIZACAO = pCAD_MPF_DT_ULTIMA_ATUALIZACAO) AND
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO) AND
        (pCAD_MPF_FL_MOTIVO is null OR CAD_MPF_FL_MOTIVO = pCAD_MPF_FL_MOTIVO);
    io_cursor := v_cursor;
  end PRC_CAD_MPF_MOTI_PEND_FAT_S;
/
