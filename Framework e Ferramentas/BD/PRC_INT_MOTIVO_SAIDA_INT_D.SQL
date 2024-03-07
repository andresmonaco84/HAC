  --PRC_INT_MOTIVO_SAIDA_INT_D
  create or replace procedure PRC_INT_MOTIVO_SAIDA_INT_D 
  (
     pTIS_MSI_CD_MOTIVOSAIDAINT IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_CD_MOTIVOSAIDAINT%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_MOTIVO_SAIDA_INT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_TIS_MSI_MOTIVO_SAIDA_INT
    WHERE  
        TIS_MSI_CD_MOTIVOSAIDAINT = pTIS_MSI_CD_MOTIVOSAIDAINT;	   
  end PRC_INT_MOTIVO_SAIDA_INT_D;
