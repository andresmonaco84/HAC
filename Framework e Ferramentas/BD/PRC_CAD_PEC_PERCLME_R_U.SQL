

--PRC_CAD_PEC_PERCLME_R_U
create or replace procedure PRC_CAD_PEC_PERCLME_R_U
(
     pCAD_PEC_ID IN TB_CAD_PEC_PERCLME.CAD_PEC_ID%type,
     pCAD_CME_CLASSIF_MED IN TB_CAD_PEC_PERCLME.CAD_CME_CLASSIF_MED%type,
     pCAD_PEC_PC_CLASSIF_MED IN TB_CAD_PEC_PERCLME.CAD_PEC_PC_CLASSIF_MED%type,
     pCAD_PEC_PC_ICMS IN TB_CAD_PEC_PERCLME.CAD_PEC_PC_ICMS%type default NULL,
     pCAD_PEC_DT_INICIO_VIGENCIA IN TB_CAD_PEC_PERCLME.CAD_PEC_DT_INICIO_VIGENCIA%type,
     pCAD_PEC_DT_FIM_VIGENCIA IN TB_CAD_PEC_PERCLME.CAD_PEC_DT_FIM_VIGENCIA%type default NULL,
     pCAD_PEC_DT_ULTIMA_ATUALIZACAO IN TB_CAD_PEC_PERCLME.CAD_PEC_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_PEC_PERCLME.SEG_USU_ID_USUARIO%type
) 
is
/********************************************************************
*    Procedure: PRC_CAD_PEC_PERCLME_R_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_CAD_PEC_PERCLME
SET	   
        CAD_CME_CLASSIF_MED = pCAD_CME_CLASSIF_MED,
        CAD_PEC_PC_CLASSIF_MED = pCAD_PEC_PC_CLASSIF_MED,
        CAD_PEC_PC_ICMS = pCAD_PEC_PC_ICMS,
        CAD_PEC_DT_INICIO_VIGENCIA = pCAD_PEC_DT_INICIO_VIGENCIA,
        CAD_PEC_DT_FIM_VIGENCIA = pCAD_PEC_DT_FIM_VIGENCIA,
        CAD_PEC_DT_ULTIMA_ATUALIZACAO = pCAD_PEC_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
WHERE
        CAD_PEC_ID = pCAD_PEC_ID;	
end PRC_CAD_PEC_PERCLME_R_U;

