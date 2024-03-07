  --PRC_AGE_CIE_CIRCULAR_ESCALA_I
  create or replace procedure PRC_ASS_CIE_CIRCULAR_ESCALA_I
  (
     pAGE_ECC_ID IN TB_ASS_CIE_CIRCULAR_ESCALA.AGE_ECC_ID%type,
     pAGE_ESM_ID IN TB_ASS_CIE_CIRCULAR_ESCALA.AGE_ESM_ID%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CIE_CIRCULAR_ESCALA.SEG_USU_ID_USUARIO%type
     
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CIE_CIRCULAR_ESCALA_I
  * 
  *    Data Criacao: 	17/07/2007   Por: Guilherme Holdack
  *    Data Alteracao:	                     Por:                 
  *
  *    Funcao: Associa circular e escalas médicas
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_CIE_CIRCULAR_ESCALA
    (
       AGE_ECC_ID,
       AGE_ESM_ID,
       SEG_USU_ID_USUARIO,
       ASS_CIE_DT_ULTIMA_ATUALIZACAO
    )
    VALUES
    (
	     pAGE_ECC_ID,
	     pAGE_ESM_ID,
	     pSEG_USU_ID_USUARIO,
	     SYSDATE
    );
	
  end PRC_ASS_CIE_CIRCULAR_ESCALA_I;
/
