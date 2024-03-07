CREATE OR REPLACE PROCEDURE "PRC_MTMD_ESTOQUE_LOCAL_PRODUTO" (
     pCAD_MTMD_ID                  IN TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_ID%type,
     pMTMD_LOTEST_ID               IN TB_MTMD_ESTOQUE_LOCAL.MTMD_LOTEST_ID%type DEFAULT NULL,
     pCAD_MTMD_FILIAL_ID           IN TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID%TYPE,
     pCAD_SET_ID                   IN TB_MTMD_ESTOQUE_LOCAL.CAD_SET_ID%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_ESTOQUE_LOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_ESTOQUE_LOCAL.CAD_UNI_ID_UNIDADE%type,
     pOrigem                       IN NUMBER := 0,     io_cursor                     OUT PKG_CURSOR.t_cursor
   )IS
    v_cursor PKG_CURSOR.t_cursor;
    /*
    */
 /***********************************************************************************************
*    Procedure: PRC_MTMD_ESTOQUE_LOCAL_PRODUTO
*
*    Data Criacao: 	 01/2010         Por: Ricardo Costa
*    Data Alteracao: 11/11/1111       Por: 
*         Descric?o: 
*    Data Alteracao:  24/10/2017  Por: Andre S. Monaco
*         Alteracao:  Adicao funcao SOUND ALIKE na descricao                       
*
*    Funcao: Retorna quantidade em estoque do produto passado como parametro
     CHAMADA DA TELA TRANSFERENCIA, ???
*************************************************************************************************/
   vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
   vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
   vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
   nFilial NUMBER := FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID);
BEGIN
      PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE,
                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                pCAD_SET_ID, 
                                nFilial,
                                vUNIDADE_ESTOQUE_CONSUMO,
                                vLOCAL_ESTOQUE_CONSUMO,
                                vSETOR_ESTOQUE_CONSUMO                                
                               );      
  OPEN v_cursor FOR
   SELECT ESTLOCAL.CAD_MTMD_ID,
          ESTLOCAL.MTMD_LOTEST_ID,
          ESTLOCAL.CAD_MTMD_FILIAL_ID,
          ESTLOCAL.CAD_UNI_ID_UNIDADE,
          ESTLOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO,
          ESTLOCAL.CAD_SET_ID,
          ESTLOCAL.MTMD_ESTLOC_QTDE_FRACIONADA,
          ESTLOCAL.MTMD_ESTLOC_FL_PADRAO,
          FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA, 
          PRODUTO.CAD_MTMD_UNID_VENDA_DS,
          PRODUTO.tis_med_cd_tabelamedica,
          PRODUTO.cad_mtmd_fl_fraciona,
         -- QTDE EM ESTOQUE, PRECISA RETORNAR A FUNC?O PARA GARANTIR QUE VAI CALCULAR
         -- PRODUTOS INTEIROS QUE FORAM FRACIONADOS
         FNC_MTMD_ESTOQUE_UNIDADE(ESTLOCAL.CAD_MTMD_ID,
                                  ESTLOCAL.CAD_UNI_ID_UNIDADE,
                                  ESTLOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                  ESTLOCAL.CAD_SET_ID,
                                  FNC_MTMD_RETORNA_FILIAL( ESTLOCAL.CAD_MTMD_ID, ESTLOCAL.CAD_MTMD_FILIAL_ID, pCAD_SET_ID),
                                  NULL -- LOTE
                                  ) MTMD_ESTLOC_QTDE,
         ESTLOCAL.MTMD_MOV_CONSUMO QTDE_CONSUMIDA,
         ESTLOCAL.MTMD_MOV_CONSUMO_OUTROS OUTROS_CONSUMOS,
         ESTLOCAL.MTMD_MOV_CONSUMO_PERC PERCENTUAL_CONSUMIDO,
         ESTLOCAL.MTMD_PEDPAD_QTDE MTMD_PEDPAD_QTDE,
         ESTLOCAL.MTMD_MOV_ESTOQUE_ATUAL,
         UNIDADE.Cad_Uni_Ds_Unidade,
         SETOR.CAD_SET_DS_SETOR,
         FILIAL.CAD_MTMD_FILIAL_DESCRICAO,
         ESTLOCAL.MTMD_MOV_DT_FORNECIMENTO MTMD_DT_RESSUPRIMENTO,
         (SELECT NVL(ITEM.MTMD_PEDPAD_PERCENT_RESSUP,0)
           FROM TB_MTMD_PEDIDO_PADRAO       PADRAO,
                 TB_MTMD_PEDIDO_PADRAO_ITENS ITEM
           -- WHERE PADRAO.CAD_MTMD_FILIAL_ID            = FNC_MTMD_RETORNA_FILIAL( ESTLOCAL.CAD_MTMD_ID, pCAD_MTMD_FILIAL_ID )
           WHERE PADRAO.CAD_MTMD_FILIAL_ID            = pCAD_MTMD_FILIAL_ID
           AND   PADRAO.cad_uni_id_unidade            = vUNIDADE_ESTOQUE_CONSUMO
           AND   PADRAO.cad_lat_id_local_atendimento  = vLOCAL_ESTOQUE_CONSUMO
           AND   PADRAO.cad_set_id                    = vSETOR_ESTOQUE_CONSUMO
           AND   ITEM.mtmd_pedpad_id                  = PADRAO.MTMD_PEDPAD_ID
           AND   ITEM.cad_mtmd_id                     = ESTLOCAL.CAD_MTMD_ID) MTMD_PEDPAD_PERCENT_RESSUP,
          FNC_MTMD_ESTOQUE_LOTE_SETOR(ESTLOCAL.CAD_MTMD_ID,
                                       ESTLOCAL.CAD_UNI_ID_UNIDADE,
                                       ESTLOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                       ESTLOCAL.CAD_SET_ID,
                                       ESTLOCAL.CAD_MTMD_FILIAL_ID,
                                       pMTMD_LOTEST_ID,
                                       NULL, --vMTMD_COD_LOTE
                                       1) MTMD_ESTLOC_QTDE_LOTE
   FROM TB_MTMD_ESTOQUE_LOCAL      ESTLOCAL,
        TB_CAD_MTMD_MAT_MED    PRODUTO,
        TB_CAD_UNI_UNIDADE         UNIDADE,
        TB_CAD_SET_SETOR           SETOR,
        TB_CAD_MTMD_FILIAL         FILIAL
   WHERE (pCAD_MTMD_ID is null OR                  ESTLOCAL.CAD_MTMD_ID                  = pCAD_MTMD_ID)
   AND   (pCAD_UNI_ID_UNIDADE IS NULL OR           ESTLOCAL.CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO)
   AND   (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ESTLOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO)
   AND   (pCAD_SET_ID IS NULL OR                   ESTLOCAL.CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO)
   AND   (pCAD_MTMD_FILIAL_ID IS NULL OR ESTLOCAL.CAD_MTMD_FILIAL_ID = nFilial)
   AND   ESTLOCAL.CAD_MTMD_ID        = PRODUTO.CAD_MTMD_ID
   AND   ESTLOCAL.CAD_UNI_ID_UNIDADE = UNIDADE.CAD_UNI_ID_UNIDADE
   AND   ESTLOCAL.CAD_SET_ID         = SETOR.CAD_SET_ID
   AND   ESTLOCAL.CAD_MTMD_FILIAL_ID = FILIAL.CAD_MTMD_FILIAL_ID
   ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA, UNIDADE.Cad_Uni_Ds_Unidade, FILIAL.CAD_MTMD_FILIAL_DESCRICAO, SETOR.CAD_SET_DS_SETOR;
    io_cursor := v_cursor;
    -- close v_cursor;
END PRC_MTMD_ESTOQUE_LOCAL_PRODUTO;