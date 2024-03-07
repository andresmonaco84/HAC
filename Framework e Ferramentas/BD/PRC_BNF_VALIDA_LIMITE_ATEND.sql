CREATE OR REPLACE PROCEDURE PRC_BNF_VALIDA_LIMITE_ATEND(pCODCON           IN BNF_CARENCIA_BENEFICIARIO.CODCON%TYPE,
                                                        pCODEST           IN BNF_BENEFICIARIO.CODEST%TYPE,
                                                        pCODBEN           IN BNF_BENEFICIARIO.CODBEN%TYPE,
                                                        pCODSEQBEN        IN BNF_BENEFICIARIO.CODSEQBEN%TYPE,
                                                        pTP_ATENDIMENTO   IN TB_AUT_ESPECIALIDADE_LIMITE.TP_ATENDIMENTO%TYPE,
                                                        pCD_ESPECIALIDADE IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE,
                                                        io_cursor         OUT PKG_CURSOR.t_cursor)

 IS
  v_cursor          PKG_CURSOR.t_cursor;
  vCBOHAC           varchar2(3);
  vQTD_LIMITE       NUMBER;
  vQTD_DIAS_PERIODO NUMBER;
  vQTD_UTILIZADA    TB_AUT_QTD_ESP_BENEF.QTD_UTILIZADA%TYPE;
  vDT_UTILIZACAO    TB_AUT_QTD_ESP_BENEF.DT_INI_UTILIZACAO%TYPE;
BEGIN

  SELECT CBO.TIS_CBO_CD_CBOS_HAC
    INTO vCBOHAC
    FROM TB_TIS_CBO_CBOS CBO
   WHERE CBO.TIS_CBO_CD_CBOS = pCD_ESPECIALIDADE;

  BEGIN
    SELECT LIMITE.QTD_LIMITE, LIMITE.QTD_DIAS_PERIODO
      INTO vQTD_LIMITE, vQTD_DIAS_PERIODO
      FROM TB_AUT_ESPECIALIDADE_LIMITE LIMITE
     WHERE LIMITE.CODESPMED = vCBOHAC
       AND LIMITE.TP_ATENDIMENTO = pTP_ATENDIMENTO;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      OPEN v_cursor FOR
        SELECT 1 AS RETORNO from dual;
      io_cursor := v_cursor;
      RETURN;
  END;

  IF (vQTD_LIMITE IS NOT NULL) THEN
    BEGIN
      SELECT QTD_UTILIZADA, DT_INI_UTILIZACAO + vQTD_DIAS_PERIODO
        INTO vQTD_UTILIZADA, vDT_UTILIZACAO
        FROM TB_AUT_QTD_ESP_BENEF
       WHERE CODCON = pCODCON
         AND CODEST = pCODEST
         AND CODBEN = pCODBEN
         AND CODSEQBEN = pCODSEQBEN
         AND CODESPMED = vCBOHAC
         AND TP_ATENDIMENTO = pTP_ATENDIMENTO;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        vDT_UTILIZACAO := NULL;
    END;
  
    IF (vDT_UTILIZACAO IS NOT NULL) THEN
      IF (TRUNC(vDT_UTILIZACAO) < TRUNC(SYSDATE)) THEN
        DELETE TB_AUT_QTD_ESP_BENEF
         WHERE CODCON = pCODCON
           AND CODEST = pCODEST
           AND CODBEN = pCODBEN
           AND CODSEQBEN = pCODSEQBEN
           AND CODESPMED = vCBOHAC
           AND TP_ATENDIMENTO = pTP_ATENDIMENTO;
      
        INSERT INTO TB_AUT_QTD_ESP_BENEF
          (CODCON,
           CODEST,
           CODBEN,
           CODSEQBEN,
           CODESPMED,
           TP_ATENDIMENTO,
           QTD_UTILIZADA,
           DT_INI_UTILIZACAO)
        VALUES
          (pCODCON,
           pCODEST,
           pCODBEN,
           pCODSEQBEN,
           vCBOHAC,
           pTP_ATENDIMENTO,
           1,
           TRUNC(SYSDATE));
      ELSE
        IF (vQTD_LIMITE > vQTD_UTILIZADA) THEN
          UPDATE TB_AUT_QTD_ESP_BENEF
             SET QTD_UTILIZADA = QTD_UTILIZADA + 1
           WHERE CODCON = pCODCON
             AND CODEST = pCODEST
             AND CODBEN = CODBEN
             AND CODSEQBEN = CODSEQBEN
             AND CODESPMED = CODESPMED
             AND TP_ATENDIMENTO = TP_ATENDIMENTO;
        
          OPEN v_cursor FOR
            SELECT 1 AS RETORNO from dual;
          io_cursor := v_cursor;
          return;
        ELSE
          OPEN v_cursor FOR
           SELECT 0 AS RETORNO FROM DUAL;
           io_cursor := v_cursor;
           RETURN;
        END IF;
      END IF;
    ELSE
      INSERT INTO TB_AUT_QTD_ESP_BENEF
        (CODCON,
         CODEST,
         CODBEN,
         CODSEQBEN,
         CODESPMED,
         TP_ATENDIMENTO,
         QTD_UTILIZADA,
         DT_INI_UTILIZACAO)
      VALUES
          (pCODCON,
           pCODEST,
           pCODBEN,
           pCODSEQBEN,
           vCBOHAC,
           pTP_ATENDIMENTO,
           1,
           TRUNC(SYSDATE));
    END IF;
  END IF;

  OPEN v_cursor FOR
    SELECT 1 AS RETORNO from dual;

  io_cursor := v_cursor;

END PRC_BNF_VALIDA_LIMITE_ATEND;
