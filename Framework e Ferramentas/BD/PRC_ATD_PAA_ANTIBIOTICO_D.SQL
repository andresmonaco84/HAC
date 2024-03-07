

--PRC_ATD_PAA_ANTIBIOTICO_D
create or replace procedure PRC_ATD_PAA_ANTIBIOTICO_D 
(
     pATD_PAA_ID IN TB_ATD_PAA_ANTIBIOTICO.ATD_PAA_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_PAA_ANTIBIOTICO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_PAA_ANTIBIOTICO
WHERE  
        ATD_PAA_ID = pATD_PAA_ID;	   
end PRC_ATD_PAA_ANTIBIOTICO_D;
