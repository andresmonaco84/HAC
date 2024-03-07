

  --PRC_SMS_MEN_MSG_ENVIADA_U
  create or replace procedure PRC_SMS_MEN_MSG_ENVIADA_U
  (
     pSMS_MEN_ID IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_ID%type,
     pSMS_MEN_ID_MODULO_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_ID_MODULO_ENVIO%type,
     pSMS_MEN_ID_TB_MODULO_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_ID_TB_MODULO_ENVIO%type,
     pSMS_MEN_DT_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_DT_ENVIO%type,
     pSMS_MEN_HR_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_HR_ENVIO%type,
     pSMS_MPA_ID IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MPA_ID%type,
     pSMS_MEN_TELEFONE_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_TELEFONE_ENVIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_MEN_MENSAGEM_ENVIADA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_SMS_MEN_MENSAGEM_ENVIADA
    SET	   
        SMS_MEN_ID_MODULO_ENVIO = pSMS_MEN_ID_MODULO_ENVIO,
        SMS_MEN_ID_TB_MODULO_ENVIO = pSMS_MEN_ID_TB_MODULO_ENVIO,
        SMS_MEN_DT_ENVIO = pSMS_MEN_DT_ENVIO,
        SMS_MEN_HR_ENVIO = pSMS_MEN_HR_ENVIO,
        SMS_MPA_ID = pSMS_MPA_ID,
        SMS_MEN_TELEFONE_ENVIO = pSMS_MEN_TELEFONE_ENVIO 
    WHERE
        SMS_MEN_ID = pSMS_MEN_ID;	
  end PRC_SMS_MEN_MSG_ENVIADA_U;

