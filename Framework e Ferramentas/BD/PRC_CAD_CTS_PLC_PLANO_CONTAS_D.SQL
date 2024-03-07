--PRC_CAD_CTS_PLC_PLANO_CONTAS_D
create or replace procedure PRC_CAD_CTS_PLC_PLANO_CONTAS_D 
(
     pCAD_CTS_PLC_ID IN TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_PLC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_CTS_PLC_PLANO_CONTAS_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_CTS_PLC_PLANO_CONTAS
WHERE  
        CAD_CTS_PLC_ID = pCAD_CTS_PLC_ID;	   
end PRC_CAD_CTS_PLC_PLANO_CONTAS_D;
