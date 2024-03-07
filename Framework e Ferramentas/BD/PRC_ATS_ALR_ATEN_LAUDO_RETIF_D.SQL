  --PRC_ATS_ALR_ATEN_LAUDO_RETIF_D
  create or replace procedure PRC_ATS_ALR_ATEN_LAUDO_RETIF_D 
  (
     pATS_ALR_ID IN TB_ATS_ALR_ATEN_LAUDO_RETIF.ATS_ALR_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_ALR_ATEN_LAUDO_RETIF_D
  * 
  *    Data Criacao: 	data da  criaÃ§Ã£o   Por: Nome do Analista
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: DescriÃ§Ã£o da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_ALR_ATEN_LAUDO_RETIF
    WHERE  
        ATS_ALR_ID = pATS_ALR_ID;	   
  end PRC_ATS_ALR_ATEN_LAUDO_RETIF_D;