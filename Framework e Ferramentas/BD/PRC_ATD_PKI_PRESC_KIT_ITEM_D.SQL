

--PRC_ATD_PKI_PRESCRICAO_KIT_ITEM_D
create or replace procedure PRC_ATD_PKI_PRESC_KIT_ITEM_D 
(
     pATD_PKI_ID IN TB_ATD_PKI_PRESCRICAO_KIT_ITEM.ATD_PKI_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_PKI_PRESCRICAO_KIT_ITEM_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_PKI_PRESCRICAO_KIT_ITEM
WHERE  
        ATD_PKI_ID = pATD_PKI_ID;	   
end PRC_ATD_PKI_PRESC_KIT_ITEM_D;
