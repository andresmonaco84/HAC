 
  --PRC_AUT_ATO_ESPEC_S
  create or replace procedure PRC_AUT_ATO_ESPEC_S 
  (
     pCODATOMED IN TB_AUT_ATO_ESPEC.CODATOMED%type DEFAULT NULL,
     pCODESPMED IN TB_AUT_ATO_ESPEC.CODESPMED%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ATO_ESPEC_S
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
       CODESPMED
    FROM TB_AUT_ATO_ESPEC
    WHERE
        (pCODATOMED is null OR CODATOMED = pCODATOMED) AND 
        (pCODESPMED is null OR CODESPMED = pCODESPMED);          
    io_cursor := v_cursor;
  end PRC_AUT_ATO_ESPEC_S;
