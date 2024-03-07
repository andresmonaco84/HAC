  create or replace procedure PRC_SEG_PER_PERFIL_MOD_DISP_S
  (
       pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type,
       io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PER_PERFIL_MOD_DISP_S
  *
  *    Data Criacao: 	26/02/2007   Por: Andrea Cazuca
  *    Data Alteracao: 24/05/2007            Por: Carlos Eduardo
  *    Alteração: Campo seg_per_id_atualizado_por renomeado para seg_usu_id_usuario
  *
  *    Funcao: Obtém os perfis "Não" associados ao Módulo
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       PER.SEG_PER_ID_PERFIL,
       PER.SEG_PER_NM_PERFIL,
       PER.SEG_PER_FL_STATUS,
       PER.SEG_PER_DT_ULTIMA_ATUALIZACAO,
       PER.SEG_USU_ID_USUARIO
    FROM TB_SEG_PER_PERFIL PER
    WHERE
    NOT EXISTS (SELECT 1
                FROM   TB_SEG_MPF_MODULO_PERFIL MPF                  
                WHERE  PER.SEG_PER_ID_PERFIL  = MPF.SEG_PER_ID_PERFIL
                AND    MPF.SEG_MOD_ID_MODULO  = pSEG_MOD_ID_MODULO)
    ORDER BY PER.SEG_PER_NM_PERFIL;       
        
    io_cursor := v_cursor;
  
end PRC_SEG_PER_PERFIL_MOD_DISP_S;
/
