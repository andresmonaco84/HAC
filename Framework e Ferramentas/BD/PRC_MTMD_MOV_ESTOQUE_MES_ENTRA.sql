CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_ESTOQUE_MES_ENTRA (
nPasso IN NUMBER default null,
pDataDe IN DATE,
pDataAte IN DATE
) is
  /*
 Gera estoque incial de controle para contabilidade
 MES ESTOQUE INICIAL: 10
 ANO ESTOQUE INCIAL: 2010
*/
-- vMTMD_SALDO_ATUAL            NUMBER(15,2);
--vMTMD_VALOR_ATUAL            NUMBER(15,2);
vCAD_MTMD_GRUPO_ID            TB_CAD_MTMD_MAT_MED.cad_mtmd_grupo_id%TYPE;
vCAD_MTMD_SUBGRUPO_ID         TB_CAD_MTMD_MAT_MED.cad_mtmd_SUBgrupo_id%TYPE;
vMTMD_QTDE_ENTRADA           NUMBER;
vMTMD_VALOR_ENTRADA          NUMBER(15,2);
vMTMD_CUSTO_MEDIO            NUMBER(15,2);
/*vMTMD_MOV_ESTOQUE_ANTERIOR   NUMBER;
vMTMD_CUSTO_MEDIO_ANTERIOR   NUMBER(15,2);
vMTMD_VALOR_TOTAL_ANTERIOR   NUMBER(15,2);
vMTMD_VALOR_MOVIMENTO        NUMBER(15,2);
vMTMD_VALOR_SAIDA            NUMBER(15,2);
vMTMD_QTDE_SAIDA             NUMBER;
vMTMD_QTDE_ACERTO            NUMBER;
vCAD_LAT_ID_LOCAL_ATENDIMENTO TB_MTMD_MOV_ESTOQUE_MES.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vCAD_UNI_ID_UNIDADE           TB_MTMD_MOV_ESTOQUE_MES.CAD_UNI_ID_UNIDADE%type;
vCAD_SET_ID                   TB_MTMD_MOV_ESTOQUE_MES.CAD_SET_ID%type;
vQtdeMovimentada NUMBER;
vQtdeAcerto      NUMBER;
dData            DATE;
d1               DATE;
d2               DATE;
vCAD_MTMD_FL_FRACIONA NUMBER;*/
-- ===========================================================================================================================
-- INICIO PROCEDURE
-- ===========================================================================================================================
BEGIN
  -- EXCLUI TODOS OS DADOS DO MES
  DELETE sgs.TB_MTMD_MOV_ESTOQUE_DIA_X;
  COMMIT;
  FOR AJUSTE IN
   ( SELECT
            TMOV.IDMOV,
            --DECODE(TMOV.CODFILIAL, 51, 2, 1) CODHOS,
            CASE
                 WHEN (TMOV.CODCOLIGADA = 2 OR TMOV.CODFILIAL = 51) THEN
                      2
                 WHEN (CODTMV = '1.4.01') THEN
                      5
                 ELSE
                      1
            END CODHOS,
            DATASAIDA DATASAIDA,
            TPRD.IDPRD,
            MTMD.CAD_MTMD_ID,
            TITMMOV.QUANTIDADE,
            (CASE
             WHEN (TITMMOV.QUANTIDADE*TUND.FATORCONVERSAO) < 1 THEN 1
             ELSE (TITMMOV.QUANTIDADE*TUND.FATORCONVERSAO)
             END) QTDE_REL,
            ((TITMMOV.VALORFINANCEIRO +
             (CASE
              WHEN (TITMMOV.VALORDESP >= 1 AND TITMMOV.CODCOLIGADA = 2) THEN TITMMOV.VALORDESP
              ELSE 0
              END)) + --Soma Frete apenas p/ Coligada 2
             (DECODE(TMOV.CODCOLIGADA, 2, NVL(TMOV.VALORFRETE, 0), 0) /
              (SELECT COUNT(IDMOV) FROM TITMMOV@RMDB ITENSRM
               WHERE ITENSRM.IDMOV = TMOV.IDMOV AND ITENSRM.CODCOLIGADA = TMOV.CODCOLIGADA))) VALOR_REL,
             --TITMMOV.VALORFINANCEIRO VALOR_REL,
             TUND.FATORCONVERSAO,
             /*TITMMOV.CODTB3FAT CAD_MTMD_GRUPO_ID,
             TITMMOV.CODTB4FAT CAD_MTMD_SUBGRUPO_ID,*/
             MTMD.CAD_MTMD_GRUPO_ID,
             MTMD.CAD_MTMD_SUBGRUPO_ID,
             CODTMV,
             TITMMOV.VALORTOTALITEM
      FROM  TMOV@RMDB TMOV,
            FCFOCOMPL@RMDB FCFOCOMPL,
            TITMMOV@RMDB TITMMOV,
            TPRD@RMDB TPRD,
            TUND@RMDB TUND,
            TTRBMOV@RMDB TTRBMOV,
            TTRBMOV@RMDB TTRBMOV_ICMS,
            TUND@RMDB TUNDVENDA,
            MTM_MAT_MED M,
            TB_CAD_MTMD_MAT_MED MTMD
 WHERE (       CODTMV = '1.2.41'
           OR  CODTMV = '1.2.45'
           OR  CODTMV = '1.2.46'
           OR  CODTMV = '1.2.47'
           OR  CODTMV = '1.2.48'
           OR  CODTMV = '1.2.51'
           OR  CODTMV = '1.2.56'
           OR  CODTMV = '1.2.58'
           OR  CODTMV = '1.2.62'
           OR  CODTMV = '1.2.64'
           OR  CODTMV = '1.2.70'
           OR  CODTMV = '1.4.01'
           OR  CODTMV = '2.2.03')
 AND TMOV.CODCOLIGADA = FCFOCOMPL.CODCOLIGADA(+)
 AND TMOV.CODCFO = FCFOCOMPL.CODCFO(+)
 AND TITMMOV.CODCOLIGADA = TPRD.CODCOLIGADA
 AND TITMMOV.IDPRD = TPRD.IDPRD
 AND TMOV.CODCOLIGADA = TITMMOV.CODCOLIGADA
 AND TMOV.IDMOV = TITMMOV.IDMOV
 AND TUND.CODUND = TITMMOV.CODUND
 AND TUNDVENDA.CODUND = TPRD.CODUNDVENDA
 AND TTRBMOV.CODCOLIGADA(+)  = TITMMOV.CODCOLIGADA
 AND TTRBMOV.IDMOV(+)        = TITMMOV.IDMOV
 AND TTRBMOV.NSEQITMMOV(+)   = TITMMOV.NSEQITMMOV
 AND TTRBMOV.CODTRB(+)       = 'IPI'
 AND TTRBMOV_ICMS.CODCOLIGADA(+)  = TITMMOV.CODCOLIGADA
 AND TTRBMOV_ICMS.IDMOV(+)        = TITMMOV.IDMOV
 AND TTRBMOV_ICMS.NSEQITMMOV(+)   = TITMMOV.NSEQITMMOV
 AND TTRBMOV_ICMS.CODTRB(+)       = 'ICMS'
 ---
--   and TMOV.IDMOV       = ICMS.IDMOV(+)
--   and TMOV.CODCOLIGADA = ICMS.CODCOLIGADA(+)
 --and TMOV.DATASAIDA >= TO_DATE('01012011 0000','DDMMYYYY  HH24MI')  AND TMOV.DATASAIDA <= TO_DATE('31012011 2359','DDMMYYYY HH24MI')
 and trunc(TMOV.DATASAIDA) >= trunc(pDataDe) AND trunc(TMOV.DATASAIDA) <= trunc(pDataAte)
 and M.CODALFMAT(+)  = SUBSTR(TPRD.CODIGOPRD,1,7)
 AND TMOV.CODCOLIGADA IN (1,2)
 --AND MTMD.CAD_MTMD_CD_RM(+) = TPRD.IDPRD
 AND TRIM(MTMD.CAD_MTMD_CODMNE) = TRIM(TPRD.CODIGOPRD)
-- AND TMOV.codfilial != 51
-- AND MTMD.CAD_MTMD_ID = 4615
 order by 3, 9, 6)
 LOOP
      /*IF (AJUSTE.IDMOV = 4606935) THEN
         AJUSTE.VALOR_REL := AJUSTE.VALOR_REL + 30;
      ELSIF (AJUSTE.IDMOV = 4607225) THEN
         AJUSTE.VALOR_REL := AJUSTE.VALOR_REL + 30;
      ELSIF (AJUSTE.IDMOV = 4609250) THEN
         AJUSTE.VALOR_REL := AJUSTE.VALOR_REL + 28.2;
      ELSIF (AJUSTE.IDMOV = 4609671 and AJUSTE.IDPRD = 5577) THEN
         AJUSTE.VALOR_REL := AJUSTE.VALOR_REL + 6.7;
      END IF;*/
      -- BUSCA GRUPO DO CADASTRO
      /*
      BEGIN
         SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID
         INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID
         FROM SGS.TB_MTMD_ESTOQUE_CONTABIL_FECHA MTMD
         WHERE MTMD.CAD_MTMD_ID        = AJUSTE.CAD_MTMD_ID
         AND   MTMD.CAD_MTMD_FILIAL_ID = AJUSTE.CODHOS;
      EXCEPTION WHEN NO_DATA_FOUND THEN
         BEGIN
            SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID
            INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID
            FROM SGS.TB_MTMD_ESTOQUE_CONTABIL MTMD
            WHERE MTMD.CAD_MTMD_ID        = AJUSTE.CAD_MTMD_ID
            AND   MTMD.CAD_MTMD_FILIAL_ID = AJUSTE.CODHOS;
         EXCEPTION WHEN NO_DATA_FOUND THEN
           vCAD_MTMD_GRUPO_ID := 0;
           vCAD_MTMD_SUBGRUPO_ID := 0;
         END;
      END;
      */
    /*BEGIN
        SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID
        INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID
        FROM TB_CAD_MTMD_MAT_MED MTMD
        WHERE MTMD.CAD_MTMD_ID = AJUSTE.CAD_MTMD_ID;
        --CONT.CAD_MTMD_GRUPO_ID    := vCAD_MTMD_GRUPO_ID;
        --CONT.CAD_MTMD_SUBGRUPO_ID := vCAD_MTMD_SUBGRUPO_ID;
    END;*/
    vCAD_MTMD_GRUPO_ID := AJUSTE.CAD_MTMD_GRUPO_ID;
    vCAD_MTMD_SUBGRUPO_ID := AJUSTE.CAD_MTMD_SUBGRUPO_ID;
    vMTMD_QTDE_ENTRADA  := NVL(AJUSTE.QTDE_REL,0);
    IF (AJUSTE.CODTMV = '1.2.64') THEN --N?o entra custo para movimento de bonificac?o (apenas qtd.)
        vMTMD_CUSTO_MEDIO   := 0;
        vMTMD_VALOR_ENTRADA := 0;
    ELSIF (AJUSTE.CODTMV = '2.2.03') THEN --Negativa qtd/valor para movimento de devoluc?o
        vMTMD_QTDE_ENTRADA  := -NVL(AJUSTE.QTDE_REL,0);
        vMTMD_CUSTO_MEDIO   := (NVL(AJUSTE.VALOR_REL,0)/NVL(AJUSTE.QTDE_REL,0));
        vMTMD_VALOR_ENTRADA := -NVL(AJUSTE.VALORTOTALITEM,0);
    ELSE
        vMTMD_CUSTO_MEDIO   := (NVL(AJUSTE.VALOR_REL,0)/NVL(AJUSTE.QTDE_REL,0));
        vMTMD_VALOR_ENTRADA := NVL(AJUSTE.VALOR_REL,0);
    END IF;
    INSERT INTO SGS.TB_MTMD_MOV_ESTOQUE_DIA_X
    (MTMD_MOV_DATA,                   CAD_MTMD_ID,                    CAD_MTMD_FILIAL_ID,
     CAD_UNI_ID_UNIDADE,              CAD_SET_ID,                     CAD_LAT_ID_LOCAL_ATENDIMENTO,
     MTMD_SALDO_ANTERIOR,             MTMD_VALOR_ANTERIOR,            MTMD_CUSTO_MEDIO_ANTERIOR,
     MTMD_QTDE_ENTRADA,               MTMD_VALOR_ENTRADA,
     MTMD_QTDE_SAIDA,                 MTMD_VALOR_SAIDA,
     MTMD_SALDO_ATUAL,                MTMD_VALOR_ATUAL,               MTMD_CUSTO_MEDIO_ATUAL,
     CAD_MTMD_GRUPO_ID,               CAD_MTMD_SUBGRUPO_ID,
     MTMD_QTDE_ACERTO,                SEG_USU_ID_USUARIO,
     SEG_DT_ATUALIZACAO,              CAD_MTMD_TPMOV_ID,              CAD_MTMD_SUBTP_ID )
    VALUES
    (AJUSTE.DATASAIDA,               AJUSTE.CAD_MTMD_ID,              AJUSTE.CODHOS,
     244,                            29,                              33,
     0,                              0,                               0,
     vMTMD_QTDE_ENTRADA,             vMTMD_VALOR_ENTRADA,
     0,                              0,
     0,                              0,                               (vMTMD_CUSTO_MEDIO),
     vCAD_MTMD_GRUPO_ID,             vCAD_MTMD_SUBGRUPO_ID,
     0,                              1,
     SYSDATE,                        1,                               1);
     COMMIT;
    /*BEGIN
      INSERT INTO SGS.TB_MTMD_MOV_ESTOQUE_DIA_X
      (MTMD_MOV_DATA,                   CAD_MTMD_ID,                    CAD_MTMD_FILIAL_ID,
       CAD_UNI_ID_UNIDADE,              CAD_SET_ID,                     CAD_LAT_ID_LOCAL_ATENDIMENTO,
       MTMD_SALDO_ANTERIOR,             MTMD_VALOR_ANTERIOR,            MTMD_CUSTO_MEDIO_ANTERIOR,
       MTMD_QTDE_ENTRADA,               MTMD_VALOR_ENTRADA,
       MTMD_QTDE_SAIDA,                 MTMD_VALOR_SAIDA,
       MTMD_SALDO_ATUAL,                MTMD_VALOR_ATUAL,               MTMD_CUSTO_MEDIO_ATUAL,
       CAD_MTMD_GRUPO_ID,               CAD_MTMD_SUBGRUPO_ID,
       MTMD_QTDE_ACERTO,                SEG_USU_ID_USUARIO,
       SEG_DT_ATUALIZACAO,              CAD_MTMD_TPMOV_ID,              CAD_MTMD_SUBTP_ID )
      VALUES
      (AJUSTE.DATASAIDA,               AJUSTE.CAD_MTMD_ID,              AJUSTE.CODHOS,
       244,                            29,                              33,
       0,                              0,                               0,
       vMTMD_QTDE_ENTRADA,             vMTMD_VALOR_ENTRADA,
       0,                              0,
       0,                              0,                               (vMTMD_CUSTO_MEDIO),
       vCAD_MTMD_GRUPO_ID,             vCAD_MTMD_SUBGRUPO_ID,
       0,                              1,
       SYSDATE,                        1,                               1);
       COMMIT;
   EXCEPTION
      WHEN DUP_VAL_ON_INDEX THEN
         UPDATE SGS.TB_MTMD_MOV_ESTOQUE_DIA_X SET
         MTMD_QTDE_ENTRADA        =  NVL(MTMD_QTDE_ENTRADA,0)  + vMTMD_QTDE_ENTRADA,
         MTMD_VALOR_ENTRADA       =  NVL(MTMD_VALOR_ENTRADA,0) + NVL(vMTMD_VALOR_ENTRADA,0),
         MTMD_CUSTO_MEDIO_ATUAL   =  vMTMD_CUSTO_MEDIO,
         SEG_DT_ATUALIZACAO       =  SYSDATE
         WHERE MTMD_MOV_DATA                = TO_DATE('01012011','DDMMYYYY')
         AND   CAD_MTMD_ID                  = AJUSTE.CAD_MTMD_ID
         AND   CAD_MTMD_FILIAL_ID           = AJUSTE.CODHOS
         AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
         AND   CAD_UNI_ID_UNIDADE           = 244
         AND   CAD_SET_ID                   = 29
         AND   CAD_MTMD_TPMOV_ID            = 1
         AND   CAD_MTMD_SUBTP_ID            = 1;
         COMMIT;
      WHEN OTHERS THEN
       RAISE_APPLICATION_ERROR(-20000,' ERRO INSERINDO '||SQLERRM);
   END;
   COMMIT;*/
 END LOOP;
-- DELETE TB_MTMD_MOV_ESTOQUE_DIA
-- WHERE CAD_MTMD_ID = 811;
-- FOR CONT IN (  -- SELECT * FROM sgs.TB_MTMD_ESTOQUE_CONTABIL_FECHA
--                   SELECT * FROM sgs.TB_MTMD_ESTOQUE_CONTABIL
--                WHERE CAD_MTMD_ID = 811
--              )
-- LOOP
   -- GERA MOVIMENTCAO DE ENTRADA DO ACERTO CONTABIL
   -- GRP E SUB
--   vCAD_MTMD_GRUPO_ID    :=NVL(CONT.CAD_MTMD_GRUPO_ID,0);
--   vCAD_MTMD_SUBGRUPO_ID :=NVL(CONT.CAD_MTMD_SUBGRUPO_ID,0);
   /*
   IF ( vCAD_MTMD_GRUPO_ID = 0 ) THEN
      -- BUSCA GRUPO DO CADASTRO
      BEGIN
         SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID
         INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID
         FROM TB_CAD_MTMD_MAT_MED MTMD
         WHERE MTMD.CAD_MTMD_ID = CONT.CAD_MTMD_ID;
      END;
   END IF;
   */
--==================================================================================================
-- INICIO PARTE 1
--==================================================================================================
/*
IF (  nPasso = 1 OR nPasso = 5 ) THEN
FOR CONT IN (SELECT * FROM sgs.TB_MTMD_ESTOQUE_CONTABIL_FECHA)
LOOP
   IF ( NVL(CONT.CAD_MTMD_GRUPO_ID,0) = 0 ) THEN
      -- BUSCA GRUPO DO CADASTRO
      BEGIN
         SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID, MTMD.CAD_MTMD_FL_FRACIONA
         INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID,     vCAD_MTMD_FL_FRACIONA
         FROM TB_CAD_MTMD_MAT_MED MTMD
         WHERE MTMD.CAD_MTMD_ID = CONT.CAD_MTMD_ID;
         CONT.CAD_MTMD_GRUPO_ID    := vCAD_MTMD_GRUPO_ID;
         CONT.CAD_MTMD_SUBGRUPO_ID := vCAD_MTMD_SUBGRUPO_ID;
      END;
   END IF;
   IF ( CONT.CAD_MTMD_GRUPO_ID != 4 ) THEN
      vMTMD_VALOR_ENTRADA := NVL(CONT.MTMD_CUSTO_MEDIO_INICIAL,0)*NVL(CONT.MTMD_SALDO_INICIAL,0);
      BEGIN
            INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
            (MTMD_MOV_DATA,                        CAD_MTMD_ID,                           CAD_MTMD_FILIAL_ID,
             CAD_LAT_ID_LOCAL_ATENDIMENTO,         CAD_UNI_ID_UNIDADE,                    CAD_SET_ID,
             MTMD_CUSTO_MEDIO_ANTERIOR,            MTMD_SALDO_ANTERIOR,                   MTMD_VALOR_ANTERIOR,
             MTMD_QTDE_ENTRADA,                    MTMD_VALOR_ENTRADA,                    MTMD_QTDE_SAIDA,
             MTMD_VALOR_SAIDA,                     MTMD_CUSTO_MEDIO_ATUAL,                MTMD_SALDO_ATUAL,
             MTMD_VALOR_ATUAL,                     CAD_MTMD_GRUPO_ID,                     CAD_MTMD_SUBGRUPO_ID,
             MTMD_QTDE_ACERTO,                     SEG_USU_ID_USUARIO,                    SEG_DT_ATUALIZACAO,
             CAD_MTMD_TPMOV_ID,                    CAD_MTMD_SUBTP_ID )
            VALUES
            (TO_DATE('31122010','DDMMYYYY'),       CONT.CAD_MTMD_ID,                     CONT.CAD_MTMD_FILIAL_ID,
             33,                                   244,                                  29,
             0,                                    0,                                    0,
             0,                                    0,                                    0,
             0,                                    NVL(CONT.MTMD_CUSTO_MEDIO_INICIAL,0), NVL(CONT.MTMD_SALDO_INICIAL,0),
             vMTMD_VALOR_ENTRADA,                  NVL(CONT.CAD_MTMD_GRUPO_ID,0),        NVL(CONT.CAD_MTMD_SUBGRUPO_ID,0),
             0,                                    1,                                    SYSDATE,
             0,                                    0);
             COMMIT;
       END;
       -- JA INSERE MES 01
      BEGIN
            INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
            (MTMD_MOV_DATA,                    CAD_MTMD_ID,                           CAD_MTMD_FILIAL_ID,
             CAD_LAT_ID_LOCAL_ATENDIMENTO,     CAD_UNI_ID_UNIDADE,                    CAD_SET_ID,
             MTMD_CUSTO_MEDIO_ANTERIOR,        MTMD_SALDO_ANTERIOR,                   MTMD_VALOR_ANTERIOR,
             MTMD_QTDE_ENTRADA,                MTMD_VALOR_ENTRADA,                    MTMD_QTDE_SAIDA,
             MTMD_VALOR_SAIDA,                 MTMD_CUSTO_MEDIO_ATUAL,                MTMD_SALDO_ATUAL,
             MTMD_VALOR_ATUAL,                 CAD_MTMD_GRUPO_ID,                     CAD_MTMD_SUBGRUPO_ID,
             MTMD_QTDE_ACERTO,                 SEG_USU_ID_USUARIO,                    SEG_DT_ATUALIZACAO,
             CAD_MTMD_TPMOV_ID,                CAD_MTMD_SUBTP_ID )
            VALUES
            (TO_DATE('01012011','DDMMYYYY'),   CONT.CAD_MTMD_ID,                     CONT.CAD_MTMD_FILIAL_ID,
             33,                               244,                                  29,
             NVL(CONT.MTMD_CUSTO_MEDIO_INICIAL,0),    CONT.MTMD_SALDO_INICIAL,              vMTMD_VALOR_ENTRADA,
             0,                                0,                                    0,
             0,                                NVL(CONT.MTMD_CUSTO_MEDIO_INICIAL,0), NVL(CONT.MTMD_SALDO_INICIAL,0),
             vMTMD_VALOR_ENTRADA,              NVL(CONT.CAD_MTMD_GRUPO_ID,0),        NVL(CONT.CAD_MTMD_SUBGRUPO_ID,0),
             0,                                1,                                    SYSDATE,
             0,                                0);
             COMMIT;
       END;
    END IF; -- GRUPO
END LOOP;
COMMIT;
END IF; -- passo
--==================================================================================================
-- FIM PARTE 1
--==================================================================================================
--==================================================================================================
-- INICIO PARTE 2
--==================================================================================================
IF ( (nPasso = 2 OR nPasso = 5)  ) THEN
FOR AJUSTE IN
   ( SELECT
            TMOV.IDMOV,
            decode(TMOV.codfilial, 51, 2  , 1  ) CODHOS,
            DATASAIDA DATASAIDA  ,
            tprd.idprd,
            MTMD.CAD_MTMD_ID,
            titmmov.quantidade,
            (CASE
             WHEN (titmmov.quantidade*tund.fatorconversao) < 1 THEN 1
             ELSE (titmmov.quantidade*tund.fatorconversao)
             END) QTDE_REL,
             TITMMOV.VALORFINANCEIRO VALOR_REL,
             tund.fatorconversao,
             MTMD.CAD_MTMD_GRUPO_ID,
             MTMD.CAD_MTMD_SUBGRUPO_ID
      FROM  TMOV@RMDB TMOV,
            FCFOCOMPL@RMDB FCFOCOMPL,
            TITMMOV@RMDB TITMMOV,
            TPRD@RMDB TPRD,
            TUND@RMDB TUND,
            TTRBMOV@RMDB TTRBMOV,
            TTRBMOV@RMDB TTRBMOV_ICMS,
            TUND@RMDB TUNDVENDA,
            MTM_MAT_MED M,
            TB_CAD_MTMD_MAT_MED MTMD
 WHERE (       CODTMV = '1.2.41'
           OR  CODTMV = '1.2.45'  OR  CODTMV = '1.2.58' OR  CODTMV = '1.2.62'
           OR  CODTMV = '1.2.46'
           or  CODTMV = '1.2.47'
           OR  codtmv = '1.2.51'
           OR  codtmv = '1.2.56'  )
 and tmov.codcoligada = fcfocompl.codcoligada(+)
 and tmov.codcfo = fcfocompl.codcfo(+)
 and titmmov.codcoligada = tprd.codcoligada
 and titmmov.idprd = tprd.idprd
 and tmov.codcoligada = titmmov.codcoligada
 and tmov.idmov = titmmov.idmov
 and tund.codund = titmmov.codund
 and tundvenda.codund = tprd.codundvenda
   ---
 and ttrbmov.codcoligada(+)  = titmmov.codcoligada
 and ttrbmov.idmov(+)        = titmmov.idmov
 and ttrbmov.nseqitmmov(+)   = titmmov.nseqitmmov
 AND TTRBMOV.CODTRB(+)       = 'IPI'
 ---
 and ttrbmov_ICMS.codcoligada(+)  = titmmov.codcoligada
 and ttrbmov_ICMS.idmov(+)        = titmmov.idmov
 and ttrbmov_ICMS.nseqitmmov(+)   = titmmov.nseqitmmov
 AND TTRBMOV_ICMS.CODTRB(+)       = 'ICMS'
 ---
--   and TMOV.IDMOV       = ICMS.IDMOV(+)
--   and TMOV.CODCOLIGADA = ICMS.CODCOLIGADA(+)
 and TMOV.DATASAIDA >= TO_DATE('01012011 0000','DDMMYYYY  HH24MI')  AND TMOV.DATASAIDA <= TO_DATE('31012011 2359','DDMMYYYY HH24MI')
 and M.CODALFMAT(+)  = SUBSTR(TPRD.CODIGOPRD,1,7)
 AND TPRD.CODCOLIGADA = 1
 AND MTMD.CAD_MTMD_CD_RM(+) = tprd.idprd
-- AND TMOV.codfilial != 51
-- AND MTMD.CAD_MTMD_ID = 4615
 order by  3, 9, 6 )
 LOOP
      IF (AJUSTE.IDMOV = 4606935) THEN
         AJUSTE.VALOR_REL := AJUSTE.VALOR_REL + 30;
      ELSIF (AJUSTE.IDMOV = 4607225) THEN
         AJUSTE.VALOR_REL := AJUSTE.VALOR_REL + 30;
      ELSIF (AJUSTE.IDMOV = 4609250) THEN
         AJUSTE.VALOR_REL := AJUSTE.VALOR_REL + 28.2;
      ELSIF (AJUSTE.IDMOV = 4609671 and AJUSTE.IDPRD = 5577) THEN
         AJUSTE.VALOR_REL := AJUSTE.VALOR_REL + 6.7;
      END IF;
      -- BUSCA GRUPO DO CADASTRO
      \*
      BEGIN
         SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID
         INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID
         FROM SGS.TB_MTMD_ESTOQUE_CONTABIL_FECHA MTMD
         WHERE MTMD.CAD_MTMD_ID        = AJUSTE.CAD_MTMD_ID
         AND   MTMD.CAD_MTMD_FILIAL_ID = AJUSTE.CODHOS;
      EXCEPTION WHEN NO_DATA_FOUND THEN
         BEGIN
            SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID
            INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID
            FROM SGS.TB_MTMD_ESTOQUE_CONTABIL MTMD
            WHERE MTMD.CAD_MTMD_ID        = AJUSTE.CAD_MTMD_ID
            AND   MTMD.CAD_MTMD_FILIAL_ID = AJUSTE.CODHOS;
         EXCEPTION WHEN NO_DATA_FOUND THEN
           vCAD_MTMD_GRUPO_ID := 0;
           vCAD_MTMD_SUBGRUPO_ID := 0;
         END;
      END;
      *\
         BEGIN
            SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID
            INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID
            FROM TB_CAD_MTMD_MAT_MED MTMD
            WHERE MTMD.CAD_MTMD_ID = AJUSTE.CAD_MTMD_ID;
--            CONT.CAD_MTMD_GRUPO_ID    := vCAD_MTMD_GRUPO_ID;
--            CONT.CAD_MTMD_SUBGRUPO_ID := vCAD_MTMD_SUBGRUPO_ID;
         END;
    vMTMD_VALOR_ENTRADA := NVL(AJUSTE.VALOR_REL,0); -- *NVL( AJUSTE.QTDE_REL,0);
    vMTMD_QTDE_ENTRADA  := NVL(AJUSTE.QTDE_REL,0);
    vMTMD_CUSTO_MEDIO   := (NVL(AJUSTE.VALOR_REL,0)/NVL(AJUSTE.QTDE_REL,0));
    BEGIN
      INSERT INTO SGS.TB_MTMD_MOV_ESTOQUE_DIA_X
      (MTMD_MOV_DATA,                   CAD_MTMD_ID,                    CAD_MTMD_FILIAL_ID,
       CAD_UNI_ID_UNIDADE,              CAD_SET_ID,                     CAD_LAT_ID_LOCAL_ATENDIMENTO,
       MTMD_SALDO_ANTERIOR,             MTMD_VALOR_ANTERIOR,            MTMD_CUSTO_MEDIO_ANTERIOR,
       MTMD_QTDE_ENTRADA,               MTMD_VALOR_ENTRADA,
       MTMD_QTDE_SAIDA,                 MTMD_VALOR_SAIDA,
       MTMD_SALDO_ATUAL,                MTMD_VALOR_ATUAL,               MTMD_CUSTO_MEDIO_ATUAL,
       CAD_MTMD_GRUPO_ID,               CAD_MTMD_SUBGRUPO_ID,
       MTMD_QTDE_ACERTO,                SEG_USU_ID_USUARIO,
       SEG_DT_ATUALIZACAO,              CAD_MTMD_TPMOV_ID,              CAD_MTMD_SUBTP_ID )
      VALUES
      (AJUSTE.DATASAIDA,               AJUSTE.CAD_MTMD_ID,              AJUSTE.CODHOS,
       244,                            29,                              33,
       0,                              0,                               0,
       vMTMD_QTDE_ENTRADA,             vMTMD_VALOR_ENTRADA,
       0,                              0,
       0,                              0,                               (vMTMD_CUSTO_MEDIO),
       vCAD_MTMD_GRUPO_ID,             vCAD_MTMD_SUBGRUPO_ID,
       0,                              1,
       SYSDATE,                        1,                               1);
       --
       COMMIT;
   EXCEPTION
      WHEN DUP_VAL_ON_INDEX THEN
         UPDATE SGS.TB_MTMD_MOV_ESTOQUE_DIA_X SET
         MTMD_QTDE_ENTRADA        =  NVL(MTMD_QTDE_ENTRADA,0)  + vMTMD_QTDE_ENTRADA,
         MTMD_VALOR_ENTRADA       =  NVL(MTMD_VALOR_ENTRADA,0) + NVL(vMTMD_VALOR_ENTRADA,0),
         MTMD_CUSTO_MEDIO_ATUAL   =  vMTMD_CUSTO_MEDIO,
         SEG_DT_ATUALIZACAO       =  SYSDATE
         WHERE MTMD_MOV_DATA                = TO_DATE('01012011','DDMMYYYY')
         AND   CAD_MTMD_ID                  = AJUSTE.CAD_MTMD_ID
         AND   CAD_MTMD_FILIAL_ID           = AJUSTE.CODHOS
         AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
         AND   CAD_UNI_ID_UNIDADE           = 244
         AND   CAD_SET_ID                   = 29
         AND   CAD_MTMD_TPMOV_ID            = 1
         AND   CAD_MTMD_SUBTP_ID            = 1;
         COMMIT;
      WHEN OTHERS THEN
       RAISE_APPLICATION_ERROR(-20000,' ERRO INSERINDO '||SQLERRM);
   END;
   COMMIT;
   \*
   -- ATUALIZA SALDO
   -- PRODUTO NUNCA TEVE MOVIMENTACAO
--   vMTMD_VALOR_ATUAL := (vMTMD_QTDE_ENTRADA - vMTMD_QTDE_SAIDA) * NVL(AJUSTE.MTMD_CUSTO_MEDIO,0);
   BEGIN
      INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
      (MTMD_MOV_DATA,                    CAD_MTMD_ID,                           CAD_MTMD_FILIAL_ID,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,     CAD_UNI_ID_UNIDADE,                    CAD_SET_ID,
       MTMD_CUSTO_MEDIO_ANTERIOR,        MTMD_SALDO_ANTERIOR,                   MTMD_VALOR_ANTERIOR,
       MTMD_QTDE_ENTRADA,                MTMD_VALOR_ENTRADA,                    MTMD_QTDE_SAIDA,
       MTMD_VALOR_SAIDA,                 MTMD_CUSTO_MEDIO_ATUAL,                MTMD_SALDO_ATUAL,
       MTMD_VALOR_ATUAL,                 CAD_MTMD_GRUPO_ID,                     CAD_MTMD_SUBGRUPO_ID,
       MTMD_QTDE_ACERTO,                 SEG_USU_ID_USUARIO,                    SEG_DT_ATUALIZACAO,
       CAD_MTMD_TPMOV_ID,                CAD_MTMD_SUBTP_ID )
      VALUES
      (TO_DATE('01012011','DDMMYYYY'),   AJUSTE.CAD_MTMD_ID,                    AJUSTE.CODHOS,
       33,                               244,                                   29,
       0,                                0,                                     0,
       0,                                0,                                     0,
       0,                                0,                                     (vMTMD_QTDE_ENTRADA),
       vMTMD_VALOR_ENTRADA,              vCAD_MTMD_GRUPO_ID,                    vCAD_MTMD_SUBGRUPO_ID,
       0,                                1,                                     SYSDATE,
       0,                                0);
   EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
      BEGIN
         UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
         MTMD_CUSTO_MEDIO_ATUAL   =  vMTMD_CUSTO_MEDIO,
         MTMD_SALDO_ATUAL         =  ( NVL(MTMD_SALDO_ATUAL,2) + vMTMD_QTDE_ENTRADA) ,
         MTMD_VALOR_ATUAL         =  NVL(MTMD_VALOR_ATUAL,2) + vMTMD_VALOR_ENTRADA,
         SEG_DT_ATUALIZACAO       =  SYSDATE
         WHERE MTMD_MOV_DATA                = TO_DATE('01012011','DDMMYYYY')
         AND   CAD_MTMD_ID                  = AJUSTE.CAD_MTMD_ID
         AND   CAD_MTMD_FILIAL_ID           = AJUSTE.CODHOS
         AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
         AND   CAD_UNI_ID_UNIDADE           = 244
         AND   CAD_SET_ID                   = 29
         AND   CAD_MTMD_TPMOV_ID            = 0
         AND   CAD_MTMD_SUBTP_ID            = 0;
      EXCEPTION
         WHEN ZERO_DIVIDE THEN
            UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
            MTMD_CUSTO_MEDIO_ATUAL   =  0,
            MTMD_SALDO_ATUAL         =  ( NVL(MTMD_SALDO_ATUAL,2) + vMTMD_QTDE_ENTRADA),
            MTMD_VALOR_ATUAL         =  NVL(MTMD_VALOR_ATUAL,2) + vMTMD_VALOR_ENTRADA,
            SEG_DT_ATUALIZACAO       =  SYSDATE
            WHERE MTMD_MOV_DATA                = TO_DATE('01012011','DDMMYYYY')
            AND   CAD_MTMD_ID                  = AJUSTE.CAD_MTMD_ID
            AND   CAD_MTMD_FILIAL_ID           = AJUSTE.CODHOS
            AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
            AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
            AND   CAD_UNI_ID_UNIDADE           = 244
            AND   CAD_SET_ID                   = 29
            AND   CAD_MTMD_TPMOV_ID            = 0
            AND   CAD_MTMD_SUBTP_ID            = 0;
      WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,' DATA  '||'01/01/2011'||
                                           ' PRODUTO '||TO_CHAR(AJUSTE.CAD_MTMD_ID)||
                                           ' FILIAL '||TO_CHAR(AJUSTE.CODHOS)||
                                            ' VLR ATU '||TO_CHAR(vMTMD_VALOR_ENTRADA)||
                                            ' ENTRADA '||TO_CHAR(vMTMD_QTDE_ENTRADA)||
                                            ' SAIDA '||TO_CHAR(0));
      END;
   END;
   -- ===========================================================================================
   IF ( vCAD_MTMD_GRUPO_ID = 4 ) THEN
     -- BAIXA DIRETO
            vMTMD_QTDE_SAIDA    := vMTMD_QTDE_ENTRADA;
            vMTMD_VALOR_SAIDA   := vMTMD_VALOR_ENTRADA;
            vMTMD_VALOR_ENTRADA := 0;
            vMTMD_QTDE_ENTRADA  := 0;
            BEGIN
               INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
               (MTMD_MOV_DATA,                   CAD_MTMD_ID,                    CAD_MTMD_FILIAL_ID,
                CAD_UNI_ID_UNIDADE,              CAD_SET_ID,                     CAD_LAT_ID_LOCAL_ATENDIMENTO,
                MTMD_SALDO_ANTERIOR,             MTMD_VALOR_ANTERIOR,            MTMD_CUSTO_MEDIO_ANTERIOR,
                MTMD_QTDE_ENTRADA,               MTMD_VALOR_ENTRADA,
                MTMD_QTDE_SAIDA,                 MTMD_VALOR_SAIDA,
                MTMD_SALDO_ATUAL,                MTMD_VALOR_ATUAL,               MTMD_CUSTO_MEDIO_ATUAL,
                CAD_MTMD_GRUPO_ID,               CAD_MTMD_SUBGRUPO_ID,
                MTMD_QTDE_ACERTO,                SEG_USU_ID_USUARIO,
                SEG_DT_ATUALIZACAO,              CAD_MTMD_TPMOV_ID,              CAD_MTMD_SUBTP_ID )
               VALUES
               (TO_DATE('01012011','DDMMYYYY'), AJUSTE.CAD_MTMD_ID,              AJUSTE.CODHOS,
                244,                            183,                             33,
                0,                              0,                               0,
                vMTMD_QTDE_ENTRADA,             vMTMD_VALOR_ENTRADA,
                vMTMD_QTDE_SAIDA,               vMTMD_VALOR_SAIDA,
                0,                              0,                               vMTMD_CUSTO_MEDIO,
                vCAD_MTMD_GRUPO_ID,             vCAD_MTMD_SUBGRUPO_ID,
                0,                              1,
                SYSDATE,                        2,                               18);
                --
   --             COMMIT;
            EXCEPTION
               WHEN DUP_VAL_ON_INDEX THEN
                  UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                  MTMD_QTDE_SAIDA          =  NVL(MTMD_QTDE_SAIDA,0)    + vMTMD_QTDE_SAIDA,
                  MTMD_VALOR_SAIDA         =  NVL(MTMD_VALOR_SAIDA,0)   + vMTMD_VALOR_SAIDA,
                  MTMD_CUSTO_MEDIO_ATUAL   =  vMTMD_CUSTO_MEDIO,
                  SEG_DT_ATUALIZACAO       =  SYSDATE
                  WHERE MTMD_MOV_DATA                = TO_DATE('01012011','DDMMYYYY')
                  AND   CAD_MTMD_ID                  = AJUSTE.CAD_MTMD_ID
                  AND   CAD_MTMD_FILIAL_ID           = AJUSTE.CODHOS
                  AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
                  AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                  AND   CAD_UNI_ID_UNIDADE           = 244
                  AND   CAD_SET_ID                   = 183
                  AND   CAD_MTMD_TPMOV_ID            = 2
                  AND   CAD_MTMD_SUBTP_ID            = 18;
                  COMMIT;
               WHEN OTHERS THEN
                RAISE_APPLICATION_ERROR(-20000,' ERRO INSERINDO '||SQLERRM);
            END;
   --         COMMIT;
            -- ATUALIZA SALDO
            -- PRODUTO NUNCA TEVE MOVIMENTACAO
               BEGIN
                  UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                  MTMD_CUSTO_MEDIO_ATUAL   =  vMTMD_CUSTO_MEDIO,
                  MTMD_SALDO_ATUAL         =  NVL(MTMD_SALDO_ATUAL,0) - vMTMD_QTDE_SAIDA,
                  MTMD_VALOR_ATUAL         =  NVL(MTMD_VALOR_ATUAL,0) - vMTMD_VALOR_SAIDA,
                  SEG_DT_ATUALIZACAO       =  SYSDATE
                  WHERE MTMD_MOV_DATA                = TO_DATE('01012011','DDMMYYYY')
                  AND   CAD_MTMD_ID                  = AJUSTE.CAD_MTMD_ID
                  AND   CAD_MTMD_FILIAL_ID           = AJUSTE.CODHOS
                  AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
                  AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                  AND   CAD_UNI_ID_UNIDADE           = 244
                  AND   CAD_SET_ID                   = 29
                  AND   CAD_MTMD_TPMOV_ID            = 0
                  AND   CAD_MTMD_SUBTP_ID            = 0;
               EXCEPTION
                  WHEN ZERO_DIVIDE THEN
                     UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                     MTMD_CUSTO_MEDIO_ATUAL   =  0,
      --               MTMD_CUSTO_MEDIO_ATUAL   =  NVL(MES.MTMD_CUSTO_MEDIO,0),
                     MTMD_SALDO_ATUAL         =  ( NVL(MTMD_SALDO_ATUAL,0) + vMTMD_QTDE_ENTRADA) - vMTMD_QTDE_SAIDA,
                     MTMD_VALOR_ATUAL         =  NVL(MTMD_VALOR_ATUAL,0) + vMTMD_VALOR_ATUAL,
                     SEG_DT_ATUALIZACAO       =  SYSDATE
                     WHERE MTMD_MOV_DATA                = TO_DATE('01012011','DDMMYYYY')
                     AND   CAD_MTMD_ID                  = AJUSTE.CAD_MTMD_ID
                     AND   CAD_MTMD_FILIAL_ID           = AJUSTE.CODHOS
                     AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0;
                  WHEN OTHERS THEN
                     RAISE_APPLICATION_ERROR(-20000,' DATA  '||TO_CHAR(d1)||
                                                    ' PRODUTO '||TO_CHAR(AJUSTE.CAD_MTMD_ID)||
                                                    ' FILIAL '||TO_CHAR(AJUSTE.CODHOS)||
                                                     ' VLR ATU '||TO_CHAR(vMTMD_VALOR_ATUAL)||
                                                     ' ENTRADA '||TO_CHAR(vMTMD_QTDE_ENTRADA)||
                                                     ' SAIDA '||TO_CHAR(vMTMD_QTDE_SAIDA));
               END;
   END IF; -- GRUPO
   *\
 END LOOP;
 COMMIT;
END IF;
--==================================================================================================
-- FIM PARTE 2
--==================================================================================================
--==================================================================================================
-- INICIO PARTE 3
--==================================================================================================
IF ( nPasso IN (3) OR nPasso = 6  ) THEN
FOR CONT IN ( SELECT * FROM sgs.TB_MTMD_ESTOQUE_CONTABIL_FECHA
              WHERE CAD_MTMD_ID IN (14965, 800, 5198, 39473)
            )
LOOP
   IF ( NVL(CONT.CAD_MTMD_GRUPO_ID,0) = 0 ) THEN
      -- BUSCA GRUPO DO CADASTRO
      BEGIN
         SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID
         INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID
         FROM TB_CAD_MTMD_MAT_MED MTMD
         WHERE MTMD.CAD_MTMD_ID = CONT.CAD_MTMD_ID;
         CONT.CAD_MTMD_GRUPO_ID    := vCAD_MTMD_GRUPO_ID;
         CONT.CAD_MTMD_SUBGRUPO_ID := vCAD_MTMD_SUBGRUPO_ID;
      END;
   END IF;
   IF ( CONT.CAD_MTMD_GRUPO_ID != 4 ) THEN
      d1 := TO_DATE('01012011 0000','DDMMYYYY HH24MI');
      d2 := TO_DATE('01012011 2359','DDMMYYYY HH24MI');
      LOOP
         FOR MES IN (
            SELECT MOV.*
            FROM SGS.TB_MTMD_MOV_MOVIMENTACAO       MOV,
                 SGS.TB_CAD_MTMD_MAT_MED            MAT,
                 SGS.TB_CAD_MTMD_SUBTP_MOVIMENTACAO TIP
         --    WHERE MOV.MTMD_MOV_DATA > CONT.MTMD_DT_SALDO_INICIAL
            WHERE MOV.MTMD_MOV_DATA >= d1
            AND   MOV.MTMD_MOV_DATA <= d2
            AND   MOV.CAD_MTMD_ID         = CONT.CAD_MTMD_ID
            AND   MOV.CAD_MTMD_FILIAL_ID  = CONT.CAD_MTMD_FILIAL_ID
            AND   MAT.CAD_MTMD_ID         = MOV.CAD_MTMD_ID
            AND   MOV.MTMD_MOV_FL_ESTORNO = 0
            AND   TIP.CAD_MTMD_TPMOV_ID   = MOV.CAD_MTMD_TPMOV_ID
            AND   TIP.CAD_MTMD_SUBTP_ID   = MOV.CAD_MTMD_SUBTP_ID
            AND   TIP.CAD_MTMD_FL_CONSUMO = 1
            ORDER BY MOV.MTMD_MOV_DATA,       MOV.CAD_MTMD_ID,       MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                     MOV.CAD_UNI_ID_UNIDADE,  MOV.CAD_SET_ID,        MOV.CAD_MTMD_FILIAL_ID,
                     MOV.CAD_MTMD_TPMOV_ID,   MOV.CAD_MTMD_SUBTP_ID, MOV.CAD_MTMD_GRUPO_ID,
                     MOV.CAD_MTMD_SUBGRUPO_ID
         ) LOOP
            IF ( MES.CAD_MTMD_SUBTP_ID NOT IN (43,44)   ) THEN
               -- NVL(CONT.MTMD_CUSTO_MEDIO_INICIAL,0)
               vMTMD_MOV_ESTOQUE_ANTERIOR := 0;
               vMTMD_VALOR_TOTAL_ANTERIOR := 0;
               vMTMD_CUSTO_MEDIO_ANTERIOR := 0;
               vMTMD_QTDE_ENTRADA         := 0;
               vMTMD_QTDE_SAIDA           := 0;
               vMTMD_VALOR_ENTRADA        := 0;
--               vMTMD_VALOR_MOVIMENTO      := (TRUNC(NVL(CONT.MTMD_CUSTO_MEDIO_INICIAL,0),2) * NVL(MES.MTMD_MOV_QTDE,2)); -- VALOR TOTAL MOVIMENTADO
               vMTMD_VALOR_MOVIMENTO      := (TRUNC(NVL(MES.MTMD_CUSTO_MEDIO,0),2) * NVL(MES.MTMD_MOV_QTDE,2)); -- VALOR TOTAL MOVIMENTADO
               vMTMD_VALOR_SAIDA          := 0;
               -- TOTALIZA
               IF ( MES.CAD_MTMD_TPMOV_ID = 1  ) THEN
                  vMTMD_VALOR_ENTRADA := NVL(vMTMD_VALOR_MOVIMENTO,0);
                  vMTMD_QTDE_ENTRADA  := NVL(MES.MTMD_MOV_QTDE,0);
               ELSE
                  vMTMD_QTDE_SAIDA    := NVL(MES.MTMD_MOV_QTDE,0);
                  vMTMD_VALOR_SAIDA   := NVL(vMTMD_VALOR_MOVIMENTO,0);
               END IF;
               -- NOTAS ENTRADA E ESTORNO NOTAS
               IF ( MES.CAD_MTMD_TPMOV_ID = 1 AND MES.CAD_MTMD_SUBTP_ID = 1  ) THEN
                  --  MOVIMENTO DE ENTRADA EXCLUIDO
                  NULL;
               ELSIF ( MES.CAD_MTMD_TPMOV_ID = 2 AND MES.CAD_MTMD_SUBTP_ID = 15 ) THEN
                  NULL;
               ELSE
                  -- INSERE INFORMAC?O
                  BEGIN
                     INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
                     (MTMD_MOV_DATA,                   CAD_MTMD_ID,                    CAD_MTMD_FILIAL_ID,
                      CAD_UNI_ID_UNIDADE,              CAD_SET_ID,                     CAD_LAT_ID_LOCAL_ATENDIMENTO,
                      MTMD_SALDO_ANTERIOR,             MTMD_VALOR_ANTERIOR,            MTMD_CUSTO_MEDIO_ANTERIOR,
                      MTMD_QTDE_ENTRADA,               MTMD_VALOR_ENTRADA,
                      MTMD_QTDE_SAIDA,                 MTMD_VALOR_SAIDA,
                      MTMD_SALDO_ATUAL,                MTMD_VALOR_ATUAL,               MTMD_CUSTO_MEDIO_ATUAL,
                      CAD_MTMD_GRUPO_ID,               CAD_MTMD_SUBGRUPO_ID,
                      MTMD_QTDE_ACERTO,                SEG_USU_ID_USUARIO,
                      SEG_DT_ATUALIZACAO,              CAD_MTMD_TPMOV_ID,              CAD_MTMD_SUBTP_ID )
                     VALUES
                     (TRUNC(MES.MTMD_MOV_DATA),       MES.CAD_MTMD_ID,                 MES.CAD_MTMD_FILIAL_ID,
                      MES.CAD_UNI_ID_UNIDADE,         MES.CAD_SET_ID,                  MES.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                      0,                              0,                               0,
                      vMTMD_QTDE_ENTRADA,             vMTMD_VALOR_ENTRADA,
                      vMTMD_QTDE_SAIDA,               vMTMD_VALOR_SAIDA,
                      0,                              0,                               NVL(MES.MTMD_CUSTO_MEDIO,0),
                      CONT.CAD_MTMD_GRUPO_ID,          CONT.CAD_MTMD_SUBGRUPO_ID,
                      0,                              1,
                      SYSDATE,                        MES.CAD_MTMD_TPMOV_ID,           MES.CAD_MTMD_SUBTP_ID);
                      --
         --             COMMIT;
                  EXCEPTION
                     WHEN DUP_VAL_ON_INDEX THEN
                        UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                        MTMD_QTDE_ENTRADA        =  NVL(MTMD_QTDE_ENTRADA,0)  + vMTMD_QTDE_ENTRADA,
                        MTMD_VALOR_ENTRADA       =  NVL(MTMD_VALOR_ENTRADA,0) + NVL(vMTMD_VALOR_ENTRADA,0),
                        MTMD_QTDE_SAIDA          =  NVL(MTMD_QTDE_SAIDA,0)    + vMTMD_QTDE_SAIDA,
                        MTMD_VALOR_SAIDA         =  NVL(MTMD_VALOR_SAIDA,0)   + vMTMD_VALOR_SAIDA,
                        MTMD_CUSTO_MEDIO_ATUAL   =  NVL(MES.MTMD_CUSTO_MEDIO,0),
                        SEG_DT_ATUALIZACAO       =  SYSDATE
                        WHERE MTMD_MOV_DATA                = TRUNC(MES.MTMD_MOV_DATA)
                        AND   CAD_MTMD_ID                  = MES.CAD_MTMD_ID
                        AND   CAD_MTMD_FILIAL_ID           = MES.CAD_MTMD_FILIAL_ID
                        AND   CAD_MTMD_GRUPO_ID            = CONT.CAD_MTMD_GRUPO_ID
                        AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = MES.CAD_LAT_ID_LOCAL_ATENDIMENTO
                        AND   CAD_UNI_ID_UNIDADE           = MES.CAD_UNI_ID_UNIDADE
                        AND   CAD_SET_ID                   = MES.CAD_SET_ID
                        AND   CAD_MTMD_TPMOV_ID            = MES.CAD_MTMD_TPMOV_ID
                        AND   CAD_MTMD_SUBTP_ID            = MES.CAD_MTMD_SUBTP_ID;
                        COMMIT;
                     WHEN OTHERS THEN
                      RAISE_APPLICATION_ERROR(-20000,' ERRO INSERINDO '||SQLERRM);
                  END;
                  -- ATUALIZA SALDO
                  vMTMD_VALOR_ATUAL := (vMTMD_QTDE_ENTRADA - vMTMD_QTDE_SAIDA) * NVL(MES.MTMD_CUSTO_MEDIO,0);
                  BEGIN
                     INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
                     (MTMD_MOV_DATA,                    CAD_MTMD_ID,                           CAD_MTMD_FILIAL_ID,
                      CAD_LAT_ID_LOCAL_ATENDIMENTO,     CAD_UNI_ID_UNIDADE,                    CAD_SET_ID,
                      MTMD_CUSTO_MEDIO_ANTERIOR,        MTMD_SALDO_ANTERIOR,                   MTMD_VALOR_ANTERIOR,
                      MTMD_QTDE_ENTRADA,                MTMD_VALOR_ENTRADA,                    MTMD_QTDE_SAIDA,
                      MTMD_VALOR_SAIDA,                 MTMD_CUSTO_MEDIO_ATUAL,                MTMD_SALDO_ATUAL,
                      MTMD_VALOR_ATUAL,                 CAD_MTMD_GRUPO_ID,                     CAD_MTMD_SUBGRUPO_ID,
                      MTMD_QTDE_ACERTO,                 SEG_USU_ID_USUARIO,                    SEG_DT_ATUALIZACAO,
                      CAD_MTMD_TPMOV_ID,                CAD_MTMD_SUBTP_ID )
                     VALUES
                     (TO_DATE('01012011','DDMMYYYY'),   MES.CAD_MTMD_ID,                       MES.CAD_MTMD_FILIAL_ID,
                      33,                               244,                                   29,
                      0,                                0,                                     0,
                      0,                                0,                                     0,
                      0,                                NVL(MES.MTMD_CUSTO_MEDIO,0),          (vMTMD_QTDE_ENTRADA-vMTMD_QTDE_SAIDA),
                      vMTMD_VALOR_ATUAL,                NVL(CONT.CAD_MTMD_GRUPO_ID,0),         NVL(CONT.CAD_MTMD_SUBGRUPO_ID,0),
                      0,                                1,                                     SYSDATE,
                      0,                                0);
                  EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
                     BEGIN
                        UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                        MTMD_CUSTO_MEDIO_ATUAL   =  ( NVL(MTMD_VALOR_ATUAL,0) + vMTMD_VALOR_ATUAL  ) / ( ( NVL(MTMD_SALDO_ATUAL,0) + vMTMD_QTDE_ENTRADA) - vMTMD_QTDE_SAIDA ),
                        MTMD_SALDO_ATUAL         =  ( NVL(MTMD_SALDO_ATUAL,0) + vMTMD_QTDE_ENTRADA) - vMTMD_QTDE_SAIDA,
                        MTMD_VALOR_ATUAL         =  NVL(MTMD_VALOR_ATUAL,0) + vMTMD_VALOR_ATUAL,
                        SEG_DT_ATUALIZACAO       =  SYSDATE
                        WHERE MTMD_MOV_DATA                = TO_DATE('01012011','DDMMYYYY')
                        AND   CAD_MTMD_ID                  = MES.CAD_MTMD_ID
                        AND   CAD_MTMD_FILIAL_ID           = MES.CAD_MTMD_FILIAL_ID
                        AND   CAD_MTMD_GRUPO_ID            = CONT.CAD_MTMD_GRUPO_ID
                        AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                        AND   CAD_UNI_ID_UNIDADE           = 244
                        AND   CAD_SET_ID                   = 29
                        AND   CAD_MTMD_TPMOV_ID            = 0
                        AND   CAD_MTMD_SUBTP_ID            = 0;
                     EXCEPTION
                        WHEN ZERO_DIVIDE THEN
                           UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                           MTMD_CUSTO_MEDIO_ATUAL   =  0,
                           MTMD_SALDO_ATUAL         =  ( NVL(MTMD_SALDO_ATUAL,0) + vMTMD_QTDE_ENTRADA) - vMTMD_QTDE_SAIDA,
                           MTMD_VALOR_ATUAL         =  NVL(MTMD_VALOR_ATUAL,0) + vMTMD_VALOR_ATUAL,
                           SEG_DT_ATUALIZACAO       =  SYSDATE
                           WHERE MTMD_MOV_DATA                = TO_DATE('01012011','DDMMYYYY')
                           AND   CAD_MTMD_ID                  = MES.CAD_MTMD_ID
                           AND   CAD_MTMD_FILIAL_ID           = MES.CAD_MTMD_FILIAL_ID
                           AND   CAD_MTMD_GRUPO_ID            = CONT.CAD_MTMD_GRUPO_ID
                           AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                           AND   CAD_UNI_ID_UNIDADE           = 244
                           AND   CAD_SET_ID                   = 29
                           AND   CAD_MTMD_TPMOV_ID            = 0
                           AND   CAD_MTMD_SUBTP_ID            = 0;
                        WHEN OTHERS THEN
                           RAISE_APPLICATION_ERROR(-20000,' DATA  '||TO_CHAR(d1)||
                                                          ' PRODUTO '||TO_CHAR(MES.CAD_MTMD_ID)||
                                                          ' FILIAL '||TO_CHAR(MES.CAD_MTMD_FILIAL_ID)||
                                                           ' VLR ATU '||TO_CHAR(vMTMD_VALOR_ATUAL)||
                                                           ' ENTRADA '||TO_CHAR(vMTMD_QTDE_ENTRADA)||
                                                           ' SAIDA '||TO_CHAR(vMTMD_QTDE_SAIDA));
                     END; -- BEGIN UPDATE MOVIMENTO
                  END;  -- BEGIN INSERT MOVIMENTO
                  -- MARCA REGISTRO COMO LIDO
                  UPDATE SGS.TB_MTMD_MOV_MOVIMENTACAO SET
                  MTMD_ID_USUARIO_ESTORNO = 55
                  WHERE MTMD_MOV_ID = MES.MTMD_MOV_ID;
                  COMMIT;
               END IF; -- ENTRADA E EXCLUSAO DE NOTAS
            END IF; -- TIPO 43 44
         END LOOP;  -- LOOP MOVIMENTACAO
         d1 := d1 + 1;
         d2 := d2 + 1;
         IF ( d2 >= TO_DATE('01022011 0000','DDMMYYYY HH24MI')  ) THEN
            EXIT;
         END IF;
      END LOOP; -- CONTADOR
   END IF; -- GRUPO 4
END LOOP; -- TABELA CONTABIL
COMMIT;
END IF;   */
--==================================================================================================
-- FIM PARTE 3
--==================================================================================================
-- END LOOP;
end PRC_MTMD_MOV_ESTOQUE_MES_ENTRA;