CREATE OR REPLACE PROCEDURE "PRC_CAD_MTMD_SIMILAR_I"
  (
     pCAD_MTMD_PRIATI_ID IN OUT TB_CAD_MTMD_SIMILAR.CAD_MTMD_PRIATI_ID%type,
     pCAD_MTMD_ID IN TB_CAD_MTMD_SIMILAR.CAD_MTMD_ID%type,
     pCAD_FL_ATIVO IN TB_CAD_MTMD_SIMILAR.CAD_FL_ATIVO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_MTMD_SIMILAR.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MTMD_SIMILAR_I
  *
  *    Data Criacao:  04/05/2009   Por: Andre S. Monaco
  *    Data Alterac?o:30/05/2011   Por: Andre S. Monaco
  *         Alterac?o:Inclus?o da regra "Se for novo, busca um que n?o esteja sendo usado"
  *    Data Alterac?o:27/03/2015   Por: Andre S. Monaco
  *         Alterac?o:Atualizacao da TB_CAD_MTMD_MAT_MED  
  *
  *    Funcao: Grava similar
  *******************************************************************/
  vCAD_MTMD_PRIATI_ID TB_CAD_MTMD_SIMILAR.CAD_MTMD_PRIATI_ID%type := pCAD_MTMD_PRIATI_ID;
  begin
    --Inativa produto se ele ja existir para manter o log
    PRC_CAD_MTMD_SIMILAR_D (pCAD_MTMD_PRIATI_ID, pCAD_MTMD_ID, pSEG_USU_ID_USUARIO);
    --Se for novo, busca um que n?o esteja sendo usado
    IF (NVL(vCAD_MTMD_PRIATI_ID, 0) = 0) THEN
       select p.cad_mtmd_priati_id 
         into vCAD_MTMD_PRIATI_ID
         from tb_cad_mtmd_priati_princ_ativo p 
        where p.cad_mtmd_priati_id not in (select s.cad_mtmd_priati_id from tb_cad_mtmd_similar s) and
              p.cad_mtmd_priati_id not in (select s.cad_mtmd_priati_id from tb_cad_mtmd_mat_med s)
          and rownum = 1;
    END IF;
    INSERT INTO TB_CAD_MTMD_SIMILAR
    (
       CAD_MTMD_PRIATI_ID,
       CAD_MTMD_ID,
       CAD_FL_ATIVO,
       CAD_MTMD_DT_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
      vCAD_MTMD_PRIATI_ID,
      pCAD_MTMD_ID,
      NVL(pCAD_FL_ATIVO, 1),
      SYSDATE,
      pSEG_USU_ID_USUARIO
    );
    pCAD_MTMD_PRIATI_ID := vCAD_MTMD_PRIATI_ID;
    UPDATE TB_CAD_MTMD_MAT_MED 
       SET CAD_MTMD_PRIATI_ID = DECODE(NVL(pCAD_FL_ATIVO, 1), 0, 0, vCAD_MTMD_PRIATI_ID)
     WHERE CAD_MTMD_ID = pCAD_MTMD_ID;
  end PRC_CAD_MTMD_SIMILAR_I;