

  --PRC_CARENCIA_BENEFICIARIO_D
  create or replace procedure PRC_CARENCIA_BENEFICIARIO_D 
  (
     pCODBEN IN BNF_CARENCIA_BENEFICIARIO.CODBEN%type,
     pCODCON IN BNF_CARENCIA_BENEFICIARIO.CODCON%type,
     pCODEST IN BNF_CARENCIA_BENEFICIARIO.CODEST%type,
     pCODSEQBEN IN BNF_CARENCIA_BENEFICIARIO.CODSEQBEN%type,
     pCODSER IN BNF_CARENCIA_BENEFICIARIO.CODSER%type,
     pDATINICAR IN BNF_CARENCIA_BENEFICIARIO.DATINICAR%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CARENCIA_BENEFICIARIO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE BNF_CARENCIA_BENEFICIARIO
    WHERE  
        CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN
    AND CODSER = pCODSER
    AND DATINICAR = pDATINICAR;	   
  end PRC_CARENCIA_BENEFICIARIO_D;
