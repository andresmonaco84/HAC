  --PRC_CAD_DOC_DOCUMENTO_RMT_I
  create or replace procedure PRC_CAD_DOC_DOCUMENTO_RMT_I
  (
     pNewIdt OUT integer,
     pCAD_DOC_ID_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_ID_DOCUMENTO%type default NULL,
     pCAD_DOC_SG_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_SG_DOCUMENTO%type,
     pCAD_DOC_DS_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DS_DOCUMENTO%type,
     pCAD_DOC_DS_OBSERVACAO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DS_OBSERVACAO%type default NULL,
     pCAD_DOC_FL_ATIVO_OK IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_FL_ATIVO_OK%type,
     pCAD_DOC_DT_ULTIMA_ATUALIZACAO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_DOC_DOCUMENTO.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DOC_DOCUMENTO_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
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
	     pCAD_DOC_SG_DOCUMENTO,
	     pCAD_DOC_DS_DOCUMENTO,
	     pCAD_DOC_DS_OBSERVACAO,
	     pCAD_DOC_FL_ATIVO_OK,
	     pCAD_DOC_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_CAD_DOC_DOCUMENTO_RMT_I;

