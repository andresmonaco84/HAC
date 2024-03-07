

--PRC_CAD_DAC_DIARIA_AUTOM_CNV_S
create or replace procedure PRC_CAD_DAC_DIARIA_AUTOM_CNV_S 
(
     pCAD_DAC_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_DAC_DIARIA_AUTOM_CNV_S
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
       CAD_DAC_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       TIS_TAC_CD_TIPO_ACOMODACAO,
       CAD_PRD_ID,
       CAD_SPL_ID,
       CAD_SET_ID,
       CAD_DAC_DT_INICIO_VIGENCIA,
       CAD_DAC_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO,
       CAD_DAC_DT_ULTIMA_ATUALIZACAO,
       CAD_DAC_FL_CONSIDERAOBITO,
       CAD_DAC_HR_OBITO_MAIOR
FROM TB_CAD_DAC_DIARIA_AUTOM_CNV
WHERE
        CAD_DAC_ID = pCAD_DAC_ID;          
io_cursor := v_cursor;
end PRC_CAD_DAC_DIARIA_AUTOM_CNV_S;
