

--PRC_CAD_CAC_CLASSIF_CONTAB_S
create or replace procedure PRC_CAD_CAC_CLASSIF_CONTAB_S 
(
     pCAD_CAC_ID_CLASSCONTABIL IN TB_CAD_CAC_CLASSIF_CONTAB.CAD_CAC_ID_CLASSCONTABIL%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CAC_CLASSIF_CONTAB_S
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
       CAD_CAC_ID_CLASSCONTABIL,
       CAD_CAC_CD_CLASSCONTABIL,
       CAD_CAC_DS_CLASSCONTABIL,
       CAD_CAC_FL_CLASSCONTABIL,
       CAD_CAC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_CAC_CD_RM_NUCLEUS,
       CAD_CAC_DS_RM_NUCLEUS
FROM TB_CAD_CAC_CLASSIF_CONTAB
WHERE
        CAD_CAC_ID_CLASSCONTABIL = pCAD_CAC_ID_CLASSCONTABIL;          
io_cursor := v_cursor;
end PRC_CAD_CAC_CLASSIF_CONTAB_S;
