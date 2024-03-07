 
  --PRC_SMS_MEN_MSG_ENVIADA_S
  create or replace procedure PRC_SMS_MEN_MSG_ENVIADA_S 
  (
     pSMS_MEN_ID IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_ID%type DEFAULT NULL,
     pSMS_MEN_ID_MODULO_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_ID_MODULO_ENVIO%type DEFAULT NULL,
     pSMS_MEN_ID_TB_MODULO_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_ID_TB_MODULO_ENVIO%type DEFAULT NULL,
     pSMS_MEN_DT_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_DT_ENVIO%type DEFAULT NULL,
     pSMS_MEN_HR_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_HR_ENVIO%type DEFAULT NULL,
     pSMS_MPA_ID IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MPA_ID%type DEFAULT NULL,
     pSMS_MEN_TELEFONE_ENVIO IN TB_SMS_MEN_MENSAGEM_ENVIADA.SMS_MEN_TELEFONE_ENVIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_MEN_MENSAGEM_ENVIADA_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       SMS_MEN_ID,
       SMS_MEN_ID_MODULO_ENVIO,
       SMS_MEN_ID_TB_MODULO_ENVIO,
       SMS_MEN_DT_ENVIO,
       SMS_MEN_HR_ENVIO,
       SMS_MPA_ID,
       SMS_MEN_TELEFONE_ENVIO
    FROM TB_SMS_MEN_MENSAGEM_ENVIADA
    WHERE
        (pSMS_MEN_ID is null OR SMS_MEN_ID = pSMS_MEN_ID) AND 
        (pSMS_MEN_ID_MODULO_ENVIO is null OR SMS_MEN_ID_MODULO_ENVIO = pSMS_MEN_ID_MODULO_ENVIO) AND 
        (pSMS_MEN_ID_TB_MODULO_ENVIO is null OR SMS_MEN_ID_TB_MODULO_ENVIO = pSMS_MEN_ID_TB_MODULO_ENVIO) AND 
        (pSMS_MEN_DT_ENVIO is null OR SMS_MEN_DT_ENVIO = pSMS_MEN_DT_ENVIO) AND 
        (pSMS_MEN_HR_ENVIO is null OR SMS_MEN_HR_ENVIO = pSMS_MEN_HR_ENVIO) AND 
        (pSMS_MPA_ID is null OR SMS_MPA_ID = pSMS_MPA_ID) AND 
        (pSMS_MEN_TELEFONE_ENVIO is null OR SMS_MEN_TELEFONE_ENVIO = pSMS_MEN_TELEFONE_ENVIO);          
    io_cursor := v_cursor;
  end PRC_SMS_MEN_MSG_ENVIADA_S;
