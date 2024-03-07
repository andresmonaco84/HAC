  --PRC_CAD_DOC_DOCUMENTO_RMT_SID
  create or replace procedure PRC_CAD_DOC_DOCUMENTO_RMT_SID 
  (
     pCAD_DOC_ID_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_ID_DOCUMENTO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DOC_DOCUMENTO_RMT_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
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
        CAD_DOC_ID_DOCUMENTO = pCAD_DOC_ID_DOCUMENTO;          
    io_cursor := v_cursor;
  end PRC_CAD_DOC_DOCUMENTO_RMT_SID;
