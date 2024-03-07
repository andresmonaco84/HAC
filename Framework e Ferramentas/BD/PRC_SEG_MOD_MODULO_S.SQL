  create or replace procedure PRC_SEG_MOD_MODULO_S 
  (
     pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type DEFAULT NULL,
     pSEG_MOD_CD_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_CD_MODULO%type DEFAULT NULL,
     pSEG_MOD_NM_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_NM_MODULO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_MOD_MODULO_S
  * 
  *    Data Criacao: 	01/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:                       Por: 
  *
  *    Funcao: Obtém o(s) Módulos do sistema por filtro (opcional)
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *******************************************************************/                         
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       SEG_MOD_ID_MODULO,
       SEG_MOD_NM_MODULO,
       SEG_MOD_DS_MODULO,
       SEG_MOD_CD_MODULO,
       SEG_MOD_DS_SISTEMA,
       SEG_MOD_DS_VERSAO,
       SEG_MOD_DT_VERSAO
    FROM TB_SEG_MOD_MODULO
    WHERE
        (pSEG_MOD_ID_MODULO is null OR SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO)
    AND (pSEG_MOD_CD_MODULO is null OR SEG_MOD_CD_MODULO = UPPER(pSEG_MOD_CD_MODULO))          
    AND (pSEG_MOD_NM_MODULO is null OR SEG_MOD_NM_MODULO LIKE UPPER(pSEG_MOD_NM_MODULO))
    ORDER BY SEG_MOD_NM_MODULO;
    io_cursor := v_cursor;
  end PRC_SEG_MOD_MODULO_S;
/
