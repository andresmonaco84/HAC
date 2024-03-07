CREATE OR REPLACE PROCEDURE PRC_SEG_PERFIL_S
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type DEFAULT NULL,
     pSEG_PER_NM_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_NM_PERFIL%type DEFAULT NULL,
     pSEG_PER_FL_STATUS IN TB_SEG_PER_PERFIL.SEG_PER_FL_STATUS%type DEFAULT NULL,
--     pSEG_USU_ID_USUARIO IN TB_SEG_PER_PERFIL.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pSEG_MOD_ID_MODULO  IN TB_SEG_MPF_MODULO_PERFIL.seg_mod_id_modulo%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PER_PERFIL_S
  *
  *    Data Criacao:  07/2009   Por: RICARDO COSTA
  *    Data Alteracao: 25/03/2010  Por: RICARDO COSTA
            Alteração: Retirada do  parametro Usuário, aqui lista todos os perfis
                       não de um usuário especifico, que deve ser chamada da perfil usuário
  *    Data Alteracao:	25/02/2013  Por: André
  *         Alteracao:	Inclusão de order by
  *
  *    Funcao: lista todos os perfis do modulo passado como parametro  
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       PER.SEG_PER_ID_PERFIL,
       PER.SEG_PER_NM_PERFIL,
       PER.SEG_PER_FL_STATUS,
       PER.SEG_PER_DT_ULTIMA_ATUALIZACAO,
       PER.SEG_USU_ID_USUARIO,
       MPF.SEG_MOD_ID_MODULO
    FROM TB_SEG_PER_PERFIL        PER,
         TB_SEG_MPF_MODULO_PERFIL MPF
    WHERE (pSEG_PER_ID_PERFIL is null OR PER.SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL)
    AND   (pSEG_PER_NM_PERFIL is null OR PER.SEG_PER_NM_PERFIL = pSEG_PER_NM_PERFIL)
    AND   (pSEG_PER_FL_STATUS is null OR PER.SEG_PER_FL_STATUS = pSEG_PER_FL_STATUS)
--    AND   (pSEG_USU_ID_USUARIO is null OR PER.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO)
    AND   (pSEG_MOD_ID_MODULO IS NULL OR MPF.SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO)
    AND   (PER.seg_per_id_perfil = MPF.seg_per_id_perfil)
    ORDER BY PER.SEG_PER_NM_PERFIL;
    io_cursor := v_cursor;
  end PRC_SEG_PERFIL_S;
 
