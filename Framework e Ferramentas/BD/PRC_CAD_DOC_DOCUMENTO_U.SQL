  create or replace procedure PRC_CAD_DOC_DOCUMENTO_U
  (
	 pCAD_DOC_ID_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_ID_DOCUMENTO%type,
     pCAD_DOC_SG_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_SG_DOCUMENTO%type,
     pCAD_DOC_DS_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DS_DOCUMENTO%type,
     pCAD_DOC_DS_OBSERVACAO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DS_OBSERVACAO%type default NULL,
     pCAD_DOC_FL_ATIVO_OK IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_FL_ATIVO_OK%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_DOC_DOCUMENTO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DOC_DOCUMENTO_U
  * 
  *    Data Criacao: 	24/04/2007   Por: Andrea Cazuca
  *    Data Alteracao:	24/05/2007  Por: Andrea Cazuca
  *
  *    Funcao: Altera os Documentos
  *	   Alteracao: Foi incluido o campo CAD_DOC_ID_DOCUMENTO
  *				  Foi incluido o campo CAD_DOC_FL_ATIVO, CAD_DOC_DT_ULTIMA_ATUALIZACAO e SEG_USU_ID_USUARIO
  *    Data Alteracao:	25/05/2007  Por: Silmara
  *    Alteração: Foi alterado os parâmetros para gravar em maiúsculo
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_DOC_DOCUMENTO
    SET
		CAD_DOC_SG_DOCUMENTO = UPPER(pCAD_DOC_SG_DOCUMENTO),	   
        CAD_DOC_DS_DOCUMENTO = UPPER(pCAD_DOC_DS_DOCUMENTO),
        CAD_DOC_DS_OBSERVACAO = UPPER(pCAD_DOC_DS_OBSERVACAO),
        CAD_DOC_FL_ATIVO_OK = pCAD_DOC_FL_ATIVO_OK,
        CAD_DOC_DT_ULTIMA_ATUALIZACAO = sysdate,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        CAD_DOC_ID_DOCUMENTO = pCAD_DOC_ID_DOCUMENTO;	
  end PRC_CAD_DOC_DOCUMENTO_U;
/
