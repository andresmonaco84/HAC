CREATE OR REPLACE PROCEDURE "PRC_LEG_ATU_INT" (pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE) is
  /*******************************************************************************
  * Procedure: PRC_LEG_ATU_INT
  * Data Criacao:  19/07/2010   Por: RAMIRO
  * Funcao: INCLUIR A INTERNAC?O DO SGS NA TABELA DO LEGADO HOSPITAL.TB_INTERNADO
  ********************************************************************************/
  v_contador number;
  ex_atendinexistente exception;
  v_cd_convenio_leg    varchar2(4);
  v_codest             number;
  v_codben             number;
  v_id_usuario         number;
  v_cd_unid_hospitalar number;
  v_nr_prontuario      number;
  v_dt_atendimento     date;
  v_hr_atendimento     varchar2(4);
  v_dt_nascimento      date;
  v_tp_sexo            varchar2(1);
  v_nm_pessoa          varchar2(52);
  v_codpad             varchar2(3);
  v_codtippad          char(1);
  v_carater_solicit    varchar2(2);
  v_trat               number;
  v_cd_alta            number;
  v_nr_conselho_plant  number;
  v_nr_conselho_resp   number;
  v_tipo_atendimento   varchar(2);
  v_ds_contato         varchar(200);
  v_cd_credencial      varchar2(30);
  v_diag               varchar2(150);
  v_codseqben          varchar2(2);
  v_nr_rg              varchar2(10);
  v_dt_validade_cred   date;
  v_nome_emp           varchar2(35);
  v_nome_plano         varchar2(35);
  v_codespmed          varchar2(3);
  v_dt_transacao       date;
  v_tp_transacao       char(1);
  v_ds_proced          varchar2(150);
  v_subproduto         varchar2(10);
  v_nr_cns             varchar2(15);
  v_cd_ind_acidente    number;
  v_tipo_int           number;
  v_regime_int         char(1);
  v_diaria_sol         number;
  v_cid10              varchar2(5);
  v_tipo_anterior      varchar(2);
  v_dt_int_anterior    date;
  v_hr_int_anterior    number(4);

  v_LOCAL              number(4); --HOMECARE
  v_dt_saida           date; --HOMECARE
  v_hr_saida           varchar2(4); --HOMECARE
  v_nr_conselho_saida  number;--HOMECARE
  v_id_usuario_SAIDA   number; --HOMECARE
BEGIN
  SELECT COUNT(*)
    INTO v_contador
    FROM TB_ATD_ATE_ATENDIMENTO ATD
   WHERE ATD.ATD_ATE_ID = pATD_ATE_ID;
  IF v_contador = 0 THEN
    raise ex_atendinexistente;
  ELSE
    SELECT CASE
             WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'SP' AND
                  CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SX73' AND
                  PLA.CAD_PLA_CD_PLANO_HAC IN ('SKIDO', 'SKIPA') THEN
              'SX94'
             WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'SP' THEN
              SUBSTR(cnv.cad_cnv_cd_hac_prestador, 1, 4)
             WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'GB' THEN
              PLA.CAD_PLA_CD_PLANO_HAC
             WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PL' THEN
              PLA.CAD_PLA_CD_PLANO_HAC
             WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN
              SUBSTR(cnv.cad_cnv_cd_hac_prestador, 1, 4)
             WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'FU' THEN
              PLA.CAD_PLA_CD_PLANO_HAC
             ELSE
              SUBSTR(cnv.cad_cnv_cd_hac_prestador, 1, 4)
           END "CODCON",
           CASE
             WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' OR
                  CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN
              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3)
             ELSE
              NULL
           END "CODEST",
           CASE
             WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' OR
                  CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN
              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7)
             ELSE
              NULL
           END "CODBEN",
           USU.SEG_USU_ID_USUARIO "CD_MATRICULA",
           TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR, '99') "CODUNIHOS",
           decode(PAC.CAD_PAC_NR_PRONTUARIO,
                  null,
                  7,
                  PAC.CAD_PAC_NR_PRONTUARIO) "CODPAC",
           TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO) "DT_INT",
           LPAD(TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO), 4, '0') "HORA_INT",
           TRUNC(PES.CAD_PES_DT_NASCIMENTO) "DATNASPAC",
           PES.CAD_PES_TP_SEXO "SEXPAC",
           SUBSTR(PES.CAD_PES_NM_PESSOA, 0, 52) "NOMPAC",
           DECODE(ATD.ATD_ATE_TP_PACIENTE, 'E', 'BAS', ATD.CODPAD) "CODPAD",
           'A' "CODTIPPAD",
           DECODE(ATD_ATE_FL_CARATER_SOLIC, 'E', 1, 'U', 3, 1) "CD_TIPO_INT",
           ATC.TIS_TIN_CD_INTERNACAO "CD_TRAT_PRO",
           DECODE(ATD.ATD_ATE_FL_STATUS,
                  'C',
                  1000,
                  DECODE(ATD.ATD_ATE_TP_PACIENTE, 'E', 12, 999)) "CD_ALTA",
           TRIM(PRO1.CAD_PRO_NR_CONSELHO) "CRM_RESP",
           TRIM(DECODE(ATD.ATD_ATE_NR_CONSELHO_SOLIC,
                       NULL,
                       PRO.CAD_PRO_NR_CONSELHO,
                       ATD.ATD_ATE_NR_CONSELHO_SOLIC)) "CRM_RESP",
           ATD.ATD_ATE_TP_PACIENTE "IN_INT_EXT",
           ATC.ATD_AIC_DS_CONTATO "AVISAR",
           PAC.CAD_PAC_CD_CREDENCIAL "CRED",
           substr(TRIM(CID.CAD_CID_DS_CID10), 0, 150) "DIAG_E",
           CASE
             WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' OR
                  CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN
              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)
             ELSE
              NULL
           END "CODSEQDEP",
           SUBSTR(TRIM(PES.CAD_PES_NR_RG), 0, 10) "RG",
           PAC.CAD_PAC_DT_VALIDADECREDENCIAL "DT_VALIDADE_CRED",
           SUBSTR(PES.CAD_PES_NM_RAZAOSOCIAL, 0, 035) "CRED_EMP",
           SUBSTR(PLA.CAD_PLA_NM_NOME_PLANO, 0, 30) "TP_PLANO",
           DECODE(CBO.TIS_CBO_CD_CBOS_HAC,
                  'ENF',
                  'CLI',
                  'ATE',
                  'CLI',
                  CBO.TIS_CBO_CD_CBOS_HAC) "ESP_MEDICO",
           SYSDATE "DT_TRANSACAO",
           'I' "TP_TRANSACAO",
           substr(PRD.CAD_PRD_DS_DESCRICAO, 0, 150) "DS_PROCED",
           DECODE(PAC.CAD_PAC_CD_SUBPLANO,
                  NULL,
                  PLA.CAD_PLA_CD_PLANO_HAC,
                  PAC.CAD_PAC_CD_SUBPLANO) "SUBPRODUTO",
         --  PAC.CAD_PAC_CD_CNS "NR_CNS",
           ATD.TIS_IAC_CD_INDACIDENTE "CD_ID_ACIDENTE",
           ATC.TIS_TIN_CD_INTERNACAO "CD_TP_INTERNACAO",
           ATC.TIS_TRI_CD_REGINTENNACAO "CD_REGIME_INTERNACAO",
           NULL "QTD_DIARIA_SOL", --ATC.ATD_AIC_QT_DIARIA_SOLICITADA
           TRIM(ATD.CAD_CID_CD_CID10) "CD_CID10_PRINC",
           LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
      INTO v_cd_convenio_leg,
           v_codest,
           v_codben,
           v_id_usuario,
           v_cd_unid_hospitalar,
           v_nr_prontuario,
           v_dt_atendimento,
           v_hr_atendimento,
           v_dt_nascimento,
           v_tp_sexo,
           v_nm_pessoa,
           v_codpad,
           v_codtippad,
           v_carater_solicit,
           v_trat,
           v_cd_alta,
           v_nr_conselho_plant,
           v_nr_conselho_resp,
           v_tipo_atendimento,
           v_ds_contato,
           v_cd_credencial,
           v_diag,
           v_codseqben,
           v_nr_rg,
           v_dt_validade_cred,
           v_nome_emp,
           v_nome_plano,
           v_codespmed,
           v_dt_transacao,
           v_tp_transacao,
           v_ds_proced,
           v_subproduto,
         --  v_nr_cns,
           v_cd_ind_acidente,
           v_tipo_int,
           v_regime_int,
           v_diaria_sol,
           v_cid10,
           v_LOCAL
      FROM TB_ATD_ATE_ATENDIMENTO ATD,
           TB_CAD_UNI_UNIDADE UNI,
           TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
           TB_CAD_PRO_PROFISSIONAL PRO,
           TB_CAD_PRO_PROFISSIONAL PRO1,
           TB_CAD_PAC_PACIENTE PAC,
           TB_CAD_CNV_CONVENIO CNV,
           TB_CAD_PLA_PLANO PLA,
           TB_CAD_PES_PESSOA PES,
           TB_TIS_CBO_CBOS CBO,
           TB_CAD_SET_SETOR SETOR,
           TB_ASS_PAT_PACIEATEND PAT,
           TB_SEG_USU_USUARIO USU,
           TB_ATD_AIC_ATE_INT_COMPL ATC,
           TB_CAD_PRD_PRODUTO PRD,
           TB_CAD_CID_CID10 CID,
           (SELECT ATD.ATD_ATE_ID, BNF.CODGRAPAR CODGRAPAR
              FROM TB_ATD_ATE_ATENDIMENTO        ATD,
                   TB_CAD_PAC_PACIENTE           PAC,
                   TB_CAD_CNV_CONVENIO           CNV,
                   TB_CAD_PLA_PLANO              PLA,
                   TB_ASS_PAT_PACIEATEND         PAT,
                   BENEFICIARIO.BNF_BENEFICIARIO BNF
             WHERE PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
               AND PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
               AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
               AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
               AND BNF.CODCON = PLA.CAD_PLA_CD_PLANO_HAC
               AND BNF.CODEST =
                   TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3))
               AND BNF.CODBEN =
                   TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7))
               AND BNF.CODSEQBEN =
                   TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2))
               AND ATD.ATD_ATE_ID = pATD_ATE_ID
               AND TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO) =
                   TRUNC(PAT.ASS_PAT_DT_ENTRADA)
               AND (CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' OR
                   CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05')) BENEF_ACS
     WHERE ATD.ATD_ATE_ID = pATD_ATE_ID
       AND PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
       AND PAT.ASS_PAT_DT_ENTRADA = ATD.ATD_ATE_DT_ATENDIMENTO
       AND PAT.ASS_PAT_HR_ENTRADA = ATD.ATD_ATE_HR_ATENDIMENTO
       AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO) =
           TRUNC(PAT.ASS_PAT_DT_ENTRADA)
       AND ATD.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
       AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
       AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
       AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND ATD.ATD_ATE_ID = BENEF_ACS.ATD_ATE_ID(+)
       AND ATD.CAD_PRO_ID_PROF_EXEC = PRO.CAD_PRO_ID_PROFISSIONAL(+)
       AND ATC.CAD_PRO_ID_PROF_ADM = PRO1.CAD_PRO_ID_PROFISSIONAL(+)
       AND ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO =
           LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
       AND ATD.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
       AND ATD.CAD_SET_ID = SETOR.CAD_SET_ID
       AND USU.SEG_USU_ID_USUARIO = ATD.SEG_USU_ID_USUARIO
       AND ATD.ATD_ATE_ID = ATC.ATD_ATE_ID
       AND ATC.CAD_PRD_ID = PRD.CAD_PRD_ID(+)
       AND ATD.CAD_CID_CD_CID10 = CID.CAD_CID_CD_CID10(+);
    IF v_codpad IS NULL THEN
      v_codpad := 'BAS';
    END IF;
  END IF;
  SELECT COUNT(*)
    INTO v_contador
    FROM HOSPITAL.TB_INTERNADO
   WHERE NR_SEQINTER = pATD_ATE_ID;
  IF v_contador = 0 THEN
    INSERT INTO HOSPITAL.TB_INTERNADO
      (NR_SEQINTER,
       CODHOS,
       CODCON,
       CODEST,
       CODBEN,
       CD_MATRICULA,
       CODUNIHOS,
       CODPAC,
       DT_INT,
       HORA_INT,
       DATNASPAC,
       SEXPAC,
       NOMPAC,
       CODPAD,
       CODTIPPAD,
       CD_TIPO_INT,
       CD_TRAT_PRO,
       CD_ALTA,
       CRM_PLANT,
       CRM_RESP,
       IN_INT_EXT,
       DT_ALTA,
       HORA_ALTA,
       CRM_ALTA,
       CD_MATRICULA_ALTA,
       AVISAR,
       CRED,
       DIAG_E,
       CODSEQDEP,
       RG,
       DT_VALIDADE_CRED,
       CRED_EMP,
       TP_PLANO,
       ESP_MEDICO,
       DT_TRANSACAO,
       TP_TRANSACAO,
       DS_PROCED,
       SUBPRODUTO,
       IN_GESTANTE,
       CD_MOTIVO_INT_REF,
       NR_SEQINTER_REF,
     --  NR_CNS,
       CD_ID_ACIDENTE,
       CD_TP_INTERNACAO,
       CD_REGIME_INTERNACAO,
       QT_DIARIA_SOL,
       CD_CID10_PRINC)
    values
      (pATD_ATE_ID,
       1,
       v_cd_convenio_leg,
       v_codest,
       v_codben,
       v_id_usuario,
       v_cd_unid_hospitalar,
       v_nr_prontuario,
       v_dt_atendimento,
       v_hr_atendimento,
       v_dt_nascimento,
       v_tp_sexo,
       v_nm_pessoa,
       v_codpad,
       v_codtippad,
       v_carater_solicit,
       v_trat,
       v_cd_alta,--
       v_nr_conselho_plant,
       v_nr_conselho_resp,
       v_tipo_atendimento,
       decode(v_tipo_atendimento, 'E', v_dt_atendimento, NULL),
       decode(v_tipo_atendimento, 'E', v_hr_atendimento, NULL),
       decode(v_tipo_atendimento, 'E', v_nr_conselho_resp, NULL),
       decode(v_tipo_atendimento, 'E', v_id_usuario, NULL),
       v_ds_contato,
       v_cd_credencial,
       v_diag,
       v_codseqben,
       v_nr_rg,
       v_dt_validade_cred,
       v_nome_emp,
       v_nome_plano,
       v_codespmed,
       v_dt_transacao,
       v_tp_transacao,
       v_ds_proced,
       v_subproduto,
       null,
       null,
       null,
      -- v_nr_cns,
       v_cd_ind_acidente,
       v_tipo_int,
       v_regime_int,
       v_diaria_sol,
       v_cid10);
  ELSE
    SELECT IN_INT_EXT, DT_INT, HORA_INT
      INTO v_tipo_anterior, v_dt_int_anterior, v_hr_int_anterior
      FROM HOSPITAL.TB_INTERNADO
     WHERE NR_SEQINTER = pATD_ATE_ID;
    UPDATE HOSPITAL.TB_INTERNADO
       SET CODHOS               = 1,
           CODCON               = v_cd_convenio_leg,
           CODEST               = v_codest,
           CODBEN               = v_codben,
           CD_MATRICULA         = v_id_usuario,
           CODUNIHOS            = v_cd_unid_hospitalar,
           CODPAC               = v_nr_prontuario,
           DT_INT               = v_dt_atendimento,
           HORA_INT             = v_hr_atendimento,
           DATNASPAC            = v_dt_nascimento,
           SEXPAC               = v_tp_sexo,
           NOMPAC               = v_nm_pessoa,
           CODPAD               = v_codpad,
           CODTIPPAD            = v_codtippad,
           CD_TIPO_INT          = v_carater_solicit,
           CD_ALTA              = v_cd_alta,
           DT_ALTA              = decode(v_tipo_atendimento,
                                         'E',
                                         v_dt_atendimento,
                                         NULL),
           HORA_ALTA            = decode(v_tipo_atendimento,
                                         'E',
                                         v_hr_atendimento,
                                         NULL),
           CRM_ALTA             = decode(v_tipo_atendimento,
                                         'E',
                                         v_nr_conselho_resp,
                                         NULL),
           CD_MATRICULA_ALTA    = decode(v_tipo_atendimento,
                                         'E',
                                         v_id_usuario,
                                         NULL),
           CD_TRAT_PRO          = v_trat,
           CRM_PLANT            = v_nr_conselho_plant,
           CRM_RESP             = v_nr_conselho_resp,
           IN_INT_EXT           = v_tipo_atendimento,
           AVISAR               = v_ds_contato,
           CRED                 = v_cd_credencial,
           DIAG_E               = v_diag,
           CODSEQDEP            = v_codseqben,
           RG                   = v_nr_rg,
           DT_VALIDADE_CRED     = v_dt_validade_cred,
           CRED_EMP             = v_nome_emp,
           TP_PLANO             = v_nome_plano,
           ESP_MEDICO           = v_codespmed,
           DT_TRANSACAO         = v_dt_transacao,
           TP_TRANSACAO         = v_tp_transacao,
           DS_PROCED            = v_ds_proced,
           SUBPRODUTO           = v_subproduto,
           IN_GESTANTE          = null,
           CD_MOTIVO_INT_REF    = null,
           NR_SEQINTER_REF      = null,
          -- NR_CNS               = v_nr_cns,
           CD_ID_ACIDENTE       = v_cd_ind_acidente,
           CD_TP_INTERNACAO     = v_tipo_int,
           CD_REGIME_INTERNACAO = v_regime_int,
           QT_DIARIA_SOL        = v_diaria_sol,
           CD_CID10_PRINC       = v_cid10
     WHERE NR_SEQINTER = pATD_ATE_ID;
  END IF;
  -- 07/01/2011 Cristiane Gomes
  -- VERIFICA SE HOUVE ALTERACAO NA DATA/HORA DE INTERNACAO
  IF (v_dt_int_anterior != v_dt_atendimento) OR
     (v_hr_int_anterior != v_hr_atendimento) THEN
    IF v_tipo_atendimento = 'E' THEN
      UPDATE HOSPITAL.TB_TRANSFERENCIA
         SET DT_ENTRADA = v_dt_atendimento,
             HORA_ENT   = v_hr_atendimento,
             DT_SAIDA   = v_dt_atendimento,
             HORA_SAIDA = v_hr_atendimento
       WHERE NR_SEQINTER = pATD_ATE_ID
         AND DT_ENTRADA = v_dt_int_anterior
         AND HORA_ENT = v_hr_int_anterior;
    ELSE
      UPDATE HOSPITAL.TB_TRANSFERENCIA
         SET DT_ENTRADA = v_dt_atendimento, HORA_ENT = v_hr_atendimento
       WHERE NR_SEQINTER = pATD_ATE_ID
         AND DT_ENTRADA = v_dt_int_anterior
         AND HORA_ENT = v_hr_int_anterior;
    END IF;
  ELSE
    -- 23/12/2010 Ramiro Ribeiro
 IF v_tipo_atendimento = 'I' AND V_LOCAL = 46 THEN --HOME CARE

      SELECT COUNT(*)
        INTO v_contador
        FROM HOSPITAL.TB_TRANSFERENCIA
       WHERE NR_SEQINTER = pATD_ATE_ID;

      IF v_contador = 0 THEN
        INSERT INTO HOSPITAL.TB_TRANSFERENCIA
          (NR_SEQINTER,
           CODHOS,
           CODUNIHOS,
           COD_QUARTO,
           COD_LEITO,
           ACORDO,
           DT_ENTRADA,
           DT_SAIDA,
           HORA_ENT,
           HORA_SAIDA,
           CD_MATRICULA,
           DT_TRANSACAO,
           TP_TRANSACAO,
           IN_CANCELADO)
        values
          (pATD_ATE_ID,
           1,
           v_cd_unid_hospitalar,
           100,
           decode(v_cd_unid_hospitalar, 2, 1, v_cd_unid_hospitalar),
           v_codpad,
           v_dt_atendimento,
           NULL,
           v_hr_atendimento,
           NULL,
           v_id_usuario,
           v_dt_transacao,
           v_tp_transacao,
           decode(v_cd_alta, 1000, 'C', 'A'));
      ELSE

      begin
        SELECT INA.ATD_INA_DT_ALTA_ADM,
               INA.ATD_INA_HR_ALTA_ADM,
               PRO.CAD_PRO_NR_CONSELHO,
               INA.SEG_USU_ID_USUARIO_ALTA
          INTO v_dt_saida,
               v_hr_saida,
               v_nr_conselho_saida,
               v_id_usuario_SAIDA
          FROM TB_ATD_INA_INT_ALTA INA, TB_CAD_PRO_PROFISSIONAL PRO
         WHERE INA.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
           AND INA.ATD_ATE_ID = pATD_ATE_ID;
      EXCEPTION WHEN NO_DATA_FOUND THEN
               v_dt_saida:= null;
               v_hr_saida:= null;
               v_nr_conselho_saida:= null;
               v_id_usuario_SAIDA:= null;
      END;

        UPDATE HOSPITAL.TB_INTERNADO
           SET DT_ALTA            = v_dt_saida,
               HORA_ALTA          = v_hr_saida,
               CRM_ALTA           = v_nr_conselho_saida,
               CD_MATRICULA_ALTA  = v_id_usuario
         WHERE NR_SEQINTER        = pATD_ATE_ID;

        UPDATE HOSPITAL.TB_TRANSFERENCIA
           SET CODHOS       = 1,
               CODUNIHOS    = v_cd_unid_hospitalar,
               COD_QUARTO   = 100,
               COD_LEITO    = decode(v_cd_unid_hospitalar, 2, 1, v_cd_unid_hospitalar),
               ACORDO       = v_codpad,
               DT_ENTRADA   = v_dt_atendimento,
               DT_SAIDA     = v_dt_saida,
               HORA_ENT     = v_hr_atendimento,
               HORA_SAIDA   = v_hr_saida,
               CD_MATRICULA = v_id_usuario,
               DT_TRANSACAO = v_dt_transacao,
               TP_TRANSACAO = v_tp_transacao,
               IN_CANCELADO = decode(v_cd_alta, 1000, 'C', 'A')
         WHERE NR_SEQINTER  = pATD_ATE_ID ;
      END IF;
    END IF;

    -- INSERE TRANSFERENCIA DA ADMISS?O;
    IF v_tipo_atendimento = 'E' THEN
      -- VERIFICA SE TIPO DA INTERNAC?O MUDOU DE INTERNO PARA EXTERNO;
      IF v_tipo_atendimento = 'E' AND v_tipo_anterior = 'I' THEN
        -- APAGA TRANSFERENCIAS DIFERENTE DA ADMISS?O;
        /*      DELETE HOSPITAL.TB_TRANSFERENCIA
               WHERE NR_SEQINTER = pATD_ATE_ID
                 AND CODUNIHOS = v_cd_unid_hospitalar
                 AND (DT_ENTRADA <> v_dt_atendimento AND
                     HORA_ENT <> v_hr_atendimento)
                 AND (DT_ENTRADA <> DT_SAIDA AND HORA_ENT <> HORA_SAIDA);
        */
        DELETE HOSPITAL.TB_TRANSFERENCIA -- 11/01/2011 CRISTIANE GOMES SUBSTITUIU O DELETE ACIMA
         WHERE NR_SEQINTER = pATD_ATE_ID;
      END IF;
      -- INSERE TRANSFERENCIA DA ADMISS?O;
      SELECT COUNT(*)
        INTO v_contador
        FROM HOSPITAL.TB_TRANSFERENCIA
       WHERE NR_SEQINTER = pATD_ATE_ID
         AND CODUNIHOS = v_cd_unid_hospitalar
         AND (DT_ENTRADA = v_dt_atendimento AND HORA_ENT = v_hr_atendimento)
         AND (DT_ENTRADA = DT_SAIDA AND HORA_ENT = HORA_SAIDA);
      IF v_contador = 0 THEN
        INSERT INTO HOSPITAL.TB_TRANSFERENCIA
          (NR_SEQINTER,
           CODHOS,
           CODUNIHOS,
           COD_QUARTO,
           COD_LEITO,
           ACORDO,
           DT_ENTRADA,
           DT_SAIDA,
           HORA_ENT,
           HORA_SAIDA,
           CD_MATRICULA,
           DT_TRANSACAO,
           TP_TRANSACAO,
           IN_CANCELADO)
        values
          (pATD_ATE_ID,
           1,
           v_cd_unid_hospitalar,
           100,
           decode(v_cd_unid_hospitalar, 2, 1, v_cd_unid_hospitalar),
           v_codpad,
           v_dt_atendimento,
           v_dt_atendimento,
           v_hr_atendimento,
           v_hr_atendimento,
           v_id_usuario,
           v_dt_transacao,
           v_tp_transacao,
           decode(v_cd_alta, 1000, 'C', 'A'));
      ELSE
        UPDATE HOSPITAL.TB_TRANSFERENCIA
           SET CODHOS       = 1,
               CODUNIHOS    = v_cd_unid_hospitalar,
               COD_QUARTO   = 100,
               COD_LEITO    = decode(v_cd_unid_hospitalar,
                                     2,
                                     1,
                                     v_cd_unid_hospitalar),
               ACORDO       = v_codpad,
               DT_ENTRADA   = v_dt_atendimento,
               DT_SAIDA     = v_dt_atendimento,
               HORA_ENT     = v_hr_atendimento,
               HORA_SAIDA   = v_hr_atendimento,
               CD_MATRICULA = v_id_usuario,
               DT_TRANSACAO = v_dt_transacao,
               TP_TRANSACAO = v_tp_transacao,
               IN_CANCELADO = decode(v_cd_alta, 1000, 'C', 'A')
         WHERE NR_SEQINTER = pATD_ATE_ID
           AND CODUNIHOS   = v_cd_unid_hospitalar
           AND (DT_ENTRADA = v_dt_atendimento AND
               HORA_ENT    = v_hr_atendimento)
           AND (DT_ENTRADA = DT_SAIDA AND HORA_ENT = HORA_SAIDA);
      END IF;
    END IF;
    -- 23/12/2010 Ramiro Ribeiro
    -- VERIFICA SE TIPO DA INTERNAC?O MUDOU DE EXTERNO PARA INTERNO;
    IF v_tipo_atendimento = 'I' AND v_tipo_anterior = 'E' THEN
      -- APAGA TRANSFERENCIAS;
      DELETE HOSPITAL.TB_TRANSFERENCIA
       WHERE NR_SEQINTER = pATD_ATE_ID
         AND CODUNIHOS = v_cd_unid_hospitalar;
    END IF;
  END IF;
END PRC_LEG_ATU_INT;


