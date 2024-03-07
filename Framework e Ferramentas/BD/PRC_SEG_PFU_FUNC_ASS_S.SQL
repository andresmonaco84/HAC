  create or replace procedure PRC_SEG_PFU_FUNC_ASS_S 
  (
     pSEG_MOD_ID_MODULO IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_MOD_ID_MODULO%type,
     pSEG_PER_ID_PERFIL IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_PER_ID_PERFIL%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_FUN_FUNC_ASS_S
  * 
  *    Data Criacao: 	27/02/2007             Por: Carlos Eduardo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Obtém IDs das funcionalidades associadas ao Módulo e Perfil
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       PFU.SEG_FUN_ID_FUNCIONALIDADE
    FROM TB_SEG_PFU_PERFIL_FUNCIONALID PFU
    WHERE
        (PFU.SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO)
    AND (PFU.SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL);
    io_cursor := v_cursor;
  end PRC_SEG_PFU_FUNC_ASS_S;
/
