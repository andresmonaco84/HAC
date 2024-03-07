CREATE OR REPLACE PROCEDURE PRC_MTMD_HISTORICO_NF_ESTOR_I
(
     pCAD_MTMD_ID IN TB_MTMD_HISTORICO_NF_ESTORNO.CAD_MTMD_ID%type,
     pCAD_MTMD_ID_ACERTO IN TB_MTMD_HISTORICO_NF_ESTORNO.CAD_MTMD_ID_ACERTO%type default NULL,
     pCAD_MTMD_FILIAL_ID IN TB_MTMD_HISTORICO_NF_ESTORNO.CAD_MTMD_FILIAL_ID%type,
     pMTMD_NR_NOTA IN TB_MTMD_HISTORICO_NF_ESTORNO.MTMD_NR_NOTA%type,
     pIDMOV IN TB_MTMD_HISTORICO_NF_ESTORNO.IDMOV%type,
     pMTMD_QTDE IN TB_MTMD_HISTORICO_NF_ESTORNO.MTMD_QTDE%type default NULL,     
     pDS_FORNECEDOR IN TB_MTMD_HISTORICO_NF_ESTORNO.DS_FORNECEDOR%type default NULL,
     pTP_MOVIMENTO IN TB_MTMD_HISTORICO_NF_ESTORNO.TP_MOVIMENTO%type default NULL,
     pNF_MOTIVO_ESTORNO IN TB_MTMD_HISTORICO_NF_ESTORNO.NF_MOTIVO_ESTORNO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_MTMD_HISTORICO_NF_ESTORNO.SEG_USU_ID_USUARIO%type,
     pSTATUS IN TB_MTMD_HISTORICO_NF_ESTORNO.STATUS%type,
     pPRECO_UNITARIO IN TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_PRECO_UNITARIO%type default NULL,
     pQTD_DEVOLUCAO_PARCIAL NUMBER default NULL,
     pMTMD_LOTEST_ID IN TB_MTMD_HISTORICO_NF_ESTORNO.MTMD_LOTEST_ID%type default NULL
)
is
/********************************************************************
*    Procedure: PRC_MTMD_HISTORICO_NF_ESTOR_I
*
*    Data Criacao: 	 14/05/2012   Por: Andre
*    Data Alterac?o: 03/09/2014   Por: Andre
*         Alterac?o: Inclusao de pQTD_DEVOLUCAO_PARCIAL e pPRECO_UNITARIO
*    Data Alterac?o: 03/06/2015   Por: Andre
*         Alterac?o: Inclusao de pMTMD_LOTEST_ID
*    Data Alterac?o: 25/10/2016   Por: Andre
*         Alterac?o: Barrar estorno de NF de Devolucao
*    Data Alterac?o: 07/06/2017   Por: Andre
*         Alterac?o: Excluir Lote quando houver, ao inves de zerar qtd.
*    Data Alterac?o: 25/10/2017   Por: Andre
*         Alterac?o: Atualizar Custo Medio
*
*    Funcao: Inserir log de estorno de NF, ja realizando a
*            movimentac?o no estoque
*******************************************************************/
MOV_ID number;
nIdEntrada number;
nQtdItensLote number := 0;
nUnidadeCompra number := 0;
nNovoSaldoLoteSetor number := 0;
vCAD_UNI_ID_UNIDADE           TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vCAD_LAT_ID_LOCAL_ATENDIMENTO TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vCAD_SET_ID                   TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
vMTMD_MOV_ID_REF              TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID_REF%type;
vIDSEQMOVRM                   TB_MTMD_HISTORICO_NOTA_FISCAL.IDSEQMOVRM%type default NULL;
vMTMD_CONTROLA_LOTE           TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_CONTROLA_LOTE%TYPE;
vCAD_MTMD_FL_CONTROLA_LOTE    TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_CONTROLA_LOTE%TYPE;
vMTMD_COD_LOTE                TB_MTMD_MOV_MOVIMENTACAO.MTMD_COD_LOTE%type;
vMTMD_MOV_SALDO_LOTE_SETOR    TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_SETOR%type;
vMTMD_MOV_SALDO_LOTE_TOTAL    TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_TOTAL%type;
vCAD_MTMD_GRUPO_ID            TB_CAD_MTMD_MAT_MED.CAD_MTMD_GRUPO_ID%TYPE;
vCAD_MTMD_SUBGRUPO_ID         TB_CAD_MTMD_MAT_MED.CAD_MTMD_SUBGRUPO_ID%TYPE;
vTP_MOV_CONSIGNADO            CONSTANT CHAR(6) := '1.2.48';
vTP_MOV_LAB                   CONSTANT CHAR(6) := '1.2.70';
PROCEDURE PRC_MTMD_ESTOQUE_MOVIMENTACAO( pTipoMov IN VARCHAR2,
                                         pCAD_UNI_ID_UNIDADE           IN OUT TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
                                         pCAD_LAT_ID_LOCAL_ATENDIMENTO IN OUT TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
                                         pCAD_SET_ID                   IN OUT TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type
                                         ) IS
BEGIN
   BEGIN
     -- BUSCA ALMOX POR TIPO DE MOVIMENTAC?O
      SELECT CCUSTO.CAD_SET_ID,
             CCUSTO.CAD_UNI_ID_UNIDADE,
             CCUSTO.CAD_LAT_ID_LOCAL_ATENDIMENTO
      INTO   pCAD_SET_ID,
             pCAD_UNI_ID_UNIDADE,
             pCAD_LAT_ID_LOCAL_ATENDIMENTO
      FROM TB_MTMD_MOV_CCUSTO CCUSTO
      WHERE CCUSTO.MTMD_TIPO_MOV_ENTRADA = pTipoMov;
    EXCEPTION WHEN NO_DATA_FOUND THEN
         --BUSCA ALMOX CENTRAL
         BEGIN
             SELECT SETOR.CAD_SET_ID,
                    SETOR.CAD_UNI_ID_UNIDADE,
                    SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
             INTO   pCAD_SET_ID,
                    pCAD_UNI_ID_UNIDADE,
                    pCAD_LAT_ID_LOCAL_ATENDIMENTO
             FROM TB_CAD_SET_SETOR SETOR
             WHERE SETOR.CAD_SET_ALMOX_CENTRAL = 1;
         EXCEPTION
           WHEN TOO_MANY_ROWS THEN
                RAISE_APPLICATION_ERROR(-20000,'SETOR: EXISTE MAIS QUE UM ESTOQUE CENTRAL CADASTRADO');
           WHEN NO_DATA_FOUND THEN
               RAISE_APPLICATION_ERROR(-20000,'SETOR NO_DATA_FOUND');
           WHEN OTHERS THEN
               RAISE_APPLICATION_ERROR(-20000,'SETOR '||sqlerrm);
         END;
   END;
END PRC_MTMD_ESTOQUE_MOVIMENTACAO;
begin
IF (pTP_MOVIMENTO IS NULL) THEN
   RAISE_APPLICATION_ERROR(-20000,'Nao permitido estorno de NF sem Tipo');
END IF;
IF (pTP_MOVIMENTO = '2.2.03') THEN
   RAISE_APPLICATION_ERROR(-20000,'Nao permitido estorno de NF de Devolucao');
END IF;
PRC_MTMD_ESTOQUE_MOVIMENTACAO( pTP_MOVIMENTO,
                               vCAD_UNI_ID_UNIDADE,
                               vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                               vCAD_SET_ID
                              );
IF (pTP_MOVIMENTO NOT IN (vTP_MOV_CONSIGNADO, vTP_MOV_LAB) AND
    NVL(FNC_MTMD_ESTOQUE_UNIDADE(pCAD_MTMD_ID,
                                 vCAD_UNI_ID_UNIDADE,
                                 vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 vCAD_SET_ID,
                                 pCAD_MTMD_FILIAL_ID,
                                 NULL),0) < pMTMD_QTDE) THEN
   RAISE_APPLICATION_ERROR(-20000,'Quantidade insuficiente no centro de dispensac?o para realizar este estorno');
ELSIF (pTP_MOVIMENTO IN (vTP_MOV_CONSIGNADO, vTP_MOV_LAB) AND NVL(pQTD_DEVOLUCAO_PARCIAL,0) > 0) THEN
   RAISE_APPLICATION_ERROR(-20000,'N?o pode haver devoluc?o parcial de Consignado por esta funcionalidade');
END IF;
SELECT H.MTMD_MOV_ID,    IDSEQMOVRM
  INTO vMTMD_MOV_ID_REF, vIDSEQMOVRM
  FROM TB_MTMD_HISTORICO_NOTA_FISCAL H
WHERE H.MTMD_NR_NOTA = pMTMD_NR_NOTA AND
      H.CAD_MTMD_ID = pCAD_MTMD_ID AND
      H.IDMOV = pIDMOV AND
      H.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID;

IF (NVL(pMTMD_LOTEST_ID, 0) != 0) THEN
  BEGIN
     SELECT L.MTMD_COD_LOTE
       INTO vMTMD_COD_LOTE
       FROM TB_MTMD_LOTEST_LOTE_ESTOQUE L
      WHERE L.MTMD_LOTEST_ID = pMTMD_LOTEST_ID
        AND L.CAD_MTMD_ID    = pCAD_MTMD_ID;

      IF (vMTMD_COD_LOTE IS NOT NULL) THEN
         vMTMD_CONTROLA_LOTE := FNC_MTMD_CONTROLA_LOTE(pCAD_MTMD_ID,pMTMD_LOTEST_ID,vCAD_MTMD_FL_CONTROLA_LOTE);
      END IF;
   EXCEPTION WHEN NO_DATA_FOUND THEN
       vMTMD_COD_LOTE := NULL;
   END;
END IF;

IF (NVL(pQTD_DEVOLUCAO_PARCIAL,0) = 0) THEN
  IF (NVL(pMTMD_LOTEST_ID, 0) != 0) THEN
    DELETE TB_MTMD_LOTEST_LOTE_ESTOQUE
       WHERE MTMD_LOTEST_ID = pMTMD_LOTEST_ID
         AND CAD_MTMD_ID = pCAD_MTMD_ID
         AND IDMOV = pIDMOV;

    SELECT COUNT(CAD_MTMD_ID)
      INTO nQtdItensLote
      FROM TB_MTMD_LOTEST_LOTE_ESTOQUE
     WHERE CAD_MTMD_ID = pCAD_MTMD_ID
       AND IDMOV = pIDMOV;
  END IF;

  IF (nQtdItensLote = 0) THEN
    DELETE TB_MTMD_HISTORICO_NOTA_FISCAL H
     WHERE H.MTMD_NR_NOTA = pMTMD_NR_NOTA AND
           H.CAD_MTMD_ID = pCAD_MTMD_ID AND
           H.IDMOV = pIDMOV;
  ELSE
    SELECT H.MTMD_QTDE / H.QTD_TOTAL_NOTA
      INTO nUnidadeCompra
      FROM TB_MTMD_HISTORICO_NOTA_FISCAL H
     WHERE H.MTMD_NR_NOTA = pMTMD_NR_NOTA AND
           H.CAD_MTMD_ID = pCAD_MTMD_ID AND
           H.IDMOV = pIDMOV AND ROWNUM = 1;

    UPDATE TB_MTMD_HISTORICO_NOTA_FISCAL H
       SET H.MTMD_QTDE = H.MTMD_QTDE - pMTMD_QTDE,
           H.QTD_TOTAL_NOTA = (H.MTMD_QTDE - pMTMD_QTDE) / nUnidadeCompra
     WHERE MTMD_NR_NOTA = pMTMD_NR_NOTA AND
           CAD_MTMD_ID = pCAD_MTMD_ID AND
           IDMOV = pIDMOV;
  END IF;
END IF;

IF (pTP_MOVIMENTO NOT IN (vTP_MOV_CONSIGNADO, vTP_MOV_LAB)) THEN
    UPDATE TB_MTMD_ESTOQUE_LOCAL E SET E.MTMD_ESTLOC_QTDE = E.MTMD_ESTLOC_QTDE - pMTMD_QTDE
    WHERE E.CAD_MTMD_ID = pCAD_MTMD_ID AND
          E.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
          E.CAD_SET_ID = vCAD_SET_ID;

    IF (NVL(pMTMD_LOTEST_ID, 0) != 0 AND vMTMD_COD_LOTE IS NOT NULL) THEN

        IF (vMTMD_CONTROLA_LOTE = 1 AND NVL(vCAD_MTMD_FL_CONTROLA_LOTE,0) = 1) THEN
          vMTMD_MOV_SALDO_LOTE_SETOR := FNC_MTMD_ESTOQUE_LOTE_SETOR(pCAD_MTMD_ID,
                                                                     vCAD_UNI_ID_UNIDADE,
                                                                     vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                     vCAD_SET_ID,
                                                                     pCAD_MTMD_FILIAL_ID,
                                                                     NULL, -- pMTMD_LOTEST_ID (ja tem o Cod Lote nesse momento)
                                                                     vMTMD_COD_LOTE,
                                                                     0 --So lote com controle
                                                                     );
          IF (vMTMD_MOV_SALDO_LOTE_SETOR < pMTMD_QTDE) THEN
             RAISE_APPLICATION_ERROR(-20020,' SALDO DO LOTE INSUFICIENTE PARA BAIXA !!!');
          ELSE
             UPDATE TB_MTMD_ESTOQUE_LOTE L
                SET L.MTMD_EST_QTDE = L.MTMD_EST_QTDE - pMTMD_QTDE,
                    L.MTMD_DATA_ATUALIZADO = SYSDATE
              WHERE L.CAD_MTMD_ID        = pCAD_MTMD_ID
                AND L.CAD_SET_ID         = vCAD_SET_ID
                AND L.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                AND L.MTMD_COD_LOTE      = vMTMD_COD_LOTE;
          END IF;
          vMTMD_MOV_SALDO_LOTE_TOTAL := FNC_MTMD_ESTOQUE_LOTE_SETOR(pCAD_MTMD_ID,
                                                                     NULL, --UNIDADE
                                                                     NULL, --LOCAL
                                                                     NULL, --SETOR
                                                                     pCAD_MTMD_FILIAL_ID,
                                                                     NULL, -- pMTMD_LOTEST_ID (ja tem o Cod Lote nesse momento)
                                                                     vMTMD_COD_LOTE, --COD_LOTE (nao tem nesse momento)
                                                                     1 --So lote com controle
                                                                     );
          nNovoSaldoLoteSetor := vMTMD_MOV_SALDO_LOTE_SETOR-pMTMD_QTDE;
        END IF;
    END IF;

    SELECT PROD.CAD_MTMD_GRUPO_ID, PROD.CAD_MTMD_SUBGRUPO_ID
      INTO vCAD_MTMD_GRUPO_ID,  vCAD_MTMD_SUBGRUPO_ID
      FROM TB_CAD_MTMD_MAT_MED PROD
     WHERE PROD.CAD_MTMD_ID = pCAD_MTMD_ID;

    SELECT SEQ_MTMD_MOVIMENTACAO.NEXTVAL INTO MOV_ID FROM DUAL;
    INSERT INTO TB_MTMD_MOV_MOVIMENTACAO
        (
           MTMD_MOV_ID,
           CAD_LAT_ID_LOCAL_ATENDIMENTO,
           CAD_UNI_ID_UNIDADE,
           CAD_SET_ID,
           CAD_MTMD_ID,
           CAD_MTMD_TPMOV_ID,
           CAD_MTMD_SUBTP_ID,
           MTMD_MOV_DATA,
           MTMD_MOV_QTDE,
           MTMD_MOV_FL_FINALIZADO,
           CAD_MTMD_FILIAL_ID,
           SEG_USU_ID_USUARIO,
           MTMD_MOV_FL_ESTORNO,
           MTMD_MOV_ID_REF,
           MTMD_MOV_ESTOQUE_ATUAL,
           MTMD_LOTEST_ID,
           CAD_MTMD_GRUPO_ID,
           CAD_MTMD_SUBGRUPO_ID,
           MTMD_CUSTO_MEDIO,
           MTMD_COD_LOTE,
           MTMD_MOV_SALDO_LOTE_SETOR,
           MTMD_MOV_SALDO_LOTE_TOTAL
        )
        VALUES
        (
          MOV_ID,
          vCAD_LAT_ID_LOCAL_ATENDIMENTO,
          vCAD_UNI_ID_UNIDADE,
          vCAD_SET_ID,
          pCAD_MTMD_ID,
          2,
          15, --BAIXA ESTORNO NF
          SYSDATE,
          pMTMD_QTDE,
          1,
          pCAD_MTMD_FILIAL_ID,
          pSEG_USU_ID_USUARIO,
          0,
          vMTMD_MOV_ID_REF,
          FNC_MTMD_ESTOQUE_UNIDADE(pCAD_MTMD_ID,
                                   vCAD_UNI_ID_UNIDADE,
                                   vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                   vCAD_SET_ID,
                                   pCAD_MTMD_FILIAL_ID,
                                   NULL),
          pMTMD_LOTEST_ID,
          vCAD_MTMD_GRUPO_ID,
          vCAD_MTMD_SUBGRUPO_ID,
          FNC_MTMD_PRECO_MEDIO(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID),
          vMTMD_COD_LOTE,
          nNovoSaldoLoteSetor,
          vMTMD_MOV_SALDO_LOTE_TOTAL
        );
    UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
      MTMD_MOV_FL_ESTORNO     = 1,
      MTMD_ID_USUARIO_ESTORNO = pSEG_USU_ID_USUARIO,
      MTMD_MOV_ID_REF         = MOV_ID
      WHERE MTMD_MOV_ID = vMTMD_MOV_ID_REF;
    UPDATE TB_MTMD_ESTOQUE_CONTABIL C
       SET C.MTMD_ESTCON_QTDE = C.MTMD_ESTCON_QTDE - pMTMD_QTDE,
           C.MTMD_CUSTO_MEDIO = FNC_MTMD_PRECO_MEDIO(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID)
    WHERE C.CAD_MTMD_ID = pCAD_MTMD_ID AND
          C.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID;
    UPDATE TB_MTMD_MOV_MES M
    SET M.MTMD_QTDE_ENTRADA = M.MTMD_QTDE_ENTRADA - pMTMD_QTDE,
        M.MTMD_MOV_SALDO = M.MTMD_MOV_SALDO - pMTMD_QTDE
    WHERE M.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
          AND M.CAD_MTMD_ID = pCAD_MTMD_ID
          AND M.MTMD_MOV_ANO = TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))
          AND M.MTMD_MOV_MES = TO_NUMBER(TO_CHAR(SYSDATE,'MM'));
ELSE --CONSIGADO (baixa automatica)
     UPDATE TB_MTMD_ESTOQUE_CONTABIL C
        SET C.MTMD_CUSTO_MEDIO = FNC_MTMD_PRECO_MEDIO(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID)
      WHERE C.CAD_MTMD_ID = pCAD_MTMD_ID AND C.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID;
     UPDATE TB_MTMD_MOV_MOVIMENTACAO
        SET MTMD_MOV_FL_ESTORNO     = 1,
            MTMD_ID_USUARIO_ESTORNO = pSEG_USU_ID_USUARIO
      WHERE MTMD_MOV_ID = vMTMD_MOV_ID_REF;
      UPDATE TB_MTMD_MOV_MOVIMENTACAO M
         SET M.CAD_MTMD_SUBTP_ID = 15
       WHERE M.MTMD_MOV_ID_REF = vMTMD_MOV_ID_REF;
      UPDATE TB_MTMD_MOV_MES M
      SET M.MTMD_QTDE_ENTRADA = M.MTMD_QTDE_ENTRADA - pMTMD_QTDE,
          M.MTMD_QTDE_SAIDA = M.MTMD_QTDE_SAIDA - pMTMD_QTDE
      WHERE M.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
            AND M.CAD_MTMD_ID = pCAD_MTMD_ID
            AND M.MTMD_MOV_ANO = TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))
            AND M.MTMD_MOV_MES = TO_NUMBER(TO_CHAR(SYSDATE,'MM'));
END IF;

INSERT INTO TB_MTMD_HISTORICO_NF_ESTORNO
(
       CAD_MTMD_ID,
       CAD_MTMD_ID_ACERTO,
       CAD_MTMD_FILIAL_ID,
       MTMD_NR_NOTA,
       IDMOV,
       MTMD_QTDE,
       DS_FORNECEDOR,
       TP_MOVIMENTO,
       NF_MOTIVO_ESTORNO,
       MTMD_MOV_ID,
       MTMD_MOV_DATA,
       SEG_USU_ID_USUARIO,
       STATUS,
       MTMD_LOTEST_ID
)
VALUES
(
	     pCAD_MTMD_ID,
	     pCAD_MTMD_ID_ACERTO,
	     pCAD_MTMD_FILIAL_ID,
	     pMTMD_NR_NOTA,
	     pIDMOV,
	     pMTMD_QTDE,
	     pDS_FORNECEDOR,
	     pTP_MOVIMENTO,
	     pNF_MOTIVO_ESTORNO,
	     MOV_ID,
	     SYSDATE,
	     pSEG_USU_ID_USUARIO,
       DECODE(NVL(pQTD_DEVOLUCAO_PARCIAL,0),0,pSTATUS,1),
       NVL(pMTMD_LOTEST_ID, 0)
);
IF (NVL(pQTD_DEVOLUCAO_PARCIAL,0) > 0) THEN --Insere a diferenca da qtd. da NF e do que foi devolvido
   PRC_MTMD_MOV_ENTRADA_UNIDADE( pCAD_MTMD_ID,
                                 pMTMD_LOTEST_ID,
                                 pCAD_MTMD_FILIAL_ID,
                                 NULL, --pMTMD_REQ_ID
                                 vCAD_UNI_ID_UNIDADE,
                                 vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 vCAD_SET_ID,
                                 1,
                                 1,
                                 pMTMD_QTDE-pQTD_DEVOLUCAO_PARCIAL,
                                 NULL,--pATD_ATE_ID
                                 NULL, --pATD_ATE_TP_PACIENTE,
                                 1, --pMTMD_MOV_FL_FINALIZADO,
                                 pSEG_USU_ID_USUARIO,
                                 NULL,--vMTMD_ID_ORIGINAL
                                 nIdEntrada);
   -- ATUALIZA REFENRENCIA DA MOVIMENTAC?O DE BAIXA APONTANDO PARA A  MOVIMENTAC?OD E ENTRADA
   UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
   MTMD_MOV_ID_REF = MOV_ID
   WHERE MTMD_MOV_ID = nIdEntrada;
   -- ATUALIZA REFERENCIA DA MOVIMENTAC?O DE ENTRADA APONTANDO PARA A MOVIMENTAC?O DE BAIXA
   UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
   MTMD_MOV_ID_REF = nIdEntrada
   WHERE MTMD_MOV_ID = MOV_ID;
END IF;
end PRC_MTMD_HISTORICO_NF_ESTOR_I;