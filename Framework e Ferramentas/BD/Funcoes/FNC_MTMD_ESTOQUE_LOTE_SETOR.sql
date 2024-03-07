CREATE OR REPLACE FUNCTION FNC_MTMD_ESTOQUE_LOTE_SETOR (
pCAD_MTMD_ID                  IN TB_MTMD_ESTOQUE_LOTE.CAD_MTMD_ID%type,
pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
pCAD_SET_ID                   IN TB_CAD_SET_SETOR.CAD_SET_ID%type DEFAULT NULL,
pCAD_MTMD_FILIAL_ID           IN TB_MTMD_ESTOQUE_LOTE.CAD_MTMD_FILIAL_ID%TYPE DEFAULT NULL,
pMTMD_LOTEST_ID               IN TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_LOTEST_ID%type DEFAULT NULL,
pMTMD_COD_LOTE                IN  TB_MTMD_ESTOQUE_LOTE.MTMD_COD_LOTE%type DEFAULT NULL,
pVERIFICA_SO_CONTROLE         IN NUMBER DEFAULT 0 -- 0 / 1 (NAO / SIM) Verifica apenas saldo de lote que entrou com controle
) RETURN  NUMBER IS
nTotal NUMBER := 0;
vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
vMTMD_COD_LOTE             TB_MTMD_ESTOQUE_LOTE.MTMD_COD_LOTE%type := pMTMD_COD_LOTE;
 /***********************************************************************************************
*    Function: FNC_MTMD_ESTOQUE_LOTE_SETOR
*
*    Data Criacao:   02/2018         Por: Andre
*
*    Funcao: RETORNA SALDO EM ESTOQUE DO PRODUTO DO RESPECTIVO LOTE
*      OBS.: Caso nao passe o setor como parametro, retorna o estoque contabil total do lote
*************************************************************************************************/

BEGIN

  IF (pMTMD_COD_LOTE IS NULL AND NOT pMTMD_LOTEST_ID IS NULL) THEN
    SELECT L.MTMD_COD_LOTE
      INTO vMTMD_COD_LOTE
      FROM TB_MTMD_LOTEST_LOTE_ESTOQUE L
     WHERE L.MTMD_LOTEST_ID = pMTMD_LOTEST_ID
       AND L.CAD_MTMD_ID    = pCAD_MTMD_ID;
  END IF;

  IF (pCAD_SET_ID IS NOT NULL) THEN
    -- BUSCA ESTOQUE DE CONSUMO
    PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE,
                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                pCAD_SET_ID,
                                pCAD_MTMD_FILIAL_ID,
                                vUNIDADE_ESTOQUE_CONSUMO,
                                vLOCAL_ESTOQUE_CONSUMO,
                                vSETOR_ESTOQUE_CONSUMO
                               );                               
    IF (vMTMD_COD_LOTE IS NOT NULL) THEN
      BEGIN
        SELECT ESTOQUE.MTMD_EST_QTDE
          INTO nTotal
          FROM TB_MTMD_ESTOQUE_LOTE ESTOQUE
         WHERE ESTOQUE.CAD_MTMD_ID         = pCAD_MTMD_ID
         AND   ESTOQUE.CAD_SET_ID          = vSETOR_ESTOQUE_CONSUMO
         AND   ESTOQUE.CAD_MTMD_FILIAL_ID  = pCAD_MTMD_FILIAL_ID
         AND   ESTOQUE.MTMD_COD_LOTE       = vMTMD_COD_LOTE
         AND   (NVL(pVERIFICA_SO_CONTROLE,0) = 0 OR 
                FNC_MTMD_CONTROLA_LOTE_COD(ESTOQUE.CAD_MTMD_ID, ESTOQUE.MTMD_COD_LOTE) = 1);
      EXCEPTION WHEN NO_DATA_FOUND THEN
         nTotal := 0;  
      END;
    END IF;
  ELSIF (vMTMD_COD_LOTE IS NOT NULL) THEN
    SELECT NVL(SUM(ESTOQUE.MTMD_EST_QTDE),0)
      INTO nTotal
      FROM TB_MTMD_ESTOQUE_LOTE ESTOQUE
     WHERE ESTOQUE.CAD_MTMD_ID         = pCAD_MTMD_ID
     AND   (pCAD_MTMD_FILIAL_ID IS NULL OR ESTOQUE.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
     AND   ESTOQUE.MTMD_COD_LOTE       = vMTMD_COD_LOTE
     AND   (NVL(pVERIFICA_SO_CONTROLE,0) = 0 OR 
            FNC_MTMD_CONTROLA_LOTE_COD(ESTOQUE.CAD_MTMD_ID, ESTOQUE.MTMD_COD_LOTE) = 1);  
  END IF;

  RETURN nTotal ;
END FNC_MTMD_ESTOQUE_LOTE_SETOR;