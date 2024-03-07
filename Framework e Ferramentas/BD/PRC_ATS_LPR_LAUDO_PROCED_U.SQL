create or replace procedure PRC_ATS_LPR_LAUDO_PROCED_U
  (
     pATS_LPR_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_ID%type,
     pATS_TPL_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_TPL_ID%type,
     pCAD_PRD_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.CAD_PRD_ID%type,
     pATS_LPR_STATUS IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_STATUS%type,
     pATS_LPR_DT_ULTIMA_ATUALIZACAO IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_LPR_LAUDO_PROCED_U
  * 
  *    Data Criacao: 	28/11/2008		   Por: Fabíola Lopes
  *
  *    Data Alteracao:	09/12/2008  Por: Pedro      
  *
  *    Funcao: Altera os dados da associacao de Laudo x Procedimento
  *
  *******************************************************************/  
  begin
    UPDATE TB_ATS_LPR_LAUDO_PROCEDIMENTO
    SET	   
       -- ATS_TPL_ID = pATS_TPL_ID,
       -- CAD_PRD_ID = pCAD_PRD_ID,
        ATS_LPR_STATUS = pATS_LPR_STATUS,
        ATS_LPR_DT_ULTIMA_ATUALIZACAO = pATS_LPR_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        ATS_LPR_ID = pATS_LPR_ID
        and ATS_TPL_ID = pATS_TPL_ID
        and CAD_PRD_ID = pCAD_PRD_ID
       ;	
  end PRC_ATS_LPR_LAUDO_PROCED_U;
