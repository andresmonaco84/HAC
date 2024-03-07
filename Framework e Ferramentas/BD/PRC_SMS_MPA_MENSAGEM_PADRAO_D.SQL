

  --PRC_SMS_MPA_MENSAGEM_PADRAO_D
  create or replace procedure PRC_SMS_MPA_MENSAGEM_PADRAO_D 
  (
     pSMS_MPA_ID IN TB_SMS_MPA_MENSAGEM_PADRAO.SMS_MPA_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_SMS_MPA_MENSAGEM_PADRAO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_SMS_MPA_MENSAGEM_PADRAO
    WHERE  
        SMS_MPA_ID = pSMS_MPA_ID;	   
  end PRC_SMS_MPA_MENSAGEM_PADRAO_D;
