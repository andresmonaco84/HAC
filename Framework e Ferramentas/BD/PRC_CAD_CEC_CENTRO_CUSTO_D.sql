
  --PRC_CAD_CEC_CENTRO_CUSTO_D
  create or replace procedure PRC_CAD_CEC_CENTRO_CUSTO_D 
  (
     pCAD_CEC_ID_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_ID_CCUSTO%type  
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CEC_CENTRO_CUSTO_D
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_CEC_CENTRO_CUSTO
    WHERE  
        CAD_CEC_ID_CCUSTO = pCAD_CEC_ID_CCUSTO;     
  end PRC_CAD_CEC_CENTRO_CUSTO_D;
