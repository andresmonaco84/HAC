CREATE OR REPLACE PROCEDURE SGS.PRC_LEG_ATU_RN_INT(pATD_ATE_ID IN TB_ATD_IDR_INT_DADOS_RN.ATD_ATE_ID%TYPE) is
  /***************************************************************************************
  * Procedure: PRC_LEG_ATU_RN_INT
  * Data Criacao:  03/09/2010   Por: RAMIRO
  * Funcao: INCLUIR O REGISTRO DO RECEM-NASCIDO DO SGS NA TABELA DO LEGADO HOSPITAL.TB_RN
  ****************************************************************************************/

  v_contador number;
  ex_atendinexistente exception;
  v_CODPAC    number;
  v_DT_INT    date;
  v_DT_NASC   date;
  v_NOM_RN    varchar2(30);
  v_APGAR     varchar2(20);
  v_SEXO      varchar2(10);
  v_IDADE_GES varchar2(15);
  v_PESO      number;
  v_CID       varchar2(5);
  v_APGAR2    varchar2(20);
  v_APGAR3    varchar2(20);
  v_IN_COLETA char(1);
  v_NR_DNV    varchar2(10);

BEGIN

  SELECT COUNT(*)
    INTO v_contador
    FROM SGS.TB_ATD_IDR_INT_DADOS_RN RN
   WHERE RN.ATD_ATE_ID = pATD_ATE_ID;

  IF v_contador = 0 THEN
    DELETE HOSPITAL.TB_RN
     WHERE CODPAC = v_CODPAC
       AND DT_INT = v_DT_INT
       AND DT_NASC = v_DT_NASC;
  
  ELSE
    SELECT PAC.CAD_PAC_NR_PRONTUARIO "CODPAC",
           ATD.ATD_ATE_DT_ATENDIMENTO "DT_INT",
           RN.ATD_IDR_DT_NASCIMENTO "DT_NASC",
           SUBSTR(RN.ATD_IDR_NM_NOME, 0, 30) "NOM_RN",
           RN.ATD_IDR_APGAR1 "APGAR",
           RN.ATD_IDR_TP_SEXO "SEXO",
           SUBSTR(RN.ATD_IDR_DS_IDADE_GESTACIONAL, 0, 15) "IDADE_GES",
           RN.ATD_IDR_QT_PESO "PESO",
           RN.CAD_CID_CD_CID10 "CID",
           RN.ATD_IDR_APGAR2 "APGAR2",
           RN.ATD_IDR_APGAR3 "APGAR3",
           NULL "IN_COLETA",
           RN.ATD_IDR_NR_DNV "NR_DNV"
      INTO v_CODPAC,
           v_DT_INT,
           v_DT_NASC,
           v_NOM_RN,
           v_APGAR,
           v_SEXO,
           v_IDADE_GES,
           v_PESO,
           v_CID,
           v_APGAR2,
           v_APGAR3,
           v_IN_COLETA,
           v_NR_DNV
      FROM SGS.TB_ATD_IDR_INT_DADOS_RN RN,
           SGS.TB_ATD_ATE_ATENDIMENTO  ATD,
           SGS.TB_ASS_PAT_PACIEATEND   PAT,
           SGS.TB_CAD_PAC_PACIENTE     PAC
     WHERE RN.ATD_ATE_ID = ATD.ATD_ATE_ID(+)
       AND ATD.ATD_ATE_ID = PAT.ATD_ATE_ID(+)
       AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE(+)
       AND RN.ATD_ATE_ID = pATD_ATE_ID;
  
    SELECT COUNT(*)
      INTO v_contador
      FROM HOSPITAL.TB_RN
     WHERE CODPAC = v_CODPAC
       AND DT_INT = v_DT_INT
       AND DT_NASC = v_DT_NASC;
  
    IF v_contador = 0 THEN
      INSERT INTO HOSPITAL.TB_RN
        (CODPAC,
         DT_INT,
         DT_NASC,
         NOM_RN,
         APGAR,
         SEXO,
         IDADE_GES,
         PESO,
         CID,
         APGAR2,
         APGAR3,
         IN_COLETA,
         NR_DNV)
      values
        (v_CODPAC,
         v_DT_INT,
         v_DT_NASC,
         v_NOM_RN,
         v_APGAR,
         v_SEXO,
         v_IDADE_GES,
         v_PESO,
         v_CID,
         v_APGAR2,
         v_APGAR3,
         v_IN_COLETA,
         v_NR_DNV);
    
    ELSE
      UPDATE HOSPITAL.TB_RN
         SET NOM_RN    = v_NOM_RN,
             APGAR     = v_APGAR,
             SEXO      = v_SEXO,
             IDADE_GES = v_IDADE_GES,
             PESO      = v_PESO,
             CID       = v_CID,
             APGAR2    = v_APGAR2,
             APGAR3    = v_APGAR3,
             IN_COLETA = v_IN_COLETA,
             NR_DNV    = v_NR_DNV
       WHERE CODPAC = v_CODPAC
         AND DT_INT = v_DT_INT
         AND DT_NASC = v_DT_NASC;
    
    END IF;
  
  END IF;

END PRC_LEG_ATU_RN_INT;
