

--PRC_CAD_UMC_UNI_MED_CONSUMO_U
create or replace procedure PRC_CAD_UMC_UNI_MED_CONSUMO_U
(
     pCAD_UMC_CD_MEDIDA_CONSUMO IN TB_CAD_UMC_UNI_MED_CONSUMO.CAD_UMC_CD_MEDIDA_CONSUMO%type,
     pCAD_UMC_DS_MEDIDA_CONSUMO IN TB_CAD_UMC_UNI_MED_CONSUMO.CAD_UMC_DS_MEDIDA_CONSUMO%type,
     pCAD_UMC_FL_STATUS IN TB_CAD_UMC_UNI_MED_CONSUMO.CAD_UMC_FL_STATUS%type,
     pCAD_UML_DT_ULTIMA_ATUALIZACAO IN TB_CAD_UMC_UNI_MED_CONSUMO.CAD_UML_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_UMC_UNI_MED_CONSUMO.SEG_USU_ID_USUARIO%type default NULL
) 
is
/********************************************************************
*    Procedure: PRC_CAD_UMC_UNI_MED_CONSUMO_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_CAD_UMC_UNI_MED_CONSUMO
SET	   
        CAD_UMC_DS_MEDIDA_CONSUMO = pCAD_UMC_DS_MEDIDA_CONSUMO,
        CAD_UMC_FL_STATUS = pCAD_UMC_FL_STATUS,
        CAD_UML_DT_ULTIMA_ATUALIZACAO = pCAD_UML_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
WHERE
        CAD_UMC_CD_MEDIDA_CONSUMO = pCAD_UMC_CD_MEDIDA_CONSUMO;	
end PRC_CAD_UMC_UNI_MED_CONSUMO_U;

