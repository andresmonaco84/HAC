--PRC_CAD_HPL_HORA_PLANTAO_S
create or replace procedure PRC_CAD_HPL_HORA_PLANTAO_S 
(
     pCAD_HPL_ID IN TB_CAD_HPL_HORA_PLANTAO.CAD_HPL_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_HPL_HORA_PLANTAO_S
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
       CAD_HPL_ID,
       CAD_CLC_ID,
       CAD_HPL_DT_INICIO_VIGENCIA,
       CAD_HPL_DT_FIM_VIGENCIA,
       CAD_HPL_QT_HORA_SEMANAL,
       CAD_HPL_QT_HORA_FIM_SEMANA,
       ASS_CPR_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_PRO_ID_PROFISSIONAL,
       TIS_CBO_CD_CBOS,
       CAD_PRD_ID,
       ASS_CPR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       TIS_MED_CD_TABELAMEDICA,
       AUX_EPP_CD_ESPECPROC,
       AUX_GPC_CD_GRUPOPROC,
       CAD_CNV_ID_CONVENIO,
       CAD_SET_ID,
       CAD_TPE_CD_CODIGO,
       CAD_PLA_ID_PLANO,
       CAD_HPL_VL_FATOR_MULTI,
       CAD_HPL_QT_HORA_DIA
FROM TB_CAD_HPL_HORA_PLANTAO
WHERE
        CAD_HPL_ID = pCAD_HPL_ID;          
io_cursor := v_cursor;
end PRC_CAD_HPL_HORA_PLANTAO_S;
