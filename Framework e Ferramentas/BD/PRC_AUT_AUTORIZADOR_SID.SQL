

---bozo

  --PRC_AUT_AUTORIZADOR_SID
  create or replace procedure PRC_AUT_AUTORIZADOR_SID 
  (
     pCD_AUTORIZADOR IN TB_AUT_AUTORIZADOR.CD_AUTORIZADOR%type     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_AUTORIZADOR_SID
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
        CD_AUTORIZADOR = pCD_AUTORIZADOR;          
    io_cursor := v_cursor;
  end PRC_AUT_AUTORIZADOR_SID;
