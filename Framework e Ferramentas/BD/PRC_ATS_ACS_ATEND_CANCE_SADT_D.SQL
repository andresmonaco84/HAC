  --PRC_ATS_ACS_ATEND_CANCE_SADT_D
  create or replace procedure PRC_ATS_ACS_ATEND_CANCE_SADT_D 
  (
     pATS_ATE_CD_INTLIB IN TB_ATS_ACS_ATEND_CANCE_SADT.ATS_ATE_CD_INTLIB%type,
     pATS_ATE_ID IN TB_ATS_ACS_ATEND_CANCE_SADT.ATS_ATE_ID%type,
     pATS_ATE_IN_INTLIB IN TB_ATS_ACS_ATEND_CANCE_SADT.ATS_ATE_IN_INTLIB%type,
     pAUX_EPP_CD_ESPECPROC IN TB_ATS_ACS_ATEND_CANCE_SADT.AUX_EPP_CD_ESPECPROC%type,
     pCAD_PRD_ID IN TB_ATS_ACS_ATEND_CANCE_SADT.CAD_PRD_ID%type,
     pTIS_MED_CD_TABELAMEDICA IN TB_ATS_APS_ATEN_PROC_SEGMENTO.TIS_MED_CD_TABELAMEDICA%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_ACS_ATEND_CANCE_SADT_D
  * 
  *    Data Criacao: 	12/11/2008		   Por: Fabíola Lopes
  *    Data Alteracao:	27/03/2010 Por: PEDRO
  *    alteracao: pTIS_MED_CD_TABELAMEDICA
  *
  *    Funcao: Exclui os dados da tabela TB_ATS_ACS_ATEND_CANCE_SADT
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_ACS_ATEND_CANCE_SADT
    WHERE  
        ATS_ATE_CD_INTLIB = pATS_ATE_CD_INTLIB
    AND ATS_ATE_ID = pATS_ATE_ID
    AND ATS_ATE_IN_INTLIB = pATS_ATE_IN_INTLIB
    AND AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC
    AND CAD_PRD_ID = pCAD_PRD_ID
    AND TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA ;	   
  end PRC_ATS_ACS_ATEND_CANCE_SADT_D;
/
