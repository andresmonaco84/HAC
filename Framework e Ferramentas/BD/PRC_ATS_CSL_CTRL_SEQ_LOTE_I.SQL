  create or replace procedure PRC_ATS_CSL_CTRL_SEQ_LOTE_I
  (
     pNewIdt OUT integer,
     pATS_CSL_DT_LOTE IN TB_ATS_CSL_CTRL_SEQ_LOTE.ATS_CSL_DT_LOTE%type,
     pSEG_USU_ID_USUARIO IN TB_ATS_CSL_CTRL_SEQ_LOTE.SEG_USU_ID_USUARIO%type,
     pATS_CSL_HR_LOTE IN TB_ATS_CSL_CTRL_SEQ_LOTE.ATS_CSL_HR_LOTE%type,
     pDT_ULTIMA_ATUALIZACAO IN TB_ATS_CSL_CTRL_SEQ_LOTE.DT_ULTIMA_ATUALIZACAO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_CSL_CTRL_SEQ_LOTE_I
  * 
  *    Data Criacao: 	20/02/2009   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Inclui Lote de Exames Protocolados
  *
  *******************************************************************/  
	
  lIdtRetorno integer;
    
  begin
  
    SELECT SEQ_ATS_ARP_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ATS_CSL_CTRL_SEQ_LOTE
    (
       ATS_APR_NR_SEQ_LOTE,
       ATS_CSL_DT_LOTE,
       SEG_USU_ID_USUARIO,
       ATS_CSL_HR_LOTE,
       DT_ULTIMA_ATUALIZACAO
    )
    VALUES
    (
	     lIdtRetorno,
	     pATS_CSL_DT_LOTE,
	     pSEG_USU_ID_USUARIO,
	     pATS_CSL_HR_LOTE,
	     pDT_ULTIMA_ATUALIZACAO
    );
    pNewIdt := lIdtRetorno;
	
  end PRC_ATS_CSL_CTRL_SEQ_LOTE_I;
/
