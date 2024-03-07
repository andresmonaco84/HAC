CREATE OR REPLACE FUNCTION FNC_MTMD_CONSUMO_MAT_MED
(
     pCAD_MTMD_PRIATI_ID TB_CAD_MTMD_MAT_MED.CAD_MTMD_PRIATI_ID%type := 0, -- Se n?o for referente a pedido padr?o, sempre enviar 0 neste parametro
     pCAD_MTMD_ID IN TB_MTMD_PEDIDO_PADRAO_ITENS.CAD_MTMD_ID%type := 0,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_PEDIDO_PADRAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_MTMD_PEDIDO_PADRAO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_SET_ID IN TB_MTMD_PEDIDO_PADRAO.CAD_SET_ID%type DEFAULT NULL,
     pCAD_MTMD_FILIAL_ID  IN TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID%TYPE,
     pDATA_INICIO in DATE,
     pDATA_FIM    IN DATE,
     pTIPO_RETORNO IN NUMBER
)
  RETURN  number IS
/********************************************************************
*    Func?o: fnc_mtmd_consumo_mat_med
*
*    Data Criacao: 	2009         Por: Ricardo
*    Data Alterac?o:05/07/2011   Por: Andre Souza Monaco
*         Alterac?o:Quando n?o achar produto, procurar Pedido Padr?o
*                   por principio ativo na busca do percentual       
*
*    Funcao: Retorna CONSUMO ( BAIXAS ) DA UNIDADE DO PERIODO PASSADO
*******************************************************************/    
retorno             NUMBER;
qtde                NUMBER;
nCAD_MTMD_ID        TB_CAD_MTMD_MAT_MED.CAD_MTMD_ID%type := 0;
vCAD_MTMD_PRIATI_ID TB_CAD_MTMD_MAT_MED.CAD_MTMD_PRIATI_ID%type;
vMTMD_ESTLOC_QTDE_FRACIONADA NUMBER;
--========================================================================================
-- 3 - TRANSFERENCIA
-- 6 - BAIXA POR PERDA/QUEBRA
-- 12 - APLICAC?O DIRETA/BAIXA AUTOMATICA ( SO EXISTE PARA O CENTRAIS DE DISPENSAC?O)
--
-- TIPO RETORNO
-- 0 = CONSUMO EFETIVO (11)
-- 1 = OUTRAS BAIXAS ( 3,6, 12 )
-- 2 = PERCENTUAL
-- CHAMADA: PRC_MTMD_ESTOQUE_LOCAL_PRODUTO
BEGIN
   -- Se n?o tem principio ativo, utiliza o proprio material de parametro
   -- Caso possua principio ativo, e porque e referente a pedido padr?o e
   -- neste caso o filtro e feito pelos similares
   vCAD_MTMD_PRIATI_ID := pCAD_MTMD_PRIATI_ID;
   IF (vCAD_MTMD_PRIATI_ID = 0) THEN
      nCAD_MTMD_ID := pCAD_MTMD_ID;
   END IF;
   IF ( pTIPO_RETORNO = 0 ) THEN
         -- CONSUMO EFETIVO
         SELECT  SUM( MTMD_MOV_QTDE ) CONSUMO
         INTO retorno
         FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTO,
              Tb_Cad_Mtmd_Mat_Med MATMED
         WHERE MOVIMENTO.CAD_MTMD_ID = MATMED.CAD_MTMD_ID
         AND ( nCAD_MTMD_ID = 0                      OR MOVIMENTO.CAD_MTMD_ID = nCAD_MTMD_ID)
         AND ( vCAD_MTMD_PRIATI_ID = 0               OR FNC_MTMD_PRINCIPIO_ATIVO (MOVIMENTO.CAD_MTMD_ID) = vCAD_MTMD_PRIATI_ID)
         AND ( pCAD_UNI_ID_UNIDADE           IS NULL OR MOVIMENTO.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE)
         AND ( pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR MOVIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
         AND ( pCAD_SET_ID                   IS NULL OR MOVIMENTO.CAD_SET_ID                   = pCAD_SET_ID)
         AND ( pCAD_MTMD_FILIAL_ID           IS NULL OR MOVIMENTO.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID )
         AND MOVIMENTO.CAD_MTMD_TPMOV_ID            = 2 -- SAIDA
         AND MOVIMENTO.CAD_MTMD_SUBTP_ID            IN (5, 8, 10, 11, 18, 22, 24, 25)
         AND MOVIMENTO.MTMD_MOV_DATA >= pDATA_INICIO
         AND MOVIMENTO.MTMD_MOV_DATA <= pDATA_FIM;
   ELSIF ( pTIPO_RETORNO = 1 ) THEN
         -- OUTRAS BAIXAS
         SELECT  SUM( MTMD_MOV_QTDE ) CONSUMO
         INTO retorno
         FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTO,
              Tb_Cad_Mtmd_Mat_Med MATMED
          WHERE MOVIMENTO.CAD_MTMD_ID = MATMED.CAD_MTMD_ID
         AND ( nCAD_MTMD_ID = 0 OR MOVIMENTO.CAD_MTMD_ID = nCAD_MTMD_ID)
         AND ( vCAD_MTMD_PRIATI_ID = 0 OR FNC_MTMD_PRINCIPIO_ATIVO (MOVIMENTO.CAD_MTMD_ID) = vCAD_MTMD_PRIATI_ID)
         AND ( pCAD_UNI_ID_UNIDADE           IS NULL OR MOVIMENTO.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE)
         AND ( pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR MOVIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
         AND ( pCAD_SET_ID                   IS NULL OR MOVIMENTO.CAD_SET_ID                   = pCAD_SET_ID)
         AND ( pCAD_MTMD_FILIAL_ID           IS NULL OR MOVIMENTO.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID )
         AND MOVIMENTO.CAD_MTMD_TPMOV_ID            IN (2) -- SAIDA
         AND MOVIMENTO.cad_mtmd_subtp_id            IN (3, 6, 12)
         AND MOVIMENTO.MTMD_MOV_DATA >= pDATA_INICIO
         AND MOVIMENTO.MTMD_MOV_DATA <= pDATA_FIM;
   ELSIF ( pTIPO_RETORNO = 2 ) THEN
      -- PERCENTUAL DE CONSUMO BASEADO NO PERIODO DO PEDIDO PADRAO
      IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
         SELECT NVL(SUM(ITENS.MTMD_PEDPAD_QTDE),0)
           INTO qtde
           FROM TB_MTMD_PEDIDO_PADRAO PADRAO,
                TB_MTMD_PEDIDO_PADRAO_ITENS ITENS,
                TB_CAD_MTMD_MAT_MED MATMED
           WHERE PADRAO.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
           AND   PADRAO.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
           AND   PADRAO.CAD_SET_ID                   = pCAD_SET_ID
           AND   PADRAO.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
           AND   ITENS.MTMD_PEDPAD_ID                = PADRAO.MTMD_PEDPAD_ID
           AND   ITENS.CAD_MTMD_ID                   = MATMED.CAD_MTMD_ID 
           AND   MATMED.CAD_MTMD_PRIATI_ID           = vCAD_MTMD_PRIATI_ID;
      ELSE
        BEGIN
           vCAD_MTMD_PRIATI_ID := FNC_MTMD_PRINCIPIO_ATIVO ( pCAD_MTMD_ID );
           retorno := 0;
           SELECT NVL(ITENS.mtmd_pedpad_qtde,0)
           INTO qtde
           FROM TB_MTMD_PEDIDO_PADRAO PADRAO,
                TB_MTMD_PEDIDO_PADRAO_ITENS ITENS,
                Tb_Cad_Mtmd_Mat_Med MATMED
           WHERE PADRAO.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE
           AND   PADRAO.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
           AND   PADRAO.cad_set_id                   = pCAD_SET_ID
           AND   PADRAO.cad_mtmd_filial_id           = pCAD_MTMD_FILIAL_ID
           AND   ITENS.mtmd_pedpad_id                = PADRAO.mtmd_pedpad_id
           --AND (nCAD_MTMD_ID = 0 OR ITENS.CAD_MTMD_ID = nCAD_MTMD_ID)
           --AND (pCAD_MTMD_PRIATI_ID = 0 OR MATMED.CAD_MTMD_PRIATI_ID = pCAD_MTMD_PRIATI_ID)
           AND   ITENS.CAD_MTMD_ID = pCAD_MTMD_ID
           AND   ITENS.CAD_MTMD_ID = MATMED.CAD_MTMD_ID;
        EXCEPTION WHEN NO_DATA_FOUND THEN
           BEGIN  
                 IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
                     retorno := 0;                                          
                     SELECT NVL(ITENS.mtmd_pedpad_qtde,0)
                     INTO qtde
                     FROM TB_MTMD_PEDIDO_PADRAO PADRAO,
                          TB_MTMD_PEDIDO_PADRAO_ITENS ITENS,
                          Tb_Cad_Mtmd_Mat_Med MATMED
                     WHERE PADRAO.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE
                     AND   PADRAO.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
                     AND   PADRAO.cad_set_id                   = pCAD_SET_ID
                     AND   PADRAO.cad_mtmd_filial_id           = pCAD_MTMD_FILIAL_ID
                     AND   ITENS.mtmd_pedpad_id                = PADRAO.mtmd_pedpad_id
                     --AND (nCAD_MTMD_ID = 0 OR ITENS.CAD_MTMD_ID = nCAD_MTMD_ID)
                     --AND (pCAD_MTMD_PRIATI_ID = 0 OR MATMED.CAD_MTMD_PRIATI_ID = pCAD_MTMD_PRIATI_ID)
                     --AND   ITENS.CAD_MTMD_ID = pCAD_MTMD_ID
                     AND   ITENS.CAD_MTMD_ID = MATMED.CAD_MTMD_ID 
                     AND   MATMED.CAD_MTMD_PRIATI_ID = vCAD_MTMD_PRIATI_ID
                     AND   ROWNUM = 1;
                 ELSE
                     return NULL;
                 END IF;
          EXCEPTION WHEN NO_DATA_FOUND THEN
                 return NULL;
          END;
        END;
      END IF;
      
      retorno := FLOOR(FNC_MTMD_EST_PADRAO_UNIDADE(vCAD_MTMD_PRIATI_ID,
                                                    nCAD_MTMD_ID,
                                                    pCAD_UNI_ID_UNIDADE,
                                                    pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                    pCAD_SET_ID,
                                                    pCAD_MTMD_FILIAL_ID,
                                                    NULL -- LOTE
                                                    ));
       -- adiciona produtos inteiros que foram fracionados para calcular o percentual certo
       -- VERIFICA SE EXISTE ITEM INTEIRO CONVERTIDO PARA FRACIONADO
       vMTMD_ESTLOC_QTDE_FRACIONADA := NVL(FNC_MTMD_ESTOQUE_FRACIONADO( vCAD_MTMD_PRIATI_ID,
                                                                        nCAD_MTMD_ID,
                                                                        pCAD_MTMD_FILIAL_ID,
                                                                        pCAD_UNI_ID_UNIDADE,
                                                                        pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                        pCAD_SET_ID ),0);
       retorno := retorno + vMTMD_ESTLOC_QTDE_FRACIONADA;
       IF ( retorno = qtde ) THEN
          retorno := null;
       else
         retorno := (( retorno/qtde )*100);
         retorno := 100-retorno;
         if ( retorno < 0 )   THEN
           retorno := null;
         END IF;
       end if;
   END IF;
   return retorno;
END;
 