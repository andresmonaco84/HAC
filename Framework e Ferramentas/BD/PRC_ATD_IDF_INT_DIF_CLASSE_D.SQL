  --PRC_ATD_IDF_INT_DIF_CLASSE_D
  create or replace procedure PRC_ATD_IDF_INT_DIF_CLASSE_D 
  (
     pATD_IDF_ID IN TB_ATD_IDF_INT_DIF_CLASSE.ATD_IDF_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_IDF_INT_DIF_CLASSE_D
  * 
  *    Data Criacao: 	31/08/2009         Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATD_IDF_INT_DIF_CLASSE
    WHERE  
        ATD_IDF_ID = pATD_IDF_ID;	   
  end PRC_ATD_IDF_INT_DIF_CLASSE_D;