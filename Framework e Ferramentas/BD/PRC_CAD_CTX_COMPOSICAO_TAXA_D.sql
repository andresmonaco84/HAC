
  --PRC_CAD_CTX_COMPOSICAO_TAXA_D
  create or replace procedure PRC_CAD_CTX_COMPOSICAO_TAXA_D 
  (
     pCAD_CTX_ID IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_CTX_ID%type  
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CTX_COMPOSICAO_TAXA_D
  * 
  *    Data Criacao:   '19-nov-09'   Por: PEDRO
  *    Data Alteracao:  data da alteração  Por: PEDRO
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_CTX_COMPOSICAO_TAXA
    WHERE  
        CAD_CTX_ID = pCAD_CTX_ID;     
  end PRC_CAD_CTX_COMPOSICAO_TAXA_D;
