CREATE OR REPLACE PROCEDURE PRC_MTMD_REQUISICAO_ITEM_S
  (
     pMTMD_REQ_ID IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%type DEFAULT NULL,
     pCAD_MTMD_ID IN TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%type DEFAULT NULL,
     pCAD_MTMD_PRESCRICAO_ID IN TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_PRESCRICAO_ID%type DEFAULT NULL,
     pATD_PME_ID IN TB_MTMD_REQUISICAO_ITEM.ATD_PME_ID%type DEFAULT NULL,
     pATD_MPM_ID IN TB_MTMD_REQUISICAO_ITEM.ATD_MPM_ID%type DEFAULT NULL,
     pORDENAR_ENDERECO IN NUMBER DEFAULT NULL, --0 ou 1
     pORDENAR_ENDERECO_02 IN NUMBER DEFAULT NULL, --0 ou 1
     -- pMTMD_REQ_FL_STATUS IN TB_MTMD_REQ_REQUISICAO.MTMD_REQ_FL_STATUS%type DEFAULT NULL,
     -- pMTM_TIPO_REQUISICAO IN TB_MTMD_REQ_REQUISICAO.MTM_TIPO_REQUISICAO%type DEFAULT NULL
     -- pCAD_UNI_ID_UNIDADE IN TB_MTMD_REQ_REQUISICAO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     -- pCAD_SET_ID IN TB_MTMD_REQ_REQUISICAO.CAD_SET_ID%type DEFAULT NULL,
     -- pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_REQ_REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_REQUISICAO_ITEM_S
  *
  *    Data Criacao:   2009          Por: Ricardo
  *    Data Alteracao: 13/01/2012    Por: Andre S. Monmaco
  *         Alteracao: Novo padr?o de query (string dinamica)
  *    Data Alteracao: 11/06/2013    Por: Andre S. Monmaco
  *         Alteracao: Mudanca da ordenac?o por mat/med
  *    Data Alteracao: 11/08/2015    Por: Andre S. Monmaco
  *         Alteracao: Adicao do campo CAD_MTMD_SUBGRUPO_ID na query
  *    Data Alteracao: 30/03/2016    Por: Andre S. Monmaco
  *         Alteracao: Adicao do patam. pCAD_MTMD_PRESCRICAO_ID
  *    Data Alteracao:  24/10/2017  Por: Andre S. Monaco
  *         Alteracao:  Adicao funcao SOUND ALIKE na descricao
  *
  *    Funcao: Listar itens de pedido
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
  begin
    V_WHERE := NULL;
    IF pMTMD_REQ_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ITEM.MTMD_REQ_ID = ' || pMTMD_REQ_ID; END IF;
    IF pCAD_MTMD_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ITEM.CAD_MTMD_ID = ' || pCAD_MTMD_ID; END IF;
    IF pCAD_MTMD_PRESCRICAO_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ITEM.CAD_MTMD_PRESCRICAO_ID = ' || pCAD_MTMD_PRESCRICAO_ID; END IF;
    IF pATD_PME_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ITEM.ATD_PME_ID = ' || pATD_PME_ID; END IF;
    IF pATD_MPM_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ITEM.ATD_MPM_ID = ' || pATD_MPM_ID; END IF;
    IF (NVL(pORDENAR_ENDERECO, 0) = 0 AND NVL(pORDENAR_ENDERECO_02, 0) = 0) THEN
       V_WHERE  := V_WHERE || ' ORDER BY PRODUTO.TIS_MED_CD_TABELAMEDICA DESC, PRODUTO.CAD_MTMD_NOMEFANTASIA';
    ELSIF (NVL(pORDENAR_ENDERECO, 0) = 1) THEN
       V_WHERE  := V_WHERE || ' ORDER BY PRODUTO.TIS_MED_CD_TABELAMEDICA DESC, PRODUTO.CAD_MTMD_ENDERECO_ALMOX_HAC, PRODUTO.CAD_MTMD_NOMEFANTASIA';
    ELSIF (NVL(pORDENAR_ENDERECO_02, 0) = 1) THEN
       V_WHERE  := V_WHERE || ' ORDER BY PRODUTO.TIS_MED_CD_TABELAMEDICA DESC, PRODUTO.CAD_MTMD_ENDERECO_ALMOX_ACS, PRODUTO.CAD_MTMD_NOMEFANTASIA';
    END IF;
    V_SELECT := '
    SELECT
       ITEM.MTMD_REQ_ID,
       ITEM.CAD_MTMD_ID,
       ITEM.MTMD_REQITEM_QTD_SOLICITADA,
       ITEM.MTMD_REQITEM_QTD_FORNECIDA,
       FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,
       PRODUTO.CAD_MTMD_UNID_VENDA_DS,
       FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID) CAD_MTMD_PRIATI_ID,
       PRODUTO.CAD_MTMD_SUBGRUPO_ID,
       ITEM.CAD_MTMD_PRESCRICAO_ID,
       ITEM.MTMD_REQ_DATA,
       REQ.ATD_ATE_ID,
       REQ.MTMD_REQ_FL_STATUS,
       REQ.MTMD_DATA_REQUISICAO,
       REQ.MTMD_DATA_DISPENSACAO,
       USU_REQUISICAO.SEG_USU_DS_NOME DS_USUARIO_REQUISICAO,
       PRODUTO.CAD_MTMD_FL_MAV,
       PRODUTO.CAD_MTMD_GRUPO_ID,
       PRODUTO.CAD_MTMD_ENDERECO_ALMOX_HAC,
       PRODUTO.CAD_MTMD_ENDERECO_ALMOX_ACS,
       REQ.CAD_SET_SETOR_FARMACIA,
       ITEM.CAD_MTMD_KIT_ID_ITEM,
       ITEM.ATD_PME_ID,
       ITEM.ATD_MPM_ID,
       ITEM.MTMD_REQITEM_CANCEL_JUST,
       ITEM.MTMD_REQ_VIA,
       ITEM.MTMD_FL_GELADEIRA,
       (SELECT CAD_MTMD_KIT_DSC
           FROM TB_CAD_MTMD_KIT
          WHERE CAD_MTMD_KIT_ID = ITEM.CAD_MTMD_KIT_ID_ITEM) CAD_MTMD_KIT_DSC_ITEM,
       ITEM.MTMD_QTD_KIT_MULTIPLICA
    FROM TB_MTMD_REQUISICAO_ITEM ITEM,
         TB_MTMD_REQ_REQUISICAO  REQ,
         TB_CAD_MTMD_MAT_MED     PRODUTO,
         TB_SEG_USU_USUARIO      USU_REQUISICAO
    WHERE REQ.MTMD_REQ_ID = ITEM.MTMD_REQ_ID AND
          PRODUTO.CAD_MTMD_ID = ITEM.CAD_MTMD_ID AND
          USU_REQUISICAO.SEG_USU_ID_USUARIO(+) = REQ.MTMD_ID_USUARIO_REQUISICAO ';
    OPEN v_cursor FOR
    V_SELECT || V_WHERE;
    io_cursor := v_cursor;
  end PRC_MTMD_REQUISICAO_ITEM_S;