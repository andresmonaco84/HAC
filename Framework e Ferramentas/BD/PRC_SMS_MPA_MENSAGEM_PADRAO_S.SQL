 
  --PRC_SMS_MPA_MENSAGEM_PADRAO_S
  create or replace procedure PRC_SMS_MPA_MENSAGEM_PADRAO_S 
  (
     pSMS_MPA_ID IN TB_SMS_MPA_MENSAGEM_PADRAO.SMS_MPA_ID%type DEFAULT NULL,
     pSMS_MPA_DS_DESCRICAO IN TB_SMS_MPA_MENSAGEM_PADRAO.SMS_MPA_DS_DESCRICAO%type DEFAULT NULL,
     pSMS_MPA_DS_MENSAGEM IN TB_SMS_MPA_MENSAGEM_PADRAO.SMS_MPA_DS_MENSAGEM%type DEFAULT NULL,
     pSMS_MPA_TP_FINALIDADE IN TB_SMS_MPA_MENSAGEM_PADRAO.SMS_MPA_TP_FINALIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_MPA_MENSAGEM_PADRAO_S
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
       SMS_MPA_ID,
       SMS_MPA_DS_DESCRICAO,
       SMS_MPA_DS_MENSAGEM,
       SMS_MPA_TP_FINALIDADE
    FROM TB_SMS_MPA_MENSAGEM_PADRAO
    WHERE
        (pSMS_MPA_ID is null OR SMS_MPA_ID = pSMS_MPA_ID) AND 
        (pSMS_MPA_DS_DESCRICAO is null OR SMS_MPA_DS_DESCRICAO = pSMS_MPA_DS_DESCRICAO) AND 
        (pSMS_MPA_DS_MENSAGEM is null OR SMS_MPA_DS_MENSAGEM = pSMS_MPA_DS_MENSAGEM) AND 
        (pSMS_MPA_TP_FINALIDADE is null OR SMS_MPA_TP_FINALIDADE = pSMS_MPA_TP_FINALIDADE);          
    io_cursor := v_cursor;
  end PRC_SMS_MPA_MENSAGEM_PADRAO_S;
