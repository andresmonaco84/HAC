

  --PRC_SMS_MPA_MENSAGEM_PADRAO_U
  create or replace procedure PRC_SMS_MPA_MENSAGEM_PADRAO_U
  (
     pSMS_MPA_ID IN TB_SMS_MPA_MENSAGEM_PADRAO.SMS_MPA_ID%type,
     pSMS_MPA_DS_DESCRICAO IN TB_SMS_MPA_MENSAGEM_PADRAO.SMS_MPA_DS_DESCRICAO%type,
     pSMS_MPA_DS_MENSAGEM IN TB_SMS_MPA_MENSAGEM_PADRAO.SMS_MPA_DS_MENSAGEM%type,
     pSMS_MPA_TP_FINALIDADE IN TB_SMS_MPA_MENSAGEM_PADRAO.SMS_MPA_TP_FINALIDADE%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_MPA_MENSAGEM_PADRAO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_SMS_MPA_MENSAGEM_PADRAO
    SET	   
        SMS_MPA_DS_DESCRICAO = pSMS_MPA_DS_DESCRICAO,
        SMS_MPA_DS_MENSAGEM = pSMS_MPA_DS_MENSAGEM,
        SMS_MPA_TP_FINALIDADE = pSMS_MPA_TP_FINALIDADE 
    WHERE
        SMS_MPA_ID = pSMS_MPA_ID;	
  end PRC_SMS_MPA_MENSAGEM_PADRAO_U;

