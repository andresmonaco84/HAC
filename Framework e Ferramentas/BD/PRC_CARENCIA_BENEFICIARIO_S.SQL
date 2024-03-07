 
  --PRC_CARENCIA_BENEFICIARIO_S
  create or replace procedure PRC_CARENCIA_BENEFICIARIO_S 
  (
     pCODCON IN BNF_CARENCIA_BENEFICIARIO.CODCON%type DEFAULT NULL,
     pCODEST IN BNF_CARENCIA_BENEFICIARIO.CODEST%type DEFAULT NULL,
     pCODBEN IN BNF_CARENCIA_BENEFICIARIO.CODBEN%type DEFAULT NULL,
     pCODSEQBEN IN BNF_CARENCIA_BENEFICIARIO.CODSEQBEN%type DEFAULT NULL,
     pCODSER IN BNF_CARENCIA_BENEFICIARIO.CODSER%type DEFAULT NULL,
     pDATINICAR IN BNF_CARENCIA_BENEFICIARIO.DATINICAR%type DEFAULT NULL,
     pDATFIMCAR IN BNF_CARENCIA_BENEFICIARIO.DATFIMCAR%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CARENCIA_BENEFICIARIO_S
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
       CODCON,
       CODEST,
       CODBEN,
       CODSEQBEN,
       CODSER,
       DATINICAR,
       DATFIMCAR
    FROM BNF_CARENCIA_BENEFICIARIO
    WHERE
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODEST is null OR CODEST = pCODEST) AND 
        (pCODBEN is null OR CODBEN = pCODBEN) AND 
        (pCODSEQBEN is null OR CODSEQBEN = pCODSEQBEN) AND 
        (pCODSER is null OR CODSER = pCODSER) AND 
        (pDATINICAR is null OR DATINICAR = pDATINICAR) AND 
        (pDATFIMCAR is null OR DATFIMCAR = pDATFIMCAR);          
    io_cursor := v_cursor;
  end PRC_CARENCIA_BENEFICIARIO_S;
