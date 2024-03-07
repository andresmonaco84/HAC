

--PRC_CAD_UMC_UNI_MED_CONSUMO_S
create or replace procedure PRC_CAD_UMC_UNI_MED_CONSUMO_S 
(
     pCAD_UMC_CD_MEDIDA_CONSUMO IN TB_CAD_UMC_UNI_MED_CONSUMO.CAD_UMC_CD_MEDIDA_CONSUMO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_UMC_UNI_MED_CONSUMO_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       CAD_UMC_CD_MEDIDA_CONSUMO,
       CAD_UMC_DS_MEDIDA_CONSUMO,
       CAD_UMC_FL_STATUS,
       CAD_UML_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_UMC_UNI_MED_CONSUMO
WHERE
        CAD_UMC_CD_MEDIDA_CONSUMO = pCAD_UMC_CD_MEDIDA_CONSUMO;          
io_cursor := v_cursor;
end PRC_CAD_UMC_UNI_MED_CONSUMO_S;
