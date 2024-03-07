CREATE OR REPLACE PROCEDURE PRC_LEG_ATU_MOV_INT(pATD_IML_ID IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_ID%TYPE) is
  /***************************************************************************************
  * Procedure: PRC_LEG_ATU_MOV_INT
  * Data Criacao:  19/07/2010   Por: RAMIRO
  * Funcao: INCLUIR A MOV. DA INTERNAC?O DO SGS NA TABELA DO LEGADO HOSPITAL.TB_INTERNADO
  * Data Alteracao: 26/7/2011   Por Cristiane 
  * Alteracao: Tratar a troca de pacientes entre leitos do mesmo setor
  ****************************************************************************************/
  v_contador number;
  ex_atendinexistente exception;
  v_atd_id             number;
  v_cd_hosp            number;
  v_cd_unid_hospitalar number;
  v_cd_quarto          number;
  v_cd_leito           number;
  v_ds_acordo          varchar2(12);
  v_dt_entrada         date;
  v_dt_saida           date;
  v_hr_entrada         varchar2(4);
  v_hr_saida           varchar2(4);
  v_id_usuario         number;
  v_dt_transacao       date;
  v_tp_transacao       char(1);
  v_in_cancelado       char(1);
  v_mov                number;
  v_codpad             varchar2(3);
  v_tipoaco            varchar2(2);
  v_cortesia           char(1);
  v_difclasse          char(1);
BEGIN
  SELECT COUNT(*)
    INTO v_contador
    FROM TB_ATD_IML_INT_MOV_LEITO MOV
   WHERE MOV.ATD_IML_ID = pATD_IML_ID;
  IF v_contador = 0 THEN
    raise ex_atendinexistente;
  ELSE
    SELECT MOV.ATD_ATE_ID "NR_SEQINTER",
           1 "CODHOS",
           UNI.CAD_UNI_CD_UNID_HOSPITALAR "CODUNIHOS",
           LTO.CAD_QLE_NR_QUARTO "COD_QUARTO",
           LTO.CAD_QLE_NR_LEITO "COD_LEITO",
           SUBSTR(ACO.TIS_TAC_DS_TIPO_ACOMODACAO, 0, 12) "ACORDO",
           TRUNC(MOV.ATD_IML_DT_ENTRADA) "DT_ENTRADA",
           TRUNC(MOV.ATD_IML_DT_SAIDA) "DT_SAIDA",
           MOV.ATD_IML_HR_ENTRADA "HORA_ENT",
           MOV.ATD_IML_HR_SAIDA "HORA_SAIDA",
           MOV.SEG_USU_ID_USUARIO "CD_MATRICULA",
           SYSDATE "DT_TRANSACAO",
           'M' "TP_TRANSACAO",
           MOV.ATD_IML_FL_STATUS "IN_CANCELADO",
           ATE.CODPAD "CODPAD",
           trim(MOV.TIS_TAC_CD_TIPO_ACOMODACAO) "TIPOACO",
           MOV.ATD_IML_FL_CORTESIA "CORTESIA",
           MOV.ATD_IML_FL_DIF_CLASSE "DIFCLASSE"
      INTO v_atd_id,
           v_cd_hosp,
           v_cd_unid_hospitalar,
           v_cd_quarto,
           v_cd_leito,
           v_ds_acordo,
           v_dt_entrada,
           v_dt_saida,
           v_hr_entrada,
           v_hr_saida,
           v_id_usuario,
           v_dt_transacao,
           v_tp_transacao,
           v_in_cancelado,
           v_codpad,
           v_tipoaco,
           v_cortesia,
           v_difclasse
      FROM TB_ATD_IML_INT_MOV_LEITO   MOV,
           TB_CAD_QLE_QUARTO_LEITO    LTO,
           TB_CAD_SET_SETOR           STR,
           TB_CAD_UNI_UNIDADE         UNI,
           TB_TIS_TAC_TIPO_ACOMODACAO ACO,
           TB_ATD_ATE_ATENDIMENTO     ATE
     WHERE MOV.CAD_CAD_QLE_ID = LTO.CAD_QLE_ID
       AND LTO.CAD_SET_ID = STR.CAD_SET_ID
       AND STR.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
       AND MOV.TIS_TAC_CD_TIPO_ACOMODACAO =
           ACO.TIS_TAC_CD_TIPO_ACOMODACAO(+)
       AND MOV.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND MOV.ATD_IML_ID = pATD_IML_ID;
  END IF;
  SELECT COUNT(*)
    INTO v_contador
    FROM HOSPITAL.TB_TRANSFERENCIA
   WHERE NR_SEQINTER = v_atd_id
     AND CODUNIHOS = v_cd_unid_hospitalar
     AND COD_QUARTO = v_cd_quarto
     AND COD_LEITO = v_cd_leito
     AND DT_ENTRADA = v_dt_entrada
     AND HORA_ENT = v_hr_entrada;
  IF v_contador = 0 THEN
    SELECT COUNT(*)
      INTO v_contador
      FROM HOSPITAL.TB_TRANSFERENCIA
     WHERE NR_SEQINTER = v_atd_id
       AND CODUNIHOS = v_cd_unid_hospitalar
       AND ((COD_QUARTO != v_cd_quarto AND COD_LEITO != v_cd_leito) OR
           (COD_LEITO != v_cd_leito))
       AND DT_ENTRADA = v_dt_entrada
       AND HORA_ENT = v_hr_entrada
       AND DT_SAIDA IS NULL
       AND HORA_SAIDA IS NULL;
    IF v_contador > 0 THEN
      UPDATE HOSPITAL.TB_TRANSFERENCIA
         SET COD_QUARTO = v_cd_quarto, COD_LEITO = v_cd_leito
       WHERE NR_SEQINTER = v_atd_id
         AND CODUNIHOS = v_cd_unid_hospitalar
         AND ((COD_QUARTO != v_cd_quarto AND COD_LEITO != v_cd_leito) OR
             (COD_LEITO != v_cd_leito))
         AND DT_ENTRADA = v_dt_entrada
         AND HORA_ENT = v_hr_entrada
         AND DT_SAIDA IS NULL
         AND HORA_SAIDA IS NULL;
    ELSE
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
        (v_atd_id,
         v_cd_hosp,
         v_cd_unid_hospitalar,
         v_cd_quarto,
         v_cd_leito,
         v_ds_acordo,
         v_dt_entrada,
         v_dt_saida,
         v_hr_entrada,
         v_hr_saida,
         v_id_usuario,
         v_dt_transacao,
         v_tp_transacao,
         v_in_cancelado);
    END IF;
  ELSE
    UPDATE HOSPITAL.TB_TRANSFERENCIA
       SET CODHOS       = v_cd_hosp,
           CODUNIHOS    = v_cd_unid_hospitalar,
           COD_QUARTO   = v_cd_quarto,
           COD_LEITO    = v_cd_leito,
           ACORDO       = v_ds_acordo,
           DT_ENTRADA   = v_dt_entrada,
           DT_SAIDA     = v_dt_saida,
           HORA_ENT     = v_hr_entrada,
           HORA_SAIDA   = v_hr_saida,
           CD_MATRICULA = v_id_usuario,
           DT_TRANSACAO = v_dt_transacao,
           TP_TRANSACAO = v_tp_transacao,
           IN_CANCELADO = v_in_cancelado
     WHERE NR_SEQINTER = v_atd_id
       AND CODUNIHOS = v_cd_unid_hospitalar
       AND COD_QUARTO = v_cd_quarto
       AND COD_LEITO = v_cd_leito
       AND DT_ENTRADA = v_dt_entrada
       AND HORA_ENT = v_hr_entrada;
  END IF;
  -- 14/09/2010 Ramiro Ribeiro
  -- ATUALIZA PADR?O NA TB_INTERNADO BASEADO NA ACOMODAC?O DA PRIMEIRA TRANFERENCIA; 
  BEGIN
    SELECT MIN(MOV.ATD_IML_ID)
      INTO v_mov
      FROM TB_ATD_IML_INT_MOV_LEITO MOV
     WHERE MOV.ATD_ATE_ID = v_atd_id
       AND MOV.ATD_IML_FL_STATUS = 'A';
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      v_mov := 0;
  END;
  IF v_mov = pATD_IML_ID THEN
    IF v_codpad IS NULL THEN
      -- ENFERMARIA SEM CORTESIA E DIF.CLASSE;
      IF (v_tipoaco = '1') AND (v_cortesia = 'N') AND (v_difclasse = 'N') THEN
        v_codpad := 'BAS';
        -- APTO SIMPLES COM CORTESIA OU DIF.CLASSE;
      ELSIF (v_tipoaco = '12') AND (v_cortesia = 'S' OR v_difclasse = 'S') THEN
        v_codpad := 'BAS';
        -- APTO SIMPLES SEM CORTESIA E DIF.CLASSE;
      ELSIF (v_tipoaco = '12') AND (v_cortesia = 'N') AND
            (v_difclasse = 'N') THEN
        v_codpad := 'EXE';
        -- APTO LUXO COM CORTESIA OU DIF.CLASSE;
      ELSIF (v_tipoaco = '11') AND (v_cortesia = 'S' OR v_difclasse = 'S') THEN
        v_codpad := 'EXE';
        -- APTO LUXO SEM CORTESIA E DIF.CLASSE;
      ELSIF (v_tipoaco = '11') AND (v_cortesia = 'N') AND
            (v_difclasse = 'N') THEN
        v_codpad := 'MST';
        -- UTI's;
      ELSIF (v_tipoaco = '51') OR (v_tipoaco = '52') OR (v_tipoaco = '53') THEN
        v_codpad := 'UTI';
      ELSE
        v_codpad := 'BAS';
      END IF;
    END IF;
    UPDATE HOSPITAL.TB_INTERNADO
       SET CODPAD = v_codpad
     WHERE NR_SEQINTER = v_atd_id;
  END IF;
END PRC_LEG_ATU_MOV_INT;
/
