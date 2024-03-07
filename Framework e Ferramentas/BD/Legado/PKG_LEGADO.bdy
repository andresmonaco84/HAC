CREATE OR REPLACE PACKAGE BODY SGS.PKG_LEGADO is
  --
  --
  --************************************************************--
  --
  PROCEDURE GRAVAR_ITEM_CONTA(PCODUNIHOS IN NUMBER,
                              PCODPAC    IN NUMBER,
                              PCODATE    IN NUMBER,
                              PCODATO    IN NUMBER,
                              PQTD       IN NUMBER,
                              PCODMED    IN NUMBER,
                              PPERC      IN NUMBER,
                              PRETORNO   OUT NUMBER,
                              PMSG       OUT VARCHAR2) IS
    vn_codser       NUMBER(2);
    vn_valcspamb    NUMBER(12, 2);
    vn_codtipate    NUMBER(2);
    vn_retorno      NUMBER(1);
    vn_codatomed    NUMBER(8);
    vn_codmed       NUMBER(9);
    vn_qtdch        NUMBER(10, 4);
    vn_vlrch        NUMBER(15, 3);
    vn_percent      NUMBER(5, 2);
    vn_valor        NUMBER(12, 2);
    vn_vlfilme      NUMBER(12, 2);
    vn_vltaxa       NUMBER(12, 2);
    vn_codclacon    NUMBER(4);
    vn_perext       NUMBER(12, 2);
    vn_calculado    NUMBER(12, 2);
    vn_vltxadm      NUMBER(12, 2);
    vn_sequencia    NUMBER(2);
    vn_teste        NUMBER(12);
    vs_codcon       VARCHAR2(4);
    vs_credenciado  VARCHAR2(1);
    vs_indclacon    VARCHAR2(1);
    vs_codtipemp    VARCHAR2(2);
    vs_codpad       VARCHAR2(3);
    vs_codindhos    VARCHAR2(4);
    vs_codtab       VARCHAR2(2);
    vs_codloc       VARCHAR2(3);
    vs_codespmed    VARCHAR2(3);
    vs_emitida      VARCHAR2(1);
    vs_faturada     VARCHAR2(1);
    vs_codsitate    VARCHAR2(1);
    vs_horate       VARCHAR2(4);
    vd_datate       DATE;
    vs_local        VARCHAR2(3);
    vn_centro_custo NUMBER(2);
    vn_perc_hosp    NUMBER(5, 2);
    vs_inmedcred    VARCHAR2(2);
    vn_cd_clinica   NUMBER(4);
    vn_base_repasse NUMBER(12, 2);
    vn_mesfat       NUMBER(2);
    vn_anofat       NUMBER(4);
    vs_cd_conselho  COM_CONSELHO_PROFISSIONAL.CD_CONS_PROF%TYPE;
    vs_cd_prof      TB_PROFISSIONAL.CD_PROF%TYPE;
    vs_sg_uf_prof   TB_PROFISSIONAL.SG_UF_PROF%TYPE;
    --
  BEGIN
    pretorno := 0;
    pmsg     := null;
    --------------------------------------------
    -- bloco de verificacoes antes de inserir --
    --------------------------------------------
    -- verifica se o atendimento existe na paciente_atendimento_amb
    BEGIN
      SELECT P.CODCON,
             P.MEDCRE,
             E.CODTIPEMP,
             P.CODTIPATE,
             P.CODPADPAC,
             P.LOCAL,
             P.CODESPMED,
             P.INDEMICONAMB,
             P.INDFATAMB,
             P.CODSITATE,
             P.HORATE,
             P.DATATE,
             P.MESFAT,
             P.ANOFAT,
             ESP.CD_CONS_PROF
        INTO vs_codcon,
             vs_credenciado,
             vs_codtipemp,
             vn_codtipate,
             vs_codpad,
             vs_codloc,
             vs_codespmed,
             vs_emitida,
             vs_faturada,
             vs_codsitate,
             vs_horate,
             vd_datate,
             vn_mesfat,
             vn_anofat,
             vs_cd_conselho
        FROM PACIENTE_ATENDIMENTO_AMB P, EMPRESA E, ESPECIALIDADE ESP
       WHERE P.CODUNIHOS = pcodunihos
         AND P.CODPAC = pcodpac
         AND P.CODATEAMB = pcodate
         AND P.CODCON = E.CODCON
         AND P.CODESPMED = ESP.CODESPMED(+);
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        pretorno := 1;
        pmsg     := 'Este atendimento nao existe';
        RETURN;
    END;
    -- ATUALIZA CAMPOS NOVOS DE PROFISSIONAL --
    IF PCODMED is not null THEN
      IF vs_cd_conselho = 'CRM' THEN
        BEGIN
          SELECT CODMED, UF_MED
            INTO vs_cd_prof, vs_sg_uf_prof
            FROM MEDICO M
           WHERE CODMED = PCODMED;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            pretorno := 1;
            pmsg     := 'Este medico nao existe';
            RETURN;
        END;
      ELSE
        BEGIN
          SELECT PROF.CD_PROF, PROF.SG_UF_PROF
            INTO vs_cd_prof, vs_sg_uf_prof
            FROM TB_PROFISSIONAL PROF
           WHERE CD_PROF = TO_CHAR(PCODMED);
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            pretorno := 1;
            pmsg     := 'Este profissional nao existe';
            RETURN;
        END;
      END IF;
      --
      update paciente_atendimento_amb p
         set CD_CONS_PROF = vs_cd_conselho,
             CD_PROF      = vs_cd_prof,
             SG_UF_PROF   = vs_sg_uf_prof
       WHERE P.CODUNIHOS = pcodunihos
         AND P.CODPAC = pcodpac
         AND P.CODATEAMB = pcodate;
      COMMIT;
    END IF;
    -- inserido em 28/08/2008 -- pra n?o inserir dados de profissionais n?o medicos --
    if vs_cd_conselho != 'CRM' THEN
      pretorno := 0;
      RETURN;
    END IF;
    -- verifica situacao do atendimento
    IF vs_emitida = 'S' THEN
      pretorno := 1;
      pmsg     := 'Conta emitida';
      RETURN;
    ELSIF vs_faturada in ('S', 'I') THEN
      pretorno := 1;
      pmsg     := 'Conta faturada';
      RETURN;
    ELSIF vs_codsitate != 'A' THEN
      pretorno := 1;
      pmsg     := 'Atendimento nao esta ativo';
      RETURN;
    END IF;
    --
    -- atualizacao inserida em 13/04/2005 para que todos os atendimentos do psac
    -- que sco digitados pela consulta de consultorio fiquem com situacao de pendente
    -- para nao constar nas estatisticas
    IF vn_codtipate IN (4, 29) AND vs_codtipemp in ('GB', 'PL') AND
       vs_codcon NOT IN ('G225', 'G226') AND pcodmed != 32908 THEN
      UPDATE PACIENTE_ATENDIMENTO_AMB
         SET CODSITATE = 'P'
       WHERE CODUNIHOS = pcodunihos
         AND CODPAC = pcodpac
         AND CODATEAMB = pcodate;
      COMMIT;
      RETURN;
    END IF;
    --
    --
    --verifica se o codatomed existe na ato_medico
    BEGIN
      SELECT A.CODSER,
             TROCA_INDCLACON(A.CODATOMED, A.INDCLACON),
             RETORNA_ATOMED(pcodato, vs_codcon, vd_datate)
        INTO vn_codser, vs_indclacon, vn_codatomed
        FROM ATO_MEDICO A
       WHERE A.CODATOMED = pcodato;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        pretorno := 1;
        pmsg     := 'Este procedimento nao existe';
        RETURN;
    END;
    --
    --verifica se o medico existe
    IF PCODUNIHOS <> 8 THEN
      BEGIN
        SELECT M.CODMED
          INTO vn_teste
          FROM MEDICO M
         WHERE M.CODMED = pcodmed;
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          pretorno := 1;
          pmsg     := 'Este medico nao existe';
          RETURN;
      END;
    END IF;
    -- verifica parametro de qtde
    IF pqtd = 0 or pqtd is null then
      pretorno := 1;
      pmsg     := 'Quantidade esta zerada ou nulo';
      RETURN;
    END IF;
    --
    -- inserido em 13/04/2005 -- INCLUINDO CONDICOES DE TIPO DE EMPRESA E
    -- TIPO DE ATENDIMENTO EM 08/06/2005 , NAO ESTAVA GERANDO A CONSULTA PARA SP
    IF (pcodato = 10038 OR pcodato = 10047) AND
       (vn_codtipate IN (4, 29) AND vs_codtipemp = 'GB' AND
       vs_codcon NOT IN ('G225', 'G226')) then
      RETURN;
    END IF;
    --
    IF (pcodato in (34010106, 34010017, 8101111) or vn_codser = 0) and
       pqtd != 1 THEN
      pretorno := 1;
      pmsg     := 'Este procedimento so permite quantidade 1';
      RETURN;
    END IF;
    --
    IF vs_codcon in ('G225', 'G226') THEN
      vs_codtipemp := 'SP';
    ELSIF vs_codtipemp = 'GB' and vn_codtipate in (5, 6, 7, 8) THEN
      vs_codtipemp := 'SP';
    ELSIF vs_codtipemp in ('PL', 'GB') THEN
      vs_codtipemp := 'GB';
    END IF;
    --
    IF pcodato = 8101111 and vs_codtipemp = 'GB' THEN
      pretorno := 1;
      pmsg     := 'Taxa nao permitida para este convenio';
      RETURN;
    END IF;
    --
    IF pcodunihos not in (8, 9) and pcodato = 10073 then
      IF vs_codcon != 'SP51' or vn_codtipate != 10 then
        pretorno := 1;
        pmsg     := 'Procedimento nao permitido para este convenio';
        RETURN;
      END IF;
    END IF;
    IF pcodato = 10038 and vn_codtipate != 4 then
      pretorno := 1;
      pmsg     := 'Procedimento nao permitido p/ este tipo de atend.';
      RETURN;
    END IF;
    --
    SELECT COUNT(*)
      INTO vn_teste
      FROM ITEM_CONTA_SP_AMBULATORIO
     WHERE CODPAC = pcodpac
       AND CODUNIHOS = pcodunihos
       AND CODATEAMB = pcodate
       AND CODATOMED = pcodato;
    IF vn_teste > 0 THEN
      pretorno := 1;
      pmsg     := 'Procedimento ja existe neste atendimento';
      RETURN;
    END IF;
    --
    IF vs_indclacon != 'S' THEN
      vn_codmed := 99999;
    ELSE
      vn_codmed := pcodmed;
    END IF;
    --------------------
    -- credenciamento --
    --------------------
    IF vn_codtipate IN (4, 14) THEN
      vs_local := 'CON';
    ELSE
      vs_local := 'AMB';
    END IF;
    ---
    CASE pcodunihos
      WHEN 3 THEN
        vn_centro_custo := 3;
      WHEN 4 THEN
        vn_centro_custo := 4;
      WHEN 5 THEN
        vn_centro_custo := 5;
      WHEN 6 THEN
        vn_centro_custo := 31;
      WHEN 8 THEN
        vn_centro_custo := 32;
      WHEN 9 THEN
        vn_centro_custo := 9;
      WHEN 13 THEN
        vn_centro_custo := 30;
      WHEN 14 THEN
        vn_centro_custo := 65;
      WHEN 15 THEN
        vn_centro_custo := 65;
      WHEN 24 THEN
        vn_centro_custo := 31;
      WHEN 25 THEN
        vn_centro_custo := 31;
    END CASE;
  ---
    DSADT.PKG_CREDENCIA.CALCULA_REPASSE_MEDICO(vn_codmed,
                                               vn_codatomed,
                                               Null,
                                               Null,
                                               vs_codcon,
                                               pcodunihos,
                                               vs_codespmed,
                                               vs_local,
                                               vn_centro_custo,
                                               vd_datate,
                                               vn_perc_hosp,
                                               vs_inmedcred,
                                               vn_cd_clinica);
    --
    VERIFICA_ATOMEDICO_CLINICA(pcodate,
                               vs_codcon,
                               vn_codatomed,
                               'AMB',
                               vd_datate,
                               vn_cd_clinica,
                               vn_retorno);
    IF vn_retorno != 0 OR vn_retorno is null then
      pretorno := 1;
      pmsg     := 'Procedimento nao permitido para este convenio';
      RETURN;
    END IF;
    -------------------------------
    -- calculo do valor do exame --
    -------------------------------
    CALC_EXA_AMB_SADT(vn_codatomed,
                      vs_codcon,
                      vd_datate,
                      pcodunihos,
                      vs_codpad,
                      pcodate,
                      vn_cd_clinica,
                      vs_codindhos,
                      vn_qtdch,
                      vn_vlrch,
                      vn_percent,
                      vn_valor,
                      vs_codtab);
    IF vn_valor is null THEN
      pretorno := 1;
      pmsg     := 'Valor do exame esta zerado';
      RETURN;
    END IF;
    --
    IF vs_codtipemp = 'GB' and vd_datate < to_date('01102003', 'ddmmyyyy') THEN
      DESCONTO_SADT(vn_codatomed,
                    vs_codcon,
                    vn_qtdch,
                    vn_percent,
                    vn_vlrch,
                    vn_valor);
    END IF;
    --
    ----------------------------
    -- calculo do m2 de filme --
    ----------------------------
    CALC_M2_FILME_ITEM(pcodunihos,
                       pcodpac,
                       pcodate,
                       vn_codatomed,
                       vd_datate,
                       vn_vlfilme,
                       vn_vltaxa);
    ----------------------------
    -- CLASSIFICACAO CONTABIL --
    ----------------------------
    CLASSAMB(vn_codatomed,
             vs_codcon,
--             vs_codloc,
             vs_indclacon,
             vn_codser,
             vn_codclacon);
    IF vn_codclacon is null THEN
      pretorno := 1;
      pmsg     := 'Procedimento sem classificacao contabil';
      RETURN;
    ELSIF vn_codclacon = 2100 and pcodunihos not in (13, 3, 5) THEN
      pretorno := 1;
      pmsg     := 'Procedimento nao permitido p/ esta unidade(FISIO)';
      RETURN;
    ELSIF pcodunihos = 13 and vn_codclacon != 5100 THEN
      pretorno := 1;
      pmsg     := 'Procedimento nao permitido p/ esta unidade(FISIO)';
      RETURN;
    END IF;
    --
    vn_valor := vn_valor * pqtd;
    IF PPERC IS NULL or PPERC = 0 THEN
      vn_calculado := vn_valor;
    ELSE
      vn_calculado := vn_valor * pperc;
      vn_valor     := vn_valor * pperc;
    END IF;
    ----------------
    -- HORA EXTRA --
    ----------------
    IF vn_valor != 0 and vn_valor is not null THEN
      CALC_HE_AMB(pcodate,
                  vn_codclacon,
                  vn_codatomed,
                  vs_codtab,
                  vn_perext);
      IF vn_perext is not null and vn_perext != 0 THEN
        vn_calculado := vn_calculado * (1 + vn_perext);
        vn_perext    := vn_perext + 1;
      ELSE
        vn_perext := 1;
      END IF;
    END IF;
    --
    IF vs_inmedcred = 'CR' THEN
      vn_calculado    := 0;
      vn_valcspamb    := 0;
      vn_base_repasse := 0;
    ELSIF vs_inmedcred = 'MF' THEN
      vn_valcspamb    := vn_calculado;
      vn_base_repasse := vn_calculado -
                         (vn_calculado * nvl(vn_perc_hosp, 0));
    ELSIF vs_inmedcred = 'MC' THEN
      IF vs_codtipemp = 'SP' and vs_codcon not in ('G225', 'G226') THEN
        vn_valcspamb    := 0;
        vn_base_repasse := 0;
      ELSE
        vn_valcspamb    := vn_calculado * nvl(vn_perc_hosp, 0);
        vn_base_repasse := vn_calculado - vn_valcspamb;
      END IF;
      
        ----------------------------------------------------------------------------------------------------
    -- zerar HM do val faturado  para medico residente para psac ALTERADO 25-08-09
    ELSIF vs_inmedcred = 'RE'
              AND ( vs_codtipemp = 'GB' OR vs_codtipemp = 'PL') 
              AND vs_codcon not in ('NR14') AND vs_indclacon = 'S'  THEN
      IF nvl(vn_perc_hosp, 0) =  1   THEN
        vn_valcspamb    := 0;
        vn_base_repasse := vn_calculado - vn_valcspamb;
      ELSE
        vn_valcspamb    := vn_calculado * nvl(vn_perc_hosp, 0);
        vn_base_repasse := vn_calculado - vn_valcspamb;
      END IF;
    --
    ------------------------------------------------------------------------------------------------------------- 

    ELSE
      vn_valcspamb    := vn_calculado;
      vn_base_repasse := vn_calculado;
      IF vs_inmedcred = 'PA' THEN
        vs_inmedcred := 'DV';
      END IF;
    END IF;
    --
    vn_vlfilme := vn_vlfilme * pqtd;
    vn_vltaxa  := vn_vltaxa * pqtd;
    -------------------------
    -- TAXA ADMINISTRATIVA --
    -------------------------
    vn_percent := 0;
    select RET_TAXA_ADM(vs_codcon, pcodunihos, 'AMB', 'I', vd_datate)
      into vn_percent
      from dual;
    IF vd_datate >= to_date('26072004', 'ddmmyyyy') THEN
      vn_vltxadm := (nvl(vn_calculado, 0) + nvl(vn_vlfilme, 0) +
                    nvl(vn_vltaxa, 0)) * vn_percent;
    ELSE
      vn_vltxadm := (nvl(vn_valcspamb, 0) + nvl(vn_vlfilme, 0) +
                    nvl(vn_vltaxa, 0)) * vn_percent;
    END IF;
    --
    select nvl(max(SEQITMCTA), 0) + 1
      into vn_sequencia
      from ITEM_CONTA_SP_AMBULATORIO
     where CODATEAMB = pcodate
       and CODPAC = pcodpac
       and CODUNIHOS = pcodunihos
       and CODATOMED not in (15030041, 15030042);
    --
    INSERT INTO ITEM_CONTA_SP_AMBULATORIO
      (CODUNIHOS,
       CODPAC,
       CODATEAMB,
       CODSER,
       CODATOMED,
       DATCSPAMB,
       CODCLACTB,
       HORCSPAMB,
       VALCSPAMB,
       CODMED,
       SEQITMCTA,
       USUARIO,
       QTDCSPAMB,
       PERTOMAMB,
       DT_DIGITACAO,
       VL_HM_CALCULADO,
       VL_HM_ORIGINAL,
       VL_TX_ADM,
       VL_M2_FILME,
       VL_TX_FILME,
       IN_MEDICO_CREDENCIADO,
       CD_CLINICA,
       VL_BASE_REPASSE,
       CODTAB,
       PC_HORA_EXTRA)
    VALUES
      (pcodunihos,
       pcodpac,
       pcodate,
       vn_codser,
       pcodato,
       vd_datate,
       vn_codclacon,
       vs_horate,
       vn_valcspamb,
       vn_codmed,
       vn_sequencia,
       'AUTO_ATEAMB',
       pqtd,
       pperc,
       sysdate,
       vn_calculado,
       vn_valor,
       vn_vltxadm,
       vn_vlfilme,
       vn_vltaxa,
       vs_inmedcred,
       vn_cd_clinica,
       vn_base_repasse,
       vs_codtab,
       vn_perext);
    --
  END GRAVAR_ITEM_CONTA;

  --
  -- ********************************************************************************************************
  --
  FUNCTION TROCA_INDCLACON(pn_codatomed IN NUMBER,
                           ps_indclacon IN VARCHAR2) RETURN VARCHAR2 IS
    vs_indclacon varchar2(1);
  BEGIN
    vs_indclacon := ps_indclacon;
    IF pn_codatomed in (24010014, 45010021, 45010072, 45010102, 45010110) THEN
      vs_indclacon := 'N';
    ELSIF pn_codatomed between 50010000 and 50019999 then
      vs_indclacon := 'N';
    ELSIF pn_codatomed in
          (50020021, 50060015, 50100050, 50100068, 50100084, 50140019) THEN
      vs_indclacon := 'N';
    ELSIF pn_codatomed = 51020017 THEN
      vs_indclacon := 'N';
    ELSIF pn_codatomed in (52230015, 52230023) THEN
      vs_indclacon := 'N';
    ELSIF pn_codatomed BETWEEN 52240000 and 52249999 THEN
      vs_indclacon := 'N';
    ELSIF pn_codatomed BETWEEN 52250000 and 52259999 and
          pn_codatomed NOT IN (52250067, 52250008, 52259999) THEN
      vs_indclacon := 'N';
    ELSIF pn_codatomed IN
          (56010117, 56010125, 56010133, 56010109, 52230015, 52230023) THEN
      vs_indclacon := 'N';
    ELSIF pn_codatomed IN (27030059, 32130040) THEN
      vs_indclacon := 'N';
    END IF;
    RETURN vs_indclacon;
  END TROCA_INDCLACON;

  --
  -- ********************************************************************************************************
  --
  PROCEDURE VERIFICA_ATOMEDICO(pnCodateamb IN NUMBER,
                               psCodcon    IN CHAR,
                               pnCodatomed IN NUMBER,
                               psCodloc    IN VARCHAR2,
                               pd_datexa   IN DATE,
                               pnRetorno   IN OUT NUMBER) IS
    sFlag      CHAR(1);
    nCodser    NUMBER(2);
    sCodtipemp VARCHAR2(2);
    sIndclacon CHAR(1);
    sEntrou    CHAR(1);
    vs_tipo    VARCHAR2(5);
    vs_codtab  VARCHAR2(4);
  BEGIN
    dsadt.Pkg_Sadt.BUSCA_CODSER(pnCodatomed, nCodser);
    IF psCodcon IN ('G225', 'G226') THEN
      sCodtipemp := 'SP';
    ELSE
      sCodtipemp := dsadt.Pkg_Sadt.BUSCA_TIPOEMPRESA(psCodcon);
    END IF;
    Busca_Indclacon(pnCodatomed, sIndclacon);
    sEntrou := NULL;
    sFlag   := NULL;
    IF sCodtipemp NOT IN ('GB', 'PL', 'FU', 'NP') THEN
      IF psCodcon IN ('SZ87', 'SZ78') THEN
        VERIFICA_BRADESCO(psCodcon,
                          pnCodateamb,
                          psCodloc,
                          pd_datexa,
                          vs_tipo);
        IF vs_tipo = 'EMP' THEN
          vs_codtab := 'B2';
        ELSIF vs_tipo = 'IND' THEN
          vs_codtab := 'B1';
        END IF;
        --
        BEGIN
          SELECT DISTINCT 'X'
            INTO sFlag
            FROM ITEM_TABELA
           WHERE codtab = vs_codtab
             AND codatomed = pnCodatomed;
          pnRetorno := 0;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            NULL;
          WHEN TOO_MANY_ROWS THEN
            pnRetorno := 0;
            sFlag     := 'X';
        END;
      END IF;
      --
      IF sFlag IS NULL THEN
        BEGIN
          SELECT 'X'
            into sFlag
            FROM EXCESSAO_ITEM_TABELA_SP_INT E
           WHERE CODCON = psCodcon
             AND CODATOMED = pnCodatomed
             AND DATEXCSP = (SELECT MAX(DATEXCSP)
                               FROM EXCESSAO_ITEM_TABELA_SP_INT X
                              WHERE E.CODCON = X.CODCON
                                AND E.CODATOMED = X.CODATOMED
                                AND E.CODPAD = X.CODPAD
                                AND DATEXCSP <= pd_datexa)
             AND ROWNUM = 1;
          pnRetorno := 0;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            NULL;
        END;
      END IF;
      --
      IF sFlag IS NULL THEN
        --
        FOR TABS IN (SELECT DISTINCT codtab
                       FROM EXCESSAO_PRIORIDADE E1
                      WHERE codcon = psCodcon
                        AND codser = nCodser
                        AND codloc = psCodloc
                        AND (DT_VIGENCIA <= pd_datexa AND
                            DT_FIM >= pd_datexa OR
                            DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL))
        -- DIOGO AQUI
         LOOP
          sEntrou := 'S';
          BEGIN
            SELECT DISTINCT 'X'
              INTO sFlag
              FROM ITEM_TABELA
             WHERE codtab = TABS.codtab
               AND codatomed = pnCodatomed;
            pnRetorno := 0;
            EXIT;
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              BEGIN
                SELECT 'X'
                  into sFlag
                  FROM EXCESSAO_ATOMED_SP
                 WHERE CODCON = psCodcon
                   AND CODATOMED = pnCodatomed
                   AND DATEXCSP =
                       (SELECT MAX(DATEXCSP)
                          FROM EXCESSAO_ATOMED_SP
                         WHERE CODCON = psCodcon
                           AND CODATOMED = pnCodatomed
                           AND DATEXCSP <= TO_DATE(TO_CHAR(pd_datexa)))
                   AND ROWNUM = 1;
                pnRetorno := 0;
                EXIT;
              EXCEPTION
                WHEN NO_DATA_FOUND THEN
                  NULL;
              END;
            WHEN TOO_MANY_ROWS THEN
              pnRetorno := 0;
          END;
        END LOOP;
        IF sEntrou IS NULL THEN
          FOR TABS IN (SELECT DISTINCT codtab
                         FROM PRIORIDADE_TABELAS_SPREST p1
                        WHERE codcon = psCodcon
                          AND codser = nCodser
                          AND codloc = psCodloc
                          AND (DT_VIGENCIA <= pd_datexa AND
                              DT_FIM >= pd_datexa OR
                              DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL))
          --  VERIFICA AQUI, DIOGO,  NAO TEM FILTRO PARA PRIORIDADE
           LOOP
            BEGIN
              SELECT DISTINCT 'X'
                INTO sFlag
                FROM ITEM_TABELA
               WHERE codtab = TABS.codtab
                 AND codatomed = pnCodatomed;
              pnRetorno := 0;
              EXIT;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                BEGIN
                  SELECT 'X'
                    into sFlag
                    FROM EXCESSAO_ATOMED_SP
                   WHERE CODCON = psCodcon
                     AND CODATOMED = pnCodatomed
                     AND DATEXCSP =
                         (SELECT MAX(DATEXCSP)
                            FROM EXCESSAO_ATOMED_SP
                           WHERE CODCON = psCodcon
                             AND CODATOMED = pnCodatomed
                             AND DATEXCSP <= TO_DATE(TO_CHAR(pd_datexa)))
                     AND ROWNUM = 1;
                  pnRetorno := 0;
                  EXIT;
                EXCEPTION
                  WHEN NO_DATA_FOUND THEN
                    NULL;
                END;
              WHEN TOO_MANY_ROWS THEN
                pnRetorno := 0;
            END;
          END LOOP;
        END IF;
      END IF;
    ELSE
      -- GLOBAL AMB --
      IF psCodloc = CGS_LOCAL_AMB THEN
        BEGIN
          sFlag := NULL;
          SELECT 'X'
            into sFlag
            FROM EXCESSAO_ATOMED_SP
           WHERE CODCON = psCodcon
             AND CODATOMED = pnCodatomed
             AND DATEXCSP <= pd_datexa
             AND ROWNUM = 1;
          pnRetorno := 0;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            NULL;
        END;
        --
        IF sFlag is null then
          FOR TABS IN (SELECT 'A1' codtab
                         FROM dual
                        WHERE pd_datexa < TO_DATE('01052008', 'DDMMYYYY')
                       UNION
                       SELECT 'A3'
                         FROM dual
                       UNION
                       SELECT 'H'
                         FROM dual
                        WHERE pd_datexa < TO_DATE('01082003', 'DDMMYYYY')
                       UNION
                       SELECT 'H1'
                         FROM DUAL
                        WHERE pd_datexa between
                              TO_DATE('01082003', 'DDMMYYYY') and
                              TO_DATE('11032007', 'DDMMYYYY')
                       UNION
                       SELECT 'AC'
                         FROM DUAL
                        WHERE pd_datexa >= TO_DATE('12032007', 'DDMMYYYY')) LOOP
            BEGIN
              SELECT DISTINCT 'X'
                INTO sFlag
                FROM ITEM_TABELA
               WHERE codtab = TABS.codtab
                 AND codatomed = pnCodatomed;
              pnRetorno := 0;
              EXIT;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                NULL;
              WHEN TOO_MANY_ROWS THEN
                NULL;
            END;
          END LOOP;
        END IF;
      ELSE
        -- LOCAL INTERNACAO, GLOBAL
        BEGIN
          sFlag := NULL;
          SELECT 'X'
            into sFlag
            FROM EXCESSAO_ITEM_TABELA_SP_INT E
           WHERE CODCON = psCodcon
             AND CODATOMED = pnCodatomed
             AND DATEXCSP = (SELECT MAX(DATEXCSP)
                               FROM EXCESSAO_ITEM_TABELA_SP_INT X
                              WHERE E.CODCON = X.CODCON
                                AND E.CODATOMED = X.CODATOMED
                                AND E.CODPAD = X.CODPAD
                                AND X.DATEXCSP <= pd_datexa)
             AND ROWNUM = 1;
          pnRetorno := 0;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            NULL;
        END;
        --
        IF sFlag is null then
          FOR TABS IN (SELECT DISTINCT codtab
                         FROM PRIORIDADE_GLOBAL
                        WHERE codtipemp = sCodtipemp
                          AND codserini <= nCodser
                          AND codserfim >= nCodser
                          AND indclacon = sIndclacon
                          AND (DT_VIGENCIA <= pd_datexa AND
                              DT_FIM >= pd_datexa OR
                              DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL)
                       UNION
                       SELECT DISTINCT codtab
                         FROM EXCESSAO_PRIORIDADE_GLOBAL
                        WHERE codcon = psCodcon
                          AND codserini <= nCodser
                          AND codserfim >= nCodser
                          AND (DT_VIGENCIA <= pd_datexa AND
                              DT_FIM >= pd_datexa OR
                              DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL)) LOOP
            BEGIN
              SELECT DISTINCT 'X'
                INTO sFlag
                FROM ITEM_TABELA
               WHERE codtab = TABS.codtab
                 AND codatomed = pnCodatomed;
              pnRetorno := 0;
              EXIT;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                NULL;
              WHEN TOO_MANY_ROWS THEN
                NULL;
            END;
          END LOOP;
        END IF;
      END IF;
    END IF;
    IF sFlag IS NULL THEN
      pnRetorno := 1;
    END IF;
  END VERIFICA_ATOMEDICO;

  --
  -- ********************************************************************************************************
  --
  PROCEDURE CALC_EXA_AMB_SADT(pn_atomedico   IN NUMBER,
                              ps_codcon      IN VARCHAR2,
                              pd_datexa      IN DATE, -- data da realizacao do item
                              pn_codunihos   IN NUMBER,
                              ps_codpadpac   IN VARCHAR2,
                              pn_codateamb   IN NUMBER,
                              pn_cd_clinica  IN NUMBER,
                              ps_codindhos   IN OUT VARCHAR2, -- codigo do indice ex.: CH / USA
                              pn_qtdch       IN OUT NUMBER,
                              pn_valorch     IN OUT NUMBER,
                              pn_percobtab   IN OUT NUMBER,
                              pn_valor_exame IN OUT NUMBER,
                              ps_codtab      IN OUT VARCHAR2 -- codigo da tabela ex.: A3/A4/A6
                              ) IS
    --
    -- calculo de exames realizados no ambulatorio
    --
--    vnExcConv     NUMBER;
    vn_codser     NUMBER; -- CODIGO DO SERVICO (ATO MEDICO)
    vs_codtipemp  EMPRESA.CODTIPEMP%TYPE; -- TIPO DE EMPRESA (CONVENIO)
    vn_prioridade NUMBER; -- PRIORIDADE NA PESQUISA DOS VALORES
    vs_codtab     VARCHAR2(2); -- CODIGO DO INDICE
    vn_codatr     NUMBER;
    vb_continua   BOOLEAN := TRUE;
    vs_indclacon  VARCHAR2(1);
    vn_qtdpa      NUMBER;
    vs_tipo       VARCHAR2(5);
  BEGIN
    --
    dsadt.Pkg_Sadt.BUSCA_CODSER(pn_atomedico, vn_codser);
    -- alteracao feita em 25/03/2003 para que estes convenios ( G225 e 226)
    -- facam os calculos pelas tabelas de servico prestado e naum do global
    -- Fernanda
    IF ps_codcon IN ('G225', 'G226') THEN
      vs_codtipemp := 'SP';
    ELSIF ps_codcon = 'NP01' THEN
      vs_codtipemp := 'FU';
    ELSE
      vs_codtipemp := dsadt.Pkg_Sadt.BUSCA_TIPOEMPRESA(ps_codcon);
    END IF;
    --
    Busca_Indclacon(pn_atomedico, vs_indclacon);
    --
    -- ################################################################################
    -- SERVICO PRESTADO E PARTICULAR
    -- ################################################################################
    IF vs_codtipemp IN (CGS_TIPO_SP, CGS_TIPO_PA) THEN
      vn_prioridade := 1;
      LOOP
        IF vn_prioridade = 4 THEN
          IF vn_codatr = CGN_CODATR_ANEST THEN
            EXIT;
          END IF;
          vn_prioridade := 1;
          vn_codatr     := CGN_CODATR_ANEST;
          ps_codindhos  := CGS_CODINDHOS_ANEST;
        END IF;
        --
        IF vs_codtipemp = CGS_TIPO_PA THEN
          pn_percobtab := 1.0;
          ps_codtab    := 'A3';
        ELSE
          -- busca codtab e percentual na PRIORIDADE_TABELAS_SPREST
          ps_codtab := NULL;
          IF vs_indclacon IN ('N', 'S') THEN
            IF ps_codcon IN ('SZ87', 'SZ78') AND
               pd_datexa >= TO_DATE('01112004', 'DDMMYYYY') THEN
              VERIFICA_BRADESCO(ps_codcon,
                                pn_codateamb,
                                'AMB',
                                pd_datexa,
                                vs_tipo);
              IF vs_tipo = 'EMP' THEN
                ps_codtab := 'B2';
              ELSIF vs_tipo = 'IND' THEN
                ps_codtab := 'B1';
              END IF;
              pn_percobtab := 1;
            END IF;
          END IF; -- FIM TESTE CONVENIO
        END IF; --  FIM TESTE INDCLACON
        IF ps_codtab IS NULL THEN
          BUSCA_PRIORIDADE_SP(vn_codser,
                              CGS_LOCAL_AMB,
                              ps_codcon,
                              vn_prioridade,
                              ps_codpadpac,
                              pd_datexa,
                              ps_codtab,
                              pn_percobtab);
        END IF;
        --
        IF (vn_codatr != CGN_CODATR_ANEST OR vn_codatr IS NULL) THEN
          -- busca na IDENTIFICACAO_TABELA o indice usado
          BUSCA_CODIGO_INDICE(ps_codtab, ps_codindhos);
          --
          vn_codatr := dsadt.Pkg_Sadt.BUSCA_ATRIBUTO(ps_codindhos, ps_codtab);
        END IF;
        --
        BEGIN
          SELECT VALEXCSP
            INTO pn_qtdch
            FROM EXCESSAO_ATOMED_SP
           WHERE CODCON = ps_codcon
             AND CODPAD = ps_codpadpac
             AND CODATOMED = pn_atomedico
             AND CODATR = vn_codatr
             AND DATEXCSP =
                 (SELECT MAX(DATEXCSP)
                    FROM EXCESSAO_ATOMED_SP
                   WHERE CODCON = ps_codcon
                     AND CODPAD = ps_codpadpac
                     AND CODATOMED = pn_atomedico
                     AND CODATR = vn_codatr
                     AND DATEXCSP <= TO_DATE(TO_CHAR(pd_datexa)));
          EXIT;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            pn_qtdch := 0;
        END;
        --
        IF pn_qtdch = 0 THEN
          BEGIN
            SELECT VALATRATOMED
              INTO pn_qtdch
              FROM ITEM_TABELA
             WHERE CODTAB = ps_codtab
               AND CODATOMED = pn_atomedico
               AND CODATR = vn_codatr;
            EXIT;
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              pn_qtdch      := 0;
              vn_prioridade := vn_prioridade + 1;
          END;
        END IF;
      END LOOP;
      --
      IF vn_codatr = CGN_CODATR_ANEST THEN
        vn_qtdpa := pn_qtdch;
        BEGIN
          SELECT QTDE_CH
            INTO pn_qtdch
            FROM TB_PORTE_ANESTESICO
           WHERE CODTAB = ps_codtab
             AND CD_PORTE = vn_qtdpa;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            pn_qtdch := 0;
            dsadt.Pkg_Sadt.GRAVA_LOG('CALC_EXAME',
                               ' PESQUISA A QTDE_CH NA TB_PORTE_ANESTESICO ' ||
                               ' CONVENIO : ' || ps_codcon || ' CODSER : ' ||
                               TO_CHAR(vn_codser) || ' CD_PORTE : ' ||
                               TO_CHAR(vn_qtdpa) || ' TABELA : ' ||
                               ps_codtab || ' PROCEDENCIA : AMB SP');
        END;
      END IF;
      --
      -- esta parte estava em outro laco if no centura (segunda parte)
      -- inicio valor da ch =================================================================
      pn_valorch := 0; -- LINHA ADICIONADA EM  26/06/2003
      -- ADICIONADO EM 26/03/2003
      -- verifica se existe excecao por classe do convenio
      -- inicio funcao classe
      VERIFICA_PRODUTO(ps_codcon,
                       pn_codateamb,
                       pn_atomedico,
                       vn_codser,
                       'AMB',
                       pd_datexa,
                       pn_valorch);
      -- ###########################################################################
      IF pn_valorch = 0 THEN
        BEGIN
          SELECT VALINDHOS
            INTO pn_valorch
            FROM EXCESSAO_IND_HOSP_ATOMED
           WHERE CODUNIHOS = pn_codunihos
             AND CODCON = ps_codcon
             AND CODATOMED = pn_atomedico
             AND CODINDHOS = ps_codindhos
             AND CODLOC = 'AMB'
             AND ((TO_DATE(TO_CHAR(pd_datexa)) BETWEEN DATINIVIGINDHOS AND
                 DATFIMVIGINDHOS) OR
                 (DATINIVIGINDHOS <= TO_DATE(TO_CHAR(pd_datexa)) AND
                 DATFIMVIGINDHOS IS NULL))
             AND DATINIVIGINDHOS =
                 (SELECT MAX(DATINIVIGINDHOS)
                    FROM EXCESSAO_IND_HOSP_ATOMED
                   WHERE CODUNIHOS = pn_codunihos
                     AND CODCON = ps_codcon
                     AND CODATOMED = pn_atomedico
                     AND CODINDHOS = ps_codindhos
                     AND CODLOC = 'AMB'
                     AND ((TO_DATE(TO_CHAR(pd_datexa)) BETWEEN
                         DATINIVIGINDHOS AND DATFIMVIGINDHOS) OR
                         (DATINIVIGINDHOS <= TO_DATE(TO_CHAR(pd_datexa)) AND
                         DATFIMVIGINDHOS IS NULL)));
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            BEGIN
              SELECT VALINDHOS
                INTO pn_valorch
                FROM EXCESSAO_IND_HOSP_CONV
               WHERE CODUNIHOS = pn_codunihos
                 AND CODCON = ps_codcon
                 AND CODINDHOS = ps_codindhos
                 AND CODSER = vn_codser
                 AND CODLOC = 'AMB'
                 AND ((TO_DATE(TO_CHAR(pd_datexa)) BETWEEN DATINIVIGINDHOS AND
                     DATFIMVIGINDHOS) OR
                     (DATINIVIGINDHOS <= TO_DATE(TO_CHAR(pd_datexa)) AND
                     DATFIMVIGINDHOS IS NULL))
                 AND DATINIVIGINDHOS =
                     (SELECT MAX(DATINIVIGINDHOS)
                        FROM EXCESSAO_IND_HOSP_CONV
                       WHERE CODUNIHOS = pn_codunihos
                         AND CODCON = ps_codcon
                         AND CODINDHOS = ps_codindhos
                         AND CODSER = vn_codser
                         AND CODLOC = 'AMB'
                         AND ((TO_DATE(TO_CHAR(pd_datexa)) BETWEEN
                             DATINIVIGINDHOS AND DATFIMVIGINDHOS) OR
                             (DATINIVIGINDHOS <=
                             TO_DATE(TO_CHAR(pd_datexa)) AND
                             DATFIMVIGINDHOS IS NULL)));
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                -- NAO ACHOU PESQUISA NA MOEDA INDICE HOSPITALAR
                BEGIN
                  SELECT VALMOEINDHOS
                    INTO pn_valorch
                    FROM MOEDA_INDICE_HOSPITALAR
                   WHERE CODINDHOS = ps_codindhos
                     AND DATMOEINDHOS =
                         (SELECT MAX(DATMOEINDHOS)
                            FROM MOEDA_INDICE_HOSPITALAR
                           WHERE CODINDHOS = ps_codindhos
                             AND DATMOEINDHOS <= TO_DATE(TO_CHAR(pd_datexa)))
                     AND ROWNUM = 1;
                EXCEPTION
                  WHEN NO_DATA_FOUND THEN
                    pn_valorch := 0;
                END;
            END;
        END; -- fim valor indice
      END IF; -- fim verificacao valor indice
      -- #####################################################################################
      -- OUTROS TIPOS DE EMPRESA N:1O SP E PA
      -- #####################################################################################
    ELSIF vs_codtipemp IN (CGS_TIPO_GB, CGS_TIPO_PL, CGS_TIPO_FUNC) THEN
      -- forca tabela pq exame ambulatorio so usa AMB
      -- vs_codtab := 'A1';     mudei 11/07/2002
      -- o mesmo para o atributo
      -- vn_codatr := 1;        mudei 11/07/2002
      --
      --
      -- ALTERACAO EMERGENCIAL PARA VOLTAR A FORCAR A TABELA A1 NO CALCULO
      --
      vn_prioridade := 1;
      LOOP
        vb_continua := TRUE;
        IF vn_prioridade >= 4 THEN
          EXIT;
        END IF;
        --
        -- identificacao da tabelA
        -- ALTERACAO FEITA EM 03/01/2003 PARA QUE CALCULE O G225 E G226 COMO NA INTERNACAO
        -- NA FORMA DE OBTER A TABELA DE COBRANCA
        --
        -- alteracao para fisioterapia ( codser = 25) enxergar tabela amb92 ( A3)
        -- 21/03/2003
        IF ps_codcon IN ('G225', 'G226') THEN
          BEGIN
            SELECT CODTAB, PERGLO
              INTO ps_codtab, pn_percobtab
              FROM EXCESSAO_PRIORIDADE_GLOBAL
             WHERE CODCON = ps_codcon
               AND (vn_codser >= CODSERINI AND vn_codser <= CODSERFIM)
               AND (DT_VIGENCIA <= pd_datexa AND DT_FIM >= pd_datexa OR
                   DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL);
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              BEGIN
                SELECT CODTAB, PERGLO
                  INTO ps_codtab, pn_percobtab
                  FROM PRIORIDADE_GLOBAL
                 WHERE CODTIPEMP = vs_codtipemp
                   AND (vn_codser >= CODSERINI AND vn_codser <= CODSERFIM)
                   AND INDCLACON = vs_indclacon
                   AND (DT_VIGENCIA <= pd_datexa AND DT_FIM >= pd_datexa OR
                       DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL);
              EXCEPTION
                WHEN NO_DATA_FOUND THEN
                  ps_codtab    := NULL;
                  pn_percobtab := 0;
                  dsadt.Pkg_Sadt.GRAVA_LOG('CALC_EXAME',
                                     ' PESQUISA NA PRIORIDADE_GLOBAL ' ||
                                     ' CONVENIO : ' || ps_codcon ||
                                     ' ATO MEDICO : ' ||
                                     TO_CHAR(pn_atomedico) || ' CODSER : ' ||
                                     TO_CHAR(vn_codser) ||
                                     ' PROCEDENCIA : INT GB');
              END;
          END;
          vn_prioridade := 4;
        ELSIF vn_codser = 25 THEN
          ps_codtab     := 'A3';
          vn_prioridade := 4;
        ELSE
          BEGIN
            IF vn_prioridade = 1 THEN
              IF pd_datexa >= TO_DATE('01052008', 'DDMMYYYY') AND
                 (pn_cd_clinica NOT IN (45, 49, 50, 51, 52) or
                 pn_cd_clinica is null) THEN
                ps_codtab := 'A3';
              ELSE
                ps_codtab := 'A1';
              END IF;
            ELSIF vn_prioridade = 2 THEN
              ps_codtab := 'A3';
            ELSIF vn_prioridade = 3 THEN
              IF TO_DATE('01082003', 'DDMMYYYY') > pd_datexa THEN
                ps_codtab := 'H';
              ELSIF pd_datexa >= TO_DATE('12032007', 'DDMMYYYY') THEN
                ps_codtab := 'AC';
              ELSE
                ps_codtab := 'H1';
              END IF;
            END IF;
          END;
        END IF; -- fim teste convenio
        --
        -- identificacao do indice
        BEGIN
          SELECT CODINDHOS
            INTO ps_codindhos
            FROM IDENTIFICACAO_TABELA
           WHERE CODTAB = ps_codtab;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            dsadt.Pkg_Sadt.GRAVA_LOG('CALC_EXAME',
                               ' PESQUISA NA IDENTIFICACAO_TABELA ' ||
                               ' CONVENIO : ' || ps_codcon ||
                               ' ATO MEDICO : ' || TO_CHAR(pn_atomedico) ||
                               ' CODTAB : ' || vs_codtab ||
                               ' PROCEDENCIA : AMB GB');
        END;
        -- :2:3:4:5:6:7:8:9:10:11:12:13:14:15:16:17:18:19:20:21:22:23:24:25 atributo :26:27:28:29:30:31:32:33:34:35:36:37:38:39:40:41:42:43:44:45:46:47:48:49:50:51:52:53:54:55:56:57:58:59
        vn_codatr := dsadt.Pkg_Sadt.BUSCA_ATRIBUTO(ps_codindhos, ps_codtab);
        -- colocado excessao de qtde em 26/08/2003
        BEGIN
          SELECT VALEXCSP
            INTO pn_qtdch
            FROM EXCESSAO_ATOMED_SP
           WHERE CODCON = ps_codcon
             AND CODPAD = ps_codpadpac
             AND CODATOMED = pn_atomedico
             AND CODATR = vn_codatr
             AND DATEXCSP =
                 (SELECT MAX(DATEXCSP)
                    FROM EXCESSAO_ATOMED_SP
                   WHERE CODCON = ps_codcon
                     AND CODPAD = ps_codpadpac
                     AND CODATOMED = pn_atomedico
                     AND CODATR = vn_codatr
                     AND DATEXCSP <= TO_DATE(TO_CHAR(pd_datexa)));
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            pn_qtdch := 0;
        END;

        IF pn_qtdch = 0 THEN
          BEGIN
            SELECT VALATRATOMED,
                   DECODE(ps_codcon,
                          'G225',
                          pn_percobtab,
                          'G226',
                          pn_percobtab,
                          PERGLOAMB)
              INTO pn_qtdch, pn_percobtab
              FROM ITEM_TABELA
             WHERE CODTAB = ps_codtab
               AND CODATOMED = pn_atomedico
               AND CODATR = vn_codatr;
            -- alterac:60o para enxergar fisio com percentual de 100% e nao 70%
            IF vs_codtipemp = CGS_TIPO_FUNC THEN
              IF pn_atomedico = 10014 and
                 pd_datexa >= to_date('01042004', 'ddmmyyyy') THEN
                pn_percobtab := 1;
              ELSE
                pn_percobtab := 0.5;
              END IF;
            ELSIF vn_codser = 25 AND ps_codcon NOT IN ('G225', 'G226') THEN
              pn_percobtab := 1;
            ELSIF pd_datexa >= to_date('01012006', 'ddmmyyyy') THEN
              pn_percobtab := 1;
            END IF;
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              pn_qtdch     := 0;
              pn_percobtab := 0;
              dsadt.Pkg_Sadt.GRAVA_LOG('CALC_EXAME',
                                 ' PESQUISA NA ITEM_TABELA ' ||
                                 ' CONVENIO : ' || ps_codcon ||
                                 ' ATO MEDICO : ' || TO_CHAR(pn_atomedico) ||
                                 ' CODTAB : ' || vs_codtab || ' CODATR : ' ||
                                 TO_CHAR(vn_codatr) ||
                                 ' PROCEDENCIA : AMB GB');
              --
              vn_prioridade := vn_prioridade + 1;
              -- se nao encontrou nao passa pelas outras querys
              vb_continua := FALSE;
          END;
        ELSE
          pn_percobtab := 1;
        END IF;
        --
        IF vb_continua THEN
          -- **
          BEGIN
            SELECT VALINDHOS
              INTO pn_valorch
              FROM EXCESSAO_IND_HOSP_ATOMED
             WHERE CODUNIHOS = pn_codunihos
               AND CODCON = ps_codcon
               AND CODATOMED = pn_atomedico
               AND CODINDHOS = ps_codindhos
               AND CODLOC = 'AMB'
               AND ((TO_DATE(TO_CHAR(pd_datexa)) BETWEEN DATINIVIGINDHOS AND
                   DATFIMVIGINDHOS) OR
                   (DATINIVIGINDHOS <= TO_DATE(TO_CHAR(pd_datexa)) AND
                   DATFIMVIGINDHOS IS NULL))
               AND DATINIVIGINDHOS =
                   (SELECT MAX(DATINIVIGINDHOS)
                      FROM EXCESSAO_IND_HOSP_ATOMED
                     WHERE CODUNIHOS = pn_codunihos
                       AND CODCON = ps_codcon
                       AND CODATOMED = pn_atomedico
                       AND CODINDHOS = ps_codindhos
                       AND CODLOC = 'AMB'
                       AND ((TO_DATE(TO_CHAR(pd_datexa)) BETWEEN
                           DATINIVIGINDHOS AND DATFIMVIGINDHOS) OR
                           (DATINIVIGINDHOS <= TO_DATE(TO_CHAR(pd_datexa)) AND
                           DATFIMVIGINDHOS IS NULL)));
            EXIT;
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              BEGIN
                SELECT VALINDHOS
                  INTO pn_valorch
                  FROM EXCESSAO_IND_HOSP_CONV
                 WHERE CODUNIHOS = pn_codunihos
                   AND CODCON = ps_codcon
                   AND CODINDHOS = ps_codindhos
                   AND CODSER = vn_codser
                   AND CODLOC = 'AMB'
                   AND ((TO_DATE(TO_CHAR(pd_datexa)) BETWEEN
                       DATINIVIGINDHOS AND DATFIMVIGINDHOS) OR
                       (DATINIVIGINDHOS <= TO_DATE(TO_CHAR(pd_datexa)) AND
                       DATFIMVIGINDHOS IS NULL))
                   AND DATINIVIGINDHOS =
                       (SELECT MAX(DATINIVIGINDHOS)
                          FROM EXCESSAO_IND_HOSP_CONV
                         WHERE CODUNIHOS = pn_codunihos
                           AND CODCON = ps_codcon
                           AND CODINDHOS = ps_codindhos
                           AND CODSER = vn_codser
                           AND CODLOC = 'AMB'
                           AND ((TO_DATE(TO_CHAR(pd_datexa)) BETWEEN
                               DATINIVIGINDHOS AND DATFIMVIGINDHOS) OR
                               (DATINIVIGINDHOS <=
                               TO_DATE(TO_CHAR(pd_datexa)) AND
                               DATFIMVIGINDHOS IS NULL)));
                EXIT;
              EXCEPTION
                WHEN NO_DATA_FOUND THEN
                  -- NAO ACHOU PESQUISA NA MOEDA INDICE HOSPITALAR
                  BEGIN
                    SELECT VALMOEINDHOS
                      INTO pn_valorch
                      FROM MOEDA_INDICE_HOSPITALAR
                     WHERE CODINDHOS = ps_codindhos
                       AND DATMOEINDHOS =
                           (SELECT MAX(DATMOEINDHOS)
                              FROM MOEDA_INDICE_HOSPITALAR
                             WHERE CODINDHOS = ps_codindhos
                               AND DATMOEINDHOS <=
                                   TO_DATE(TO_CHAR(pd_datexa)))
                       AND ROWNUM = 1;
                    EXIT;
                  EXCEPTION
                    WHEN NO_DATA_FOUND THEN
                      pn_valorch := 0;
                    WHEN OTHERS THEN
                      pn_valorch := 0;
                      RAISE_APPLICATION_ERROR(-20501,
                                              'NAO ENCONTROU VALOR 1');
                  END;
                WHEN OTHERS THEN
                  dsadt.Pkg_Sadt.GRAVA_LOG('CALC_EXAME', SQLERRM);
                  RAISE_APPLICATION_ERROR(-20501, 'NAO ENCONTROU VALOR 2');

              END;
          END;
          -- verifica desconto do ato medico
          -- calculo de desconto retirado 05/08/2002 Ricardo
          --EXIT;
          --
        END IF; -- fim vb_continua
      END LOOP; -- fim teste prioridade
      IF (pn_qtdch = 0) THEN
        dsadt.Pkg_Sadt.GRAVA_LOG('CALC_EXAME',
                           ' VALOR_ZERADO ' || ' #CONVENIO : ' || ps_codcon ||
                           ' #ATO MEDICO : ' || TO_CHAR(pn_atomedico) ||
                           ' #DATEXA : ' ||
                           TO_CHAR(PD_DATEXA, 'DD/MM/YYYY') ||
                           ' #CODINDHOS : ' || ps_codindhos ||
                           ' #CODUNIHOS :' || TO_CHAR(pn_codunihos) ||
                           ' #PROCEDENCIA : AMB GB');
      END IF;

    END IF; -- FIM TESTE TIPO EMPRESA
    --
    --  ***************************************************************************************
    --   RETIRADA A ROTINA QUE FORCA O VALOR DE LITOTRIPSIA, POR ORDEM DO ROGERIO DA DIRETORIA
    --   COMERCIAL   -  19/02/2003    Diogo
    --  ***************************************************************************************
    --   IF pn_atomedico = 56030460 AND vs_codtipemp IN ( CGS_TIPO_GB, CGS_TIPO_PL, CGS_TIPO_FUNC ) THEN
    --      pn_valor_exame := 290.14;   -- VALOR FORCADO ACORDADO PARA O GLOBAL!!!!!!!!!!
    --   ELSE
    pn_valor_exame := ROUND((pn_qtdch * pn_valorch) * Pn_percobtab, 2);
    --   END IF;
    --
  END CALC_EXA_AMB_SADT;

  ---
  ---****************************************************************************************
  ---
  PROCEDURE DESCONTO_SADT(pn_atomedico   IN NUMBER,
                          ps_codcon      IN VARCHAR2,
                          pn_qtdch       IN NUMBER,
                          pn_percobtab   IN NUMBER,
                          pn_valorch     IN OUT NUMBER,
                          pn_valor_exame IN OUT NUMBER) IS
    -- procedure para calculo de desconto dos exames que est:61o on-line
    vn_existe NUMBER;
  BEGIN
    -- verifica se existe na tabela do SADT
    BEGIN
      SELECT COUNT(1)
        INTO vn_existe
        FROM SADT_EXAME
       WHERE CODUNISAD = 'L'
         AND CODATOMED = pn_atomedico;
      IF vn_existe >= 1 THEN
        -- existe, calcula desconto
        CALC_DESCONTO(pn_atomedico,
                      ps_codcon,
                      pn_qtdch,
                      pn_percobtab,
                      pn_valorch,
                      pn_valor_exame);
      END IF;
    EXCEPTION
      WHEN OTHERS THEN
        dsadt.Pkg_Sadt.GRAVA_LOG('DESCONTO_SADT',
                           ' EXAME NAO EXISTE NA SADT_EXAME');
    END;
  END DESCONTO_SADT;

  ---
  --- *************************************************************************************************************
  ---
  PROCEDURE CALC_M2_FILME_ITEM(PN_CODUNIHOS IN NUMBER,
                               PN_CODPAC    IN NUMBER,
                               PN_CODATE    IN NUMBER,
                               PN_CODATO    IN NUMBER,
                               PD_DATEXA    IN DATE,
                               PN_VL_FILME  OUT NUMBER,
                               PN_VL_TAXA   OUT NUMBER) IS
    vn_codser     ATO_MEDICO.CODSER%TYPE;
    vs_codcon     EMPRESA.CODCON%TYPE;
    vs_codtipemp  EMPRESA.CODTIPEMP%TYPE;
    v_continua    BOOLEAN;
    vn_codtipate  PACIENTE_ATENDIMENTO_AMB.CODTIPATE%TYPE;
    vn_percom     NUMBER(5, 2);
    vs_codtab     PRIORIDADE_TABELAS_SPREST.CODTAB%TYPE;
    vn_prioridade NUMBER(2);
    vn_qtdech     NUMBER(10, 4);
    vn_percent    NUMBER(5, 2);
    vn_valch      NUMBER(14, 3);
    --
  BEGIN
    v_continua := TRUE;
    --
    SELECT CODSER
      INTO vn_codser
      FROM ATO_MEDICO
     WHERE CODATOMED = pn_codato;
    --
    SELECT P.CODCON, E.CODTIPEMP, P.CODTIPATE, nvl(E.PERCOMFIL, 0)
      INTO vs_codcon, vs_codtipemp, vn_codtipate, vn_percom
      FROM PACIENTE_ATENDIMENTO_AMB P, EMPRESA E
     WHERE P.CODUNIHOS = PN_CODUNIHOS
       AND P.CODPAC = PN_CODPAC
       AND P.CODATEAMB = PN_CODATE
       AND P.CODCON = E.CODCON;
    --
    if vs_codcon IN ('G225', 'G226') OR
       (vs_codtipemp IN ('GB', 'PL', 'FU', 'NP') AND
       vn_codtipate IN (5, 6, 7, 8) and vs_codcon != 'NR14') THEN
      vs_codtipemp := 'SP';
    ELSIF vs_codtipemp IN ('GB', 'PL', 'FU', 'NP') THEN
      vs_codtipemp := 'GB';
    END IF;
    --
    IF vn_codser = 31 AND vs_codtipemp = 'SP' THEN
      v_continua := TRUE;
    ELSIF vn_codser IN (32, 33, 34, 36) THEN
      v_continua := TRUE;
    ELSE
      v_continua := FALSE;
    END IF;
    ----
    ---------------------------------------------------------
    --- busca tabela, percentual de desconto e qtde do m2 ---
    ---------------------------------------------------------
    IF v_continua = TRUE THEN
      ----------------------
      -- servico prestado --
      ----------------------
      IF vs_codtipemp IN (CGS_TIPO_SP, CGS_TIPO_PA) THEN
        vn_prioridade := 1;
        LOOP
          IF vn_prioridade = 4 THEN
            EXIT;
          END IF;
          v_continua := TRUE;
          BEGIN
            SELECT CODTAB
              INTO vs_codtab
              FROM PRIORIDADE_TABELAS_SPREST
             WHERE CODSER = vn_codser
               AND PRIORIDADE = vn_prioridade
               AND CODLOC = 'AMB'
               AND CODCON = vs_codcon
               AND (DT_VIGENCIA <= pd_datexa AND DT_FIM >= pd_datexa OR
                   DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL);
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              BEGIN
                vn_prioridade := vn_prioridade + 1;
                v_continua    := FALSE;
              END;
          END;
          --
          IF v_continua = TRUE THEN
            BEGIN
              SELECT VALATRATOMED, 1
                INTO vn_qtdech, vn_percent
                FROM ITEM_TABELA
               WHERE CODATOMED = pn_codato
                 AND CODTAB = vs_codtab
                 AND CODATR = 6;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                BEGIN
                  vn_prioridade := vn_prioridade + 1;
                  v_continua    := FALSE;
                END;
            END;
          END IF;
          --
          IF v_continua = TRUE THEN
            EXIT;
          END IF;
        END LOOP;
        ------------
        -- global --
        ------------
      ELSIF vs_codtipemp = 'GB' THEN
        vn_prioridade := 1;
        LOOP
          IF vn_prioridade = 3 THEN
            EXIT;
          END IF;
          --
          v_continua := TRUE;
          IF vn_prioridade = 1 THEN
            IF pd_datexa >= to_date('01052008', 'ddmmyyyy') THEN
              vs_codtab := 'A3';
            ELSE
              vs_codtab := 'A1';
            END IF;
          ELSIF vn_prioridade = 2 THEN
            vs_codtab := 'A3';
          ELSE
            vs_codtab     := NULL;
            vn_prioridade := vn_prioridade + 1;
            v_continua    := FALSE;
          END IF;
          --
          IF v_continua = TRUE THEN
            BEGIN
              SELECT VALATRATOMED, PERGLOAMB
                INTO vn_qtdech, vn_percent
                FROM ITEM_TABELA
               WHERE CODATOMED = pn_codato
                 AND CODTAB = vs_codtab
                 AND CODATR = 6;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                BEGIN
                  vn_prioridade := vn_prioridade + 1;
                  v_continua    := FALSE;
                END;
            END;
          END IF;
          --
          IF v_continua = TRUE THEN
            EXIT;
          END IF;
        END LOOP;
      END IF; -- TIPO DE EMPRESA
    END IF; -- V_CONTINUA
    ----
    -------------------------------------
    --** PESQUISA DE VALOR DE MOEDA **---
    -------------------------------------
    IF v_continua = TRUE THEN
      BEGIN
        SELECT VALINDHOS
          INTO vn_valch
          FROM EXCESSAO_IND_HOSP_ATOMED
         WHERE CODUNIHOS = pn_codunihos
           AND CODCON = vs_codcon
           AND CODATOMED = pn_codato
           AND CODLOC = 'AMB'
           AND CODINDHOS = 'M2'
           AND ((pd_datexa BETWEEN DATINIVIGINDHOS AND DATFIMVIGINDHOS) OR
               (DATINIVIGINDHOS <= pd_datexa AND DATFIMVIGINDHOS IS NULL))
           AND DATINIVIGINDHOS =
               (SELECT MAX(DATINIVIGINDHOS)
                  FROM EXCESSAO_IND_HOSP_ATOMED
                 WHERE CODUNIHOS = pn_codunihos
                   AND CODCON = vs_codcon
                   AND CODATOMED = pn_codato
                   AND CODLOC = 'AMB'
                   AND CODINDHOS = 'M2'
                   AND ((pd_datexa BETWEEN DATINIVIGINDHOS AND
                       DATFIMVIGINDHOS) OR (DATINIVIGINDHOS <= pd_datexa AND
                       DATFIMVIGINDHOS IS NULL)));
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          BEGIN
            SELECT VALINDHOS
              INTO vn_valch
              FROM EXCESSAO_IND_HOSP_CONV
             WHERE CODUNIHOS = pn_codunihos
               AND CODCON = vs_codcon
               AND CODLOC = 'AMB'
               AND CODINDHOS = 'M2'
               AND CODSER = vn_codser
               AND ((pd_datexa BETWEEN DATINIVIGINDHOS AND DATFIMVIGINDHOS) OR
                   (DATINIVIGINDHOS <= pd_datexa AND
                   DATFIMVIGINDHOS IS NULL))
               AND DATINIVIGINDHOS =
                   (SELECT MAX(DATINIVIGINDHOS)
                      FROM EXCESSAO_IND_HOSP_CONV
                     WHERE CODUNIHOS = pn_codunihos
                       AND CODCON = vs_codcon
                       AND CODLOC = 'AMB'
                       AND CODINDHOS = 'M2'
                       AND CODSER = vn_codser
                       AND ((pd_datexa BETWEEN DATINIVIGINDHOS AND
                           DATFIMVIGINDHOS) OR
                           (DATINIVIGINDHOS <= pd_datexa AND
                           DATFIMVIGINDHOS IS NULL)));
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              BEGIN
                SELECT VALMOEINDHOS
                  INTO vn_valch
                  FROM MOEDA_INDICE_HOSPITALAR
                 WHERE CODINDHOS = 'M2'
                   AND CODMOE = 2
                   AND DATMOEINDHOS =
                       (SELECT MAX(DATMOEINDHOS)
                          FROM MOEDA_INDICE_HOSPITALAR
                         WHERE CODINDHOS = 'M2'
                           AND codmoe = 2
                           AND DATMOEINDHOS <= pd_datexa)
                   AND ROWNUM = 1;
              EXCEPTION
                WHEN NO_DATA_FOUND THEN
                  vn_valch := 0;
              END; --MOEDA
          END; --EXC IND HOSP CONV
      END; -- EXC IND HOSP ATOMED
    END IF;
    ------------------------
    --- CALCULO DO VALOR ---
    ------------------------
    pn_vl_filme := nvl(vn_qtdech, 0) * nvl(vn_valch, 0);
    pn_vl_taxa  := nvl(pn_vl_filme, 0) * nvl(vn_percom, 0) *
                   nvl(vn_percent, 0);
    --
    pn_vl_filme := TRUNC(NVL(pn_vl_filme, 0.00), 2);
    pn_vl_taxa  := TRUNC(NVL(pn_vl_taxa, 0.00), 2);
    --
  END CALC_M2_FILME_ITEM;

  --
  -- ***********************************************************************************
  --
  PROCEDURE CLASSAMB(pnCODATOMED IN NUMBER,
                     psCODCON    IN VARCHAR2,
                     psINDCLACON IN VARCHAR2,
                     pnCODSER    IN NUMBER,
                     pnCODCLACTB IN OUT NUMBER) IS
    -- ************************************************************
    -- 08/07/2003                                                 *
    -- ESTA PROCEDURE VAI SER DESCONTINUADA - ESTA NO LUGAR       *
    -- A PROCEDURE "CLASS_CONTABIL"                               *
    -- PROCEDURE ALTERADA PARA SE CRIAR OUTROS PARAMETROS         *
    -- E JUNTAR A ROTINA DE INTERNADO QUE ERA SEPARADA            *
    -- ************************************************************
    -- WINDCLACON  VARCHAR2(1);
    WCODTIPEMP VARCHAR2(2);
    sCODLOC    VARCHAR2(4);
    nCodAtoMed ATO_MEDICO.CODATOMED%TYPE;
    sIndClaCon ATO_MEDICO.INDCLACON%TYPE;
    nCodSer    ATO_MEDICO.CODSER%TYPE;
  BEGIN
    SELECT CODTIPEMP INTO WCODTIPEMP FROM EMPRESA WHERE CODCON = psCODCON;
    --
    -- se for PL, PASSA para GB
    IF WCODTIPEMP IN ('PL', 'FU', 'PM', 'NP') THEN
      WCODTIPEMP := 'GB';
      --  ELSIF WCODTIPEMP = 'NP' THEN
      --    pnCODCLACTB := 5300;
      --    RETURN;
    END IF;
    sCODLOC := CGS_COD_LOC;
    /*
     --
     -- ############################################  alteracao usiminas 07/07/2003
     IF psCODCON = 'SW38' THEN
        -- verifica se existe csdigo no "DE - PARA"
        BEGIN
           SELECT CODATOASS
           INTO   nCodAtoMed
           FROM ATO_MEDICO_ASSOCIADO
           WHERE CODCON    = psCODCON
           AND   CODATOMED = pnCODATOMED;
           --
           -- busca outros dados
           BEGIN
              SELECT CODSER, INDCLACON
              INTO   nCodSer, sIndClaCon
              FROM   ATO_MEDICO
              WHERE CODATOMED = nCodAtoMed;
              --
           EXCEPTION
              WHEN OTHERS THEN
                 NULL;
           END;
        EXCEPTION
           WHEN NO_DATA_FOUND THEN
              nCodAtoMed := pnCODATOMED;
              nCodSer    := pnCODSER;
              sIndClaCon := psINDCLACON;
        END;
     END IF;    -- fim teste usiminas
       -- ############################################  fim alteracao usiminas 07/07/2003
    */
    /* Excessao Classif. Contabil - Empresa */
    nCodAtoMed := pnCODATOMED;
    nCodSer    := pnCODSER;
    sIndClaCon := psINDCLACON;
    --
    BEGIN
      SELECT CODCLACTB
        INTO pnCODCLACTB
        FROM EXCESSAO_CLASSIF_CONTABIL
       WHERE CODATOMED = nCodAtoMed
         AND CODCON = psCODCON;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        BEGIN
          SELECT CODCLACTB
            INTO pnCODCLACTB
            FROM EXCESSAO_CLAS_CONTABIL
           WHERE CODATOMED = nCodAtoMed;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            /* Excessao Classif. Contabil - Geral */
            IF psINDCLACON = 'S' THEN
              BEGIN
                SELECT CODCLACTB
                  INTO pnCODCLACTB
                  FROM CLASSIF_CONTABIL_ATO_MEDICO
                 WHERE CODATOMED = nCodAtoMed
                   AND CODTIPEMP = WCODTIPEMP
                   AND CODLOC = sCODLOC;
              EXCEPTION
                WHEN NO_DATA_FOUND THEN
                  -- busca a classificacao do servico
                  BEGIN
                    SELECT CODCLACTB
                      INTO pnCODCLACTB
                      FROM CLASSIF_CONTABIL_SERVICO
                     WHERE CODSER = nCodSer
                       AND CODLOC = sCODLOC;
                  EXCEPTION
                    WHEN NO_DATA_FOUND THEN
                      pnCODCLACTB := NULL; -- SEM Class Contabil
                  END;
              END;
            ELSIF (sIndClaCon != 'S') OR (sIndClaCon IS NULL) THEN
              BEGIN
                SELECT CODCLACTB
                  INTO pnCODCLACTB
                  FROM CLASSIF_CONTABIL_SERVICO
                 WHERE CODSER = nCodSer
                   AND CODLOC = sCODLOC;
              EXCEPTION
                WHEN NO_DATA_FOUND THEN
                  pnCODCLACTB := NULL; -- SEM Classificacao Contabil
              END;
            END IF;
        END;
    END;
  END CLASSAMB;

  --
  -- **********************************************************************************************
  --
  PROCEDURE CALC_HE_AMB(pn_codateamb IN NUMBER,
                        pn_codclactb IN NUMBER,
                        pn_codatomed IN NUMBER,
                        ps_codtab    IN VARCHAR2,
                        pn_perext    IN OUT NUMBER) IS
    --
    vs_codcon    VARCHAR2(4);
    vn_codpac    NUMBER(8);
    vn_codunihos NUMBER(2);
    vn_hora      NUMBER(4);
    vd_datate    DATE;
    vs_datfer    CHAR(1);
    vn_dia       NUMBER(1);
    vs_horextamb CHAR(1);
    vs_indclacon CHAR(1);
    vs_indext    CHAR(1);
    vn_horini    NUMBER(4);
    --
  BEGIN
    pn_perext := 0;
    --
    SELECT codpac,
           codunihos,
           datate,
           TO_NUMBER(TO_CHAR(DATATE, 'D')),
           -- TO_NUMBER(SUBSTR(horate,1,2))
           HORATE,
           CODCON
      INTO vn_codpac, vn_codunihos, vd_datate, vn_dia, vn_hora, vs_codcon
      FROM PACIENTE_ATENDIMENTO_AMB
     WHERE codateamb = pn_codateamb;
    --
    IF (vs_codcon IN ('SW32', 'SW11') and pn_codatomed = 10014 and
       vd_datate >= to_date('23082004', 'ddmmyyyy')) or
       (vs_codcon IN ('SX60', 'SP54') and
       pn_codatomed in (8102002, 8102008, 8102009) and
       vd_datate >= to_date('01082006', 'ddmmyyyy')) or
       (SUBSTR(TO_CHAR(pn_codatomed), 0, 2) not in ('30')) THEN
      vs_horextamb := ' ';
    ELSE
      Busca_Indclacon(pn_codatomed, vs_indclacon);
      --
      IF (vs_indclacon IN ('X', 'A') OR pn_codclactb = 3200 OR
         (pn_codclactb = 3300 AND vs_codcon = 'G226') OR
         (pn_codclactb = 3300 AND vs_codcon = 'G225')) and
         pn_codatomed != 10038 THEN
        BEGIN
          SELECT HOREXTAMB
            INTO vs_horextamb
            FROM EMPRESA
           WHERE CODCON = vs_codcon;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            vs_horextamb := ' ';
        END;
        --
        -- ALTERACAO PARA CALCULAR TB TAXA DE SALA
        IF vs_indclacon IN ('S', 'X', 'A') AND vs_horextamb = 'S' THEN
          -- H.E. --
          BEGIN
            SELECT 'X'
              INTO vs_datfer
              FROM FERIADO
             WHERE CODUNIHOS = vn_codunihos
               AND DIAFER = vd_datate
               AND TP_FERIADO = 'F';
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              vs_datfer := NULL;
          END;
          --
          -- E FERIADO
          DBMS_OUTPUT.PUT_LINE('FERIADO:' || VS_DATFER);
          IF vs_datfer IS NOT NULL THEN
            BEGIN
              -- ALTERACAO PARA OBTER PERCENTUAL DE TAXA DE SALA NO AMB.
              SELECT DECODE(vs_indclacon, 'S', PERHOREXT, PERHETAXSAL)
                INTO pn_perext
                FROM HORA_EXTRA_UNID_HOSP_TABELA
               WHERE CODTAB = ps_codtab
                 AND CODUNIHOS = vn_codunihos;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                pn_perext := 0;
                RAISE_APPLICATION_ERROR(-25001, 'Erro');
            END;
          ELSE
            -- NAO E FERIADO
            --
            BEGIN
              SELECT MAX(HORINI)
                INTO vn_horini
                FROM HORARIO_TABELA
               WHERE NUMDIA = vn_dia
                 AND CODTAB = ps_codtab
                 AND HORINI <= vn_hora;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                vn_horini := NULL;
            END;
            IF vn_horini IS NOT NULL THEN
              BEGIN
                SELECT INDHOREXT
                  INTO vs_indext
                  FROM HORARIO_TABELA
                 WHERE NUMDIA = vn_dia
                   AND CODTAB = ps_codtab
                   AND HORINI = vn_horini;
              EXCEPTION
                WHEN NO_DATA_FOUND THEN
                  vs_indext := ' ';
                  pn_perext := 0;
              END;
            END IF;
            --
            IF vs_indext = 'S' THEN
              BEGIN
                SELECT DECODE(vs_indclacon, 'S', PERHOREXT, PERHETAXSAL)
                  INTO pn_perext
                  FROM HORA_EXTRA_UNID_HOSP_TABELA
                 WHERE CODTAB = ps_codtab
                   AND CODUNIHOS = vn_codunihos;
              EXCEPTION
                WHEN NO_DATA_FOUND THEN
                  pn_perext := 0;
                  RAISE_APPLICATION_ERROR(-25001, 'Erro');
              END;
            END IF;
          END IF; -- do FERIADO
        END IF; -- da CLASSIFICACAO E DA HORA EXTRA
      END IF; -- e HM
    END IF;
  END CALC_HE_AMB;

  --
  -- ************************************************************************************************************
  --
  FUNCTION RET_TAXA_ADM(ps_codcon     IN VARCHAR2,
                        pn_codunihos  IN NUMBER,
                        ps_codloc     IN VARCHAR2,
                        ps_in_int_ext IN CHAR,
                        pd_datexa     IN DATE) RETURN NUMBER IS
    --
    vn_percentual NUMBER(5, 2);
    --
  BEGIN
    vn_percentual := 0;
    BEGIN
      SELECT VL_PERCENTUAL
        INTO vn_percentual
        FROM COM_REGRA_CONVENIO
       WHERE CODCON = ps_codcon
         AND CODUNIHOS = pn_codunihos
         AND CODLOC = ps_codloc
         AND IN_INT_EXT = ps_in_int_ext
         AND ((TO_DATE(TO_CHAR(pd_datexa)) BETWEEN DT_INICIO_VIGENCIA AND
             DT_FIM_VIGENCIA) OR
             (DT_INICIO_VIGENCIA <= TO_DATE(TO_CHAR(pd_datexa)) AND
             DT_FIM_VIGENCIA IS NULL));
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        vn_percentual := 0;
    END;
    --
    IF vn_percentual IS NULL THEN
      vn_percentual := 0;
    END IF;
    --
    return vn_percentual;
  END RET_TAXA_ADM;

  --
  --=================================================================================
  --
  PROCEDURE Busca_Indclacon(pn_codatomed IN NUMBER,
                            ps_indclacon OUT VARCHAR2) IS
  BEGIN
    --
    BEGIN
      SELECT INDCLACON
        INTO ps_indclacon
        FROM ATO_MEDICO
       WHERE CODATOMED = pn_codatomed;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        dsadt.Pkg_Sadt.GRAVA_LOG('INDCLACON',
                           ' ATO_MED: ' || TO_CHAR(pn_codatomed) || ' ' ||
                           SQLERRM);
    END;
    --
  END Busca_Indclacon;

  --
  -- *********************************************************************************************************
  --

  PROCEDURE VERIFICA_BRADESCO(ps_codcon    IN VARCHAR2,
                              pn_codateamb IN NUMBER,
                              ps_local     IN VARCHAR2,
                              pd_data      IN DATE,
                              ps_tipo      IN OUT VARCHAR2) IS
    sCred  VARCHAR2(50);
    nRegra NUMBER;
  BEGIN
    -- existe excecao para o convenio verifica se e a classe especifica
    IF ps_local = 'AMB' THEN
      BEGIN
        SELECT PRO.PRODUTO
          INTO sCred
          FROM COM_PRODUTO_CONVENIO PRO, PACIENTE_ATENDIMENTO_AMB HOS
         WHERE HOS.CODATEAMB = pn_codateamb
           AND PRO.CODCON = ps_codcon
           AND PRO.PRODUTO =
               SUBSTR(HOS.NUMCRE, PRO.DIGITO_INI, PRO.QTD_DIGITO);
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          DBMS_OUTPUT.PUT_LINE(' PRODUTO     : SEM CADASTRO ');
        WHEN TOO_MANY_ROWS THEN
          NULL;
      END;
    ELSIF ps_local = 'INT' THEN
      BEGIN
        SELECT PRO.PRODUTO
          INTO sCred
          FROM COM_PRODUTO_CONVENIO PRO, TB_INTERNADO HOS
         WHERE HOS.NR_SEQINTER = pn_codateamb
           AND PRO.CODCON = ps_codcon
           AND PRO.PRODUTO =
               SUBSTR(HOS.CRED, PRO.DIGITO_INI, PRO.QTD_DIGITO);
        DBMS_OUTPUT.PUT_LINE(' PRODUTO     : ' || sCred || ' REGRA ' ||
                             TO_CHAR(nRegra) || ' ATOMEDICO ');
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          DBMS_OUTPUT.PUT_LINE(' PRODUTO     : SEM CADASTRO ');
        WHEN TOO_MANY_ROWS THEN
          NULL;
      END;
    END IF; -- fim teste local
    IF (sCred IN (9, 7)) THEN
      ps_tipo := 'EMP';
    ELSE
      ps_tipo := 'IND';
    END IF;
  END VERIFICA_BRADESCO;

  --
  -- ============================================================================
  --
  PROCEDURE BUSCA_PRIORIDADE_SP(pn_codser     IN NUMBER,
                                ps_local      IN VARCHAR2,
                                ps_codcon     IN VARCHAR2,
                                pn_prioridade IN NUMBER,
                                ps_codpadpac  IN VARCHAR2,
                                pd_datexa     IN DATE,
                                ps_codtab     IN OUT VARCHAR2,
                                pn_percobtab  IN OUT NUMBER) IS
  BEGIN
    SELECT CODTAB, PERCOBTAB
      INTO ps_codtab, pn_percobtab
      FROM EXCESSAO_PRIORIDADE
     WHERE CODSER = pn_codser
       AND PRIORIDADE = pn_prioridade
       AND CODLOC = ps_local
       AND CODCON = ps_codcon
       AND CODPAD = ps_codpadpac
       AND (DT_VIGENCIA <= pd_datexa AND DT_FIM >= pd_datexa OR
           DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL);
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      BEGIN
        SELECT CODTAB, PERCOBTAB
          INTO ps_codtab, pn_percobtab
          FROM PRIORIDADE_TABELAS_SPREST
         WHERE CODSER = pn_codser
           AND PRIORIDADE = pn_prioridade
           AND CODLOC = ps_local
           AND CODCON = ps_codcon
           AND (DT_VIGENCIA <= pd_datexa AND DT_FIM >= pd_datexa OR
               DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL);
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          ps_codtab    := NULL;
          pn_percobtab := 0;
          dsadt.Pkg_Sadt.GRAVA_LOG('CALC_EXAME',
                             ' PESQUISA NA PRIORIDADE_TABELAS_SPREST ' ||
                             ' CONVENIO : ' || ps_codcon || ' CODSER : ' ||
                             TO_CHAR(pn_codser) || ' PRIORIDADE : ' ||
                             TO_CHAR(pn_prioridade) || ' PROCEDENCIA :' ||
                             ps_local);
        WHEN OTHERS THEN
          NULL;
      END;
  END BUSCA_PRIORIDADE_SP;

  --
  -- ============================================================================
  --
  PROCEDURE BUSCA_CODIGO_INDICE(ps_codtab    IN VARCHAR2,
                                ps_codindhos IN OUT VARCHAR2) IS
  BEGIN
    SELECT CODINDHOS
      INTO ps_codindhos
      FROM IDENTIFICACAO_TABELA
     WHERE CODTAB = ps_codtab;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      ps_codindhos := NULL;
      dsadt.Pkg_Sadt.GRAVA_LOG('CALC_EXAME',
                         ' PESQUISA NA IDENTIFICACAO_TABELA ');
  END;

  --
  -- *********************************************************************************************************
  --
  PROCEDURE VERIFICA_PRODUTO(ps_codcon    IN VARCHAR2,
                             pn_codateamb IN NUMBER,
                             pn_atomedico IN NUMBER,
                             pn_codser    IN NUMBER,
                             ps_local     IN VARCHAR2,
                             pd_data      IN DATE,
                             pn_valorch   IN OUT NUMBER) IS
    sCred       VARCHAR2(50);
    nRegra      NUMBER;
    sSubProduto VARCHAR2(10);
    nCodUniHos  NUMBER;
    sVerifica   VARCHAR2(3);
  BEGIN
    DBMS_OUTPUT.PUT_LINE(' ENTROU PRODUTO ');
    pn_valorch := 0;
    -- existe excecao para o convenio verifica se e a classe especifica
    IF ps_local = 'AMB' THEN
      -- BUSCA INFORMACOE DO ATENDIMENTO
      BEGIN
        SELECT SUBPRODUTO, CODUNIHOS
          INTO sSubProduto, nCodUniHos
          FROM PACIENTE_ATENDIMENTO_AMB
         WHERE CODATEAMB = pn_codateamb;
        DBMS_OUTPUT.PUT_LINE(' ##############  SUBPRODUTO ' || sSubProduto);
      EXCEPTION
        WHEN OTHERS THEN
          NULL;
      END;
      --
      -- VERIFICA SE EXISTE REGRA PRA ESTE CONVENIO
      --
      BEGIN
        SELECT VERIFICA
          INTO sVerifica
          FROM COM_REGRA_PRODUTO PRO, COM_UNIDADE_REGRA UNI
         WHERE PRO.CODCON = ps_codcon
           AND ((pd_data BETWEEN PRO.DT_INI AND PRO.DT_FIM) OR
               (pd_data >= PRO.DT_INI AND PRO.DT_FIM IS NULL))
           AND UNI.CODCON = PRO.CODCON
           AND UNI.REGRA = PRO.REGRA
           AND UNI.CODUNIHOS = nCodUniHos
           AND ((pd_data BETWEEN UNI.DT_INI AND UNI.DT_FIM) OR
               (pd_data >= UNI.DT_INI AND UNI.DT_FIM IS NULL));
        DBMS_OUTPUT.PUT_LINE(' ************* VERIFICA ' || sVerifica);
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          NULL;
        WHEN TOO_MANY_ROWS THEN
          DBMS_OUTPUT.PUT_LINE(' ************* TO_MANY_ROWS VERIFICA ' ||
                               sVerifica);
        WHEN OTHERS THEN
          NULL;
      END;

      IF sVerifica = 'SUB' THEN
        BEGIN
          SELECT REG.VLR,
                 SUBSTR(HOS.SUBPRODUTO, PRO.DIGITO_INI, PRO.QTD_DIGITO),
                 REG.REGRA
            INTO pn_valorch, sCred, nRegra
            FROM COM_REGRA_PROCEDIMENTO   ATO,
                 COM_REGRA_PRODUTO        REG,
                 COM_PRODUTO_CONVENIO     PRO,
                 COM_UNIDADE_REGRA        UNI,
                 PACIENTE_ATENDIMENTO_AMB HOS
           WHERE HOS.CODATEAMB = pn_codateamb
             AND REG.CODCON = ps_codcon
             AND ((pd_data BETWEEN REG.DT_INI AND REG.DT_FIM) OR
                 (REG.DT_INI <= pd_data AND REG.DT_FIM IS NULL))
             AND UNI.CODCON = REG.CODCON
             AND UNI.REGRA = REG.REGRA
             AND UNI.CODUNIHOS = HOS.CODUNIHOS
             AND ((pd_data BETWEEN UNI.DT_INI AND UNI.DT_FIM) OR
                 (pd_data >= UNI.DT_INI AND UNI.DT_FIM IS NULL))
             AND PRO.CODCON = REG.CODCON
             AND PRO.PRODUTO =
                 SUBSTR(HOS.SUBPRODUTO, PRO.DIGITO_INI, PRO.QTD_DIGITO)
             AND ATO.CODCON = REG.CODCON
             AND ATO.REGRA = REG.REGRA
             AND ATO.PRODUTO = PRO.PRODUTO
             AND ATO.CODATOMED = pn_atomedico;
          DBMS_OUTPUT.PUT_LINE(' PRODUTO     : ' || sCred || ' REGRA ' ||
                               TO_CHAR(nRegra) || ' ATOMEDICO ');
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            BEGIN
              SELECT REG.VLR,
                     SUBSTR(HOS.SUBPRODUTO, PRO.DIGITO_INI, PRO.QTD_DIGITO),
                     REG.REGRA
                INTO pn_valorch, sCred, nRegra
                FROM COM_REGRA_PROCEDIMENTO   ATO,
                     COM_REGRA_PRODUTO        REG,
                     COM_PRODUTO_CONVENIO     PRO,
                     COM_UNIDADE_REGRA        UNI,
                     PACIENTE_ATENDIMENTO_AMB HOS
               WHERE HOS.CODATEAMB = pn_codateamb
                 AND REG.CODCON = ps_codcon
                 AND ((pd_data BETWEEN REG.DT_INI AND REG.DT_FIM) OR
                     (REG.DT_INI <= pd_data AND REG.DT_FIM IS NULL))
                 AND UNI.CODCON = REG.CODCON
                 AND UNI.REGRA = REG.REGRA
                 AND UNI.CODUNIHOS = HOS.CODUNIHOS
                 AND ((pd_data BETWEEN UNI.DT_INI AND UNI.DT_FIM) OR
                     (pd_data >= UNI.DT_INI AND UNI.DT_FIM IS NULL))
                 AND PRO.CODCON = REG.CODCON
                 AND PRO.PRODUTO =
                     SUBSTR(HOS.SUBPRODUTO, PRO.DIGITO_INI, PRO.QTD_DIGITO)
                 AND ATO.CODCON = REG.CODCON
                 AND ATO.REGRA = REG.REGRA
                 AND ATO.PRODUTO = PRO.PRODUTO
                 AND ATO.CODSER = pn_codser;
              DBMS_OUTPUT.PUT_LINE(' PRODUTO     : ' || sCred || ' REGRA ' ||
                                   TO_CHAR(nRegra) || ' CODSER ');
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                DBMS_OUTPUT.PUT_LINE(' PRODUTO     : SEM CADASTRO ');
                pn_valorch := 0;
              WHEN TOO_MANY_ROWS THEN
                dsadt.Pkg_Sadt.GRAVA_LOG('PRODUTO',
                                   'CODSER ' || TO_CHAR(pn_codser) ||
                                   ' ATO ' || TO_CHAR(pn_atomedico) ||
                                   ' CODCON ' || ps_codcon);
            END; -- FIM BEGIN DO EXCEPTION
          WHEN TOO_MANY_ROWS THEN
            dsadt.Pkg_Sadt.GRAVA_LOG('PRODUTO',
                               'CODSER ' || TO_CHAR(pn_codser) || ' ATO ' ||
                               TO_CHAR(pn_atomedico) || ' CODCON ' ||
                               ps_codcon);
        END;
      ELSIF sVerifica = 'CRE' THEN
        -- PRODUTO VERIFICADO NA CREDENCIAL
        BEGIN
          SELECT REG.VLR,
                 SUBSTR(HOS.NUMCRE, PRO.DIGITO_INI, PRO.QTD_DIGITO),
                 REG.REGRA
            INTO pn_valorch, sCred, nRegra
            FROM COM_REGRA_PROCEDIMENTO   ATO,
                 COM_REGRA_PRODUTO        REG,
                 COM_PRODUTO_CONVENIO     PRO,
                 COM_UNIDADE_REGRA        UNI,
                 PACIENTE_ATENDIMENTO_AMB HOS
           WHERE HOS.CODATEAMB = pn_codateamb
             AND REG.CODCON = ps_codcon
             AND ((pd_data BETWEEN REG.DT_INI AND REG.DT_FIM) OR
                 (REG.DT_INI <= pd_data AND REG.DT_FIM IS NULL))
             AND PRO.CODCON = REG.CODCON
             AND UNI.CODCON = REG.CODCON
             AND UNI.REGRA = REG.REGRA
             AND UNI.CODUNIHOS = HOS.CODUNIHOS
             AND ((pd_data BETWEEN UNI.DT_INI AND UNI.DT_FIM) OR
                 (pd_data >= UNI.DT_INI AND UNI.DT_FIM IS NULL))
             AND PRO.PRODUTO =
                 SUBSTR(HOS.NUMCRE, PRO.DIGITO_INI, PRO.QTD_DIGITO)
             AND ATO.CODCON = REG.CODCON
             AND ATO.REGRA = REG.REGRA
             AND ATO.PRODUTO = PRO.PRODUTO
             AND ATO.CODATOMED = pn_atomedico;
          DBMS_OUTPUT.PUT_LINE(' PRODUTO     : ' || sCred || ' REGRA ' ||
                               TO_CHAR(nRegra) || ' ATOMEDICO ');
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            BEGIN
              SELECT REG.VLR,
                     SUBSTR(HOS.NUMCRE, PRO.DIGITO_INI, PRO.QTD_DIGITO),
                     REG.REGRA
                INTO pn_valorch, sCred, nRegra
                FROM COM_REGRA_PROCEDIMENTO   ATO,
                     COM_REGRA_PRODUTO        REG,
                     COM_PRODUTO_CONVENIO     PRO,
                     COM_UNIDADE_REGRA        UNI,
                     PACIENTE_ATENDIMENTO_AMB HOS
               WHERE HOS.CODATEAMB = pn_codateamb
                 AND UNI.REGRA = REG.REGRA
                 AND UNI.CODUNIHOS = HOS.CODUNIHOS
                 AND UNI.CODCON = REG.CODCON
                 AND REG.CODCON = ps_codcon
                 AND ((pd_data BETWEEN REG.DT_INI AND REG.DT_FIM) OR
                     (REG.DT_INI <= pd_data AND REG.DT_FIM IS NULL))
                 AND PRO.CODCON = REG.CODCON
                 AND PRO.PRODUTO =
                     SUBSTR(HOS.NUMCRE, PRO.DIGITO_INI, PRO.QTD_DIGITO)
                 AND ATO.CODCON = REG.CODCON
                 AND ATO.REGRA = REG.REGRA
                 AND ATO.PRODUTO = PRO.PRODUTO
                 AND ATO.CODSER = pn_codser;
              DBMS_OUTPUT.PUT_LINE(' PRODUTO     : ' || sCred || ' REGRA ' ||
                                   TO_CHAR(nRegra) || ' CODSER ');
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                DBMS_OUTPUT.PUT_LINE(' PRODUTO     : SEM CADASTRO ');
                pn_valorch := 0;
              WHEN TOO_MANY_ROWS THEN
                dsadt.Pkg_Sadt.GRAVA_LOG('PRODUTO',
                                   'CODSER ' || TO_CHAR(pn_codser) ||
                                   ' ATO ' || TO_CHAR(pn_atomedico) ||
                                   ' CODCON ' || ps_codcon);
            END; -- FIM BEGIN DO EXCEPTION
          WHEN TOO_MANY_ROWS THEN
            dsadt.Pkg_Sadt.GRAVA_LOG('PRODUTO',
                               'CODSER ' || TO_CHAR(pn_codser) || ' ATO ' ||
                               TO_CHAR(pn_atomedico) || ' CODCON ' ||
                               ps_codcon);
        END;
      END IF; -- FIM TESTE TIPO DE VERIFICACAO
    ELSIF ps_local = 'INT' THEN

      -- BUSCA INFORMACOE DO ATENDIMENTO
      BEGIN
        SELECT SUBPRODUTO, CODUNIHOS
          INTO sSubProduto, nCodUniHos
          FROM TB_INTERNADO
         WHERE NR_SEQINTER = pn_codateamb;
      EXCEPTION
        WHEN OTHERS THEN
          NULL;
      END;
      --
      -- VERIFICA SE EXISTE REGRA PRA ESTE CONVENIO
      --
      BEGIN
        SELECT VERIFICA
          INTO sVerifica
          FROM COM_REGRA_PRODUTO PRO, COM_UNIDADE_REGRA UNI
         WHERE PRO.CODCON = ps_codcon
           AND ((pd_data BETWEEN PRO.DT_INI AND PRO.DT_FIM) OR
               (pd_data >= PRO.DT_INI AND PRO.DT_FIM IS NULL))
           AND UNI.CODCON(+) = PRO.CODCON
           AND UNI.REGRA(+) = PRO.REGRA
           AND UNI.CODUNIHOS(+) = nCodUniHos
           AND ((pd_data BETWEEN UNI.DT_INI AND UNI.DT_FIM) OR
               (pd_data >= UNI.DT_INI AND UNI.DT_FIM IS NULL));
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          NULL;
        WHEN OTHERS THEN
          NULL;
      END;

      IF sVerifica = 'SUB' THEN
        BEGIN
          SELECT REG.VLR,
                 SUBSTR(HOS.SUBPRODUTO, PRO.DIGITO_INI, PRO.QTD_DIGITO),
                 REG.REGRA
            INTO pn_valorch, sCred, nRegra
            FROM COM_REGRA_PROCEDIMENTO ATO,
                 COM_REGRA_PRODUTO      REG,
                 COM_PRODUTO_CONVENIO   PRO,
                 COM_UNIDADE_REGRA      UNI,
                 TB_INTERNADO           HOS
           WHERE HOS.NR_SEQINTER = pn_codateamb
             AND REG.CODCON = ps_codcon
             AND ((pd_data BETWEEN REG.DT_INI AND REG.DT_FIM) OR
                 (REG.DT_INI <= pd_data AND REG.DT_FIM IS NULL))
             AND PRO.CODCON = REG.CODCON
             AND UNI.CODCON = REG.CODCON
             AND UNI.REGRA = REG.REGRA
             AND UNI.CODUNIHOS = HOS.CODUNIHOS
             AND ((pd_data BETWEEN UNI.DT_INI AND UNI.DT_FIM) OR
                 (pd_data >= UNI.DT_INI AND UNI.DT_FIM IS NULL))
             AND PRO.PRODUTO =
                 SUBSTR(HOS.SUBPRODUTO, PRO.DIGITO_INI, PRO.QTD_DIGITO)
             AND ATO.CODCON = REG.CODCON
             AND ATO.REGRA = REG.REGRA
             AND ATO.PRODUTO = PRO.PRODUTO
             AND ATO.CODATOMED = pn_atomedico;
          DBMS_OUTPUT.PUT_LINE(' PRODUTO     : ' || sCred || ' REGRA ' ||
                               TO_CHAR(nRegra) || ' ATOMEDICO ');
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            BEGIN
              SELECT REG.VLR,
                     SUBSTR(HOS.SUBPRODUTO, PRO.DIGITO_INI, PRO.QTD_DIGITO),
                     REG.REGRA
                INTO pn_valorch, sCred, nRegra
                FROM COM_REGRA_PROCEDIMENTO ATO,
                     COM_REGRA_PRODUTO      REG,
                     COM_PRODUTO_CONVENIO   PRO,
                     COM_UNIDADE_REGRA      UNI,
                     TB_INTERNADO           HOS
               WHERE HOS.NR_SEQINTER = pn_codateamb
                 AND REG.CODCON = ps_codcon
                 AND ((pd_data BETWEEN REG.DT_INI AND REG.DT_FIM) OR
                     (REG.DT_INI <= pd_data AND REG.DT_FIM IS NULL))
                 AND PRO.CODCON = REG.CODCON
                 AND UNI.CODCON = REG.CODCON
                 AND UNI.REGRA = REG.REGRA
                 AND UNI.CODUNIHOS = HOS.CODUNIHOS
                 AND ((pd_data BETWEEN UNI.DT_INI AND UNI.DT_FIM) OR
                     (pd_data >= UNI.DT_INI AND UNI.DT_FIM IS NULL))
                 AND PRO.PRODUTO =
                     SUBSTR(HOS.SUBPRODUTO, PRO.DIGITO_INI, PRO.QTD_DIGITO)
                 AND ATO.CODCON = REG.CODCON
                 AND ATO.REGRA = REG.REGRA
                 AND ATO.PRODUTO = PRO.PRODUTO
                 AND ATO.CODSER = pn_codser;
              DBMS_OUTPUT.PUT_LINE(' PRODUTO     : ' || sCred || ' REGRA ' ||
                                   TO_CHAR(nRegra) || ' CODSER ');
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                DBMS_OUTPUT.PUT_LINE(' PRODUTO     : SEM CADASTRO ');
                pn_valorch := 0;
              WHEN TOO_MANY_ROWS THEN
                dsadt.Pkg_Sadt.GRAVA_LOG('PRODUTO',
                                   'CODSER ' || TO_CHAR(pn_codser) ||
                                   ' ATO ' || TO_CHAR(pn_atomedico) ||
                                   ' CODCON ' || ps_codcon);
            END; -- FIM BEGIN DO EXCEPTION
          WHEN TOO_MANY_ROWS THEN
            dsadt.Pkg_Sadt.GRAVA_LOG('PRODUTO',
                               'CODSER ' || TO_CHAR(pn_codser) || ' ATO ' ||
                               TO_CHAR(pn_atomedico) || ' CODCON ' ||
                               ps_codcon);
        END;
      ELSIF sVerifica = 'CRE' THEN
        BEGIN
          SELECT REG.VLR,
                 SUBSTR(HOS.CRED, PRO.DIGITO_INI, PRO.QTD_DIGITO),
                 REG.REGRA
            INTO pn_valorch, sCred, nRegra
            FROM COM_REGRA_PROCEDIMENTO ATO,
                 COM_REGRA_PRODUTO      REG,
                 COM_PRODUTO_CONVENIO   PRO,
                 COM_UNIDADE_REGRA      UNI,
                 TB_INTERNADO           HOS
           WHERE HOS.NR_SEQINTER = pn_codateamb
             AND REG.CODCON = ps_codcon
             AND ((pd_data BETWEEN REG.DT_INI AND REG.DT_FIM) OR
                 (REG.DT_INI <= pd_data AND REG.DT_FIM IS NULL))
             AND PRO.CODCON = REG.CODCON
             AND UNI.CODCON = REG.CODCON
             AND UNI.REGRA = REG.REGRA
             AND UNI.CODUNIHOS = HOS.CODUNIHOS
             AND ((pd_data BETWEEN UNI.DT_INI AND UNI.DT_FIM) OR
                 (pd_data >= UNI.DT_INI AND UNI.DT_FIM IS NULL))
             AND PRO.PRODUTO =
                 SUBSTR(HOS.CRED, PRO.DIGITO_INI, PRO.QTD_DIGITO)
             AND ATO.CODCON = REG.CODCON
             AND ATO.REGRA = REG.REGRA
             AND ATO.PRODUTO = PRO.PRODUTO
             AND ATO.CODATOMED = pn_atomedico;
          DBMS_OUTPUT.PUT_LINE(' PRODUTO     : ' || sCred || ' REGRA ' ||
                               TO_CHAR(nRegra) || ' ATOMEDICO ');
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            BEGIN
              SELECT REG.VLR,
                     SUBSTR(HOS.CRED, PRO.DIGITO_INI, PRO.QTD_DIGITO),
                     REG.REGRA
                INTO pn_valorch, sCred, nRegra
                FROM COM_REGRA_PROCEDIMENTO ATO,
                     COM_REGRA_PRODUTO      REG,
                     COM_PRODUTO_CONVENIO   PRO,
                     COM_UNIDADE_REGRA      UNI,
                     TB_INTERNADO           HOS
               WHERE HOS.NR_SEQINTER = pn_codateamb
                 AND REG.CODCON = ps_codcon
                 AND ((pd_data BETWEEN REG.DT_INI AND REG.DT_FIM) OR
                     (REG.DT_INI <= pd_data AND REG.DT_FIM IS NULL))
                 AND PRO.CODCON = REG.CODCON
                 AND UNI.CODCON = REG.CODCON
                 AND UNI.REGRA = REG.REGRA
                 AND UNI.CODUNIHOS = HOS.CODUNIHOS
                 AND ((pd_data BETWEEN UNI.DT_INI AND UNI.DT_FIM) OR
                     (pd_data >= UNI.DT_INI AND UNI.DT_FIM IS NULL))
                 AND PRO.PRODUTO =
                     SUBSTR(HOS.CRED, PRO.DIGITO_INI, PRO.QTD_DIGITO)
                 AND ATO.CODCON = REG.CODCON
                 AND ATO.REGRA = REG.REGRA
                 AND ATO.PRODUTO = PRO.PRODUTO
                 AND ATO.CODSER = pn_codser;
              DBMS_OUTPUT.PUT_LINE(' PRODUTO     : ' || sCred || ' REGRA ' ||
                                   TO_CHAR(nRegra) || ' CODSER ');
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                pn_valorch := 0;
                DBMS_OUTPUT.PUT_LINE(' PRODUTO     : SEM CADASTRO ');
              WHEN TOO_MANY_ROWS THEN
                dsadt.Pkg_Sadt.GRAVA_LOG('PRODUTO',
                                   'CODSER ' || TO_CHAR(pn_codser) ||
                                   ' ATO ' || TO_CHAR(pn_atomedico) ||
                                   ' CODCON ' || ps_codcon);
            END; -- FIM BEGIN DO EXCEPTION
          WHEN TOO_MANY_ROWS THEN
            dsadt.Pkg_Sadt.GRAVA_LOG('PRODUTO',
                               'CODSER ' || TO_CHAR(pn_codser) || ' ATO ' ||
                               TO_CHAR(pn_atomedico) || ' CODCON ' ||
                               ps_codcon);
        END;
      END IF;
    END IF; -- fim teste local
  END VERIFICA_PRODUTO;

  ---
  ---****************************************************************************************
  ---
  -- procedure para calculo de desconto
  PROCEDURE CALC_DESCONTO(pn_atomedico   IN NUMBER,
                          ps_codcon      IN VARCHAR2,
                          pn_qtdch       IN NUMBER,
                          pn_percobtab   IN NUMBER,
                          pn_valorch     IN OUT NUMBER,
                          pn_valor_exame IN OUT NUMBER) IS
    vs_desconto VARCHAR2(3);
    vn_valorch  NUMBER(9, 2);
  BEGIN
    vn_valorch := pn_valorch;
    -- nao da desconto para estes convenios
    IF ps_codcon NOT IN ('G225', 'G226') THEN
      FOR teste IN (SELECT 1
                      FROM EMPRESA
                     WHERE CODCON = ps_codcon
                       AND CODTIPEMP IN ('GB', 'PL', 'FU', 'NP')) LOOP
        -- so entra aqui se for GLOBAL
        BEGIN
          SELECT ID_SERVICO
            INTO vs_desconto
            FROM ATO_MEDICO
           WHERE CODATOMED = pn_atomedico;
          IF vs_desconto = 'D' THEN
            pn_valorch := ROUND(pn_valorch - (pn_valorch * 0.037037), 2);
            -- pn_valorch := 0.26;
            pn_valor_exame := (pn_qtdch * pn_valorch) * Pn_percobtab;
          END IF;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            pn_valorch := vn_valorch;
        END;
        EXIT;
      END LOOP;
    END IF;
  END CALC_DESCONTO;

  PROCEDURE VERIFICA_ATOMEDICO_CLINICA(pnCodateamb   IN NUMBER,
                                       psCodcon      IN CHAR,
                                       pnCodatomed   IN NUMBER,
                                       psCodloc      IN VARCHAR2,
                                       pd_datexa     IN DATE,
                                       pn_cd_clinica IN NUMBER,
                                       pnRetorno     IN OUT NUMBER) IS
    sFlag      CHAR(1);
    nCodser    NUMBER(2);
    sCodtipemp VARCHAR2(2);
    sIndclacon CHAR(1);
    sEntrou    CHAR(1);
    vs_tipo    VARCHAR2(5);
    vs_codtab  VARCHAR2(4);
  BEGIN
    dsadt.Pkg_Sadt.BUSCA_CODSER(pnCodatomed, nCodser);
    IF psCodcon IN ('G225', 'G226') THEN
      sCodtipemp := 'SP';
    ELSE
      sCodtipemp := dsadt.Pkg_Sadt.BUSCA_TIPOEMPRESA(psCodcon);
    END IF;
    Busca_Indclacon(pnCodatomed, sIndclacon);
    sEntrou := NULL;
    sFlag   := NULL;
    IF sCodtipemp NOT IN ('GB', 'PL', 'FU', 'NP') THEN
      IF psCodcon IN ('SZ87', 'SZ78') THEN
        VERIFICA_BRADESCO(psCodcon,
                          pnCodateamb,
                          psCodloc,
                          pd_datexa,
                          vs_tipo);
        IF vs_tipo = 'EMP' THEN
          vs_codtab := 'B2';
        ELSIF vs_tipo = 'IND' THEN
          vs_codtab := 'B1';
        END IF;
        --
        BEGIN
          SELECT DISTINCT 'X'
            INTO sFlag
            FROM ITEM_TABELA
           WHERE codtab = vs_codtab
             AND codatomed = pnCodatomed;
          pnRetorno := 0;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            NULL;
          WHEN TOO_MANY_ROWS THEN
            pnRetorno := 0;
            sFlag     := 'X';
        END;
      END IF;
      --
      IF sFlag IS NULL THEN
        BEGIN
          SELECT 'X'
            into sFlag
            FROM EXCESSAO_ITEM_TABELA_SP_INT E
           WHERE CODCON = psCodcon
             AND CODATOMED = pnCodatomed
             AND DATEXCSP = (SELECT MAX(DATEXCSP)
                               FROM EXCESSAO_ITEM_TABELA_SP_INT X
                              WHERE E.CODCON = X.CODCON
                                AND E.CODATOMED = X.CODATOMED
                                AND E.CODPAD = X.CODPAD
                                AND DATEXCSP <= pd_datexa)
             AND ROWNUM = 1;
          pnRetorno := 0;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            NULL;
        END;
      END IF;
      --
      IF sFlag IS NULL THEN
        --
        FOR TABS IN (SELECT DISTINCT codtab
                       FROM EXCESSAO_PRIORIDADE E1
                      WHERE codcon = psCodcon
                        AND codser = nCodser
                        AND codloc = psCodloc
                        AND (DT_VIGENCIA <= pd_datexa AND
                            DT_FIM >= pd_datexa OR
                            DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL))
        -- DIOGO AQUI
         LOOP
          sEntrou := 'S';
          BEGIN
            SELECT DISTINCT 'X'
              INTO sFlag
              FROM ITEM_TABELA
             WHERE codtab = TABS.codtab
               AND codatomed = pnCodatomed;
            pnRetorno := 0;
            EXIT;
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              BEGIN
                SELECT 'X'
                  into sFlag
                  FROM EXCESSAO_ATOMED_SP
                 WHERE CODCON = psCodcon
                   AND CODATOMED = pnCodatomed
                   AND DATEXCSP =
                       (SELECT MAX(DATEXCSP)
                          FROM EXCESSAO_ATOMED_SP
                         WHERE CODCON = psCodcon
                           AND CODATOMED = pnCodatomed
                           AND DATEXCSP <= TO_DATE(TO_CHAR(pd_datexa)))
                   AND ROWNUM = 1;
                pnRetorno := 0;
                EXIT;
              EXCEPTION
                WHEN NO_DATA_FOUND THEN
                  NULL;
              END;
            WHEN TOO_MANY_ROWS THEN
              pnRetorno := 0;
          END;
        END LOOP;
        IF sEntrou IS NULL THEN
          FOR TABS IN (SELECT DISTINCT codtab
                         FROM PRIORIDADE_TABELAS_SPREST p1
                        WHERE codcon = psCodcon
                          AND codser = nCodser
                          AND codloc = psCodloc
                          AND (DT_VIGENCIA <= pd_datexa AND
                              DT_FIM >= pd_datexa OR
                              DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL))
          --  VERIFICA AQUI, DIOGO,  NAO TEM FILTRO PARA PRIORIDADE
           LOOP
            BEGIN
              SELECT DISTINCT 'X'
                INTO sFlag
                FROM ITEM_TABELA
               WHERE codtab = TABS.codtab
                 AND codatomed = pnCodatomed;
              pnRetorno := 0;
              EXIT;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                BEGIN
                  SELECT 'X'
                    into sFlag
                    FROM EXCESSAO_ATOMED_SP
                   WHERE CODCON = psCodcon
                     AND CODATOMED = pnCodatomed
                     AND DATEXCSP =
                         (SELECT MAX(DATEXCSP)
                            FROM EXCESSAO_ATOMED_SP
                           WHERE CODCON = psCodcon
                             AND CODATOMED = pnCodatomed
                             AND DATEXCSP <= TO_DATE(TO_CHAR(pd_datexa)))
                     AND ROWNUM = 1;
                  pnRetorno := 0;
                  EXIT;
                EXCEPTION
                  WHEN NO_DATA_FOUND THEN
                    NULL;
                END;
              WHEN TOO_MANY_ROWS THEN
                pnRetorno := 0;
            END;
          END LOOP;
        END IF;
      END IF;
    ELSE
      -- GLOBAL AMB --
      IF psCodloc = CGS_LOCAL_AMB THEN
        BEGIN
          sFlag := NULL;
          SELECT 'X'
            into sFlag
            FROM EXCESSAO_ATOMED_SP
           WHERE CODCON = psCodcon
             AND CODATOMED = pnCodatomed
             AND DATEXCSP <= pd_datexa
             AND ROWNUM = 1;
          pnRetorno := 0;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            NULL;
        END;
        --
        IF sFlag is null then
          FOR TABS IN (SELECT 'A1' codtab
                         FROM dual
                        WHERE pd_datexa < TO_DATE('01052008', 'DDMMYYYY')
                           OR pn_cd_clinica IN (45, 49, 50, 51, 52)
                       UNION
                       SELECT 'A3'
                         FROM dual
                       UNION
                       SELECT 'H'
                         FROM dual
                        WHERE pd_datexa < TO_DATE('01082003', 'DDMMYYYY')
                       UNION
                       SELECT 'H1'
                         FROM DUAL
                        WHERE pd_datexa between
                              TO_DATE('01082003', 'DDMMYYYY') and
                              TO_DATE('11032007', 'DDMMYYYY')
                       UNION
                       SELECT 'AC'
                         FROM DUAL
                        WHERE pd_datexa >= TO_DATE('12032007', 'DDMMYYYY')) LOOP
            BEGIN
              SELECT DISTINCT 'X'
                INTO sFlag
                FROM ITEM_TABELA
               WHERE codtab = TABS.codtab
                 AND codatomed = pnCodatomed;
              pnRetorno := 0;
              EXIT;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                NULL;
              WHEN TOO_MANY_ROWS THEN
                NULL;
            END;
          END LOOP;
        END IF;
      ELSE
        -- LOCAL INTERNACAO, GLOBAL
        BEGIN
          sFlag := NULL;
          SELECT 'X'
            into sFlag
            FROM EXCESSAO_ITEM_TABELA_SP_INT E
           WHERE CODCON = psCodcon
             AND CODATOMED = pnCodatomed
             AND DATEXCSP = (SELECT MAX(DATEXCSP)
                               FROM EXCESSAO_ITEM_TABELA_SP_INT X
                              WHERE E.CODCON = X.CODCON
                                AND E.CODATOMED = X.CODATOMED
                                AND E.CODPAD = X.CODPAD
                                AND X.DATEXCSP <= pd_datexa)
             AND ROWNUM = 1;
          pnRetorno := 0;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            NULL;
        END;
        --
        vs_codtab := NULL;
        IF sFlag is null then
          FOR TABS IN (SELECT DISTINCT codtab
                         FROM PRIORIDADE_GLOBAL
                        WHERE codtipemp = sCodtipemp
                          AND codserini <= nCodser
                          AND codserfim >= nCodser
                          AND indclacon = sIndclacon
                          AND (DT_VIGENCIA <= pd_datexa AND
                              DT_FIM >= pd_datexa OR
                              DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL)
                       UNION
                       SELECT DISTINCT codtab
                         FROM EXCESSAO_PRIORIDADE_GLOBAL
                        WHERE codcon = psCodcon
                          AND codserini <= nCodser
                          AND codserfim >= nCodser
                          AND (DT_VIGENCIA <= pd_datexa AND
                              DT_FIM >= pd_datexa OR
                              DT_VIGENCIA <= pd_datexa AND DT_FIM IS NULL)) LOOP
            BEGIN
              IF TABS.codtab = 'A3' and
                 pn_cd_clinica in (45, 49, 50, 51, 52) and
                 pd_datexa >= to_date('01052008', 'ddmmyyyy') THEN
                vs_codtab := 'A8';
              ELSE
                vs_codtab := TABS.CODTAB;
              END IF;
              SELECT DISTINCT 'X'
                INTO sFlag
                FROM ITEM_TABELA
               WHERE codtab = vs_codtab
                 AND codatomed = pnCodatomed;
              pnRetorno := 0;
              EXIT;
            EXCEPTION
              WHEN NO_DATA_FOUND THEN
                NULL;
              WHEN TOO_MANY_ROWS THEN
                NULL;
            END;
          END LOOP;
        END IF;
      END IF;
    END IF;
    IF sFlag IS NULL THEN
      pnRetorno := 1;
    END IF;
  END VERIFICA_ATOMEDICO_CLINICA;

end PKG_LEGADO;