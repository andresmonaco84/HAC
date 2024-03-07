  --PRC_ATS_ALR_ATEN_LAUDO_RETIF_I
  create or replace procedure PRC_ATS_ALR_ATEN_LAUDO_RETIF_I
  (
     pNewIdt OUT integer,
     pATS_ALR_ID IN TB_ATS_ALR_ATEN_LAUDO_RETIF.ATS_ALR_ID%type default NULL,
     pATS_APL_ID IN TB_ATS_ALR_ATEN_LAUDO_RETIF.ATS_APL_ID%type,
     pATS_ALR_TEXTO_LAUDO_RETIF IN TB_ATS_ALR_ATEN_LAUDO_RETIF.ATS_ALR_TEXTO_LAUDO_RETIF%type,
     pATS_ALR_DT_RETIFICACAO IN TB_ATS_ALR_ATEN_LAUDO_RETIF.ATS_ALR_DT_RETIFICACAO%type,
     pATS_ALR_HR_RETIFICACAO IN TB_ATS_ALR_ATEN_LAUDO_RETIF.ATS_ALR_HR_RETIFICACAO%type,
     pATS_ALR_DT_ULTIMA_ATUALIZACAO IN TB_ATS_ALR_ATEN_LAUDO_RETIF.ATS_ALR_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATS_ALR_ATEN_LAUDO_RETIF.SEG_USU_ID_USUARIO%type,
     pCAD_PRO_ID_PROF IN TB_ATS_ALR_ATEN_LAUDO_RETIF.CAD_PRO_ID_PROF%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_ALR_ATEN_LAUDO_RETIF_I
  * 
  *    Data Criacao: 	data da  criaÃ§Ã£o   Por: Nome do Analista
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: DescriÃ§Ã£o da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ATS_ALR_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ATS_ALR_ATEN_LAUDO_RETIF
    (
       ATS_ALR_ID,
       ATS_APL_ID,
       ATS_ALR_TEXTO_LAUDO_RETIF,
       ATS_ALR_DT_RETIFICACAO,
       ATS_ALR_HR_RETIFICACAO,
       ATS_ALR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PRO_ID_PROF
    )
    VALUES
    (
      lIdtRetorno,
	     pATS_APL_ID,
	     pATS_ALR_TEXTO_LAUDO_RETIF,
	     pATS_ALR_DT_RETIFICACAO,
	     pATS_ALR_HR_RETIFICACAO,
	     pATS_ALR_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pCAD_PRO_ID_PROF
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ATS_ALR_ATEN_LAUDO_RETIF_I;