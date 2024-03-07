create or replace procedure PRC_ATD_IEP_INT_EVOL_PAC_S
(
     pATD_IEP_ID IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_IEP_INT_EVOL_PACIENTE_S
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
       ATD_IEP_ID,
       ATD_ATE_ID,
       ATD_IEP_DT_EVOLUCAO,
       ATD_IEP_HR_EVOLUCAO,
       CAD_CID_CD_CID10,
       ATD_IEP_DS_EVOLUCAO,
       ATD_IEP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PRO_ID_PROFISSIONAL,
       TIS_CBO_CD_CBOS,
       ATD_IEP_DIAGNOSTICO,
       ATD_IEP_ANTECEDENTES,
       ATD_IEP_ALERGIAS,
       ATD_IEP_ANTIBIOTICOS,
       ATD_IEP_PROTOCOLOS,
       ATD_IEP_EXAME_FIS,
       ATD_IEP_APLANOTER,
       ATD_IEP_INTERCONS,
       ATD_IEP_OBS,
       ATD_IEP_HISTOR_MOL_ATU,
       ATD_IEP_EXA_LAB_IMAG,
       ATD_IEP_FL_STATUS_EVOLUCAO,
       ATD_IEP_IMPRESSAO_CLINICA,
       ATD_IEP_DS_ADMISSAO,
       --ATD_IEP_DS_EVOLUCAO_CLOB
       ATD_IEP_INTERCORRENCIA,
       ATD_IEP_MED_USO_CONTINUO,
       ATD_IDR_ID,
       ATD_IEP_RN_DIAG_PATMAT ,
       ATD_IEP_RN_CONTR_TRIAG ,
       ATD_IEP_RN_EXAMF_PEND_ORI ,
       ATD_IEP_ALERTA_EXAMES,
       ATD_IEP_SCIH

FROM TB_ATD_IEP_INT_EVOL_PACIENTE
WHERE
        ATD_IEP_ID = pATD_IEP_ID;
io_cursor := v_cursor;
end PRC_ATD_IEP_INT_EVOL_PAC_S;
/
