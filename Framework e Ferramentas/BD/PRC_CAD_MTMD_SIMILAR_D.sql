CREATE OR REPLACE PROCEDURE "PRC_CAD_MTMD_SIMILAR_D"
  (
     pCAD_MTMD_PRIATI_ID IN TB_CAD_MTMD_SIMILAR.CAD_MTMD_PRIATI_ID%type,
     pCAD_MTMD_ID IN TB_CAD_MTMD_SIMILAR.CAD_MTMD_ID%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_MTMD_SIMILAR.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MTMD_SIMILAR_U
  *
  *    Data Criacao:  data da  criac?o   Por: Andre S. Monaco
  *    Data Alterac?o:27/03/2015   Por: Andre S. Monaco
  *         Alterac?o:Atualizacao da TB_CAD_MTMD_MAT_MED
  *
  *    Funcao: A delec?o inativa o registro para ter um log
  *******************************************************************/
  begin
    UPDATE TB_CAD_MTMD_SIMILAR
    SET
        CAD_FL_ATIVO = 0,
        CAD_MTMD_DT_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE CAD_MTMD_ID = pCAD_MTMD_ID; --AND
        --CAD_MTMD_PRIATI_ID = pCAD_MTMD_PRIATI_ID AND
        --CAD_FL_ATIVO = 1;
    UPDATE TB_CAD_MTMD_MAT_MED 
       SET CAD_MTMD_PRIATI_ID = 0
     WHERE CAD_MTMD_ID = pCAD_MTMD_ID;
  end PRC_CAD_MTMD_SIMILAR_D;
 