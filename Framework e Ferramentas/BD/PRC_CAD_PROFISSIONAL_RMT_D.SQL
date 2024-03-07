  --PRC_CAD_PROFISSIONAL_RMT_D
  create or replace procedure PRC_CAD_PROFISSIONAL_RMT_D 
  (
     pCAD_PRO_ID_PROFISSIONAL IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PROFISSIONAL_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_PRO_PROFISSIONAL
    WHERE  
        CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL;	   
  end PRC_CAD_PROFISSIONAL_RMT_D;
