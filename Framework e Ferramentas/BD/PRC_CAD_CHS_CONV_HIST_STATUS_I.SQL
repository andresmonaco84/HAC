  create or replace procedure PRC_CAD_CHS_CONV_HIST_STATUS_I
  (
     pNewIdt OUT integer,
     pCAD_CHS_ID IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CNV_ID_CONVENIO%type,
     pCAD_CHS_DT_INI_VIGENCIA IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_DT_INI_VIGENCIA%type,
     pCAD_CHS_DT_FIM_VIGENCIA IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_DT_FIM_VIGENCIA%type default NULL,
     pCAD_CHS_FL_STATUS IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_CHS_CONV_HISTO_STATUS.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CHS_CONV_HIST_STATUS_I
  * 
  *    Data Criacao: 	20/06/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Cadastro de Status do Convênio
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
    FROM   TB_CAD_CHS_CONV_HISTO_STATUS
    WHERE  ((pCAD_CHS_DT_INI_VIGENCIA <= CAD_CHS_DT_INI_VIGENCIA 
             AND CAD_CHS_DT_FIM_VIGENCIA IS NULL)
    OR     (pCAD_CHS_DT_INI_VIGENCIA BETWEEN CAD_CHS_DT_INI_VIGENCIA AND CAD_CHS_DT_FIM_VIGENCIA))
    AND    CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;
        
    IF nCount > 0 then
        raise_application_error (-20000, 'Existe status em aberto ou est� dentre um vigencia existente');
    END IF;
    
    SELECT SEQ_CAD_CHS_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_CAD_CHS_CONV_HISTO_STATUS
    (
       CAD_CHS_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_CHS_DT_INI_VIGENCIA,
       CAD_CHS_DT_FIM_VIGENCIA,
       CAD_CHS_FL_STATUS,
       CAD_CHS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	     lIdtRetorno,
	     pCAD_CNV_ID_CONVENIO,
	     pCAD_CHS_DT_INI_VIGENCIA,
	     pCAD_CHS_DT_FIM_VIGENCIA,
	     pCAD_CHS_FL_STATUS,
	     sysdate,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
    
  end PRC_CAD_CHS_CONV_HIST_STATUS_I;
/
