  --PRC_ATS_ARP_ATEN_RESULT_PROC_D
  create or replace procedure PRC_ATS_ARP_ATEN_RESULT_PROC_D 
  (
     pATS_ARP_DT_RESULTADO IN TB_ATS_ARP_ATEN_RESULT_PROCED.ATS_ARP_DT_RESULTADO%type,
     pATS_ATE_CD_INTLIB IN TB_ATS_ARP_ATEN_RESULT_PROCED.ATS_ATE_CD_INTLIB%type,
     pATS_ATE_ID IN TB_ATS_ARP_ATEN_RESULT_PROCED.ATS_ATE_ID%type,
     pATS_ATE_IN_INTLIB IN TB_ATS_ARP_ATEN_RESULT_PROCED.ATS_ATE_IN_INTLIB%type,
     pATS_EPP_CD_ESPECPROC IN TB_ATS_ARP_ATEN_RESULT_PROCED.ATS_EPP_CD_ESPECPROC%type,
     pCAD_PRD_ID IN TB_ATS_ARP_ATEN_RESULT_PROCED.CAD_PRD_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_ARP_ATEN_RESULT_PROC_D
  * 
  *    Data Criacao: 	04/11/2008		   Por: Fabiola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui os dados do resultado do precedimento do SADT
  *
  *******************************************************************/    
   begin
    DELETE TB_ATS_ARP_ATEN_RESULT_PROCED
    WHERE  
        ATS_ARP_DT_RESULTADO = pATS_ARP_DT_RESULTADO
    AND ATS_ATE_CD_INTLIB = pATS_ATE_CD_INTLIB
    AND ATS_ATE_ID = pATS_ATE_ID
    AND ATS_ATE_IN_INTLIB = pATS_ATE_IN_INTLIB
    AND ATS_EPP_CD_ESPECPROC = pATS_EPP_CD_ESPECPROC
    AND CAD_PRD_ID = pCAD_PRD_ID;
  end PRC_ATS_ARP_ATEN_RESULT_PROC_D;
