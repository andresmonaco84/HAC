  --PRC_CAD_SPL_SUB_PLANO_RMT_U
  create or replace procedure PRC_CAD_SPL_SUB_PLANO_RMT_U
  (
     pCAD_SPL_ID IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_ID%type,
     pCAD_SPL_CD_SUB_PLANO IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_CD_SUB_PLANO%type,
     pCAD_SPL_DS_SUB_PLANO IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_DS_SUB_PLANO%type,
     pCAD_SPL_FL_STATUS IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_FL_STATUS%type,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_SPL_SUB_PLANO.CAD_CNV_ID_CONVENIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SPL_SUB_PLANO_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_SPL_SUB_PLANO
    SET	   
        CAD_SPL_CD_SUB_PLANO = pCAD_SPL_CD_SUB_PLANO,
        CAD_SPL_DS_SUB_PLANO = pCAD_SPL_DS_SUB_PLANO,
        CAD_SPL_FL_STATUS = pCAD_SPL_FL_STATUS,
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO 
    WHERE
        CAD_SPL_ID = pCAD_SPL_ID;	
  end PRC_CAD_SPL_SUB_PLANO_RMT_U;

