

--PRC_CAD_DAC_DIARIA_AUTOM_CNV_D
create or replace procedure PRC_CAD_DAC_DIARIA_AUTOM_CNV_D 
(
     pCAD_DAC_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_DAC_DIARIA_AUTOM_CNV_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_DAC_DIARIA_AUTOM_CNV
WHERE  
        CAD_DAC_ID = pCAD_DAC_ID;	   
end PRC_CAD_DAC_DIARIA_AUTOM_CNV_D;
