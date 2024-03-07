

  --PRC_SMS_OPE_OPERADORA_I
  create or replace procedure PRC_SMS_OPE_OPERADORA_I
  (
     pSMS_OPE_ID IN TB_SMS_OPE_OPERADORA.SMS_OPE_ID%type,
     pSMS_OPE_NM_OPERADORA IN TB_SMS_OPE_OPERADORA.SMS_OPE_NM_OPERADORA%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_OPE_OPERADORA_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_SMS_OPE_OPERADORA
    (
       SMS_OPE_ID,
       SMS_OPE_NM_OPERADORA
    )
    VALUES
    (
	     pSMS_OPE_ID,
	     pSMS_OPE_NM_OPERADORA
    );
	
  end PRC_SMS_OPE_OPERADORA_I;

