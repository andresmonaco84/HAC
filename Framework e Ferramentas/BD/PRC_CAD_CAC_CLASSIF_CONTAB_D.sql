

--PRC_CAD_CAC_CLASSIF_CONTAB_D
create or replace procedure PRC_CAD_CAC_CLASSIF_CONTAB_D 
(
     pCAD_CAC_ID_CLASSCONTABIL IN TB_CAD_CAC_CLASSIF_CONTAB.CAD_CAC_ID_CLASSCONTABIL%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_CAC_CLASSIF_CONTAB_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_CAC_CLASSIF_CONTAB
WHERE  
        CAD_CAC_ID_CLASSCONTABIL = pCAD_CAC_ID_CLASSCONTABIL;	   
end PRC_CAD_CAC_CLASSIF_CONTAB_D;
