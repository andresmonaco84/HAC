

  --PRC__ENDERECO_BENEF_D
  create or replace procedure PRC_ENDERECO_BENEF_D 
  (
     pCODBEN IN BNF_ENDERECO_BENEF.CODBEN%type,
     pCODCON IN BNF_ENDERECO_BENEF.CODCON%type,
     pCODEST IN BNF_ENDERECO_BENEF.CODEST%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC__ENDERECO_BENEF_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE BNF_ENDERECO_BENEF
    WHERE  
        CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST;	   
  end PRC_ENDERECO_BENEF_D;
