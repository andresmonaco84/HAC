  --PRC_ATS_APL_ATEN_PROC_LAUDO_D
  create or replace procedure PRC_ATS_APL_ATEN_PROC_LAUDO_D 
  (
     pATS_APL_ID IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_APL_ATEN_PROC_LAUDO_D
  * 
  *    Data Criacao: 	18/11/2008		   Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui os dados do Laudo do Procedimento/Exame
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_APL_ATEN_PROCED_LAUDO
    WHERE  
        ATS_APL_ID = pATS_APL_ID;	   
  end PRC_ATS_APL_ATEN_PROC_LAUDO_D;