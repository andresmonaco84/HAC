CREATE OR REPLACE PROCEDURE PRC_MTMD_REQUISICAO_ITEM_D
  (
     pCAD_MTMD_ID IN TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%type,
     pMTMD_REQ_ID IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_REQUISICAO_ITEM_D
  *
  *    Data Criacao: 	data da  cria???#o   Por: Nome do Analista
  *    Data Alteracao:	data da altera???#o  Por: Nome do Analista
  *
  *    Funcao: Descri???#o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  begin    
    DELETE TB_MTMD_REQUISICAO_ITEM
    WHERE  CAD_MTMD_ID = pCAD_MTMD_ID
    AND MTMD_REQ_ID    = pMTMD_REQ_ID;
    
    DELETE TB_MTMD_REQUISICAO_ITEM_KIT
    WHERE MTMD_REQ_ID = pMTMD_REQ_ID
    AND   CAD_MTMD_ID_REF = pCAD_MTMD_ID;
    
    UPDATE TB_MTMD_REQUISICAO_ITEM_KIT SET
    CAD_MTMD_KIT_ID_ITEM = NULL,
    CAD_MTMD_ID_KIT = NULL
    WHERE MTMD_REQ_ID = pMTMD_REQ_ID
    AND   NVL(CAD_MTMD_ID_KIT,0) = pCAD_MTMD_ID;
    
    -- COMMIT;
  end PRC_MTMD_REQUISICAO_ITEM_D;