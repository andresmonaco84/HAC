
--PRC_SEG_PAR_PARAMETRO_R_I
create or replace procedure PRC_SEG_PAR_PARAMETRO_R_I
(
     pSEG_PAR_CD IN TB_SEG_PAR_PARAMETRO.SEG_PAR_CD%type,
     pSEG_PAR_NM_PARAMETRO IN TB_SEG_PAR_PARAMETRO.SEG_PAR_NM_PARAMETRO%type,
     pSEG_PAR_VL_PARAMETRO IN TB_SEG_PAR_PARAMETRO.SEG_PAR_VL_PARAMETRO%type	
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PAR_PARAMETRO_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_SEG_PAR_PARAMETRO
(
       SEG_PAR_CD,
       SEG_PAR_NM_PARAMETRO,
       SEG_PAR_VL_PARAMETRO
)
VALUES
(
	     pSEG_PAR_CD,
	     pSEG_PAR_NM_PARAMETRO,
	     pSEG_PAR_VL_PARAMETRO
);
	
end PRC_SEG_PAR_PARAMETRO_R_I;

