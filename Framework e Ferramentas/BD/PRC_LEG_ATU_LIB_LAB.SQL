CREATE OR REPLACE PROCEDURE SGS.PRC_LEG_ATU_LIB_LAB(pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE) is
  /***********************************************************************************
  * Procedure: PRC_LEG_ATU_LIB_LAB
  * Data Criacao:  20/09/2010   Por: RAMIRO
  * Funcao: INCLUIR O ATENDIMENTO DE LABORAT. NA TABELA DO SGS TB_ATD_ATE_ATENDIMENTO
  ************************************************************************************/

  v_contador number;
  ex_atendinexistente exception;
  v_DATEXA                       date;
  v_HOREXA                       number(4);
  v_CODPAD                       varchar2(3);
  v_ASS_PAP_FL_CARATER_SOLIC     char(1);
  v_DS_IND_CLINICA               varchar2(50);
  v_ASS_PAP_DS_OBSERVACAO        varchar2(100);
  v_CAD_LAT_ID_LOCAL_ATENDIMENTO number;
  v_CAD_UNI_ID_UNIDADE           number;
  v_CODESPMED                    varchar2(5);
  v_CAD_SET_ID                   number;
  v_CAD_PRO_ID_PROFISSIONAL      number;
  v_ATD_ATE_NR_CONSELHO_SOLIC    varchar2(15);
  v_ATD_ATE_CD_UFCONSELHO_SOLIC  varchar2(2);
  v_CANCELADO                    char(1);
  v_CPR_CD_CONSELHOPROF_SOLIC    varchar2(7);
  v_CAD_PAC_ID_PACIENTE          number;
  v_CAD_CNV_ID_CONVENIO          number;
  v_CAD_PLA_ID_PLANO             number;
  v_CAD_PAC_CD_CREDENCIAL        varchar2(20);

BEGIN

  BEGIN
    SELECT count(*)
      INTO v_contador
      FROM TB_ASS_PAP_PAC_ATEN_PROC LIB
     WHERE LIB.ATD_ATE_ID = pATD_ATE_ID;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      v_contador := 0;
  END;

  IF v_contador > 0 THEN

    BEGIN
      SELECT EXA.DATEXA "DT_ATEND",
             EXA.HOREXA "HR_ATEND",
             LIB.CODPAD "CODPAC",
             LIB.ASS_PAP_FL_CARATER_SOLIC "CARATER_SOLIC",
             ATE.DS_IND_CLINICA "INDCLINICA",
             LIB.ASS_PAP_DS_OBSERVACAO "OBS",
             LIB.CAD_LAT_ID_LOCAL_ATENDIMENTO "LOCAL",
             UNI.CAD_UNI_ID_UNIDADE "UNIDADE",
             CBO.TIS_CBO_CD_CBOS "ESPEC",
             DECODE(LIB.CAD_UNI_ID_UNIDADE,244,124, 
                                           245,121, 
                                           246,122, 
                                           247,123,
                                           248,1092,
                                           250,88,
                                           251,89,
                                           242,33,
                                           281,732,
                                           301,512,
                                           321,712,
                                           341,812,
                                           361,1212,
                                           381, 1672,
                                           401, 1812,
                                           461, 2132,
                                           LIB.cad_set_id_setor_liberacao) "SETOR",
             PROF.CAD_PRO_ID_PROFISSIONAL "ID_PROD",
             LIB.ATD_ATE_NR_CONSELHO_SOLIC "NR_CONS_PROF",
             LIB.ATD_ATE_CD_UFCONSELHO_SOLIC "UF_PROF",
             DECODE(EXA.CANCELADO, 'S', 'C', 'A') "STATUS",
             LIB.TIS_CPR_CD_CONSELHOPROF_SOLIC "CD_CONS_PROF",
             LIB.CAD_PAC_ID_PACIENTE "ID_PAC",
             PAC.CAD_CNV_ID_CONVENIO "CONVENIO",
             PAC.CAD_PLA_ID_PLANO "PLANO",
             PAC.CAD_PAC_CD_CREDENCIAL "CRED"
        INTO v_DATEXA,
             v_HOREXA,
             v_CODPAD,
             v_ASS_PAP_FL_CARATER_SOLIC,
             v_DS_IND_CLINICA,
             v_ASS_PAP_DS_OBSERVACAO,
             v_CAD_LAT_ID_LOCAL_ATENDIMENTO,
             v_CAD_UNI_ID_UNIDADE,
             v_CODESPMED,
             v_CAD_SET_ID,
             v_CAD_PRO_ID_PROFISSIONAL,
             v_ATD_ATE_NR_CONSELHO_SOLIC,
             v_ATD_ATE_CD_UFCONSELHO_SOLIC,
             v_CANCELADO,
             v_CPR_CD_CONSELHOPROF_SOLIC,
             v_CAD_PAC_ID_PACIENTE,
             v_CAD_CNV_ID_CONVENIO,
             v_CAD_PLA_ID_PLANO,
             v_CAD_PAC_CD_CREDENCIAL
        FROM PACIENTE_ATENDIMENTO_AMB ATE,
             SADT_PACIENTE            EXA,
             SADT_PROCEDENCIA         PROC,
             TB_ASS_PAP_PAC_ATEN_PROC LIB,
             TB_TIS_CBO_CBOS          CBO,
             TB_CAD_UNI_UNIDADE       UNI,
             TB_CAD_PRO_PROFISSIONAL  PROF,
             TB_CAD_PAC_PACIENTE      PAC
       WHERE ATE.CODATEAMB = LIB.ATD_ATE_ID
         AND ATE.CODATEAMB = EXA.CODATEAMB
         AND EXA.CD_PROCED = PROC.CD_PROCED
         AND LIB.TIS_CBO_CD_CBOS_SOLIC = CBO.TIS_CBO_CD_CBOS
         AND LIB.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
         AND LIB.ATD_ATE_NR_CONSELHO_SOLIC = PROF.CAD_PRO_NR_CONSELHO(+)
         AND LIB.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
         AND EXA.CODUNISAD = 'L'
         AND ROWNUM = 1
         AND LIB.ATD_ATE_ID = pATD_ATE_ID
       ORDER BY EXA.DATEXA;
      EXCEPTION 
        WHEN OTHERS THEN
          NULL;
    END;      
    
    BEGIN
      SELECT COUNT(*)
        INTO v_contador
        FROM TB_ATD_ATE_ATENDIMENTO ATD
       WHERE ATD.ATD_ATE_ID = pATD_ATE_ID;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        v_contador := 0;
    END;
    
    IF v_contador = 0 THEN
     
      -- INSERE ATENDIMENTO (TB_ATD_ATE_ATENDIMENTO);
      INSERT INTO TB_ATD_ATE_ATENDIMENTO
        (ATD_ATE_TP_PACIENTE,
         ATD_ATE_ID,
         ATD_ATE_DT_ATENDIMENTO,
         ATD_ATE_HR_ATENDIMENTO,
         CODPAD,
         ATD_ATE_FL_CARATER_SOLIC,
         ATD_ATE_DS_INDCLINICA,
         ATD_ATE_DS_OBSERVACAO,
         ATD_ATE_DT_ULTIMA_ATUALIZACAO,
         SEG_USU_ID_USUARIO,
         CAD_LAT_ID_LOCAL_ATENDIMENTO,
         TIS_TAT_CD_TPATENDIMENTO,
         CAD_UNI_ID_UNIDADE,
         TIS_CBO_CD_CBOS,
         TIS_CBO_CD_CBOS_SOLIC,
         CAD_SET_ID,
         CAD_UNI_ID_UNID_PROC,
         CAD_PRO_ID_PROF_EXEC,
         ATD_ATE_NR_CONSELHO_SOLIC,
         ATD_ATE_CD_UFCONSELHO_SOLIC,
         ATD_ATE_FL_STATUS,
         TIS_CPR_CD_CONSELHOPROF_SOLIC)
      values
        ('A',
         pATD_ATE_ID,
         trunc(v_DATEXA),
         v_HOREXA,
         v_CODPAD,
         v_ASS_PAP_FL_CARATER_SOLIC,
         v_DS_IND_CLINICA,
         v_ASS_PAP_DS_OBSERVACAO,
         SYSDATE,
         9362,
         v_CAD_LAT_ID_LOCAL_ATENDIMENTO,
         5,
         v_CAD_UNI_ID_UNIDADE,
         NULL, -- v_CODESPMED, -- alterado em 23/02/2017
         v_CODESPMED,
         v_CAD_SET_ID,
         v_CAD_UNI_ID_UNIDADE,
         NULL, -- v_CAD_PRO_ID_PROFISSIONAL, -- alterado em 13/02/2017
         v_ATD_ATE_NR_CONSELHO_SOLIC,
         v_ATD_ATE_CD_UFCONSELHO_SOLIC,
         v_CANCELADO,
         v_CPR_CD_CONSELHOPROF_SOLIC);
      
      -- INSERE PACIENTE DO ATENDIMENTO (TB_ASS_PAT_PACIEATEND);       
      INSERT INTO TB_ASS_PAT_PACIEATEND
        (ATD_ATE_ID,
         CAD_PAC_ID_PACIENTE,
         ASS_PAT_DT_ENTRADA,
         ASS_PAT_HR_ENTRADA,
         ASS_PAT_DT_SAIDA,
         ASS_PAT_HR_SAIDA,
         ASS_PAT_FL_STATUS,
         SEG_USU_ID_USUARIO,
         ASS_PAT_DT_ULTIMA_ATUALIZACAO,
         CAD_CNV_ID_CONVENIO,
         CAD_PLA_ID_PLANO,
         CAD_PAC_CD_CREDENCIAL,
         ASS_PAT_DS_OBSERVACAO)
      values
        (pATD_ATE_ID,
         v_CAD_PAC_ID_PACIENTE,
         trunc(v_DATEXA),
         v_HOREXA,
         trunc(v_DATEXA),
         v_HOREXA,
         v_CANCELADO,
         9362,
         SYSDATE,
         v_CAD_CNV_ID_CONVENIO,
         v_CAD_PLA_ID_PLANO,
         v_CAD_PAC_CD_CREDENCIAL,
         v_ASS_PAP_DS_OBSERVACAO);
    END IF;
  END IF;
END PRC_LEG_ATU_LIB_LAB;
 