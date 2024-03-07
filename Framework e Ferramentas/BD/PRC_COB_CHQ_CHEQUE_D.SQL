--PRC_COB_CHQ_CHEQUE_D
create or replace procedure PRC_COB_CHQ_CHEQUE_D 
(
     pCOB_CHQ_ID IN TB_COB_CHQ_CHEQUE.COB_CHQ_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_CHQ_CHEQUE_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_CHQ_CHEQUE
WHERE  
        COB_CHQ_ID = pCOB_CHQ_ID;	   
end PRC_COB_CHQ_CHEQUE_D;
/
