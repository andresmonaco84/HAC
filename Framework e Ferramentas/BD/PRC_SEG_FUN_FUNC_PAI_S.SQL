  create or replace procedure PRC_SEG_FUN_FUNC_PAI_S 
  (
	 pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_FUN_FUNC_PAI_S
  * 
  *    Data Criacao: 	  27/02/2007             Por: Carlos Eduardo
  *    Data Alteracao:	20/04/2007             Por: Andréa Cazuca
  *    Alteracao: Foi incluída o parametro SEG_MOD_ID_MODULO
  *
  *    Data Alteracao:	06/07/2007             Por: Carlos Eduardo
  *    Alteracao: O parametro SEG_MOD_ID_MODULO passou a aceitar NULL
  *
  *    Funcao: Retorna as funcionalidades Pai (Raiz do Menu)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       SEG_FUN_ID_FUNCIONALIDADE,
       SEG_FUN_DS_DESCRICAO,
       SEG_FUN_FL_ITEM_MENU_OK,
       SEG_FUN_ID_FUNCIONALIDADE_PAI,
       SEG_FUN_DS_NOME_PAGINA,
       SEG_FUN_NM_NOME
    FROM TB_SEG_FUN_FUNCIONALIDADE
    WHERE
        (SEG_FUN_ID_FUNCIONALIDADE_PAI IS NULL)
    AND	(SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO or SEG_MOD_ID_MODULO IS NULL)
    ORDER BY SEG_FUN_NM_NOME;
    io_cursor := v_cursor;
  end PRC_SEG_FUN_FUNC_PAI_S;
/
