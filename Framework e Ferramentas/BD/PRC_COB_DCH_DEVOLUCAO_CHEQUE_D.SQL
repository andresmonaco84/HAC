--PRC_COB_DCH_DEVOLUCAO_CHEQUE_D
create or replace procedure PRC_COB_DCH_DEVOLUCAO_CHEQUE_D 
(
     pCOB_DCH_ID IN TB_COB_DCH_DEVOLUCAO_CHEQUE.COB_DCH_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_DCH_DEVOLUCAO_CHEQUE_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_DCH_DEVOLUCAO_CHEQUE
WHERE  
        COB_DCH_ID = pCOB_DCH_ID;	   
end PRC_COB_DCH_DEVOLUCAO_CHEQUE_D;
/
