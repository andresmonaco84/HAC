  --PRC_AGE_ESM_ESCALA_MEDICA_D
  create or replace procedure PRC_AGE_ESM_ESCALA_MEDICA_D 
  (
     pAGE_ESM_ID IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_ESM_ESCALA_MEDICA_D
  * 
  *    Data Criacao: 	16/07/2007            Por: Guilherme Holdack
  *    Data Alteracao:	                     Por:                 
  *
  *    Funcao: Deleção de registros na tabela TB_AGE_ESM_ESCALA_MEDICA
  *
  *******************************************************************/    
  begin
    DELETE TB_AGE_ESM_ESCALA_MEDICA
    WHERE  
        AGE_ESM_ID = pAGE_ESM_ID;	   
  end PRC_AGE_ESM_ESCALA_MEDICA_D;
/
