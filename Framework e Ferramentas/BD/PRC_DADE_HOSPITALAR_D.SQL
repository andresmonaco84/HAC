

  --PRC_DADE_HOSPITALAR_D
  create or replace procedure PRC_DADE_HOSPITALAR_D 
  (
     pCODUNIHOS IN UNIDADE_HOSPITALAR.CODUNIHOS%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_DADE_HOSPITALAR_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE UNIDADE_HOSPITALAR
    WHERE  
        CODUNIHOS = pCODUNIHOS;	   
  end PRC_DADE_HOSPITALAR_D;
