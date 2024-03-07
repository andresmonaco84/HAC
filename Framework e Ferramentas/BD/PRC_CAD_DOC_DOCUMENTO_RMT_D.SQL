  --PRC_CAD_DOC_DOCUMENTO_RMT_D
  create or replace procedure PRC_CAD_DOC_DOCUMENTO_RMT_D 
  (
     pCAD_DOC_ID_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_ID_DOCUMENTO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DOC_DOCUMENTO_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_DOC_DOCUMENTO
    WHERE  
        CAD_DOC_ID_DOCUMENTO = pCAD_DOC_ID_DOCUMENTO;	   
  end PRC_CAD_DOC_DOCUMENTO_RMT_D;
