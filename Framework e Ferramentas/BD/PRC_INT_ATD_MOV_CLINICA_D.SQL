

  --PRC_INT_ATD_MOV_CLINICA_D
  create or replace procedure PRC_INT_ATD_MOV_CLINICA_D 
  (
     pATD_IMC_ID IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_IMC_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_MOV_CLINICA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATD_IMC_INT_MOV_CLINICA
    WHERE  
        ATD_IMC_ID = pATD_IMC_ID;	   
  end PRC_INT_ATD_MOV_CLINICA_D;
