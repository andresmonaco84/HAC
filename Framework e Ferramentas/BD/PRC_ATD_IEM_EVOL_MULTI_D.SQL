

--PRC_ATD_IEM_EVOL_MULTI_D
create or replace procedure PRC_ATD_IEM_EVOL_MULTI_D 
(
     pATD_IEM_ID IN TB_ATD_IEM_EVOL_MULTI.ATD_IEM_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_IEM_EVOL_MULTI_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_IEM_EVOL_MULTI
WHERE  
        ATD_IEM_ID = pATD_IEM_ID;	   
end PRC_ATD_IEM_EVOL_MULTI_D;
