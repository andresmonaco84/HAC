--PRC_CAD_MDC_MOTIVO_DEV_CHEQUE_D
create or replace procedure PRC_CAD_MDC_MOT_DEV_CHEQUE_D 
(
     pCAD_MDC_ID IN TB_CAD_MDC_MOTIVO_DEV_CHEQUE.CAD_MDC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_MDC_MOTIVO_DEV_CHEQUE_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_MDC_MOTIVO_DEV_CHEQUE
WHERE  
        CAD_MDC_ID = pCAD_MDC_ID;	   
end PRC_CAD_MDC_MOT_DEV_CHEQUE_D;
/
