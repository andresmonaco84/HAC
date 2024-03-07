  --PRC_CAD_TEL_TELEFONE_RMT_D
  create or replace procedure PRC_CAD_TEL_TELEFONE_RMT_D 
  (
     pCAD_TEL_ID_TELEFONE IN TB_CAD_TEL_TELEFONE.CAD_TEL_ID_TELEFONE%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TEL_TELEFONE_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_TEL_TELEFONE
    WHERE  
        CAD_TEL_ID_TELEFONE = pCAD_TEL_ID_TELEFONE;	   
  end PRC_CAD_TEL_TELEFONE_RMT_D;
