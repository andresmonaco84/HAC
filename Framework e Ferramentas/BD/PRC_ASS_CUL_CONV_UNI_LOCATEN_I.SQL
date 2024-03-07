  --PRC_ASS_CUL_CONV_UNI_LOCATEND_I
  create or replace procedure PRC_ASS_CUL_CONV_UNI_LOCATEN_I
  (
     pNewIdt OUT integer,
     pASS_CUL_DT_INI_VIGENCIA IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DT_INI_VIGENCIA%type,
     pASS_CUL_DS_MOTIVO_FIM_VIGENCI IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CUL_CONV_UNI_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pASS_CUL_DT_FIM_VIGENCIA IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CUL_CONV_UNI_LOCATEND.SEG_USU_ID_USUARIO%type,	
     pASS_CNU_ID IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CNU_ID%type
    ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUL_CONV_UNI_LOCATEN_I
  * 
  *    Data Criacao: 	05/06/2007   Por: Silmara
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: DescriÃ§Ã£o da funcionalidade da Stored Procedure
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
    FROM   TB_ASS_CUL_CONV_UNI_LOCATEND
    WHERE  (   ( pASS_CUL_DT_INI_VIGENCIA > = ASS_CUL_DT_INI_VIGENCIA AND ASS_CUL_DT_FIM_VIGENCIA IS NULL )
            OR ( pASS_CUL_DT_INI_VIGENCIA BETWEEN ASS_CUL_DT_INI_VIGENCIA AND ASS_CUL_DT_FIM_VIGENCIA))
    AND    ASS_CNU_ID = pASS_CNU_ID
    AND    CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO;
    
    IF nCount > 0 then
       raise_application_error (-20000, 'Já existe Associação neste período');
    END IF;
    
    SELECT SEQ_ASS_CUL_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_CUL_CONV_UNI_LOCATEND
    (
       ASS_CUL_ID,
       ASS_CUL_DT_INI_VIGENCIA,
       ASS_CUL_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CUL_DT_ULTIMA_ATUALIZACAO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ASS_CUL_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO,
       ASS_CNU_ID
    )
    VALUES
    (
	     lIdtRetorno,
	     pASS_CUL_DT_INI_VIGENCIA,
	     UPPER(pASS_CUL_DS_MOTIVO_FIM_VIGENCI),
	     SYSDATE,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	     pASS_CUL_DT_FIM_VIGENCIA,
	     pSEG_USU_ID_USUARIO,
         pASS_CNU_ID
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ASS_CUL_CONV_UNI_LOCATEN_I;
/
