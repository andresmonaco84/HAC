--PRC_ASS_CTU_CNV_TAB_UTILIZA_D
create or replace procedure PRC_ASS_CTU_CNV_TAB_UTILIZA_D 
(
     pASS_CTU_ID IN TB_ASS_CTU_CNV_TAB_UTILIZA.ASS_CTU_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_CTU_CNV_TAB_UTILIZA_D
* 
*    Data Criacao: 19/2/2010	   Por: Pedro
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_CTU_CNV_TAB_UTILIZA
WHERE  
        ASS_CTU_ID = pASS_CTU_ID;	   
end PRC_ASS_CTU_CNV_TAB_UTILIZA_D;
