

  --PRC_SMS_PRE_PREFIXO_OPR_U
  create or replace procedure PRC_SMS_PRE_PREFIXO_OPR_U
  (
     pSMS_OPE_ID IN TB_SMS_PRE_PREFIXO_OPERADORA.SMS_OPE_ID%type,
     pSMS_PRE_DS_PREFIXO IN TB_SMS_PRE_PREFIXO_OPERADORA.SMS_PRE_DS_PREFIXO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_PRE_PREFIXO_OPERADORA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_SMS_PRE_PREFIXO_OPERADORA
    SET	   
 
    WHERE
        SMS_OPE_ID = pSMS_OPE_ID
    AND SMS_PRE_DS_PREFIXO = pSMS_PRE_DS_PREFIXO;	
  end PRC_SMS_PRE_PREFIXO_OPR_U;

