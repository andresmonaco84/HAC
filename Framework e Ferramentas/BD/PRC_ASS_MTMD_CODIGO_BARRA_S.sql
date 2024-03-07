CREATE OR REPLACE PROCEDURE PRC_ASS_MTMD_CODIGO_BARRA_S
(
   pCAD_MTMD_ID IN TB_ASS_MTMD_CODIGO_BARRA.CAD_MTMD_ID%type DEFAULT NULL,
   pCAD_MTMD_FILIAL_ID IN TB_ASS_MTMD_CODIGO_BARRA.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
   pMTMD_LOTEST_ID IN TB_ASS_MTMD_CODIGO_BARRA.MTMD_LOTEST_ID%type DEFAULT NULL,
   pMTM_CD_BARRA IN TB_ASS_MTMD_CODIGO_BARRA.MTM_CD_BARRA%type DEFAULT NULL,
   pSEG_ID_USUARIO_IMPRESSAO IN TB_ASS_MTMD_CODIGO_BARRA.SEG_ID_USUARIO_IMPRESSAO%type DEFAULT NULL, --Se diferente de null executar gravac?o do item caso necessario
   io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_MTMD_CODIGO_BARRA_S
* 
*    Data Criacao:   2009
*    Data Alteracao: 06/08/2014   Por: Andre
*         Alterac?o: Desativac?o de busca em RM e Legado, 
*                    adequac?o para o novo modelo de lotes e
*                    inclus?o e gerac?o de codigo
*    Data Alteracao: 16/09/2015   Por: Andre
*         Alterac?o: Desativacao oficial da no Legado
*
*    Funcao: Insere/Seleciona cod barra
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
vCAD_MTMD_ID     TB_ASS_MTMD_CODIGO_BARRA.CAD_MTMD_ID%type;
vCD_BARRA        TB_ASS_MTMD_CODIGO_BARRA.MTM_CD_BARRA%type := pMTM_CD_BARRA;
nFilial          TB_ASS_MTMD_CODIGO_BARRA.CAD_MTMD_FILIAL_ID%type := NULL;
FILIAL_HAC       CONSTANT NUMBER := 1;
FILIAL_CE        CONSTANT NUMBER := 4;
begin
  --Se n?o for passado codigo, e for passado usuario, lote, produto e filial, obter codigo ou incluir caso seja passado usuario e n?o exista ainda para o respectivo lote
  IF (pMTM_CD_BARRA IS NULL AND pMTMD_LOTEST_ID IS NOT NULL AND pCAD_MTMD_ID IS NOT NULL AND pCAD_MTMD_FILIAL_ID != FILIAL_CE) THEN
     BEGIN
       SELECT BARRA.CAD_MTMD_ID, BARRA.MTM_CD_BARRA, BARRA.CAD_MTMD_FILIAL_ID
       INTO   vCAD_MTMD_ID,      vCD_BARRA,          nFilial
       FROM TB_ASS_MTMD_CODIGO_BARRA BARRA
       WHERE BARRA.CAD_MTMD_ID        = pCAD_MTMD_ID
         AND BARRA.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
         AND BARRA.MTMD_LOTEST_ID     = pMTMD_LOTEST_ID;
     EXCEPTION WHEN NO_DATA_FOUND THEN        
        IF (pSEG_ID_USUARIO_IMPRESSAO IS NOT NULL) THEN
          SELECT LOTE.CAD_MTMD_ID, LOTE.CAD_MTMD_FILIAL_ID
            INTO vCAD_MTMD_ID,     nFilial
            FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LOTE
            WHERE LOTE.CAD_MTMD_ID         = pCAD_MTMD_ID
              AND LOTE.CAD_MTMD_FILIAL_ID  = pCAD_MTMD_FILIAL_ID
              AND LOTE.MTMD_LOTEST_ID      = pMTMD_LOTEST_ID;
       
          PRC_ASS_MTMD_CODIGO_BARRA_I(vCAD_MTMD_ID, nFilial, pMTMD_LOTEST_ID, FNC_MTMD_COD_BARRA_EAN13(pMTMD_LOTEST_ID, vCAD_MTMD_ID), pSEG_ID_USUARIO_IMPRESSAO);
          
          SELECT BARRA.MTM_CD_BARRA
            INTO vCD_BARRA
            FROM TB_ASS_MTMD_CODIGO_BARRA BARRA
           WHERE BARRA.CAD_MTMD_ID        = pCAD_MTMD_ID
             AND BARRA.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
             AND BARRA.MTMD_LOTEST_ID     = pMTMD_LOTEST_ID;
        END IF;
     END;  
  ELSIF (pMTM_CD_BARRA IS NOT NULL) THEN
    --MANTER PROVISORIAMENTE DURANTE O 1? MES DE IMPLANTAC?O A BUSCA NO LEGADO
    BEGIN
       -- AQUI N?O VERIFICA FILIAL, E SO PARA SABER SE EXISTE O CODIGO CADASTRADO
       SELECT	BARRA.CAD_MTMD_ID
       INTO   vCAD_MTMD_ID
       FROM TB_ASS_MTMD_CODIGO_BARRA BARRA
       WHERE BARRA.MTM_CD_BARRA = pMTM_CD_BARRA;
    EXCEPTION WHEN NO_DATA_FOUND THEN
       vCAD_MTMD_ID := NULL;
    END;
  END IF;
    
  IF ( pCAD_MTMD_FILIAL_ID IS NOT NULL AND nFilial IS NULL ) THEN
     IF ( pCAD_MTMD_FILIAL_ID = FILIAL_CE ) THEN
       nFilial := FILIAL_HAC;
     ELSIF (pCAD_MTMD_ID IS NOT NULL OR vCAD_MTMD_ID IS NOT NULL) THEN
       nFilial := FNC_MTMD_RETORNA_FILIAL(NVL(pCAD_MTMD_ID, vCAD_MTMD_ID), pCAD_MTMD_FILIAL_ID, NULL);
     ELSE
       nFilial := pCAD_MTMD_FILIAL_ID;
     END IF;
  END IF;
  
  OPEN v_cursor FOR
  SELECT	
     BARRA.CAD_MTMD_ID,
     BARRA.CAD_MTMD_FILIAL_ID,
     BARRA.MTMD_LOTEST_ID,
     BARRA.MTM_CD_BARRA
  FROM TB_ASS_MTMD_CODIGO_BARRA BARRA
  WHERE --(vCAD_MTMD_ID is null OR BARRA.CAD_MTMD_ID = vCAD_MTMD_ID)
         BARRA.MTM_CD_BARRA = vCD_BARRA
  AND   (pCAD_MTMD_FILIAL_ID is null OR BARRA.CAD_MTMD_FILIAL_ID = nFilial)
  AND   (pMTMD_LOTEST_ID is null OR BARRA.MTMD_LOTEST_ID = pMTMD_LOTEST_ID);
  io_cursor := v_cursor;    
  
end PRC_ASS_MTMD_CODIGO_BARRA_S;
 