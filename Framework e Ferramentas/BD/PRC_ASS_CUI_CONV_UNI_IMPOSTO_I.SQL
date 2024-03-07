create or replace procedure PRC_ASS_CUI_CONV_UNI_IMPOSTO_I
  (
     pNewIdt OUT integer,
     pASS_CUI_DT_INI_VIGENCIA IN TB_ASS_CUI_CONV_UNI_IMPOSTO.ASS_CUI_DT_INI_VIGENCIA%type,
     pASS_CUI_DT_FIM_VIGENCIA IN TB_ASS_CUI_CONV_UNI_IMPOSTO.ASS_CUI_DT_FIM_VIGENCIA%type default NULL,
     pASS_CNU_ID IN TB_ASS_CUI_CONV_UNI_IMPOSTO.ASS_CNU_ID%type,
     pASS_CUI_PC_IMPOSTO IN TB_ASS_CUI_CONV_UNI_IMPOSTO.ASS_CUI_PC_IMPOSTO%type,
     pASS_CUI_DS_MOTIVO_FIM_VIG IN TB_ASS_CUI_CONV_UNI_IMPOSTO.ASS_CUI_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pCAD_IMP_ID_IMPOSTO IN TB_ASS_CUI_CONV_UNI_IMPOSTO.CAD_IMP_ID_IMPOSTO%type,
     pASS_CUI_VL_MIN_RECOLHIM IN TB_ASS_CUI_CONV_UNI_IMPOSTO.ASS_CUI_VL_MIN_RECOLHIM%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CUI_CONV_UNI_IMPOSTO.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUI_CONV_UNI_IMPOSTO_I
  *
  *    Data Criacao: 	28/05/2007         Por: Fabiola R. Lopes
  *    Data Alteracao:			   Por:
  *
  *    Funcao: Incluir Associacao do Convenio Unidade com Impostos
  *
  *	   Data Alteracao: 16/07/07      Por: Fabiola Lopes
  *    Funcao: Alteracao do raise_application_erro de -30000 para -20000
  *
  *******************************************************************/
    lIdtRetorno integer;
    nCount      integer;

  begin
    
    nCount := 0;
      
    SELECT COUNT(*) 
    INTO   nCount
    FROM   TB_ASS_CUI_CONV_UNI_IMPOSTO
    WHERE  (   ( pASS_CUI_DT_INI_VIGENCIA >= ASS_CUI_DT_INI_VIGENCIA AND ASS_CUI_DT_FIM_VIGENCIA IS NULL )
            OR ( pASS_CUI_DT_INI_VIGENCIA BETWEEN ASS_CUI_DT_INI_VIGENCIA AND ASS_CUI_DT_FIM_VIGENCIA)   )
    AND    ASS_CNU_ID = pASS_CNU_ID
    AND    CAD_IMP_ID_IMPOSTO = pCAD_IMP_ID_IMPOSTO;
    
    IF nCount > 0 then
       raise_application_error (-20000, 'Já existe Associação neste período');
    END IF;
  
    SELECT SEQ_ASS_CUI_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_ASS_CUI_CONV_UNI_IMPOSTO
    (
       ASS_CUI_ID,
       ASS_CUI_DT_INI_VIGENCIA,
       ASS_CUI_DT_FIM_VIGENCIA,
       ASS_CNU_ID,
       ASS_CUI_PC_IMPOSTO,
       ASS_CUI_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CUI_DT_ULTIMA_ATUALIZACAO,
       CAD_IMP_ID_IMPOSTO,
       ASS_CUI_VL_MIN_RECOLHIM,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	     lIdtRetorno,
	     pASS_CUI_DT_INI_VIGENCIA,
	     pASS_CUI_DT_FIM_VIGENCIA,
	     pASS_CNU_ID,
	     pASS_CUI_PC_IMPOSTO,
	     UPPER(pASS_CUI_DS_MOTIVO_FIM_VIG),
	     SYSDATE,
	     pCAD_IMP_ID_IMPOSTO,
	     pASS_CUI_VL_MIN_RECOLHIM,
	     pSEG_USU_ID_USUARIO
    );
    
    pNewIdt := lIdtRetorno;
    
  end PRC_ASS_CUI_CONV_UNI_IMPOSTO_I;