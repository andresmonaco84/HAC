CREATE OR REPLACE PROCEDURE PRC_LEG_ATU_GUIA_INT(pATD_GUI_CD_CODIGO   IN TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_CODIGO%TYPE,
                                                       pATD_ATE_ID          IN TB_ATD_GUI_GUIAATEND.ATD_ATE_ID%TYPE,
                                                       pATD_GUI_DT_VALIDADE IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_VALIDADE%TYPE) is
  /*********************************************************************
  * Procedure: PRC_LEG_ATU_GUIA_INT
  * Data alteracao:  28/05/2013   Por: PEDRO
  * Funcao: corrigido 2 select retirando a pat e pegando o paciente atual
  **********************************************************************/
  v_contador number;
  ex_atendinexistente exception;
  v_dt_int           date;
  v_cd_prontuario    number;
  v_nr_guia          varchar2(30);
  v_dt_guia          date;
  v_dt_validade_guia date;
  v_cd_codvalidade   number;
  v_nr_senha         varchar2(30);
  v_nr_dias_validade number;
  v_ds_compl         varchar2(200);
  v_atd_id           number;
  v_dt_autorizacao   date;
BEGIN
  SELECT COUNT(*)
    INTO v_contador
    FROM TB_ATD_GUI_GUIAATEND GUIA
   WHERE GUIA.ATD_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO
     AND GUIA.ATD_ATE_ID = pATD_ATE_ID
     AND GUIA.ATD_GUI_DT_VALIDADE = pATD_GUI_DT_VALIDADE;
  IF v_contador = 0 THEN
    raise ex_atendinexistente;
  ELSE
    SELECT ATD.ATD_ATE_DT_ATENDIMENTO "DT_INT",
           PAC.CAD_PAC_NR_PRONTUARIO "CODPAC",
           GUI.ATD_GUI_CD_CODIGO "CODGUIA",
           GUI.ATD_GUI_DT_EMISSAOGUIA "DT_GUIA",
           GUI.ATD_GUI_DT_VALIDADE "DT_VALIDADE",
           DECODE(GUI.ATD_GUI_FL_ATIVO_OK, 'S', 1, 0) "COD_VALIDADE",
           DECODE(GUI.ATD_GUI_CD_SENHA,
                  NULL,
                  GUI.ATD_GUI_CD_CODIGO,
                  GUI.ATD_GUI_CD_SENHA) "CODSENHA",
           GUI.ATD_GUI_DIAS_VALIDADE "DIAS_VALIDADE",
           GUI.ATD_GUI_DS_OBSERVACAO "COMPL_GUIA",
           ATD.ATD_ATE_ID "NR_SEQINTER",
           GUI.ATD_GUI_DT_AUTORIZGUIA "DT_AUTORIZACAO"
      INTO v_dt_int,
           v_cd_prontuario,
           v_nr_guia,
           v_dt_guia,
           v_dt_validade_guia,
           v_cd_codvalidade,
           v_nr_senha,
           v_nr_dias_validade,
           v_ds_compl,
           v_atd_id,
           v_dt_autorizacao
      FROM TB_ATD_ATE_ATENDIMENTO ATD,
           TB_CAD_UNI_UNIDADE     UNI,
           TB_CAD_PAC_PACIENTE    PAC,
           TB_ATD_GUI_GUIAATEND   GUI
     WHERE GUI.ATD_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO
       AND ATD.ATD_ATE_ID = pATD_ATE_ID
       AND GUI.ATD_GUI_DT_VALIDADE = pATD_GUI_DT_VALIDADE
       AND ATD.ATD_ATE_ID = GUI.ATD_ATE_ID
       AND ATD.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
       AND fnc_buscar_paciente_atual(ATD.ATD_ATE_ID) = PAC.CAD_PAC_ID_PACIENTE;
  END IF;
  SELECT COUNT(*)
    INTO v_contador
    FROM HOSPITAL.TB_GUIA
   WHERE NR_SEQINTER = pATD_ATE_ID
     AND CODGUIA = TO_CHAR(pATD_GUI_CD_CODIGO)
     AND DT_VALIDADE = pATD_GUI_DT_VALIDADE;
  IF v_contador = 0 THEN
    INSERT INTO HOSPITAL.TB_GUIA
      (DT_INT,
       CODPAC,
       CODGUIA,
       DT_GUIA,
       DT_VALIDADE,
       COD_VALIDADE,
       CODSENHA,
       DIAS_VALIDADE,
       COMPL_GUIA,
       NR_SEQINTER,
       DT_AUTORIZACAO)
    values
      (v_dt_int,
       v_cd_prontuario,
       v_nr_guia,
       v_dt_guia,
       v_dt_validade_guia,
       v_cd_codvalidade,
       v_nr_senha,
       v_nr_dias_validade,
       v_ds_compl,
       v_atd_id,
       v_dt_autorizacao);
  ELSE
    UPDATE HOSPITAL.TB_GUIA
       SET DT_VALIDADE    = v_dt_validade_guia,
           COD_VALIDADE   = v_cd_codvalidade,
           DIAS_VALIDADE  = v_nr_dias_validade,
           COMPL_GUIA     = v_ds_compl,
           DT_AUTORIZACAO = v_dt_autorizacao
     WHERE CODGUIA = pATD_GUI_CD_CODIGO
       AND NR_SEQINTER = pATD_ATE_ID
       AND DT_VALIDADE = pATD_GUI_DT_VALIDADE;
  END IF;
END PRC_LEG_ATU_GUIA_INT;
