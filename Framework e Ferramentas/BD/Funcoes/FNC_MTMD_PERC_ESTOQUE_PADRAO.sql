CREATE OR REPLACE FUNCTION "FNC_MTMD_PERC_ESTOQUE_PADRAO" (  pCAD_MTMD_PRIATI_ID TB_CAD_MTMD_MAT_MED.CAD_MTMD_PRIATI_ID%type,
     pCAD_MTMD_ID IN TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
     pCAD_MTMD_FILIAL_ID  IN TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID%TYPE,
     pMTMD_LOTEST_ID IN TB_MTMD_ESTOQUE_LOCAL.MTMD_LOTEST_ID%type,
     pMTMD_PEDPAD_QTDE IN TB_MTMD_PEDIDO_PADRAO_ITENS.MTMD_PEDPAD_QTDE%type
   )
  RETURN  NUMBER IS
nTotal NUMBER;
nQtdEstoque NUMBER;
--========================================================================================
-- RETORNA PORCENTAGEM EXISTENTE NO ESTOQUE REFERENTE A QTD. PADRÃO - USADA NA TELA DE PEDIDO PADRÃO
--========================================================================================
BEGIN
    nQtdEstoque := FNC_MTMD_EST_PADRAO_UNIDADE(pCAD_MTMD_PRIATI_ID,
                                               pCAD_MTMD_ID,
                                               pCAD_UNI_ID_UNIDADE,
                                               pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                               pCAD_SET_ID, 
                                               FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID ),
                                               pMTMD_LOTEST_ID
                                               );
                                               
    nTotal := ( nQtdEstoque * 100  ) / pMTMD_PEDPAD_QTDE;   

    RETURN FLOOR(nTotal) ;
END;
 
