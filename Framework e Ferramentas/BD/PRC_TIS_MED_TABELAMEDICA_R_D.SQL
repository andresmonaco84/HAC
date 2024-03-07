

--PRC_TIS_MED_TABELAMEDICA_R_D
create or replace procedure PRC_TIS_MED_TABELAMEDICA_R_D 
(
     pTIS_MED_CD_TABELAMEDICA IN TB_TIS_MED_TABELAMEDICA.TIS_MED_CD_TABELAMEDICA%type	
)
is
/********************************************************************
*    Procedure: PRC_TIS_MED_TABELAMEDICA_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_TIS_MED_TABELAMEDICA
WHERE  
        TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA;	   
end PRC_TIS_MED_TABELAMEDICA_R_D;
