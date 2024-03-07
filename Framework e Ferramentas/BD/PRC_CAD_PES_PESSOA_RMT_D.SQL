  --PRC_CAD_PES_PESSOA_RMT_D
  create or replace procedure PRC_CAD_PES_PESSOA_RMT_D 
  (
     pCAD_PES_ID_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PES_PESSOA_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_PES_PESSOA
    WHERE  
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA;	   
  end PRC_CAD_PES_PESSOA_RMT_D;
