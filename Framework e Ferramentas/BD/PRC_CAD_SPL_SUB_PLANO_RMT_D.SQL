  --PRC_CAD_SPL_SUB_PLANO_RMT_D
  create or replace procedure PRC_CAD_SPL_SUB_PLANO_RMT_D 
  (
     pCAD_SPL_ID IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SPL_SUB_PLANO_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_SPL_SUB_PLANO
    WHERE  
        CAD_SPL_ID = pCAD_SPL_ID;	   
  end PRC_CAD_SPL_SUB_PLANO_RMT_D;
