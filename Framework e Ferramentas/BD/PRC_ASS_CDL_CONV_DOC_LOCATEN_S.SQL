  --PRC_ASS_CDL_CONV_DOC_LOCATEND_S
  create or replace procedure PRC_ASS_CDL_CONV_DOC_LOCATEN_S 
  (
     pASS_CDL_ID IN TB_ASS_CDL_CONV_DOC_LOCATEND.ASS_CDL_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     pCAD_DOC_ID_DOCUMENTO IN TB_CAD_DOC_DOCUMENTO.CAD_DOC_ID_DOCUMENTO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CDL_CONV_DOC_LOCATEND_S
  * 
  *    Data Criacao: 	data da  cria√ß√£o   Por: Nome do Analista
  *    Funcao: Descri√ß√£o da funcionalidade da Stored Procedure
  *
  *	   Data Alteracao:	13/06/2007  Por: Andrea Cazuca
  *	   Alteracao: Foi incluido o campo CAD_CNV_ID_CONVENIO como parametro
  *
  *    Data de Altera√ß√£o: 29/06/2007        por: Fabiola
  *    Altera√ß√£o: Inclus√£o do order by
  *
  *    Data de AlteraÁ„o:  27/09/2007         por: Guilherme Holdack
  *    AlteraÁ„o:  Inlcus„o de novos par‚metros pCAD_LAT_ID_LOCAL_ATENDIMENTO e
  *                pCAD_DOC_ID_DOCUMENTO
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_CNV_ID_CONVENIO,
       CAD_DOC_ID_DOCUMENTO,
       ASS_CDL_ID
    FROM TB_ASS_CDL_CONV_DOC_LOCATEND
    WHERE
        (pASS_CDL_ID is null OR ASS_CDL_ID = pASS_CDL_ID)
    AND (pCAD_CNV_ID_CONVENIO is null OR CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
    AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null OR CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
    AND (pCAD_DOC_ID_DOCUMENTO is null OR CAD_DOC_ID_DOCUMENTO = pCAD_DOC_ID_DOCUMENTO)
    
    order BY  CAD_LAT_ID_LOCAL_ATENDIMENTO;
    io_cursor := v_cursor;
  end PRC_ASS_CDL_CONV_DOC_LOCATEN_S;
/
