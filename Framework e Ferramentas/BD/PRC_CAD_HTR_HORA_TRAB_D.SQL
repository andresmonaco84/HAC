

--PRC_CAD_HTR_HORA_TRAB_D
create or replace procedure PRC_CAD_HTR_HORA_TRAB_D 
(
     pCAD_HTR_ID IN TB_CAD_HTR_HORA_TRAB.CAD_HTR_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_HTR_HORA_TRAB_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_HTR_HORA_TRAB
WHERE  
        CAD_HTR_ID = pCAD_HTR_ID;	   
end PRC_CAD_HTR_HORA_TRAB_D;
