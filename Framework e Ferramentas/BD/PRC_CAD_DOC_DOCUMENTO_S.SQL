  create or replace procedure PRC_CAD_DOC_DOCUMENTO_S 
  (
     pCAD_DOC_ID_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_ID_DOCUMENTO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DOC_DOCUMENTO_S
  * 
  *    Data Criacao: 	24/04/2007  Por: Andrea Cazuca
  *    Data Alteracao:	24/05/2007  Por: Andrea Cazuca
  *
  *    Funcao: Seleciona os Documentos
  *    Alteracao: Foi incluido o campo CAD_DOC_ID_DOCUMENTO
  *				  Foi incluido o campo CAD_DOC_FL_ATIVO_OK, CAD_DOC_DT_ULTIMA_ATUALIZACAO E SEG_USU_ID_USUARIO
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
	   CAD_DOC_ID_DOCUMENTO,
       CAD_DOC_SG_DOCUMENTO,
       CAD_DOC_DS_DOCUMENTO,
       CAD_DOC_DS_OBSERVACAO,
       CAD_DOC_FL_ATIVO_OK,
       CAD_DOC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_CAD_DOC_DOCUMENTO
    WHERE
        (pCAD_DOC_ID_DOCUMENTO is null OR CAD_DOC_ID_DOCUMENTO = pCAD_DOC_ID_DOCUMENTO)
    ORDER BY CAD_DOC_SG_DOCUMENTO;
    io_cursor := v_cursor;
  end PRC_CAD_DOC_DOCUMENTO_S;
/
