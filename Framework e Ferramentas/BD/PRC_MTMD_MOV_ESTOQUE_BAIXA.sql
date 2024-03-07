CREATE OR REPLACE PROCEDURE "PRC_MTMD_MOV_ESTOQUE_BAIXA"
(    pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
     pMTMD_REQ_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_REQ_ID%type DEFAULT NULL,
     pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type DEFAULT NULL,
     pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
     pMTMD_ESTLOC_QTDE             IN TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type,
     pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type default NULL,
     pATD_ATE_TP_PACIENTE          IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_TP_PACIENTE%type default NULL,
     pCAD_MTMD_TPMOV_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%type,
     pCAD_MTMD_SUBTP_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type,
     pCAD_MTMD_FL_FRACIONA         IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FRACIONA%TYPE DEFAULT NULL,
     pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
     pMTMD_MOV_DATA_FATURAMENTO    IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA_FATURAMENTO%type  DEFAULT NULL,
     pMTMD_MOV_HORA_FATURAMENTO    IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_HORA_FATURAMENTO%type  DEFAULT NULL,
     pNewIdt OUT integer
)
IS
 /***********************************************************************************************
*    Procedure: PRC_MTMD_MOV_ESTOQUE_BAIXA
*
*    Data Criacao:  06/2009         Por: Ricardo Costa
*    Data Alteracao: 13/01/2010      Por: rICARDO cOSTA
*         Descric?o: Busca estoque de consumo
*    Data Alteracao: 14/01/2010      Por: rICARDO cOSTA
*         Descric?o: TIREI TESTE DE MOVIMENTAC?O N?O FATURADA PARA TESTAR CONSUMO DE ESTOQUE
*    Data Alteracao: 15/01/2010      Por: rICARDO cOSTA
*         Descric?o: DATA E HORA FATURAMENTO
*    Data Alteracao: 16/01/2010      Por: rICARDO cOSTA
*         Descric?o: Ajuste da funcionalidade FNC_MTMD_VERIFICA_ESTOQUE
                     para verificar tipo de movimento NAO_FATURADO
*    Data Alteracao: 15/03/2010      Por: RICARDO cOSTA
*         Descric?o: Ajuste para teste em paralelo novo faturamento
*                    codigos de erros tratados no servico
*    Data Alteracao: 07/04/2010      Por: ANDRE SOUZA MONACO
*         Descric?o: N?o deixa faturar quando e ambulatorio
*    Data Alteracao: 19/04/2010      Por: RICARDO COSTA
*         Descric?o: Adiciona atualizac?o data ultimo consumo,
                     Acertado Estoque contabil para carrinho de emergencia
*    Data Alteracao: 09/06/2010      Por: RICARDO COSTA
*         Descric?o: Alterac?o para movimentar produtos reutilizaveis
*                    Uso das constantes direto da PKG para centralizar o codigo
*    Data Alteracao: 23/08/2010      Por: RICARDO COSTA
*         Descric?o: ATUALIZADO MIGRA2
*    Data Alteracao: 14/10/2010      Por: Andre S. Monaco
*         Descric?o: Adic?o da func?o FNC_MTMD_MOV_DATA e sua chamada ao inserir a movimentac?o (regra de obito)
*    Data Alteracao: 21/11/2010      Por: RICARDO COSTA
*         Descric?o: REMOVIDA a func?o FNC_MTMD_MOV_DATA e sua chamada ao inserir a movimentac?o (regra de obito)
                     A DATA DA MOVIMENTAC?O N?O TEM NADA A VER COM FATURAMENTO E NUNCE DEVE SER ALTERADA
*    Data Alteracao: 21/03/2011      Por: Andre Souza Monaco
*         Descric?o: Desativac?o do interface com o legado
*    Data Alteracao: 23/09/2014      Por: Andre Souza Monaco
*         Descric?o: vMTMD_TP_FRACAO_ID sempre sera NULL quando setor for ATENDIMENTO DOMICILIAR
*    Data Alteracao: 16/10/2015      Por: Andre Souza Monaco
*         Descric?o: Atualizar qtd. fornecida quando tiver pMTMD_REQ_ID e for Kit
*    Data Alteracao: 16/05/2016      Por: Andre Souza Monaco
*         Descric?o: Atualizar qtd. fornecida quando tiver pMTMD_REQ_ID e for com prescricao quando for UTI GERAL/CARDIO
*    Data Alteracao: 07/06/2016      Por: Andre Souza Monaco
*         Descric?o: Atualizar qtd. fornecida do pedido quando tiver pMTMD_REQ_ID e for UTI GERAL/CARDIO
*    Data Alteracao: 07/11/2017      Por: Andre Souza Monaco
*         Descric?o: Atualizar qtd. fornecida (subtraindo) do pedido quando tiver pMTMD_REQ_ID
*                    e for movimento de BAIXA TRANSF. OU PERDA (no caso isso sera identificado como a devolucao do item)
*
*    Funcao: MOVIMENTO DE BAIXA EM ESTOQUE
             REALIZA A BAIXA DEFINITIVA DO ESTOQUE APOS CONSUMO DO PRODUTO OU SE FOR BAIXA AUTOMATICA
             APOS DISPENSAC?O
             CHAMADA: DE PRC_MTMD_MOV_ESTOQUE_TRANSF E TELA DE CONSUMO
*************************************************************************************************/
/* CODIGOS DE ERRO RAISE */
/*NAO_EXISTE_ESTOQUE      CONSTANT NUMBER := -20001;
NAO_EXISTE_ESTOQUE_FRAC CONSTANT NUMBER := -20003;
NAO_EXISTE_FRACIONADO   CONSTANT NUMBER := -20004;
RAISE_GENERICO          CONSTANT NUMBER := -20000;*/
/* FIM CODIGOS DE ERRO RAISE */
nFracionado       TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FRACIONA%TYPE;
nBaixaAutomatica  TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_BAIXA_AUTOMATICA%TYPE;
nQtdeConsumida    NUMBER;
nQtdeEstLoc       NUMBER;
nQtdePedida       NUMBER;
nQtdePedidaGravar NUMBER;
nQtdeFornecida    NUMBER;
-- nQtdeEstLocFracionada NUMBER; (N?o estamos mais controlando a Qtd. Fracionada)
vCAD_MTMD_TPMOV_ID TB_CAD_MTMD_SUBTP_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%TYPE;
vCAD_MTMD_SUBTP_ID TB_CAD_MTMD_SUBTP_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%TYPE;
--bFaturado          TB_CAD_MTMD_SUBTP_MOVIMENTACAO.CAD_MTMD_FL_FATURA%TYPE;
nTabelaMedica      TB_CAD_MTMD_MAT_MED.TIS_MED_CD_TABELAMEDICA%TYPE;
--pNewIdtMovFatura   integer;
bMovimentaEstoque  BOOLEAN;
nFilial            NUMBER;
vPERCENTUAL        NUMBER;
nUnidVenda         TB_CAD_MTMD_MAT_MED.CAD_MTMD_UNIDADE_VENDA%TYPE;
nFaturado          TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FATURADO%TYPE;
bInteiroFracionado BOOLEAN;
vMTMD_TP_FRACAO_ID TB_MTMD_MOV_MOVIMENTACAO.MTMD_TP_FRACAO_ID%TYPE;
vQtdeConvertida    NUMBER;
vnAux              NUMBER;
nReutilizavel      TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_reutilizavel%TYPE;
-- VARIAVEIS PARA UNIDADES
vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
--vCAD_MTMD_KIT_ID           TB_MTMD_REQ_REQUISICAO.CAD_MTMD_KIT_ID%type;
vSETOR_FARMACIA            TB_MTMD_REQ_REQUISICAO.CAD_SET_SETOR_FARMACIA%TYPE;
vMTMD_REQ_FL_STATUS        TB_MTMD_REQ_REQUISICAO.MTMD_REQ_FL_STATUS%type;
vCAD_MTMD_PRESCRICAO_ID    TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_PRESCRICAO_ID%TYPE;
vCAD_MTMD_ID_PRESCRICAO    TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%TYPE := pCAD_MTMD_ID;
vCAD_MTMD_ID_ORIGINAL      TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%TYPE := pCAD_MTMD_ID;
vCAD_MTMD_PRIATI_ID        TB_CAD_MTMD_MAT_MED.CAD_MTMD_PRIATI_ID%TYPE;
SIM                             CONSTANT NUMBER := 1;
NAO                             CONSTANT NUMBER := 0;
BAIXA_TRANSFERENCIA_PAC         CONSTANT NUMBER := 59;
BAIXA_CONS_DISP_AUTO_PACIENTE   CONSTANT NUMBER := 60;
BAIXA_DEVOLUCAO_CONSIGNADO      CONSTANT NUMBER := 70;
BAIXA_EMPRESTIMO_CONCEDIDO      CONSTANT NUMBER := 64;
BAIXA_EMPRESTIMO_DEVOLVIDO      CONSTANT NUMBER := 65;
BAIXA_INVENTARIO                CONSTANT NUMBER := 43;
----------------------------------------------------------------------------------------------------
-- VERIFICA SE TIPO DE MOVIMENTO PERMITE FRACIONAMENTO
----------------------------------------------------------------------------------------------------
FUNCTION FNC_MTMD_MOV_PERMITE_FRACAO( ppCAD_MTMD_SUBTP_ID  IN NUMBER  ) RETURN NUMBER IS
   retorna NUMBER;
BEGIN
   retorna := 1; -- POR PADRAO PERMITE
   -- TIPOS QUE NAO PERMITEM FRACIONAMENTO
   IF  ppCAD_MTMD_SUBTP_ID IN ( PKG_MTMD_CONSTANTES.MOV_BXA_TRANSFERENCIA,
                                PKG_MTMD_CONSTANTES.BAIXA_ACERTO,
                                PKG_MTMD_CONSTANTES.BAIXA_PERDA_QUEBRA,
                                PKG_MTMD_CONSTANTES.BAIXA_NAO_FATURADO,
                                PKG_MTMD_CONSTANTES.BAIXA_CAR_EMERGENCIA_N_FAT,
                                PKG_MTMD_CONSTANTES.BAIXA_CENTRO_CUSTO,
                                BAIXA_TRANSFERENCIA_PAC,
                                BAIXA_EMPRESTIMO_CONCEDIDO,
                                BAIXA_EMPRESTIMO_DEVOLVIDO,
                                BAIXA_CONS_DISP_AUTO_PACIENTE,
                                BAIXA_INVENTARIO, 
                                BAIXA_DEVOLUCAO_CONSIGNADO) THEN
      retorna := 0;
   END IF;
   RETURN retorna;
END FNC_MTMD_MOV_PERMITE_FRACAO;
----------------------------------------------------------------------------------------------------
-- VERIFICA SE SETOR GERA RESERVA DE CONSUMO, ( N?O FAZ MOVIMENTAC?O FATURADA, SOMENTE BAIXA ESTOQUE )
----------------------------------------------------------------------------------------------------
FUNCTION FNC_MTMD_SETOR_RESERVA_CONSUMO( ppCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
                                         ppCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
                                         ppCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type ) RETURN NUMBER IS
   retorna NUMBER;
BEGIN
   -- N O MOMENTO SO C. CIRURGICO TRABALHA DESTA FORMA, ESTOU CENTRALIZANDO PARA GARANTIR NO FUTURO
   -- SE EXISTIREM MAIS SETORES ISSO DEVE VIRAR PARAMETRO DA TABELA DE CONFIGURAC?O DE SETORES
   retorna := 0;
   IF (  ppCAD_SET_ID IN (61)  ) THEN
      retorna := 1;
   END IF;
   RETURN retorna;
END FNC_MTMD_SETOR_RESERVA_CONSUMO;
----------------------------------------------------------------------------------------------------
-- VERIFICA SE TIPO DE MOVIMENTO ALTERA ESTOQUE CONTABIL
----------------------------------------------------------------------------------------------------
FUNCTION FNC_GERA_MOV_CONTABIL( pppCAD_MTMD_SUBTP_ID IN NUMBER) RETURN NUMBER IS
     nCAD_MTMD_FL_CONSUMO  NUMBER;
BEGIN
   SELECT SUBTP.CAD_MTMD_FL_CONSUMO
   INTO nCAD_MTMD_FL_CONSUMO
   FROM TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBTP
   WHERE SUBTP.CAD_MTMD_SUBTP_ID = pppCAD_MTMD_SUBTP_ID;
   RETURN nCAD_MTMD_FL_CONSUMO;
END FNC_GERA_MOV_CONTABIL;
----------------------------------------------------------------------------------------------------
-- VERIFICA SE TIPO DE MOVIMENTO E FATURADO
----------------------------------------------------------------------------------------------------
FUNCTION FNC_MTMD_MOV_COBRA_PRODUTO( ppCAD_MTMD_SUBTP_ID  IN NUMBER) RETURN NUMBER IS
   Faturado NUMBER;
BEGIN
   SELECT SUBTP.CAD_MTMD_FL_FATURA
   INTO Faturado
   FROM TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBTP
   WHERE SUBTP.CAD_MTMD_SUBTP_ID = ppCAD_MTMD_SUBTP_ID;
   RETURN Faturado;
END FNC_MTMD_MOV_COBRA_PRODUTO;
----------------------------------------------------------------------------------------------------
-- VEIRIFICA SE EXISTE ESTOQUE PARA CONSUMO
----------------------------------------------------------------------------------------------------
FUNCTION FNC_MTMD_VERIFICA_ESTOQUE( p_CAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
                                    p_CAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
                                    p_CAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
                                    p_CAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
                                    p_CAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
                                    p_MTMD_ESTLOC_QTDE             IN NUMBER, -- TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type,
                                    p_CAD_MTMD_FL_FRACIONA         IN NUMBER, -- TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FRACIONA%TYPE,
                                    p_UnidVenda                    IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_UNIDADE_VENDA%TYPE ) RETURN NUMBER IS
     nQtdeEstLoc NUMBER;
     retorno NUMBER;
BEGIN
   nQtdeEstLoc :=  NVL(FNC_MTMD_ESTOQUE_UNIDADE (p_CAD_MTMD_ID,
                                                 p_CAD_UNI_ID_UNIDADE,
                                                 p_CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                 p_CAD_SET_ID,
                                                 p_CAD_MTMD_FILIAL_ID,
                                                 NULL),0);
   IF ( ((p_MTMD_ESTLOC_QTDE < p_UnidVenda) AND p_CAD_MTMD_FL_FRACIONA = SIM ) AND nQtdeEstLoc >= 1 AND (vCAD_MTMD_SUBTP_ID NOT IN (PKG_MTMD_CONSTANTES.BAIXA_NAO_FATURADO) )  ) THEN
      -- SE FOR FRACIONADO E A QUANTIDADE CONSUMIDA MENOR QUE UNIDADE DE VENDA, E EXISTE MAIS QUE UMA UNIDADE EM ESTOQUE
      retorno := SIM;
   -- VERIFICA ESTOQUE DE INTEIRO N?O FATURADO
   ELSIF (((p_MTMD_ESTLOC_QTDE >= p_UnidVenda) AND p_CAD_MTMD_FL_FRACIONA = SIM ) AND nQtdeEstLoc >= (p_MTMD_ESTLOC_QTDE/p_UnidVenda) AND (vCAD_MTMD_SUBTP_ID NOT IN (PKG_MTMD_CONSTANTES.BAIXA_NAO_FATURADO) )  ) THEN
      -- SE FOR CONVERTER FRACIONADO PARA INTEIRO, VERIFICAR QTD. SUFICIENTE EM ESTOQUE
      retorno := SIM;
   ELSIF( (p_MTMD_ESTLOC_QTDE <= nQtdeEstLoc) AND (vCAD_MTMD_SUBTP_ID IN ( PKG_MTMD_CONSTANTES.BAIXA_NAO_FATURADO) )  ) THEN
      retorno := SIM;
   -- VERIFICA ESTOQUE DE CONSUMO INTEIRO
   ELSIF( (p_MTMD_ESTLOC_QTDE <= nQtdeEstLoc) AND p_CAD_MTMD_FL_FRACIONA = NAO ) THEN
      -- NAO E FRACIONADO E QTDE COSNUMIDA MENOR QUE QTDE EM ESTOQUE
      retorno := SIM;
   ELSE
      -- DO RESTO NAO DEIXA BAIXAR DO ESTOQUE
      retorno := NAO;
   END IF;
   RETURN  retorno;
END FNC_MTMD_VERIFICA_ESTOQUE;
---------------------------------------------------------------------------------------------------
-- VERIFICA QTDE PARA INTEIRO FRACIONADO
-- JA DA BAIXA NA PARTE FRACIONADA E SO RETORNA A PARTE "INTEIRA" DO CONSUMO
---------------------------------------------------------------------------------------------------
PROCEDURE PRC_VERIFICA_QTDE( nUnidade       IN     NUMBER,
                             nLocal         IN     NUMBER,
                             nSetor         IN     NUMBER,
                             nUnidVenda     IN     NUMBER,
                             nQtdeConsumida IN OUT NUMBER,
                             nFracionado    IN OUT NUMBER) IS
  nInteiro NUMBER;
  nFracao  NUMBER;
  vNewIdt  NUMBER;
BEGIN
   -- SE CONSUMO MENOR QUE UNIDADE DE VENDA NAO FAZ NADA
   IF ( nQtdeConsumida >=  nUnidVenda ) THEN
      nInteiro := TRUNC(nQtdeConsumida / nUnidVenda );
      nFracao  := nQtdeConsumida - (TRUNC(nQtdeConsumida / nUnidVenda )*nUnidVenda);
      -- VERIFICA ESTOQUE PARA QTDE INTEIRA
      IF FNC_MTMD_VERIFICA_ESTOQUE( pCAD_MTMD_ID,
                                    nFilial,
                                    nUnidade,
                                    nLocal,
                                    nSetor,
                                    nInteiro,
                                    NAO, -- nFracionado,
                                    nUnidVenda ) = NAO THEN
         RAISE_APPLICATION_ERROR( -20001,'NAO EXISTE ESTOQUE PARA REALIZAR ESTA BAIXA, QTDE: '||TO_CHAR(nInteiro)||'  FRACAO: '||TO_CHAR(nFracao) );
      END IF;
      -- SE EXISTE FRACAO, GERA MOVIMENTO
      IF ( nFracao > 0 ) THEN
         -- CHAMA PROCEDURE DE BAIXA PARA UNIDADE QUE ESTA CONSUMINDO, N?O PARA UNIDADE DO ESTOQUE DE CONSUMO
         PRC_MTMD_MOV_ESTOQUE_BAIXA ( pCAD_MTMD_ID ,
                                      pMTMD_REQ_ID,
                                      pMTMD_LOTEST_ID,
                                      nFilial,
                                      pCAD_UNI_ID_UNIDADE,
                                      pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                      pCAD_SET_ID,
                                      nFracao,
                                      pATD_ATE_ID,
                                      pATD_ATE_TP_PACIENTE,
                                      pCAD_MTMD_TPMOV_ID,
                                      pCAD_MTMD_SUBTP_ID,
                                      SIM, -- FORCA FRACIONAMENTO (pCAD_MTMD_FL_FRACIONA),
                                      pSEG_USU_ID_USUARIO,
                                      pMTMD_MOV_DATA_FATURAMENTO,
                                      pMTMD_MOV_HORA_FATURAMENTO,
                                      vNewIdt );
      END IF;
      nQtdeConsumida := nInteiro;
      nFracionado    := NAO; -- CONVERTE PARA INTEIRO
   END IF;
END PRC_VERIFICA_QTDE;
----------------------------------------------------------------------------------------------------
-- CRIA FRACIONAMENTO DE INTEIRO NO ESTOQUE LOCAL
----------------------------------------------------------------------------------------------------
PROCEDURE PRC_MTMD_FRACIONA_INTEIRO( ppCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
                                     ppCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
                                     ppCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
                                     ppCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
                                     ppCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
                                     ppUnidVenda                    IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_UNIDADE_VENDA%TYPE )
IS
   vMTMD_ESTLOC_QTDE_FRACIONADA TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE_FRACIONADA%TYPE;
   vNewIdt  NUMBER;
BEGIN
   -- VERIFICA SE JA EXISTE PRODUTO FRACIONADO NO ESTOQUE DE CONSUMO
   vMTMD_ESTLOC_QTDE_FRACIONADA := FNC_MTMD_ESTOQUE_FRACIONADO( 0,
                                                                ppCAD_MTMD_ID,
                                                                ppCAD_MTMD_FILIAL_ID,
                                                                ppCAD_UNI_ID_UNIDADE,
                                                                ppCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                ppCAD_SET_ID );
   -- VERIFICA ESTOQUE PARA INTEIRO  NO ESTOQUE DE CONSUMO
   IF ( (FNC_MTMD_VERIFICA_ESTOQUE( ppCAD_MTMD_ID,
                                   ppCAD_MTMD_FILIAL_ID,
                                   ppCAD_UNI_ID_UNIDADE,
                                   ppCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                   ppCAD_SET_ID,
                                   1, -- QTDE
                                   NAO, -- ppCAD_MTMD_FL_FRACIONA
                                   ppUnidVenda ) + vMTMD_ESTLOC_QTDE_FRACIONADA) = NAO ) THEN
      RAISE_APPLICATION_ERROR( -20003,'NAO EXISTE ESTOQUE PARA FRACIONAR ESTE PRODUTO');
      -- RAISE_APPLICATION_ERROR( -20000,'N?O EXISTE ESTOQUE PARA FRACIONAR ESTE PRODUTO');
   END IF;
   IF ( vMTMD_ESTLOC_QTDE_FRACIONADA = 0  ) THEN
      -- N?O EXISTE ITEM FRACIONADO, FRACIONA DO ESTOQUE DE CONSUMO
      UPDATE TB_MTMD_ESTOQUE_LOCAL SET
      MTMD_ESTLOC_QTDE_FRACIONADA = NVL(MTMD_ESTLOC_QTDE_FRACIONADA,0)+1
      WHERE  CAD_MTMD_ID                  = ppCAD_MTMD_ID
      AND    CAD_MTMD_FILIAL_ID           = ppCAD_MTMD_FILIAL_ID
      AND    CAD_UNI_ID_UNIDADE           = ppCAD_UNI_ID_UNIDADE
      AND    CAD_LAT_ID_LOCAL_ATENDIMENTO = ppCAD_LAT_ID_LOCAL_ATENDIMENTO
      AND    CAD_SET_ID                   = ppCAD_SET_ID;
      -- GERA MOVIMENTAC?O DE CONVERS?O PARA UNIDADE QUE ESTA CONSUMINDO
      PRC_MTMD_MOV_MOVIMENTACAO_I (   pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                      pCAD_UNI_ID_UNIDADE,
                                      pCAD_SET_ID,
                                      NULL, -- pMTMD_REQ_ID,
                                      NULL, -- pMTMD_LOTEST_ID,
                                      ppCAD_MTMD_ID,
                                      ppCAD_MTMD_FILIAL_ID,
                                      PKG_MTMD_CONSTANTES.TIPO_MOVIMENTO_SAIDA,
                                      PKG_MTMD_CONSTANTES.CONVERSAO_INTEIRO_FRACIONADO, -- vCAD_MTMD_SUBTP_ID,
                                      SYSDATE,
                                      0, -- QTDE CONSUMIDA
                                      SIM, -- pMTMD_MOV_FL_FINALIZADO
                                      NULL, -- pATD_ATE_ID,
                                      NULL, -- pATD_ATE_TP_PACIENTE,
                                      pSEG_USU_ID_USUARIO,
                                      vMTMD_TP_FRACAO_ID,
                                      NULL,
                                      pMTMD_MOV_DATA_FATURAMENTO,
                                      pMTMD_MOV_HORA_FATURAMENTO,
                                      vNewIdt
                                   );
   END IF;
END PRC_MTMD_FRACIONA_INTEIRO;
----------------------------------------------------------------------------------------------------
-- BAIXA PRODUTO INTEIRO COMO FRACIONADO
----------------------------------------------------------------------------------------------------
PROCEDURE PRC_MTMD_BAIXA_INTEIRO_FRAC(ppCAD_MTMD_ID                 IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
                                     ppCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
                                     ppCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
                                     ppCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
                                     ppCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
                                     ppUnidVenda                    IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_UNIDADE_VENDA%TYPE DEFAULT NULL)
IS
   vMTMD_ESTLOC_QTDE_FRACIONADA TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE_FRACIONADA%TYPE;
   --vNewIdt  NUMBER;
BEGIN
      -- VERIFICA SE JA EXISTE PRODUTO FRACIONADO NO ESTOQUE DE CONSUMO
   vMTMD_ESTLOC_QTDE_FRACIONADA := FNC_MTMD_ESTOQUE_FRACIONADO( 0,
                                                                ppCAD_MTMD_ID,
                                                                ppCAD_MTMD_FILIAL_ID,
                                                                ppCAD_UNI_ID_UNIDADE,
                                                                ppCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                ppCAD_SET_ID );
   -- VERIFICA ESTOQUE PARA INTEIRO NO ESTOQUE DE CONSUMO
   IF ( (FNC_MTMD_VERIFICA_ESTOQUE( ppCAD_MTMD_ID,
                                   ppCAD_MTMD_FILIAL_ID,
                                   ppCAD_UNI_ID_UNIDADE,
                                   ppCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                   ppCAD_SET_ID,
                                   1, -- QTDE
                                   NAO, -- ppCAD_MTMD_FL_FRACIONA
                                   ppUnidVenda ) + vMTMD_ESTLOC_QTDE_FRACIONADA) = NAO ) THEN
      RAISE_APPLICATION_ERROR( -20003, 'NAO EXISTE ESTOQUE PARA FRACIONAR ESTE PRODUTO');
   END IF;
   IF ( vMTMD_ESTLOC_QTDE_FRACIONADA >= 1  ) THEN
      -- BAIXA ITEM FRACIONADO DO ESTOQUE DE CONSUMO
      UPDATE TB_MTMD_ESTOQUE_LOCAL SET
      MTMD_ESTLOC_QTDE_FRACIONADA = NVL(MTMD_ESTLOC_QTDE_FRACIONADA,0)-1
      WHERE  CAD_MTMD_ID                  = ppCAD_MTMD_ID
      AND    CAD_MTMD_FILIAL_ID           = ppCAD_MTMD_FILIAL_ID
      AND    CAD_UNI_ID_UNIDADE           = ppCAD_UNI_ID_UNIDADE
      AND    CAD_LAT_ID_LOCAL_ATENDIMENTO = ppCAD_LAT_ID_LOCAL_ATENDIMENTO
      AND    CAD_SET_ID                   = ppCAD_SET_ID;
   ELSE
      -- N?O PODE DEIXAR BAIXAR A UNIDADE FISICAMENTE, POIS N?O TEM FRACIONADO
      RAISE_APPLICATION_ERROR( -20000, 'NAO EXISTE ESTOQUE FRACIONADO DESTE PRODUTO PARA DAR BAIXA');
   END IF;
END PRC_MTMD_BAIXA_INTEIRO_FRAC;
--#################### I N I C I O  P R O C E D U R E ###########################################################
BEGIN
   bMovimentaEstoque  := TRUE;
   nQtdeConsumida     := NVL( pMTMD_ESTLOC_QTDE,1);
   vCAD_MTMD_TPMOV_ID := NVL( pCAD_MTMD_TPMOV_ID, PKG_MTMD_CONSTANTES.TIPO_MOVIMENTO_SAIDA);
   vCAD_MTMD_SUBTP_ID := NVL( pCAD_MTMD_SUBTP_ID,0);
   nFilial            := FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID);
   bInteiroFracionado := FALSE;
   -- VERIFICA DE QUAL ESTOQUE O SETOR CONSOME
   PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE,        pCAD_LAT_ID_LOCAL_ATENDIMENTO,   pCAD_SET_ID,
                                nFilial,
                                vUNIDADE_ESTOQUE_CONSUMO,   vLOCAL_ESTOQUE_CONSUMO,          vSETOR_ESTOQUE_CONSUMO
                               );
   -- BUSCA INFORMACOES SOBRE PRODUTO
   BEGIN
      SELECT MATMED.CAD_MTMD_FL_FRACIONA,
             DECODE(pCAD_SET_ID, 2252, 0, NVL(MATMED.CAD_MTMD_FL_BAIXA_AUTOMATICA, 0)),--SEMPRE LIBERAR BAIXA PARA ATENDIMENTO DOMICILIAR
             MATMED.TIS_MED_CD_TABELAMEDICA,
             MATMED.CAD_MTMD_UNIDADE_VENDA,
             MATMED.CAD_MTMD_FL_FATURADO,
             DECODE(pCAD_SET_ID, 2252, null, MATMED.MTMD_TP_FRACAO_ID),--N?O CONSUMIR EM ML PARA ATENDIMENTO DOMICILIAR
             MATMED.cad_mtmd_fl_reutilizavel,
             MATMED.CAD_MTMD_PRIATI_ID
      INTO   nFracionado,
             nBaixaAutomatica,
             nTabelaMedica,
             nUnidVenda,
             nFaturado,
             vMTMD_TP_FRACAO_ID,
             nReutilizavel,
             vCAD_MTMD_PRIATI_ID
      FROM TB_CAD_MTMD_MAT_MED MATMED
      WHERE MATMED.CAD_MTMD_ID = pCAD_MTMD_ID;
   END;
   IF (NVL(vCAD_MTMD_SUBTP_ID,0) = BAIXA_CONS_DISP_AUTO_PACIENTE) THEN
      vMTMD_TP_FRACAO_ID := null;
   END IF;
   -- NAO PASSOU NO PAREMETRO
   IF ( vCAD_MTMD_SUBTP_ID = 0  ) THEN
--      IF ( nFaturado = SIM ) THEN
         IF ( nFracionado = SIM ) THEN
            vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.MOV_BXA_FRACIONADO;
         ELSE
            vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.BAIXA_CONSUMO;
         END IF;
--     ELSIF ( nFaturado = NAO) THEN
--         IF ( nFracionado = SIM ) THEN
--            vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.MOV_BXA_FRACIONADO;
--         ELSE
--            vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.BAIXA_CONSUMO;
--         END IF;
--      END IF;
  END IF;
   -- VERIFICA SE PRODUTO INTEIRO ESTA SENDO CONSUMIDO COMO FRACIONADO
   IF ( pCAD_MTMD_FL_FRACIONA = SIM  AND  nFracionado = NAO ) THEN
      -- AJUSTA UNIDADE DE VENDA PARA SER MAIOR QUE QTDE CONSUMIDA PARA QUANDO ENTRAR NA PROCEDURE PRC_VERIFICA_QTDE
      nUnidVenda := nQtdeConsumida+1;
      -- QUANTIDADE DIGITADA, PARA GARANTIR QUE CONSUMO INTEIRO DE FRAC?O ESTA CERTO
      -- REGISTRANDO NA TABELA DE MOVIMENTAC?O
      vQtdeConvertida := FNC_MTMD_CONVERTE_FRACAO( vMTMD_TP_FRACAO_ID,  nQtdeConsumida );
      -- CRIA FRAC?O DE PRODUTO INTEIRO
      PRC_MTMD_FRACIONA_INTEIRO( pCAD_MTMD_ID,
                                 nFilial,
                                 vUNIDADE_ESTOQUE_CONSUMO,
                                 vLOCAL_ESTOQUE_CONSUMO,
                                 vSETOR_ESTOQUE_CONSUMO,
                                 nUnidVenda );
      nFracionado := pCAD_MTMD_FL_FRACIONA;
      bInteiroFracionado := TRUE;
   ELSIF ( FNC_MTMD_SETOR_RESERVA_CONSUMO( pCAD_UNI_ID_UNIDADE, pCAD_LAT_ID_LOCAL_ATENDIMENTO, pCAD_SET_ID) = NAO
           AND vCAD_MTMD_SUBTP_ID IN  (PKG_MTMD_CONSTANTES.BAIXA_NAO_FATURADO, PKG_MTMD_CONSTANTES.BAIXA_CAR_EMERGENCIA_N_FAT)
           AND nFracionado = NAO
           AND nFaturado = SIM ) THEN
      -- SE NAO FOR "NAO FATURADO" NAO E CONSUMIDO PARA O PACIENTE ENTAO N?O EXISTE CONVERSAO
      -- SUBTRAI INTEIRO QUE FOI CONVERTIDO
      -- SETORES QUE GERAM RESERVA N?O PODEM ENTRAR AQUI, POIS SEMPRE V?O ENVIAR CONSUMO N?O FATURADO MAS N?O FAZEM CONVERS?O
      PRC_MTMD_BAIXA_INTEIRO_FRAC( pCAD_MTMD_ID,
                                   nFilial,
                                   vUNIDADE_ESTOQUE_CONSUMO,
                                   vLOCAL_ESTOQUE_CONSUMO,
                                   vSETOR_ESTOQUE_CONSUMO,
                                   nUnidVenda);
      bInteiroFracionado := TRUE;
   -- SE PARAMETRO ESTIVER DIFERENTE DO CADASTRO O PARAMETRO FICA SENDO O PADR?O
   ELSIF ( NVL(pCAD_MTMD_FL_FRACIONA,0) = NAO AND nFracionado = SIM ) THEN
      nFracionado := NVL(pCAD_MTMD_FL_FRACIONA,nFracionado);
   END IF;
   -- SE FOR FRACIONADO - FATURADO E TIPO DE FRAC?O ESTIVER EM BRANCO
   --IF ( nFracionado = SIM AND  nBaixaAutomatica = NAO AND vMTMD_TP_FRACAO_ID IS NULL ) THEN
   IF ( nFracionado = SIM AND vMTMD_TP_FRACAO_ID IS NULL AND
        (FNC_MTMD_MOV_PERMITE_FRACAO( vCAD_MTMD_SUBTP_ID ) = SIM OR vCAD_MTMD_SUBTP_ID = BAIXA_CONS_DISP_AUTO_PACIENTE)) THEN
      -- VERIFICA SE CONVERTE PARA INTEIRO
      PRC_VERIFICA_QTDE( vUNIDADE_ESTOQUE_CONSUMO,
                         vLOCAL_ESTOQUE_CONSUMO,
                         vSETOR_ESTOQUE_CONSUMO,
                         nUnidVenda,
                         nQtdeConsumida,
                         nFracionado );
      -- SE FOR SETOR COM RESERVA JA FORCA CONSUMO N?O FATURADO
      IF (  FNC_MTMD_SETOR_RESERVA_CONSUMO( pCAD_UNI_ID_UNIDADE, pCAD_LAT_ID_LOCAL_ATENDIMENTO, pCAD_SET_ID) = SIM AND nFracionado = NAO ) THEN
         vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.BAIXA_NAO_FATURADO;
      END IF;
   END IF;
   -- SE FOR FRACAO COM TABELA DE CONVERSAO E FOR FATURADO
   IF ( vMTMD_TP_FRACAO_ID IS NOT NULL AND FNC_MTMD_MOV_PERMITE_FRACAO( vCAD_MTMD_SUBTP_ID ) = SIM) THEN
       vQtdeConvertida := FNC_MTMD_CONVERTE_FRACAO( vMTMD_TP_FRACAO_ID,  nQtdeConsumida );
       IF ( vQtdeConvertida IS NOT NULL  ) THEN
          vnAux           := nQtdeConsumida;
          nQtdeConsumida  := vQtdeConvertida;
          vQtdeConvertida := vnAux;
       END IF;
   END IF;
   -- SE FOR CONVERS?O N?O PRECISA VERIFICAR ESTOQUE, JA FOI VERIFICADO NO FRACIONAMENTO
   IF ( bInteiroFracionado = FALSE ) THEN -- ALTERADO 14/01/2010
      BEGIN
         -- VERIFICA ESTOQUE  DE CONSUMO
         IF FNC_MTMD_VERIFICA_ESTOQUE( pCAD_MTMD_ID,
                                       nFilial,
                                       vUNIDADE_ESTOQUE_CONSUMO,
                                       vLOCAL_ESTOQUE_CONSUMO,
                                       vSETOR_ESTOQUE_CONSUMO,
                                       nQtdeConsumida,
                                       nFracionado,
                                       nUnidVenda ) = NAO THEN
            RAISE_APPLICATION_ERROR( -20001, ' N?O EXISTE ESTOQUE PARA REALIZAR ESTA BAIXA'||
                                             ' QTDE CONSUMO '||TO_CHAR(nQtdeConsumida)||
                                             ' FRACIONADO '||TO_CHAR(nFracionado)||
                                             ' PRODUTO/FILIAL '||TO_CHAR(pCAD_MTMD_ID)||'-'||TO_CHAR(nFilial)||
                                             ' U/L/S '||TO_CHAR(vUNIDADE_ESTOQUE_CONSUMO)||'/'||TO_CHAR(vLOCAL_ESTOQUE_CONSUMO)||'/'||TO_CHAR(vSETOR_ESTOQUE_CONSUMO));
         END IF;
      END;
   END IF;
   --
   -- N?O ENTRA SE TIPO MOVIMENTAC?O N?O PERMITIR FRACIONAMENTO
   IF (FNC_MTMD_MOV_PERMITE_FRACAO( vCAD_MTMD_SUBTP_ID ) = SIM OR vCAD_MTMD_SUBTP_ID = 0 ) THEN
      -- REUTILIZAVEL
      IF ( nReutilizavel = SIM  ) THEN
         vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.MOV_BXA_REUTILIZAVEL;
        bMovimentaEstoque := FALSE;
      -- FRACIONADO
      ELSIF (nFracionado = SIM ) THEN
        bMovimentaEstoque := FALSE;
        -- VERIFICA TIPO DE MOVIMENTO BASEADO NA FILIAL OU SETOR
        IF nFilial = PKG_MTMD_CONSTANTES.FILIAL_CARRINHO_EMERGENCIA  THEN
           vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.MOV_BXA_CAR_EMERGENCIA_FRAC;
        ELSE
           IF ( vCAD_MTMD_SUBTP_ID IS NULL  ) THEN
              vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.MOV_BXA_FRACIONADO;
           END IF;
        END IF;
      ELSE -- INTEIRO
        IF nFilial = PKG_MTMD_CONSTANTES.FILIAL_CARRINHO_EMERGENCIA  THEN
           vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.BAIXA_CAR_EMERGENCIA;
        ELSIF (vCAD_MTMD_SUBTP_ID NOT IN (BAIXA_CONS_DISP_AUTO_PACIENTE,BAIXA_DEVOLUCAO_CONSIGNADO)) THEN
           vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.BAIXA_CONSUMO;
        END IF;
      END IF; -- FIM TESTE DE FRACIONADO
   END IF; -- VERIFICA SE MOV PERMITE FRACAO
   BEGIN
      -- GERA MOVIMENTAC?O PARA UNIDADE QUE ESTA CONSUMINDO
      PRC_MTMD_MOV_MOVIMENTACAO_I (   pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                      pCAD_UNI_ID_UNIDADE,
                                      pCAD_SET_ID,
                                      pMTMD_REQ_ID,
                                      pMTMD_LOTEST_ID,
                                      pCAD_MTMD_ID,
                                      nFilial,
                                      vCAD_MTMD_TPMOV_ID,
                                      vCAD_MTMD_SUBTP_ID,
                                      SYSDATE,
                                      nQtdeConsumida, -- QTDE CONSUMIDA
                                      SIM, -- pMTMD_MOV_FL_FINALIZADO
                                      pATD_ATE_ID,
                                      pATD_ATE_TP_PACIENTE,
                                      pSEG_USU_ID_USUARIO,
                                      vMTMD_TP_FRACAO_ID,
                                      vQtdeConvertida,
                                      pMTMD_MOV_DATA_FATURAMENTO,
                                      pMTMD_MOV_HORA_FATURAMENTO,
                                      pNewIdt
                                   );
   END;
   /*IF (nBaixaAutomatica = NAO) THEN
      -- VERIFICA SE A MOVIMENTAC?O E FATURADA E SE N?O E AMBULATORIO
      IF (FNC_MTMD_MOV_COBRA_PRODUTO( vCAD_MTMD_SUBTP_ID ) = SIM AND pATD_ATE_TP_PACIENTE != 'A') THEN
         BEGIN
            PRC_MTMD_MOV_FATURAR_ONLINE (pNewIdt, 0);
         EXCEPTION WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,sqlerrm);
         END;
      END IF;
   END IF;*/
   -- =====================================================================================================
   IF (bMovimentaEstoque = TRUE) THEN
      -- BAIXA DO ESTOQUE DE CONSUMO
      -- RAISE_APPLICATION_ERROR(-20000,' QTDE CONSUMO '||TO_CHAR(nQtdeConsumida)||' SUB TIPO '||TO_CHAR(vCAD_MTMD_SUBTP_ID));
      UPDATE TB_MTMD_ESTOQUE_LOCAL SET
      MTMD_ESTLOC_QTDE         = NVL(MTMD_ESTLOC_QTDE,0) - nQtdeConsumida,
      MTMD_MOV_CONSUMO         = NVL(MTMD_MOV_CONSUMO,0) + nQtdeConsumida, -- CONSUMO
      MTMD_ESTLOC_DATA         = SYSDATE
      WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
      AND   CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO
      AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO
      AND   CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO
      AND   CAD_MTMD_FILIAL_ID           = nFilial;
      --IF SQL%FOUND THEN
         -- ATUALIZA PERCENTUAL DE CONSUMO
         PRC_MTMD_ESTOQUE_PER_CONSUMO_U(  pCAD_MTMD_ID,
                                          nFilial,
                                          vUNIDADE_ESTOQUE_CONSUMO,
                                          vLOCAL_ESTOQUE_CONSUMO,
                                          vSETOR_ESTOQUE_CONSUMO,
                                          vPERCENTUAL);
         -- VERIFICA MOVIMENTOS QUE GERAM ACERTO CONTABIL
         IF ( FNC_GERA_MOV_CONTABIL( vCAD_MTMD_SUBTP_ID ) = SIM ) THEN
            BEGIN
               UPDATE TB_MTMD_ESTOQUE_CONTABIL SET
               MTMD_ESTCON_QTDE           = NVL(MTMD_ESTCON_QTDE,0) - nQtdeConsumida,
               DT_ULTIMO_CONSUMO          = SYSDATE
               WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
               AND   CAD_MTMD_FILIAL_ID = DECODE(nFilial,4,1,nFilial);
            END;
         END IF;
      /*ELSE
         RAISE_APPLICATION_ERROR( -20001, ' N?O EXISTE ESTOQUE PARA MOVIMENTAR ESTE PRODUTO - 14142 ' || TO_CHAR(pCAD_MTMD_ID));
      END IF;*/ -- FIM SQL%FOUND
      IF (pMTMD_REQ_ID IS NOT NULL) THEN
        SELECT REQ.MTMD_REQ_FL_STATUS, REQ.CAD_SET_SETOR_FARMACIA
          INTO vMTMD_REQ_FL_STATUS,    vSETOR_FARMACIA
          FROM TB_MTMD_REQ_REQUISICAO REQ
         WHERE REQ.MTMD_REQ_ID = pMTMD_REQ_ID;
        --IF (pCAD_SET_ID IN (0) AND nFracionado = NAO) THEN
        --RAISE_APPLICATION_ERROR( -20001, pCAD_SET_ID || ' / ' || vSETOR_ESTOQUE_CONSUMO);
        IF (pCAD_SET_ID IN (200,201,2652) AND pCAD_SET_ID != vSETOR_ESTOQUE_CONSUMO AND nFracionado = NAO) THEN
            --Quando for UTI GERAL/CARDIO/TERREO e estoque for compartilhado com a satelite, e for inteiro, atualizar qtd. dispensada do Pedido
            BEGIN
              SELECT ITEM.CAD_MTMD_PRESCRICAO_ID
                INTO vCAD_MTMD_PRESCRICAO_ID
                FROM TB_MTMD_REQUISICAO_ITEM ITEM
               WHERE ITEM.mtmd_req_id   = pMTMD_REQ_ID
               AND   ITEM.cad_mtmd_id   = pCAD_MTMD_ID
               AND   ITEM.MTMD_ID_ORIGINAL IS NULL;
               vCAD_MTMD_ID_PRESCRICAO := pCAD_MTMD_ID;
            EXCEPTION WHEN NO_DATA_FOUND THEN --PROCURA SIMILAR
               IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
                   BEGIN
                      SELECT ITEM.CAD_MTMD_PRESCRICAO_ID, ITEM.CAD_MTMD_ID
                       INTO  vCAD_MTMD_PRESCRICAO_ID,     vCAD_MTMD_ID_PRESCRICAO
                       FROM TB_MTMD_REQUISICAO_ITEM ITEM JOIN
                            TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = ITEM.CAD_MTMD_ID
                       WHERE ITEM.mtmd_req_id   = pMTMD_REQ_ID
                       AND   M.CAD_MTMD_PRIATI_ID   = vCAD_MTMD_PRIATI_ID
                       AND   ITEM.MTMD_ID_ORIGINAL IS NULL AND ROWNUM = 1;
                   EXCEPTION WHEN NO_DATA_FOUND THEN
                       vCAD_MTMD_ID_PRESCRICAO := NULL;
                   END;
               END IF;
            END;
            IF (vCAD_MTMD_PRESCRICAO_ID IS NOT NULL) THEN
               --Atualizar qtd. fornecida prescricao quando for UTI GERAL/CARDIO
               UPDATE TB_CAD_MTMD_PRESCRICAO_ITEM PI
                  SET PI.CAD_MTMD_PRC_QTDE_DISP = NVL(PI.CAD_MTMD_PRC_QTDE_DISP,0) + nQtdeConsumida
                WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1 AND
                      PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID AND
                      PI.CAD_MTMD_ID = vCAD_MTMD_ID_PRESCRICAO;
            END IF;
            IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
              BEGIN
                SELECT ITEM.CAD_MTMD_ID
                  INTO vCAD_MTMD_ID_ORIGINAL
                  FROM TB_MTMD_REQUISICAO_ITEM ITEM JOIN
                       TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = ITEM.CAD_MTMD_ID
                 WHERE ITEM.mtmd_req_id   = pMTMD_REQ_ID
                   AND M.CAD_MTMD_PRIATI_ID   = vCAD_MTMD_PRIATI_ID
                   AND ITEM.MTMD_ID_ORIGINAL IS NULL AND ROWNUM = 1;
              EXCEPTION WHEN NO_DATA_FOUND THEN
                vCAD_MTMD_ID_ORIGINAL := NULL;
              END;
              SELECT RI.MTMD_REQITEM_QTD_SOLICITADA
                 INTO nQtdePedida
                 FROM TB_MTMD_REQUISICAO_ITEM RI
                WHERE CAD_MTMD_ID = vCAD_MTMD_ID_ORIGINAL
                  AND MTMD_REQ_ID = pMTMD_REQ_ID;
              IF (NVL(vCAD_MTMD_ID_ORIGINAL,0) = pCAD_MTMD_ID) THEN
                 nQtdePedidaGravar := nQtdePedida;
              ELSE
                 nQtdePedidaGravar := nQtdeConsumida;
              END IF;
              BEGIN
                 PRC_MTMD_REQUISICAO_ITEM_I( pMTMD_REQ_ID,
                                             pCAD_MTMD_ID,
                                             nQtdePedidaGravar,
                                             nQtdeConsumida,
                                             vCAD_MTMD_ID_ORIGINAL,
                                             vCAD_MTMD_PRESCRICAO_ID
                                            );
              EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
                 SELECT RI.MTMD_REQITEM_QTD_FORNECIDA
                   INTO nQtdeFornecida
                   FROM TB_MTMD_REQUISICAO_ITEM RI
                  WHERE CAD_MTMD_ID = pCAD_MTMD_ID
                    AND MTMD_REQ_ID = pMTMD_REQ_ID;
                 IF (NVL(vCAD_MTMD_ID_ORIGINAL,0) != pCAD_MTMD_ID) THEN
                    nQtdePedidaGravar := nQtdeFornecida+nQtdeConsumida;
                 END IF;
                 PRC_MTMD_REQUISICAO_ITEM_U( pMTMD_REQ_ID,
                                             pCAD_MTMD_ID,
                                             nQtdePedidaGravar,
                                             nQtdeFornecida+nQtdeConsumida
                                            );
              END;
              SELECT SUM(RI.MTMD_REQITEM_QTD_FORNECIDA)
                 INTO nQtdeFornecida
                 FROM TB_MTMD_REQUISICAO_ITEM RI JOIN
                      TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = RI.CAD_MTMD_ID
                WHERE PROD.CAD_MTMD_PRIATI_ID = vCAD_MTMD_PRIATI_ID
                  AND RI.MTMD_REQ_ID = pMTMD_REQ_ID
                GROUP BY PROD.CAD_MTMD_PRIATI_ID;

              IF (nQtdeFornecida > nQtdePedida) THEN
                 RAISE_APPLICATION_ERROR(-20000, ' ITEM JA FORNECIDO NESTE PEDIDO POR OUTRO PROCESSO ');
              END IF;
            ELSE
               UPDATE TB_MTMD_REQUISICAO_ITEM
                  SET MTMD_REQITEM_QTD_FORNECIDA = NVL(MTMD_REQITEM_QTD_FORNECIDA,0) + nQtdeConsumida
                WHERE CAD_MTMD_ID = pCAD_MTMD_ID
                  AND MTMD_REQ_ID = pMTMD_REQ_ID;

               SELECT RI.MTMD_REQITEM_QTD_SOLICITADA, RI.MTMD_REQITEM_QTD_FORNECIDA
                 INTO nQtdePedida,                    nQtdeFornecida
                 FROM TB_MTMD_REQUISICAO_ITEM RI
                WHERE CAD_MTMD_ID = pCAD_MTMD_ID
                  AND MTMD_REQ_ID = pMTMD_REQ_ID;

               IF (nQtdeFornecida > nQtdePedida) THEN
                  RAISE_APPLICATION_ERROR(-20000, ' ITEM JA FORNECIDO NESTE PEDIDO POR OUTRO PROCESSO ');
               END IF;
            END IF;
        ELSIF (pCAD_MTMD_SUBTP_ID IN (PKG_MTMD_CONSTANTES.MOV_BXA_TRANSFERENCIA, PKG_MTMD_CONSTANTES.BAIXA_PERDA_QUEBRA) AND nFracionado = NAO) THEN
              UPDATE TB_MTMD_REQUISICAO_ITEM
                 SET MTMD_REQITEM_QTD_FORNECIDA = MTMD_REQITEM_QTD_FORNECIDA - nQtdeConsumida
               WHERE CAD_MTMD_ID = pCAD_MTMD_ID
                 AND MTMD_REQ_ID = pMTMD_REQ_ID;
              IF (pATD_ATE_ID IS NOT NULL AND vMTMD_REQ_FL_STATUS IN (3,4,8)) THEN
                 UPDATE TB_MTMD_REQUISICAO_ITEM
                    SET MTMD_REQITEM_QTD_DEVOLVIDA = NVL(MTMD_REQITEM_QTD_DEVOLVIDA,0) + nQtdeConsumida,
                        MTMD_REQITEM_DATA_DEVOLUCAO = SYSDATE
                  WHERE CAD_MTMD_ID = pCAD_MTMD_ID
                    AND MTMD_REQ_ID = pMTMD_REQ_ID;
              END IF;
        ELSIF (pCAD_MTMD_SUBTP_ID IN (60) AND pATD_ATE_ID IS NOT NULL AND NVL(vSETOR_FARMACIA,0) = 61) THEN
           SELECT RI.MTMD_REQITEM_QTD_FORNECIDA, RI.MTMD_REQITEM_QTD_SOLICITADA
             INTO nQtdeFornecida,                nQtdePedida
             FROM TB_MTMD_REQUISICAO_ITEM RI
            WHERE CAD_MTMD_ID = pCAD_MTMD_ID
              AND MTMD_REQ_ID = pMTMD_REQ_ID;

            nQtdeFornecida := nQtdeFornecida+nQtdeConsumida;

            IF (nQtdeFornecida > nQtdePedida) THEN
               RAISE_APPLICATION_ERROR(-20000, ' ITEM JA FORNECIDO EM SUA TOTALIDADE ');
            END IF;

            --Quando for Baixa Auto. de Personalizado dispensado pelo C.C., atualizar Qtd. Forn. do Pedido
            UPDATE TB_MTMD_REQUISICAO_ITEM
               SET MTMD_REQITEM_QTD_FORNECIDA = MTMD_REQITEM_QTD_FORNECIDA + nQtdeConsumida
             WHERE CAD_MTMD_ID = pCAD_MTMD_ID
               AND MTMD_REQ_ID = pMTMD_REQ_ID;
        END IF;
      END IF;
   END IF; -- FIM TESTE BAIXACONTABIL
END PRC_MTMD_MOV_ESTOQUE_BAIXA;