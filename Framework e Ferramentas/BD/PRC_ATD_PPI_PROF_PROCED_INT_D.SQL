

--PRC_ATD_PPI_PROF_PROCED_INT_D
create or replace procedure PRC_ATD_PPI_PROF_PROCED_INT_D 
(
     pATD_PPI_ID IN TB_ATD_PPI_PROF_PROCED_INT.ATD_PPI_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_PPI_PROF_PROCED_INT_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_PPI_PROF_PROCED_INT
WHERE  
        ATD_PPI_ID = pATD_PPI_ID;	   
end PRC_ATD_PPI_PROF_PROCED_INT_D;
