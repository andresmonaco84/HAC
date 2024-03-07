--PRC_COB_PAG_PAGAMENTO_GUIA_D
create or replace procedure PRC_COB_PAG_PAGAMENTO_GUIA_D 
(
     pCOB_PAG_ID IN TB_COB_PAG_PAGAMENTO_GUIA.COB_PAG_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_PAG_PAGAMENTO_GUIA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_PAG_PAGAMENTO_GUIA
WHERE  
        COB_PAG_ID = pCOB_PAG_ID;	   
end PRC_COB_PAG_PAGAMENTO_GUIA_D;
/
