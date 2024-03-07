

--PRC_CAD_HTR_HORA_TRAB_S
create or replace procedure PRC_CAD_HTR_HORA_TRAB_S 
(
     pCAD_HTR_ID IN TB_CAD_HTR_HORA_TRAB.CAD_HTR_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_HTR_HORA_TRAB_S
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
       CAD_HTR_ID,
       CAD_CLC_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_PRO_ID_PROFISSIONAL,
       TIS_CBO_CD_CBOS,
       CAD_SET_ID,
       CAD_HTR_DT_INICIO_VIGENCIA,
       CAD_HTR_DT_FIM_VIGENCIA,
       CAD_HTR_QT_HORA_SEMANA,
       CAD_HTR_VL_FATOR_MULTI_SEMANA,
       CAD_HTR_QT_HORA_FIM_SEMANA,
       CAD_HTR_VL_FATOR_MULTI_FIMSEM,
       CAD_HTR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_HTR_HORA_TRAB
WHERE
        CAD_HTR_ID = pCAD_HTR_ID;          
io_cursor := v_cursor;
end PRC_CAD_HTR_HORA_TRAB_S;
