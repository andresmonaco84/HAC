  --PRC_AGE_PEE_PERIODO_ESCALA_U
  create or replace procedure PRC_AGE_PEE_PERIODO_ESCALA_U
  (
     pAGE_PEE_CD_PERIODO_ESCALA IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_CD_PERIODO_ESCALA%type,
     pAGE_PEE_ID IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_ID%type,
     pAGE_PEE_DS_PERIODO_ESCALA IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_DS_PERIODO_ESCALA%type,
     pAGE_PEE_HR_INI_PERIODO_ESCALA IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_HR_INI_PERIODO_ESCALA%type,
     pAGE_PEE_HR_FIM_PERIODO_ESCALA IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_HR_FIM_PERIODO_ESCALA%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_PEE_PERIODO_ESCALA_U
  * 
  *    Data Criacao: 	  10/07/2007           Por: Carlos Eduardo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Altera um período de escala médica
  *    Data Alteracao: 07/11/2007        	  Por: Guilherme Holdack
  *    Inclusão de Upper para campos.
  *******************************************************************/  
  nCount  integer;
  begin
  
  SELECT COUNT(*)
  INTO   nCount  
  FROM   TB_AGE_PEE_PERIODO_ESCALA
  WHERE  AGE_PEE_HR_INI_PERIODO_ESCALA = pAGE_PEE_HR_INI_PERIODO_ESCALA
  AND    AGE_PEE_HR_FIM_PERIODO_ESCALA = pAGE_PEE_HR_FIM_PERIODO_ESCALA
  AND    AGE_PEE_CD_PERIODO_ESCALA = pAGE_PEE_CD_PERIODO_ESCALA;
  
    IF nCount > 0 then
       raise_application_error (-20000, 'Já existe este período');
    END IF;    
  
  
    UPDATE TB_AGE_PEE_PERIODO_ESCALA
    SET	   
        AGE_PEE_CD_PERIODO_ESCALA = pAGE_PEE_CD_PERIODO_ESCALA,
        AGE_PEE_DS_PERIODO_ESCALA = upper(pAGE_PEE_DS_PERIODO_ESCALA),
        AGE_PEE_HR_INI_PERIODO_ESCALA = pAGE_PEE_HR_INI_PERIODO_ESCALA,
        AGE_PEE_HR_FIM_PERIODO_ESCALA = pAGE_PEE_HR_FIM_PERIODO_ESCALA 
    WHERE
        AGE_PEE_ID = pAGE_PEE_ID;
        
  end PRC_AGE_PEE_PERIODO_ESCALA_U;
/
