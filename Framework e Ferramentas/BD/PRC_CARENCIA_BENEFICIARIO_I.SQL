

  --PRC_CARENCIA_BENEFICIARIO_I
  create or replace procedure PRC_CARENCIA_BENEFICIARIO_I
  (
     pCODCON IN BNF_CARENCIA_BENEFICIARIO.CODCON%type,
     pCODEST IN BNF_CARENCIA_BENEFICIARIO.CODEST%type,
     pCODBEN IN BNF_CARENCIA_BENEFICIARIO.CODBEN%type,
     pCODSEQBEN IN BNF_CARENCIA_BENEFICIARIO.CODSEQBEN%type,
     pCODSER IN BNF_CARENCIA_BENEFICIARIO.CODSER%type,
     pDATINICAR IN BNF_CARENCIA_BENEFICIARIO.DATINICAR%type,
     pDATFIMCAR IN BNF_CARENCIA_BENEFICIARIO.DATFIMCAR%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CARENCIA_BENEFICIARIO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO BNF_CARENCIA_BENEFICIARIO
    (
       CODCON,
       CODEST,
       CODBEN,
       CODSEQBEN,
       CODSER,
       DATINICAR,
       DATFIMCAR
    )
    VALUES
    (
	     pCODCON,
	     pCODEST,
	     pCODBEN,
	     pCODSEQBEN,
	     pCODSER,
	     pDATINICAR,
	     pDATFIMCAR
    );
	
  end PRC_CARENCIA_BENEFICIARIO_I;

