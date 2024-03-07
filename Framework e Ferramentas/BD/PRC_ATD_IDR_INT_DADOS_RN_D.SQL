

--PRC_ATD_IDR_INT_DADOS_RN_D
create or replace procedure PRC_ATD_IDR_INT_DADOS_RN_D 
(
     pATD_IDR_ID IN TB_ATD_IDR_INT_DADOS_RN.ATD_IDR_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_IDR_INT_DADOS_RN_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_IDR_INT_DADOS_RN
WHERE  
        ATD_IDR_ID = pATD_IDR_ID;	   
end PRC_ATD_IDR_INT_DADOS_RN_D;
