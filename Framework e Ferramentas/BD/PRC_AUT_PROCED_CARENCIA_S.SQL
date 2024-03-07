 
  --PRC_AUT_PROCED_CARENCIA_S
  create or replace procedure PRC_AUT_PROCED_CARENCIA_S 
  (
     pCODATOMED IN TB_AUT_PROCED_CARENCIA.CODATOMED%type DEFAULT NULL,
     pCODSER IN TB_AUT_PROCED_CARENCIA.CODSER%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_PROCED_CARENCIA_S
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
       CODATOMED,
       CODSER
    FROM TB_AUT_PROCED_CARENCIA
    WHERE
        (pCODATOMED is null OR CODATOMED = pCODATOMED) AND 
        (pCODSER is null OR CODSER = pCODSER);          
    io_cursor := v_cursor;
  end PRC_AUT_PROCED_CARENCIA_S;
