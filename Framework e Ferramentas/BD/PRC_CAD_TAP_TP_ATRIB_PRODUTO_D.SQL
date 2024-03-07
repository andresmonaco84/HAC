 create or replace procedure PRC_CAD_TAP_TP_ATRIB_PRODUTO_D 
  (
     pCAD_TAP_TP_ATRIBUTO IN TB_CAD_TAP_TP_ATRIB_PRODUTO.CAD_TAP_TP_ATRIBUTO%type  
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TAP_TP_ATRIB_PRODUTO_D
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_TAP_TP_ATRIB_PRODUTO
    WHERE  
        CAD_TAP_TP_ATRIBUTO = pCAD_TAP_TP_ATRIBUTO;     
  end PRC_CAD_TAP_TP_ATRIB_PRODUTO_D;