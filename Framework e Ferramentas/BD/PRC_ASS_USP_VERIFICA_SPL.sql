CREATE OR REPLACE PROCEDURE "PRC_ASS_USP_VERIFICA_SPL" (pCAD_UNI_ID_UNIDADE           IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_UNI_ID_UNIDADE%TYPE,
                                                     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
                                                     pCAD_CNV_ID_CONVENIO          IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE,
                                                     pCAD_SPL_CD_SUB_PLANO         IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_CD_SUB_PLANO%TYPE DEFAULT NULL,
                                                     pCAD_SPL_DS_SUB_PLANO         IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_DS_SUB_PLANO%TYPE DEFAULT NULL,
                                                     io_cursor                     OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_ASS_USP_VERIFICA_SPL
  *
  *    Data Criacao: 04/05/2010  Por: Pedro
  *    Alteração:
  *
  *    Verifica se exige Sub-Plano
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  vCAD_SPL_ID NUMBER;
  vVERIFICA_CREDENCIAL VARCHAR2(1);
BEGIN

-- VERIFICA SE USA REGRA DE VALIDAÇÃO DE SUB-PLANO

BEGIN
   SELECT CAD_CNV_FL_VALIDA_SUBPLANOCRE
   INTO   vVERIFICA_CREDENCIAL
   FROM TB_CAD_CNV_CONVENIO CNV 
   WHERE  CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
   AND    CNV.CAD_CNV_FL_VALIDA_SUBPLANOCRE = 'S';
EXCEPTION WHEN NO_DATA_FOUND THEN 
          vVERIFICA_CREDENCIAL := 'N';
END;

IF ( vVERIFICA_CREDENCIAL = 'S' ) THEN 
   OPEN V_CURSOR FOR
   SELECT SPL.CAD_SPL_ID,
         SPL.CAD_SPL_CD_SUB_PLANO,
         SPL.CAD_SPL_DS_SUB_PLANO,
         SPL.CAD_CNV_ID_CONVENIO,
         SPL.CAD_SPL_FL_STATUS
   FROM TB_CAD_SPL_SUB_PLANO SPL
   WHERE  SPL.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
   AND (pCAD_SPL_CD_SUB_PLANO IS NULL OR SPL.CAD_SPL_CD_SUB_PLANO = pCAD_SPL_CD_SUB_PLANO)
   AND ROWNUM = 1;
ELSE

   -- NAO EXISTE VALIDAÇÃO DE SUB-PLANO, ENTAO APLICA REGRA DE UNIDADE/LOCAL
   IF (  pCAD_SPL_CD_SUB_PLANO IS NOT NULL ) THEN
      -- VERIFICA SE EXISTE SUB-PLANO CADASTRADO
    
      OPEN v_cursor FOR
      select SPL.CAD_SPL_ID,
         SPL.CAD_SPL_CD_SUB_PLANO,
         SPL.CAD_SPL_DS_SUB_PLANO,
         SPL.CAD_CNV_ID_CONVENIO,
         SPL.CAD_SPL_FL_STATUS
      from TB_ASS_USP_UNI_LAT_SUB_PLANO usp,
           TB_CAD_SPL_SUB_PLANO         spl,
           TB_CAD_CNV_CONVENIO          CNV
      where spl.cad_spl_id                 = usp.cad_spl_id
      AND SPL.CAD_CNV_ID_CONVENIO          = CNV.CAD_CNV_ID_CONVENIO
      AND CNV.CAD_CNV_ID_CONVENIO          = pCAD_CNV_ID_CONVENIO
      and USP.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
      AND USP.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
      AND SPL.CAD_SPL_CD_SUB_PLANO         = pCAD_SPL_CD_SUB_PLANO
      AND SPL.CAD_SPL_FL_STATUS            = 'A'
      AND USP.ASS_USP_FL_STATUS            = 'A';
   ELSE     
   -- io_cursor := v_cursor;
   
   -- if v_cursor%rowcount = 0 then
     --EXCEPTION WHEN NO_DATA_FOUND THEN
     BEGIN OPEN v_cursor FOR
     select SPL.CAD_SPL_ID,
            SPL.CAD_SPL_CD_SUB_PLANO,
            SPL.CAD_SPL_DS_SUB_PLANO,
            SPL.CAD_CNV_ID_CONVENIO,
            SPL.CAD_SPL_FL_STATUS
     FROM   TB_CAD_SPL_SUB_PLANO SPL
     WHERE  SPL.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
     AND (pCAD_SPL_CD_SUB_PLANO IS NULL OR SPL.CAD_SPL_CD_SUB_PLANO = pCAD_SPL_CD_SUB_PLANO)
     AND (pCAD_SPL_DS_SUB_PLANO IS NULL OR SPL.CAD_SPL_DS_SUB_PLANO LIKE pCAD_SPL_DS_SUB_PLANO)
     AND SPL.CAD_SPL_FL_STATUS = 'A';
     end; 
   END if;
END IF;   
  io_cursor := v_cursor;

end PRC_ASS_USP_VERIFICA_SPL;
