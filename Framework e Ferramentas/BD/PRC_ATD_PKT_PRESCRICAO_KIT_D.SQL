

--PRC_ATD_PKT_PRESCRICAO_KIT_D
create or replace procedure PRC_ATD_PKT_PRESCRICAO_KIT_D 
(
     pATD_PKT_ID IN TB_ATD_PKT_PRESCRICAO_KIT.ATD_PKT_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_PKT_PRESCRICAO_KIT_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_PKT_PRESCRICAO_KIT
WHERE  
        ATD_PKT_ID = pATD_PKT_ID;	   
end PRC_ATD_PKT_PRESCRICAO_KIT_D;
