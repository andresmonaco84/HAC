 
  --PRC_SMS_OPE_OPERADORA_S
  create or replace procedure PRC_SMS_OPE_OPERADORA_S 
  (
     pSMS_OPE_ID IN TB_SMS_OPE_OPERADORA.SMS_OPE_ID%type DEFAULT NULL,
     pSMS_OPE_NM_OPERADORA IN TB_SMS_OPE_OPERADORA.SMS_OPE_NM_OPERADORA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_OPE_OPERADORA_S
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
       SMS_OPE_NM_OPERADORA
    FROM TB_SMS_OPE_OPERADORA
    WHERE
        (pSMS_OPE_ID is null OR SMS_OPE_ID = pSMS_OPE_ID) AND 
        (pSMS_OPE_NM_OPERADORA is null OR SMS_OPE_NM_OPERADORA = pSMS_OPE_NM_OPERADORA);          
    io_cursor := v_cursor;
  end PRC_SMS_OPE_OPERADORA_S;
