

--PRC_TIS_TFA_TP_FATURAMENTO_D
create or replace procedure PRC_TIS_TFA_TP_FATURAMENTO_D 
(
     pTIS_TFA_CD_TPFATURAMENTO IN TB_TIS_TFA_TP_FATURAMENTO.TIS_TFA_CD_TPFATURAMENTO%type	
)
is
/********************************************************************
*    Procedure: PRC_TIS_TFA_TP_FATURAMENTO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_TIS_TFA_TP_FATURAMENTO
WHERE  
        TIS_TFA_CD_TPFATURAMENTO = pTIS_TFA_CD_TPFATURAMENTO;	   
end PRC_TIS_TFA_TP_FATURAMENTO_D;
