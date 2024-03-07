CREATE OR REPLACE PROCEDURE "PRC_REP_EXA_REA_FORA_PROT_ESP"
(
  P_CAD_PRO_ID_PROFISSIONAL STRING DEFAULT NULL,
  P_TIS_CBO_CD_CBOS         STRING DEFAULT NULL,
  P_CBO                     STRING DEFAULT NULL,
  P_CBO_EXCECAO             STRING DEFAULT NULL,
  P_DATA_INICIO             SADT_PACIENTE.DATEXA%TYPE DEFAULT NULL,
  P_DATA_FIM                SADT_PACIENTE.DATEXA%TYPE DEFAULT NULL,
  P_TOTAL_VALEXA_PROF       NUMBER DEFAULT NULL,
  IO_CURSOR                 OUT PKG_CURSOR.T_CURSOR
)
IS
  V_CURSOR            PKG_CURSOR.T_CURSOR;
  V_SELECT_3         VARCHAR2(9000);
  V_WHERE_3          VARCHAR2(9000);
  V_GROUP_3          VARCHAR2(1000);
  V_HAVING_3         VARCHAR2(1000);
  V_ORDER_3          VARCHAR2(1000);
BEGIN
  -- WHERE
  IF P_CBO_EXCECAO IS NOT NULL AND P_CBO IS NULL AND P_CAD_PRO_ID_PROFISSIONAL IS NULL AND P_TIS_CBO_CD_CBOS IS NULL THEN
    V_WHERE_3 := V_WHERE_3 || ' AND ATD.CAD_PRO_ID_PROF_EXEC  NOT IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || P_CBO_EXCECAO || '''))) ';
  END IF;
  IF P_CBO IS NOT NULL AND P_CBO_EXCECAO IS NULL AND P_CAD_PRO_ID_PROFISSIONAL IS NULL AND P_TIS_CBO_CD_CBOS IS NULL THEN
    V_WHERE_3 := V_WHERE_3 || ' AND ATD.CAD_PRO_ID_PROF_EXEC||ATD.TIS_CBO_CD_CBOS   IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || P_CBO || '''))) ';
  END IF;
  IF P_TIS_CBO_CD_CBOS IS NOT NULL AND P_CBO_EXCECAO IS NULL AND P_CAD_PRO_ID_PROFISSIONAL IS NULL AND P_CBO IS NULL THEN
    V_WHERE_3 := V_WHERE_3 || ' AND ATD.TIS_CBO_CD_CBOS  IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || P_TIS_CBO_CD_CBOS || '''))) ';
  END IF;
  IF P_CAD_PRO_ID_PROFISSIONAL IS NOT NULL AND P_CBO_EXCECAO IS NULL AND P_TIS_CBO_CD_CBOS IS NULL AND P_CBO IS NULL THEN
    V_WHERE_3 := V_WHERE_3 || ' AND ATD.CAD_PRO_ID_PROF_EXEC  IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || P_CAD_PRO_ID_PROFISSIONAL || '''))) ';
  END IF;
  -- HAVING
  IF P_TOTAL_VALEXA_PROF IS NOT NULL THEN
    V_HAVING_3 := ' HAVING SUM(CCI.FAT_CCI_VL_FATURADO) > ' || P_TOTAL_VALEXA_PROF ;
  END IF;
V_SELECT_3 := ' SELECT TO_NUMBER(PRO.CAD_PRO_NR_CONSELHO) CRM,
                       PES_PRO.CAD_PES_NM_PESSOA PROFISSIONAL,
                       SP.CODEXA CODEXA,
                       SE.DESEXA DESEXA,
                       COUNT(CCI.FAT_CCI_QT_CONSUMO) QUANTIDADE,
                       SUM(CCI.FAT_CCI_VL_FATURADO) VALEXA,
                       CLC.CAD_CLC_CD_CLINICA,
                       CLC.CAD_CLC_DS_DESCRICAO
                  FROM SADT_PACIENTE SP,
                       SADT_EXAMES_PACIENTE SEP,
                       SADT_EXAME SE,
                       SADT_PROCEDENCIA SPRO,
                       TB_ATD_ATE_ATENDIMENTO ATD,
                       TB_ASS_PAT_PACIEATEND PAT,
                       TB_CAD_PAC_PACIENTE PAC,
                       TB_CAD_PLA_PLANO PLA,
                       TB_CAD_PRO_PROFISSIONAL PRO,
                       TB_CAD_PES_PESSOA PES_PRO,
                       TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                       TB_FAT_MCC_MOV_COM_CONSUMO  MCC,
                       TB_FAT_CCI_CONTA_CONSU_ITEM CCI,
                       TB_CAD_PRD_PRODUTO          PRD
                 WHERE SP.CODUNIHOS = SEP.CODUNIHOS
                   AND SP.CODUNISAD = SEP.CODUNISAD
                   AND SP.CODEXA = SEP.CODEXA
                   AND SEP.CODUNISAD = SE.CODUNISAD
                   AND SEP.CODMNE = SE.CODMNE
                   AND SP.CD_PROCED = SPRO.CD_PROCED
                   AND SP.CODATEAMB = ATD.ATD_ATE_ID
                   AND PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
                   AND PAT.CAD_PAC_ID_PACIENTE = FNC_BUSCAR_PACIENTE_ATUAL(ATD.ATD_ATE_ID)
                   AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
                   AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
                   AND SP.CODCON = PLA.CAD_PLA_CD_PLANO_HAC
                   AND PRO.CAD_PES_ID_PESSOA = PES_PRO.CAD_PES_ID_PESSOA
                   AND TO_CHAR(SP.CODMED) = TO_CHAR(PRO.CAD_PRO_NR_CONSELHO)
                   AND SP.CODATEAMB = MCC.ATD_ATE_ID
                   AND MCC.ATD_ATE_ID = CCI.ATD_ATE_ID
                   AND MCC.FAT_MCC_ID = CCI.FAT_MCC_ID
                   AND CCI.CAD_PRD_ID = PRD.CAD_PRD_ID
                   AND TRUNC(SP.DATEXA) = TRUNC(CCI.FAT_CCI_DT_INICIO_CONSUMO)
                   AND DECODE(TO_CHAR(SE.CD_TUSS), NULL, TO_CHAR(SE.CODATOMED), TO_CHAR(SE.CD_TUSS)) = TRIM(PRD.CAD_PRD_CD_CODIGO)
                   AND SP.CODUNISAD = ' || CHR(39) ||'L'|| CHR(39) || '
                   AND MCC.FAT_TCO_ID = 182
                   AND CCI.FAT_CCI_FL_STATUS = ' || CHR(39) ||'A'|| CHR(39) || '
                   AND PRD.TIS_MED_CD_TABELAMEDICA IN (' || CHR(39) ||'16'|| CHR(39) || ' , ' || CHR(39) ||'0'|| CHR(39) || ' )
                   AND SP.CD_PROCED != 999
                   AND PLA.CAD_PLA_CD_TIPOPLANO IN (' || CHR(39) ||'GB'|| CHR(39) || ' , ' || CHR(39) ||'PL'|| CHR(39) || ' )
                   AND SEP.FL_PROTOCOLO = ' || CHR(39) ||'N'|| CHR(39) || '
                   AND (SEP.FL_JUSTIFICATIVA != ' || CHR(39) ||'S'|| CHR(39) || ' OR SEP.FL_JUSTIFICATIVA IS NULL)
                   AND SPRO.LOCAL NOT LIKE ' || CHR(39) ||'PS%'|| CHR(39) || '
                   AND PRO.TIS_CPR_CD_CONSELHOPROF = ' || CHR(39) ||'CRM'|| CHR(39) || '
                   AND PRO.CAD_PRO_NR_CONSELHO NOT IN ( ' || CHR(39) ||'77225'|| CHR(39) || ', ' || CHR(39) ||'33377'|| CHR(39) || ' , ' || CHR(39) ||'90904'|| CHR(39) || ' , ' || CHR(39) ||'75050'|| CHR(39) || ' )
                   AND (SE.IN_ANEXO <> ' || CHR(39) ||'S'|| CHR(39) || ' OR SE.IN_ANEXO IS NULL)
                   AND SP.DATEXA >= ' || CHR(39) || P_DATA_INICIO || CHR(39) || '
                   AND SP.DATEXA <= ' || CHR(39) || P_DATA_FIM || CHR(39) || '
                   AND CLC.CAD_CLC_ID(+) = SGS.FNC_OBTER_CLINICA_PROF(PRO.CAD_PRO_ID_PROFISSIONAL, SP.DATEXA)
                   AND ATD.ATD_ATE_TP_PACIENTE <> ' || CHR(39) ||'I'|| CHR(39) || '
                   AND CCI.FAT_CCI_ID = (SELECT MAX(X.FAT_CCI_ID) 
                                           FROM TB_FAT_CCI_CONTA_CONSU_ITEM X
                                          WHERE X.ATD_ATE_ID = ATD.ATD_ATE_ID
                                            AND TRUNC(X.FAT_CCI_DT_INICIO_CONSUMO) = TRUNC(SP.DATEXA)
                                            AND X.FAT_CCI_FL_STATUS = ' || CHR(39) ||'A'|| CHR(39) || '
                                            AND X.CAD_PRD_ID = PRD.CAD_PRD_ID) ';
V_GROUP_3 := ' GROUP BY PRO.CAD_PRO_NR_CONSELHO,
                        PES_PRO.CAD_PES_NM_PESSOA,
                        SP.CODEXA,
                        SE.DESEXA,
                        CLC.CAD_CLC_CD_CLINICA,
                        CLC.CAD_CLC_DS_DESCRICAO ';
V_ORDER_3 := ' ORDER BY PES_PRO.CAD_PES_NM_PESSOA ';
 OPEN V_CURSOR FOR
--   'select * from dual';
    V_SELECT_3 || V_WHERE_3 || V_GROUP_3 || V_HAVING_3 || V_ORDER_3;
 BEGIN
--  dbms_output.put_line( V_SELECT_3 || V_WHERE_3 || V_GROUP_3 || V_HAVING_3 || V_ORDER_3 );
  IO_CURSOR := V_CURSOR;
 END;
END  PRC_REP_EXA_REA_FORA_PROT_ESP;
