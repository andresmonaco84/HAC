create or replace procedure sgs.PRC_CAD_MPF_MOTI_PEND_FAT_U
  (
     pCAD_MPF_ID IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_ID%type,
     pCAD_MPF_DS_MOTI_PEND_FATURAR IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_DS_MOTI_PEND_FATURAR%type,
     pCAD_MPF_FL_STATUS IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_FL_STATUS%type,
     pCAD_MPF_DT_ULTIMA_ATUALIZACAO IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_MPF_MOTI_PEND_FATURAR.SEG_USU_ID_USUARIO%type,
     pCAD_MPF_FL_MOTIVO IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_FL_MOTIVO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MPF_MOTI_PEND_FAT_U
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  begin
    UPDATE TB_CAD_MPF_MOTI_PEND_FATURAR
    SET
        CAD_MPF_DS_MOTI_PEND_FATURAR = pCAD_MPF_DS_MOTI_PEND_FATURAR,
        CAD_MPF_FL_STATUS = pCAD_MPF_FL_STATUS,
        CAD_MPF_DT_ULTIMA_ATUALIZACAO = pCAD_MPF_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_MPF_FL_MOTIVO = pCAD_MPF_FL_MOTIVO
    WHERE
        CAD_MPF_ID = pCAD_MPF_ID;
  end PRC_CAD_MPF_MOTI_PEND_FAT_U;
/
