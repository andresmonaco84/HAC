

  --PRC__BENEFICIARIO_D
  create or replace procedure PRC__BENEFICIARIO_D 
  (
     pCD_EMPRESA IN BNF_BENEFICIARIO.CD_EMPRESA%type,
     pCODBEN IN BNF_BENEFICIARIO.CODBEN%type,
     pCODCON IN BNF_BENEFICIARIO.CODCON%type,
     pCODEST IN BNF_BENEFICIARIO.CODEST%type,
     pCODSEQBEN IN BNF_BENEFICIARIO.CODSEQBEN%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC__BENEFICIARIO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE BNF_BENEFICIARIO
    WHERE  
        CD_EMPRESA = pCD_EMPRESA
    AND CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN;	   
  end PRC__BENEFICIARIO_D;
