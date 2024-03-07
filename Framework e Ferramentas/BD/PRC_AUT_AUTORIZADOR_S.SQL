 
  --PRC_AUT_AUTORIZADOR_S
  create or replace procedure PRC_AUT_AUTORIZADOR_S 
  (
     pCODCON IN TB_AUT_AUTORIZADOR.CODCON%type DEFAULT NULL,
     pCODEST IN TB_AUT_AUTORIZADOR.CODEST%type DEFAULT NULL,
     pCODBEN IN TB_AUT_AUTORIZADOR.CODBEN%type DEFAULT NULL,
     pCODSEQBEN IN TB_AUT_AUTORIZADOR.CODSEQBEN%type DEFAULT NULL,
     pCD_AUTORIZADOR IN TB_AUT_AUTORIZADOR.CD_AUTORIZADOR%type DEFAULT NULL,
     pDT_AUTORIZACAO IN TB_AUT_AUTORIZADOR.DT_AUTORIZACAO%type DEFAULT NULL,
     pCD_LOCAL_AUTORIZACAO IN TB_AUT_AUTORIZADOR.CD_LOCAL_AUTORIZACAO%type DEFAULT NULL,
     pCODATOMED IN TB_AUT_AUTORIZADOR.CODATOMED%type DEFAULT NULL,
     pCODESPMED IN TB_AUT_AUTORIZADOR.CODESPMED%type DEFAULT NULL,
     pDS_RET_AUTORIZADOR IN TB_AUT_AUTORIZADOR.DS_RET_AUTORIZADOR%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_AUTORIZADOR_S
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
       CD_AUTORIZADOR,
       DT_AUTORIZACAO,
       CD_LOCAL_AUTORIZACAO,
       CODATOMED,
       CODESPMED,
       DS_RET_AUTORIZADOR
    FROM TB_AUT_AUTORIZADOR
    WHERE
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODEST is null OR CODEST = pCODEST) AND 
        (pCODBEN is null OR CODBEN = pCODBEN) AND 
        (pCODSEQBEN is null OR CODSEQBEN = pCODSEQBEN) AND 
        (pCD_AUTORIZADOR is null OR CD_AUTORIZADOR = pCD_AUTORIZADOR) AND 
        (pDT_AUTORIZACAO is null OR DT_AUTORIZACAO = pDT_AUTORIZACAO) AND 
        (pCD_LOCAL_AUTORIZACAO is null OR CD_LOCAL_AUTORIZACAO = pCD_LOCAL_AUTORIZACAO) AND 
        (pCODATOMED is null OR CODATOMED = pCODATOMED) AND 
        (pCODESPMED is null OR CODESPMED = pCODESPMED) AND 
        (pDS_RET_AUTORIZADOR is null OR DS_RET_AUTORIZADOR = pDS_RET_AUTORIZADOR);          
    io_cursor := v_cursor;
  end PRC_AUT_AUTORIZADOR_S;
