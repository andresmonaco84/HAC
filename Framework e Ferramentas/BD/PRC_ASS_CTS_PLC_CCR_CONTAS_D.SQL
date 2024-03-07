--PRC_ASS_CTS_PLC_CCR_CONTAS_D
create or replace procedure PRC_ASS_CTS_PLC_CCR_CONTAS_D 
(
     pASS_CTS_CCR_ID IN TB_ASS_CTS_PLC_CCR_CONTAS.ASS_CTS_CCR_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_CTS_PLC_CCR_CONTAS_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_CTS_PLC_CCR_CONTAS
WHERE  
        ASS_CTS_CCR_ID = pASS_CTS_CCR_ID;	   
end PRC_ASS_CTS_PLC_CCR_CONTAS_D;
