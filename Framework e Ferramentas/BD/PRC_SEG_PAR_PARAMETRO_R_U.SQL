
--PRC_SEG_PAR_PARAMETRO_R_U
create or replace procedure PRC_SEG_PAR_PARAMETRO_R_U
(
     pSEG_PAR_CD IN TB_SEG_PAR_PARAMETRO.SEG_PAR_CD%type,
     pSEG_PAR_NM_PARAMETRO IN TB_SEG_PAR_PARAMETRO.SEG_PAR_NM_PARAMETRO%type,
     pSEG_PAR_VL_PARAMETRO IN TB_SEG_PAR_PARAMETRO.SEG_PAR_VL_PARAMETRO%type
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PAR_PARAMETRO_R_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_SEG_PAR_PARAMETRO
SET	   
        SEG_PAR_NM_PARAMETRO = pSEG_PAR_NM_PARAMETRO,
        SEG_PAR_VL_PARAMETRO = pSEG_PAR_VL_PARAMETRO 
WHERE
        SEG_PAR_CD = pSEG_PAR_CD;	
end PRC_SEG_PAR_PARAMETRO_R_U;

