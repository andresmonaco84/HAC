

--PRC_CAD_NFM_NOTA_FIS_MAT_D
create or replace procedure PRC_CAD_NFM_NOTA_FIS_MAT_D 
(
     pCAD_NFM_ID IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_NFM_NOTA_FIS_MAT_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_NFM_NOTA_FIS_MAT
WHERE  
        CAD_NFM_ID = pCAD_NFM_ID;	   
end PRC_CAD_NFM_NOTA_FIS_MAT_D;
