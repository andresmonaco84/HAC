 create or replace procedure PRC_CAD_TAP_TP_ATRIB_PRODUTO_U
  (
     pCAD_TAP_TP_ATRIBUTO IN TB_CAD_TAP_TP_ATRIB_PRODUTO.CAD_TAP_TP_ATRIBUTO%type,
     pCAD_TAP_DS_ATRIBUTO IN TB_CAD_TAP_TP_ATRIB_PRODUTO.CAD_TAP_DS_ATRIBUTO%type,
     pCAD_TAP_FL_STATUS IN TB_CAD_TAP_TP_ATRIB_PRODUTO.CAD_TAP_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_TAP_TP_ATRIB_PRODUTO.SEG_USU_ID_USUARIO%type,
     pTIS_CDE_CD_CODIGO_DESPESA IN TB_CAD_TAP_TP_ATRIB_PRODUTO.TIS_CDE_CD_CODIGO_DESPESA%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TAP_TP_ATRIB_PRODUTO_U
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_TAP_TP_ATRIB_PRODUTO
    SET     
        CAD_TAP_DS_ATRIBUTO = pCAD_TAP_DS_ATRIBUTO,
        CAD_TAP_FL_STATUS = pCAD_TAP_FL_STATUS,
        CAD_TAP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        TIS_CDE_CD_CODIGO_DESPESA = pTIS_CDE_CD_CODIGO_DESPESA 
    WHERE
        CAD_TAP_TP_ATRIBUTO = pCAD_TAP_TP_ATRIBUTO;  
  end PRC_CAD_TAP_TP_ATRIB_PRODUTO_U;
