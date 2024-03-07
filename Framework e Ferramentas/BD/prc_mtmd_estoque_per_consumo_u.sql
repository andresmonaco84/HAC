CREATE OR REPLACE PROCEDURE PRC_MTMD_ESTOQUE_PER_CONSUMO_U
(
     pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
--     pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type DEFAULT NULL,
     pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
     pPERCENTUAL                   OUT NUMBER     )
   IS
/********************************************************************
  *    Procedure: prc_mtmd_estoque_per_consumo_u
  *
  *    Data Criacao:    2009  Por: Ricardo Costa
  *    Data Alteracao:  16/03/2011  Por: Andre S. Monaco
  *         Alteracao:  N?o estava atualizando correto quando um similar estava no padr?o
  *    Data Alteracao:  10/09/2015  Por: Andre S. Monaco
  *         Alteracao:  Quando centro dispensação somar padrao dos similares e enviar PA pro consumo 
  *
  *    Funcao: ATUALIZA PERCENTUAL DE CONSUMO DO PRODUTO NO ESTOQUE DA UNIDADE
  *
  *******************************************************************/
nPercConsumo      NUMBER;
vFL_SUBSTALMOX_OK TB_CAD_SET_SETOR.CAD_SET_FL_SUBSTALMOX_OK%TYPE;
vMTMD_ID_ORIGINAL TB_MTMD_ESTOQUE_LOCAL.MTMD_ID_ORIGINAL%TYPE;
vPRIATI_ID                 TB_CAD_MTMD_MAT_MED.CAD_MTMD_PRIATI_ID%type := 0;
vMTMD_PEDPAD_QTDE NUMBER;
BEGIN       
   nPercConsumo := NULL;
              
   SELECT DECODE(CAD_SET_ALMOX_CENTRAL, 1, 'S', NVL(CAD_SET_FL_SUBSTALMOX_OK,'N'))
   INTO   vFL_SUBSTALMOX_OK
   FROM   TB_CAD_SET_SETOR
   WHERE CAD_SET_ID = pCAD_SET_ID;
       
   -- VERIFICA SE E SIMILAR OU ORIGINAL DO ESTOQUE PADRAO
   BEGIN
      SELECT NVL(MTMD_ID_ORIGINAL,0)
      INTO   vMTMD_ID_ORIGINAL
      FROM   TB_MTMD_ESTOQUE_LOCAL
      WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
      AND   CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
      AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
      AND   CAD_SET_ID                   = pCAD_SET_ID
      AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      vMTMD_ID_ORIGINAL := 0;
   END;
   IF (vFL_SUBSTALMOX_OK = 'S') THEN
     SELECT NVL(CAD_MTMD_PRIATI_ID, 0)
       INTO   vPRIATI_ID
       FROM   TB_CAD_MTMD_MAT_MED 
       WHERE CAD_MTMD_ID = pCAD_MTMD_ID;
           
     SELECT NVL(SUM(ITENS.MTMD_PEDPAD_QTDE),0)
       INTO vMTMD_PEDPAD_QTDE
       FROM TB_MTMD_PEDIDO_PADRAO PADRAO,
            TB_MTMD_PEDIDO_PADRAO_ITENS ITENS,
            TB_CAD_MTMD_MAT_MED MATMED
       WHERE PADRAO.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
       AND   PADRAO.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
       AND   PADRAO.CAD_SET_ID                   = pCAD_SET_ID
       AND   PADRAO.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
       AND   ITENS.MTMD_PEDPAD_ID                = PADRAO.MTMD_PEDPAD_ID
       AND   ITENS.CAD_MTMD_ID                   = MATMED.CAD_MTMD_ID 
       AND   MATMED.CAD_MTMD_PRIATI_ID           = vPRIATI_ID;       
   ELSE
     IF ( vMTMD_ID_ORIGINAL != 0 ) THEN
        -- E SIMILAR VERIFICA SE ORIGINAL E PADRAO
        vMTMD_PEDPAD_QTDE := NVL(FNC_MTMD_PRODUTO_PADRAO ( vMTMD_ID_ORIGINAL,
                                                       pCAD_MTMD_FILIAL_ID,
                                                       pCAD_SET_ID,
                                                       pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                       pCAD_UNI_ID_UNIDADE
                                                      ),0);
     END IF;
     IF ( vMTMD_PEDPAD_QTDE IS NULL OR vMTMD_PEDPAD_QTDE = 0 ) THEN
        -- SE N?O E SIMILAR OU N?O ENCONTROU NA CONDIC?O ACIMA, VERIFICA SE E PADRAO
        vMTMD_PEDPAD_QTDE := NVL(FNC_MTMD_PRODUTO_PADRAO ( pCAD_MTMD_ID,
                                                       pCAD_MTMD_FILIAL_ID,
                                                       pCAD_SET_ID,
                                                       pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                       pCAD_UNI_ID_UNIDADE
                                                      ),0);
     END IF;
   END IF;
   IF ( vMTMD_PEDPAD_QTDE > 0 ) THEN
      -- E PADRAO, ATUALIZA PERCENTUAL DO PRODUTO ORIGINAL DO ESTOQUER PADRAO, SE EXISTIR
      IF ( vMTMD_ID_ORIGINAL != 0 ) THEN
          -- E SIMILAR BUSCA PERCENTUAL DE CONSUMO DO ORIGINAL
          nPercConsumo := FNC_MTMD_CONSUMO_MAT_MED(vPRIATI_ID,
                                                   vMTMD_ID_ORIGINAL,
                                                   pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                   pCAD_UNI_ID_UNIDADE,
                                                   pCAD_SET_ID,
                                                   pCAD_MTMD_FILIAL_ID,
                                                   FNC_MTMD_DATA_ULT_FORNECIMENTO( vMTMD_ID_ORIGINAL,
                                                                                   pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                                   pCAD_UNI_ID_UNIDADE,
                                                                                   pCAD_SET_ID,
                                                                                   pCAD_MTMD_FILIAL_ID),
                                                    SYSDATE,
                                                    2 -- PERCENTUAL CONSUMO EFETIVO
                                                    );              
       END IF;
       IF ( nPercConsumo IS NULL ) THEN
          -- SE N?O E SIMILAR OU N?O ENCONTROU NA CONDIC?O ACIMA, BUSCA PERCENTUAL DE CONSUMO DELE MESMO
          nPercConsumo := FNC_MTMD_CONSUMO_MAT_MED(vPRIATI_ID,
                                                   pCAD_MTMD_ID,
                                                   pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                   pCAD_UNI_ID_UNIDADE,
                                                   pCAD_SET_ID,
                                                   pCAD_MTMD_FILIAL_ID,
                                                   FNC_MTMD_DATA_ULT_FORNECIMENTO( pCAD_MTMD_ID,
                                                                                   pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                                   pCAD_UNI_ID_UNIDADE,
                                                                                   pCAD_SET_ID,
                                                                                   pCAD_MTMD_FILIAL_ID),
                                                    SYSDATE,
                                                    2 -- PERCENTUAL CONSUMO EFETIVO
                                                    );
          IF (NVL(vMTMD_ID_ORIGINAL,0) = 0) THEN vMTMD_ID_ORIGINAL := pCAD_MTMD_ID; END IF;
       END IF;
       -- ATUALIZA PERCENTUAL DE CONSUMO
       UPDATE TB_MTMD_ESTOQUE_LOCAL SET
       MTMD_MOV_CONSUMO_PERC    = nPercConsumo -- PERCENTUAL DE CONSUMO
       WHERE CAD_MTMD_ID                  = vMTMD_ID_ORIGINAL
       AND   CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
       AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
       AND   CAD_SET_ID                   = pCAD_SET_ID
       AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID;
       IF (vFL_SUBSTALMOX_OK = 'S' AND NVL(vMTMD_ID_ORIGINAL,0) != pCAD_MTMD_ID) THEN
             UPDATE TB_MTMD_ESTOQUE_LOCAL SET
             MTMD_MOV_CONSUMO_PERC    = nPercConsumo -- PERCENTUAL DE CONSUMO
             WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
             AND   CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
             AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
             AND   CAD_SET_ID                   = pCAD_SET_ID
             AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID;  
       END IF;
   END IF;
   pPERCENTUAL := nPercConsumo;
END; -- Procedure
 