CREATE OR REPLACE PROCEDURE PRC_REP_REL_RESUMO_PAGTO_CLI (
    pREP_PGM_MES_PAGTO_INI        IN  TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
    pREP_PGM_ANO_PAGTO_INI        IN  TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
    pCAD_UNI_ID_UNIDADE           IN  STRING DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN  STRING DEFAULT NULL,
    pCAD_TPE_CD_CODIGO            IN  TB_REP_PGM_PAGTO_MEDICO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
    pREP_PGM_TP_CREDENCIA_PROF    IN  TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL,
    pSEMCONSULTA                  IN  STRING DEFAULT 'N',
    pCAD_TAP_TP_ATRIBUTO          IN  STRING DEFAULT NULL,
    IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR
)
IS
/********************************************************************
*
*    PROCEDURE: PRC_REP_REL_RESUMO_PAGTO_CLI
*    DATA 25/01/2012   POR: DAVI S. M. DOS REIS
*    ALTERA��O: 03/07/2012 - SORAYA AREAS SOARES
*              - inclus�o TB_REP_RPA_RESUMO e TB_REP_PPC_PROFISSIONAL
*              - FLAGS REP_PGM_FL_STATUS e REP_PGM_FL_PAGO
*              - l�gica sele��o
*    ALTERA��O: 10/07/2012 - SORAYA AREAS SOARES
*              - Tratamento HAC e ACS
*                Quando pREP_PGM_TP_CREDENCIA_PROF = null, significa que ir� trazer MF (HAC) e MC (ACS),
*                    nesse caso, ser� utilizado o UNION. Para n�o duplicar o c�digo, foi utilizado um
*                    'while', que repete o mesmo SELECT, alterando, apenas o atributo pREP_PGM_TP_CREDENCIA_PROF
*                Se pREP_PGM_TP_CREDENCIA_PROF = MF ou MC, ser� utilizado apenas o SELECT sem UNION.
*    ALTERA��O: 11/07/2012 - SORAYA AREAS SOARES
*               - Altera��o pCAD_CNV_ID_CONVENIO para PCAD_TPE_CD_CODIGO
*    ALTERA��O: 24/07/2012 - SORAYA AREAS SOARES
*               - Inclus�o par�metros pSEMCONSULTA, pCAD_TAP_TP_ATRIBUTO
*               - Inclus�o de select de taxas
*    ALTERA��O: 07/08/2012 - SORAYA AREAS SOARES
*               - Inclus�o par�metro FL_STATUS na cl�usula where do resumo
*
*    OBS.: o par�metro pREP_PGM_FL_PAGO = F(finalizado), pois esse relat�rio s� pode ser impresso ap�s o fechamento.
*
*********************************************************************/
----------------------
--
-- VARI�VEIS LOCAIS
--
----------------------
V_CURSOR PKG_CURSOR.T_CURSOR;
-- Vari�vel utilizada para mudar o valor de MC para MF, quando pREP_PGM_TP_CREDENCIA_PROF = null.
V_REP_PGM_TP_CREDENCIA_PROF   varchar(2);
-- Vari�vel utilizada para referenciar HAC(MF) e ACS(MC)
V_HAC_ACS varchar(3);
-- Vari�vel utilizada para repetir o comando SELECT (UNION), quando pREP_PGM_TP_CREDENCIA_PROF = null.
V_Flag integer;
-- Vari�vel utilizada para conter o comando SELECT.
V_SELECT varchar(20000);
BEGIN
----------------------
--
-- FLAG PARA IDENTIFICAR SE O RELAT�RIO � POR (MC) ou (MF) ou (MC e MF)
--
----------------------
 -- If que verifica se � para trazer tudo (MC e MF) ou pREP_PGM_TP_CREDENCIA_PROF selecionado no relat�rio.
 IF pREP_PGM_TP_CREDENCIA_PROF IS NULL THEN
    BEGIN
     -- Inicialmente trar� todas as informa��es para MC (ACS).
     V_REP_PGM_TP_CREDENCIA_PROF := 'MC';
     V_Flag := 1;
    END;
  ELSE
    BEGIN
      V_REP_PGM_TP_CREDENCIA_PROF := pREP_PGM_TP_CREDENCIA_PROF;
      V_Flag := 0;
    END;
  END IF;
  -- V_Flag = 0, significa que foi selecionado MF (HAC) ou MC (ACS).
  -- V_Flag = 1, significa que a escolha foi ambos.
  WHILE V_Flag <=1
    LOOP
      -- Converte MF em HAC e MC em ACS
      IF V_REP_PGM_TP_CREDENCIA_PROF='MF' THEN
        V_HAC_ACS := 'HAC';
      ELSE
        V_HAC_ACS := 'ACS';
      END IF;
----------------------
--
-- MONTAGEM DO SELECT
--
-- clina = cl�nica relacionada a HM  (a)
-- clinb = cl�nica relacionada a EXA (b)
-- clinc = cl�nica relacionada a TAX (c)
-- clind = cl�nica relacionada a ACR�SCIMO E DESCONTO - RESUMO (d)
-- cline = cl�nica relacionada a Horas Extras - PPC (e)
----------------------
      -- APENAS 1 SELECT. NA 1A VEZ V_REP_PGM_TP_CREDENCIA_PROF = MC, DEPOIS � MF
      V_SELECT := V_SELECT || 'SELECT C.CAD_CLC_CD_CLINICA, 
                                      C.CAD_CLC_DS_DESCRICAO CAD_CLC_DS_DESCRICAO,
                                      ' || CHR(39) || V_HAC_ACS || CHR(39) ||' REP_PGM_TP_CREDENCIA_PROF,
                                      NVL(A.CALCHM,  0) CALCHM, 
                                      NVL(B.CALCEXA, 0) CALCEXA,  
                                      NVL(F.CALCTXA, 0) CALCTXA,
                                      NVL(A.CALCHM, 0) + NVL(B.CALCEXA, 0) + NVL(F.CALCTXA, 0) TOTAL_CALCULADO,
                                      NVL(A.FATHM,   0) FATHM, 
                                      NVL(B.FATEXA,  0) FATEXA,   
                                      NVL(F.FATTXA,  0) FATTXA,
                                      NVL(A.FATHM, 0) + NVL(B.FATEXA, 0) + NVL(F.FATTXA, 0) TOTAL_FATURADO,
                                      NVL(A.PAGOHM,  0) PAGOHM, 
                                      NVL(B.PAGOEXA, 0) PAGOEXA,  
                                      NVL(F.PAGOTXA, 0) PAGOTXA,
                                      NVL(D.PAGOVALOR, 0) + NVL(E.PAGOPROF, 0) PAGOVALOR,
                                      DECODE(C.CAD_CLC_CT_EMPRESA, ''SC'', ''SANTOS CLINICA'' ,
                                                                   ''ES'', ''ESSENCIAL'' ,
                                                                    ''GE'', ''GEST�O'' ,
                                                                   ''CE'', ''CLINICA EXTERNA'',
                                                                   ''CI'', ''CLINICA INTERNA'') CAD_CLC_CT_EMPRESA
                                FROM TB_CAD_CLC_CLINICA_CREDENCIADA C
                           LEFT JOIN
                           ( SELECT PGM.CAD_CLC_ID                CLINA,
                                    SUM(PGM.REP_PGM_VL_CALCULADO) CALCHM,
                                    SUM(PGM.REP_PGM_VL_FATURADO)  FATHM,
                                    SUM(PGM.REP_PGM_VL_PAGO)      PAGOHM
                               FROM TB_REP_PGM_PAGTO_MEDICO PGM
                              WHERE PGM.REP_PGM_MES_PAGTO = ' || pREP_PGM_MES_PAGTO_INI || '
                                AND PGM.REP_PGM_ANO_PAGTO = ' || pREP_PGM_ANO_PAGTO_INI;
        -- S� PASSA PELOS IFS, CASO UNIDADE, LOCAL OU TIPO EMPRESA SEJAM SELECIONADOS E TAMB�M PSEMCONSULTA, PCAD_TAP_TP_ATRIBUTO.
        IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN 
          V_SELECT := V_SELECT || ' AND PGM.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_UNI_ID_UNIDADE || ''' ))) ';
        END IF;
        IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN 
          V_SELECT := V_SELECT || ' AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_LAT_ID_LOCAL_ATENDIMENTO || ''' ))) ';
        END IF;
        IF pCAD_TPE_CD_CODIGO IS NOT NULL THEN 
          V_SELECT := V_SELECT || ' AND PGM.CAD_TPE_CD_CODIGO            = ' || pCAD_TPE_CD_CODIGO ;
        END IF;
        IF pSEMCONSULTA = 'S' THEN 
          V_SELECT := V_SELECT || ' AND  PGM.AUX_EPP_CD_ESPECPROC        != 101 ';
        END IF;
        -- IF PARA RETORNAR VALORES ZERADOS EM HM.
        IF pCAD_TAP_TP_ATRIBUTO IS NOT NULL AND INSTR(pCAD_TAP_TP_ATRIBUTO,'HM') = 0 THEN 
          V_SELECT := V_SELECT || ' AND 1                                = 2 ';
        END IF;
        --
        -- CONTINUA��O DA COMPOSI��O DO SELECT.
        --
        V_SELECT := V_SELECT || ' AND PGM.REP_PGM_FL_PAGO           = '  || CHR(39) || 'F'  || CHR(39) || '
                                  AND PGM.REP_PGM_FL_STATUS         = '  || CHR(39) || 'A'  || CHR(39) || '
                                  AND PGM.CAD_TAP_TP_ATRIBUTO       = '  || CHR(39) || 'HM' || CHR(39) || '
                                  AND PGM.REP_PGM_TP_CREDENCIA_PROF = '  || CHR(39) || V_REP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                             GROUP BY PGM.CAD_CLC_ID) A
                                   ON C.CAD_CLC_ID = A.CLINA
                            LEFT JOIN
                            ( SELECT PGM.CAD_CLC_ID                CLINB,
                                     SUM(PGM.REP_PGM_VL_CALCULADO) CALCEXA,
                                     SUM(PGM.REP_PGM_VL_FATURADO)  FATEXA,
                                     SUM(PGM.REP_PGM_VL_PAGO)      PAGOEXA
                                FROM TB_REP_PGM_PAGTO_MEDICO PGM
                               WHERE PGM.REP_PGM_MES_PAGTO =  ' || pREP_PGM_MES_PAGTO_INI || '
                                 AND PGM.REP_PGM_ANO_PAGTO =  ' || pREP_PGM_ANO_PAGTO_INI;
        -- S� PASSA PELOS IFS, CASO UNIDADE, LOCAL OU TIPO EMPRESA SEJAM SELECIONADOS E TAMB�M PSEMCONSULTA, PCAD_TAP_TP_ATRIBUTO.
        IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN 
          V_SELECT := V_SELECT || ' AND PGM.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_UNI_ID_UNIDADE || ''' ))) ';
        END IF;
        IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN 
          V_SELECT := V_SELECT || ' AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_LAT_ID_LOCAL_ATENDIMENTO || ''' ))) ';
        END IF;
        IF pCAD_TPE_CD_CODIGO IS NOT NULL THEN 
          V_SELECT := V_SELECT || ' AND PGM.CAD_TPE_CD_CODIGO            = ' || pCAD_TPE_CD_CODIGO ;
        END IF;
        IF pSEMCONSULTA = 'S' THEN 
          V_SELECT := V_SELECT || ' AND PGM.AUX_EPP_CD_ESPECPROC         != 101 ';
        END IF;
        -- IF PARA RETORNAR VALORES ZERADOS EM EXA.
        IF pCAD_TAP_TP_ATRIBUTO IS NOT NULL AND INSTR(pCAD_TAP_TP_ATRIBUTO,'EXA') = 0 THEN 
          V_SELECT := V_SELECT || ' AND 1                                = 2 ';
        END IF;
        --
        -- CONTINUA��O DA COMPOSI��O DO SELECT.
        --
        V_SELECT := V_SELECT || ' AND PGM.REP_PGM_FL_PAGO           =  ' || CHR(39) || 'F'                         || CHR(39) || '
                                  AND PGM.REP_PGM_FL_STATUS         =  ' || CHR(39) || 'A'                         || CHR(39) || '
                                  AND PGM.CAD_TAP_TP_ATRIBUTO       =  ' || CHR(39) || 'EXA'                       || CHR(39) || '
                                  AND PGM.REP_PGM_TP_CREDENCIA_PROF =  ' || CHR(39) || V_REP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                             GROUP BY PGM.CAD_CLC_ID) B
                                   ON C.CAD_CLC_ID = B.CLINB
                            LEFT JOIN
                            ( SELECT PGM.CAD_CLC_ID                CLINF,
                                     SUM(PGM.REP_PGM_VL_CALCULADO) CALCTXA,
                                     SUM(PGM.REP_PGM_VL_FATURADO)  FATTXA,
                                     SUM(PGM.REP_PGM_VL_PAGO)      PAGOTXA
                                FROM TB_REP_PGM_PAGTO_MEDICO PGM
                               WHERE PGM.REP_PGM_MES_PAGTO =  ' || pREP_PGM_MES_PAGTO_INI || '
                                 AND PGM.REP_PGM_ANO_PAGTO =  ' || pREP_PGM_ANO_PAGTO_INI;
        -- S� PASSA PELOS IFS, CASO UNIDADE, LOCAL OU TIPO EMPRESA SEJAM SELECIONADOS E TAMB�M PSEMCONSULTA, PCAD_TAP_TP_ATRIBUTO.
        IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN 
          V_SELECT := V_SELECT || ' AND PGM.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_UNI_ID_UNIDADE || ''' ))) ';
        END IF;
        IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN 
          V_SELECT := V_SELECT || ' AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_LAT_ID_LOCAL_ATENDIMENTO || ''' ))) ';
        END IF;
        IF pCAD_TPE_CD_CODIGO IS NOT NULL THEN 
          V_SELECT := V_SELECT || ' AND PGM.CAD_TPE_CD_CODIGO            = ' || pCAD_TPE_CD_CODIGO ;
        END IF;
        IF pSEMCONSULTA = 'S' THEN 
          V_SELECT := V_SELECT || ' AND PGM.AUX_EPP_CD_ESPECPROC         != 101 ';
        END IF;
        -- IF PARA RETORNAR VALORES ZERADOS EM TAX.
        IF pCAD_TAP_TP_ATRIBUTO IS NOT NULL AND INSTR(pCAD_TAP_TP_ATRIBUTO,'TAX') = 0 THEN 
          V_SELECT := V_SELECT || ' AND 1                                         = 2 ';
        END IF;
        --
        -- CONTINUA��O DA COMPOSI��O DO SELECT.
        --
        V_SELECT := V_SELECT || ' AND PGM.REP_PGM_FL_PAGO              =  '  || CHR(39) || 'F'   || CHR(39) || '
                                  AND PGM.REP_PGM_FL_STATUS            =  '  || CHR(39) || 'A'   || CHR(39) || '
                                  AND PGM.CAD_TAP_TP_ATRIBUTO          =  '  || CHR(39) || 'TAX' || CHR(39) || '
                                  AND PGM.REP_PGM_TP_CREDENCIA_PROF    =  '  || CHR(39) || V_REP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                            GROUP BY PGM.CAD_CLC_ID) F
                               ON C.CAD_CLC_ID = F.CLINF
                           LEFT JOIN
                           ( SELECT RESUMO.CAD_CLC_ID                                                             CLIND,
                                    SUM(NVL(RESUMO.REP_RPA_VL_ACRESCIMO, 0) - NVL(RESUMO.REP_RPA_VL_DESCONTO, 0)) PAGOVALOR
                               FROM TB_REP_RPA_RESUMO_PAGTO RESUMO
                              WHERE RESUMO.REP_RPA_MES_PAGTO = ' || pREP_PGM_MES_PAGTO_INI ||'
                                AND RESUMO.REP_RPA_ANO_PAGTO = ' || pREP_PGM_ANO_PAGTO_INI;
                            -- S� PASSA PELO IF, CASO UNIDADE SEJA SELECIONADO.
                              IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN 
                                V_SELECT := V_SELECT || ' AND RESUMO.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_UNI_ID_UNIDADE || ''' ))) ';
                              END IF;
            --
            -- CONTINUA��O DA COMPOSI��O DO SELECT.
            --
        V_SELECT := V_SELECT || ' AND RESUMO.REP_RPA_TP_CREDENCIA_PROF = ' || CHR(39) || V_REP_PGM_TP_CREDENCIA_PROF || CHR(39) || '
                                  AND RESUMO.REP_RPA_FL_STATUS         = ' || CHR(39) || 'A'   || CHR(39) || '
                            GROUP BY RESUMO.CAD_CLC_ID) D
                                  ON C.CAD_CLC_ID = D.CLIND
                           LEFT JOIN
                           ( SELECT PGPROF.CAD_CLC_ID                                                                CLINE,
                                    DECODE(' || CHR(39) || V_REP_PGM_TP_CREDENCIA_PROF || CHR(39) || ' ,
                                    ' || CHR(39) || 'MF' || CHR(39) || ',
                                    SUM(NVL(PGPROF.REP_PPC_VL_HE_PAGO_HAC, 0) + NVL(PGPROF.REP_PPC_VL_PAGO_HAC, 0)),
                                    ' || CHR(39) || 'MC' || CHR(39) || ',
                                    SUM(NVL(PGPROF.REP_PPC_VL_HE_PAGO_ACS, 0) + NVL(PGPROF.REP_PPC_VL_PAGO_ACS, 0))) PAGOPROF
                               FROM TB_REP_PPC_PAG_PROF_CLI PGPROF
                              WHERE PGPROF.REP_PPC_MES_PAGTO = ' || pREP_PGM_MES_PAGTO_INI ||'
                                AND PGPROF.REP_PPC_ANO_PAGTO = ' || pREP_PGM_ANO_PAGTO_INI;
       --
       -- S� PASSA PELOS IFS, CASO UNIDADE E/OU LOCAL SEJAM SELECIONADOS.
       --
       IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN 
         V_SELECT := V_SELECT || ' AND PGPROF.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_UNI_ID_UNIDADE || ''' ))) ';
       END IF;
       IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN 
         V_SELECT := V_SELECT || ' AND PGPROF.CAD_LAT_ID_LOCAL IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_LAT_ID_LOCAL_ATENDIMENTO || ''' ))) ';
       END IF;
       --
       -- CONTINUA��O DA COMPOSI��O DO SELECT COM A CL�USULA WHERE.
       --
       V_SELECT := V_SELECT || ' AND PGPROF.REP_PPC_FL_PAGTO = ' || CHR(39) || 'F'  || CHR(39) || '
                            GROUP BY PGPROF.CAD_CLC_ID) E
                                  ON C.CAD_CLC_ID = E.CLINE
                               WHERE NVL(A.CALCHM,    0) <> 0 
                                  OR NVL(B.CALCEXA,   0) <> 0  
                                  OR NVL(F.CALCTXA,   0) <> 0 
                                  OR NVL(A.FATHM,     0) <> 0 
                                  OR NVL(B.FATEXA,    0) <> 0  
                                  OR NVL(F.FATTXA,    0) <> 0 
                                  OR NVL(A.PAGOHM,    0) <> 0 
                                  OR NVL(B.PAGOEXA,   0) <> 0  
                                  OR NVL(F.PAGOTXA,   0) <> 0 
                                  OR NVL(D.PAGOVALOR, 0) <> 0 
                                  OR NVL(E.PAGOPROF,  0) <> 0' ;
      -- V_Flag = 0, SIGNIFICA QUE FOI SELECIONADO MF (HAC) OU MC (ACS).
      -- V_Flag = 1, SIGNIFICA QUE A ESCOLHA FOI AMBOS.
      -- V_Flag = 2, PARA SAIR DO WHILE.
      if V_Flag = 0 then
        V_Flag := 2;
      ELSE
        BEGIN
           --       
           -- CASO PREP_PGM_TP_CREDENCIA_PROF = NULL, PASSA POR AQUI PARA COMPOR O UNION.
           --
           V_REP_PGM_TP_CREDENCIA_PROF := 'MF';
           V_SELECT := V_SELECT || ' UNION ';
           -- V_FLAG = 0, PARA SAIR DO WHILE AP�S COMPOR A 2A PARTE DO SELECT.
           V_Flag := 0;
        END;
      END IF;
   END LOOP;
   DBMS_OUTPUT.PUT_LINE (V_SELECT);
   V_SELECT := V_SELECT || ' ORDER BY CAD_CLC_DS_DESCRICAO, REP_PGM_TP_CREDENCIA_PROF' ;
   OPEN V_CURSOR FOR V_SELECT;
   IO_CURSOR := V_CURSOR;
END PRC_REP_REL_RESUMO_PAGTO_CLI;