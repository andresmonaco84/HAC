

--PRC_CAD_CME_CLASSIF_MED_S
create or replace procedure PRC_CAD_CME_CLASSIF_MED_S 
(
     pCAD_CME_CLASSIF_MED IN TB_CAD_CME_CLASSIF_MED.CAD_CME_CLASSIF_MED%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CME_CLASSIF_MED_S
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
       CAD_CME_CLASSIF_MED,
       CAD_CME_DS_CLASSIF_MED,
       CAD_CME_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_CME_CLASSIF_MED
WHERE
        CAD_CME_CLASSIF_MED = pCAD_CME_CLASSIF_MED;          
io_cursor := v_cursor;
end PRC_CAD_CME_CLASSIF_MED_S;
