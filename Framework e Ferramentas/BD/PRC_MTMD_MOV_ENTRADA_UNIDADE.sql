CREATE OR REPLACE PROCEDURE "PRC_MTMD_MOV_ENTRADA_UNIDADE"
(
   pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
   pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type default null,
   pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
   pMTMD_REQ_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_REQ_ID%type,
   pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
   pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
   pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
   pCAD_MTMD_TPMOV_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%type,
   pCAD_MTMD_SUBTP_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type,
   pMTMD_MOV_QTDE                IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_QTDE%type,
   pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type default NULL,
   pATD_ATE_TP_PACIENTE          IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_TP_PACIENTE%type default NULL,
   pMTMD_MOV_FL_FINALIZADO       IN TB_MTMD_MOV_MOVIMENTACAO.mtmd_mov_fl_finalizado%TYPE default NULL,
   pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
   pMTMD_ID_ORIGINAL             IN TB_MTMD_ESTOQUE_LOCAL.MTMD_ID_ORIGINAL%TYPE DEFAULT NULL,
   pNewIdt                       OUT INTEGER
)
IS
  /************************************************************************
  *    Procedure: PRC_MTMD_MOV_ENTRADA_UNIDADE
  *
  *    Data Criacao: 	25/11/2009   Por: RICARDO COSTA
  *
  *    Data alterac?o: 19/04/2010   Por: RICARDO COSTA
  *         Alterac?o: Retirado Acerto Carrinho de emergencia, que n?o existe mais no estqoue contabil
*    Data Alteracao: 06/08/2010      Por: RICARDO cOSTA
*         Descric?o: ATUALIZADO MIGRA2
  *    Data alterac?o: 06/08/2010   Por: RICARDO COSTA
  *         Alterac?o: VERIFICAC?O DE ENTRADA NO ALMOXARIFADO CENTRAL PARA CARRINHO DE EMERGENCIA
                       N?O EXISTE ESTOQUE NO ALMOXARIFADO CENTRAL DO C.E.
  *    Data alterac?o: 12/06/2017   Por: ANDRE MONACO
  *         Alterac?o: Atualiza perc. consumo tambem no insert da TB_MTMD_ESTOQUE_LOCAL
  *
  *    CHAMADA: PRC_MTMD_MOV_ESTOQUE_TRANSF
  *
  *    Funcao: Abastece Estoque da Unidade com produto Dispensado Pelo Almoxarifado Central
  *            OBS: a tela de transferencia tambem chama esta procedure para movimentar o produto
  ************************************************************************/
nFilial             NUMBER;
vMTMD_PEDPAD_QTDE   NUMBER;
nTeste              NUMBER;
nPercConsumo        NUMBER;
flBaixaAutomatica   TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_BAIXA_AUTOMATICA%TYPE;
flCentroDispensacao TB_CAD_SET_SETOR.CAD_SET_FL_SUBSTALMOX_OK%TYPE;
nConsumo            NUMBER;
ENTRADA_PERSONALIZADA        CONSTANT NUMBER :=9;
ENTRADA_TRANSFERENCIA        CONSTANT NUMBER :=2;
ENTRADA_ACERTO               CONSTANT NUMBER :=31;
ENTRADA_ESTORNO_NAO_FATURADO CONSTANT NUMBER :=13;
ENTRADA_PEDIDO_PADRAO        CONSTANT NUMBER :=7;
ENTRADA_CONSUMO_ESTORNADO    CONSTANT NUMBER :=16;
ENTRADA_AVULSO               CONSTANT NUMBER :=4;
ENTRADA_CARRO_EMERGENCIA     CONSTANT NUMBER :=21;
ENTRADA_DISPENSACAO_ESTORNO  CONSTANT NUMBER :=23;
SIM                          CONSTANT NUMBER :=1;
   vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
   vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
   vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
-- ===============================================================================
-- CHAMADA DE: PRC_MTMD_REQ_ITEM_DISPENSA
-- ===============================================================================
FUNCTION EXCLUI_MOVIMENTO_DO_ERRO( pNewIdt IN NUMBER ) RETURN NUMBER IS
Teste NUMBER;
BEGIN
   BEGIN
      SELECT MTMD_MOV_ID
      INTO   Teste
      FROM TB_MTMD_MOV_MOVIMENTACAO
      WHERE MTMD_MOV_ID = pNewIdt;
      --
      -- SE ALGUMA COISA ACONTECER E NAO CONSEGUIR DAR ROLLBACK NO MOVIMENTO TENTA EXCLUIR MANUALMENTE
      --
      DELETE TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID = pNewIdt;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      NULL;
   END;
   RETURN 0;
END EXCLUI_MOVIMENTO_DO_ERRO;
-- ===============================================================================
-- ===============================================================================
BEGIN
  -- VERIFIFCA SE E CENTRO DE DISPENSACAO
  IF ( FNC_MTMD_CENTRO_DISPENSACAO( pCAD_UNI_ID_UNIDADE,
                                    pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                    pCAD_SET_ID ) = SIM AND pCAD_MTMD_FILIAL_ID = PKG_MTMD_CONSTANTES.FILIAL_CARRINHO_EMERGENCIA ) THEN
     -- E CENTRO DE DISPENSACAO N?O EXISTE ENTRADA PARA FILIAL 4
     nFilial := PKG_MTMD_CONSTANTES.FILIAL_HAC;
  ELSE
     nFilial := FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID);
  END IF;
  -- TB_MTMD_MATMED_SETOR
  PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE,
                               pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                               pCAD_SET_ID,
                               nFilial,
                               vUNIDADE_ESTOQUE_CONSUMO,
                               vLOCAL_ESTOQUE_CONSUMO,
                               vSETOR_ESTOQUE_CONSUMO
                              );
  -- MOVIMENTAC?O TEM QUE ACONTECER ANTES DO ACERTO DO ESTOQUE
  -- NA MESMA FILIAL E SETOR ORIGINAL
  PRC_MTMD_MOV_MOVIMENTACAO_I (  pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 pCAD_UNI_ID_UNIDADE,
                                 pCAD_SET_ID,
                                 pMTMD_REQ_ID,
                                 pMTMD_LOTEST_ID,
                                 pCAD_MTMD_ID,
                                 nFilial,
                                 pCAD_MTMD_TPMOV_ID,
                                 pCAD_MTMD_SUBTP_ID,
                                 SYSDATE,
                                 pMTMD_MOV_QTDE,
                                 pMTMD_MOV_FL_FINALIZADO,
                                 pATD_ATE_ID,
                                 pATD_ATE_TP_PACIENTE,
                                 pSEG_USU_ID_USUARIO,
                                 NULL, -- ID_CONVERSAO
                                 NULL, -- QTDE_CONVERTIDA
                                 NULL, -- DT_FAT
                                 NULL, -- HR_FAT
                                 pNewIdt
                                );
  -- RETORNA QTDE SE PRODUTO FIZER PARTE DO ESTOQUE PADRAO DA UNIDADE
  BEGIN
     -- VERIFICA QTDE PADRAO DO PRODUTO NO SETOR
     vMTMD_PEDPAD_QTDE :=  FNC_MTMD_PRODUTO_PADRAO ( pCAD_MTMD_ID,
                                                     nFilial,
                                                     vSETOR_ESTOQUE_CONSUMO,
                                                     vLOCAL_ESTOQUE_CONSUMO,
                                                     vUNIDADE_ESTOQUE_CONSUMO );
  EXCEPTION WHEN OTHERS THEN
     nTeste := EXCLUI_MOVIMENTO_DO_ERRO( pNewIdt );
     RAISE_APPLICATION_ERROR(-20001,' ERRO TENTANDO OBTER QTDE PADRAO DA UNIDADE - ENTRADA ESTOQUE NA UNIDADE -');
  END;
  BEGIN
     INSERT INTO TB_MTMD_ESTOQUE_LOCAL
     ( CAD_MTMD_ID,                    MTMD_LOTEST_ID,                    CAD_MTMD_FILIAL_ID,
       CAD_SET_ID,                     CAD_LAT_ID_LOCAL_ATENDIMENTO,      CAD_UNI_ID_UNIDADE,
       MTMD_ESTLOC_DATA,               MTMD_ESTLOC_QTDE,                  MTMD_PEDPAD_QTDE,
       MTMD_MOV_DT_FORNECIMENTO,       MTMD_MOV_ESTOQUE_ATUAL,            MTMD_ID_ORIGINAL
     )
     VALUES
     ( pCAD_MTMD_ID,                   pMTMD_LOTEST_ID,                   nFilial,
       vSETOR_ESTOQUE_CONSUMO,         vLOCAL_ESTOQUE_CONSUMO,            vUNIDADE_ESTOQUE_CONSUMO,
       SYSDATE,                        pMTMD_MOV_QTDE,                    vMTMD_PEDPAD_QTDE,
       SYSDATE,                        pMTMD_MOV_QTDE,                    pMTMD_ID_ORIGINAL
     );
     -- ATUALIZA PERCENTUAL DE CONSUMO
     PRC_MTMD_ESTOQUE_PER_CONSUMO_U(  pCAD_MTMD_ID, nFilial,  vUNIDADE_ESTOQUE_CONSUMO, vLOCAL_ESTOQUE_CONSUMO, vSETOR_ESTOQUE_CONSUMO, nPercConsumo);
  EXCEPTION
     WHEN DUP_VAL_ON_INDEX THEN
        -- AJUSTA CONSUMO CONFORME TIPO DE MOVIMENTO
        IF ( pCAD_MTMD_SUBTP_ID IN (  ENTRADA_PERSONALIZADA, ENTRADA_PEDIDO_PADRAO, ENTRADA_AVULSO, PKG_MTMD_CONSTANTES.MOV_ENT_REQ_ESTOQUE_LOCAL )  ) THEN
           nConsumo := NULL;
        ELSIF ( pCAD_MTMD_SUBTP_ID IN ( ENTRADA_CONSUMO_ESTORNADO, ENTRADA_ESTORNO_NAO_FATURADO )  ) THEN
           SELECT MTMD_MOV_CONSUMO
           INTO   nConsumo
           FROM TB_MTMD_ESTOQUE_LOCAL
           WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
           AND   CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO
           AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO
           AND   CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO
           AND   CAD_MTMD_FILIAL_ID           = nFilial;
           IF ( nConsumo > 0 )  THEN
              nConsumo := nConsumo - pMTMD_MOV_QTDE;
              IF ( nConsumo < 0 ) THEN
                 nConsumo := NULL;
              END IF;
           ELSE
              nConsumo := 0;
           END IF;
        ELSE
           nConsumo := NULL;
        END IF;
        UPDATE TB_MTMD_ESTOQUE_LOCAL SET
        MTMD_ESTLOC_QTDE         = MTMD_ESTLOC_QTDE + pMTMD_MOV_QTDE,
        MTMD_MOV_ESTOQUE_ATUAL   = MTMD_ESTLOC_QTDE + pMTMD_MOV_QTDE, -- fornecido
        MTMD_MOV_CONSUMO         = nConsumo,
        MTMD_MOV_CONSUMO_OUTROS  = NULL, -- ZERA OUTROS CONSUMOS
        MTMD_MOV_CONSUMO_PERC    = NULL, -- ZERA PERCENTUAL DE CONSUMO
        MTMD_PEDPAD_QTDE         = vMTMD_PEDPAD_QTDE,
        MTMD_ID_ORIGINAL         = pMTMD_ID_ORIGINAL,
        -- MTMD_MOV_DT_FORNECIMENTO = SYSDATE, -- ATUALIZA DATA DE FORNECIMENTO
        MTMD_MOV_DT_FORNECIMENTO =  (CASE WHEN pCAD_MTMD_SUBTP_ID IN (  ENTRADA_PERSONALIZADA, ENTRADA_PEDIDO_PADRAO, ENTRADA_AVULSO, ENTRADA_CARRO_EMERGENCIA, PKG_MTMD_CONSTANTES.MOV_ENT_REQ_ESTOQUE_LOCAL,  PKG_MTMD_CONSTANTES.ENTRADA_ACERTO ) THEN
                                        SYSDATE -- ATUALIZA DATA DE FORNECIMENTO
                                     ELSE
                                        MTMD_MOV_DT_FORNECIMENTO
                                     END),
        MTMD_ESTLOC_DATA         = SYSDATE
        WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
        AND   CAD_MTMD_FILIAL_ID           = nFilial
        AND   CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO
        AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO
        AND   CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO;
        -- ATUALIZA PERCENTUAL DE CONSUMO
        PRC_MTMD_ESTOQUE_PER_CONSUMO_U(  pCAD_MTMD_ID, nFilial,  vUNIDADE_ESTOQUE_CONSUMO, vLOCAL_ESTOQUE_CONSUMO, vSETOR_ESTOQUE_CONSUMO, nPercConsumo);
        IF SQL%FOUND THEN
           IF ( pCAD_MTMD_SUBTP_ID IN (  ENTRADA_PERSONALIZADA, ENTRADA_PEDIDO_PADRAO, ENTRADA_AVULSO, ENTRADA_CARRO_EMERGENCIA, PKG_MTMD_CONSTANTES.MOV_ENT_REQ_ESTOQUE_LOCAL )  ) THEN
              -- ACERTA COLUNA DE RESERVA DA DISPENSAC?O
              UPDATE TB_MTMD_ESTOQUE_LOCAL SET
              MTMD_ESTLOC_QTDE_DISP = NVL(MTMD_ESTLOC_QTDE_DISP,0) - pMTMD_MOV_QTDE
              WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
              AND   CAD_MTMD_FILIAL_ID           = DECODE(nFilial,4,1,nFilial) -- ELE RESERVA COMO ESTOQUE HAC PARA CARRINHO DE EMERGENCIA
              AND   CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO
              AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO
              AND   CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO;
              IF SQL%NOTFOUND THEN
                 IF ( nFilial != 4 ) THEN
                    nTeste :=   EXCLUI_MOVIMENTO_DO_ERRO( pNewIdt );
                    RAISE_APPLICATION_ERROR(-20001,' N?O ENCONTROU PRODUTO PARA ATUALIZAR - ENTRADA UNDIADE - ');
                 END IF;
              END IF;
           END IF; -- FIM TESTE TIPO DE ENTRADA
        END IF; -- FIM SQL%NOTFOUND
   END; -- FIM BLOCO INSERT
   --- NAO EXISTE CARRINHO DE EMERGENCIA NO ESTOQUE CONTABIL
   -- ACERTA ESTOQUE CONTABIL SE FOR MOVIMENTAC?O QUE REALIZA RESERVA DE PRODUTO
   IF ( pCAD_MTMD_SUBTP_ID NOT IN ( ENTRADA_TRANSFERENCIA, ENTRADA_ACERTO, ENTRADA_ESTORNO_NAO_FATURADO, ENTRADA_PEDIDO_PADRAO, PKG_MTMD_CONSTANTES.MOV_ENT_REQ_ESTOQUE_LOCAL, ENTRADA_CONSUMO_ESTORNADO  )  ) THEN
      UPDATE TB_MTMD_ESTOQUE_CONTABIL SET
      MTMD_ESTCON_QTDE = MTMD_ESTCON_QTDE + pMTMD_MOV_QTDE
      WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
      AND   CAD_MTMD_FILIAL_ID = DECODE(nFilial,4,1,nFilial);
   END IF;
END PRC_MTMD_MOV_ENTRADA_UNIDADE;