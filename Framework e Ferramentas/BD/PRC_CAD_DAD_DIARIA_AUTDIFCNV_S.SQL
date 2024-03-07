

--PRC_CAD_DAD_DIARIA_AUTDIFCNV_S
create or replace procedure PRC_CAD_DAD_DIARIA_AUTDIFCNV_S 
(
     pCAD_DAD_ID IN TB_CAD_DAD_DIARIA_AUTDIFCNV.CAD_DAD_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_DAD_DIARIA_AUTDIFCNV_S
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
       CAD_DAD_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_CNV_ID_CONVENIO_DES,
       CAD_PLA_ID_PLANO,
       CAD_SPL_ID,
       TIS_TAC_CD_TIPO_ACOMOD_ORI,
       CAD_PRD_ID_ORI,
       TIS_TAC_CD_TIPO_ACOMOD_DES,
       CAD_PRD_ID_DES,
       CAD_SET_ID,
       CAD_DAD_DT_INICIO_VIGENCIA,
       CAD_DAD_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO,
       CAD_DAD_DT_ULTIMA_ATUALIZACAO,
       CAD_DAD_FL_CONSIDERAOBITO,
       CAD_DAD_HR_OBITO_MAIOR
FROM TB_CAD_DAD_DIARIA_AUTDIFCNV
WHERE
        CAD_DAD_ID = pCAD_DAD_ID;          
io_cursor := v_cursor;
end PRC_CAD_DAD_DIARIA_AUTDIFCNV_S;
