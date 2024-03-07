CREATE OR REPLACE PROCEDURE PRC_ASS_MTMD_CODIGO_BARRA_I
  (
     pCAD_MTMD_ID IN TB_ASS_MTMD_CODIGO_BARRA.CAD_MTMD_ID%type,
     pCAD_MTMD_FILIAL_ID IN TB_ASS_MTMD_CODIGO_BARRA.CAD_MTMD_FILIAL_ID%type,
     pMTMD_LOTEST_ID IN TB_ASS_MTMD_CODIGO_BARRA.MTMD_LOTEST_ID%type,
     pMTM_CD_BARRA IN TB_ASS_MTMD_CODIGO_BARRA.MTM_CD_BARRA%type,
     pSEG_ID_USUARIO_IMPRESSAO IN TB_ASS_MTMD_CODIGO_BARRA.SEG_ID_USUARIO_IMPRESSAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_MTMD_CODIGO_BARRA_I
  *
  *    Data Criacao:   2009
  *    Data Alteracao: 06/08/2014   Por: André
  *         Alteração: Adição do param. pSEG_ID_USUARIO_IMPRESSAO
  *
  *    Funcao: Insere cod barra
  *******************************************************************/

  begin

    INSERT INTO TB_ASS_MTMD_CODIGO_BARRA
    (
       CAD_MTMD_ID,
       CAD_MTMD_FILIAL_ID,
       MTMD_LOTEST_ID,
       MTM_CD_BARRA,
       SEG_ID_USUARIO_IMPRESSAO,
       ASS_MTMD_DT_ATUALIZACAO
    )
    VALUES
    (
       pCAD_MTMD_ID,
       pCAD_MTMD_FILIAL_ID,
       pMTMD_LOTEST_ID,
       substr(pMTM_CD_BARRA,1,60),
       pSEG_ID_USUARIO_IMPRESSAO,
       SYSDATE
    );
  EXCEPTION 
     WHEN DUP_VAL_ON_INDEX THEN
        NULL;
     WHEN OTHERS THEN
     RAISE_APPLICATION_ERROR(-20001,'COD. BARRA, PRODUTO '||TO_CHAR(pCAD_MTMD_ID)||SQLERRM);  
  end PRC_ASS_MTMD_CODIGO_BARRA_I;
 
