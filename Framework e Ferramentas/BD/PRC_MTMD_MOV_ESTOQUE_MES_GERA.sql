CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_ESTOQUE_MES_GERA (
  nPasso                 IN NUMBER,
  pDataDe                IN DATE,
  pDataAte               IN DATE,
  pCAD_MTMD_ID IN        TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type default null,
  pCAD_MTMD_FILIAL_ID IN TB_MTMD_HISTORICO_NOTA_FISCAL.CAD_MTMD_FILIAL_ID%TYPE default null
) IS
vMTMD                        NUMBER;
vMTMD_SALDO_ATUAL            TB_MTMD_MOV_ESTOQUE_DIA.MTMD_SALDO_ATUAL%TYPE;
vMTMD_VALOR_ATUAL            TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_ATUAL%TYPE;
vCAD_MTMD_GRUPO_ID           TB_CAD_MTMD_MAT_MED.cad_mtmd_grupo_id%TYPE;
vCAD_MTMD_SUBGRUPO_ID        TB_CAD_MTMD_MAT_MED.cad_mtmd_SUBgrupo_id%TYPE;
vMTMD_CUSTO_MEDIO            TB_MTMD_MOV_ESTOQUE_DIA.MTMD_CUSTO_MEDIO_ATUAL%TYPE;
vMTMD_VALOR_UNITARIO         TB_MTMD_MOV_ESTOQUE_DIA.MTMD_CUSTO_MEDIO_ATUAL%TYPE;
vMTMD_VALOR_ENTRADA          NUMBER(15,2);
vMTMD_VALOR_SAIDA            NUMBER(15,2);
vMTMD_QTDE_ENTRADA           NUMBER;
vMTMD_QTDE_SAIDA             NUMBER;
vQTDE_JA_TIRADA              NUMBER;
vQTDE_TIRAR                  NUMBER;
d1       DATE;
d2       DATE;
vCAD_MTMD_FL_ATIVO TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_ATIVO%TYPE;
CAD_UNI_ID_UNIDADE_MOV       NUMBER := 244;
ID_LOCAL_ATENDIMENTO_MOV     NUMBER := 33;
CAD_SET_ID_MOV               NUMBER := 29;
-- ===========================================================================================================================
PROCEDURE INSEREMESATUAL
(
pMTMD_MOV_DATA                IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_MOV_DATA%TYPE,
pCAD_MTMD_ID_MA               IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_ID%TYPE,
pCAD_MTMD_FILIAL_ID_MA        IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_FILIAL_ID%TYPE,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_UNI_ID_UNIDADE%TYPE,
pCAD_SET_ID                   IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_SET_ID%TYPE,
pMTMD_CUSTO_MEDIO_ANTERIOR    IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_CUSTO_MEDIO_ANTERIOR%TYPE,
pMTMD_SALDO_ANTERIOR          IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_SALDO_ANTERIOR%TYPE,
pMTMD_VALOR_ANTERIOR          IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_ANTERIOR%TYPE,
pMTMD_QTDE_ENTRADA            IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_QTDE_ENTRADA%TYPE,
pMTMD_VALOR_ENTRADA           IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_ENTRADA%TYPE,
pMTMD_QTDE_SAIDA              IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_QTDE_SAIDA%TYPE,
pMTMD_VALOR_SAIDA             IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_SAIDA%TYPE,
pMTMD_CUSTO_MEDIO_ATUAL       IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_CUSTO_MEDIO_ATUAL%TYPE,
pMTMD_SALDO_ATUAL             IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_SALDO_ATUAL%TYPE,
pMTMD_VALOR_ATUAL             IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_ATUAL%TYPE,
pCAD_MTMD_GRUPO_ID            IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_GRUPO_ID%TYPE,
pCAD_MTMD_SUBGRUPO_ID         IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_SUBGRUPO_ID%TYPE
)
IS
BEGIN
   -- INSERE SALDO ANTERIOR
   /*BEGIN
   INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
   (
    MTMD_MOV_DATA,                        CAD_MTMD_ID,                           CAD_MTMD_FILIAL_ID,
    CAD_LAT_ID_LOCAL_ATENDIMENTO,         CAD_UNI_ID_UNIDADE,                    CAD_SET_ID,
    MTMD_CUSTO_MEDIO_ANTERIOR,            MTMD_SALDO_ANTERIOR,                   MTMD_VALOR_ANTERIOR,
    MTMD_QTDE_ENTRADA,                    MTMD_VALOR_ENTRADA,                    MTMD_QTDE_SAIDA,
    MTMD_VALOR_SAIDA,                     MTMD_CUSTO_MEDIO_ATUAL,                MTMD_SALDO_ATUAL,
    MTMD_VALOR_ATUAL,                     CAD_MTMD_GRUPO_ID,                     CAD_MTMD_SUBGRUPO_ID,
    MTMD_QTDE_ACERTO,                     SEG_USU_ID_USUARIO,                    SEG_DT_ATUALIZACAO,
    CAD_MTMD_TPMOV_ID,                    CAD_MTMD_SUBTP_ID
   )
   VALUES
   (
    pMTMD_MOV_DATA,                       pCAD_MTMD_ID_MA,                       pCAD_MTMD_FILIAL_ID_MA,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO,        pCAD_UNI_ID_UNIDADE,                   pCAD_SET_ID,
    pMTMD_CUSTO_MEDIO_ANTERIOR,           pMTMD_SALDO_ANTERIOR,                  pMTMD_VALOR_ANTERIOR,
    pMTMD_QTDE_ENTRADA,                   pMTMD_VALOR_ENTRADA,                   pMTMD_QTDE_SAIDA,
    pMTMD_VALOR_SAIDA,                    pMTMD_CUSTO_MEDIO_ATUAL,               pMTMD_SALDO_ATUAL,
    pMTMD_VALOR_ATUAL,                    pCAD_MTMD_GRUPO_ID,                    pCAD_MTMD_SUBGRUPO_ID,
    0, \*MTMD_QTDE_ACERTO*\               1,                                     SYSDATE,
    0,                                    0
   );
   EXCEPTION WHEN OTHERS THEN
     RAISE_APPLICATION_ERROR(-20000,' ERRO '||TO_CHAR(pMTMD_MOV_DATA,'DD/MM/YYYY HH24MI')||' PROD '||TO_CHAR(pCAD_MTMD_ID)||SQLERRM );
   END;*/
   -- INSERE SALDO ATUAL
   BEGIN
   INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
   (
    MTMD_MOV_DATA,                        CAD_MTMD_ID,                           CAD_MTMD_FILIAL_ID,
    CAD_LAT_ID_LOCAL_ATENDIMENTO,         CAD_UNI_ID_UNIDADE,                    CAD_SET_ID,
    MTMD_CUSTO_MEDIO_ANTERIOR,            MTMD_SALDO_ANTERIOR,                   MTMD_VALOR_ANTERIOR,
    MTMD_QTDE_ENTRADA,                    MTMD_VALOR_ENTRADA,                    MTMD_QTDE_SAIDA,
    MTMD_VALOR_SAIDA,                     MTMD_CUSTO_MEDIO_ATUAL,                MTMD_SALDO_ATUAL,
    MTMD_VALOR_ATUAL,                     CAD_MTMD_GRUPO_ID,                     CAD_MTMD_SUBGRUPO_ID,
    MTMD_QTDE_ACERTO,                     SEG_USU_ID_USUARIO,                    SEG_DT_ATUALIZACAO,
    CAD_MTMD_TPMOV_ID,                    CAD_MTMD_SUBTP_ID
   )
   VALUES
   (
    --pMTMD_MOV_DATA+1,                     pCAD_MTMD_ID_MA,                       pCAD_MTMD_FILIAL_ID_MA,
    pMTMD_MOV_DATA,                       pCAD_MTMD_ID_MA,                       pCAD_MTMD_FILIAL_ID_MA,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO,        pCAD_UNI_ID_UNIDADE,                   pCAD_SET_ID,
    pMTMD_CUSTO_MEDIO_ATUAL,              pMTMD_SALDO_ATUAL,                     pMTMD_VALOR_ATUAL,
    pMTMD_QTDE_ENTRADA,                   pMTMD_VALOR_ENTRADA,                   pMTMD_QTDE_SAIDA,
    pMTMD_VALOR_SAIDA,                    pMTMD_CUSTO_MEDIO_ATUAL,               pMTMD_SALDO_ATUAL,
    pMTMD_VALOR_ATUAL,                    pCAD_MTMD_GRUPO_ID,                    pCAD_MTMD_SUBGRUPO_ID,
    0, /*MTMD_QTDE_ACERTO*/               1,                                     SYSDATE,
    0,                                    0
   );
   EXCEPTION
   WHEN DUP_VAL_ON_INDEX THEN
     NULL;
   WHEN OTHERS THEN
     RAISE_APPLICATION_ERROR(-20000,' ERRO '||TO_CHAR(pMTMD_MOV_DATA,'DD/MM/YYYY HH24MI')||
                                    ' PROD '||TO_CHAR(pCAD_MTMD_ID_MA)||
                                    ' FILIAL '||TO_CHAR(pCAD_MTMD_FILIAL_ID_MA)||
                                    ' GRUPO '||TO_CHAR(pCAD_MTMD_GRUPO_ID)||
                                    ' SUBG '||TO_CHAR(pCAD_MTMD_SUBGRUPO_ID)||
                                     SQLERRM );
   END;
END INSEREMESATUAL;
-- ===========================================================================================================================
PROCEDURE INSEREMOVIMENTOENTRADA
(
pMTMD_MOV_DATA                IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_MOV_DATA%TYPE,
pCAD_MTMD_ID_ME               IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_ID%TYPE,
pCAD_MTMD_FILIAL_ID_ME        IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_FILIAL_ID%TYPE,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_UNI_ID_UNIDADE%TYPE,
pCAD_SET_ID                   IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_SET_ID%TYPE,
pMTMD_CUSTO_MEDIO_ANTERIOR    IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_CUSTO_MEDIO_ANTERIOR%TYPE,
pMTMD_SALDO_ANTERIOR          IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_SALDO_ANTERIOR%TYPE,
pMTMD_VALOR_ANTERIOR          IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_ANTERIOR%TYPE,
pMTMD_QTDE_ENTRADA            IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_QTDE_ENTRADA%TYPE,
pMTMD_VALOR_ENTRADA           IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_ENTRADA%TYPE,
pMTMD_QTDE_SAIDA              IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_QTDE_SAIDA%TYPE,
pMTMD_VALOR_SAIDA             IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_SAIDA%TYPE,
pMTMD_CUSTO_MEDIO_ATUAL       IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_CUSTO_MEDIO_ATUAL%TYPE,
pMTMD_SALDO_ATUAL             IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_SALDO_ATUAL%TYPE,
pMTMD_VALOR_ATUAL             IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_ATUAL%TYPE,
pCAD_MTMD_GRUPO_ID            IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_GRUPO_ID%TYPE,
pCAD_MTMD_SUBGRUPO_ID         IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_SUBGRUPO_ID%TYPE,
pCAD_MTMD_TPMOV_ID            IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_TPMOV_ID%TYPE,
pCAD_MTMD_SUBTP_ID            IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_SUBTP_ID%TYPE
) IS
BEGIN
   BEGIN
      INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
      (
       MTMD_MOV_DATA,                        CAD_MTMD_ID,                           CAD_MTMD_FILIAL_ID,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,         CAD_UNI_ID_UNIDADE,                    CAD_SET_ID,
       MTMD_CUSTO_MEDIO_ANTERIOR,            MTMD_SALDO_ANTERIOR,                   MTMD_VALOR_ANTERIOR,
       MTMD_QTDE_ENTRADA,                    MTMD_VALOR_ENTRADA,                    MTMD_QTDE_SAIDA,
       MTMD_VALOR_SAIDA,                     MTMD_CUSTO_MEDIO_ATUAL,                MTMD_SALDO_ATUAL,
       MTMD_VALOR_ATUAL,                     CAD_MTMD_GRUPO_ID,                     CAD_MTMD_SUBGRUPO_ID,
       MTMD_QTDE_ACERTO,                     SEG_USU_ID_USUARIO,                    SEG_DT_ATUALIZACAO,
       CAD_MTMD_TPMOV_ID,                    CAD_MTMD_SUBTP_ID
      )
      VALUES
      (
       pMTMD_MOV_DATA,                       pCAD_MTMD_ID_ME,                       pCAD_MTMD_FILIAL_ID_ME,
       pCAD_LAT_ID_LOCAL_ATENDIMENTO,        pCAD_UNI_ID_UNIDADE,                   pCAD_SET_ID,
       pMTMD_CUSTO_MEDIO_ANTERIOR,           pMTMD_SALDO_ANTERIOR,                  pMTMD_VALOR_ANTERIOR,
       pMTMD_QTDE_ENTRADA,                   pMTMD_VALOR_ENTRADA,                   pMTMD_QTDE_SAIDA,
       pMTMD_VALOR_SAIDA,                    pMTMD_CUSTO_MEDIO_ATUAL,               pMTMD_SALDO_ATUAL,
       pMTMD_VALOR_ATUAL,                    pCAD_MTMD_GRUPO_ID,                    pCAD_MTMD_SUBGRUPO_ID,
       0, /*MTMD_QTDE_ACERTO*/               1,                                     SYSDATE,
       pCAD_MTMD_TPMOV_ID,                   pCAD_MTMD_SUBTP_ID
      );
   EXCEPTION
      WHEN DUP_VAL_ON_INDEX THEN
         UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
         MTMD_QTDE_ENTRADA        =  NVL(MTMD_QTDE_ENTRADA,0)  + pMTMD_QTDE_ENTRADA,
         MTMD_VALOR_ENTRADA       =  NVL(MTMD_VALOR_ENTRADA,0) + NVL(pMTMD_VALOR_ENTRADA,0),
         MTMD_CUSTO_MEDIO_ATUAL   =  pMTMD_CUSTO_MEDIO_ATUAL,
         SEG_DT_ATUALIZACAO       =  SYSDATE
         WHERE MTMD_MOV_DATA                = pMTMD_MOV_DATA
         AND   CAD_MTMD_ID                  = pCAD_MTMD_ID_ME
         AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID_ME
         AND   CAD_MTMD_GRUPO_ID            = pCAD_MTMD_GRUPO_ID
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
         AND   CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
         AND   CAD_SET_ID                   = pCAD_SET_ID
         AND   CAD_MTMD_TPMOV_ID            = pCAD_MTMD_TPMOV_ID
         AND   CAD_MTMD_SUBTP_ID            = pCAD_MTMD_SUBTP_ID;
   END;
END INSEREMOVIMENTOENTRADA;
-- ===========================================================================================================================
PROCEDURE LinhaZero
(
pMTMD_MOV_DATA                IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_MOV_DATA%TYPE,
pCAD_MTMD_ID_LZ               IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_ID%TYPE,
pCAD_MTMD_FILIAL_ID_LZ        IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_FILIAL_ID%TYPE,
pMTMD_QTDE_ENTRADA            IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_QTDE_ENTRADA%TYPE,
pMTMD_VALOR_ENTRADA           IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_ENTRADA%TYPE,
pMTMD_QTDE_SAIDA              IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_QTDE_SAIDA%TYPE,
pMTMD_VALOR_SAIDA             IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_SAIDA%TYPE,
pCAD_MTMD_GRUPO_ID            IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_GRUPO_ID%TYPE,
pCAD_MTMD_SUBGRUPO_ID         IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_SUBGRUPO_ID%TYPE
) IS
vSALDO_ATUAL NUMBER;
vVALOR_ATUAL NUMBER;
BEGIN
   vVALOR_ATUAL := pMTMD_VALOR_ENTRADA-pMTMD_VALOR_SAIDA;
   vSALDO_ATUAL := pMTMD_QTDE_ENTRADA-pMTMD_QTDE_SAIDA;
   /*BEGIN
      INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
      (MTMD_MOV_DATA,                            CAD_MTMD_ID,                           CAD_MTMD_FILIAL_ID,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,             CAD_UNI_ID_UNIDADE,                    CAD_SET_ID,
       MTMD_CUSTO_MEDIO_ANTERIOR,                MTMD_SALDO_ANTERIOR,                   MTMD_VALOR_ANTERIOR,
       MTMD_QTDE_ENTRADA,                        MTMD_VALOR_ENTRADA,                    MTMD_QTDE_SAIDA,
       MTMD_VALOR_SAIDA,                         MTMD_CUSTO_MEDIO_ATUAL,                MTMD_SALDO_ATUAL,
       MTMD_VALOR_ATUAL,                         CAD_MTMD_GRUPO_ID,                     CAD_MTMD_SUBGRUPO_ID,
       MTMD_QTDE_ACERTO,                         SEG_USU_ID_USUARIO,                    SEG_DT_ATUALIZACAO,
       CAD_MTMD_TPMOV_ID,                        CAD_MTMD_SUBTP_ID )
      VALUES
      (TRUNC(pMTMD_MOV_DATA),                    pCAD_MTMD_ID_LZ,                       pCAD_MTMD_FILIAL_ID_LZ,
       33,                                       244,                                   29,
       0,                                        0,                                     0,
       0,                                        0,                                     0,
       0,                                        DECODE(vSALDO_ATUAL, 0, 0, vVALOR_ATUAL / vSALDO_ATUAL), vSALDO_ATUAL,
       vVALOR_ATUAL,                             pCAD_MTMD_GRUPO_ID,                    pCAD_MTMD_SUBGRUPO_ID,
       0,                                        1,                                     SYSDATE,
       0,                                        0);
   EXCEPTION WHEN DUP_VAL_ON_INDEX THEN*/
      BEGIN
         UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
         --MTMD_CUSTO_MEDIO_ATUAL   =  round(((NVL(MTMD_VALOR_ATUAL,0) + pMTMD_VALOR_ENTRADA) - pMTMD_VALOR_SAIDA),2)/round(((NVL(MTMD_SALDO_ATUAL,0) + pMTMD_QTDE_ENTRADA)  - pMTMD_QTDE_SAIDA),2),
         MTMD_CUSTO_MEDIO_ATUAL   =  round(((NVL(MTMD_VALOR_ATUAL,0) + pMTMD_VALOR_ENTRADA) - pMTMD_VALOR_SAIDA),4)/round(((NVL(MTMD_SALDO_ATUAL,0) + pMTMD_QTDE_ENTRADA)  - pMTMD_QTDE_SAIDA),4),
         MTMD_SALDO_ATUAL         =  (NVL(MTMD_SALDO_ATUAL,0) + pMTMD_QTDE_ENTRADA)  - pMTMD_QTDE_SAIDA ,
         MTMD_VALOR_ATUAL         =  (NVL(MTMD_VALOR_ATUAL,0) + pMTMD_VALOR_ENTRADA) - pMTMD_VALOR_SAIDA,
         SEG_DT_ATUALIZACAO       =  SYSDATE
         WHERE MTMD_MOV_DATA                = TRUNC(pMTMD_MOV_DATA)
         AND   CAD_MTMD_ID                  = pCAD_MTMD_ID_LZ
         AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID_LZ
         --AND   CAD_MTMD_GRUPO_ID            = pCAD_MTMD_GRUPO_ID
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
         AND   CAD_UNI_ID_UNIDADE           = 244
         AND   CAD_SET_ID                   = 29
         AND   CAD_MTMD_TPMOV_ID            = 0
         AND   CAD_MTMD_SUBTP_ID            = 0;
      EXCEPTION
         WHEN ZERO_DIVIDE THEN
            UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
            MTMD_CUSTO_MEDIO_ATUAL   =  0,
            MTMD_SALDO_ATUAL         =  (NVL(MTMD_SALDO_ATUAL,0) + pMTMD_QTDE_ENTRADA)  - pMTMD_QTDE_SAIDA,
            MTMD_VALOR_ATUAL         =  (NVL(MTMD_VALOR_ATUAL,0) + pMTMD_VALOR_ENTRADA) - pMTMD_VALOR_SAIDA,
            SEG_DT_ATUALIZACAO       =  SYSDATE
            WHERE MTMD_MOV_DATA                = pMTMD_MOV_DATA
            AND   CAD_MTMD_ID                  = pCAD_MTMD_ID_LZ
            AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID_LZ
            --AND   CAD_MTMD_GRUPO_ID            = pCAD_MTMD_GRUPO_ID
            AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
            AND   CAD_UNI_ID_UNIDADE           = 244
            AND   CAD_SET_ID                   = 29
            AND   CAD_MTMD_TPMOV_ID            = 0
            AND   CAD_MTMD_SUBTP_ID            = 0;
      END;
   --END;
END LinhaZero;
-- ===========================================================================================================================
FUNCTION BuscaSaldoAtual(
pCAD_MTMD_ID_SA               IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_ID%TYPE,
pCAD_MTMD_FILIAL_ID_SA        IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_FILIAL_ID%TYPE,
pCAD_MTMD_GRUPO_ID            IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_GRUPO_ID%TYPE,
pMTMD_MOV_DATA                IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_MOV_DATA%TYPE  ) RETURN NUMBER
IS
vMTMD_SALDO_ATUAL TB_MTMD_MOV_ESTOQUE_DIA.MTMD_SALDO_ATUAL%TYPE;
BEGIN
   BEGIN
      SELECT SUM(MTMD_SALDO_ATUAL)
      INTO   vMTMD_SALDO_ATUAL
      FROM TB_MTMD_MOV_ESTOQUE_DIA
      WHERE MTMD_MOV_DATA                = pMTMD_MOV_DATA
      AND   CAD_MTMD_ID                  = pCAD_MTMD_ID_SA
      AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID_SA
      --AND   CAD_MTMD_GRUPO_ID            = pCAD_MTMD_GRUPO_ID
      AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
      AND   CAD_UNI_ID_UNIDADE           = 244
      AND   CAD_SET_ID                   = 29
      AND   CAD_MTMD_TPMOV_ID            = 0
      AND   CAD_MTMD_SUBTP_ID            = 0;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      vMTMD_SALDO_ATUAL := 0;
   END;
   RETURN vMTMD_SALDO_ATUAL;
END BuscaSaldoAtual;
 -- ===========================================================================================================================
PROCEDURE GERAMOVIMENTACAO
(
pMTMD_MOV_DATA                IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_MOV_DATA%TYPE,
pCAD_MTMD_ID_G                IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_ID%TYPE,
pCAD_MTMD_FILIAL_ID_G         IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_FILIAL_ID%TYPE,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_UNI_ID_UNIDADE%TYPE,
pCAD_SET_ID                   IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_SET_ID%TYPE,
pMTMD_QTDE_ENTRADA            IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_QTDE_ENTRADA%TYPE,
pMTMD_VALOR_ENTRADA           IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_ENTRADA%TYPE,
pMTMD_QTDE_SAIDA              IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_QTDE_SAIDA%TYPE,
pMTMD_VALOR_SAIDA             IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_VALOR_SAIDA%TYPE,
pMTMD_CUSTO_MEDIO_ATUAL       IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_CUSTO_MEDIO_ATUAL%TYPE,
pCAD_MTMD_GRUPO_ID            IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_GRUPO_ID%TYPE,
pCAD_MTMD_SUBGRUPO_ID         IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_SUBGRUPO_ID%TYPE,
pCAD_MTMD_TPMOV_ID            IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_TPMOV_ID%TYPE,
pCAD_MTMD_SUBTP_ID            IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_SUBTP_ID%TYPE
) IS
vCAD_LAT_ID_LOCAL_ATENDIMENTO TB_MTMD_MOV_ESTOQUE_DIA.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE := pCAD_LAT_ID_LOCAL_ATENDIMENTO;
vCAD_UNI_ID_UNIDADE           TB_MTMD_MOV_ESTOQUE_DIA.CAD_UNI_ID_UNIDADE%TYPE := pCAD_UNI_ID_UNIDADE;
vCAD_SET_ID                   TB_MTMD_MOV_ESTOQUE_DIA.CAD_SET_ID%TYPE := pCAD_SET_ID;
BEGIN
   IF (pCAD_MTMD_GRUPO_ID = 4 AND pCAD_MTMD_SUBGRUPO_ID = 942) THEN --ALIMENTOS NAO ESTOCAVEIS
      vCAD_LAT_ID_LOCAL_ATENDIMENTO := 33;
      vCAD_UNI_ID_UNIDADE := 244;
      vCAD_SET_ID := 183;
   END IF;
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
      (TRUNC(pMTMD_MOV_DATA),          pCAD_MTMD_ID_G,                  pCAD_MTMD_FILIAL_ID_G,
       vCAD_UNI_ID_UNIDADE,            vCAD_SET_ID,                     vCAD_LAT_ID_LOCAL_ATENDIMENTO,
       0,                              0,                               0,
       pMTMD_QTDE_ENTRADA,             pMTMD_VALOR_ENTRADA,
       pMTMD_QTDE_SAIDA,               pMTMD_VALOR_SAIDA,
       0,                              0,                               NVL(pMTMD_CUSTO_MEDIO_ATUAL,0),
       pCAD_MTMD_GRUPO_ID,             pCAD_MTMD_SUBGRUPO_ID,
       0,                              1,
       SYSDATE,                        pCAD_MTMD_TPMOV_ID,              pCAD_MTMD_SUBTP_ID);
   EXCEPTION
      WHEN DUP_VAL_ON_INDEX THEN
         UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
         MTMD_QTDE_ENTRADA        =  NVL(MTMD_QTDE_ENTRADA,0)  + pMTMD_QTDE_ENTRADA,
         MTMD_VALOR_ENTRADA       =  NVL(MTMD_VALOR_ENTRADA,0) + NVL(pMTMD_VALOR_ENTRADA,0),
         MTMD_QTDE_SAIDA          =  NVL(MTMD_QTDE_SAIDA,0)    + pMTMD_QTDE_SAIDA,
         MTMD_VALOR_SAIDA         =  NVL(MTMD_VALOR_SAIDA,0)   + pMTMD_VALOR_SAIDA,
         MTMD_CUSTO_MEDIO_ATUAL   =  NVL(pMTMD_CUSTO_MEDIO_ATUAL,0),
         SEG_DT_ATUALIZACAO       =  SYSDATE
         WHERE MTMD_MOV_DATA                = TRUNC(pMTMD_MOV_DATA)
         AND   CAD_MTMD_ID                  = pCAD_MTMD_ID_G
         AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID_G
         AND   CAD_MTMD_GRUPO_ID            = pCAD_MTMD_GRUPO_ID
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vCAD_LAT_ID_LOCAL_ATENDIMENTO
         AND   CAD_UNI_ID_UNIDADE           = vCAD_UNI_ID_UNIDADE
         AND   CAD_SET_ID                   = vCAD_SET_ID
         AND   CAD_MTMD_TPMOV_ID            = pCAD_MTMD_TPMOV_ID
         AND   CAD_MTMD_SUBTP_ID            = pCAD_MTMD_SUBTP_ID;
         COMMIT;
      WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(-20000,' ERRO INSERINDO '||SQLERRM);
   END;
END GERAMOVIMENTACAO;
FUNCTION CALCULACM
(
pQTDE_ENTRADA                 IN  NUMBER, -- QTDE RECEBIDA NA NOTA FISCAL
pPRECO_ATUAL                  IN  NUMBER, -- PRECO DA NOTA FISCAL
pMTMD_ESTCON_QTDE_ANTERIOR    IN  NUMBER DEFAULT NULL, -- ESTOQUE NO HISTORICO DO PRODUTO
pMTMD_CUSTO_MEDIO_ANTERIOR    IN  NUMBER DEFAULT NULL
) RETURN NUMBER IS
vMTMD_CUSTO_MEDIO       NUMBER;
ResultadoAtual          NUMBER;
Resultadoentrada        NUMBER;
SomaEstoque             NUMBER;
Parte1                  NUMBER;
ResultadoFinal          NUMBER;
BEGIN
IF( pMTMD_CUSTO_MEDIO_ANTERIOR = 0 OR pMTMD_ESTCON_QTDE_ANTERIOR = 0 ) THEN
         vMTMD_CUSTO_MEDIO := pPRECO_ATUAL;
ELSE
   BEGIN
      ResultadoAtual   := NVL(pMTMD_ESTCON_QTDE_ANTERIOR,0) * NVL(pMTMD_CUSTO_MEDIO_ANTERIOR,0);
      Resultadoentrada := pQTDE_ENTRADA * pPRECO_ATUAL;
      SomaEstoque      := pMTMD_ESTCON_QTDE_ANTERIOR + pQTDE_ENTRADA;
      Parte1           := ResultadoAtual + Resultadoentrada;
      IF (SomaEstoque > 0) THEN
         ResultadoFinal := Parte1/SomaEstoque;
      ELSE
         ResultadoFinal := 0;
      END IF;
      IF (ResultadoFinal < 0) THEN
         ResultadoFinal := 0;
      END IF;
      vMTMD_CUSTO_MEDIO := ResultadoFinal;
   EXCEPTION
      WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(-20000, SQLERRM);
   END;
END IF;
   RETURN vMTMD_CUSTO_MEDIO;
END CALCULACM;
-- ===========================================================================================================================
-- INICIO PROCEDURE
-- ===========================================================================================================================
BEGIN
  -- EXCLUI TODOS OS DADOS DO MES
  /*DELETE TB_MTMD_MOV_ESTOQUE_DIA
  WHERE MTMD_MOV_DATA >= TO_DATE('31122010 0000','DDMMYYYY HH24MI')
  AND   MTMD_MOV_DATA <= TO_DATE('31012011 235959','DDMMYYYY HH24MISS');*/
  IF (NOT pCAD_MTMD_ID IS NULL AND NOT pCAD_MTMD_FILIAL_ID IS NULL) THEN
    DELETE TB_MTMD_MOV_ESTOQUE_DIA
    WHERE MTMD_MOV_DATA >= pDataDe
    AND   MTMD_MOV_DATA <= pDataAte
    AND   CAD_MTMD_ID = pCAD_MTMD_ID
    AND   CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID;
  ELSIF (NOT pCAD_MTMD_FILIAL_ID IS NULL) THEN
    DELETE TB_MTMD_MOV_ESTOQUE_DIA
    WHERE MTMD_MOV_DATA >= pDataDe
    AND   MTMD_MOV_DATA <= pDataAte
    AND   CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID;
  ELSE
    DELETE TB_MTMD_MOV_ESTOQUE_DIA
    WHERE MTMD_MOV_DATA >= pDataDe
    AND   MTMD_MOV_DATA <= pDataAte;
  END IF;
  COMMIT;
/*FOR CONT IN (SELECT * FROM SGS.TB_MTMD_ESTOQUE_CONTABIL_FECHA
--             WHERE CAD_MTMD_ID IN (14965, 800, 5198, 39473, 6263, 4642, 1440, 5921, 756 )
--             WHERE CAD_MTMD_ID = 46415
            ) LOOP*/
FOR CONT IN (SELECT MTMD.CAD_MTMD_ID,
                    LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                    LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                    LINHA_ZERO.CAD_MTMD_FILIAL_ID,
                    LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_INICIAL, --MTMD_SALDO_ATUAL,
                    DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO_INICIAL, --MTMD_CUSTO_MEDIO_ATUAL,
                    LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL
              FROM TB_CAD_MTMD_MAT_MED MTMD,
                   TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                   (
                     SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = Add_months(pDataDe, -1)
                     AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
                     AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO,
                   (
                     SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE CAD_MTMD_TPMOV_ID            = 1
                     AND   CAD_MTMD_SUBTP_ID            = 1
                     AND   MTMD_MOV_DATA >= Add_months(pDataDe, -1)
                     AND   MTMD_MOV_DATA <= Add_months(pDataAte, -1)
                     AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
                     AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )
                   ) NOTAS
              WHERE DIAP.MTMD_MOV_DATA >= Add_months(pDataDe, -1)
              AND   DIAP.MTMD_MOV_DATA <= Add_months(pDataAte, -1)
              AND   ( pCAD_MTMD_ID IS NULL OR DIAP.CAD_MTMD_ID = pCAD_MTMD_ID )
              AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR DIAP.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
              AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
              AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
              AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)         = DIAP.CAD_MTMD_SUBGRUPO_ID
              AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
              AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
              AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
              AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
              AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
              AND NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL
              GROUP BY MTMD.CAD_MTMD_ID,
                       LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                       LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                       LINHA_ZERO.CAD_MTMD_FILIAL_ID,
                       DIAP.CAD_MTMD_FILIAL_ID,
                       LINHA_ZERO.MTMD_SALDO_ATUAL,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                       LINHA_ZERO.MTMD_VALOR_ATUAL
              HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0) + NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0) ) > 0
              --HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)  ) > 0
              UNION -- Junta com produtos incluidos no mes que n?o tinha no mes anterior
             /*SELECT M.CAD_MTMD_ID,
                     M.CAD_MTMD_GRUPO_ID,
                     M.CAD_MTMD_SUBGRUPO_ID,
                     C.CAD_MTMD_FILIAL_ID,
                     0 MTMD_SALDO_ATUAL, 0 MTMD_CUSTO_MEDIO_ATUAL, 0 MTMD_SALDO_ATUAL
                FROM TPRD@RMDB T,
                     TB_CAD_MTMD_MAT_MED M,
                     TB_MTMD_ESTOQUE_CONTABIL C
               WHERE M.CAD_MTMD_CD_RM = T.IDPRD AND
                     C.CAD_MTMD_ID = M.CAD_MTMD_ID AND
                     T.DTCADASTRAMENTO >= pDataDe AND
                     T.DTCADASTRAMENTO <= pDataAte AND
                     ( pCAD_MTMD_ID IS NULL OR M.CAD_MTMD_ID = pCAD_MTMD_ID ) AND
                     ( pCAD_MTMD_FILIAL_ID IS NULL OR C.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )*/
              SELECT CAD_MTMD_ID,  
                     CAD_MTMD_GRUPO_ID,
                     CAD_MTMD_SUBGRUPO_ID,
                     CAD_MTMD_FILIAL_ID,
                     0 MTMD_SALDO_ATUAL, 0 MTMD_CUSTO_MEDIO_ATUAL, 0 MTMD_SALDO_ATUAL
              FROM (SELECT DISTINCT
                           M.CAD_MTMD_ID,
                           M.CAD_MTMD_GRUPO_ID,
                           M.CAD_MTMD_SUBGRUPO_ID,
                           M.CAD_MTMD_FILIAL_ID,
                           0 MTMD_SALDO_ATUAL, 0 MTMD_CUSTO_MEDIO_ATUAL, 0 MTMD_SALDO_ATUAL
                    FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA_X M
                    UNION
                    SELECT DISTINCT
                           S.CAD_MTMD_ID,
                           S.CAD_MTMD_GRUPO_ID,
                           S.CAD_MTMD_SUBGRUPO_ID,
                           S.CAD_MTMD_FILIAL_ID,
                           0 MTMD_SALDO_ATUAL, 0 MTMD_CUSTO_MEDIO_ATUAL, 0 MTMD_SALDO_ATUAL
                    FROM SGS.TB_MTMD_MOV_ESTOQUE_SAI S) EST
              WHERE --M.MTMD_MOV_DATA >= pDataDe
              --AND   M.MTMD_MOV_DATA <= pDataAte
                  ( pCAD_MTMD_FILIAL_ID IS NULL OR EST.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
              AND ( pCAD_MTMD_ID IS NULL OR EST.CAD_MTMD_ID = pCAD_MTMD_ID )
              AND EST.CAD_MTMD_ID NOT IN
              (
              SELECT MTMD.CAD_MTMD_ID
              FROM TB_CAD_MTMD_MAT_MED MTMD,
                   TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                   (
                     SELECT CAD_MTMD_ID, CAD_MTMD_FILIAL_ID, CAD_MTMD_GRUPO_ID, CAD_MTMD_SUBGRUPO_ID, MTMD_VALOR_ATUAL
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = Add_months(pDataDe, -1)
                     AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
                     AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO,
                   (
                     SELECT CAD_MTMD_ID, MTMD_MOV_DATA, CAD_MTMD_FILIAL_ID, CAD_MTMD_TPMOV_ID, CAD_MTMD_SUBTP_ID
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE CAD_MTMD_TPMOV_ID            = 1
                     AND   CAD_MTMD_SUBTP_ID            = 1
                     AND   MTMD_MOV_DATA >= Add_months(pDataDe, -1)
                     AND   MTMD_MOV_DATA <= Add_months(pDataAte, -1)
                     AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
                     AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )
                   ) NOTAS
              WHERE DIAP.MTMD_MOV_DATA >= Add_months(pDataDe, -1)
              AND   DIAP.MTMD_MOV_DATA <= Add_months(pDataAte, -1)
              AND   ( pCAD_MTMD_ID IS NULL OR DIAP.CAD_MTMD_ID = pCAD_MTMD_ID )
              AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR DIAP.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
              AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
              AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
              AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)         = DIAP.CAD_MTMD_SUBGRUPO_ID
              AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
              AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
              AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
              AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
              AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
              AND NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL
              AND MTMD.CAD_MTMD_ID = EST.CAD_MTMD_ID
              GROUP BY MTMD.CAD_MTMD_ID,
                       LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                       LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                       LINHA_ZERO.CAD_MTMD_FILIAL_ID,
                       DIAP.CAD_MTMD_FILIAL_ID
              HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0)  ) > 0
              )
            ) LOOP
      /*BEGIN
        select t.cad_mtmd_id INTO vMTMD from sgs.tb_mtmd_mov_estoque_dia t
        where rownum = 1 and trunc(mtmd_mov_data) >= to_date('01042014', 'ddMMyyyy')
        and t.cad_mtmd_filial_id = CONT.CAD_MTMD_FILIAL_ID
        and cad_mtmd_id = CONT.CAD_MTMD_ID;
      EXCEPTION WHEN NO_DATA_FOUND THEN    */
      IF ( NVL(CONT.CAD_MTMD_GRUPO_ID,0) = 0 ) THEN
         -- BUSCA GRUPO DO CADASTRO
         BEGIN
            SELECT MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID, CAD_MTMD_FL_ATIVO
            INTO   vCAD_MTMD_GRUPO_ID,     vCAD_MTMD_SUBGRUPO_ID,     vCAD_MTMD_FL_ATIVO
            FROM TB_CAD_MTMD_MAT_MED MTMD
            WHERE MTMD.CAD_MTMD_ID = CONT.CAD_MTMD_ID;
            CONT.CAD_MTMD_GRUPO_ID    := vCAD_MTMD_GRUPO_ID;
            CONT.CAD_MTMD_SUBGRUPO_ID := vCAD_MTMD_SUBGRUPO_ID;
         END;
      END IF;
      vCAD_MTMD_GRUPO_ID    := CONT.CAD_MTMD_GRUPO_ID;
      vCAD_MTMD_SUBGRUPO_ID := CONT.CAD_MTMD_SUBGRUPO_ID;
      vMTMD_CUSTO_MEDIO     := CONT.MTMD_CUSTO_MEDIO_INICIAL;
      vMTMD_SALDO_ATUAL     := CONT.MTMD_SALDO_INICIAL;
      --vMTMD_VALOR_ATUAL     := NVL(CONT.MTMD_CUSTO_MEDIO_INICIAL,0)*NVL(CONT.MTMD_SALDO_INICIAL,0);
      vMTMD_VALOR_ATUAL     := CONT.MTMD_VALOR_ATUAL;
--==================================================================================================
-- INICIO PARTE 1
--==================================================================================================
   IF (  nPasso = 1 OR nPasso = 5 ) THEN
      --IF ( vCAD_MTMD_GRUPO_ID != 4 ) THEN
         INSEREMESATUAL(pDataDe, --TO_DATE('31122010','DDMMYYYY'),       -- pMTMD_MOV_DATA
                        CONT.CAD_MTMD_ID,                     -- pCAD_MTMD_ID
                        CONT.CAD_MTMD_FILIAL_ID,              -- pCAD_MTMD_FILIAL_ID
                        33,                                   -- pCAD_LAT_ID_LOCAL_ATENDIMENTO
                        244,                                  -- pCAD_UNI_ID_UNIDADE
                        29,                                   -- pCAD_SET_ID
                        0,                                    -- pMTMD_CUSTO_MEDIO_ANTERIOR
                        0,                                    -- pMTMD_SALDO_ANTERIOR
                        0,                                    -- pMTMD_VALOR_ANTERIOR
                        0,                                    -- pMTMD_QTDE_ENTRADA
                        0,                                    -- pMTMD_VALOR_ENTRADA
                        0,                                    -- pMTMD_QTDE_SAIDA
                        0,                                    -- pMTMD_VALOR_SAIDA
                        NVL(CONT.MTMD_CUSTO_MEDIO_INICIAL,0), -- pMTMD_CUSTO_MEDIO_ATUAL
                        NVL(CONT.MTMD_SALDO_INICIAL,0),       -- pMTMD_SALDO_ATUAL
                        vMTMD_VALOR_ATUAL,                    -- pMTMD_VALOR_ATUAL
                        NVL(vCAD_MTMD_GRUPO_ID,0),        -- pCAD_MTMD_GRUPO_ID
                        NVL(vCAD_MTMD_SUBGRUPO_ID,0)      -- pCAD_MTMD_SUBGRUPO_ID
                       );
      --END IF; -- GRUPO
      COMMIT;
   END IF; -- passo
--==================================================================================================
-- FIM PARTE 1
--==================================================================================================
d1 := pDataDe;--TO_DATE('01012011 0000','DDMMYYYY HH24MI');
d2 := TO_DATE(TO_CHAR(pDataDe, 'DDMMYYYY') || ' 235959','DDMMYYYY HH24MISS');--pDataDe;--TO_DATE('01012011 2359','DDMMYYYY HH24MI');
LOOP
--==================================================================================================
-- INICIO PARTE 2
--==================================================================================================
   IF ( (nPasso = 2 OR nPasso = 5)  ) THEN
/*      FOR AJUSTE IN
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
        FROM  TMOV@RMDB TMOV,            FCFOCOMPL@RMDB FCFOCOMPL,
              TITMMOV@RMDB TITMMOV,      TPRD@RMDB TPRD,
              TUND@RMDB TUND,            TTRBMOV@RMDB TTRBMOV,
              TTRBMOV@RMDB TTRBMOV_ICMS, TUND@RMDB TUNDVENDA,
              MTM_MAT_MED M,           TB_CAD_MTMD_MAT_MED MTMD
        WHERE ( CODTMV = '1.2.41' OR  CODTMV = '1.2.45' OR  CODTMV = '1.2.58' OR  CODTMV = '1.2.62' OR
                CODTMV = '1.2.46' or  CODTMV = '1.2.47' OR  codtmv = '1.2.51' OR  codtmv = '1.2.56'  )
        and tmov.codcoligada             = fcfocompl.codcoligada(+)
        and tmov.codcfo                  = fcfocompl.codcfo(+)
        and titmmov.codcoligada          = tprd.codcoligada
        and titmmov.idprd                = tprd.idprd
        and tmov.codcoligada             = titmmov.codcoligada
        and tmov.idmov                   = titmmov.idmov
        and tund.codund                  = titmmov.codund
        and tundvenda.codund             = tprd.codundvenda
        and ttrbmov.codcoligada(+)       = titmmov.codcoligada
        and ttrbmov.idmov(+)             = titmmov.idmov
        and ttrbmov.nseqitmmov(+)        = titmmov.nseqitmmov
        AND TTRBMOV.CODTRB(+)            = 'IPI'
        and ttrbmov_ICMS.codcoligada(+)  = titmmov.codcoligada
        and ttrbmov_ICMS.idmov(+)        = titmmov.idmov
        and ttrbmov_ICMS.nseqitmmov(+)   = titmmov.nseqitmmov
        AND TTRBMOV_ICMS.CODTRB(+)       = 'ICMS'
        --
        AND MTMD.CAD_MTMD_ID             = CONT.CAD_MTMD_ID
--        AND TMOV.DATASAIDA               >= TO_DATE('01012011 0000','DDMMYYYY  HH24MI')
--        AND TMOV.DATASAIDA               <= TO_DATE('31012011 2359','DDMMYYYY HH24MI')
        AND TMOV.DATASAIDA               >= d1
        AND TMOV.DATASAIDA               <= d2
        --
        and M.CODALFMAT(+)  = SUBSTR(TPRD.CODIGOPRD,1,7)
        AND TPRD.CODCOLIGADA = 1
        AND MTMD.CAD_MTMD_CD_RM(+) = tprd.idprd
        order by  3, 9, 6 )
      LOOP      */
      FOR AJUSTE IN
      ( SELECT *
      FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA_X DIAX
      WHERE DIAX.MTMD_MOV_DATA >= d1
      AND   DIAX.MTMD_MOV_DATA <= d2
      AND   DIAX.CAD_MTMD_ID        = CONT.CAD_MTMD_ID
      AND   DIAX.CAD_MTMD_FILIAL_ID = CONT.CAD_MTMD_FILIAL_ID
      ORDER BY DIAX.MTMD_MOV_DATA)
      LOOP
         IF ( AJUSTE.CAD_MTMD_FILIAL_ID = CONT.CAD_MTMD_FILIAL_ID ) THEN
            vCAD_MTMD_GRUPO_ID    := AJUSTE.CAD_MTMD_GRUPO_ID;
            vCAD_MTMD_SUBGRUPO_ID := AJUSTE.CAD_MTMD_SUBGRUPO_ID;
            vMTMD_VALOR_ENTRADA  := NVL(AJUSTE.MTMD_VALOR_ENTRADA,0); -- *NVL( AJUSTE.QTDE_REL,0);
            vMTMD_QTDE_ENTRADA   := NVL(AJUSTE.MTMD_QTDE_ENTRADA,0);
            vMTMD_VALOR_UNITARIO := AJUSTE.MTMD_CUSTO_MEDIO_ATUAL;
            vMTMD_SALDO_ATUAL := BuscaSaldoAtual(CONT.CAD_MTMD_ID,
                                                 CONT.CAD_MTMD_FILIAL_ID,
                                                 vCAD_MTMD_GRUPO_ID,
                                                 pDataDe);--TO_DATE('01012011','DDMMYYYY'));
            vMTMD_CUSTO_MEDIO := CALCULACM( --CONT.CAD_MTMD_ID,
                                            --CONT.CAD_MTMD_FILIAL_ID,
                                            vMTMD_QTDE_ENTRADA,
                                            vMTMD_VALOR_UNITARIO,
                                            vMTMD_SALDO_ATUAL,
                                            vMTMD_CUSTO_MEDIO );
            INSEREMOVIMENTOENTRADA(
                                   AJUSTE.MTMD_MOV_DATA,   -- pMTMD_MOV_DATA
                                   AJUSTE.CAD_MTMD_ID,               -- pCAD_MTMD_ID
                                   AJUSTE.CAD_MTMD_FILIAL_ID,                    -- pCAD_MTMD_FILIAL_ID
                                   33,                               -- pCAD_LAT_ID_LOCAL_ATENDIMENTO
                                   244,                              -- pCAD_UNI_ID_UNIDADE
                                   29,                               -- pCAD_SET_ID
                                   0,                                -- pMTMD_CUSTO_MEDIO_ANTERIOR
                                   0,                                -- pMTMD_SALDO_ANTERIOR
                                   0,                                -- pMTMD_VALOR_ANTERIOR
                                   vMTMD_QTDE_ENTRADA,               -- pMTMD_QTDE_ENTRADA
                                   vMTMD_VALOR_ENTRADA,              -- pMTMD_VALOR_ENTRADA
                                   0,                                -- pMTMD_QTDE_SAIDA
                                   0,                                -- pMTMD_VALOR_SAIDA
                                   vMTMD_VALOR_UNITARIO,             -- pMTMD_CUSTO_MEDIO_ATUAL
                                   0,                                -- pMTMD_SALDO_ATUAL
                                   0,                                -- pMTMD_VALOR_ATUAL
                                   AJUSTE.CAD_MTMD_GRUPO_ID,               -- pCAD_MTMD_GRUPO_ID
                                   AJUSTE.CAD_MTMD_SUBGRUPO_ID,            -- pCAD_MTMD_SUBGRUPO_ID
                                   1,                                -- pCAD_MTMD_TPMOV_ID
                                   1                                 -- pCAD_MTMD_SUBTP_ID
                                  );
            COMMIT;
            LinhaZero(
                               pDataDe, --TO_DATE('01012011','DDMMYYYY'),    -- pMTMD_MOV_DATA
                               AJUSTE.CAD_MTMD_ID,                -- pCAD_MTMD_ID
                               AJUSTE.CAD_MTMD_FILIAL_ID,                     -- pCAD_MTMD_FILIAL_ID
                               -- pCAD_LAT_ID_LOCAL_ATENDIMENTO
                               -- pCAD_UNI_ID_UNIDADE
                               -- pCAD_SET_ID
                               -- 0,                                 -- pMTMD_CUSTO_MEDIO_ANTERIOR
                               -- 0,                                 -- pMTMD_SALDO_ANTERIOR
                               -- 0,                                 -- pMTMD_VALOR_ANTERIOR
                               vMTMD_QTDE_ENTRADA,                -- pMTMD_QTDE_ENTRADA
                               vMTMD_VALOR_ENTRADA,               -- pMTMD_VALOR_ENTRADA
                               0,                                 -- pMTMD_QTDE_SAIDA
                               0,                                 -- pMTMD_VALOR_SAIDA
                               -- pMTMD_CUSTO_MEDIO_ATUAL
                               -- pMTMD_SALDO_ATUAL
                               -- pMTMD_VALOR_ATUAL
                               AJUSTE.CAD_MTMD_GRUPO_ID,               -- pCAD_MTMD_GRUPO_ID
                               AJUSTE.CAD_MTMD_SUBGRUPO_ID             -- pCAD_MTMD_SUBGRUPO_ID
                               -- pCAD_MTMD_TPMOV_ID
                               -- pCAD_MTMD_SUBTP_ID
                             );
            COMMIT;
            -- ===========================================================================================
            IF ( (vCAD_MTMD_GRUPO_ID = 4 AND vCAD_MTMD_SUBGRUPO_ID = 942) OR --ALIMENTOS NAO ESTOCAVEIS
                 (AJUSTE.CAD_MTMD_FILIAL_ID = 2 AND vCAD_MTMD_GRUPO_ID != 1 AND vMTMD_VALOR_ENTRADA < 0) OR
                 (AJUSTE.CAD_MTMD_FILIAL_ID = 1 AND vCAD_MTMD_GRUPO_ID = 61 AND vMTMD_VALOR_ENTRADA < 0)) THEN
               -- BAIXA DIRETO
               vMTMD_QTDE_SAIDA    := vMTMD_QTDE_ENTRADA;
               vMTMD_VALOR_SAIDA   := vMTMD_VALOR_ENTRADA;
               vMTMD_VALOR_ENTRADA := 0;
               vMTMD_QTDE_ENTRADA  := 0;
               GERAMOVIMENTACAO(
                                 AJUSTE.MTMD_MOV_DATA,                 -- pMTMD_MOV_DATA
                                 AJUSTE.CAD_MTMD_ID,                      -- pCAD_MTMD_ID
                                 AJUSTE.CAD_MTMD_FILIAL_ID,                           -- pCAD_MTMD_FILIAL_ID
                                 33,                                      -- pCAD_LAT_ID_LOCAL_ATENDIMENTO
                                 244,                                     -- pCAD_UNI_ID_UNIDADE
                                 29,  -- pCAD_SET_ID
                                 -- pMTMD_CUSTO_MEDIO_ANTERIOR
                                 -- pMTMD_SALDO_ANTERIOR
                                 -- pMTMD_VALOR_ANTERIOR
                                 vMTMD_QTDE_ENTRADA,                      -- pMTMD_QTDE_ENTRADA
                                 vMTMD_VALOR_ENTRADA,                     -- pMTMD_VALOR_ENTRADA
                                 vMTMD_QTDE_SAIDA,                        -- pMTMD_QTDE_SAIDA
                                 vMTMD_VALOR_SAIDA,                       -- pMTMD_VALOR_SAIDA
                                 vMTMD_VALOR_UNITARIO,                    -- pMTMD_CUSTO_MEDIO_ATUAL
                                 -- pMTMD_SALDO_ATUAL
                                 -- pMTMD_VALOR_ATUAL
                                 AJUSTE.CAD_MTMD_GRUPO_ID,                      -- pCAD_MTMD_GRUPO_ID
                                 AJUSTE.CAD_MTMD_SUBGRUPO_ID,                   -- pCAD_MTMD_SUBGRUPO_ID
                                 2,                                       -- pCAD_MTMD_TPMOV_ID
                                 18                                       -- pCAD_MTMD_SUBTP_ID
                                );
               COMMIT;
               LinhaZero(
                                  pDataDe, --TO_DATE('01012011','DDMMYYYY'),    -- pMTMD_MOV_DATA
                                  AJUSTE.CAD_MTMD_ID,                -- pCAD_MTMD_ID
                                  AJUSTE.CAD_MTMD_FILIAL_ID,                     -- pCAD_MTMD_FILIAL_ID
                                  -- pCAD_LAT_ID_LOCAL_ATENDIMENTO
                                  -- pCAD_UNI_ID_UNIDADE
                                  -- pCAD_SET_ID
                                  -- 0,                                 -- pMTMD_CUSTO_MEDIO_ANTERIOR
                                  -- 0,                                 -- pMTMD_SALDO_ANTERIOR
                                  -- 0,                                 -- pMTMD_VALOR_ANTERIOR
                                  vMTMD_QTDE_ENTRADA,                -- pMTMD_QTDE_ENTRADA
                                  vMTMD_VALOR_ENTRADA,               -- pMTMD_VALOR_ENTRADA
                                  vMTMD_QTDE_SAIDA,                  -- pMTMD_QTDE_SAIDA
                                  vMTMD_VALOR_SAIDA,                 -- pMTMD_VALOR_SAIDA
                                  -- pMTMD_CUSTO_MEDIO_ATUAL
                                  -- pMTMD_SALDO_ATUAL
                                  -- pMTMD_VALOR_ATUAL
                                  AJUSTE.CAD_MTMD_GRUPO_ID,               -- pCAD_MTMD_GRUPO_ID
                                  AJUSTE.CAD_MTMD_SUBGRUPO_ID             -- pCAD_MTMD_SUBGRUPO_ID
                                  -- pCAD_MTMD_TPMOV_ID
                                  -- pCAD_MTMD_SUBTP_ID
                             );
               COMMIT;
            END IF; -- GRUPO
         END IF; -- TESTE FILIAL
      END LOOP;
   END IF;
--==================================================================================================
-- FIM PARTE 2
--==================================================================================================
--==================================================================================================
-- INICIO PARTE 3
--==================================================================================================
   IF ( nPasso IN (3) OR nPasso = 5  ) THEN
      IF (CONT.CAD_MTMD_SUBGRUPO_ID != 942) THEN --ALIMENTOS NAO ESTOCAVEIS
            FOR MES IN (
               /*
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
                     MOV.CAD_MTMD_SUBGRUPO_ID */
               SELECT * FROM SGS.TB_MTMD_MOV_ESTOQUE_SAI SAI
               WHERE SAI.CAD_MTMD_ID        = CONT.CAD_MTMD_ID
               AND   SAI.CAD_MTMD_FILIAL_ID = CONT.CAD_MTMD_FILIAL_ID
               AND   SAI.MTMD_MOV_DATA >= d1
               AND   SAI.MTMD_MOV_DATA <= d2
               ORDER BY SAI.MTMD_MOV_DATA
            ) LOOP
               -- IF ( MES.CAD_MTMD_SUBTP_ID NOT IN (43,44)   ) THEN
                  vMTMD_QTDE_ENTRADA         := 0;
                  vMTMD_QTDE_SAIDA           := 0;
                  vMTMD_VALOR_ENTRADA        := 0;
                  vMTMD_VALOR_SAIDA          := 0;
                  IF ( MES.CAD_MTMD_TPMOV_ID = 1  ) THEN
                     vMTMD_VALOR_ENTRADA := NVL(MES.MTMD_MOV_QTDE,0) * vMTMD_CUSTO_MEDIO;
                     vMTMD_QTDE_ENTRADA  := NVL(MES.MTMD_MOV_QTDE,0);
                     vMTMD_QTDE_SAIDA    := 0;
                     vMTMD_VALOR_SAIDA   := 0;
                     IF (MES.CAD_MTMD_SUBTP_ID != 1 AND
                         vMTMD_QTDE_ENTRADA > 0 AND vMTMD_VALOR_ENTRADA = 0) THEN
                         BEGIN
                           SELECT ESTOQUE.MTMD_CUSTO_MEDIO
                             INTO vMTMD_CUSTO_MEDIO
                             FROM TB_MTMD_ESTOQUE_CONTABIL ESTOQUE
                            WHERE ESTOQUE.CAD_MTMD_ID        = MES.CAD_MTMD_ID
                              AND ESTOQUE.CAD_MTMD_FILIAL_ID = MES.CAD_MTMD_FILIAL_ID;
                         EXCEPTION WHEN NO_DATA_FOUND THEN
                            vMTMD_CUSTO_MEDIO := 0;
                         END;
                         vMTMD_VALOR_ENTRADA := NVL(MES.MTMD_MOV_QTDE,0) * vMTMD_CUSTO_MEDIO;
                     END IF;
                  ELSE
                     vMTMD_VALOR_ENTRADA := 0;
                     vMTMD_QTDE_ENTRADA  := 0;
                     vMTMD_QTDE_SAIDA    := NVL(MES.MTMD_MOV_QTDE,0);
                     vMTMD_VALOR_SAIDA   := NVL(MES.MTMD_MOV_QTDE,0)*vMTMD_CUSTO_MEDIO;
                  END IF;
                  -- NOTAS ENTRADA E ESTORNO NOTAS
                 --  IF ( MES.CAD_MTMD_TPMOV_ID = 1 AND MES.CAD_MTMD_SUBTP_ID = 1  ) THEN
                     --  MOVIMENTO DE ENTRADA EXCLUIDO
                 --    NULL;
                 -- ELSIF ( MES.CAD_MTMD_TPMOV_ID = 2 AND MES.CAD_MTMD_SUBTP_ID = 15 ) THEN
                 --    NULL;
                  -- ELSE
                     GERAMOVIMENTACAO(
                                       TRUNC(MES.MTMD_MOV_DATA),                 -- pMTMD_MOV_DATA
                                       MES.CAD_MTMD_ID,                      -- pCAD_MTMD_ID
                                       MES.CAD_MTMD_FILIAL_ID,                           -- pCAD_MTMD_FILIAL_ID
                                       MES.CAD_LAT_ID_LOCAL_ATENDIMENTO,        -- pCAD_LAT_ID_LOCAL_ATENDIMENTO
                                       MES.CAD_UNI_ID_UNIDADE,                  -- pCAD_UNI_ID_UNIDADE
                                       MES.CAD_SET_ID,                          -- pCAD_SET_ID
                                       -- pMTMD_CUSTO_MEDIO_ANTERIOR
                                       -- pMTMD_SALDO_ANTERIOR
                                       -- pMTMD_VALOR_ANTERIOR
                                       vMTMD_QTDE_ENTRADA,                      -- pMTMD_QTDE_ENTRADA
                                       vMTMD_VALOR_ENTRADA,                     -- pMTMD_VALOR_ENTRADA
                                       vMTMD_QTDE_SAIDA,                        -- pMTMD_QTDE_SAIDA
                                       vMTMD_VALOR_SAIDA,                       -- pMTMD_VALOR_SAIDA
                                       vMTMD_CUSTO_MEDIO,                       -- pMTMD_CUSTO_MEDIO_ATUAL
                                       -- pMTMD_SALDO_ATUAL
                                       -- pMTMD_VALOR_ATUAL
                                       vCAD_MTMD_GRUPO_ID,                      -- pCAD_MTMD_GRUPO_ID
                                       vCAD_MTMD_SUBGRUPO_ID,                   -- pCAD_MTMD_SUBGRUPO_ID
                                       MES.CAD_MTMD_TPMOV_ID,                   -- pCAD_MTMD_TPMOV_ID
                                       MES.CAD_MTMD_SUBTP_ID                    -- pCAD_MTMD_SUBTP_ID
                                    );
                     COMMIT;
                     LinhaZero(
                                        pDataDe,--TO_DATE('01012011','DDMMYYYY'),   -- pMTMD_MOV_DATA
                                        MES.CAD_MTMD_ID,                  -- pCAD_MTMD_ID
                                        MES.CAD_MTMD_FILIAL_ID,           -- pCAD_MTMD_FILIAL_ID
                                        -- pCAD_LAT_ID_LOCAL_ATENDIMENTO
                                        -- pCAD_UNI_ID_UNIDADE
                                        -- pCAD_SET_ID
                                        -- 0,                                 -- pMTMD_CUSTO_MEDIO_ANTERIOR
                                        -- 0,                                 -- pMTMD_SALDO_ANTERIOR
                                        -- 0,                                 -- pMTMD_VALOR_ANTERIOR
                                        vMTMD_QTDE_ENTRADA,                -- pMTMD_QTDE_ENTRADA
                                        vMTMD_VALOR_ENTRADA,               -- pMTMD_VALOR_ENTRADA
                                        vMTMD_QTDE_SAIDA,                  -- pMTMD_QTDE_SAIDA
                                        vMTMD_VALOR_SAIDA,                 -- pMTMD_VALOR_SAIDA
                                        -- pMTMD_CUSTO_MEDIO_ATUAL
                                        -- pMTMD_SALDO_ATUAL
                                        -- pMTMD_VALOR_ATUAL
                                        vCAD_MTMD_GRUPO_ID,               -- pCAD_MTMD_GRUPO_ID
                                        vCAD_MTMD_SUBGRUPO_ID             -- pCAD_MTMD_SUBGRUPO_ID
                                        -- pCAD_MTMD_TPMOV_ID
                                        -- pCAD_MTMD_SUBTP_ID
                                      );
                     COMMIT;
                  -- END IF; -- ENTRADA E EXCLUSAO DE NOTAS
               -- END IF; -- TIPO 43 44
           END LOOP;  -- LOOP MOVIMENTACAO
           COMMIT;
           IF ( TRUNC(d2) = TRUNC(pDataAte) ) THEN
             -- Depois de processar as baixas do produto, verifica se saldo atual n?o ficou negativo
             SELECT SUM(ED.MTMD_SALDO_ATUAL) INTO vMTMD_SALDO_ATUAL
             FROM TB_MTMD_MOV_ESTOQUE_DIA ED
             WHERE MTMD_MOV_DATA                = TRUNC(pDataDe)
             AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
             AND   CAD_MTMD_FILIAL_ID           = CONT.CAD_MTMD_FILIAL_ID
             --AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
             AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
             AND   CAD_UNI_ID_UNIDADE           = 244
             AND   CAD_SET_ID                   = 29
             AND   CAD_MTMD_TPMOV_ID            = 0
             AND   CAD_MTMD_SUBTP_ID            = 0;
             -- Se saldo ficou negativo, retira algumas baixas para zerar
             IF (vMTMD_SALDO_ATUAL < 0) THEN
                vMTMD_SALDO_ATUAL := -vMTMD_SALDO_ATUAL;
                vQTDE_JA_TIRADA := 0;
                FOR BAIXA IN (
                              SELECT * FROM TB_MTMD_MOV_ESTOQUE_DIA ED
                               WHERE MTMD_MOV_DATA >= pDataDe
                               AND   MTMD_MOV_DATA <= pDataAte
                               AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
                               AND   CAD_MTMD_FILIAL_ID           = CONT.CAD_MTMD_FILIAL_ID
                               --AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
                               AND   CAD_MTMD_TPMOV_ID            = 2
                               AND   MTMD_QTDE_SAIDA              > 0
                               ORDER BY ED.MTMD_QTDE_SAIDA DESC            )
                     LOOP
                     IF (vQTDE_JA_TIRADA < vMTMD_SALDO_ATUAL) THEN
                         SELECT ED.MTMD_QTDE_SAIDA INTO vQTDE_TIRAR
                           FROM TB_MTMD_MOV_ESTOQUE_DIA ED
                           WHERE MTMD_MOV_DATA                = BAIXA.MTMD_MOV_DATA
                           AND   CAD_MTMD_ID                  = BAIXA.CAD_MTMD_ID
                           AND   CAD_MTMD_FILIAL_ID           = BAIXA.CAD_MTMD_FILIAL_ID
                           AND   CAD_MTMD_GRUPO_ID            = BAIXA.CAD_MTMD_GRUPO_ID
                           AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = BAIXA.CAD_LAT_ID_LOCAL_ATENDIMENTO
                           AND   CAD_UNI_ID_UNIDADE           = BAIXA.CAD_UNI_ID_UNIDADE
                           AND   CAD_SET_ID                   = BAIXA.CAD_SET_ID
                           AND   CAD_MTMD_TPMOV_ID            = BAIXA.CAD_MTMD_TPMOV_ID
                           AND   CAD_MTMD_SUBTP_ID            = BAIXA.CAD_MTMD_SUBTP_ID;
                         IF ((vQTDE_TIRAR + vQTDE_JA_TIRADA) > vMTMD_SALDO_ATUAL) THEN
                            vQTDE_TIRAR := vMTMD_SALDO_ATUAL - vQTDE_JA_TIRADA;
                         END IF;
                         UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                             MTMD_QTDE_SAIDA          = NVL(MTMD_QTDE_SAIDA,0) - NVL(vQTDE_TIRAR,0),
                             MTMD_VALOR_SAIDA         =  NVL(MTMD_CUSTO_MEDIO_ATUAL,0) * (NVL(MTMD_QTDE_SAIDA,0) - NVL(vQTDE_TIRAR,0))
                           WHERE MTMD_MOV_DATA                = BAIXA.MTMD_MOV_DATA
                           AND   CAD_MTMD_ID                  = BAIXA.CAD_MTMD_ID
                           AND   CAD_MTMD_FILIAL_ID           = BAIXA.CAD_MTMD_FILIAL_ID
                           AND   CAD_MTMD_GRUPO_ID            = BAIXA.CAD_MTMD_GRUPO_ID
                           AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = BAIXA.CAD_LAT_ID_LOCAL_ATENDIMENTO
                           AND   CAD_UNI_ID_UNIDADE           = BAIXA.CAD_UNI_ID_UNIDADE
                           AND   CAD_SET_ID                   = BAIXA.CAD_SET_ID
                           AND   CAD_MTMD_TPMOV_ID            = BAIXA.CAD_MTMD_TPMOV_ID
                           AND   CAD_MTMD_SUBTP_ID            = BAIXA.CAD_MTMD_SUBTP_ID;
                           vQTDE_JA_TIRADA := vQTDE_JA_TIRADA + vQTDE_TIRAR;
                     ELSE
                         exit;
                     END IF;
                 END LOOP;  -- LOOP BAIXAS
                 --Recupera valor para acertar linha zero
                 SELECT NVL(SUM(ED.MTMD_QTDE_ENTRADA),0), NVL(SUM(ED.MTMD_VALOR_ENTRADA),0)
                 INTO vMTMD_QTDE_ENTRADA, vMTMD_VALOR_ENTRADA
                 FROM TB_MTMD_MOV_ESTOQUE_DIA ED
                 WHERE MTMD_MOV_DATA >= pDataDe
                 AND   MTMD_MOV_DATA <= pDataAte
                 AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
                 AND   CAD_MTMD_FILIAL_ID           = CONT.CAD_MTMD_FILIAL_ID
                 --AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
                 AND   CAD_MTMD_TPMOV_ID            = 1;
                 SELECT NVL(SUM(ED.MTMD_QTDE_SAIDA),0), NVL(SUM(ED.MTMD_VALOR_SAIDA),0)
                 INTO vMTMD_QTDE_SAIDA, vMTMD_VALOR_SAIDA
                 FROM TB_MTMD_MOV_ESTOQUE_DIA ED
                 WHERE MTMD_MOV_DATA >= pDataDe
                 AND   MTMD_MOV_DATA <= pDataAte
                 AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
                 AND   CAD_MTMD_FILIAL_ID           = CONT.CAD_MTMD_FILIAL_ID
                 --AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
                 AND   CAD_MTMD_TPMOV_ID            = 2;
                 UPDATE TB_MTMD_MOV_ESTOQUE_DIA T SET
                           MTMD_SALDO_ATUAL = MTMD_SALDO_ANTERIOR + vMTMD_QTDE_ENTRADA - vMTMD_QTDE_SAIDA,
                           MTMD_VALOR_ATUAL = MTMD_VALOR_ANTERIOR + vMTMD_VALOR_ENTRADA - vMTMD_VALOR_SAIDA
                   WHERE MTMD_MOV_DATA                = TRUNC(pDataDe)
                   AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
                   AND   CAD_MTMD_FILIAL_ID           = CONT.CAD_MTMD_FILIAL_ID
                   --AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
                   AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                   AND   CAD_UNI_ID_UNIDADE           = 244
                   AND   CAD_SET_ID                   = 29
                   AND   CAD_MTMD_TPMOV_ID            = 0
                   AND   CAD_MTMD_SUBTP_ID            = 0;
                  BEGIN
                    UPDATE TB_MTMD_MOV_ESTOQUE_DIA T SET
                             MTMD_CUSTO_MEDIO_ATUAL = MTMD_VALOR_ATUAL / MTMD_SALDO_ATUAL
                     WHERE MTMD_MOV_DATA                = TRUNC(pDataDe)
                     AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
                     AND   CAD_MTMD_FILIAL_ID           = CONT.CAD_MTMD_FILIAL_ID
                     --AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0;
                   EXCEPTION
                      WHEN OTHERS THEN
                           UPDATE TB_MTMD_MOV_ESTOQUE_DIA T SET
                                   MTMD_CUSTO_MEDIO_ATUAL = 0
                           WHERE MTMD_MOV_DATA                = TRUNC(pDataDe)
                           AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
                           AND   CAD_MTMD_FILIAL_ID           = CONT.CAD_MTMD_FILIAL_ID
                           --AND   CAD_MTMD_GRUPO_ID            = vCAD_MTMD_GRUPO_ID
                           AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                           AND   CAD_UNI_ID_UNIDADE           = 244
                           AND   CAD_SET_ID                   = 29
                           AND   CAD_MTMD_TPMOV_ID            = 0
                           AND   CAD_MTMD_SUBTP_ID            = 0;
                  END;
                  COMMIT;
             END IF;   -- FIM - AJUSTA SALDO QUANDO MENOR QUE 0
           END IF;
      END IF; -- GRUPO 4
   END IF; -- PASSO
--==================================================================================================
-- FIM PARTE 3
--==================================================================================================
   d1 := d1 + 1;
   d2 := d2 + 1;
   --IF ( d2 >= TO_DATE('01022011 0000','DDMMYYYY HH24MI')  ) THEN
   IF ( d2 >= pDataAte + 1 ) THEN
      EXIT;
   END IF;
END LOOP; -- CONTADOR
--    END;
END LOOP;  -- LOOP SUPERIOR
--QUANDO PROCESSO GERAL, EXECUTAR AJUSTES
IF (pCAD_MTMD_ID IS NULL AND pCAD_MTMD_FILIAL_ID IS NULL) THEN
    BEGIN
        -- PRODUTOS QUE ENTRARAM NO RM E N?O CONSTAM REGISTROS NO RELATORIO (nem na linha 0)
        FOR X IN (SELECT DISTINCT MTMD.CAD_MTMD_ID, TPRD.CODCOLPRD
                  FROM  TMOV@RMDB TMOV,
                        FCFOCOMPL@RMDB FCFOCOMPL,
                        TITMMOV@RMDB TITMMOV,
                        TPRODUTO@RMDB TPRD,
                        TTRBMOV@RMDB TTRBMOV,
                        TTRBMOV@RMDB TTRBMOV_ICMS,
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
                             )
                   AND TMOV.CODCOLIGADA = FCFOCOMPL.CODCOLIGADA(+)
                   AND TMOV.CODCFO = FCFOCOMPL.CODCFO(+)
                   AND TITMMOV.CODCOLIGADA = TPRD.CODCOLPRD
                   AND TITMMOV.IDPRD = TPRD.IDPRD
                   AND TMOV.CODCOLIGADA = TITMMOV.CODCOLIGADA
                   AND TMOV.IDMOV = TITMMOV.IDMOV
                   AND TTRBMOV.CODCOLIGADA(+)  = TITMMOV.CODCOLIGADA
                   AND TTRBMOV.IDMOV(+)        = TITMMOV.IDMOV
                   AND TTRBMOV.NSEQITMMOV(+)   = TITMMOV.NSEQITMMOV
                   AND TTRBMOV.CODTRB(+)       = 'IPI'
                   AND TTRBMOV_ICMS.CODCOLIGADA(+)  = TITMMOV.CODCOLIGADA
                   AND TTRBMOV_ICMS.IDMOV(+)        = TITMMOV.IDMOV
                   AND TTRBMOV_ICMS.NSEQITMMOV(+)   = TITMMOV.NSEQITMMOV
                   AND TTRBMOV_ICMS.CODTRB(+)       = 'ICMS'
                   AND TMOV.DATASAIDA >= TRUNC(pDataDe)  AND TMOV.DATASAIDA <= TRUNC(pDataAte)
                   AND M.CODALFMAT(+)  = SUBSTR(TPRD.CODIGOPRD,1,7)
                   AND TPRD.CODCOLPRD IN (1, 2)
                   AND TRIM(MTMD.CAD_MTMD_CODMNE) = TRIM(TPRD.CODIGOPRD)
                  AND MTMD.CAD_MTMD_ID NOT IN (SELECT T.CAD_MTMD_ID
                                                FROM TB_MTMD_MOV_ESTOQUE_DIA T
                                                WHERE T.MTMD_MOV_DATA >= TRUNC(pDataDe) AND T.MTMD_MOV_DATA <= TRUNC(pDataAte)
                                                  AND T.CAD_MTMD_FILIAL_ID = TPRD.CODCOLPRD AND T.CAD_MTMD_SUBTP_ID = 1
                                                  AND T.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND ROWNUM = 1)
        ) LOOP
            PRC_MTMD_MOV_ESTOQUE_MES_GERA(5,
                                          TRUNC(pDataDe),
                                          TRUNC(pDataAte),
                                          X.CAD_MTMD_ID,
                                          X.CODCOLPRD);
        END LOOP;
        -- DEVOLUC?O FINANCEIRA DE PRODUTOS COM VALOR E SEM SALDO
        FOR X IN (SELECT *
                    FROM TB_MTMD_MOV_ESTOQUE_DIA EST
                   WHERE EST.MTMD_MOV_DATA = TRUNC(pDataDe) AND
                         EST.CAD_MTMD_SUBTP_ID = 0 AND
                         EST.CAD_MTMD_TPMOV_ID = 0 AND
                         NVL(EST.MTMD_SALDO_ATUAL,0) = 0 AND
                         NVL(EST.MTMD_VALOR_ATUAL,0) > 0
             ) LOOP
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
                (X.MTMD_MOV_DATA,                X.CAD_MTMD_ID,                   X.CAD_MTMD_FILIAL_ID,
                 244,                            29,                              33,
                 0,                              0,                               0,
                 0,                              0,
                 0,                              X.MTMD_VALOR_ATUAL,
                 0,                              0,                               0,
                 X.CAD_MTMD_GRUPO_ID,            X.CAD_MTMD_SUBGRUPO_ID,
                 0,                              1,
                 SYSDATE,                        2,                               18);
             EXCEPTION
                WHEN DUP_VAL_ON_INDEX THEN
                   UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET MTMD_VALOR_SAIDA =  NVL(MTMD_VALOR_SAIDA,0) + X.MTMD_VALOR_ATUAL
                   WHERE MTMD_MOV_DATA                = X.MTMD_MOV_DATA
                   AND   CAD_MTMD_ID                  = X.CAD_MTMD_ID
                   AND   CAD_MTMD_FILIAL_ID           = X.CAD_MTMD_FILIAL_ID
                   AND   CAD_MTMD_GRUPO_ID            = X.CAD_MTMD_GRUPO_ID
                   AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                   AND   CAD_UNI_ID_UNIDADE           = 244
                   AND   CAD_SET_ID                   = 29
                   AND   CAD_MTMD_TPMOV_ID            = 2
                   AND   CAD_MTMD_SUBTP_ID            = 18;
                WHEN OTHERS THEN
                   RAISE_APPLICATION_ERROR(-20000,' ERRO INSERINDO '||SQLERRM);
             END;
             UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                   --MTMD_CUSTO_MEDIO_ATUAL   =  0,
                   MTMD_SALDO_ATUAL         =  0,
                   MTMD_VALOR_ATUAL         =  0
               WHERE MTMD_MOV_DATA                = TRUNC(pDataDe)
               AND   CAD_MTMD_ID                  = X.CAD_MTMD_ID
               AND   CAD_MTMD_FILIAL_ID           = X.CAD_MTMD_FILIAL_ID
               AND   CAD_MTMD_GRUPO_ID            = X.CAD_MTMD_GRUPO_ID
               AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
               AND   CAD_UNI_ID_UNIDADE           = 244
               AND   CAD_SET_ID                   = 29
               AND   CAD_MTMD_TPMOV_ID            = 0
               AND   CAD_MTMD_SUBTP_ID            = 0;
         END LOOP;
         --ACERTA SALDO ZERADO COM CENTAVOS NEGATIVOS
         FOR VAL_ATUAL_CENT_NEGATIVO IN (SELECT MTMD.CAD_MTMD_ID,
                                                LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                                                LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                                                LINHA_ZERO.CAD_MTMD_FILIAL_ID,
                                                SUM(
                                                 (CASE
                                                   WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal
                                                   ELSE 0
                                                   END )
                                                ) MTMD_VALOR_SAIDA,
                                                LINHA_ZERO.MTMD_SALDO_ATUAL,
                                                DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO_ATUAL,
                                                LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL
                                          FROM TB_CAD_MTMD_MAT_MED MTMD,
                                               TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                                               (
                                                 SELECT *
                                                 FROM TB_MTMD_MOV_ESTOQUE_DIA
                                                 WHERE MTMD_MOV_DATA                = TRUNC(pDataDe)
                                                 AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                                                 AND   CAD_UNI_ID_UNIDADE           = 244
                                                 AND   CAD_SET_ID                   = 29
                                                 AND   CAD_MTMD_TPMOV_ID            = 0
                                                 AND   CAD_MTMD_SUBTP_ID            = 0
                                               ) LINHA_ZERO,
                                               (
                                                 SELECT *
                                                 FROM TB_MTMD_MOV_ESTOQUE_DIA
                                                 WHERE CAD_MTMD_TPMOV_ID            = 1
                                                 AND   CAD_MTMD_SUBTP_ID            = 1
                                                 AND   MTMD_MOV_DATA >= TRUNC(pDataDe)
                                                 AND   MTMD_MOV_DATA <= TRUNC(pDataAte)
                                               ) NOTAS
                                          WHERE DIAP.MTMD_MOV_DATA >= TRUNC(pDataDe)
                                          AND   DIAP.MTMD_MOV_DATA <= TRUNC(pDataAte)
                                          AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
                                          AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
                                          AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
                                          AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
                                          AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)         = DIAP.CAD_MTMD_SUBGRUPO_ID
                                          AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
                                          AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
                                          AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
                                          AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
                                          AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
                                          AND NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL
                                          and (LINHA_ZERO.MTMD_VALOR_ATUAL > -1000 and LINHA_ZERO.MTMD_VALOR_ATUAL < 0)
                                          and LINHA_ZERO.MTMD_SALDO_ATUAL = 0
                                          and DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL) = 0
                                          GROUP BY MTMD.CAD_MTMD_ID,
                                                   LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                                                   LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                                                   LINHA_ZERO.CAD_MTMD_FILIAL_ID,
                                                   DIAP.CAD_MTMD_FILIAL_ID,
                                                   LINHA_ZERO.MTMD_SALDO_ATUAL,
                                                   LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                                                   LINHA_ZERO.MTMD_VALOR_ATUAL
                                          HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)) > 0
                                          and SUM(
                                                 (CASE
                                                   WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal
                                                   ELSE 0
                                                   END )
                                                ) >= 1
                                                        )
         LOOP
              FOR BAIXA IN (
                          SELECT * FROM TB_MTMD_MOV_ESTOQUE_DIA ED
                           WHERE MTMD_MOV_DATA >= TRUNC(pDataDe)
                           AND   MTMD_MOV_DATA <= TRUNC(pDataAte)
                           AND   CAD_MTMD_ID                  = VAL_ATUAL_CENT_NEGATIVO.CAD_MTMD_ID
                           AND   CAD_MTMD_FILIAL_ID           = VAL_ATUAL_CENT_NEGATIVO.CAD_MTMD_FILIAL_ID
                           AND   CAD_MTMD_TPMOV_ID            = 2
                           AND   MTMD_VALOR_SAIDA              > 0
                           ORDER BY ED.MTMD_VALOR_SAIDA DESC            )
               LOOP
                   UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                           MTMD_VALOR_SAIDA         =  MTMD_VALOR_SAIDA + VAL_ATUAL_CENT_NEGATIVO.MTMD_VALOR_ATUAL
                         WHERE MTMD_MOV_DATA                = BAIXA.MTMD_MOV_DATA
                         AND   CAD_MTMD_ID                  = BAIXA.CAD_MTMD_ID
                         AND   CAD_MTMD_FILIAL_ID           = BAIXA.CAD_MTMD_FILIAL_ID
                         AND   CAD_MTMD_GRUPO_ID            = BAIXA.CAD_MTMD_GRUPO_ID
                         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = BAIXA.CAD_LAT_ID_LOCAL_ATENDIMENTO
                         AND   CAD_UNI_ID_UNIDADE           = BAIXA.CAD_UNI_ID_UNIDADE
                         AND   CAD_SET_ID                   = BAIXA.CAD_SET_ID
                         AND   CAD_MTMD_TPMOV_ID            = BAIXA.CAD_MTMD_TPMOV_ID
                         AND   CAD_MTMD_SUBTP_ID            = BAIXA.CAD_MTMD_SUBTP_ID;
                   UPDATE TB_MTMD_MOV_ESTOQUE_DIA T SET
                            MTMD_VALOR_ATUAL = 0
                           WHERE MTMD_MOV_DATA                = TRUNC(pDataDe)
                           AND   CAD_MTMD_ID                  = VAL_ATUAL_CENT_NEGATIVO.CAD_MTMD_ID
                           AND   CAD_MTMD_FILIAL_ID           = VAL_ATUAL_CENT_NEGATIVO.CAD_MTMD_FILIAL_ID
                           --AND   CAD_MTMD_GRUPO_ID            = VAL_ATUAL_CENT_NEGATIVO.CAD_MTMD_GRUPO_ID
                           AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                           AND   CAD_UNI_ID_UNIDADE           = 244
                           AND   CAD_SET_ID                   = 29
                           AND   CAD_MTMD_TPMOV_ID            = 0
                           AND   CAD_MTMD_SUBTP_ID            = 0;
                   EXIT;
               END LOOP;
         END LOOP;
         --ACERCAR CM ZERADOS SEM SALDO, PARA FICAR CORRETO PARA O PROXIMO FECHAMENTO
         FOR X IN (SELECT *
                    FROM TB_MTMD_MOV_ESTOQUE_DIA EST
                   WHERE EST.MTMD_MOV_DATA = TRUNC(pDataDe) AND
                         EST.CAD_MTMD_SUBTP_ID = 0 AND
                         EST.CAD_MTMD_TPMOV_ID = 0 AND
                         NVL(EST.MTMD_SALDO_ATUAL,0) = 0 AND
                         NVL(EST.MTMD_CUSTO_MEDIO_ATUAL,0) = 0 AND
                         EST.CAD_MTMD_GRUPO_ID NOT IN (0, 61, 4, 14, 58)
             )
         LOOP
          UPDATE TB_MTMD_MOV_ESTOQUE_DIA C
             SET MTMD_CUSTO_MEDIO_ATUAL = FNC_MTMD_PRECO_MEDIO(X.CAD_MTMD_ID, X.CAD_MTMD_FILIAL_ID)
           WHERE CAD_MTMD_ID = X.CAD_MTMD_ID AND
                 CAD_MTMD_FILIAL_ID = X.CAD_MTMD_FILIAL_ID AND
                 MTMD_MOV_DATA = TRUNC(pDataDe) AND
                 CAD_MTMD_SUBTP_ID = 0 AND
                 CAD_MTMD_TPMOV_ID = 0;
         END LOOP;
         --ACERTAR CENTRO CUSTO VAL. SEM QTDE.
         BEGIN
            FOR CONT IN (SELECT EST.CAD_MTMD_GRUPO_ID,
                                 EST.CAD_MTMD_SUBGRUPO_ID,
                                 EST.CAD_MTMD_ID,
                                 EST.MTMD_VALOR_SAIDA,
                                 EST.CAD_UNI_ID_UNIDADE,
                                 EST.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 EST.CAD_SET_ID,
                                 EST.MTMD_MOV_DATA
                            FROM TB_MTMD_MOV_ESTOQUE_DIA EST
                           WHERE EST.MTMD_MOV_DATA = TRUNC(pDataDe) AND
                                 EST.CAD_MTMD_FILIAL_ID = 1 AND
                                 EST.CAD_MTMD_TPMOV_ID = 2 AND
                                 EST.CAD_MTMD_SUBTP_ID = 18 AND
                                 NVL(EST.MTMD_QTDE_SAIDA , 0) = 0 AND
                                 NVL(EST.MTMD_VALOR_SAIDA, 0) > 0
                          ORDER BY 1
            ) LOOP

                  IF (CONT.CAD_MTMD_GRUPO_ID IN (4,11)) THEN
                      CAD_UNI_ID_UNIDADE_MOV           := 244;
                      ID_LOCAL_ATENDIMENTO_MOV         := 33;
                      CAD_SET_ID_MOV                   := 183; --ALMOXARIFADO SND
                  ELSIF (CONT.CAD_MTMD_GRUPO_ID IN (12)) THEN
                      CAD_UNI_ID_UNIDADE_MOV           := 244;
                      ID_LOCAL_ATENDIMENTO_MOV         := 33;
                      CAD_SET_ID_MOV                   := 533; --ALMOXARIFADO HIGIENIZAÇÃO
                  ELSIF (CONT.CAD_MTMD_GRUPO_ID IN (8)) THEN
                      CAD_UNI_ID_UNIDADE_MOV           := 244;
                      ID_LOCAL_ATENDIMENTO_MOV         := 33;
                      CAD_SET_ID_MOV                   := 532; --ALMOXARIFADO MANUTENÇÃO
                  ELSIF ((CONT.CAD_MTMD_GRUPO_ID = 61 AND CONT.CAD_MTMD_SUBGRUPO_ID = 60) OR
                         (CONT.CAD_MTMD_GRUPO_ID = 6  AND CONT.CAD_MTMD_SUBGRUPO_ID = 60) OR
                         (CONT.CAD_MTMD_GRUPO_ID = 6  AND CONT.CAD_MTMD_SUBGRUPO_ID = 65)) THEN
                      CAD_UNI_ID_UNIDADE_MOV           := 244;
                      ID_LOCAL_ATENDIMENTO_MOV         := 29;
                      CAD_SET_ID_MOV                   := 61; --CENTRO CIRURGICO
                  ELSIF (CONT.CAD_MTMD_GRUPO_ID = 6 AND CONT.CAD_MTMD_SUBGRUPO_ID = 63) THEN
                      CAD_UNI_ID_UNIDADE_MOV           := 248;
                      ID_LOCAL_ATENDIMENTO_MOV         := 27;
                      CAD_SET_ID_MOV                   := 113; --HEMODINAMICA
                  ELSIF (CONT.CAD_MTMD_GRUPO_ID = 1 AND CONT.CAD_MTMD_SUBGRUPO_ID = 16) THEN
                      CAD_UNI_ID_UNIDADE_MOV           := 248;
                      ID_LOCAL_ATENDIMENTO_MOV         := 27;
                      CAD_SET_ID_MOV                   := 159; --QUIMIO
                  ELSIF (CONT.CAD_MTMD_GRUPO_ID = 34) THEN
                      CAD_UNI_ID_UNIDADE_MOV           := 244;
                      ID_LOCAL_ATENDIMENTO_MOV         := 33;
                      CAD_SET_ID_MOV                   := 124; --LABORATORIO
                  ELSE
                      CAD_UNI_ID_UNIDADE_MOV           := 244;
                      ID_LOCAL_ATENDIMENTO_MOV         := 33;
                      CAD_SET_ID_MOV                   := 29; --ALMOXARIFADO CENTRAL
                  END IF;

                  UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                       CAD_UNI_ID_UNIDADE           =  CAD_UNI_ID_UNIDADE_MOV,
                       CAD_LAT_ID_LOCAL_ATENDIMENTO =  ID_LOCAL_ATENDIMENTO_MOV,
                       CAD_SET_ID                   =  CAD_SET_ID_MOV,
                       SEG_DT_ATUALIZACAO           =  SYSDATE
                       WHERE MTMD_MOV_DATA          = CONT.MTMD_MOV_DATA
                       AND   CAD_MTMD_ID            = CONT.CAD_MTMD_ID
                       AND   CAD_MTMD_GRUPO_ID      = CONT.CAD_MTMD_GRUPO_ID
                       AND   CAD_SET_ID             = CONT.CAD_SET_ID
                       AND   CAD_MTMD_FILIAL_ID     = 1
                       AND   CAD_MTMD_TPMOV_ID      = 2
                       AND   CAD_MTMD_SUBTP_ID      = 18;
            END LOOP;
         END;
    END;
END IF;
COMMIT;
END  PRC_MTMD_MOV_ESTOQUE_MES_GERA;