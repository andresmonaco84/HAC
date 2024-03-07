
--PRC_SEG_PAR_PARAMETRO_R_D
create or replace procedure PRC_SEG_PAR_PARAMETRO_R_D 
(
     pSEG_PAR_CD IN TB_SEG_PAR_PARAMETRO.SEG_PAR_CD%type	
)
is
/********************************************************************
*    Procedure: PRC_SEG_PAR_PARAMETRO_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_SEG_PAR_PARAMETRO
WHERE  
        SEG_PAR_CD = pSEG_PAR_CD;	   
end PRC_SEG_PAR_PARAMETRO_R_D;
