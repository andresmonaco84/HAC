CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_MOVIMENTACAO_I
  (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
     pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
     pMTMD_REQ_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_REQ_ID%type  DEFAULT NULL,
     pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type default null,
     pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
     pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
     pCAD_MTMD_TPMOV_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%type,
     pCAD_MTMD_SUBTP_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type,
     pMTMD_MOV_DATA                IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%type default SYSDATE,
     pMTMD_MOV_QTDE                IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_QTDE%type,
     pMTMD_MOV_FL_FINALIZADO       IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_FL_FINALIZADO%type,
     pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type default NULL,
     pATD_ATE_TP_PACIENTE          IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_TP_PACIENTE%type default NULL,
     pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
     pMTMD_TP_FRACAO_ID            IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_TP_FRACAO_ID%TYPE  DEFAULT NULL,
     pMTMD_QTD_CONVERTIDA          IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_QTD_CONVERTIDA%type  DEFAULT NULL,
     pMTMD_MOV_DATA_FATURAMENTO    IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA_FATURAMENTO%type  DEFAULT NULL,
     pMTMD_MOV_HORA_FATURAMENTO    IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_HORA_FATURAMENTO%type  DEFAULT NULL,
     pNewIdt                       OUT integer
  )
  is
  lIdtRetorno integer;
  vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
  vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
  vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
  vMTMD_MOV_DATA_FATURAMENTO TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA_FATURAMENTO%type;
  vMTMD_MOV_HORA_FATURAMENTO TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_HORA_FATURAMENTO%type;
  vMTMD_MOV_SALDO_LOTE_SETOR TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_SETOR%type;
  vMTMD_MOV_SALDO_LOTE_TOTAL TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_TOTAL%type;
  vMTMD_COD_LOTE             TB_MTMD_MOV_MOVIMENTACAO.MTMD_COD_LOTE%type;
  vMTMD_NOVA_QTD_SOMA_LOTE   TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_TOTAL%type := 0;
  vMTMD_QTD_DISPON_SEMLOTE   TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_TOTAL%type;
  vMTMD_DT_VALIDADE          TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_DT_VALIDADE%TYPE;
  sHora VARCHAR2(4);
  vCAD_MTMD_GRUPO_ID         TB_CAD_MTMD_MAT_MED.cad_mtmd_grupo_id%TYPE;
  vCAD_MTMD_SUBGRUPO_ID      TB_CAD_MTMD_MAT_MED.cad_mtmd_SUBgrupo_id%TYPE;
  vCAD_MTMD_FL_CONTROLA_LOTE TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_CONTROLA_LOTE%TYPE;
  vMTMD_CUSTO_MEDIO          TB_MTMD_ESTOQUE_CONTABIL.mtmd_custo_medio%type;
  SUB_MOV_ENTRADA_NF           CONSTANT NUMBER := 1;
  SUB_MOV_ENTRADA_TRANSF       CONSTANT NUMBER := 2;
  SUB_MOV_ESTORNO_NAO_FAT      CONSTANT NUMBER := 13;
  SUB_MOV_ESTORNO_CONS_PAC     CONSTANT NUMBER := 16;
  SUB_MOV_ESTORNO_CCUSTO       CONSTANT NUMBER := 29;
  INFORMATIVO_FATURAMENTO      CONSTANT NUMBER := 66;
  /*SUB_MOV_BAIXA_CONS_PAC       CONSTANT NUMBER := 11;
  SUB_MOV_BAIXA_CONS_CE_FAT    CONSTANT NUMBER := 25;
  SUB_MOV_BAIXA_CONS_NAO_FAT   CONSTANT NUMBER := 18;
  SUB_MOV_BAIXA_CONS_CCUSTO    CONSTANT NUMBER := 19;
  SUB_MOV_BAIXA_PERDA_QUEBRA   CONSTANT NUMBER := 6;
  SUB_MOV_BAIXA_ACERTO         CONSTANT NUMBER := 30;
  SUB_MOV_ENTRADA_ACERTO       CONSTANT NUMBER := 31;*/
  SUB_MOV_ENTRADA_FORN         CONSTANT NUMBER := 1;
  NAO_FATURADO                 CONSTANT NUMBER := 0;
  vCAD_MTMD_FL_CONSUMO         NUMBER(1);
  vCAD_MTMD_FL_FRACIONADO      NUMBER(1);
  vCAD_MTMD_FL_INFORMATIVO     NUMBER(1);
  vSETOR_BARRAR_TRANSF         NUMBER(1);
  nFilial                      NUMBER;
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_MOVIMENTACAO_I
  *
  *    Data Criacao:  06/2009   Por: RICARDO COSTA
  *    Data Alteracao: 04/02/2010  Por: RICARDO COSTA
  *         Alterac?o: Verificac?o da quantidade de digitos da hora
  *                    pode ter 2,3,4 caracteres
  *    Data Alteracao: 06/04/2010  Por: ANDRE SOUZA MONACO
  *         Alterac?o: Quando CE, busca custo medio do HAC
  *    Data Alteracao: 19/04/2010  Por: RICARDO COSTA
  *         Alterac?o: Mes/Ano Rotina de Contabilidade
  *    Data Alteracao: 14/10/2010  Por: ANDRE SOUZA MONACO
  *         Alterac?o: pMTMD_MOV_DATA voltou a ser utilizado quando
                       diferente de null (p/ regra do obito)
  *    Data Alteracao: 18/03/2011  Por: ANDRE SOUZA MONACO
  *         Alterac?o: Chamada no final da PRC_MTMD_MOV_MES_G
  *    Data Alteracao: 21/11/2011  Por: ANDRE SOUZA MONACO
  *         Alterac?o: Barrar movimento se setor estiver em inventario
  *    Data Alteracao: 02/2018  Por: ANDRE SOUZA MONACO
  *         Alterac?o: Novas infs. de lote
  *
  *    Funcao: Registra toda movimentac?o de produtos
  *
  *******************************************************************/
  nEstoque                     NUMBER;
  vMTMD_ESTLOC_QTDE_FRACIONADA NUMBER;
  ----------------------------------------------------------------------------------------------------
-- RETORNA DATA DO MOVIMENTO A GERAR ( SE OBITO, RETORNA DATA DO OBITO E N?O A ATUAL )
----------------------------------------------------------------------------------------------------
FUNCTION FNC_MTMD_MOV_DATA(parATD_ATE_ID IN TB_ATD_INA_INT_ALTA.ATD_ATE_ID%type) RETURN DATE IS
   retorna TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%type;
   pData   TB_ATD_IML_INT_MOV_LEITO.ATD_IML_DT_SAIDA%type;
   pHora   TB_ATD_IML_INT_MOV_LEITO.ATD_IML_HR_SAIDA%type;
BEGIN
   retorna := SYSDATE; -- POR PADRAO E A DATA ATUAL
   IF (FNC_INT_PAC_OBITO(parATD_ATE_ID) = 1) THEN
      SELECT INA.ATD_INA_DT_ALTA_ADM, INA.ATD_INA_HR_ALTA_ADM
         INTO pData, pHora
         FROM TB_ATD_INA_INT_ALTA INA
         WHERE INA.ATD_ATE_ID = pATD_ATE_ID;
      retorna := FNC_JUNTAR_DATA_HORA(pData, pHora);
   END IF;
   RETURN retorna;
END FNC_MTMD_MOV_DATA;
--=========================================================================================
-- INICIO PROCEDURE
--=========================================================================================
  BEGIN
   IF ( pMTMD_MOV_HORA_FATURAMENTO IS NULL ) THEN
      -- RAISE_APPLICATION_ERROR(-20000,' DATA '||TO_CHAR(SYSDATE, 'HH24MI'));
      vMTMD_MOV_HORA_FATURAMENTO := TO_CHAR(SYSDATE, 'HH24MI');
   ELSE
      vMTMD_MOV_HORA_FATURAMENTO := pMTMD_MOV_HORA_FATURAMENTO;
      IF  ( LENGTH(TO_CHAR(vMTMD_MOV_HORA_FATURAMENTO)) = 2 ) THEN
         sHora := '00'||TO_CHAR(vMTMD_MOV_HORA_FATURAMENTO);
      ELSIF ( LENGTH(TO_CHAR(vMTMD_MOV_HORA_FATURAMENTO)) = 3 ) THEN
         sHora := '0'||TO_CHAR(vMTMD_MOV_HORA_FATURAMENTO);
      ELSE
         sHora := TO_CHAR(vMTMD_MOV_HORA_FATURAMENTO);
      END IF;
   END IF;
   IF ( pMTMD_MOV_DATA_FATURAMENTO IS NULL ) THEN
      vMTMD_MOV_DATA_FATURAMENTO := SYSDATE;
   ELSE
      vMTMD_MOV_DATA_FATURAMENTO := TO_DATE(TO_CHAR(TRUNC(pMTMD_MOV_DATA_FATURAMENTO),'DDMMYYYY')||' '||sHora,'DDMMYYYY HH24MI');
   END IF;
    -- BUSCA ESTOQUE ATUAL DO PRODUTO NA UNIDADE
    BEGIN
       SELECT NVL(FNC_MTMD_ESTOQUE_UNIDADE (pCAD_MTMD_ID,
                                            pCAD_UNI_ID_UNIDADE,
                                            pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                            pCAD_SET_ID,
                                            pCAD_MTMD_FILIAL_ID,
                                            pMTMD_LOTEST_ID
                                           ),0)
       INTO nEstoque
       FROM DUAL;
    EXCEPTION WHEN NO_DATA_FOUND THEN
       nEstoque := NULL;
    END;
    -- VERIFICA SE EXISTE ITEM INTEIRO CONVERTIDO PARA FRACIONADO
    vMTMD_ESTLOC_QTDE_FRACIONADA := NVL(FNC_MTMD_ESTOQUE_FRACIONADO( 0,
                                                                     pCAD_MTMD_ID,
                                                                     pCAD_MTMD_FILIAL_ID,
                                                                     pCAD_UNI_ID_UNIDADE,
                                                                     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                     pCAD_SET_ID ),0);
    nEstoque := nEstoque + vMTMD_ESTLOC_QTDE_FRACIONADA;
    -- VERIFICA SE EXISTE MOVIMENTAC?O CONTABIL(ENTRADA OU BAIXA DEFINITIVA)
    BEGIN
       SELECT NVL(CAD_MTMD_FL_CONSUMO,0), NVL(CAD_MTMD_FL_FRACIONADO,0), NVL(CAD_MTMD_FL_INFORMATIVO,0)
       INTO   vCAD_MTMD_FL_CONSUMO,       vCAD_MTMD_FL_FRACIONADO,       vCAD_MTMD_FL_INFORMATIVO
       FROM TB_CAD_MTMD_SUBTP_MOVIMENTACAO
       WHERE CAD_MTMD_SUBTP_ID = pCAD_MTMD_SUBTP_ID
       AND   CAD_MTMD_TPMOV_ID = pCAD_MTMD_TPMOV_ID;
    END;
   -- A MOVIMENTAC?O E GERADA PARA A UNIDADE/SETOR QUE ESTA MOVIMENTANDO O PRODUTO
   -- A PESQUISA AQUI E PARA REGISTRAR DE QUAL UNIDADE FOI REALIZADA A BAIXA
   PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE,
                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                pCAD_SET_ID,
                                pCAD_MTMD_FILIAL_ID,
                                vUNIDADE_ESTOQUE_CONSUMO,
                                vLOCAL_ESTOQUE_CONSUMO,
                                vSETOR_ESTOQUE_CONSUMO
                               );
    IF ( vSETOR_ESTOQUE_CONSUMO = pCAD_SET_ID ) THEN
       -- SE SETORES FOREM OS MESMOS GRAVA NULL
       vUNIDADE_ESTOQUE_CONSUMO := NULL;
       vLOCAL_ESTOQUE_CONSUMO   := NULL;
       vSETOR_ESTOQUE_CONSUMO   := NULL;
    END IF;
    -- BUSCA INFORMACOES SOBRE PRODUTO
    SELECT  MTMD.cad_mtmd_grupo_id, MTMD.cad_mtmd_subgrupo_id
    INTO     vCAD_MTMD_GRUPO_ID,    vCAD_MTMD_SUBGRUPO_ID
    FROM TB_CAD_MTMD_MAT_MED MTMD
    WHERE MTMD.cad_mtmd_id = pCAD_MTMD_ID;    
    -- SE TIVER INVENTARIO EM ANDAMENTO DO SETOR ABORTAR MOVIMENTO
    IF (pCAD_MTMD_SUBTP_ID != INFORMATIVO_FATURAMENTO AND 
        (FNC_MTMD_SETOR_INVENTARIADO(NVL(vSETOR_ESTOQUE_CONSUMO,pCAD_SET_ID), pCAD_MTMD_FILIAL_ID, 1) IN (1,2) OR
         FNC_MTMD_SETOR_INVENTARIADO(NVL(vSETOR_ESTOQUE_CONSUMO,pCAD_SET_ID), pCAD_MTMD_FILIAL_ID, 1, vCAD_MTMD_GRUPO_ID) IN (1,2))) THEN
       RAISE_APPLICATION_ERROR(-20010,'NAO E PERMITIDO REALIZAR MOVIMENTACAO, POIS A CONTAGEM PARA INVENTARIO DO ESTOQUE DO SETOR NAO PODE ESTAR EM ANDAMENTO');
    END IF;
    IF (pCAD_MTMD_FILIAL_ID = 1 AND pCAD_MTMD_SUBTP_ID = SUB_MOV_ENTRADA_TRANSF) THEN
      SELECT COUNT(S.CAD_SET_ID)
        INTO vSETOR_BARRAR_TRANSF
        FROM TB_MTMD_MATMED_SETOR S
        WHERE S.CAD_SET_ID = NVL(vSETOR_ESTOQUE_CONSUMO,pCAD_SET_ID)
          --AND S.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29 --INTERNACAO
          AND S.MTMD_FUN_ID_FUNCIONALIDADE IS NOT NULL;
      IF (vSETOR_BARRAR_TRANSF = 1) THEN
         RAISE_APPLICATION_ERROR(-20040,'NAO PERMITIDO REALIZAR TRANSFERENCIA PARA ESTE SETOR !');
      END IF;
    END IF;
    IF (FNC_MTMD_CONTROLA_LOTE(pCAD_MTMD_ID,pMTMD_LOTEST_ID,vCAD_MTMD_FL_CONTROLA_LOTE) = 1 AND
        pMTMD_LOTEST_ID IS NOT NULL) THEN --Se for medicamento que controla lote, busca infs. lote
       SELECT L.MTMD_COD_LOTE, NVL(MTMD_DT_VAL_ALT, MTMD_DT_VALIDADE)
         INTO vMTMD_COD_LOTE,  vMTMD_DT_VALIDADE
         FROM TB_MTMD_LOTEST_LOTE_ESTOQUE L
        WHERE L.MTMD_LOTEST_ID = pMTMD_LOTEST_ID
          AND L.CAD_MTMD_ID    = pCAD_MTMD_ID;

       IF (vMTMD_DT_VALIDADE IS NULL) THEN vMTMD_DT_VALIDADE := TRUNC(SYSDATE); END IF;

       IF (((pCAD_MTMD_TPMOV_ID = 2 AND pCAD_MTMD_SUBTP_ID NOT IN (6,30,43)) OR pCAD_MTMD_SUBTP_ID = 69) --69 = DEVOLUCAO SETOR SEM PEDIDO
           AND vMTMD_DT_VALIDADE < TRUNC(SYSDATE)) THEN
          RAISE_APPLICATION_ERROR(-20220,'MEDICAMENTO VENCIDO, PERMITIDO APENAS REGISTRO DE PERDA !!!');
       END IF;

       IF (vMTMD_COD_LOTE IS NOT NULL) THEN

         vMTMD_MOV_SALDO_LOTE_SETOR := FNC_MTMD_ESTOQUE_LOTE_SETOR(pCAD_MTMD_ID,
                                                                   pCAD_UNI_ID_UNIDADE,
                                                                   pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                   pCAD_SET_ID,
                                                                   pCAD_MTMD_FILIAL_ID,
                                                                   NULL, -- pMTMD_LOTEST_ID (ja tem o Cod Lote nesse momento)
                                                                   vMTMD_COD_LOTE,
                                                                   1 --So lote com controle
                                                                   );
         IF (pCAD_MTMD_TPMOV_ID = 2 AND vCAD_MTMD_FL_FRACIONADO = 1) THEN -- Baixa Fracionada tem que ter algum saldo
             IF (vMTMD_MOV_SALDO_LOTE_SETOR = 0) THEN
               RAISE_APPLICATION_ERROR(-20020,' SALDO DO LOTE INSUFICIENTE PARA BAIXA !!!');
             END IF;
         ELSIF (pCAD_MTMD_TPMOV_ID = 2 AND vCAD_MTMD_FL_INFORMATIVO != 1 AND
                vMTMD_MOV_SALDO_LOTE_SETOR < pMTMD_MOV_QTDE) THEN -- Se baixa inteira, verificar se saldo e suficiente
             RAISE_APPLICATION_ERROR(-20020,' SALDO DO LOTE INSUFICIENTE PARA BAIXA !!!');
         END IF;

         IF (pCAD_MTMD_TPMOV_ID = 1) THEN
           vMTMD_NOVA_QTD_SOMA_LOTE := pMTMD_MOV_QTDE;
         ELSE
           vMTMD_NOVA_QTD_SOMA_LOTE := -pMTMD_MOV_QTDE;
         END IF;

         IF (vCAD_MTMD_FL_FRACIONADO = 1 OR vCAD_MTMD_FL_INFORMATIVO = 1) THEN --NAO INTERFERE NO SALDO DO SETOR
            vMTMD_NOVA_QTD_SOMA_LOTE := 0;
         END IF;

         vMTMD_MOV_SALDO_LOTE_SETOR := vMTMD_MOV_SALDO_LOTE_SETOR + vMTMD_NOVA_QTD_SOMA_LOTE;

         IF (vCAD_MTMD_FL_CONSUMO = 0 AND pCAD_MTMD_SUBTP_ID NOT IN (3,4,7,9,5,8,10,21,23)) THEN --NAO MEXE COM SALDO TOTAL CONTABIL, MANTEM SALDO ATUAL.
           vMTMD_NOVA_QTD_SOMA_LOTE := 0;                                                        --NAO LEVA EM CONTA BAIXA TRANSF./ ESTORNO. DISP / ENTRADA/BAIXA RESSUP.,
         END IF;                                                                                 --PQ NESSE MOMENTO JA ENTROU/SAIU O QUE SAIU/ENTROU DA ORIGEM

         vMTMD_MOV_SALDO_LOTE_TOTAL := FNC_MTMD_ESTOQUE_LOTE_SETOR(pCAD_MTMD_ID,
                                                                   NULL, --UNIDADE
                                                                   NULL, --LOCAL
                                                                   NULL, --SETOR
                                                                   pCAD_MTMD_FILIAL_ID,
                                                                   NULL, -- pMTMD_LOTEST_ID (ja tem o Cod Lote nesse momento)
                                                                   vMTMD_COD_LOTE, --COD_LOTE (nao tem nesse momento)
                                                                   1 --So lote com controle
                                                                   ) + vMTMD_NOVA_QTD_SOMA_LOTE;
       END IF;

    ELSIF (NVL(vCAD_MTMD_FL_CONTROLA_LOTE,0) = 1 AND --Item tem controle de lote mas o lote enviado como param. nao tem controle
           vCAD_MTMD_FL_FRACIONADO = 0 AND vCAD_MTMD_FL_INFORMATIVO = 0) THEN
       vMTMD_QTD_DISPON_SEMLOTE := FNC_MTMD_EST_SEMLOTE_SETOR(pCAD_MTMD_ID,
                                                              pCAD_UNI_ID_UNIDADE,
                                                              pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                              pCAD_SET_ID,
                                                              pCAD_MTMD_FILIAL_ID);
       --RAISE_APPLICATION_ERROR(-20020,vMTMD_QTD_DISPON_SEMLOTE || ' ' || pMTMD_MOV_QTDE);
       IF (pCAD_MTMD_TPMOV_ID = 2 AND vCAD_MTMD_FL_FRACIONADO = 1) THEN -- Baixa Fracionada tem que ter algum saldo
           IF (vMTMD_QTD_DISPON_SEMLOTE = 0) THEN
             RAISE_APPLICATION_ERROR(-20030,' PRODUTO COM CONTROLE DE LOTE SEM SALDO DISPONIVEL PARA CONSUMIR LOTE SEM CONTROLE !!!');
           END IF;
       ELSIF (pCAD_MTMD_TPMOV_ID = 2 AND vCAD_MTMD_FL_INFORMATIVO != 1 AND
              vMTMD_QTD_DISPON_SEMLOTE < pMTMD_MOV_QTDE) THEN -- Se baixa inteira, verificar se saldo e suficiente
           RAISE_APPLICATION_ERROR(-20030,' PRODUTO COM CONTROLE DE LOTE SEM SALDO DISPONIVEL PARA CONSUMIR LOTE SEM CONTROLE !!!');
       END IF;
    END IF;

    BEGIN
       -- BUSCA INFORMAC?ES SOBRE PRECO
       SELECT CONTABIL.mtmd_custo_medio
       INTO    vMTMD_CUSTO_MEDIO
       FROM TB_MTMD_ESTOQUE_CONTABIL CONTABIL
       WHERE CONTABIL.cad_mtmd_id        = pCAD_MTMD_ID
       AND   CONTABIL.cad_mtmd_filial_id = DECODE(pCAD_MTMD_FILIAL_ID,4,1,pCAD_MTMD_FILIAL_ID);
       IF ( NVL(vMTMD_CUSTO_MEDIO,0)=0 AND pCAD_MTMD_SUBTP_ID NOT IN (SUB_MOV_ENTRADA_FORN) ) THEN
          PRC_ENVIA_EMAIL_CURTO('sgs@anacosta.com.br',
                                'andre.monaco@prestadores.anacosta.com.br',
                                ' [MOVIMENTACAO CUSTO MEDIO] ',
                                ' PRODUTO  '||TO_CHAR(pCAD_MTMD_ID)||
                                ' FILIAL '||TO_CHAR(pCAD_MTMD_FILIAL_ID)||
                                ' PRODUTO SEM CUSTO MEDIO');
          /*PRC_ENVIA_EMAIL ('ricardo.costa@anacosta.com.br', -- origem
                           'andre.monaco@anacosta.com.br', --destino
                           'ramiro.andrade@anacosta.com.br'  ,-- pemail_copia
                           ' [MOVIMENTACAO CUSTO MEDIO] ',-- pemail_assunto
                           ' PRODUTO  '||TO_CHAR(pCAD_MTMD_ID)||
                           ' FILIAL '||TO_CHAR(pCAD_MTMD_FILIAL_ID)||
                           ' PRODUTO SEM CUSTO MEDIO');*/
       END IF;
    EXCEPTION
       WHEN OTHERS THEN
       /*IF (pCAD_MTMD_SUBTP_ID NOT IN (SUB_MOV_ENTRADA_FORN)) THEN
          PRC_ENVIA_EMAIL ('ricardo.costa@anacosta.com.br', -- origem
                           'ricardo.costa@anacosta.com.br', --destino
                           'maria.santos@anacosta.com.br;ramiro.andrade@anacosta.com.br'  ,-- pemail_copia
                           ' [MOVIMENTACAO] ',-- pemail_assunto
                           ' PRODUTO  '||TO_CHAR(pCAD_MTMD_ID)||
                           ' FILIAL '||TO_CHAR(pCAD_MTMD_FILIAL_ID)||
                           SQLERRM);
          RAISE_APPLICATION_ERROR(-20000,' NAO FOI ENCONTRADA UMA NOTA FISCAL PARA RESGATAR O CUSTO MEDIO '||SQLERRM);
          vMTMD_CUSTO_MEDIO := 0;
       ELSE
          vMTMD_CUSTO_MEDIO := 0;
       END IF;*/
       vMTMD_CUSTO_MEDIO := 0;
    END;
    IF (pCAD_MTMD_SUBTP_ID IN (62, 63)) THEN --Para entrada de emprestimo, deixar igual entrada de NF mantendo logica no historico
       nEstoque := nEstoque + pMTMD_MOV_QTDE;
    END IF;
    SELECT SEQ_MTMD_MOVIMENTACAO.NextVal INTO lIdtRetorno FROM DUAL;
    BEGIN
    INSERT INTO TB_MTMD_MOV_MOVIMENTACAO
    (
       MTMD_MOV_ID,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_UNI_ID_UNIDADE,
       CAD_SET_ID,
       MTMD_LOTEST_ID,
       CAD_MTMD_ID,
       CAD_MTMD_TPMOV_ID,
       CAD_MTMD_SUBTP_ID,
       MTMD_MOV_DATA,
       MTMD_MOV_QTDE,
       MTMD_MOV_FL_FINALIZADO,
       ATD_ATE_ID,
       ATD_ATE_TP_PACIENTE,
       CAD_MTMD_FILIAL_ID,
       MTMD_REQ_ID,
       SEG_USU_ID_USUARIO,
       MTMD_MOV_ESTOQUE_ATUAL,
       MTMD_MOV_FL_ESTORNO,
       MTMD_MOV_QTDE_FRACIONADA,
       MTMD_TP_FRACAO_ID,
       MTMD_QTD_CONVERTIDA,
       MTMD_MOV_FL_FATURADO,
       MTMD_UNIDADE_ESTOQUE_CONSUMO,
       MTMD_LOCAL_ESTOQUE_CONSUMO,
       MTMD_SETOR_ESTOQUE_CONSUMO,
       MTMD_MOV_DATA_FATURAMENTO,
       MTMD_MOV_HORA_FATURAMENTO,
       CAD_MTMD_GRUPO_ID,
       CAD_MTMD_SUBGRUPO_ID,
       MTMD_CUSTO_MEDIO,
       MTMD_COD_LOTE,
       MTMD_MOV_SALDO_LOTE_SETOR,
       MTMD_MOV_SALDO_LOTE_TOTAL
    )
    VALUES
    (
      lIdtRetorno,
      pCAD_LAT_ID_LOCAL_ATENDIMENTO,
      pCAD_UNI_ID_UNIDADE,
      pCAD_SET_ID,
      pMTMD_LOTEST_ID,
      pCAD_MTMD_ID,
      pCAD_MTMD_TPMOV_ID,
      pCAD_MTMD_SUBTP_ID,
      SYSDATE,
      pMTMD_MOV_QTDE,
      pMTMD_MOV_FL_FINALIZADO,
      pATD_ATE_ID,
      PATD_ATE_TP_PACIENTE,
      pCAD_MTMD_FILIAL_ID,
      pMTMD_REQ_ID,
      pSEG_USU_ID_USUARIO,
      nEstoque,
      0,
      vMTMD_ESTLOC_QTDE_FRACIONADA,
      pMTMD_TP_FRACAO_ID,
      pMTMD_QTD_CONVERTIDA,
      NAO_FATURADO,
      vUNIDADE_ESTOQUE_CONSUMO,
      vLOCAL_ESTOQUE_CONSUMO,
      vSETOR_ESTOQUE_CONSUMO,
      vMTMD_MOV_DATA_FATURAMENTO,
      vMTMD_MOV_HORA_FATURAMENTO,
      vCAD_MTMD_GRUPO_ID,
      vCAD_MTMD_SUBGRUPO_ID,
      vMTMD_CUSTO_MEDIO,
      vMTMD_COD_LOTE,
      vMTMD_MOV_SALDO_LOTE_SETOR,
      vMTMD_MOV_SALDO_LOTE_TOTAL
    );
    EXCEPTION WHEN OTHERS THEN
       RAISE_APPLICATION_ERROR(-20005,' MOV FINALIZADO'||TO_CHAR(pMTMD_MOV_FL_FINALIZADO)||' SALDO MOV '||TO_CHAR(nEstoque)||' ID '||TO_CHAR(lIdtRetorno) ||
                               SQLERRM || ' TP_MOV - ' || TO_CHAR(pCAD_MTMD_TPMOV_ID) || ' SUBTP_MOV - ' || TO_CHAR(pCAD_MTMD_SUBTP_ID));
    END;
    IF (pCAD_MTMD_FILIAL_ID = 4) THEN -- CE
        nFilial := 1; -- HAC
    ELSE
        nFilial := pCAD_MTMD_FILIAL_ID;
    END IF;
    IF (pCAD_MTMD_SUBTP_ID IN (SUB_MOV_ENTRADA_NF,
                               SUB_MOV_ESTORNO_NAO_FAT,
                               SUB_MOV_ESTORNO_CONS_PAC,
                               SUB_MOV_ESTORNO_CCUSTO, 44, 31, 61, 62, 63, 69)) THEN
       PRC_MTMD_MOV_MES_G(nFilial,
                          pCAD_MTMD_ID,
                          TO_NUMBER(TO_CHAR(SYSDATE,'MM')),
                          TO_NUMBER(TO_CHAR(SYSDATE,'YYYY')),
                          pMTMD_MOV_QTDE,
                          0);
    ELSIF (pCAD_MTMD_TPMOV_ID = 2 AND (vCAD_MTMD_FL_CONSUMO = 1 OR pCAD_MTMD_SUBTP_ID = 30) AND pCAD_MTMD_SUBTP_ID NOT IN (1,15)) THEN
       PRC_MTMD_MOV_MES_G(nFilial,
                          pCAD_MTMD_ID,
                          TO_NUMBER(TO_CHAR(SYSDATE,'MM')),
                          TO_NUMBER(TO_CHAR(SYSDATE,'YYYY')),
                          0,
                          pMTMD_MOV_QTDE);
    END IF;
    IF (vSETOR_ESTOQUE_CONSUMO IS NULL) THEN
        vSETOR_ESTOQUE_CONSUMO := pCAD_SET_ID;
    END IF;
    IF (vMTMD_COD_LOTE IS NOT NULL AND vCAD_MTMD_FL_FRACIONADO = 0 AND vCAD_MTMD_FL_INFORMATIVO = 0) THEN
      IF (pCAD_MTMD_TPMOV_ID = 1) THEN
        UPDATE TB_MTMD_ESTOQUE_LOTE L
           SET L.MTMD_EST_QTDE = L.MTMD_EST_QTDE + pMTMD_MOV_QTDE,
               L.MTMD_DATA_ATUALIZADO = SYSDATE
         WHERE L.CAD_MTMD_ID        = pCAD_MTMD_ID
           AND L.CAD_SET_ID         = vSETOR_ESTOQUE_CONSUMO
           AND L.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
           AND L.MTMD_COD_LOTE      = vMTMD_COD_LOTE;

        IF (SQL%ROWCOUNT = 0) THEN
           INSERT INTO SGS.TB_MTMD_ESTOQUE_LOTE
           ( MTMD_COD_LOTE,            CAD_MTMD_ID,            CAD_SET_ID,
             CAD_MTMD_FILIAL_ID,       MTMD_EST_QTDE,          MTMD_DATA_ATUALIZADO
           )
           VALUES
           ( TRIM(vMTMD_COD_LOTE),     pCAD_MTMD_ID,           vSETOR_ESTOQUE_CONSUMO,
             pCAD_MTMD_FILIAL_ID,      pMTMD_MOV_QTDE,         SYSDATE
           );
        END IF;
      ELSE
        UPDATE TB_MTMD_ESTOQUE_LOTE L
            SET L.MTMD_EST_QTDE = L.MTMD_EST_QTDE - pMTMD_MOV_QTDE,
                L.MTMD_DATA_ATUALIZADO = SYSDATE
          WHERE L.CAD_MTMD_ID        = pCAD_MTMD_ID
            AND L.CAD_SET_ID         = vSETOR_ESTOQUE_CONSUMO
            AND L.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
            AND L.MTMD_COD_LOTE      = vMTMD_COD_LOTE;
      END IF;
    END IF;
    -- VERIFICA QUAL TIPO DE MOVIMENTAC?O GERA CONSUMO/ENTRADA DEFINITIVA
    /*
    IF (pCAD_MTMD_SUBTP_ID IN (SUB_MOV_BAIXA_CONS_PAC,
                               SUB_MOV_BAIXA_CONS_CE_FAT,
                               SUB_MOV_BAIXA_CONS_NAO_FAT,
                               SUB_MOV_BAIXA_CONS_CCUSTO,
                               SUB_MOV_BAIXA_PERDA_QUEBRA,
                               SUB_MOV_BAIXA_ACERTO,
                               SUB_MOV_ENTRADA_ACERTO,
                               SUB_MOV_ENTRADA_FORN)) THEN
                               */
    -- VERIFICA SE TIPO DE MOVIEMNTO GERA CONSUMO FINAL
    /*
    IF ( vCAD_MTMD_FL_CONSUMO = 1 OR pCAD_MTMD_SUBTP_ID = 1  ) THEN
         -- REGISTRA MOVIMENTO CONTABIL
         PRC_MTMD_MOV_ESTOQUE_MES_U (pCAD_MTMD_ID,
                                     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                     pCAD_UNI_ID_UNIDADE,
                                     pCAD_SET_ID,
                                     pCAD_MTMD_FILIAL_ID,
                                     pMTMD_MOV_QTDE,
                                     pCAD_MTMD_TPMOV_ID,
                                     pCAD_MTMD_SUBTP_ID,
                                     -- NULL, --VALOR (VERIFICAR)
                                     vMTMD_CUSTO_MEDIO, --CUSTO MEDIO (VERIFICAR)
                                     nEstoque,
                                     pSEG_USU_ID_USUARIO,
                                     vCAD_MTMD_GRUPO_ID,
                                     vCAD_MTMD_SUBGRUPO_ID,
                                     NULL, -- MES
                                     NULL -- ANO
                                     );
    END IF;
    */
    pNewIdt := lIdtRetorno;
  end PRC_MTMD_MOV_MOVIMENTACAO_I;