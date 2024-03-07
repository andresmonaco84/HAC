create or replace procedure PRC_AGE_PEE_PERIODO_ESCALA_I
  (
     pNewIdt OUT integer,
     pAGE_PEE_CD_PERIODO_ESCALA IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_CD_PERIODO_ESCALA%type,
     pAGE_PEE_ID IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_ID%type default NULL,
     pAGE_PEE_DS_PERIODO_ESCALA IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_DS_PERIODO_ESCALA%type,
     pAGE_PEE_HR_INI_PERIODO_ESCALA IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_HR_INI_PERIODO_ESCALA%type,
     pAGE_PEE_HR_FIM_PERIODO_ESCALA IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_HR_FIM_PERIODO_ESCALA%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_PEE_PERIODO_ESCALA_I
  * 
  *    Data Criacao: 	  10/07/2007           Por: Carlos Eduardo
  *
  *    Funcao: Inclui período de escala médica
  *
  *    Data Alteracao: 13/08/2007            Por: Ricardo
  *
  *    Funcao: Inclui verificação de periodo ja existente
  *    Data Alteracao: 07/11/2007        	  Por: Guilherme Holdack
  *    Inclusão de Upper para campos.
  *******************************************************************/  
    lIdtRetorno integer;
    nCount  integer;	  
  begin
  
  SELECT COUNT(*)
  INTO   nCount  
  FROM TB_AGE_PEE_PERIODO_ESCALA
  WHERE AGE_PEE_HR_INI_PERIODO_ESCALA = pAGE_PEE_HR_INI_PERIODO_ESCALA
  AND   AGE_PEE_HR_FIM_PERIODO_ESCALA = pAGE_PEE_HR_FIM_PERIODO_ESCALA
  AND   AGE_PEE_CD_PERIODO_ESCALA = pAGE_PEE_CD_PERIODO_ESCALA;
  
    IF nCount > 0 then
       raise_application_error (-20000, 'Já existe este período');
    END IF;    
  
  
    SELECT SEQ_AGE_PEE_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_AGE_PEE_PERIODO_ESCALA
    (
       AGE_PEE_ID,
       AGE_PEE_CD_PERIODO_ESCALA,
       AGE_PEE_DS_PERIODO_ESCALA,
       AGE_PEE_HR_INI_PERIODO_ESCALA,
       AGE_PEE_HR_FIM_PERIODO_ESCALA
    )
    VALUES
    (
       lIdtRetorno,
	     pAGE_PEE_CD_PERIODO_ESCALA,
	     upper(pAGE_PEE_DS_PERIODO_ESCALA),
	     pAGE_PEE_HR_INI_PERIODO_ESCALA,
	     pAGE_PEE_HR_FIM_PERIODO_ESCALA
    );
    pNewIdt := lIdtRetorno;	
  end PRC_AGE_PEE_PERIODO_ESCALA_I;
/
