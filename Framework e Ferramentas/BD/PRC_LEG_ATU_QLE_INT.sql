create or replace procedure PRC_LEG_ATU_QLE_INT(pCAD_QLE_ID IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_ID%TYPE) is
/******************************************************************************
* Procedure: PRC_LEG_ATU_QLE_INT
* Data Criacao:  19/07/2010   Por: RAMIRO
* Funcao: INCLUIR QUARTO E LEITO DO SGS NA TABELA DO LEGADO HOSPITAL.TB_QUARTO
*******************************************************************************/

  v_contador              number;
  ex_atendinexistente     exception;
  v_cd_hosp               number;
  v_cd_unid_hospitalar    number;
  v_cd_quarto             number;
  v_cd_leito              number;
  v_nr_andar              number;
  v_cd_setor              varchar2(4);
  v_cd_codaco             varchar2(4);  
  v_cd_codaco_prov        varchar2(4);  
  v_tp_sexo               char(1);
  v_tp_quarto             char(1);
  v_nr_ramal              number;

BEGIN

  SELECT COUNT(*)
    INTO v_contador
    FROM TB_CAD_QLE_QUARTO_LEITO QLE
   WHERE QLE.CAD_QLE_ID = pCAD_QLE_ID;

  IF v_contador = 0 THEN
    raise ex_atendinexistente;

  ELSE
    SELECT 1 "CODHOS",
           UNI.CAD_UNI_CD_UNID_HOSPITALAR "CODUNIHOS",
           LTO.CAD_QLE_NR_QUARTO "COD_QUARTO",
           LTO.CAD_QLE_NR_LEITO "COD_LEITO",
           STR.CAD_SET_NR_ANDAR "AN_ANDAR",
           STR.CAD_SET_CD_SETOR "CD_SETOR",
           LTO.CAD_QLE_TP_SEXO "SEXO",
           TO_CHAR(TRUNC(LTO.TIS_TAC_CD_TIPO_ACOM_PROV)) "COD_ACO_PROV",
           TO_CHAR(TRUNC(LTO.TIS_TAC_CD_TIPO_ACOMODACAO)) "COD_ACO",
           LTO.CAD_QLE_TP_QUARTO_LEITO "TP_QUARTO",
           LTO.CAD_QLE_NR_RAMAL "RAMAL"
      INTO v_cd_hosp,
           v_cd_unid_hospitalar,
           v_cd_quarto,
           v_cd_leito,
           v_nr_andar,
           v_cd_setor,
           v_tp_sexo,
           v_cd_codaco_prov,
           v_cd_codaco,
           v_tp_quarto,
           v_nr_ramal
      FROM TB_CAD_QLE_QUARTO_LEITO LTO,
           TB_CAD_SET_SETOR STR,
           TB_CAD_UNI_UNIDADE UNI
     WHERE LTO.CAD_SET_ID = STR.CAD_SET_ID
       AND STR.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
       AND LTO.CAD_QLE_ID = pCAD_QLE_ID;
  END IF;

  SELECT COUNT(*)
    INTO v_contador
    FROM HOSPITAL.TB_QUARTO
   WHERE CODUNIHOS = v_cd_unid_hospitalar
     AND COD_QUARTO = v_cd_quarto
     AND COD_LEITO = v_cd_leito;

  IF v_contador = 0 THEN
    INSERT INTO HOSPITAL.TB_QUARTO
      (CODHOS,
       CODUNIHOS,
       COD_QUARTO,
       COD_LEITO,
       AN_SETOR,
       CD_SETOR,
       SEXO,
       COD_ACO_PROV,
       COD_ACO,
       TP_QUARTO,
       RAMAL)
    values
      (v_cd_hosp,
       v_cd_unid_hospitalar,
       v_cd_quarto,
       v_cd_leito,
       v_nr_andar,
       v_cd_setor,
       v_tp_sexo,
       v_cd_codaco_prov,
       v_cd_codaco,
       v_tp_quarto,
       v_nr_ramal);
  ELSE
    UPDATE HOSPITAL.TB_QUARTO
       SET AN_SETOR = v_nr_andar,
           SEXO = v_tp_sexo,
           COD_ACO_PROV = v_cd_codaco_prov,
           COD_ACO = v_cd_codaco,
           TP_QUARTO = v_tp_quarto,
           RAMAL = v_nr_ramal
     WHERE CODHOS = v_cd_hosp
       AND CODUNIHOS = v_cd_unid_hospitalar
       AND COD_QUARTO = v_cd_quarto
       AND COD_LEITO = v_cd_leito
       AND CD_SETOR = v_cd_setor;
  END IF;
.
END PRC_LEG_ATU_QLE_INT;