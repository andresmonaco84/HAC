create or replace procedure PRC_CAD_MPF_MOTI_PEND_FAT_I
  (
     pNewIdt OUT integer,
     pCAD_MPF_ID IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_ID%type default NULL,
     pCAD_MPF_DS_MOTI_PEND_FATURAR IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_DS_MOTI_PEND_FATURAR%type,
     pCAD_MPF_FL_STATUS IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_FL_STATUS%type,
     pCAD_MPF_DT_ULTIMA_ATUALIZACAO IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_MPF_MOTI_PEND_FATURAR.SEG_USU_ID_USUARIO%type,
     pCAD_MPF_FL_MOTIVO IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_FL_MOTIVO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MPF_MOTI_PEND_FAT_I
  *
  *    Data Criacao:  data da  criac?o   Por: Nome do Analista
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
    lIdtRetorno integer;

  begin
    SELECT SEQ_CAD_MPF_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_CAD_MPF_MOTI_PEND_FATURAR
    (
       CAD_MPF_ID,
       CAD_MPF_DS_MOTI_PEND_FATURAR,
       CAD_MPF_FL_STATUS,
       CAD_MPF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_MPF_FL_MOTIVO
    )
    VALUES
    (
       lIdtRetorno,
    pCAD_MPF_DS_MOTI_PEND_FATURAR,
    pCAD_MPF_FL_STATUS,
    pCAD_MPF_DT_ULTIMA_ATUALIZACAO,
    pSEG_USU_ID_USUARIO,
    pCAD_MPF_FL_MOTIVO
    );
    pNewIdt := lIdtRetorno;
  end PRC_CAD_MPF_MOTI_PEND_FAT_I;
/
