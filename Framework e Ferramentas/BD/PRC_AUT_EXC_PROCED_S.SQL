 
  --PRC_AUT_EXC_PROCED_S
  create or replace procedure PRC_AUT_EXC_PROCED_S 
  (
     pCODTIPEMP IN TB_AUT_EXC_PROCED.CODTIPEMP%type DEFAULT NULL,
     pCODATOMED IN TB_AUT_EXC_PROCED.CODATOMED%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_EXC_PROCED_S
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
       CODTIPEMP,
       CODATOMED
    FROM TB_AUT_EXC_PROCED
    WHERE
        (pCODTIPEMP is null OR CODTIPEMP = pCODTIPEMP) AND 
        (pCODATOMED is null OR CODATOMED = pCODATOMED);          
    io_cursor := v_cursor;
  end PRC_AUT_EXC_PROCED_S;
