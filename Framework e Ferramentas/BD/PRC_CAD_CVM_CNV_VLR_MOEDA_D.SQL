--PRC_CAD_CVM_CONV_VLR_MOEDAHOS_D
create or replace procedure PRC_CAD_CVM_CNV_VLR_MOEDA_D 
(
     pCAD_CVM_ID IN TB_CAD_CVM_CONV_VLR_MOEDAHOS.CAD_CVM_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_CVM_CNV_VLR_MOEDA_D
* 
*    Data Criacao: 	10/12/2009   Por: Pedro
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_CVM_CONV_VLR_MOEDAHOS
WHERE  
        CAD_CVM_ID = pCAD_CVM_ID;	   
end PRC_CAD_CVM_CNV_VLR_MOEDA_D;

