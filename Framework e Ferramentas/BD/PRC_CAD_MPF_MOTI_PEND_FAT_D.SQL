  --PRC_CAD_MPF_MOTI_PEND_FAT_D
  create or replace procedure PRC_CAD_MPF_MOTI_PEND_FAT_D
  (
     pCAD_MPF_ID IN TB_CAD_MPF_MOTI_PEND_FATURAR.CAD_MPF_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MPF_MOTI_PEND_FAT_D
  *
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  begin
    DELETE TB_CAD_MPF_MOTI_PEND_FATURAR
    WHERE
        CAD_MPF_ID = pCAD_MPF_ID;
  end PRC_CAD_MPF_MOTI_PEND_FAT_D;