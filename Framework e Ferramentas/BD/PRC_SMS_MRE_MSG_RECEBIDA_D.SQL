

  --PRC_SMS_MRE_MSG_RECEBIDA_D
  create or replace procedure PRC_SMS_MRE_MSG_RECEBIDA_D 
  (
     pSMS_MRE_ID IN TB_SMS_MRE_MENSAGEM_RECEBIDA.SMS_MRE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_SMS_MRE_MENSAGEM_RECEBIDA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_SMS_MRE_MENSAGEM_RECEBIDA
    WHERE  
        SMS_MRE_ID = pSMS_MRE_ID;	   
  end PRC_SMS_MRE_MSG_RECEBIDA_D;
