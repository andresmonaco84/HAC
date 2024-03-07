

--PRC_TIS_TAT_TP_ATENDIMENTO_D
create or replace procedure PRC_TIS_TAT_TP_ATENDIMENTO_D 
(
     pTIS_TAT_CD_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%type	
)
is
/********************************************************************
*    Procedure: PRC_TIS_TAT_TP_ATENDIMENTO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_TIS_TAT_TP_ATENDIMENTO
WHERE  
        TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO;	   
end PRC_TIS_TAT_TP_ATENDIMENTO_D;
