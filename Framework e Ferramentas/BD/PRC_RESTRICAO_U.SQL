

  --PRC__RESTRICAO_U
  create or replace procedure PRC_RESTRICAO_U
  (
     pCD_RESTRICAO IN BNF_RESTRICAO.CD_RESTRICAO%type,
     pDS_RESTRICAO IN BNF_RESTRICAO.DS_RESTRICAO%type default NULL,
     pID_TRAVA IN BNF_RESTRICAO.ID_TRAVA%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC__RESTRICAO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE BNF_RESTRICAO
    SET	   
        DS_RESTRICAO = pDS_RESTRICAO,
        ID_TRAVA = pID_TRAVA 
    WHERE
        CD_RESTRICAO = pCD_RESTRICAO;	
  end PRC_RESTRICAO_U;

