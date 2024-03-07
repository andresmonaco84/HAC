

--PRC_CAD_HIP_HISTORICO_PRD_R_D
create or replace procedure PRC_CAD_HIP_HISTORICO_PRD_R_D 
(
     pCAD_HIP_CD_CODIGO IN TB_CAD_HIP_HISTORICO_PRODUTO.CAD_HIP_CD_CODIGO%type,
     pCAD_HIP_DT_INICIO_VIGENCIA IN TB_CAD_HIP_HISTORICO_PRODUTO.CAD_HIP_DT_INICIO_VIGENCIA%type,
     pCAD_HIP_NM_MNEMONICO IN TB_CAD_HIP_HISTORICO_PRODUTO.CAD_HIP_NM_MNEMONICO%type,
     pCAD_PRD_ID IN TB_CAD_HIP_HISTORICO_PRODUTO.CAD_PRD_ID%type,
     pTIS_MED_CD_TABELAMEDICA IN TB_CAD_HIP_HISTORICO_PRODUTO.TIS_MED_CD_TABELAMEDICA%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_HIP_HISTORICO_PRD_R_D
* 
*    Data Criacao: 	08/07/2010   Por: Rafael Coimbra
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_HIP_HISTORICO_PRODUTO
WHERE  
        CAD_HIP_CD_CODIGO = pCAD_HIP_CD_CODIGO
    AND CAD_HIP_DT_INICIO_VIGENCIA = pCAD_HIP_DT_INICIO_VIGENCIA
    AND CAD_HIP_NM_MNEMONICO = pCAD_HIP_NM_MNEMONICO
    AND CAD_PRD_ID = pCAD_PRD_ID
    AND TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA;	   
end PRC_CAD_HIP_HISTORICO_PRD_R_D;
