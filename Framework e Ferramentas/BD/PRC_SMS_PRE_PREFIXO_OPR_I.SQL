

  --PRC_SMS_PRE_PREFIXO_OPR_I
  create or replace procedure PRC_SMS_PRE_PREFIXO_OPR_I
  (
     pSMS_OPE_ID IN TB_SMS_PRE_PREFIXO_OPERADORA.SMS_OPE_ID%type,
     pSMS_PRE_DS_PREFIXO IN TB_SMS_PRE_PREFIXO_OPERADORA.SMS_PRE_DS_PREFIXO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SMS_PRE_PREFIXO_OPERADORA_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_SMS_PRE_PREFIXO_OPERADORA
    (
       SMS_OPE_ID,
       SMS_PRE_DS_PREFIXO
    )
    VALUES
    (
	     pSMS_OPE_ID,
	     pSMS_PRE_DS_PREFIXO
    );
	
  end PRC_SMS_PRE_PREFIXO_OPR_I;

