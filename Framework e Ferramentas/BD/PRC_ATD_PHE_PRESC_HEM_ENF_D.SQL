

--PRC_ATD_PHE_PRESC_HEM_ENF_D
create or replace procedure PRC_ATD_PHE_PRESC_HEM_ENF_D 
(
     pATD_PHE_ID IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_PHE_PRESC_HEM_ENF_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_PHE_PRESC_HEM_ENF
WHERE  
        ATD_PHE_ID = pATD_PHE_ID;	   
end PRC_ATD_PHE_PRESC_HEM_ENF_D;
