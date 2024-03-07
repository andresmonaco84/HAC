CREATE OR REPLACE PROCEDURE "PRC_CTS_14_APOIO_CONF_CARGA_RM"(P_MESFAT IN TB_CTS_MOV_MOVIMENTACAO_RM.CTS_MOV_RM_MES%type,
                                 P_ANOFAT IN TB_CTS_MOV_MOVIMENTACAO_RM.CTS_MOV_RM_ANO%type,
                                 IO_CURSOR         OUT PKG_CURSOR.T_CURSOR) IS
  v_cursor PKG_CURSOR.t_cursor;
BEGIN
  OPEN v_cursor FOR
    SELECT CCR.CAD_CCR_ID,
           CCR.CAD_CCR_CD_CONTA,
           CCR.CAD_CCR_DS_DESCRICAO,
           UNI.CODFILIAL FILIAL,
           CEC.CAD_CEC_CD_CCUSTO C_CUSTO,
           SUM(MV.RM) MOVTORM,
           SUM(MV.SGS) CARGASGS,
           SUM(MV.RM) - SUM(MV.SGS) DIFERENCA
      FROM TB_CAD_CCR_CCONTA_RM    CCR,
           TB_CAD_UNI_UNIDADE      UNI,
           TB_CAD_CEC_CENTRO_CUSTO CEC,
           ---- MOVTO BASE DE DADOS DO SALDUS
           (SELECT TO_NUMBER(SALDO.ANO) ANO,
                   TO_NUMBER(SALDO.MES) MES,
                   SALDO.ID_CONTA,
                   SALDO.ID_UNIDADE,
                   SALDO.ID_CCUSTO,
                   SUM(SALDO.VALOR) RM,
                   0.00 SGS
              FROM (SELECT TO_CHAR(LAN.DATA, 'YYYY') ANO,
                           TO_CHAR(LAN.DATA, 'MM') MES,
                           CCR.CAD_CCR_ID ID_CONTA,
                           UNI.CAD_UNI_ID_UNIDADE ID_UNIDADE,
                           CC.CAD_CEC_ID_CCUSTO ID_CCUSTO,
                           SUM(VALOR) * -1 VALOR
                      FROM RM.CPARTIDA          LAN,
                           TB_CAD_CCR_CCONTA_RM    CCR,
                           RM.GFILIAL           F,
                           TB_CAD_UNI_UNIDADE      UNI,
                           TB_CAD_CEC_CENTRO_CUSTO CC,
                           RM.CHISTP            CHISTP
                     WHERE CCR.CAD_CCR_CD_COLIGADA = LAN.CODCOLIGADA
                       AND CCR.CAD_CCR_CD_CONTA = LAN.DEBITO
                       AND LAN.CODCOLIGADA = F.CODCOLIGADA
                       AND LAN.CODFILIAL = F.CODFILIAL
                       AND F.CODFILIAL = DECODE(UNI.CAD_UNI_ID_UNIDADE,
                                                248,
                                                NULL,
                                                UNI.CODFILIAL)
                       AND DECODE(UNI.CAD_UNI_ID_UNIDADE,
                                  248,
                                  244,
                                  UNI.CAD_UNI_ID_UNIDADE) =
                           UNI.CAD_UNI_ID_UNIDADE
                       AND LAN.CODCCUSTO = CC.CAD_CEC_CD_CCUSTO(+)
                       AND LAN.CODCOLIGADA = 1
                       AND TO_CHAR(LAN.DATA, 'YYYY') = P_ANOFAT
                       AND LAN.CODLOTE = 0
                       AND TO_CHAR(LAN.DATA, 'MM') = P_MESFAT
                       AND LAN.CODCOLIGADA = CHISTP.CODCOLIGADA(+)
                       AND LAN.CODHISTP = CHISTP.CODHISTP(+)
                       AND NVL(CHISTP.HISTFECHA, 0) = 0
                       AND (LAN.DEBITO LIKE '3%' OR LAN.DEBITO LIKE '4%')
                     GROUP BY TO_CHAR(LAN.DATA, 'YYYY'),
                              TO_CHAR(LAN.DATA, 'MM'),
                              CCR.CAD_CCR_ID,
                              UNI.CAD_UNI_ID_UNIDADE,
                              CC.CAD_CEC_ID_CCUSTO
                    UNION
                    SELECT TO_CHAR(LAN.DATA, 'YYYY') ANO,
                           TO_CHAR(LAN.DATA, 'MM') MES,
                           CCR.CAD_CCR_ID ID_CONTA,
                           UNI.CAD_UNI_ID_UNIDADE ID_UNIDADE,
                           CC.CAD_CEC_ID_CCUSTO ID_CCUSTO,
                           SUM(VALOR) VALOR
                      FROM RM.CPARTIDA          LAN,
                           TB_CAD_CCR_CCONTA_RM    CCR,
                           RM.GFILIAL           F,
                           TB_CAD_UNI_UNIDADE      UNI,
                           TB_CAD_CEC_CENTRO_CUSTO CC,
                           RM.CHISTP            CHISTP
                     WHERE CCR.CAD_CCR_CD_COLIGADA = LAN.CODCOLIGADA
                       AND CCR.CAD_CCR_CD_CONTA = LAN.CREDITO
                       AND LAN.CODCOLIGADA = F.CODCOLIGADA
                       AND LAN.CODFILIAL = F.CODFILIAL
                       AND F.CODFILIAL = DECODE(UNI.CAD_UNI_ID_UNIDADE,
                                                248,
                                                NULL,
                                                UNI.CODFILIAL)
                       AND DECODE(UNI.CAD_UNI_ID_UNIDADE,
                                  248,
                                  244,
                                  UNI.CAD_UNI_ID_UNIDADE) =
                           UNI.CAD_UNI_ID_UNIDADE
                       AND LAN.CODCCUSTO = CC.CAD_CEC_CD_CCUSTO(+)
                       AND LAN.CODCOLIGADA = 1
                       AND TO_CHAR(LAN.DATA, 'YYYY') = P_ANOFAT
                       AND LAN.CODLOTE = 0
                       AND TO_CHAR(LAN.DATA, 'MM') = P_MESFAT
                       AND LAN.CODCOLIGADA = CHISTP.CODCOLIGADA(+)
                       AND LAN.CODHISTP = CHISTP.CODHISTP(+)
                       AND NVL(CHISTP.HISTFECHA, 0) = 0
                       AND (LAN.CREDITO LIKE '3%' OR LAN.CREDITO LIKE '4%')
                     GROUP BY TO_CHAR(LAN.DATA, 'YYYY'),
                              TO_CHAR(LAN.DATA, 'MM'),
                              CCR.CAD_CCR_ID,
                              UNI.CAD_UNI_ID_UNIDADE,
                              CC.CAD_CEC_ID_CCUSTO) SALDO
             GROUP BY SALDO.ANO,
                      SALDO.MES,
                      SALDO.ID_CONTA,
                      SALDO.ID_UNIDADE,
                      SALDO.ID_CCUSTO
            --- MOVTO DA CARGA NO SGS
            UNION ALL
            SELECT M.CTS_MOV_RM_ANO,
                   M.CTS_MOV_RM_MES,
                   M.CAD_CCR_ID,
                   M.CAD_UNI_ID_UNIDADE,
                   M.CAD_CEC_ID_CCUSTO,
                   0.00 VLRM,
                   SUM(M.CTS_MOV_RM_VL_SALDO) TOTAL
              FROM TB_CTS_MOV_MOVIMENTACAO_RM M
             WHERE M.CTS_MOV_RM_ANO = P_ANOFAT
               AND M.CTS_MOV_RM_MES = P_MESFAT
             GROUP BY M.CTS_MOV_RM_ANO,
                      M.CTS_MOV_RM_MES,
                      M.CAD_CCR_ID,
                      M.CAD_UNI_ID_UNIDADE,
                      M.CAD_CEC_ID_CCUSTO) MV
    ------
     WHERE CCR.CAD_CCR_ID = MV.ID_CONTA
       AND MV.ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
       AND MV.ID_CCUSTO = CEC.CAD_CEC_ID_CCUSTO(+)
     GROUP BY CCR.CAD_CCR_ID,
              CCR.CAD_CCR_CD_CONTA,
              CCR.CAD_CCR_DS_DESCRICAO,
              UNI.CODFILIAL,
              CEC.CAD_CEC_CD_CCUSTO
     ORDER BY ABS(SUM(MV.RM) - SUM(MV.SGS)) DESC, 1;

  IO_CURSOR := V_CURSOR;
END PRC_CTS_14_APOIO_CONF_CARGA_RM;
/
