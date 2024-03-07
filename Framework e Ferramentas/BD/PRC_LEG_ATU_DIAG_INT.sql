CREATE OR REPLACE PROCEDURE PRC_LEG_ATU_DIAG_INT (pATD_ATE_ID IN TB_ATD_IDG_INT_DIAGNOSTICO.ATD_ATE_ID%TYPE,
                                                  pATD_IDG_ID IN TB_ATD_IDG_INT_DIAGNOSTICO.ATD_IDG_ID%TYPE) is
  /********************************************************************************************************
  * Procedure: PRC_LEG_ATU_DIAG_INT
  * Data Criacao:  03/09/2010   Por: RAMIRO
  * Funcao: INCLUIR O REGISTRO DE DIAGNÓSTICO DO SGS NA TABELA DO LEGADO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
  *********************************************************************************************************/

  v_contador      number;
  v_DT_INT        date;
  v_HORA_INT      number;
  v_CIDEVE1       varchar2(5);
  v_CIDEVE2       varchar2(5);
  v_CIDEVE3       varchar2(5);
  v_CIDSEC1       varchar2(5);
  v_CIDSEC2       varchar2(5);
  v_CIDSEC3       varchar2(5);
  v_CIDSEC4       varchar2(5);
  v_CIDSEC5       varchar2(5);
  v_CIDALERGIA    varchar2(5);
  v_CIDMOLESTIA   varchar2(5);
  v_CIDPRINC      varchar2(5);
  v_CIDPROVISORIO varchar2(5);
  v_CIDMORTIS     varchar2(5);
  v_DOCOBITO      number(10);
  v_TRAT_REAL     number(10);  
  v_PROCED        number(10);  
  v_PRODUTO       varchar2(150);
  
BEGIN

  SELECT COUNT(*)
    INTO v_contador
    FROM SGS.TB_ATD_IDG_INT_DIAGNOSTICO DIAG
   WHERE DIAG.ATD_ATE_ID = pATD_ATE_ID
     AND DIAG.ATD_IDG_ID = pATD_IDG_ID;

  IF v_contador > 0 THEN

    SELECT ATD.ATD_ATE_DT_ATENDIMENTO                            "DT_INT",
           ATD.ATD_ATE_HR_ATENDIMENTO                            "HORA_INT",
           trim(DIAG.ATD_IDG_CD_CIDEVE1)                         "CIDEVE1",
           trim(DIAG.ATD_IDG_CD_CIDEVE2)                         "CIDEVE2",
           trim(DIAG.ATD_IDG_CD_CIDEVE3)                         "CIDEVE3",
           trim(DIAG.ATD_IDG_CD_CIDSEC1)                         "CIDSEC1",
           trim(DIAG.ATD_IDG_CD_CIDSEC2)                         "CIDSEC2",
           trim(DIAG.ATD_IDG_CD_CIDSEC3)                         "CIDSEC3",
           trim(DIAG.ATD_IDG_CD_CIDSEC4)                         "CIDSEC4",
           trim(DIAG.ATD_IDG_CD_CIDSEC5)                         "CIDSEC5",
           trim(DIAG.ATD_IDG_CD_CIDALERGIA)                      "CIDALERGIA",
           trim(DIAG.ATD_IDG_CD_CIDMOLESTIA)                     "CIDMOLESTIA",
           trim(DIAG.ATD_IDG_CD_CIDPRINCIPAL)                    "CIDPRINC",
           trim(DIAG.ATD_IDG_CD_CIDPROVISORIO)                   "CIDPROVISORIO",
           trim(DIAG.ATD_IDG_CD_CIDCAUSAMORTIS)                  "CIDMORTIS",
           DIAG.ATD_IDG_NR_DOCUMENTOOBITO                        "DOCOBITO",
           DECODE(NVL(DIAG.TIS_TIN_CD_INTERNACAO_REA,0), 2,2, 1) "TRAT_REAL",
           DIAG.CAD_PCI_CD_PROCEDIMENTO_CIH                      "PROCED",
           SUBSTR(PRD.CAD_PRD_DS_DESCRICAO,0,150)                "PRODUTO" 
      INTO v_DT_INT,
           v_HORA_INT,
           v_CIDEVE1,
           v_CIDEVE2,
           v_CIDEVE3,
           v_CIDSEC1,
           v_CIDSEC2,
           v_CIDSEC3,
           v_CIDSEC4,
           v_CIDSEC5,
           v_CIDALERGIA,
           v_CIDMOLESTIA,
           v_CIDPRINC,
           v_CIDPROVISORIO,
           v_CIDMORTIS,
           v_DOCOBITO,
           v_TRAT_REAL,
           v_PROCED,
           v_PRODUTO
      FROM SGS.TB_ATD_IDG_INT_DIAGNOSTICO DIAG,
           SGS.TB_ATD_ATE_ATENDIMENTO     ATD,
           SGS.TB_CAD_PRD_PRODUTO         PRD
     WHERE DIAG.ATD_ATE_ID = ATD.ATD_ATE_ID
       AND DIAG.CAD_PRD_ID = PRD.CAD_PRD_ID(+)
       AND DIAG.ATD_ATE_ID = pATD_ATE_ID
       AND DIAG.ATD_IDG_ID = pATD_IDG_ID;

    -- LIMPA HISTORICO DE DIAGNÓSTICOS
    DELETE HOSPITAL.TB_HISTORICO_DIAGNOSTICO
     WHERE NR_SEQINTER = pATD_ATE_ID
       AND DT_INT = v_DT_INT
       AND HORA_INT = v_HORA_INT;

    -- CID EVENTUAL 1 - ID 9
    IF v_CIDEVE1 IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDEVE1), 9);
    END IF;

    -- CID EVENTUAL 2 - ID 10
    IF v_CIDEVE2 IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDEVE2), 10);
    END IF;

    -- CID EVENTUAL 3 - ID 11
    IF v_CIDEVE3 IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDEVE3), 11);
    END IF;

    -- CID SECUNDARIO 1 - ID 1
    IF v_CIDSEC1 IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDSEC1), 1);
    END IF;

    -- CID SECUNDARIO 2 - ID 2
    IF v_CIDSEC2 IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDSEC2), 2);
    END IF;

    -- CID SECUNDARIO 3 - ID 3
    IF v_CIDSEC3 IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDSEC3), 3);
    END IF;

    -- CID SECUNDARIO 4 - ID 14
    IF v_CIDSEC4 IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDSEC4), 14);
    END IF;

    -- CID SECUNDARIO 5 - ID 15
    IF v_CIDSEC5 IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDSEC5), 15);
    END IF;

    -- CID ALERGINA - ID 4
    IF v_CIDALERGIA IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDALERGIA), 4);
    END IF;

    -- CID MOLESTIA - ID 6
    IF v_CIDMOLESTIA IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDMOLESTIA), 6);
    END IF;

    -- CID PRINCIPAL - ID 8
    IF v_CIDPRINC IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDPRINC), 8);
    END IF;

    -- CID PROVISÓRIO - ID 13
    IF v_CIDPROVISORIO IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDPROVISORIO), 13);
    END IF;

    -- CID MORTIS - ID 12
    IF v_CIDMORTIS IS NOT NULL THEN
      INSERT INTO HOSPITAL.TB_HISTORICO_DIAGNOSTICO
        (NR_SEQINTER, DT_INT, HORA_INT, CID, ID_CID)
      VALUES
        (pATD_ATE_ID, v_DT_INT, v_HORA_INT, trim(v_CIDMORTIS), 12);
    END IF;

    -- DADOS DE INTERNAÇÃO 
    UPDATE HOSPITAL.TB_INTERNADO 
       SET NRDOCOBITO = v_DOCOBITO,
           TRAT_REAL = v_TRAT_REAL,
           COD_PROCED = v_PROCED,
           DS_PROCED = v_PRODUTO
     WHERE NR_SEQINTER = pATD_ATE_ID;

  ELSE
    DELETE HOSPITAL.TB_HISTORICO_DIAGNOSTICO
     WHERE NR_SEQINTER = pATD_ATE_ID
       AND DT_INT = v_DT_INT
       AND HORA_INT = v_HORA_INT;

  END IF;

END PRC_LEG_ATU_DIAG_INT;
