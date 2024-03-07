

  --PRC_RESTRICAO_I
  create or replace procedure PRC_RESTRICAO_I
  (
     pCD_RESTRICAO IN BNF_RESTRICAO.CD_RESTRICAO%type,
     pDS_RESTRICAO IN BNF_RESTRICAO.DS_RESTRICAO%type default NULL,
     pID_TRAVA IN BNF_RESTRICAO.ID_TRAVA%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_RESTRICAO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO BNF_RESTRICAO
    (
       CD_RESTRICAO,
       DS_RESTRICAO,
       ID_TRAVA
    )
    VALUES
    (
	     pCD_RESTRICAO,
	     pDS_RESTRICAO,
	     pID_TRAVA
    );
	
  end PRC_RESTRICAO_I;

