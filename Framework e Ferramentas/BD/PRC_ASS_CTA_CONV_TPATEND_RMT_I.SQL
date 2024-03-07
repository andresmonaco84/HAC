---fim


  --PRC_ASS_CTA_CONV_TPATEND_RMT_I
  create or replace procedure PRC_ASS_CTA_CONV_TPATEND_RMT_I
  (
   pNewIdt OUT integer,
     pASS_CTA_ID IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_ID%type,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CTA_CONV_TPATEND.CAD_CNV_ID_CONVENIO%type,
     pTIS_TAT_CD_TPATENDIMENTO IN TB_ASS_CTA_CONV_TPATEND.TIS_TAT_CD_TPATENDIMENTO%type,
     pASS_CTA_DS_MOTIVO_FIM_VIGENC IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_CTA_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_DT_ULTIMA_ATUALIZACAO%type,
     pASS_CTA_DT_INI_VIGENCIA IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_DT_INI_VIGENCIA%type,
     pASS_CTA_DT_FIM_VIGENCIA IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CTA_CONV_TPATEND.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTA_CONV_TPATEND_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	   lIdtRetorno integer;
    nCount integer;

  begin

    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_ASS_CTA_CONV_TPATEND
    WHERE  ((pASS_CTA_DT_INI_VIGENCIA >= ASS_CTA_DT_INI_VIGENCIA
             AND ASS_CTA_DT_FIM_VIGENCIA IS NULL)
    OR     (pASS_CTA_DT_INI_VIGENCIA BETWEEN ASS_CTA_DT_INI_VIGENCIA AND ASS_CTA_DT_FIM_VIGENCIA))
    AND    CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND    TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO;

    IF nCount > 0 then
       raise_application_error (-20000, 'Ja existe Associac?o neste periodo');
    END IF;

    SELECT SEQ_ASS_CTA_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_CTA_CONV_TPATEND
    (
       ASS_CTA_ID,
       CAD_CNV_ID_CONVENIO,
       TIS_TAT_CD_TPATENDIMENTO,
       ASS_CTA_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CTA_DT_ULTIMA_ATUALIZACAO,
       ASS_CTA_DT_INI_VIGENCIA,
       ASS_CTA_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	    lIdtRetorno,
	     pCAD_CNV_ID_CONVENIO,
	     pTIS_TAT_CD_TPATENDIMENTO,
	     pASS_CTA_DS_MOTIVO_FIM_VIGENC,
	     pASS_CTA_DT_ULTIMA_ATUALIZACAO,
	     pASS_CTA_DT_INI_VIGENCIA,
	     pASS_CTA_DT_FIM_VIGENCIA,
	     pSEG_USU_ID_USUARIO
    );
	 pNewIdt := lIdtRetorno;
  end PRC_ASS_CTA_CONV_TPATEND_RMT_I;

