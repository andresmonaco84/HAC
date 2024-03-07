CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_BAIXA_CENT_DISP
(  pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
   pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type default null,
   pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
   pMTMD_REQ_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_REQ_ID%type,
   pCAD_UNI_ID_UNIDADE_S         IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
   pCAD_LAT_ID_LOCAL_S           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
   pCAD_SET_ID_S                 IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
   pCAD_MTMD_TPMOV_S             IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%type,
   pCAD_MTMD_SUBTP_S             IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type,
   pMTMD_ESTLOC_QTDE             IN TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type,
   pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type default NULL,
   pATD_ATE_TP_PACIENTE          IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_TP_PACIENTE%type default NULL,
   pMTMD_MOV_FL_FINALIZADO       IN TB_MTMD_MOV_MOVIMENTACAO.mtmd_mov_fl_finalizado%TYPE default NULL,
   pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
   pEntrada                      IN NUMBER := 0, -- 0 = baixa estoque do centro de dipensac?o / 1 = estorna(entrada) centro de disp.
   pNewIdt                       OUT integer
)   IS
 /********************************************************************
  *    Procedure: PRC_MTMD_MOV_BAIXA_CENT_DISP
  *
  *    Data Criacao:   12/2009       Por: RICARDO COSTA
  *    Data Alteracao:  19/04/2010    Por: RICARDO COSTA
  *         alterac?o: Checagem da Filial no ajuste do estqoue contabil, Carrinho de emergencia
  *    Data Alteracao:  09/07/2010    Por: RICARDO COSTA
  *         alterac?o: ADICIONADO VERIFICAC?O DE ESTOQUE
  *    Data Alteracao: 29/11/2011      Por: Andre S. Monaco
  *         Descric?o: Registrar movimentac?es durante inventario, quando um dos setores ainda n?o teve inventario
  *    Data Alteracao: 27/03/2012      Por: Andre S. Monaco
  *         Descric?o: - Ultima alterac?o (29/11/11) comentada
  *                    - Atualizar percentual do centro de dispensac?o
  *    Data Alteracao: 26/07/2013      Por: Andre S. Monaco
  *         Descric?o: Quando for movimento de carrinho de emergencia,
  *                    busca estoque de consumo compartilhado do mesmo, ao inves do HAC
  *
  *    Funcao: Centraliza Baixa/Estorno no Estoque do Centro de Dispensac?o ( almoxarifado )
               reservando o produto para posterior envio ao setor/unidade
  *
  *******************************************************************/
nFilial             NUMBER;
nFilialConsumo      NUMBER;
cEstoqueConsumoCentroDisp CHAR(1) := 'N';
nTipoRequisicao     NUMBER;
nLixo               NUMBER;
nUnidadeAlmox       NUMBER;
nLocalAlmox         NUMBER;
nSetorAlmox         NUMBER;
nUnidadeFarmacia    NUMBER;
nLocalFarmacia      NUMBER;
nSetorFarmacia      NUMBER;
nEstoqueUnidade     NUMBER;
vPERCENTUAL         NUMBER;
vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
vCAD_MTMD_GRUPO_ID         TB_CAD_MTMD_MAT_MED.cad_mtmd_grupo_id%TYPE;
BEGIN
   SELECT R.MTM_TIPO_REQUISICAO, R.CAD_SET_SETOR_FARMACIA
     INTO nTipoRequisicao,       nSetorFarmacia
     FROM TB_MTMD_REQ_REQUISICAO R
    WHERE R.MTMD_REQ_ID = pMTMD_REQ_ID;
   IF (nSetorFarmacia IS NOT NULL) THEN
     SELECT CAD_UNI_ID_UNIDADE, CAD_LAT_ID_LOCAL_ATENDIMENTO
       INTO nUnidadeFarmacia,   nLocalFarmacia
       FROM TB_CAD_SET_SETOR
      WHERE CAD_SET_ID = nSetorFarmacia;
   END IF;
   nFilial := FNC_MTMD_RETORNA_FILIAL(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID_S);
   --IF (pCAD_MTMD_SUBTP_S = PKG_MTMD_CONSTANTES.MOV_BXA_CAR_EMERGENCIA) THEN
   IF (nTipoRequisicao = PKG_MTMD_CONSTANTES.REQ_CARRINHO_EMERGENCIA) THEN
       nFilialConsumo := PKG_MTMD_CONSTANTES.FILIAL_CARRINHO_EMERGENCIA;
   ELSE
       nFilialConsumo := nFilial;
   END IF;
   PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE_S,
                                pCAD_LAT_ID_LOCAL_S,
                                pCAD_SET_ID_S,
                                nFilialConsumo,
                                vUNIDADE_ESTOQUE_CONSUMO,
                                vLOCAL_ESTOQUE_CONSUMO,
                                vSETOR_ESTOQUE_CONSUMO
                               );
   --BARRAR DISPENSAR PEDIDO PERSONALIZADO QUANDO ESTOQUE FOR COMPARTILHADO COM UM CENTRO DE DISPENSAC?O
   IF (vSETOR_ESTOQUE_CONSUMO != pCAD_SET_ID_S) THEN
      SELECT S.CAD_SET_FL_SUBSTALMOX_OK
        INTO cEstoqueConsumoCentroDisp
        FROM TB_CAD_SET_SETOR S
        WHERE S.CAD_SET_ID = vSETOR_ESTOQUE_CONSUMO;
      IF (cEstoqueConsumoCentroDisp = 'S' AND nTipoRequisicao = PKG_MTMD_CONSTANTES.REQ_PERSONALIZADA) THEN
         RAISE_APPLICATION_ERROR(-20051,'NAO E PERMITIDO REALIZAR MOVIMENTACAO, POIS ESTE ESTOQUE E COMPARTILHADO COM UM CENTRO DE DISPENSACAO');
      END IF;
   END IF;
   -- BUSCA INFORMACOES SOBRE PRODUTO
   SELECT MTMD.CAD_MTMD_GRUPO_ID
     INTO vCAD_MTMD_GRUPO_ID
   FROM TB_CAD_MTMD_MAT_MED MTMD
   WHERE MTMD.CAD_MTMD_ID = pCAD_MTMD_ID;    
   -- SE TIVER INVENTARIO EM ANDAMENTO DO SETOR DESTINO, ABORTAR MOVIMENTO
   IF (FNC_MTMD_SETOR_INVENTARIADO(NVL(vSETOR_ESTOQUE_CONSUMO,pCAD_SET_ID_S), pCAD_MTMD_FILIAL_ID, 1) IN (1,2) OR
       FNC_MTMD_SETOR_INVENTARIADO(NVL(vSETOR_ESTOQUE_CONSUMO,pCAD_SET_ID_S), pCAD_MTMD_FILIAL_ID, 1, vCAD_MTMD_GRUPO_ID) IN (1,2)) THEN
      RAISE_APPLICATION_ERROR(-20010,'A?O E PERMITIDO REALIZAR MOVIMENTACAO, POIS A CONTAGEM PARA INVENTARIO DO ESTOQUE DO SETOR DESTINO N?O PODE ESTAR EM ANDAMENTO');
   END IF;
   -- SAIDA
   -- MOVIMENTAC?O TEM QUE ACONTECER ANTES DO ACERTO DO ESTOQUE
   -- PROCEDURE DA MOVIMENTACAO PEGA ESTOQUE ATUAL PARA LOG
   -- VERIFICA QUAL O CENTRO DE DISPENSACAO DO ESTOQUE DE CONSUMO
   IF (nSetorFarmacia IS NULL) THEN
      IF (nTipoRequisicao = 9) THEN --9 = MANUTENCAO
          nUnidadeAlmox := 244;
          nLocalAlmox := 33;
          nSetorAlmox := 532; -- SETOR MANUTENCAO
      ELSIF (nTipoRequisicao IN (PKG_MTMD_CONSTANTES.REQ_IMPRESSOS,PKG_MTMD_CONSTANTES.REQ_OUTROS,6)) THEN --6 = HIGIENIZACAO
          nUnidadeAlmox := 244;
          nLocalAlmox := 33;
          nSetorAlmox := 29; --ALMOX. CENTRAL (FIXO)
      ELSE
          BEGIN
             SELECT SETOR.CAD_SET_UNIDADE_ALMOX,
                    SETOR.CAD_SET_LOCAL_ALMOX,
                    SETOR.CAD_SET_SETOR_ALMOX
             INTO nUnidadeAlmox, nLocalAlmox, nSetorAlmox
             FROM TB_CAD_SET_SETOR SETOR
             WHERE SETOR.CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO
             AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO
             AND   SETOR.CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO;
          EXCEPTION WHEN NO_DATA_FOUND THEN
             NULL;
          END;
          IF (nSetorAlmox is null or nLocalAlmox is null or nUnidadeAlmox is null) THEN
             -- SE NAO TEM CENTRO DE DISPENSAC?O, BUSCA ALMOXARIFADO CENTRAL
             SELECT SETOR.CAD_UNI_ID_UNIDADE,
                    SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                    SETOR.CAD_SET_ID
             INTO nUnidadeAlmox, nLocalAlmox, nSetorAlmox
             FROM TB_CAD_SET_SETOR SETOR
             WHERE SETOR.CAD_SET_ALMOX_CENTRAL = 1;
          END IF;
      END IF;
   ELSE
      nUnidadeAlmox := nUnidadeFarmacia;
      nLocalAlmox := nLocalFarmacia;
      nSetorAlmox := nSetorFarmacia;
   END IF;
   -- VERIFICA SE EXISTE SALDO NO CENTRO DE DISPENSACAO
   IF (nSetorFarmacia IS NULL) THEN
     IF (nTipoRequisicao IN (PKG_MTMD_CONSTANTES.REQ_CARRINHO_EMERGENCIA,PKG_MTMD_CONSTANTES.REQ_IMPRESSOS,PKG_MTMD_CONSTANTES.REQ_OUTROS,6,9)) THEN --9 = MANUTENCAO, 6 = HIGIENIZACAO
       nEstoqueUnidade := NVL(FNC_MTMD_ESTOQUE_UNIDADE(pCAD_MTMD_ID,
                                                       nUnidadeAlmox,
                                                       nLocalAlmox,
                                                       nSetorAlmox,
                                                       1,
                                                       pMTMD_LOTEST_ID),0);
     ELSE
       nEstoqueUnidade := NVL(FNC_MTMD_ESTOQUE_CENT_DISP ( pCAD_MTMD_ID,
                                                           vUNIDADE_ESTOQUE_CONSUMO,
                                                           vLOCAL_ESTOQUE_CONSUMO,
                                                           vSETOR_ESTOQUE_CONSUMO,
                                                           nFilial,
                                                           NULL),0);
     END IF;
   ELSE
     nEstoqueUnidade := NVL(FNC_MTMD_ESTOQUE_UNIDADE(pCAD_MTMD_ID,
                                                     nUnidadeFarmacia,
                                                     nLocalFarmacia,
                                                     nSetorFarmacia,
                                                     nFilial,
                                                     pMTMD_LOTEST_ID),0);
   END IF;
   IF ( pEntrada = 0 AND nEstoqueUnidade < pMTMD_ESTLOC_QTDE ) THEN
      RAISE_APPLICATION_ERROR(-20011, 'NAO EXISTE SALDO PARA MOVIMENTAR ESTE ITEM !!! SALDO CENTRO DISP '||TO_CHAR(nEstoqueUnidade)||
                                      ' QTDE CONSUMO '||TO_CHAR(pMTMD_ESTLOC_QTDE)||
                                      ' U/L/S '||TO_CHAR(vUNIDADE_ESTOQUE_CONSUMO)||'/'||TO_CHAR(vLOCAL_ESTOQUE_CONSUMO)||'/'||TO_CHAR(vSETOR_ESTOQUE_CONSUMO)||
                                      ' FILIAL '||TO_CHAR(nFILIAL));
   END IF;
   PRC_MTMD_MOV_MOVIMENTACAO_I(nLocalAlmox,
                               nUnidadeAlmox,
                               nSetorAlmox,
                               pMTMD_REQ_ID,
                               pMTMD_LOTEST_ID,
                               pCAD_MTMD_ID,
                               nFilial, -- pCAD_MTMD_FILIAL_ID,
                               pCAD_MTMD_TPMOV_S,
                               pCAD_MTMD_SUBTP_S,
                               SYSDATE,
                               pMTMD_ESTLOC_QTDE,
                               pMTMD_MOV_FL_FINALIZADO,
                               pATD_ATE_ID,
                               pATD_ATE_TP_PACIENTE,
                               pSEG_USU_ID_USUARIO,
                               NULL, -- ID_CONVERSAO
                               NULL, -- QTDE_CONVERTIDA
                               NULL,-- DT_FAT
                               NULL, -- HR_FAT
                               pNewIdt
                            );
    BEGIN
       -- PARA BAIXA OU ENTRADA DEPOIS DE UMA BAIXA N?O EXISTE INSERT, SE PRODUTO N?O EXISTIR NO ESTOQUE PARA O PROCESSO
       SELECT MTMD_ESTLOC_QTDE
       INTO   nLixo
       FROM   TB_MTMD_ESTOQUE_LOCAL
       WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
       AND   CAD_MTMD_FILIAL_ID           = nFilial
       AND   CAD_UNI_ID_UNIDADE           = nUnidadeAlmox
       AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = nLocalAlmox
       AND   CAD_SET_ID                   = nSetorAlmox;
       -- EXISTE CONTINUA PROCESSO NORMALMENTE
       IF (pEntrada = 0) THEN
         -- RESERVA DE ITEM DISPENSADO
         BEGIN
            UPDATE TB_MTMD_ESTOQUE_LOCAL SET
            MTMD_ESTLOC_QTDE = MTMD_ESTLOC_QTDE - pMTMD_ESTLOC_QTDE,
            MTMD_MOV_CONSUMO         = NVL(MTMD_MOV_CONSUMO,0) + pMTMD_ESTLOC_QTDE, -- CONSUMO
            -- MTMD_MOV_CONSUMO_OUTROS  = nConsumoOutros, -- OUTROS CONSUMOS
            MTMD_ESTLOC_DATA = SYSDATE
            WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
            AND   CAD_MTMD_FILIAL_ID           = nFilial
            AND   CAD_UNI_ID_UNIDADE           = nUnidadeAlmox
            AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = nLocalAlmox
            AND   CAD_SET_ID                   = nSetorAlmox;
            -- ADICIONA QTDE NA COLUNA DE RESERVA DA UNIDADE ( ESTOQUE DE CONSUMO )
            UPDATE TB_MTMD_ESTOQUE_LOCAL SET
            MTMD_ESTLOC_QTDE_DISP = NVL(MTMD_ESTLOC_QTDE_DISP,0) + pMTMD_ESTLOC_QTDE,
            MTMD_ESTLOC_DATA = SYSDATE
            WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
            AND   CAD_MTMD_FILIAL_ID           = nFilial
            AND   CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO
            AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO
            AND   CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO;
            --  AJUSTA ESTOQUE CONTABIL
            UPDATE TB_MTMD_ESTOQUE_CONTABIL SET
            MTMD_ESTCON_QTDE           = MTMD_ESTCON_QTDE - pMTMD_ESTLOC_QTDE,
            MTMD_ESTCON_DT_ATUALIZACAO = SYSDATE
            WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
            AND   CAD_MTMD_FILIAL_ID = DECODE(nFilial,4,1,nFilial);
         EXCEPTION WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,' QTDE '||TO_CHAR(pMTMD_ESTLOC_QTDE)||
                                           ' FILIAL '||TO_CHAR(nFilial)||chr(10)||chr(13)||
                                           ' SETOR  '||TO_CHAR(nSetorAlmox)||
                                           ' LOCAL '||TO_CHAR(nLocalAlmox)||
                                           ' ESTOQUE '||TO_CHAR(nLixo)||
                                            chr(10)||chr(13)||' ERRO '||sqlerrm);
         END;
       ELSE -- ESTORNA RESERVA DE ITEM
         UPDATE TB_MTMD_ESTOQUE_LOCAL SET
         MTMD_ESTLOC_QTDE = MTMD_ESTLOC_QTDE + pMTMD_ESTLOC_QTDE,
         MTMD_MOV_CONSUMO = NVL(MTMD_MOV_CONSUMO,0) - pMTMD_ESTLOC_QTDE, -- CONSUMO
         MTMD_ESTLOC_DATA = SYSDATE
         WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
         AND   CAD_MTMD_FILIAL_ID           = nFilial
         AND   CAD_UNI_ID_UNIDADE           = nUnidadeAlmox
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = nLocalAlmox
         AND   CAD_SET_ID                   = nSetorAlmox;
         -- RETIRA QTDE NA COLUNA DE RESERVA (DISPENSAC?O) DA UNIDADE ( ESTOQUE DE CONSUMO )
         UPDATE TB_MTMD_ESTOQUE_LOCAL SET
         MTMD_ESTLOC_QTDE_DISP = NVL(MTMD_ESTLOC_QTDE_DISP,0) - pMTMD_ESTLOC_QTDE,
         MTMD_ESTLOC_DATA = SYSDATE
         WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
         AND   CAD_MTMD_FILIAL_ID           = nFilial
         AND   CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO
         AND   CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO;
         --  AJUSTA ESTOQUE CONTABIL
         UPDATE TB_MTMD_ESTOQUE_CONTABIL SET
         MTMD_ESTCON_QTDE           = MTMD_ESTCON_QTDE + pMTMD_ESTLOC_QTDE,
         MTMD_ESTCON_DT_ATUALIZACAO = SYSDATE
         WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
         AND   CAD_MTMD_FILIAL_ID = DECODE(nFilial,4,1,nFilial);
       END IF;
       PRC_MTMD_ESTOQUE_PER_CONSUMO_U(pCAD_MTMD_ID,
                                      nFilial,
                                      nUnidadeAlmox,
                                      nLocalAlmox,
                                      nSetorAlmox,
                                      vPERCENTUAL);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
           IF (pEntrada = 0) THEN
                RAISE_APPLICATION_ERROR(-20000,' TENTATIVA DE MOVIMENTAC?O INDEVIDA (SAIDA) ');
           ELSE
                RAISE_APPLICATION_ERROR(-20000,' TENTATIVA DE MOVIMENTAC?O INDEVIDA (ENTRADA) ');
           END IF;
    END;
    -- SE SETOR DE ENTRADA JA TEVE INVENTARIO E O DE SAIDA N?O,
    -- OU VICE VERSA, INSERIR NA TABELA DE REGISTROS
    -- DE MOVIMENTAC?ES DURANTE INVENTARIO
    /*IF ((FNC_MTMD_SETOR_INVENTARIADO(nSetorAlmox, nFilial, 0) = 1 AND
         FNC_MTMD_SETOR_INVENTARIADO(vSETOR_ESTOQUE_CONSUMO, nFilial, 0) = 0) OR
        (FNC_MTMD_SETOR_INVENTARIADO(nSetorAlmox, nFilial, 0) = 0 AND
         FNC_MTMD_SETOR_INVENTARIADO(vSETOR_ESTOQUE_CONSUMO, nFilial, 0) = 1)) THEN
         INSERT INTO TB_MTMD_MOV_INVENTARIO VALUES( pCAD_MTMD_ID,
                                                    nFilial,
                                                    nSetorAlmox,
                                                    SYSDATE,
                                                    pCAD_MTMD_TPMOV_S,
                                                    pCAD_MTMD_SUBTP_S,
                                                    pMTMD_ESTLOC_QTDE,
                                                    pNewIdt);
    END IF;    */
END PRC_MTMD_MOV_BAIXA_CENT_DISP;