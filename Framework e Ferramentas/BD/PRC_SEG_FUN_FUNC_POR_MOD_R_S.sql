create or replace procedure PRC_SEG_FUN_FUNC_POR_MOD_R_S
  (
     pSEG_MOD_ID_MODULO IN TB_SEG_FUN_FUNCIONALIDADE.SEG_MOD_ID_MODULO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_FUN_FUNC_POR_MOD_R_S
  *
  *    Data Criacao:   17/05/2010             Por: Rafael Coimbra
  *    Data Alteracao:                       Por:
  *
  *    Funcao: Retorna as funcionalidades pertencentes ao módulo passado
  *            por parametro e as funcionalidades que tem o módulo nulo
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

    SELECT
           FUN.SEG_FUN_ID_FUNCIONALIDADE,
           FUN.SEG_FUN_DS_DESCRICAO,
           FUN.SEG_FUN_FL_ITEM_MENU_OK,
           FUN.SEG_FUN_ID_FUNCIONALIDADE_PAI,
           FUN.SEG_FUN_DS_NOME_PAGINA,
           FUN.SEG_FUN_NM_NOME,
           FUN.SEG_MOD_ID_MODULO 
    FROM 
           TB_SEG_FUN_FUNCIONALIDADE FUN 
    WHERE 
           FUN.SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO
           OR FUN.SEG_MOD_ID_MODULO IS NULL 
    ORDER BY FUN.SEG_FUN_ID_FUNCIONALIDADE_PAI;
    
    io_cursor := v_cursor;
  end PRC_SEG_FUN_FUNC_POR_MOD_R_S;
