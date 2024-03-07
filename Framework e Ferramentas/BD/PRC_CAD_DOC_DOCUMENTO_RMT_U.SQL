  --PRC_CAD_DOC_DOCUMENTO_RMT_U
  create or replace procedure PRC_CAD_DOC_DOCUMENTO_RMT_U
  (
     pCAD_DOC_ID_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_ID_DOCUMENTO%type,
     pCAD_DOC_SG_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_SG_DOCUMENTO%type,
     pCAD_DOC_DS_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DS_DOCUMENTO%type,
     pCAD_DOC_DS_OBSERVACAO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DS_OBSERVACAO%type default NULL,
     pCAD_DOC_FL_ATIVO_OK IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_FL_ATIVO_OK%type,
     pCAD_DOC_DT_ULTIMA_ATUALIZACAO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_DOC_DOCUMENTO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DOC_DOCUMENTO_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_DOC_DOCUMENTO
    SET	   
        CAD_DOC_SG_DOCUMENTO = pCAD_DOC_SG_DOCUMENTO,
        CAD_DOC_DS_DOCUMENTO = pCAD_DOC_DS_DOCUMENTO,
        CAD_DOC_DS_OBSERVACAO = pCAD_DOC_DS_OBSERVACAO,
        CAD_DOC_FL_ATIVO_OK = pCAD_DOC_FL_ATIVO_OK,
        CAD_DOC_DT_ULTIMA_ATUALIZACAO = pCAD_DOC_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        CAD_DOC_ID_DOCUMENTO = pCAD_DOC_ID_DOCUMENTO;	
  end PRC_CAD_DOC_DOCUMENTO_RMT_U;

