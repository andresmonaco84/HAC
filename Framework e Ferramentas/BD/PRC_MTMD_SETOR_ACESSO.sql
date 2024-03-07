CREATE OR REPLACE PROCEDURE PRC_MTMD_SETOR_ACESSO(
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MATMED_CONFIG.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MATMED_CONFIG.CAD_UNI_ID_UNIDADE%type,
     pCAD_SET_ID                   IN TB_MTMD_MATMED_CONFIG.CAD_SET_ID%type,
     pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,     
     pNewIdt                       OUT integer
) IS
  /********************************************************************
  *    Procedure: PRC_MTMD_SETOR_ACESSO
  *
  *    Data Criacao:  17/06/2010  Por: RICARDO COSTA
  *    Data Alteracao:            Por: 
  *         Alteração: 
  *  
  *    Funcao: VERIFICA SE SETOR TEM ACESSO AO PRODUTO SENDO MOVIMENTADO
  *
  *******************************************************************/
vCAD_MTMD_GRUPO_ID TB_CAD_MTMD_MAT_MED.CAD_MTMD_GRUPO_ID%type;
BEGIN
    IF (pCAD_SET_ID = 1372) THEN
      SELECT CAD_MTMD_GRUPO_ID INTO vCAD_MTMD_GRUPO_ID
        FROM TB_CAD_MTMD_MAT_MED
       WHERE CAD_MTMD_ID = pCAD_MTMD_ID;      
      IF (vCAD_MTMD_GRUPO_ID = 44) THEN
         pNewIdt := 1; 
         return;
      END IF;
    END IF;
    BEGIN
    SELECT 1
    INTO   pNewIdt
    FROM TB_MTMD_MATMED_CONFIG CONFIG,
         TB_CAD_MTMD_MAT_MED   MTMD
    WHERE CONFIG.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND   CONFIG.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
    AND   CONFIG.CAD_SET_ID                   = pCAD_SET_ID
    AND   MTMD.CAD_MTMD_ID                    = pCAD_MTMD_ID
    AND   CONFIG.CAD_MTMD_GRUPO_ID            = MTMD.CAD_MTMD_GRUPO_ID
    AND   CONFIG.CAD_MTMD_SUBGRUPO_ID         = MTMD.CAD_MTMD_SUBGRUPO_ID;
    EXCEPTION WHEN NO_DATA_FOUND THEN
       pNewIdt := 0;
    END;
END PRC_MTMD_SETOR_ACESSO;