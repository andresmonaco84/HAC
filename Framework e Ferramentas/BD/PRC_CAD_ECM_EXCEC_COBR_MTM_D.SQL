  --PRC_CAD_ECM_EXCEC_COBRANCA_MTM_D
  create or replace procedure PRC_CAD_ECM_EXCEC_COBR_MTM_D 
  (
     pCAD_ECM_ID IN TB_CAD_ECM_EXCEC_COBRANCA_MTM.CAD_ECM_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_ECM_EXCEC_COBR_MTM_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_ECM_EXCEC_COBRANCA_MTM
    WHERE  
        CAD_ECM_ID = pCAD_ECM_ID;	   
  end PRC_CAD_ECM_EXCEC_COBR_MTM_D;

