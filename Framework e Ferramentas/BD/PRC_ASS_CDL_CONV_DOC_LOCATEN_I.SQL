create or replace procedure PRC_ASS_CDL_CONV_DOC_LOCATEN_I
  (
     pNewIdt OUT integer,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_CNV_ID_CONVENIO%type,
     pCAD_DOC_ID_DOCUMENTO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_DOC_ID_DOCUMENTO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CDL_CONV_DOC_LOCATEND_I
  *
  *    Data Criacao: 	04/06/2007   Por: SILMARA
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: DescriÃ§Ã£o da funcionalidade da Stored Procedure
  *
  *    Data Alteracao:	16/07/07     Por: Fabiola Lopes
  *    Alteração:		Acerto do raise_application de -30000 para -20000
  *
  *******************************************************************/
	lIdtRetorno integer;
  nCount integer;
  begin

    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_ASS_CDL_CONV_DOC_LOCATEND
    WHERE  CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND    CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND    CAD_DOC_ID_DOCUMENTO = pCAD_DOC_ID_DOCUMENTO;

    IF nCount > 0 then
       raise_application_error (-20000, 'Já existe Associação neste período');
    END IF;

    SELECT SEQ_ASS_CDL_01.NextVal INTO lIdtRetorno FROM DUAL;


    INSERT INTO TB_ASS_CDL_CONV_DOC_LOCATEND
    (
       ASS_CDL_ID,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_CNV_ID_CONVENIO,
       CAD_DOC_ID_DOCUMENTO

    )
    VALUES
    (
       lIdtRetorno,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	     pCAD_CNV_ID_CONVENIO,
	     pCAD_DOC_ID_DOCUMENTO
    );
  pNewIdt := lIdtRetorno;
  end PRC_ASS_CDL_CONV_DOC_LOCATEN_I;
/
