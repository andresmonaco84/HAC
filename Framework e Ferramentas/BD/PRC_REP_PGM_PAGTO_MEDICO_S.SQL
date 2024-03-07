CREATE OR REPLACE PROCEDURE SGS."PRC_REP_PGM_PAGTO_MEDICO_S"
(
       PREP_PGM_ID IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ID%TYPE,
       IO_CURSOR   OUT PKG_CURSOR.T_CURSOR
)
IS
  /********************************************************************
  *    Procedure: PRC_REP_PGM_PAGTO_MEDICO_S
  *
  *    Data Criacao:  data da  cria��o   Por: Nome do Analista
  *    Data Alteracao: data da altera��o  Por: Nome do Analista
  *
  *    Funcao: Descri��o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
    SELECT ATD_ATE_ID,
           ATD_ATE_FL_CARATER_SOLIC,
           FAT_CCP_ID,
           FAT_COC_ID,
           CAD_TAP_TP_ATRIBUTO,
           CAD_PRD_ID,
           CAD_TIH_TP_INDICE_HOSP,
           REP_PGM_QT_INDICE,
           REP_PGM_VL_INDICE,
           REP_PGM_VL_UNITARIO,
           REP_PGM_DT_INICIO_REALIZACAO,
           REP_PGM_HR_INICIO_REALIZACAO,
           REP_PGM_VL_FATURADO,
           REP_PGM_QT_CONSUMO,
           CAD_PRO_ID_PROFISSIONAL,
           REP_PGM_PC_GRAU_PART_PROF,
           REP_PGM_DT_ULTIMA_ATUALIZACAO,
           REP_PGM_VL_CALCULADO,
           CAD_PAC_ID_PACIENTE,
           REP_PGM_TP_CREDENCIA_PROF,
           REP_PGM_FL_PACOTE,
           CAD_CEC_ID_CCUSTO,
           CAD_CAC_ID_CLASSCONTABIL,
           REP_PGM_MES_FECHAMENTO,
           REP_PGM_ANO_FECHAMENTO,
           SEG_USU_ID_USUARIO_CRIACAO,
           REP_PGM_DT_CRIACAO,
           REP_PGM_MES_PAGTO,
           REP_PGM_ANO_PAGTO,
           REP_PGM_FL_PAGO,
           REP_PGM_DT_PAGAMENTO,
           CAD_UNI_ID_UNIDADE,
           CAD_LAT_ID_LOCAL_ATENDIMENTO,
           CAD_UNI_ID_UNIDADE_PAGTO,
           REP_PGM_FL_STATUS,
           REP_PGM_CD_ORIGEM,
           REP_PGM_ID,
           CAD_SET_ID_REALIZACAO,
           CAD_SET_ID_MOVIMENTACAO,
           FAT_CCI_PC_ACOMODACAO_HM,
           REP_PGM_CD_JUSTIFICATIVA,
           SEG_USU_ID_USUARIO_ATUALIZ,
           CAD_CNV_ID_CONVENIO,
           CAD_CLC_ID,
           CAD_REP_VL_PAGTO_EXTRA,
           CAD_PLA_CD_TIPOPLANO,
           AUX_EPP_CD_ESPECPROC,
           TIS_MED_CD_TABELAMEDICA,
           REP_PGM_VL_PAGO,
           AUX_GPC_CD_GRUPOPROC,
           TIS_TAC_CD_TIPO_ACOMOD_AUT,
           REP_RPA_ID,
           FAT_CCI_ID,
           REP_PGM_FL_ATENDIMENTO_RETORNO,
           REP_PGM_QT_CUSTO_OPER,
           REP_PGM_QT_HONORARIO,
           CAD_TPE_CD_CODIGO,
           TIS_CBO_CD_CBOS,
           ASS_RPG_ID,
           REP_PPC_ID,
           REP_PGM_FONTE_PAGADORA,
           CAD_PRD_ID_COBRADO

      FROM TB_REP_PGM_PAGTO_MEDICO
     WHERE REP_PGM_ID = PREP_PGM_ID;
  IO_CURSOR := V_CURSOR;
END PRC_REP_PGM_PAGTO_MEDICO_S;