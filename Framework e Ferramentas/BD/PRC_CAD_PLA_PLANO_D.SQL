  --PRC_CAD_PLA_PLANO_D
  create or replace procedure PRC_CAD_PLA_PLANO_D 
  (
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PLA_PLANO_D
  * 
  *    Data Criacao: 	26/06/2007   Por: Ricardo Costa
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui registro da tabela plano
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_PLA_PLANO
    WHERE  
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;	   
  end PRC_CAD_PLA_PLANO_D;
/
