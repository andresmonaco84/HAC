CREATE OR REPLACE PROCEDURE PRC_SEG_PERFIL_FUNCIONALID_S
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_PER_ID_PERFIL%type DEFAULT NULL,
     pSEG_MOD_ID_MODULO IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_MOD_ID_MODULO%type DEFAULT NULL,
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_FUN_ID_FUNCIONALIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PERFIL_FUNCIONALID_S
  *
  *    Data Criacao: 	  2009        Por: Ricardo
  *    Data Alteracao:	25/02/2013  Por: André
  *         Alteracao:	Inclusão de order by
  *
  *    Funcao: Listar funcionalidades do perfil
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       ASS.SEG_PER_ID_PERFIL,
       ASS.SEG_MOD_ID_MODULO,
       ASS.SEG_FUN_ID_FUNCIONALIDADE,
       PERFIL.SEG_PER_NM_PERFIL,
       FUNC.SEG_FUN_NM_NOME
    FROM TB_SEG_PFU_PERFIL_FUNCIONALID ASS,
         TB_SEG_PER_PERFIL             PERFIL,
         TB_SEG_FUN_FUNCIONALIDADE     FUNC
    WHERE
        (pSEG_PER_ID_PERFIL is null OR         ASS.SEG_PER_ID_PERFIL         = pSEG_PER_ID_PERFIL) AND
        (pSEG_MOD_ID_MODULO is null OR         ASS.SEG_MOD_ID_MODULO         = pSEG_MOD_ID_MODULO) AND
        (pSEG_FUN_ID_FUNCIONALIDADE is null OR ASS.SEG_FUN_ID_FUNCIONALIDADE = pSEG_FUN_ID_FUNCIONALIDADE)
    AND PERFIL.SEG_PER_ID_PERFIL       = ASS.SEG_PER_ID_PERFIL
    AND FUNC.SEG_FUN_ID_FUNCIONALIDADE = ASS.SEG_FUN_ID_FUNCIONALIDADE
    AND FUNC.SEG_MOD_ID_MODULO         = ASS.SEG_MOD_ID_MODULO
    ORDER BY FUNC.SEG_FUN_NM_NOME;
    io_cursor := v_cursor;
  end PRC_SEG_PERFIL_FUNCIONALID_S;
 
