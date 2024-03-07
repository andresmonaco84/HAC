

--PRC_CAD_UMC_UNI_MED_CONSUMO_D
create or replace procedure PRC_CAD_UMC_UNI_MED_CONSUMO_D 
(
     pCAD_UMC_CD_MEDIDA_CONSUMO IN TB_CAD_UMC_UNI_MED_CONSUMO.CAD_UMC_CD_MEDIDA_CONSUMO%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_UMC_UNI_MED_CONSUMO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_UMC_UNI_MED_CONSUMO
WHERE  
        CAD_UMC_CD_MEDIDA_CONSUMO = pCAD_UMC_CD_MEDIDA_CONSUMO;	   
end PRC_CAD_UMC_UNI_MED_CONSUMO_D;
