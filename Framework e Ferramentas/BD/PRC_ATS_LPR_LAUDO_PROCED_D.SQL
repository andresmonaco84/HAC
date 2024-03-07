  --PRC_ATS_LPR_LAUDO_PROCED_D
  create or replace procedure PRC_ATS_LPR_LAUDO_PROCED_D
  (
     pATS_LPR_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_LPR_LAUDO_PROCED_D
  * 
  *    Data Criacao: 	28/11/2008		   Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui os dados da associacao de Laudo x Procedimento
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_LPR_LAUDO_PROCEDIMENTO
    WHERE  
        ATS_LPR_ID = pATS_LPR_ID;	   
  end PRC_ATS_LPR_LAUDO_PROCED_D;