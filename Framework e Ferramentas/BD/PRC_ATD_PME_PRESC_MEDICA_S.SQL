create or replace procedure PRC_ATD_PME_PRESC_MEDICA_S
(
     pATD_PME_ID IN TB_ATD_PME_PRESCRICAO_MEDICA.ATD_PME_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_PME_PRESCRICAO_MEDICA_S
*
*    Data Criacao: data da  cria??o   Por: Nome do Analista
*    Data Alteracao:data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ATD_PME_ID,
       ATD_ATE_ID,
       ATD_PME_FL_STATUS,
       ATD_PME_TP_PRESCRICAO,
       ATD_PME_QT_PESO,
       ATD_PME_FL_PESO_AFERIDO,
       ATD_PME_FL_PESO_REFERIDO,
       ATD_PME_QT_ALTURA,
       ATD_PME_QT_PESO_CALORICO,
       ATD_PME_FL_ALERGIA,
       ATD_PME_DS_ALERGIA,
       ATD_PME_DT_HR_CRIACAO,
       ATD_PME_ID_USU_CRIACAO,
       ATD_PME_DT_ULT_ATUALIZ,
       ATD_PME_ID_USU_ULT_ATUALIZ,
       ATD_PME_FL_RN,
       ATD_IDR_ID,
       ATD_PME_DT_HEMODIALISE,
       ATD_PME_HR_H_INI,
       ATD_PME_HR_H_FIM,
       ATD_PME_FL_H_PESO,
       ATD_PME_VL_H_PESO,
       ATD_PME_FL_H_ISOLAMENTO,
       ATD_PME_VL_H_ISOLAMENTO,
       ATD_PME_FL_H_SOROLOGIA,
       ATD_PME_FL_H_HBSAG,
       ATD_PME_FL_H_ANTIHCV,
       ATD_PME_FL_H_ANTIHIV,
       ATD_PME_VL_H_PESOSECOPRE,
       ATD_PME_VL_H_PESOSECOPOS,
       ATD_PME_VL_H_PAMINPRE,
       ATD_PME_VL_H_PAMAXPRE,
       ATD_PME_VL_H_PAMINPOS,
       ATD_PME_VL_H_PAMAXPOS,
       ATD_PME_VL_H_PULSOPRE,
       ATD_PME_VL_H_PULSOPOS,
       ATD_PME_HR_H_DURACAO,
       ATD_PME_VL_H_DIALISATONA,
       ATD_PME_VL_H_DIALISATOCA,
       ATD_PME_VL_H_ADICAODEK,
       ATD_PME_VL_H_HEPARINA,
       ATD_PME_VL_H_TEMPERATURA,
       ATD_PME_VL_H_FLUXODIALISAT,
       ATD_PME_VL_H_FLUXOSANGUE,
       ATD_PME_VL_H_ULTRAFILTRACAO,
       ATD_PME_VL_H_GLICEMIACAPILA,
       ATD_PME_DS_H_OBSERVACAO_MED,
       ATD_PME_CD_H_E_VIAACESSO,

     ATD_PME_FL_H_ENCAMINHAM,
       ATD_PME_FL_H_E_STATUS,
       ATD_PME_FL_TEV_AVALIACAO,
       ATD_PME_FL_TEV_CONTR_IND,
       ATD_PME_DS_TEV_OBSERVACAO,
       ATD_PME_ID_H_E_USU_CRIACAO,
       ATD_PME_DT_H_E_CRIACAO,
       ATD_PME_ID_H_E_USU_ATUALIZ,
       ATD_PME_DT_H_E_ULT_ATUALIZ,
       ATD_PME_FL_H_STATUS,
       ATD_PME_DS_OBS_FARMACIA,
       ATD_PME_DS_OBS_FARMAC_ANT,
       ATD_PME_DS_JUSTIF,
       SEG_USU_ID_INTERV_ANT,
       SEG_USU_ID_INTERV

FROM TB_ATD_PME_PRESCRICAO_MEDICA
WHERE
        ATD_PME_ID = pATD_PME_ID;
io_cursor := v_cursor;
end PRC_ATD_PME_PRESC_MEDICA_S;
