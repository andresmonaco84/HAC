

--PRC_ASS_PRC_PROCED_CBOS_D
create or replace procedure PRC_ASS_PRC_PROCED_CBOS_D 
(
     pCAD_PRD_CD_CODIGO IN TB_ASS_PRC_PROCED_CBOS.CAD_PRD_CD_CODIGO%type,
     pTIS_CBO_CD_CBOS_HAC IN TB_ASS_PRC_PROCED_CBOS.TIS_CBO_CD_CBOS_HAC%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_PRC_PROCED_CBOS_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_PRC_PROCED_CBOS
WHERE  
        CAD_PRD_CD_CODIGO = pCAD_PRD_CD_CODIGO
    AND TIS_CBO_CD_CBOS_HAC = pTIS_CBO_CD_CBOS_HAC;	   
end PRC_ASS_PRC_PROCED_CBOS_D;
