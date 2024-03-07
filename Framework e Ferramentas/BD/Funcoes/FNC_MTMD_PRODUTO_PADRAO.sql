CREATE OR REPLACE FUNCTION "FNC_MTMD_PRODUTO_PADRAO"
  (
     pCAD_MTMD_ID IN TB_MTMD_PEDIDO_PADRAO_ITENS.CAD_MTMD_ID%type,
     PCAD_MTMD_FILIAL_ID  IN TB_MTMD_PEDIDO_PADRAO.CAD_MTMD_FILIAL_ID%TYPE,
     pCAD_SET_ID IN TB_MTMD_PEDIDO_PADRAO.CAD_SET_ID%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_PEDIDO_PADRAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE IN TB_MTMD_PEDIDO_PADRAO.CAD_UNI_ID_UNIDADE%type
  )
  RETURN  NUMBER IS
  nQtdPadrao NUMBER;
 /***********************************************************************************************
*    Function: FNC_MTMD_PRODUTO_PADRAO
*
*    Data Criacao:   11/2009         Por: Ricardo Costa
*    Data Alteracao: 13/01/2010      Por: RICARDO cOSTA
*         Descrição: Busca estoque de consumo
*    Data Alteracao: 13/08/2010      Por: RICARDO cOSTA
*         Descrição: ATUALIZADO MIGRA 2
*    Data Alteracao: 16/08/2010      Por: RICARDO cOSTA
*         Descrição: ADICIONEI ENVIO DE E-MAIL QUANDO ENCOTNRAR MAIS QUE 1 PADRAO PARA SETOR
*
*    Funcao:   VERIFICA SE O PRODUTO É PADRAO NO SETOR E RETORNA QTDE PADRAO SE FOR O CASO
               SE RETORNAR ZERO NÃO É PRODUTO PADRÃO NO SETOR
*************************************************************************************************/
   vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
   vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
   vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
  nFilial NUMBER;
  -- CHAMADA:
  --  ESTOQUE_LOCAL_PRODUTO
  --  PRC_MTMD_REQ_ITEM_DISP_I
BEGIN
    nFilial := FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID );
    PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE,
                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                pCAD_SET_ID,
                                nFilial,
                                vUNIDADE_ESTOQUE_CONSUMO,
                                vLOCAL_ESTOQUE_CONSUMO,
                                vSETOR_ESTOQUE_CONSUMO
                               );
   BEGIN
     SELECT NVL(ITEM.MTMD_PEDPAD_QTDE,0) FL_PADRAO
     INTO  nQtdPadrao
     FROM TB_MTMD_PEDIDO_PADRAO       PADRAO,
          TB_MTMD_PEDIDO_PADRAO_ITENS ITEM
     WHERE PADRAO.CAD_MTMD_FILIAL_ID            = nFilial
     AND   PADRAO.cad_uni_id_unidade            = vUNIDADE_ESTOQUE_CONSUMO
     AND   PADRAO.cad_lat_id_local_atendimento  = vLOCAL_ESTOQUE_CONSUMO
     AND   PADRAO.cad_set_id                    = vSETOR_ESTOQUE_CONSUMO
     AND   ITEM.mtmd_pedpad_id                  = PADRAO.MTMD_PEDPAD_ID
     AND   ITEM.cad_mtmd_id                     = pCAD_MTMD_ID;
   EXCEPTION
      WHEN NO_DATA_FOUND THEN
         nQtdPadrao := NULL;
      /*WHEN TOO_MANY_ROWS THEN
       PRC_ENVIA_EMAIL('ricardo.costa@anacosta.com.br','ricardo.costa@anacosta.com.br',NULL,'[MATMED ERRO]',
                       'Retornou várias linhas na pesquisa de pedido padrao [FNC_MTMD_PRODUTO_PADRAO]');*/
   END;
   return nQtdPadrao;
END FNC_MTMD_PRODUTO_PADRAO;