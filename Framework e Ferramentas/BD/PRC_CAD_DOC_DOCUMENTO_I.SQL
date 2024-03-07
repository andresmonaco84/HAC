  create or replace procedure PRC_CAD_DOC_DOCUMENTO_I
  (
	 pNewIdt OUT integer,
     pCAD_DOC_SG_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_SG_DOCUMENTO%type,
     pCAD_DOC_DS_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DS_DOCUMENTO%type,
     pCAD_DOC_DS_OBSERVACAO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DS_OBSERVACAO%type default NULL,
     pCAD_DOC_FL_ATIVO_OK IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_FL_ATIVO_OK%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_DOC_DOCUMENTO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DOC_DOCUMENTO_I
  * 
  *    Data Criacao: 	24/04/2007   Por: Andrea Cazuca
  *    Data Alteracao:	24/05/2007  Por: Andrea Cazuca
  *
  *    Funcao: Insere os Documentos
  *	   Alteracao: Foi incluido o campo CAD_DOC_ID_DOCUMENTO
  *				  Foi incluido os campos CAD_DOC_FL_ATIVO, CAD_DOC_DT_ULTIMA_ATUALIZACAO e SEG_USU_ID_USUARIO
  *
  *******************************************************************/  
	lIdtRetorno integer;  
  begin
	SELECT SEQ_CAD_DOC_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_CAD_DOC_DOCUMENTO
    (
	     CAD_DOC_ID_DOCUMENTO,
       CAD_DOC_SG_DOCUMENTO,
       CAD_DOC_DS_DOCUMENTO,
       CAD_DOC_DS_OBSERVACAO,
       CAD_DOC_FL_ATIVO_OK,
       CAD_DOC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
		   lIdtRetorno,
	     upper(pCAD_DOC_SG_DOCUMENTO),
	     upper(pCAD_DOC_DS_DOCUMENTO),
	     upper(pCAD_DOC_DS_OBSERVACAO),
	     pCAD_DOC_FL_ATIVO_OK,
	     sysdate,
	     pSEG_USU_ID_USUARIO
    );
	pNewIdt := lIdtRetorno;
  end PRC_CAD_DOC_DOCUMENTO_I;
/
