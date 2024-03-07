  --PRC_INT_ATD_OBSERVACAO_D
  create or replace procedure PRC_INT_ATD_OBSERVACAO_D 
  (
     pATD_INO_ID IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_OBSERVACAO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATD_INO_INT_OBSERVACAO
    WHERE  
        ATD_INO_ID = pATD_INO_ID;	   
  end PRC_INT_ATD_OBSERVACAO_D;
