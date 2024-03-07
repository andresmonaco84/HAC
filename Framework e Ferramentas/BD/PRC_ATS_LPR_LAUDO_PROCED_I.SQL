  --PRC_ATS_LPR_LAUDO_PROCED_I
  create or replace procedure PRC_ATS_LPR_LAUDO_PROCED_I
  (
     pNewIdt OUT integer,
     pATS_LPR_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_ID%type default NULL,
     pATS_TPL_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_TPL_ID%type,
     pCAD_PRD_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.CAD_PRD_ID%type,
     pATS_LPR_STATUS IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_STATUS%type,
     pATS_LPR_DT_ULTIMA_ATUALIZACAO IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_LPR_LAUDO_PROCED_I
  * 
  *    Data Criacao: 	28/11/2008		   Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Inclui os dados da associacao de Laudo x Procedimento
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ATS_LPR_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ATS_LPR_LAUDO_PROCEDIMENTO
    (
       ATS_LPR_ID,
       ATS_TPL_ID,
       CAD_PRD_ID,
       ATS_LPR_STATUS,
       ATS_LPR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
      lIdtRetorno,
	     pATS_TPL_ID,
	     pCAD_PRD_ID,
	     pATS_LPR_STATUS,
	     pATS_LPR_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ATS_LPR_LAUDO_PROCED_I;