
--PRC_AUX_EPP_ESPECPROC_R_D
create or replace procedure PRC_AUX_EPP_ESPECPROC_R_D 
(
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%type,
     pTIS_MED_CD_TABELAMEDICA IN TB_AUX_EPP_ESPECPROC.TIS_MED_CD_TABELAMEDICA%type	
)
is
/********************************************************************
*    Procedure: PRC_AUX_EPP_ESPECPROC_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_AUX_EPP_ESPECPROC
WHERE  
        AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC
    AND TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA;	   
end PRC_AUX_EPP_ESPECPROC_R_D;
