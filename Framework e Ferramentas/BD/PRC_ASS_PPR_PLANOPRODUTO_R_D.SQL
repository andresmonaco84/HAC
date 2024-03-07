

--PRC_ASS_PPR_PLANOPRODUTO_R_D
create or replace procedure PRC_ASS_PPR_PLANOPRODUTO_R_D 
(
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PPR_PLANOPRODUTO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_PPR_PLANOPRODUTO.CAD_PLA_ID_PLANO%type,
     pCAD_PRD_ID IN TB_ASS_PPR_PLANOPRODUTO.CAD_PRD_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_PPR_PLANOPRODUTO_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_PPR_PLANOPRODUTO
WHERE  
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
    AND CAD_PRD_ID = pCAD_PRD_ID;	   
end PRC_ASS_PPR_PLANOPRODUTO_R_D;
