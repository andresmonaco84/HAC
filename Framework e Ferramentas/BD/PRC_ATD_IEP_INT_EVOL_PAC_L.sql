﻿create or replace procedure PRC_ATD_IEP_INT_EVOL_PAC_L
(
     pATD_IEP_ID IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_ID%type DEFAULT NULL,
     pATD_ATE_ID IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_ATE_ID%type DEFAULT NULL,
     pATD_IEP_DT_EVOLUCAO IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_DT_EVOLUCAO%type DEFAULT NULL,
     pATD_IEP_HR_EVOLUCAO IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_HR_EVOLUCAO%type DEFAULT NULL,
     pCAD_CID_CD_CID10 IN TB_ATD_IEP_INT_EVOL_PACIENTE.CAD_CID_CD_CID10%type DEFAULT NULL,
     pATD_IEP_DS_EVOLUCAO IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_DS_EVOLUCAO%type DEFAULT NULL,
     pATD_IEP_DT_ULTIMA_ATUALIZACAO IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ATD_IEP_INT_EVOL_PACIENTE.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ATD_IEP_INT_EVOL_PACIENTE.CAD_PRO_ID_PROFISSIONAL%type DEFAULT NULL,
     pTIS_CBO_CD_CBOS IN TB_ATD_IEP_INT_EVOL_PACIENTE.TIS_CBO_CD_CBOS%type DEFAULT NULL,
     pATD_IEP_DIAGNOSTICO IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_DIAGNOSTICO%type DEFAULT NULL,
     pATD_IEP_ANTECEDENTES IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_ANTECEDENTES%type DEFAULT NULL,
     pATD_IEP_ALERGIAS IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_ALERGIAS%type DEFAULT NULL,
     pATD_IEP_ANTIBIOTICOS IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_ANTIBIOTICOS%type DEFAULT NULL,
     pATD_IEP_PROTOCOLOS IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_PROTOCOLOS%type DEFAULT NULL,
     pATD_IEP_EXAME_FIS IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_EXAME_FIS%type DEFAULT NULL,
     pATD_IEP_APLANOTER IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_APLANOTER%type DEFAULT NULL,
     pATD_IEP_INTERCONS IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_INTERCONS%type DEFAULT NULL,
     pATD_IEP_OBS IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_OBS%type DEFAULT NULL,
     pATD_IEP_HISTOR_MOL_ATU IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_HISTOR_MOL_ATU%type DEFAULT NULL,
     pATD_IEP_EXA_LAB_IMAG IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_EXA_LAB_IMAG%type DEFAULT NULL,
     pATD_IEP_FL_STATUS_EVOLUCAO IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_FL_STATUS_EVOLUCAO%type DEFAULT NULL,
     pATD_IEP_IMPRESSAO_CLINICA IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_IMPRESSAO_CLINICA%type DEFAULT NULL,
     pATD_IEP_DS_ADMISSAO IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_DS_ADMISSAO%type default NULL,
   --  pATD_IEP_DS_EVOLUCAO_CLOB IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_DS_EVOLUCAO_CLOB%type default NULL,
    pATD_IEP_INTERCORRENCIA IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_INTERCORRENCIA%type default NULL,
    pATD_IEP_MED_USO_CONTINUO IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_MED_USO_CONTINUO%type default NULL,
    pATD_IDR_ID IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IDR_ID%type default NULL,
    pATD_IEP_RN_DIAG_PATMAT IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_RN_DIAG_PATMAT%type default NULL,
    pATD_IEP_RN_CONTR_TRIAG IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_RN_CONTR_TRIAG%type default NULL,
     pATD_IEP_RN_EXAMF_PEND_ORI IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_RN_EXAMF_PEND_ORI%type default NULL,    
          pATD_IEP_ALERTA_EXAMES IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_ALERTA_EXAMES%type default NULL,
          pATD_IEP_SCIH IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_SCIH%type default NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_IEP_INT_EVOL_PAC_L
*
*    Data Criacao:   data da  cria??o   Por: Nome do Analista
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
begin
  V_WHERE := NULL;
  IF pATD_IEP_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_ID = ' || pATD_IEP_ID; END IF;
IF pATD_ATE_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_ATE_ID = ' || pATD_ATE_ID; END IF;
IF pATD_IEP_DT_EVOLUCAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_DT_EVOLUCAO = ' || CHR(39) || pATD_IEP_DT_EVOLUCAO || CHR(39); END IF;
IF pATD_IEP_HR_EVOLUCAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_HR_EVOLUCAO = ' || pATD_IEP_HR_EVOLUCAO; END IF;
IF pCAD_CID_CD_CID10 IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CID_CD_CID10 = ' || CHR(39) || pCAD_CID_CD_CID10 || CHR(39); END IF;
IF pATD_IEP_DS_EVOLUCAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_DS_EVOLUCAO = ' || CHR(39) || pATD_IEP_DS_EVOLUCAO || CHR(39); END IF;
IF pATD_IEP_DT_ULTIMA_ATUALIZACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_DT_ULTIMA_ATUALIZACAO = ' || CHR(39) || pATD_IEP_DT_ULTIMA_ATUALIZACAO || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
IF pCAD_PRO_ID_PROFISSIONAL IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_PRO_ID_PROFISSIONAL = ' || pCAD_PRO_ID_PROFISSIONAL; END IF;
IF pTIS_CBO_CD_CBOS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_CBO_CD_CBOS = ' || CHR(39) || pTIS_CBO_CD_CBOS || CHR(39); END IF;
IF pATD_IEP_DIAGNOSTICO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_DIAGNOSTICO = ' || CHR(39) || pATD_IEP_DIAGNOSTICO || CHR(39); END IF;
IF pATD_IEP_ANTECEDENTES IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_ANTECEDENTES = ' || CHR(39) || pATD_IEP_ANTECEDENTES || CHR(39); END IF;
IF pATD_IEP_ALERGIAS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_ALERGIAS = ' || CHR(39) || pATD_IEP_ALERGIAS || CHR(39); END IF;
IF pATD_IEP_ANTIBIOTICOS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_ANTIBIOTICOS = ' || CHR(39) || pATD_IEP_ANTIBIOTICOS || CHR(39); END IF;
IF pATD_IEP_PROTOCOLOS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_PROTOCOLOS = ' || CHR(39) || pATD_IEP_PROTOCOLOS || CHR(39); END IF;
IF pATD_IEP_EXAME_FIS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_EXAME_FIS = ' || CHR(39) || pATD_IEP_EXAME_FIS || CHR(39); END IF;
IF pATD_IEP_APLANOTER IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_APLANOTER = ' || CHR(39) || pATD_IEP_APLANOTER || CHR(39); END IF;
IF pATD_IEP_INTERCONS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_INTERCONS = ' || CHR(39) || pATD_IEP_INTERCONS || CHR(39); END IF;
IF pATD_IEP_OBS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_OBS = ' || CHR(39) || pATD_IEP_OBS || CHR(39); END IF;
IF pATD_IEP_HISTOR_MOL_ATU IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_HISTOR_MOL_ATU = ' || CHR(39) || pATD_IEP_HISTOR_MOL_ATU || CHR(39); END IF;
IF pATD_IEP_EXA_LAB_IMAG IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_EXA_LAB_IMAG = ' || CHR(39) || pATD_IEP_EXA_LAB_IMAG || CHR(39); END IF;
IF pATD_IEP_FL_STATUS_EVOLUCAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_FL_STATUS_EVOLUCAO = ' || CHR(39) || pATD_IEP_FL_STATUS_EVOLUCAO || CHR(39); END IF;
IF pATD_IEP_IMPRESSAO_CLINICA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_IMPRESSAO_CLINICA = ' || CHR(39) || pATD_IEP_IMPRESSAO_CLINICA || CHR(39); END IF;

IF pATD_IEP_DS_ADMISSAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_DS_ADMISSAO = ' || CHR(39) || pATD_IEP_DS_ADMISSAO || CHR(39); END IF;
--IF pATD_IEP_DS_EVOLUCAO_CLOB IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_DS_EVOLUCAO_CLOB = ' || CHR(39) || pATD_IEP_DS_EVOLUCAO_CLOB || CHR(39); END IF;

IF  pATD_IEP_INTERCORRENCIA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_INTERCORRENCIA = ' || CHR(39) ||   pATD_IEP_INTERCORRENCIA || CHR(39); END IF;
IF pATD_IEP_MED_USO_CONTINUO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_MED_USO_CONTINUO = ' || CHR(39) || pATD_IEP_MED_USO_CONTINUO || CHR(39); END IF;

IF pATD_IDR_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IDR_ID = ' || pATD_IDR_ID; END IF;

IF pATD_IEP_RN_DIAG_PATMAT IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_RN_DIAG_PATMAT = ' || CHR(39) || pATD_IEP_RN_DIAG_PATMAT || CHR(39); END IF;
IF pATD_IEP_RN_CONTR_TRIAG IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_RN_CONTR_TRIAG = ' || CHR(39) || pATD_IEP_RN_CONTR_TRIAG || CHR(39); END IF;
IF pATD_IEP_RN_EXAMF_PEND_ORI IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_RN_EXAMF_PEND_ORI = ' || CHR(39) || pATD_IEP_RN_EXAMF_PEND_ORI || CHR(39); END IF;

IF pATD_IEP_ALERTA_EXAMES IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_ALERTA_EXAMES = ' || CHR(39) || pATD_IEP_ALERTA_EXAMES || CHR(39); END IF;
IF pATD_IEP_SCIH IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_IEP_SCIH = ' || CHR(39) || pATD_IEP_SCIH || CHR(39); END IF;

   V_SELECT := '
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
        ATD_IEP_RN_DIAG_PATMAT,
        ATD_IEP_RN_CONTR_TRIAG,
        ATD_IEP_RN_EXAMF_PEND_ORI,
        ATD_IEP_ALERTA_EXAMES,
        ATD_IEP_SCIH

FROM TB_ATD_IEP_INT_EVOL_PACIENTE
WHERE null is null  '    ;

OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_ATD_IEP_INT_EVOL_PAC_L;
/
