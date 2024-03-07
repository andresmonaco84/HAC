

  --PRC_CAD_PLA_PLANO_D
  create or replace procedure PRC_CAD_PLA_PLANO_RMT_D 
  (
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PLA_PLANO_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_PLA_PLANO
    WHERE  
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;	   
  end PRC_CAD_PLA_PLANO_RMT_D;
