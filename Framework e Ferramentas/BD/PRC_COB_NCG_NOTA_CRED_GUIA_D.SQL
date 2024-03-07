--PRC_COB_NCG_NOTA_CREDITO_GUIA_D
create or replace procedure PRC_COB_NCG_NOTA_CRED_GUIA_D 
(
     pCOB_NCG_ID IN TB_COB_NCG_NOTA_CREDITO_GUIA.COB_NCG_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_NCG_NOTA_CREDITO_GUIA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_NCG_NOTA_CREDITO_GUIA
WHERE  
        COB_NCG_ID = pCOB_NCG_ID;	   
end PRC_COB_NCG_NOTA_CRED_GUIA_D;
/
