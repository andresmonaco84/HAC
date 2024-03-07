  --PRC_ATS_CPS_CAD_PROC_SEG_U
  create or replace procedure PRC_ATS_CPS_CAD_PROC_SEG_U
  (
     pCAD_PRD_ID IN TB_ATS_CPS_CAD_PROC_SEGMENTO.CAD_PRD_ID%type,
     pATS_CPS_CD_SEGMENTO IN TB_ATS_CPS_CAD_PROC_SEGMENTO.ATS_CPS_CD_SEGMENTO%type,
     pATS_CPS_DS_SEGMENTO IN TB_ATS_CPS_CAD_PROC_SEGMENTO.ATS_CPS_DS_SEGMENTO%type default NULL,
     pATS_CPS_DT_ULTIMA_ATUALIZACAO IN TB_ATS_CPS_CAD_PROC_SEGMENTO.ATS_CPS_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATS_CPS_CAD_PROC_SEGMENTO.SEG_USU_ID_USUARIO%type,
     pATS_CPS_FL_STATUS IN TB_ATS_CPS_CAD_PROC_SEGMENTO.ATS_CPS_FL_STATUS%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_CPS_CAD_PROC_SEG_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ATS_CPS_CAD_PROC_SEGMENTO
    SET	   
        ATS_CPS_DS_SEGMENTO = pATS_CPS_DS_SEGMENTO,
        ATS_CPS_DT_ULTIMA_ATUALIZACAO = pATS_CPS_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ATS_CPS_FL_STATUS = pATS_CPS_FL_STATUS 
    WHERE
        ATS_CPS_CD_SEGMENTO = pATS_CPS_CD_SEGMENTO
    AND CAD_PRD_ID = pCAD_PRD_ID;	
  end PRC_ATS_CPS_CAD_PROC_SEG_U;