

  --PRC_DADE_HOSPITALAR_I
  create or replace procedure PRC_DADE_HOSPITALAR_I
  (
     pCODUNIHOS IN UNIDADE_HOSPITALAR.CODUNIHOS%type,
     pDESUNIHOS IN UNIDADE_HOSPITALAR.DESUNIHOS%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_DADE_HOSPITALAR_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO UNIDADE_HOSPITALAR
    (
       CODUNIHOS,
       DESUNIHOS
    )
    VALUES
    (
	     pCODUNIHOS,
	     pDESUNIHOS
    );
	
  end PRC_DADE_HOSPITALAR_I;

