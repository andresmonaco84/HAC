--PRC_ATD_CIR_CIRURGIA_REAL_D
create or replace procedure PRC_ATD_CIR_CIRURGIA_REAL_D 
(
     pATD_CIR_ID IN TB_ATD_CIR_CIRURGIA_REALIZADA.ATD_CIR_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_CIR_CIRURGIA_REAL_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_CIR_CIRURGIA_REALIZADA
WHERE  
        ATD_CIR_ID = pATD_CIR_ID;	   
end PRC_ATD_CIR_CIRURGIA_REAL_D;
