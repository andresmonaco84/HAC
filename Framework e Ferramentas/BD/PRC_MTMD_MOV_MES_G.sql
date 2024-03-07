create or replace procedure PRC_MTMD_MOV_MES_G
(
   pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_MES.CAD_MTMD_FILIAL_ID%type,
   pCAD_MTMD_ID IN TB_MTMD_MOV_MES.CAD_MTMD_ID%type,
   pMTMD_MOV_MES IN TB_MTMD_MOV_MES.MTMD_MOV_MES%type,
   pMTMD_MOV_ANO IN TB_MTMD_MOV_MES.MTMD_MOV_ANO%type,
   pMTMD_QTDE_ENTRADA IN TB_MTMD_MOV_MES.MTMD_QTDE_ENTRADA%type default NULL,
   pMTMD_QTDE_SAIDA IN TB_MTMD_MOV_MES.MTMD_QTDE_SAIDA%type default NULL
)
is
/********************************************************************
*    Procedure: PRC_MTMD_MOV_MES_G
*
*    Data Criacao:   24/02/2011   Por: Andre Souza Monaco
*    Data Alteracao: 27/09/2011   Por: Andre Souza Monaco
*         Alteracao: Adição do campo MTMD_MOV_SALDO
*
*    Funcao: Grava(insert ou update) na TB_MTMD_MOV_MES
*******************************************************************/
begin
  BEGIN
    INSERT INTO TB_MTMD_MOV_MES
    (
       CAD_MTMD_FILIAL_ID,
       CAD_MTMD_ID,
       MTMD_MOV_MES,
       MTMD_MOV_ANO,
       MTMD_QTDE_ENTRADA,
       MTMD_QTDE_SAIDA,
       MTMD_MOV_SALDO,
       MTMD_DATA_ATUALIZACAO
    )
    VALUES
    (
      pCAD_MTMD_FILIAL_ID,
      pCAD_MTMD_ID,
      pMTMD_MOV_MES,
      pMTMD_MOV_ANO,
      pMTMD_QTDE_ENTRADA,
      pMTMD_QTDE_SAIDA,
      --FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID),
      FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID)+pMTMD_QTDE_ENTRADA-pMTMD_QTDE_SAIDA,
      SYSDATE
    );
  EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
        UPDATE TB_MTMD_MOV_MES
        SET
            MTMD_QTDE_ENTRADA     = MTMD_QTDE_ENTRADA + pMTMD_QTDE_ENTRADA,
            MTMD_QTDE_SAIDA       = MTMD_QTDE_SAIDA + pMTMD_QTDE_SAIDA,
            --MTMD_MOV_SALDO        = FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID),
            --MTMD_MOV_SALDO        = MTMD_MOV_SALDO+pMTMD_QTDE_ENTRADA-pMTMD_QTDE_SAIDA,
            MTMD_MOV_SALDO        = FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID)+pMTMD_QTDE_ENTRADA-pMTMD_QTDE_SAIDA,
            MTMD_DATA_ATUALIZACAO = SYSDATE
        WHERE
            CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
        AND CAD_MTMD_ID        = pCAD_MTMD_ID
        AND MTMD_MOV_ANO       = pMTMD_MOV_ANO
        AND MTMD_MOV_MES       = pMTMD_MOV_MES;
  END;
end PRC_MTMD_MOV_MES_G;
