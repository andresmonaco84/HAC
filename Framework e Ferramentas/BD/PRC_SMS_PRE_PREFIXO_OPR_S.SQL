 
  --PRC_SMS_PRE_PREFIXO_OPR_S
  create or replace procedure PRC_SMS_PRE_PREFIXO_OPR_S 
  (
     pSMS_OPE_ID IN TB_SMS_PRE_PREFIXO_OPERADORA.SMS_OPE_ID%type DEFAULT NULL,
     pSMS_PRE_DS_PREFIXO IN TB_SMS_PRE_PREFIXO_OPERADORA.SMS_PRE_DS_PREFIXO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_PRE_PREFIXO_OPERADORA_S
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
       SMS_OPE_ID,
       SMS_PRE_DS_PREFIXO
    FROM TB_SMS_PRE_PREFIXO_OPERADORA
    WHERE
        (pSMS_OPE_ID is null OR SMS_OPE_ID = pSMS_OPE_ID) AND 
        (pSMS_PRE_DS_PREFIXO is null OR SMS_PRE_DS_PREFIXO = pSMS_PRE_DS_PREFIXO);          
    io_cursor := v_cursor;
  end PRC_SMS_PRE_PREFIXO_OPR_S;
