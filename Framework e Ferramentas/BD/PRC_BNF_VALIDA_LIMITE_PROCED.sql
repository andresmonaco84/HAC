CREATE OR REPLACE PROCEDURE PRC_BNF_VALIDA_LIMITE_PROCED(pCODCON         IN BNF_CARENCIA_BENEFICIARIO.CODCON%TYPE,
                                                         pCODEST         IN BNF_BENEFICIARIO.CODEST%TYPE,
                                                         pCODBEN         IN BNF_BENEFICIARIO.CODBEN%TYPE,
                                                         pCODSEQBEN      IN BNF_BENEFICIARIO.CODSEQBEN%TYPE,
                                                         pTP_ATENDIMENTO IN TB_AUT_ATO_MEDICO_LIMITE.TP_ATENDIMENTO%TYPE,
                                                         pCODATOMED      IN TB_AUT_ATO_MEDICO_LIMITE.CODATOMED%TYPE,
                                                         io_cursor       OUT PKG_CURSOR.t_cursor)

 IS
  v_cursor                PKG_CURSOR.t_cursor;
  vQTD_LIMITE             NUMBER;
  vQTD_DIAS_PERIODO       NUMBER;
  vQTD_LIMITE_PLANO       NUMBER;
  vQTD_DIAS_PERIODO_PLANO NUMBER;
  vQTD_UTILIZADA          TB_AUT_QTD_ESP_BENEF.QTD_UTILIZADA%TYPE;
  vDT_UTILIZACAO          TB_AUT_QTD_ESP_BENEF.DT_INI_UTILIZACAO%TYPE;
BEGIN

  BEGIN
    SELECT QTD_LIMITE, QTD_DIAS_PERIODO
      INTO vQTD_LIMITE, vQTD_DIAS_PERIODO
      FROM TB_AUT_ATO_MEDICO_LIMITE
     WHERE CODATOMED = pCODATOMED
       AND TP_ATENDIMENTO = pTP_ATENDIMENTO;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      OPEN v_cursor FOR
        SELECT 1 AS RETORNO from dual;
        io_cursor := v_cursor;
      RETURN;
  END;
  IF (vQTD_LIMITE IS NOT NULL) THEN
  
    BEGIN
      SELECT QTD_LIMITE, QTD_DIAS_PERIODO
        INTO vQTD_LIMITE_PLANO, vQTD_DIAS_PERIODO_PLANO
        FROM TB_AUT_CONF_ATO_AUTORIZADOR
       WHERE CODCON = pCODCON
         AND CODATOMED = pCODATOMED
         AND TP_ATENDIMENTO = pTP_ATENDIMENTO;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        vQTD_LIMITE_PLANO       := NULL;
        vQTD_DIAS_PERIODO_PLANO := NULL;
    END;
    IF (vQTD_LIMITE_PLANO IS NOT NULL) THEN
      vQTD_DIAS_PERIODO := vQTD_DIAS_PERIODO_PLANO;
      vQTD_LIMITE := vQTD_LIMITE_PLANO;
    END IF;
  
    BEGIN
    
      SELECT QTD_UTILIZADA, DT_INI_UTILIZACAO + vQTD_DIAS_PERIODO
        INTO vQTD_UTILIZADA, vDT_UTILIZACAO
        FROM TB_AUT_QTD_ATO_BENEF
       WHERE CODCON = pCODCON
         AND CODEST = pCODEST
         AND CODBEN = pCODBEN
         AND CODSEQBEN = pCODSEQBEN
         AND CODATOMED = pCODATOMED
         AND TP_ATENDIMENTO = pTP_ATENDIMENTO;
    
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        vQTD_UTILIZADA := NULL;
        vDT_UTILIZACAO := TRUNC(SYSDATE);
    END;
  
    IF (vQTD_UTILIZADA IS NULL) THEN
      INSERT INTO TB_AUT_QTD_ATO_BENEF
        (CODCON,
         CODEST,
         CODBEN,
         CODSEQBEN,
         CODATOMED,
         TP_ATENDIMENTO,
         QTD_UTILIZADA,
         DT_INI_UTILIZACAO)
      VALUES
        (pCODCON,
         pCODEST,
         pCODBEN,
         pCODSEQBEN,
         pCODATOMED,
         pTP_ATENDIMENTO,
         1,
         TRUNC(SYSDATE));
    
      OPEN v_cursor FOR
        SELECT 1 AS RETORNO from dual;
        io_cursor := v_cursor;
      RETURN;
    END IF;
  
    IF (TRUNC(vDT_UTILIZACAO) < TRUNC(SYSDATE)) THEN
      DELETE TB_AUT_QTD_ATO_BENEF
       WHERE CODCON = pCODCON
         AND CODEST = pCODEST
         AND CODBEN = pCODBEN
         AND CODSEQBEN = pCODSEQBEN
         AND CODATOMED = pCODATOMED
         AND TP_ATENDIMENTO = pTP_ATENDIMENTO;
    
      INSERT INTO TB_AUT_QTD_ATO_BENEF
        (CODCON,
         CODEST,
         CODBEN,
         CODSEQBEN,
         CODATOMED,
         TP_ATENDIMENTO,
         QTD_UTILIZADA,
         DT_INI_UTILIZACAO)
      VALUES
        (pCODCON,
         pCODEST,
         pCODBEN,
         pCODSEQBEN,
         pCODATOMED,
         pTP_ATENDIMENTO,
         1,
         TRUNC(SYSDATE));
    ELSE
      IF (vQTD_LIMITE > vQTD_UTILIZADA) THEN
        UPDATE TB_AUT_QTD_ATO_BENEF
           SET QTD_UTILIZADA = QTD_UTILIZADA + 1
         WHERE CODCON = pCODCON
           AND CODEST = pCODEST
           AND CODBEN = pCODBEN
           AND CODSEQBEN = pCODSEQBEN
           AND CODATOMED = pCODATOMED
           AND TP_ATENDIMENTO = pTP_ATENDIMENTO;
      ELSE
        OPEN v_cursor FOR
          SELECT 0 AS RETORNO from dual;
          io_cursor := v_cursor;
        return;
      END IF;
    END IF;
  END IF;

  OPEN v_cursor FOR
    SELECT 1 AS RETORNO from dual;
io_cursor := v_cursor;
  

END PRC_BNF_VALIDA_LIMITE_PROCED;
 