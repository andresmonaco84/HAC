

  --PRC_SMS_MRE_MSG_RECEBIDA_U
  create or replace procedure PRC_SMS_MRE_MSG_RECEBIDA_U
  (
     pSMS_MRE_ID IN TB_SMS_MRE_MENSAGEM_RECEBIDA.SMS_MRE_ID%type,
     pSMS_MRE_DT_RECEBIMENTO IN TB_SMS_MRE_MENSAGEM_RECEBIDA.SMS_MRE_DT_RECEBIMENTO%type,
     pSMS_MRE_HR_RECEBIMENTO IN TB_SMS_MRE_MENSAGEM_RECEBIDA.SMS_MRE_HR_RECEBIMENTO%type,
     pSMS_MRE_DS_RESPOSTA_OPERACAO IN TB_SMS_MRE_MENSAGEM_RECEBIDA.SMS_MRE_DS_RESPOSTA_OPERACAO%type default NULL,
     pSMS_MEN_ID IN TB_SMS_MRE_MENSAGEM_RECEBIDA.SMS_MEN_ID%type,
     pSMS_OPE_ID IN TB_SMS_MRE_MENSAGEM_RECEBIDA.SMS_OPE_ID%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_MRE_MENSAGEM_RECEBIDA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_SMS_MRE_MENSAGEM_RECEBIDA
    SET	   
        SMS_MRE_DT_RECEBIMENTO = pSMS_MRE_DT_RECEBIMENTO,
        SMS_MRE_HR_RECEBIMENTO = pSMS_MRE_HR_RECEBIMENTO,
        SMS_MRE_DS_RESPOSTA_OPERACAO = pSMS_MRE_DS_RESPOSTA_OPERACAO,
        SMS_MEN_ID = pSMS_MEN_ID,
        SMS_OPE_ID = pSMS_OPE_ID 
    WHERE
        SMS_MRE_ID = pSMS_MRE_ID;	
  end PRC_SMS_MRE_MSG_RECEBIDA_U;

