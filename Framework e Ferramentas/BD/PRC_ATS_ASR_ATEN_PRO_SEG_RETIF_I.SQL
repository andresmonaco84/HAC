  --PRC_ATS_ASR_ATEN_PRO_SEG_RET_I
  create or replace procedure PRC_ATS_ASR_ATEN_PRO_SEG_RET_I
  (
     pNewIdt OUT integer,
     pATS_ASR_ID IN TB_ATS_ASR_ATEN_PRO_SEG_RETIF.ATS_ASR_ID%type default NULL,
     pATS_APS_ID IN TB_ATS_ASR_ATEN_PRO_SEG_RETIF.ATS_APS_ID%type,
     pCAD_PRD_ID IN TB_ATS_ASR_ATEN_PRO_SEG_RETIF.CAD_PRD_ID%type,
     pATS_CPD_CD_SEGMENTO IN TB_ATS_ASR_ATEN_PRO_SEG_RETIF.ATS_CPD_CD_SEGMENTO%type,
     pATS_ASR_DT_ULTIMA_ATUALIZACAO IN TB_ATS_ASR_ATEN_PRO_SEG_RETIF.ATS_ASR_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATS_ASR_ATEN_PRO_SEG_RETIF.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_ASR_ATEN_PRO_SEG_RET_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ATS_ASR_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ATS_ASR_ATEN_PRO_SEG_RETIF
    (
       ATS_ASR_ID,
       ATS_APS_ID,
       CAD_PRD_ID,
       ATS_CPD_CD_SEGMENTO,
       ATS_ASR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
      lIdtRetorno,
	     pATS_APS_ID,
	     pCAD_PRD_ID,
	     pATS_CPD_CD_SEGMENTO,
	     pATS_ASR_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ATS_ASR_ATEN_PRO_SEG_RET_I;