CREATE OR REPLACE PROCEDURE PRC_SEG_PERFIL_USUARIO_S
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_PER_ID_PERFIL%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_USU_ID_USUARIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pSEG_MOD_ID_MODULO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_MOD_ID_MODULO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PEU_PERMISSAO_USUARIO_S
  *
  *    Data Criacao:  06/2009   Por: Ricardo Costa
  *    Data Alteracao:	25/02/2013  Por: André
  *         Alteracao:	Inclusão de order by
  *
  *    Funcao: Recupera os perfis relacionados a um usuário por unidade
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       PERUSU.SEG_PER_ID_PERFIL,
       PERUSU.SEG_USU_ID_USUARIO,
       PERUSU.CAD_UNI_ID_UNIDADE,
       PERUSU.SEG_MOD_ID_MODULO,
       PERFIL.seg_per_nm_perfil
    FROM TB_SEG_PEU_PERMISSAO_USUARIO PERUSU,
         TB_SEG_PER_PERFIL            PERFIL
    WHERE  PERUSU.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO  -- SE É PERFIL POR USUARIO O USUÁRIO É OBRIGATORIO
    AND    (pSEG_PER_ID_PERFIL  is null OR PERUSU.SEG_PER_ID_PERFIL  = pSEG_PER_ID_PERFIL)
    AND    (pCAD_UNI_ID_UNIDADE is null OR PERUSU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND    (pSEG_MOD_ID_MODULO  is null OR PERUSU.SEG_MOD_ID_MODULO  = pSEG_MOD_ID_MODULO)
    AND    PERFIL.seg_per_id_perfil   = PERUSU.SEG_PER_ID_PERFIL
    ORDER BY PERFIL.seg_per_nm_perfil;
    io_cursor := v_cursor;
  end PRC_SEG_PERFIL_USUARIO_S;
 
