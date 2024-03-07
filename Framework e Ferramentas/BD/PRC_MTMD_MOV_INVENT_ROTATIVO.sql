CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_INVENT_ROTATIVO
(    pCAD_MTMD_ID                  IN TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_ID%type,
     pCAD_MTMD_FILIAL_ID           IN TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID%type,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_ESTOQUE_LOCAL.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_ESTOQUE_LOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID                   IN TB_MTMD_ESTOQUE_LOCAL.CAD_SET_ID%type,
     pMTMD_ESTLOC_QTDE             IN TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type,
     pMTMD_LOTEST_ID               IN TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_LOTEST_ID%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL
)
IS
 /***********************************************************************************************
*    Procedure: PRC_MTMD_MOV_ESTOQUE_ACERTO
*
*    Data Criacao:    08/2022         Por: Andre Monaco
*
*    Funcao:   REALIZA O ACERTO DO ESTOQUE DE ACORDO COM A NOVA QTD.
*************************************************************************************************/
nQtdeEstLocAntiga   NUMBER;
nQtdeEstContabil    NUMBER;
nFilial             NUMBER;
pNewIdt             integer;
nDiferencaAcerto    NUMBER;
vPERCENTUAL         NUMBER;
vCAD_MTMD_TPMOV_ID  TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%type;
vCAD_MTMD_SUBTP_ID  TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type;
nQtdeMovimento      NUMBER;
vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
TIPO_MOV_ENTRADA         CONSTANT NUMBER := 1;
TIPO_MOV_BAIXA           CONSTANT NUMBER := 2;
-- SUB_MOV_ENTRADA_ACERTO   CONSTANT NUMBER := 31;
-- SUB_MOV_BAIXA_ACERTO     CONSTANT NUMBER := 30;
NAO                      CONSTANT NUMBER := 0;
BEGIN
   nFilial := pCAD_MTMD_FILIAL_ID;

   PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE,
                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                pCAD_SET_ID,
                                pCAD_MTMD_FILIAL_ID,
                                vUNIDADE_ESTOQUE_CONSUMO,
                                vLOCAL_ESTOQUE_CONSUMO,
                                vSETOR_ESTOQUE_CONSUMO );
  BEGIN
      -- BUSCA ESTOQUE LOCAL
      IF (NVL(pMTMD_LOTEST_ID,0) = 0) THEN
        nQtdeEstLocAntiga := NVL(FNC_MTMD_ESTOQUE_UNIDADE (pCAD_MTMD_ID,
                                                           vUNIDADE_ESTOQUE_CONSUMO,
                                                           vLOCAL_ESTOQUE_CONSUMO,
                                                           vSETOR_ESTOQUE_CONSUMO,
                                                           nFilial,
                                                           NULL),0);
      ELSE
        nQtdeEstLocAntiga := NVL(FNC_MTMD_ESTOQUE_LOTE_SETOR(pCAD_MTMD_ID,
                                                             vUNIDADE_ESTOQUE_CONSUMO,
                                                             vLOCAL_ESTOQUE_CONSUMO,
                                                             vSETOR_ESTOQUE_CONSUMO,
                                                             nFilial,
                                                             pMTMD_LOTEST_ID,
                                                             NULL, --vMTMD_COD_LOTE
                                                             1),0);
      END IF;
      -- CALCULA DIFERENÇA DO ACERTO PARA AJUSTAR CONSUMO DO PRODUTO
      nDiferencaAcerto := nQtdeEstLocAntiga - pMTMD_ESTLOC_QTDE;
      IF ( nDiferencaAcerto < 0 ) THEN
         nQtdeMovimento := nDiferencaAcerto*-1; -- PRA PREVENIR NUMEROS NEGATIVOS
      ELSE
         nQtdeMovimento := nDiferencaAcerto;
      END IF;
      -- VERIFICA QUAL O TIPO DE MOVIMENTO
      -- SE QTDE EXISTENTE FOR MENOR QUE QUANTIDADE ENVIADA É ACERTO DE ENTRADA
      IF ( nQtdeEstLocAntiga < pMTMD_ESTLOC_QTDE ) THEN
         -- ESTA DANDO ENTRADA NO ESTOQUE
         vCAD_MTMD_TPMOV_ID := TIPO_MOV_ENTRADA;
         vCAD_MTMD_SUBTP_ID := 44; -- MOV ENTRADA INVENTARIO
         PRC_MTMD_MOV_ENTRADA_UNIDADE( pCAD_MTMD_ID,
                                       pMTMD_LOTEST_ID,
                                       nFilial,
                                       NULL, -- pMTMD_REQ_ID,
                                       pCAD_UNI_ID_UNIDADE,
                                       pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                       pCAD_SET_ID,
                                       vCAD_MTMD_TPMOV_ID,
                                       vCAD_MTMD_SUBTP_ID,
                                       nQtdeMovimento,
                                       NULL, --pATD_ATE_ID,
                                       NULL, -- pATD_ATE_TP_PACIENTE,
                                       1, --pMTMD_MOV_FL_FINALIZADO,
                                       pSEG_USU_ID_USUARIO,
                                       NULL, -- pMTMD_ID_ORIGINAL,
                                       pNewIdt);
      ELSIF ( nQtdeEstLocAntiga > pMTMD_ESTLOC_QTDE ) THEN
         -- ESTA DANDO BAIXA NO ESTOQUE
         vCAD_MTMD_TPMOV_ID := TIPO_MOV_BAIXA;
         vCAD_MTMD_SUBTP_ID := 43; -- MOV BAIXA INVENTARIO
         PRC_MTMD_MOV_ESTOQUE_BAIXA( pCAD_MTMD_ID,
                                     NULL, -- pMTMD_REQ_ID
                                     pMTMD_LOTEST_ID,
                                     nFilial,
                                     pCAD_UNI_ID_UNIDADE,
                                     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                     pCAD_SET_ID,
                                     nQtdeMovimento,
                                     NULL,-- pATD_ATE_ID
                                     NULL,-- pATD_ATE_TP_PACIENTE
                                     vCAD_MTMD_TPMOV_ID,
                                     vCAD_MTMD_SUBTP_ID,
                                     NAO, --pCAD_MTMD_FL_FRACIONA
                                     pSEG_USU_ID_USUARIO,
                                     NULL,
                                     NULL,
                                     pNewIdt);
      END IF;
   END;
   -- ATUALIZA PERCENTUAL DE CONSUMO
   PRC_MTMD_ESTOQUE_PER_CONSUMO_U(  pCAD_MTMD_ID,
                                    nFilial,
                                    vUNIDADE_ESTOQUE_CONSUMO,
                                    vLOCAL_ESTOQUE_CONSUMO,
                                    vSETOR_ESTOQUE_CONSUMO,
                                    vPERCENTUAL);
   -- ATUALIZA ESTOQUE CONTÁBIL
   BEGIN
      -- PEGA A SOMA DE TODOS OS ESTOQUES LOCAIS PARA ACERTAR O ESTOQUE CONTÁBIL
      IF ( nFilial IN(1,4) ) THEN
         SELECT NVL(SUM(MTMD_ESTLOC_QTDE),0)+ NVL(SUM(MTMD_ESTLOC_QTDE_FRACIONADA),0)
         INTO nQtdeEstContabil
         FROM TB_MTMD_ESTOQUE_LOCAL ESTLOC
         WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
         AND   CAD_MTMD_FILIAL_ID           IN (1,4);
      ELSE
         SELECT NVL(SUM(MTMD_ESTLOC_QTDE),0)+ NVL(SUM(MTMD_ESTLOC_QTDE_FRACIONADA),0)
         INTO nQtdeEstContabil
         FROM TB_MTMD_ESTOQUE_LOCAL ESTLOC
         WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
         AND   CAD_MTMD_FILIAL_ID           = nFilial;
      END IF;
   END;
   BEGIN
       -- NÃO EXISTE ESTOQUE CONTABIL PARA CARRINHO DE EMERGENCIA
       INSERT INTO TB_MTMD_ESTOQUE_CONTABIL
         (CAD_MTMD_ID, CAD_MTMD_FILIAL_ID,                     MTMD_ESTCON_DT_ATUALIZACAO, MTMD_ESTCON_QTDE, MTMD_CUSTO_MEDIO)
         VALUES
         (pCAD_MTMD_ID, DECODE(nFilial,4,1,nFilial),           SYSDATE,                    pMTMD_ESTLOC_QTDE, 0);
   EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
          UPDATE TB_MTMD_ESTOQUE_CONTABIL SET
          MTMD_ESTCON_QTDE           = nQtdeEstContabil,
          MTMD_ESTCON_DT_ATUALIZACAO = SYSDATE
          WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
          AND   CAD_MTMD_FILIAL_ID = DECODE(nFilial,4,1,nFilial);
   END;
--COMMIT;
END PRC_MTMD_MOV_INVENT_ROTATIVO;