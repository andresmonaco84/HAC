CREATE OR REPLACE PROCEDURE PRC_REP_PGM_PAGTO_MEDICO_PRM (PCAD_CLC_ID                 IN TB_REP_PGM_PAGTO_MEDICO.CAD_CLC_ID%TYPE DEFAULT NULL,
                                                         PREP_PGM_MES_PAGTO            IN INT,
                                                         PREP_PGM_ANO_PAGTO            IN INT,
                                                         PATD_ATE_DT_ATENDIMENTO_INI   IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_DT_INICIO_REALIZACAO%TYPE DEFAULT NULL,
                                                         PATD_ATE_DT_ATENDIMENTO_FIM   IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_DT_INICIO_REALIZACAO%TYPE DEFAULT NULL,
                                                         PREP_PGM_FL_PACOTE            IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_FL_PACOTE%TYPE DEFAULT NULL,
                                                         PATD_ATE_ID                   IN VARCHAR2,
                                                         PCAD_PRO_ID_PROFISSIONAL      IN VARCHAR2,
                                                         PTIS_CBO_CD_CBOS              IN VARCHAR2,
                                                         PCAD_UNI_ID_UNIDADE           IN VARCHAR2,
                                                         PCAD_LAT_ID_LOCAL_ATENDIMENTO IN VARCHAR2,
                                                         PCAD_SET_ID                   IN VARCHAR2,
                                                         PAUX_EPP_CD_ESPECPROC         IN VARCHAR2,
                                                         PAUX_CAD_PRD_ID               IN VARCHAR2,
                                                         PCAD_CNV_ID_CONVENIO          IN VARCHAR2,
                                                         PCAD_PLA_CD_TIPOPLANO         IN VARCHAR2,
                                                         pCAD_TPE_CD_CODIGO            IN VARCHAR2,
                                                         PFLAGATENDIMENTOSEMCLINICA    IN VARCHAR2,
                                                         IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  *    Procedure: PRC_REP_PGM_PAGTO_MEDICO_PRM
  *
  *    Data Criacao:  data da  criac?o   Por: Nome do Analista
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/

  V_CURSOR PKG_CURSOR.T_CURSOR;
  V_WHERE  VARCHAR2(5000);
  V_SELECT VARCHAR2(10000);
BEGIN
  V_WHERE := 'WHERE 1 = 1';
  
  IF PCAD_CLC_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_CLC_ID = ' || PCAD_CLC_ID;
  END IF;
  
  IF (PREP_PGM_MES_PAGTO IS NOT NULL) AND (PREP_PGM_ANO_PAGTO IS NOT NULL) THEN
    V_WHERE := V_WHERE || ' AND PGM.REP_PGM_MES_PAGTO = ' || PREP_PGM_MES_PAGTO;
    V_WHERE := V_WHERE || ' AND PGM.REP_PGM_ANO_PAGTO = ' || PREP_PGM_ANO_PAGTO;
  END IF;
  
  IF (PATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL) AND
     (PATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL) THEN
    V_WHERE := V_WHERE || ' AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN TO_DATE(''' || PATD_ATE_DT_ATENDIMENTO_INI || ''',''DD/MM/YYY'' )
                            AND TO_DATE(''' || PATD_ATE_DT_ATENDIMENTO_FIM || ''',''DD/MM/YYY'' )';
  END IF;
  
  IF PREP_PGM_FL_PACOTE IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.REP_PGM_FL_PACOTE = ' || PREP_PGM_FL_PACOTE;
  END IF;
  
  IF PATD_ATE_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.ATD_ATE_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PATD_ATE_ID || ''' ))) ';
  END IF;
  
  IF PCAD_PRO_ID_PROFISSIONAL IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_PRO_ID_PROFISSIONAL IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_PRO_ID_PROFISSIONAL || ''' ))) ';
  END IF;
  
  IF PTIS_CBO_CD_CBOS IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.TIS_CBO_CD_CBOS IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PTIS_CBO_CD_CBOS || ''' ))) ';
  END IF;
  
  IF PCAD_UNI_ID_UNIDADE IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_UNI_ID_UNIDADE || ''' ))) ';
  END IF;
  
  IF PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_LAT_ID_LOCAL_ATENDIMENTO || ''' ))) ';
  END IF;
  
  IF PCAD_SET_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_SET_ID_REALIZACAO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_SET_ID || ''' ))) ';
  END IF;
  
  IF PAUX_EPP_CD_ESPECPROC IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.AUX_EPP_CD_ESPECPROC IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PAUX_EPP_CD_ESPECPROC || ''' ))) ';
  END IF;
  
  IF PAUX_CAD_PRD_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_PRD_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PAUX_CAD_PRD_ID || ''' ))) ';
  END IF;
  
  IF PCAD_CNV_ID_CONVENIO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_CNV_ID_CONVENIO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_CNV_ID_CONVENIO || ''' ))) ';
  END IF;
  
  IF PCAD_PLA_CD_TIPOPLANO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_PLA_CD_TIPOPLANO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_PLA_CD_TIPOPLANO || ''' ))) ';
  END IF;
  
  IF PCAD_TPE_CD_CODIGO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_TPE_CD_CODIGO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_TPE_CD_CODIGO || ''' ))) ';
  END IF;
  
  IF PFLAGATENDIMENTOSEMCLINICA = 'S' THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_CLC_ID IS NULL ';
  END IF;
  
  V_SELECT := 'SELECT PGM.ATD_ATE_ID,
                      PGM.FAT_CCP_ID,
                      PGM.FAT_COC_ID,
                      PGM.CAD_TAP_TP_ATRIBUTO,
                      PGM.CAD_PRD_ID,
                      PGM.CAD_TIH_TP_INDICE_HOSP,
                      PGM.REP_PGM_QT_INDICE,
                      PGM.REP_PGM_VL_INDICE,
                      PGM.REP_PGM_VL_UNITARIO,
                      PGM.REP_PGM_DT_INICIO_REALIZACAO,
                      PGM.REP_PGM_HR_INICIO_REALIZACAO,
                      PGM.REP_PGM_VL_FATURADO,
                      PGM.REP_PGM_QT_CONSUMO,
                      PGM.CAD_PRO_ID_PROFISSIONAL,
                      PGM.REP_PGM_PC_GRAU_PART_PROF,
                      PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO,
                      PGM.REP_PGM_VL_CALCULADO,
                      PGM.CAD_PAC_ID_PACIENTE,
                      PGM.REP_PGM_TP_CREDENCIA_PROF,
                      PGM.REP_PGM_FL_PACOTE,
                      PGM.CAD_CEC_ID_CCUSTO,
                      PGM.CAD_CAC_ID_CLASSCONTABIL,
                      PGM.REP_PGM_MES_FECHAMENTO,
                      PGM.REP_PGM_ANO_FECHAMENTO,
                      PGM.SEG_USU_ID_USUARIO_CRIACAO,
                      PGM.REP_PGM_DT_CRIACAO,
                      PGM.REP_PGM_MES_PAGTO,
                      PGM.REP_PGM_ANO_PAGTO,
                      PGM.REP_PGM_FL_PAGO,
                      PGM.REP_PGM_DT_PAGAMENTO,
                      PGM.CAD_UNI_ID_UNIDADE,
                      PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                      PGM.CAD_UNI_ID_UNIDADE_PAGTO,
                      PGM.REP_PGM_FL_STATUS,
                      PGM.REP_PGM_CD_ORIGEM,
                      PGM.REP_PGM_ID,
                      PGM.CAD_SET_ID_REALIZACAO,
                      PGM.CAD_SET_ID_MOVIMENTACAO,
                      PGM.FAT_CCI_PC_ACOMODACAO_HM,
                      PGM.REP_PGM_CD_JUSTIFICATIVA,
                      PGM.SEG_USU_ID_USUARIO_ATUALIZ,
                      PGM.CAD_CNV_ID_CONVENIO,
                      PGM.CAD_CLC_ID,
                      PGM.CAD_REP_VL_PAGTO_EXTRA,
                      PGM.CAD_PLA_CD_TIPOPLANO,
                      PGM.AUX_EPP_CD_ESPECPROC,
                      PGM.TIS_MED_CD_TABELAMEDICA,
                      PGM.REP_PGM_VL_PAGO,
                      PGM.AUX_GPC_CD_GRUPOPROC,
                      PGM.TIS_TAC_CD_TIPO_ACOMOD_AUT,
                      PGM.REP_RPA_ID,
                      PGM.FAT_CCI_ID,
                      PGM.REP_PGM_FL_ATENDIMENTO_RETORNO,
                      PGM.REP_PGM_QT_CUSTO_OPER,
                      PGM.REP_PGM_QT_HONORARIO,
                      PGM.CAD_TPE_CD_CODIGO,
                      PGM.TIS_CBO_CD_CBOS,
                      PGM.ASS_RPG_ID,
                      PGM.REP_PPC_ID,

                      PRO.CAD_PRO_ID_PROFISSIONAL,
                      PRO.CAD_PRO_NM_NOME,
                      PRO.CAD_PRO_NR_CONSELHO,
                      PRO.CAD_PRO_CD_COD_PRO,
                      PRO.TIS_CPR_CD_CONSELHOPROF,

                      CBOS.TIS_CBO_DS_CBOS_HAC ESPECIALIDADE_PROF,

                      CLC.CAD_CLC_ID,
                      CLC.CAD_CLC_CD_CLINICA,
                      CLC.CAD_CLC_DS_DESCRICAO,

                      USU.SEG_USU_DS_NOME,
                      USU1.SEG_USU_DS_NOME AS SEG_USU_DS_NOME_ATUALIZA,

                      CAC.CAD_CAC_DS_CLASSCONTABIL,

                      UNI.CAD_UNI_DS_UNIDADE,
                      UNI.CAD_UNI_ID_UNIDADE,

                      LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,

                      SETO.CAD_SET_DS_SETOR,
                      SETO1.CAD_SET_DS_SETOR AS CAD_SET_DS_SETOR_MOV,

                      PAC.CAD_PAC_ID_PACIENTE,
                      PES.CAD_PES_NM_PESSOA CAD_PAC_NM_TITULAR,

                      CNV.CAD_CNV_NM_FANTASIA,

                      MED.TIS_MED_DS_TABELAMEDICA,
                      EPP.AUX_EPP_DS_DESCRICAO,
                      GPC.AUX_GPC_DS_DESCRICAO,

                      DECODE(TAC.TIS_TAC_PC_ACOMODACAO_HM,NULL,0),

                      PRD.CAD_PRD_CD_CODIGO,
                      PRD.CAD_PRD_DS_DESCRICAO,

                      JPG.CAD_JPG_DS_JUSTIFICATIVA

                 FROM TB_REP_PGM_PAGTO_MEDICO PGM

                 LEFT JOIN TB_CAD_CLC_CLINICA_CREDENCIADA CLC ON PGM.CAD_CLC_ID = CLC.CAD_CLC_ID

                INNER JOIN TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
                INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO

                INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO ON PGM.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
                 LEFT JOIN TB_TIS_CBO_CBOS CBOS ON PGM.TIS_CBO_CD_CBOS = CBOS.TIS_CBO_CD_CBOS

                INNER JOIN TB_CAD_SET_SETOR SETO ON SETO.CAD_SET_ID = PGM.CAD_SET_ID_REALIZACAO
                 LEFT JOIN TB_CAD_SET_SETOR SETO1 ON SETO1.CAD_SET_ID = PGM.CAD_SET_ID_MOVIMENTACAO

                INNER JOIN TB_SEG_USU_USUARIO USU ON USU.SEG_USU_ID_USUARIO = PGM.SEG_USU_ID_USUARIO_CRIACAO
                 LEFT JOIN TB_SEG_USU_USUARIO USU1 ON USU1.SEG_USU_ID_USUARIO = PGM.SEG_USU_ID_USUARIO_ATUALIZ

                INNER JOIN TB_CAD_CNV_CONVENIO CNV ON CNV.CAD_CNV_ID_CONVENIO = PGM.CAD_CNV_ID_CONVENIO

                 LEFT JOIN TB_TIS_MED_TABELAMEDICA MED ON MED.TIS_MED_CD_TABELAMEDICA = PGM.TIS_MED_CD_TABELAMEDICA

                 LEFT JOIN TB_AUX_EPP_ESPECPROC EPP ON EPP.AUX_EPP_CD_ESPECPROC = PGM.AUX_EPP_CD_ESPECPROC AND EPP.TIS_MED_CD_TABELAMEDICA = PGM.TIS_MED_CD_TABELAMEDICA

                 LEFT JOIN TB_AUX_GPC_GRUPOPROC GPC ON GPC.AUX_GPC_CD_GRUPOPROC = PGM.AUX_GPC_CD_GRUPOPROC  AND GPC.AUX_EPP_CD_ESPECPROC = PGM.AUX_EPP_CD_ESPECPROC AND GPC.TIS_MED_CD_TABELAMEDICA = PGM.TIS_MED_CD_TABELAMEDICA

                INNER JOIN TB_CAD_PRD_PRODUTO PRD ON PGM.CAD_PRD_ID = PRD.CAD_PRD_ID 

                  AND PRD.TIS_MED_CD_TABELAMEDICA = MED.TIS_MED_CD_TABELAMEDICA 
                  AND PRD.AUX_EPP_CD_ESPECPROC = EPP.AUX_EPP_CD_ESPECPROC
                  AND PRD.AUX_GPC_CD_GRUPOPROC = GPC.AUX_GPC_CD_GRUPOPROC

                 LEFT JOIN TB_TIS_TAC_TIPO_ACOMODACAO TAC ON TAC.TIS_TAC_CD_TIPO_ACOMODACAO = PGM.TIS_TAC_CD_TIPO_ACOMOD_AUT

                INNER JOIN TB_CAD_TPE_TIPOEMPRESA TPE ON TPE.CAD_TPE_CD_CODIGO = PGM.CAD_TPE_CD_CODIGO

                 LEFT JOIN TB_CAD_JPG_JUSTIFICA_PAGTO JPG ON JPG.ID_CAD_JPG = PGM.REP_PGM_CD_JUSTIFICATIVA

                INNER JOIN TB_CAD_PAC_PACIENTE PAC ON PGM.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE

                 LEFT JOIN TB_CAD_CEC_CENTRO_CUSTO CEC ON PGM.CAD_CEC_ID_CCUSTO = CEC.CAD_CEC_ID_CCUSTO

                 LEFT JOIN TB_CAD_CAC_CLASSIF_CONTAB CAC ON PGM.CAD_CAC_ID_CLASSCONTABIL = CAC.CAD_CAC_ID_CLASSCONTABIL

                INNER JOIN TB_CAD_PES_PESSOA PES ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA  ';

  V_SELECT := V_SELECT || V_WHERE;

--  DBMS_OUTPUT.put_line(V_SELECT);

  OPEN V_CURSOR FOR V_SELECT;
  IO_CURSOR := V_CURSOR;

END PRC_REP_PGM_PAGTO_MEDICO_PRM;
