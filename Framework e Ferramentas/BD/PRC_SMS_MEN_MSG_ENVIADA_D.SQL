

  --PRC_SMS_MEN_MSG_ENVIADA_D
  create or replace procedure PRC_SMS_MEN_MSG_ENVIADA_D 
  (
     pSMS_MEN_ID IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_SMS_MEN_MENSAGEM_ENVIADA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_SMS_MEN_MENSAGEM_ENVIADA
    WHERE  
        SMS_MEN_ID = pSMS_MEN_ID;	   
  end PRC_SMS_MEN_MSG_ENVIADA_D;
