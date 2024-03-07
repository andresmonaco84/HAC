CREATE OR REPLACE PROCEDURE PRC_MTMD_PEDIDO_PADRAO_ITENS_U
  (
     pCAD_MTMD_ID IN TB_MTMD_PEDIDO_PADRAO_ITENS.CAD_MTMD_ID%type,
     pMTMD_PEDPAD_ID IN TB_MTMD_PEDIDO_PADRAO_ITENS.MTMD_PEDPAD_ID%type,
     pMTMD_PEDPAD_QTDE IN TB_MTMD_PEDIDO_PADRAO_ITENS.MTMD_PEDPAD_QTDE%type default NULL,
     pMTMD_PEDPAD_PERCENT_RESSUP IN TB_MTMD_PEDIDO_PADRAO_ITENS.MTMD_PEDPAD_PERCENT_RESSUP%type default NULL
  )
  is
  /********************************************************************
  ATUALIZA ITENS DO PEDIDO PADRAO
  *******************************************************************/
     vCAD_LAT_ID_LOCAL_ATENDIMENTO TB_MTMD_PEDIDO_PADRAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
     vCAD_UNI_ID_UNIDADE           TB_MTMD_PEDIDO_PADRAO.CAD_UNI_ID_UNIDADE%type;
     vCAD_SET_ID                   TB_MTMD_PEDIDO_PADRAO.CAD_SET_ID%type;
     vCAD_MTMD_FILIAL_ID           TB_MTMD_PEDIDO_PADRAO.CAD_MTMD_FILIAL_ID%type;
     vPERCENTUAL                   NUMBER;
  begin
     -- ACERTA ESTOQUE ON-LINE
     BEGIN
       SELECT PEDIDO.CAD_LAT_ID_LOCAL_ATENDIMENTO,
              PEDIDO.CAD_UNI_ID_UNIDADE,
              PEDIDO.CAD_SET_ID,
              PEDIDO.CAD_MTMD_FILIAL_ID
       INTO  vCAD_LAT_ID_LOCAL_ATENDIMENTO,
             vCAD_UNI_ID_UNIDADE,
             vCAD_SET_ID,
             vCAD_MTMD_FILIAL_ID
       FROM TB_MTMD_PEDIDO_PADRAO        PEDIDO
       WHERE PEDIDO.mtmd_pedpad_ID = pMTMD_PEDPAD_ID;
       -- ATUALIZA ESTOQUE UNIDADE
       UPDATE TB_MTMD_ESTOQUE_LOCAL SET
       MTMD_PEDPAD_QTDE = pMTMD_PEDPAD_QTDE,
       MTMD_ID_ORIGINAL = NULL
       WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
       AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vCAD_LAT_ID_LOCAL_ATENDIMENTO
       AND   CAD_UNI_ID_UNIDADE           = vCAD_UNI_ID_UNIDADE
       AND   CAD_SET_ID                   = vCAD_SET_ID
       AND   CAD_MTMD_FILIAL_ID           = vCAD_MTMD_FILIAL_ID;
       -- ATUALIZA SIMILARES
       UPDATE TB_MTMD_ESTOQUE_LOCAL
          SET MTMD_ID_ORIGINAL = pCAD_MTMD_ID
        WHERE CAD_LAT_ID_LOCAL_ATENDIMENTO = vCAD_LAT_ID_LOCAL_ATENDIMENTO
        AND   CAD_UNI_ID_UNIDADE           = vCAD_UNI_ID_UNIDADE
        AND   CAD_SET_ID                   = vCAD_SET_ID
        AND   CAD_MTMD_FILIAL_ID           = vCAD_MTMD_FILIAL_ID 
        AND   CAD_MTMD_ID IN (SELECT MATMED.CAD_MTMD_ID
                                FROM TB_MTMD_ESTOQUE_LOCAL ESTOQUE,
                                     TB_CAD_MTMD_MAT_MED MATMED
                               WHERE ESTOQUE.CAD_MTMD_ID             = MATMED.CAD_MTMD_ID
                               AND   ESTOQUE.CAD_SET_ID              = vCAD_SET_ID
                               AND   ESTOQUE.CAD_MTMD_FILIAL_ID      = vCAD_MTMD_FILIAL_ID
                               AND   ESTOQUE.CAD_MTMD_ID             != pCAD_MTMD_ID
                               AND   MATMED.CAD_MTMD_PRIATI_ID       != 0                
                               AND   MATMED.CAD_MTMD_PRIATI_ID       = FNC_MTMD_PRINCIPIO_ATIVO(pCAD_MTMD_ID));
     EXCEPTION WHEN NO_DATA_FOUND THEN
        NULL;
     END;
    -- ====================================================================  
    UPDATE TB_MTMD_PEDIDO_PADRAO_ITENS
    SET
        MTMD_PEDPAD_QTDE = pMTMD_PEDPAD_QTDE,
        MTMD_PEDPAD_PERCENT_RESSUP = pMTMD_PEDPAD_PERCENT_RESSUP,
        MTMD_DT_ATUALIZACAO = SYSDATE
    WHERE
        CAD_MTMD_ID = pCAD_MTMD_ID
    AND MTMD_PEDPAD_ID = pMTMD_PEDPAD_ID;
         -- ATUALIZA PERCENTUAL DE CONSUMO        
           PRC_MTMD_ESTOQUE_PER_CONSUMO_U(  pCAD_MTMD_ID,
                                            vCAD_MTMD_FILIAL_ID,
                                            vCAD_UNI_ID_UNIDADE,
                                            vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                            vCAD_SET_ID,
                                            vPERCENTUAL);       
  end PRC_MTMD_PEDIDO_PADRAO_ITENS_U;
 