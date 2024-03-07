

  --PRC_SMS_OPE_OPERADORA_D
  create or replace procedure PRC_SMS_OPE_OPERADORA_D 
  (
     pSMS_OPE_ID IN TB_SMS_OPE_OPERADORA.SMS_OPE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_SMS_OPE_OPERADORA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_SMS_OPE_OPERADORA
    WHERE  
        SMS_OPE_ID = pSMS_OPE_ID;	   
  end PRC_SMS_OPE_OPERADORA_D;
