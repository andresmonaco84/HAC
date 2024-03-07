 
  --PRC_RESTRICAO_S
  create or replace procedure PRC_RESTRICAO_S 
  (
     pCD_RESTRICAO IN BNF_RESTRICAO.CD_RESTRICAO%type DEFAULT NULL,
     pDS_RESTRICAO IN BNF_RESTRICAO.DS_RESTRICAO%type DEFAULT NULL,
     pID_TRAVA IN BNF_RESTRICAO.ID_TRAVA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_RESTRICAO_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CD_RESTRICAO,
       DS_RESTRICAO,
       ID_TRAVA
    FROM BNF_RESTRICAO
    WHERE
        (pCD_RESTRICAO is null OR CD_RESTRICAO = pCD_RESTRICAO) AND 
        (pDS_RESTRICAO is null OR DS_RESTRICAO = pDS_RESTRICAO) AND 
        (pID_TRAVA is null OR ID_TRAVA = pID_TRAVA);          
    io_cursor := v_cursor;
  end PRC_RESTRICAO_S;
