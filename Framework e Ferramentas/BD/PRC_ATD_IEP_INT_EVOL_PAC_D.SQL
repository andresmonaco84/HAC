

--PRC_ATD_IEP_INT_EVOL_PACIENTE_D
create or replace procedure PRC_ATD_IEP_INT_EVOL_PAC_D 
(
     pATD_IEP_ID IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_IEP_INT_EVOL_PACIENTE_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_IEP_INT_EVOL_PACIENTE
WHERE  
        ATD_IEP_ID = pATD_IEP_ID;	   
end PRC_ATD_IEP_INT_EVOL_PAC_D;
