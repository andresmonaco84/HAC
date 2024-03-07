create or replace procedure PRC_ATS_APS_ATEN_PROC_SEG_01_D
  (
     pATS_ATE_CD_INTLIB IN TB_ATS_APS_ATEN_PROC_SEGMENTO.ATS_ATE_CD_INTLIB%type DEFAULT NULL,
     pATS_ATE_IN_INTLIB IN TB_ATS_APS_ATEN_PROC_SEGMENTO.ATS_ATE_IN_INTLIB%type DEFAULT NULL,
     pATS_ATE_ID IN TB_ATS_APS_ATEN_PROC_SEGMENTO.ATS_ATE_ID%type DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_ATS_APS_ATEN_PROC_SEGMENTO.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
     pCAD_PRD_ID IN TB_ATS_APS_ATEN_PROC_SEGMENTO.CAD_PRD_ID%type DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_ATS_APS_ATEN_PROC_SEGMENTO.TIS_MED_CD_TABELAMEDICA%type	DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_APS_ATEN_PROC_SEG_01_D
  *
  *    Data Criacao:    12/02/2009         Por: Fabíola Lopes
   *    Data Alteracao:	27/03/2010  Por: Pedro
  *    Alteração: pTIS_MED_CD_TABELAMEDICA
  *
  *    Funcao: Exclui os segmento pela chave composta
  *
  *******************************************************************/
  begin
    DELETE TB_ATS_APS_ATEN_PROC_SEGMENTO aps
    WHERE
           APS.ATS_ATE_CD_INTLIB = pATS_ATE_CD_INTLIB AND
           APS.ATS_ATE_IN_INTLIB = pATS_ATE_IN_INTLIB AND
           APS.ATS_ATE_ID = pATS_ATE_ID AND
           APS.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC AND
           APS.CAD_PRD_ID = pCAD_PRD_ID AND
           APS.TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA;

  end PRC_ATS_APS_ATEN_PROC_SEG_01_D;
/
