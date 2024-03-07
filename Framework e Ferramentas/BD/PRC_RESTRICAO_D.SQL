

  --PRC_RESTRICAO_D
  create or replace procedure PRC_RESTRICAO_D 
  (
     pCD_RESTRICAO IN BNF_RESTRICAO.CD_RESTRICAO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_RESTRICAO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE BNF_RESTRICAO
    WHERE  
        CD_RESTRICAO = pCD_RESTRICAO;	   
  end PRC_RESTRICAO_D;
