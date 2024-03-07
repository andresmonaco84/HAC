

--PRC_CAD_VCM_VAL_COBR_MAT_MED_D
create or replace procedure PRC_CAD_VCM_VAL_COBR_MAT_MED_D 
(
     pCAD_VCM_ID IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_VCM_VAL_COBR_MAT_MED_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_VCM_VAL_COBR_MAT_MED
WHERE  
        CAD_VCM_ID = pCAD_VCM_ID;	   
end PRC_CAD_VCM_VAL_COBR_MAT_MED_D;
