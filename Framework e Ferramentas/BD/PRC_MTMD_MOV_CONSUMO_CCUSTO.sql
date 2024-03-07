CREATE OR REPLACE PROCEDURE "PRC_MTMD_MOV_CONSUMO_CCUSTO" (
     pMTMD_ID_TP_CCUSTO            IN TB_MTMD_MOV_CCUSTO.MTMD_ID_TP_CCUSTO%TYPE,
     pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
     pATD_ATE_ID                   IN TB_MTMD_REQ_REQUISICAO.ATD_ATE_ID%type default NULL,
     pATD_ATE_TP_PACIENTE          IN TB_MTMD_REQ_REQUISICAO.ATD_ATE_TP_PACIENTE%type default NULL,
     pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
     pMTMD_ESTLOC_QTDE             IN TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type,     
     pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
     pMTMD_REQ_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_REQ_ID%type  DEFAULT NULL,
     pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type DEFAULT NULL
)
   IS
-- ============================================
-- REALIZA BAIXA NO ESTOQUE ORIGEM (ALMOXARIFADO SATELITE)
-- E DISTRIBUI A DESPESA PARA CENTRO DE CUSTO
-- ============================================
DIST_DESPESA_CCUSTO  CONSTANT NUMBER := 27;
DIST_DESPESA_HCARE   CONSTANT NUMBER := 28;
BAIXA_CONSUMO_CCUSTO CONSTANT NUMBER := 19;
MOVIMENTACAO_BAIXA   CONSTANT NUMBER := 2;
--FILIAL_HAC           CONSTANT NUMBER := 1;
--FILIAL_ACS           CONSTANT NUMBER := 2;
--FRACIONADO           CONSTANT NUMBER := 1;
NAO_FRACIONADO       CONSTANT NUMBER := 0;
pNewIdt                       NUMBER; --  RETORNO ID MOVIMENTACAO
pNewIdtOrigem                 NUMBER;
nQtdeConsumida       TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type;
vCAD_UNI_ID_UNIDADE_ORIGEM  TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vCAD_LAT_ID_LOCAL_ORIGEM    TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vCAD_SET_ID_ORIGEM          TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
vCAD_MTMD_SUBTP_ID          TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type;
vCAD_MTMD_FILIAL_ID         TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type;
BEGIN
  IF ( pMTMD_ESTLOC_QTDE IS NULL OR pMTMD_ESTLOC_QTDE = 0 ) THEN
     nQtdeConsumida := 1;
  ELSE
     nQtdeConsumida := pMTMD_ESTLOC_QTDE;
  END IF;
  IF ( pATD_ATE_TP_PACIENTE = 'H' ) THEN
     vCAD_MTMD_SUBTP_ID  := DIST_DESPESA_HCARE;
  ELSE
     vCAD_MTMD_SUBTP_ID := DIST_DESPESA_CCUSTO;
     -- vCAD_MTMD_FILIAL_ID := NVL(pCAD_MTMD_FILIAL_ID,1);
  END IF;
  -- BUSCA UNIDADE/LOCAL/SETOR DA ORIGEM DA MOVIMENTAC?O
  BEGIN
   SELECT CAD_UNI_ID_UNIDADE,
          CAD_LAT_ID_LOCAL_ATENDIMENTO,
          CAD_SET_ID
    INTO  vCAD_UNI_ID_UNIDADE_ORIGEM,
          vCAD_LAT_ID_LOCAL_ORIGEM,
          vCAD_SET_ID_ORIGEM
    FROM TB_MTMD_MOV_CCUSTO
    WHERE MTMD_ID_TP_CCUSTO = pMTMD_ID_TP_CCUSTO;
  EXCEPTION WHEN NO_DATA_FOUND THEN
     RAISE_APPLICATION_ERROR(-20001,'ORIGEM DA MOVIMENTACAO NAO LOCALIZADA');
  END;
  vCAD_MTMD_FILIAL_ID := FNC_MTMD_RETORNA_FILIAL(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, vCAD_SET_ID_ORIGEM);
  -- GERA MOVIMENTAC?O DE DESPESA PARA CENTRO DE CUSTO
  PRC_MTMD_MOV_MOVIMENTACAO_I (   pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                  pCAD_UNI_ID_UNIDADE,
                                  pCAD_SET_ID,
                                  pMTMD_REQ_ID,
                                  pMTMD_LOTEST_ID,
                                  pCAD_MTMD_ID,
                                  vCAD_MTMD_FILIAL_ID, -- nFilial,
                                  MOVIMENTACAO_BAIXA,
                                  vCAD_MTMD_SUBTP_ID,
                                  SYSDATE,
                                  nQtdeConsumida, -- QTDE CONSUMIDA
                                  1, -- pMTMD_MOV_FL_FINALIZADO
                                  pATD_ATE_ID,
                                  pATD_ATE_TP_PACIENTE,
                                  pSEG_USU_ID_USUARIO,
                                  NULL, -- ID_CONVERSAO
                                  NULL, -- QTDE_CONVERTIDA
                                  NULL, -- DT_FAT
                                  NULL, -- HR_FAT
                                  pNewIdt
                                );
  -- BAIXA PRODUTO NA UNIDADE DE ORIGEM
  PRC_MTMD_MOV_ESTOQUE_BAIXA( pCAD_MTMD_ID,
                              pMTMD_REQ_ID,
                              pMTMD_LOTEST_ID,
                              vCAD_MTMD_FILIAL_ID,
                              vCAD_UNI_ID_UNIDADE_ORIGEM,
                              vCAD_LAT_ID_LOCAL_ORIGEM,
                              vCAD_SET_ID_ORIGEM,
                              nQtdeConsumida,
                              pATD_ATE_ID,
                              pATD_ATE_TP_PACIENTE,
                              MOVIMENTACAO_BAIXA,
                              BAIXA_CONSUMO_CCUSTO,
                              NAO_FRACIONADO,
                              pSEG_USU_ID_USUARIO,
                              NULL, -- DT_FAT
                              NULL, -- HR_FAT
                              pNewIdtOrigem
                             )  ;
   -- ATUALIZA COM ID NA MOVIMENTAC?O DE BAIXA
   BEGIN
      UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
      MTMD_MOV_ID_REF = pNewIdt -- ID DA MOVIMENTAC?O DE CONSUMO CCUSTO
      WHERE MTMD_MOV_ID = pNewIdtOrigem;
   END;
END;