  create or replace procedure PRC_SEG_PER_PERFIL_S 
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type DEFAULT NULL,
     pSEG_PER_NM_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_NM_PERFIL%type DEFAULT NULL,
     pSEG_PER_FL_STATUS IN TB_SEG_PER_PERFIL.SEG_PER_FL_STATUS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PER_PERFIL_S
  * 
  *    Data Criacao: 	01/03/2007             Por: Carlos Eduardo
  *    Data Alteracao: 24/05/2007            Por: Carlos Eduardo
  *    Alteração: Campo seg_per_id_atualizado_por renomeado para seg_usu_id_usuario
  *
  *    Funcao: Obtém o(s) Perfi(is) de segurança por filtro (Opcional)
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *******************************************************************/                             
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       SEG_PER_ID_PERFIL,
       SEG_PER_NM_PERFIL,
       SEG_PER_FL_STATUS,
       SEG_PER_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_SEG_PER_PERFIL
    WHERE
        (pSEG_PER_ID_PERFIL is null OR SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL)
    AND (pSEG_PER_NM_PERFIL is null OR SEG_PER_NM_PERFIL LIKE UPPER(pSEG_PER_NM_PERFIL))
    AND (pSEG_PER_FL_STATUS  is null OR SEG_PER_FL_STATUS  = pSEG_PER_FL_STATUS)
    ORDER BY SEG_PER_NM_PERFIL;
        
    io_cursor := v_cursor;
  end PRC_SEG_PER_PERFIL_S;
/
