create or replace procedure PRC_ATD_MPM_MED_PRESC_MED_S
(
     pATD_MPM_ID IN TB_ATD_MPM_MED_PRESC_MED.ATD_MPM_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_MPM_MED_PRESC_MED_S
*
*    Data Criacao:  data da  cria??o   Por: Nome do Analista
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ATD_MPM_ID,
       ATD_PME_ID,
       CAD_MTMD_ID,
       ATD_MPM_DS_DOSE,
       ATD_MPM_DS_VIA,
       ATD_MPM_DS_INTERVALO,
       ATD_MPM_DS_OBSERVACAO,
       ATD_MPM_DT_HORA_CRIACAO,
       ATD_MPM_ID_USU_CRIACAO,
       ATD_MPM_DT_ULT_ATUALIZ,
       ATD_MPM_ID_USU_ULT_ATUALIZ,
       ATD_MPM_DS_MEDICAMENTO,
       INT_PPR_ID,
       ATD_MPM_CD_VIA,
       ATD_MPM_FL_IMEDIATO,
       ATD_MPM_DT_HORA_REALIZ,
       ATD_MPM_FL_PEDIDO_EST,
       ATD_MPM_QT_PEDIDO,
       ATD_MPM_DILUENTE,
       ATD_MPM_COMPLEMENTO,
       ATD_MPM_FORMAFARMAC,
       ATD_MPM_ID_PAI,
       ATD_MPM_NOME_PACIENTE,
       ATD_MPM_TIPO,
       ATD_MPM_DOSE_ADM,
       ATD_MPM_FL_IMPRESSO,
       ATD_MPM_JUSTIFICATIVA,
       ATD_MPM_STATUS,
       ATD_MPM_APRAZAMENTO,
       ATD_MPM_TP_CONDICIONAL,
       ATD_MPM_FL_PROFILATICO_ORIGEM,
       ATD_MPM_DT_INICIO

FROM TB_ATD_MPM_MED_PRESC_MED
WHERE
        ATD_MPM_ID = pATD_MPM_ID;
io_cursor := v_cursor;
end PRC_ATD_MPM_MED_PRESC_MED_S;
