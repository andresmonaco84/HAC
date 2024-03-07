

  --PRC_SMS_OPE_OPERADORA_U
  create or replace procedure PRC_SMS_OPE_OPERADORA_U
  (
     pSMS_OPE_ID IN TB_SMS_OPE_OPERADORA.SMS_OPE_ID%type,
     pSMS_OPE_NM_OPERADORA IN TB_SMS_OPE_OPERADORA.SMS_OPE_NM_OPERADORA%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_OPE_OPERADORA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_SMS_OPE_OPERADORA
    SET	   
        SMS_OPE_NM_OPERADORA = pSMS_OPE_NM_OPERADORA 
    WHERE
        SMS_OPE_ID = pSMS_OPE_ID;	
  end PRC_SMS_OPE_OPERADORA_U;

