--PRC_COB_NPR_NOTA_PROMISSORIA_D
create or replace procedure PRC_COB_NPR_NOTA_PROMISSORIA_D 
(
     pCOB_NPR_ID IN TB_COB_NPR_NOTA_PROMISSORIA.COB_NPR_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_NPR_NOTA_PROMISSORIA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_NPR_NOTA_PROMISSORIA
WHERE  
        COB_NPR_ID = pCOB_NPR_ID;	   
end PRC_COB_NPR_NOTA_PROMISSORIA_D;
/
