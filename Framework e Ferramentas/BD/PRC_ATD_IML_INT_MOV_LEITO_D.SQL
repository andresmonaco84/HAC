

  --PRC_ATD_IML_INT_MOV_LEITO_D
  create or replace procedure PRC_ATD_IML_INT_MOV_LEITO_D 
  (
     pATD_IML_ID IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_IML_INT_MOV_LEITO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATD_IML_INT_MOV_LEITO
    WHERE  
        ATD_IML_ID = pATD_IML_ID;	   
  end PRC_ATD_IML_INT_MOV_LEITO_D;
