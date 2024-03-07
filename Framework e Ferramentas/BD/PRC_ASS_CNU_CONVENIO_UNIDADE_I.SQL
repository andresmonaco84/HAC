  create or replace procedure PRC_ASS_CNU_CONVENIO_UNIDADE_I
  (
     pNewIdt OUT integer,
     pASS_CNU_DT_INI_VIGENCIA IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DT_INI_VIGENCIA%type,
     pASS_CNU_DT_FIM_VIGENCIA IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DT_FIM_VIGENCIA%type default NULL,
     pASS_CNU_DS_MOTIVO_FIM_VIGEN IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CNU_CONVENIO_UNIDADE.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNU_CONVENIO_UNIDADE_I
  * 
  *    Data Criacao: 	25/05/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: Inclui a Associação do Convenio X Unidade
  *
  *	   Data Alteracao: 16/07/07      Por: Fabiola Lopes
  *    Funcao: Alteracao do raise_application_erro de -30000 para -20000
  *
  *******************************************************************/  
    lIdtRetorno integer;
    nCount integer;
	  
  begin
  
   SELECT COUNT(*) 
    INTO   nCount
    FROM   TB_ASS_CNU_CONVENIO_UNIDADE
    WHERE  ((pASS_CNU_DT_INI_VIGENCIA >= ASS_CNU_DT_INI_VIGENCIA 
             AND ASS_CNU_DT_FIM_VIGENCIA IS NULL)
    OR     (pASS_CNU_DT_INI_VIGENCIA BETWEEN ASS_CNU_DT_INI_VIGENCIA AND ASS_CNU_DT_FIM_VIGENCIA))
    AND    CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND    CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;
    
    IF nCount > 0 then
       raise_application_error (-20000, 'Já existe Associação neste período');
    END IF;
  
    SELECT SEQ_ASS_CNU_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_CNU_CONVENIO_UNIDADE
    (
       ASS_CNU_ID,
       ASS_CNU_DT_INI_VIGENCIA,
       ASS_CNU_DT_FIM_VIGENCIA,
       ASS_CNU_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CNU_DT_ULTIMA_ATUALIZACAO,
       CAD_CNV_ID_CONVENIO,
       CAD_UNI_ID_UNIDADE,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	     lIdtRetorno,
	     pASS_CNU_DT_INI_VIGENCIA,
	     pASS_CNU_DT_FIM_VIGENCIA,
	     upper(pASS_CNU_DS_MOTIVO_FIM_VIGEN),
	     sysdate,
	     pCAD_CNV_ID_CONVENIO,
	     pCAD_UNI_ID_UNIDADE,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ASS_CNU_CONVENIO_UNIDADE_I;
/
