  --PRC_INT_CAD_QUARTO_LEITO_D
  create or replace procedure PRC_INT_CAD_QUARTO_LEITO_D 
  (
     pCAD_QLE_ID IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_QUARTO_LEITO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_QLE_QUARTO_LEITO
    WHERE  
        CAD_QLE_ID = pCAD_QLE_ID;	   
  end PRC_INT_CAD_QUARTO_LEITO_D;
