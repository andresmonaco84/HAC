create or replace procedure PRC_ASS_CUT_CONV_UNI_TPACOM_I
  (
     pNewIdt OUT integer,
     pASS_CUT_DT_INI_VIGENCIA IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DT_INI_VIGENCIA%type,
     pASS_CUT_DS_MOTIVO_FIM_VIG IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_CUT_DT_FIM_VIGENCIA IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DT_FIM_VIGENCIA%type default NULL,
     pASS_UTA_ID_UNID_TPACOMOD IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_UTA_ID_UNID_TPACOMOD%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CUT_CONV_UNI_TPACOMOD.SEG_USU_ID_USUARIO%type,
     pASS_CNU_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CNU_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUT_CONV_UNI_TPACOM_I
  *
  *    Data Criacao: 	12/06/2007         Por: Fabíola R. Lopes
  *    Data Alteracao:	                   Por:
  *
  *    Funcao: Inclui as Associações de Convênio Unidade x Tipo de Acomodação
  *
  *	   Data Alteracao: 16/07/07      Por: Fabiola Lopes
  *    Funcao: Alteracao do raise_application_erro de -30000 para -20000
  *
  *******************************************************************/
    lIdtRetorno integer;
    nCount  integer;
  begin
    nCount := 0;
    
    SELECT COUNT(*) 
    INTO   nCount
    FROM   TB_ASS_CUT_CONV_UNI_TPACOMOD
    WHERE  (   ( pASS_CUT_DT_INI_VIGENCIA > = ASS_CUT_DT_INI_VIGENCIA AND ASS_CUT_DT_FIM_VIGENCIA IS NULL )
            OR ( pASS_CUT_DT_INI_VIGENCIA BETWEEN ASS_CUT_DT_INI_VIGENCIA AND ASS_CUT_DT_FIM_VIGENCIA))
    AND    ASS_CNU_ID = pASS_CNU_ID
    AND    ASS_UTA_ID_UNID_TPACOMOD = pASS_UTA_ID_UNID_TPACOMOD;
    
    IF nCount > 0 then
       raise_application_error (-20000, 'Já existe Associação neste período');
    END IF;
    
    SELECT SEQ_ASS_CUT_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_ASS_CUT_CONV_UNI_TPACOMOD
    (
       ASS_CUT_ID,
       ASS_CUT_DT_INI_VIGENCIA,
       ASS_CUT_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CUT_DT_FIM_VIGENCIA,
       ASS_CUT_DT_ULTIMA_ATUALIZACAO,
       ASS_UTA_ID_UNID_TPACOMOD,
       SEG_USU_ID_USUARIO,
       ASS_CNU_ID
    )
    VALUES
    (
	     lIdtRetorno,
	     pASS_CUT_DT_INI_VIGENCIA,
	     UPPER(pASS_CUT_DS_MOTIVO_FIM_VIG),
	     pASS_CUT_DT_FIM_VIGENCIA,
	     SYSDATE,
	     pASS_UTA_ID_UNID_TPACOMOD,
	     pSEG_USU_ID_USUARIO,
	     pASS_CNU_ID
    );
    pNewIdt := lIdtRetorno;
  end PRC_ASS_CUT_CONV_UNI_TPACOM_I;