CREATE OR REPLACE PROCEDURE PRC_REP_REL_SINT_PAGTO_CLI
(
  PREP_PGM_ANOMES_INI           IN STRING DEFAULT NULL,
  PREP_PGM_ANOMES_FIM           IN STRING DEFAULT NULL,
  PCAD_UNI_ID_UNIDADE           IN STRING DEFAULT NULL,
  PCAD_LAT_ID_LOCAL_ATENDIMENTO IN STRING DEFAULT NULL,
  PCAD_TPE_CD_CODIGO            IN TB_REP_PGM_PAGTO_MEDICO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
  PREP_PGM_TP_CREDENCIA_PROF    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL,
  PSEMCONSULTA                  IN STRING DEFAULT 'N',
  PCAD_TAP_TP_ATRIBUTO          IN STRING DEFAULT NULL,
  IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR
)
IS
 /********************************************************************
  *
  *    PROCEDURE: PRC_REP_REL_RESUMO_PAGTO_CLI
  *    DATA 25/01/2012   POR: DAVI S. M. DOS REIS
  *    ALTERAC?O: 03/07/2012 - SORAYA AREAS SOARES
  *              - INCLUS?O TB_REP_RPA_RESUMO E TB_REP_PPC_PROFISSIONAL
  *              - FLAGS REP_PGM_FL_STATUS E REP_PGM_FL_PAGO
  *              - LOGICA SELEC?O
  *    ALTERAC?O: 10/07/2012 - SORAYA AREAS SOARES
  *              - TRATAMENTO HAC E ACS
  *                QUANDO PREP_PGM_TP_CREDENCIA_PROF = NULL, SIGNIFICA QUE IRA TRAZER MF (HAC) E MC (ACS),
  *                    NESSE CASO, SERA UTILIZADO O UNION. PARA N?O DUPLICAR O CODIGO, FOI UTILIZADO UM
  *                    'WHILE', QUE REPETE O MESMO SELECT, ALTERANDO, APENAS O ATRIBUTO PREP_PGM_TP_CREDENCIA_PROF
  *                SE PREP_PGM_TP_CREDENCIA_PROF = MF OU MC, SERA UTILIZADO APENAS O SELECT SEM UNION.
  *    ALTERAC?O: 11/07/2012 - SORAYA AREAS SOARES
  *               - ALTERAC?O PCAD_CNV_ID_CONVENIO PARA PCAD_TPE_CD_CODIGO
  *    ALTERAC?O: 24/07/2012 - SORAYA AREAS SOARES
  *               - INCLUS?O PARAMETROS PSEMCONSULTA, PCAD_TAP_TP_ATRIBUTO
  *               - INCLUS?O DE SELECT DE TAXAS
  *    ALTERAC?O: 07/08/2012 - SORAYA AREAS SOARES
  *               - INCLUS?O PARAMETRO FL_STATUS NA CLAUSULA WHERE DO RESUMO
  *
  *    OBS.: O PARAMETRO PREP_PGM_FL_PAGO = F(FINALIZADO), POIS ESSE RELATORIO SO PODE SER IMPRESSO APOS O FECHAMENTO.
  *
  *    ALTERACAO: 08/03/2016 - FABIOLA R LOPES. - A PEDIDO DA NINA PARA PERMITIR INFORMAR PERIODO
  *               AJUSTADO TAMBEM AO PADRAO QUE UTILIZAMOS
  *
  *********************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
  V_SELECT    VARCHAR2(9000);
  V_SELECT_1  VARCHAR2(5000);
  V_PGM       VARCHAR(2000);
  V_PGM_1     VARCHAR(2000);
  V_RPA       VARCHAR(2000);
  V_PPC       VARCHAR(2000);
  V_WHERE     VARCHAR2(10000);
BEGIN
    V_SELECT := NULL;
    V_PGM    := NULL;
    V_PGM_1  := NULL;
    V_RPA    := NULL;
    V_PPC    := NULL;
    V_WHERE  := NULL;
    -- PARA UTILIZAR COM A TEBELA PGM
    V_PGM :=   /* ' (TO_CHAR( (PGM.REP_PGM_ANO_PAGTO * 100 + PGM.REP_PGM_MES_PAGTO)* 100 + 01) >=  ''' || PREP_PGM_ANOMES_INI || '''
               AND TO_CHAR( (PGM.REP_PGM_ANO_PAGTO * 100 + PGM.REP_PGM_MES_PAGTO)* 100 + 01) <=  ''' || PREP_PGM_ANOMES_FIM || ''')'; */
                '  ((PGM.REP_PGM_ANO_PAGTO || LPAD(PGM.REP_PGM_MES_PAGTO, 2, ''0'')) >=  ''' || PREP_PGM_ANOMES_INI || '''
                AND (PGM.REP_PGM_ANO_PAGTO || LPAD(PGM.REP_PGM_MES_PAGTO, 2, ''0'')) <=  ''' || PREP_PGM_ANOMES_FIM || ''')'; 
                IF PCAD_UNI_ID_UNIDADE IS NOT NULL THEN
                  V_PGM := V_PGM || ' AND PGM.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_UNI_ID_UNIDADE || ''' ))) ';
                END IF;
                IF PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
                  V_PGM := V_PGM || ' AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_LAT_ID_LOCAL_ATENDIMENTO || ''' ))) ';
                END IF;
                IF PCAD_TPE_CD_CODIGO IS NOT NULL THEN
                  V_PGM := V_PGM || ' AND PGM.CAD_TPE_CD_CODIGO = ' || PCAD_TPE_CD_CODIGO;
                END IF;
                IF PSEMCONSULTA = 'S' THEN
                  V_PGM := V_PGM || ' AND PGM.AUX_EPP_CD_ESPECPROC != 101 ';
                END IF;
    -- IF PARA RETORNAR VALORES ZERADOS EM TAX.
    IF PCAD_TAP_TP_ATRIBUTO IS NOT NULL AND INSTR(PCAD_TAP_TP_ATRIBUTO, 'TAX') = 0 THEN
      V_PGM_1 := ' AND 1 = 2 ';
    END IF;
    -- PARA UTILIZAR COM A TABELA RPA
    V_RPA :=    /*' (TO_CHAR( (RESUMO.REP_RPA_ANO_PAGTO * 100 + RESUMO.REP_RPA_MES_PAGTO)* 100 + 01) >= ''' || PREP_PGM_ANOMES_INI || '''
               AND TO_CHAR( (RESUMO.REP_RPA_ANO_PAGTO * 100 + RESUMO.REP_RPA_MES_PAGTO)* 100 + 01) <= ''' || PREP_PGM_ANOMES_FIM || ''')';*/
                '  ((RESUMO.REP_RPA_ANO_PAGTO || LPAD(RESUMO.REP_RPA_MES_PAGTO, 2, ''0'')) >=  ''' || PREP_PGM_ANOMES_INI || '''
                AND (RESUMO.REP_RPA_ANO_PAGTO || LPAD(RESUMO.REP_RPA_MES_PAGTO, 2, ''0'')) <=  ''' || PREP_PGM_ANOMES_FIM || ''')'; 
                IF PCAD_UNI_ID_UNIDADE IS NOT NULL THEN
                  V_RPA := V_RPA || ' AND RESUMO.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_UNI_ID_UNIDADE || ''' ))) ';
                END IF;
    -- PARA UTILIZAR COM A TABELA PPC
    V_PPC :=    /*'(TO_CHAR( (PGPROF.REP_PPC_ANO_PAGTO * 100 + PGPROF.REP_PPC_MES_PAGTO)* 100 + 01) >= ''' || PREP_PGM_ANOMES_INI || '''
                   AND TO_CHAR( (PGPROF.REP_PPC_ANO_PAGTO * 100 + PGPROF.REP_PPC_MES_PAGTO)* 100 + 01) <= ''' || PREP_PGM_ANOMES_FIM || ''')';*/
                '  ((PGPROF.REP_PPC_ANO_PAGTO || LPAD(PGPROF.REP_PPC_MES_PAGTO, 2, ''0'')) >=  ''' || PREP_PGM_ANOMES_INI || '''
                AND (PGPROF.REP_PPC_ANO_PAGTO || LPAD(PGPROF.REP_PPC_MES_PAGTO, 2, ''0'')) <=  ''' || PREP_PGM_ANOMES_FIM || ''')'; 
                IF PCAD_UNI_ID_UNIDADE IS NOT NULL THEN
                  V_PPC := V_PPC || ' AND PGPROF.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_UNI_ID_UNIDADE || ''' ))) ';
                END IF;
                IF PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
                  V_PPC := V_PPC || ' AND PGPROF.CAD_LAT_ID_LOCAL IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_LAT_ID_LOCAL_ATENDIMENTO || ''' ))) ';
                END IF;
    IF (PREP_PGM_TP_CREDENCIA_PROF = 'MC') THEN
      V_SELECT_1 := ' LEFT JOIN (SELECT PGPROF.CAD_CLC_ID CLINE,
                                      SUM(NVL(PGPROF.REP_PPC_VL_HE_PAGO_ACS, 0) + NVL(PGPROF.REP_PPC_VL_PAGO_ACS, 0)) PAGOPROF
                                 FROM TB_REP_PPC_PAG_PROF_CLI PGPROF
                                WHERE ' || V_PPC || '
                                  AND PGPROF.REP_PPC_FL_PAGTO = ' || CHR(39) || 'F' || CHR(39) ||'
                                  AND PGPROF.REP_PPC_TP_CREDENCIA_PROF = ' || CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                             GROUP BY PGPROF.CAD_CLC_ID
                               HAVING SUM(NVL(PGPROF.REP_PPC_VL_HE_PAGO_ACS, 0) + NVL(PGPROF.REP_PPC_VL_PAGO_ACS, 0)) <> 0 ) E
                           ON C.CAD_CLC_ID = E.CLINE ';
    END IF;
    IF (PREP_PGM_TP_CREDENCIA_PROF = 'MF') THEN
      V_SELECT_1 := ' LEFT JOIN (SELECT PGPROF.CAD_CLC_ID CLINE,
                                      SUM(NVL(PGPROF.REP_PPC_VL_HE_PAGO_HAC, 0) + NVL(PGPROF.REP_PPC_VL_PAGO_HAC, 0)) PAGOPROF
                                 FROM TB_REP_PPC_PAG_PROF_CLI PGPROF
                                WHERE ' || V_PPC || '
                                  AND PGPROF.REP_PPC_FL_PAGTO = ' || CHR(39) || 'F' || CHR(39) ||'
                                  AND PGPROF.REP_PPC_TP_CREDENCIA_PROF = ' || CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                             GROUP BY PGPROF.CAD_CLC_ID
                               HAVING SUM(NVL(PGPROF.REP_PPC_VL_HE_PAGO_HAC, 0) + NVL(PGPROF.REP_PPC_VL_PAGO_HAC, 0)) <> 0 ) E
                           ON C.CAD_CLC_ID = E.CLINE ';
    END IF;
    V_WHERE := ' WHERE    NVL(A.CALCHM,    0) <> 0
                       OR NVL(B.CALCEXA,   0) <> 0
                       OR NVL(F.CALCTXA,   0) <> 0
                       OR NVL(A.FATHM,     0) <> 0
                       OR NVL(B.FATEXA,    0) <> 0
                       OR NVL(F.FATTXA,    0) <> 0
                       OR NVL(A.PAGOHM,    0) <> 0
                       OR NVL(B.PAGOEXA,   0) <> 0
                       OR NVL(F.PAGOTXA,   0) <> 0
                       OR NVL(D.PAGOVALOR, 0) <> 0
                       OR NVL(E.PAGOPROF,  0) <> 0
              ORDER BY CAD_CLC_DS_DESCRICAO ';
    V_SELECT := '  SELECT C.CAD_CLC_CD_CLINICA,
                          C.CAD_CLC_DS_DESCRICAO CAD_CLC_DS_DESCRICAO,
                          ' ||  CHR(39) || PREP_PGM_TP_CREDENCIA_PROF ||  CHR(39) || ' REP_PGM_TP_CREDENCIA_PROF,
                          NVL(A.CALCHM, 0) CALCHM,
                          NVL(B.CALCEXA, 0) CALCEXA,
                          NVL(F.CALCTXA, 0) CALCTXA,
                          NVL(A.CALCHM, 0) + NVL(B.CALCEXA, 0) + NVL(F.CALCTXA, 0) TOTAL_CALCULADO,
                          NVL(A.FATHM, 0) FATHM,
                          NVL(B.FATEXA, 0) FATEXA,
                          NVL(F.FATTXA, 0) FATTXA,
                          NVL(A.FATHM, 0) + NVL(B.FATEXA, 0) + NVL(F.FATTXA, 0) TOTAL_FATURADO,
                          NVL(A.PAGOHM, 0) PAGOHM,
                          NVL(B.PAGOEXA, 0) PAGOEXA,
                          NVL(F.PAGOTXA, 0) PAGOTXA,
                          NVL(D.PAGOVALOR, 0) + NVL(E.PAGOPROF, 0) PAGOVALOR,
                          DECODE(C.CAD_CLC_CT_EMPRESA, ' || CHR(39) || 'SC' || CHR(39) ||', ' || CHR(39) || 'SANTOS CLINICA'  || CHR(39) ||',
                                                       ' || CHR(39) || 'ES' || CHR(39) ||', ' || CHR(39) || 'ESSENCIAL'       || CHR(39) ||',
                                                       ' || CHR(39) || 'CE' || CHR(39) ||', ' || CHR(39) || 'CLINICA EXTERNA' || CHR(39) ||',
                                                       ' || CHR(39) || 'GE' || CHR(39) ||', ' || CHR(39) || 'GESTÃO' || CHR(39) ||',
                                                       ' || CHR(39) || 'CI' || CHR(39) ||', ' || CHR(39) || 'CLINICA INTERNA' || CHR(39) ||'  ) CAD_CLC_CT_EMPRESA
                     FROM TB_CAD_CLC_CLINICA_CREDENCIADA C
                     LEFT JOIN (SELECT PGM.CAD_CLC_ID CLINA,
                                       SUM(PGM.REP_PGM_VL_CALCULADO) CALCHM,
                                       SUM(PGM.REP_PGM_VL_FATURADO) FATHM,
                                       SUM(PGM.REP_PGM_VL_PAGO) PAGOHM
                                  FROM TB_REP_PGM_PAGTO_MEDICO PGM
                                 WHERE ' || V_PGM || V_PGM_1 ||'
                                   AND PGM.REP_PGM_FL_PAGO = ' || CHR(39) || 'F' || CHR(39) ||'
                                   AND PGM.REP_PGM_FL_STATUS = ' || CHR(39) || 'A' || CHR(39) ||'
                                   AND PGM.CAD_TAP_TP_ATRIBUTO = ' || CHR(39) || 'HM' || CHR(39) ||'
                                   AND PGM.REP_PGM_TP_CREDENCIA_PROF = ' || CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                                 GROUP BY PGM.CAD_CLC_ID
                                 HAVING NVL(SUM(PGM.REP_PGM_VL_CALCULADO), 0) + NVL(SUM(PGM.REP_PGM_VL_FATURADO), 0) + NVL(SUM(PGM.REP_PGM_VL_PAGO), 0) <> 0)  A
                       ON C.CAD_CLC_ID = A.CLINA
                     LEFT JOIN (SELECT PGM.CAD_CLC_ID CLINB,
                                       SUM(PGM.REP_PGM_VL_CALCULADO) CALCEXA,
                                       SUM(PGM.REP_PGM_VL_FATURADO) FATEXA,
                                       SUM(PGM.REP_PGM_VL_PAGO) PAGOEXA
                                  FROM TB_REP_PGM_PAGTO_MEDICO PGM
                                 WHERE ' || V_PGM || '
                                   AND PGM.REP_PGM_FL_PAGO = ' || CHR(39) || 'F' || CHR(39) ||'
                                   AND PGM.REP_PGM_FL_STATUS = ' || CHR(39) || 'A' || CHR(39) ||'
                                   AND PGM.CAD_TAP_TP_ATRIBUTO = ' || CHR(39) || 'EXA' || CHR(39) ||'
                                   AND PGM.REP_PGM_TP_CREDENCIA_PROF = ' || CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                                 GROUP BY PGM.CAD_CLC_ID
                                 HAVING NVL(SUM(PGM.REP_PGM_VL_CALCULADO), 0) + NVL(SUM(PGM.REP_PGM_VL_FATURADO), 0) + NVL(SUM(PGM.REP_PGM_VL_PAGO), 0) <> 0) B
                       ON C.CAD_CLC_ID = B.CLINB
                     LEFT JOIN (SELECT PGM.CAD_CLC_ID CLINF,
                                       SUM(PGM.REP_PGM_VL_CALCULADO) CALCTXA,
                                       SUM(PGM.REP_PGM_VL_FATURADO) FATTXA,
                                       SUM(PGM.REP_PGM_VL_PAGO) PAGOTXA
                                  FROM TB_REP_PGM_PAGTO_MEDICO PGM
                                 WHERE ' || V_PGM || '
                                   AND PGM.REP_PGM_FL_PAGO = ' || CHR(39) || 'F' || CHR(39) ||'
                                   AND PGM.REP_PGM_FL_STATUS = ' || CHR(39) || 'A' || CHR(39) ||'
                                   AND PGM.CAD_TAP_TP_ATRIBUTO = ' || CHR(39) || 'TAX' || CHR(39) ||'
                                   AND PGM.REP_PGM_TP_CREDENCIA_PROF = ' || CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                                 GROUP BY PGM.CAD_CLC_ID
                                 HAVING NVL(SUM(PGM.REP_PGM_VL_CALCULADO), 0) + NVL(SUM(PGM.REP_PGM_VL_FATURADO), 0) + NVL(SUM(PGM.REP_PGM_VL_PAGO), 0) <> 0) F
                       ON C.CAD_CLC_ID = F.CLINF
                     LEFT JOIN (SELECT RESUMO.CAD_CLC_ID CLIND,
                                       SUM(NVL(RESUMO.REP_RPA_VL_ACRESCIMO, 0) - NVL(RESUMO.REP_RPA_VL_DESCONTO, 0)) PAGOVALOR
                                  FROM TB_REP_RPA_RESUMO_PAGTO RESUMO
                                 WHERE ' || V_RPA || '
                                   AND RESUMO.REP_RPA_TP_CREDENCIA_PROF = ' || CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                                   AND RESUMO.REP_RPA_FL_STATUS = ' || CHR(39) || 'A' || CHR(39) ||'
                                 GROUP BY RESUMO.CAD_CLC_ID
                                 HAVING SUM(NVL(RESUMO.REP_RPA_VL_ACRESCIMO, 0) - NVL(RESUMO.REP_RPA_VL_DESCONTO, 0)) <> 0 ) D
                       ON C.CAD_CLC_ID = D.CLIND
                    ' || V_SELECT_1 || V_WHERE ;
    DBMS_OUTPUT.PUT_LINE(V_SELECT);
    OPEN V_CURSOR FOR
         V_SELECT;
    IO_CURSOR := V_CURSOR;
END PRC_REP_REL_SINT_PAGTO_CLI;