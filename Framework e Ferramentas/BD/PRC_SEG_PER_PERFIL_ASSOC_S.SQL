  create or replace procedure PRC_SEG_PER_PERFIL_ASSOC_S 
  (
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_USU_ID_USUARIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PER_PERFIL_ASSOC_S
  *
  *    Data Criacao: 	21/02/2007   Por: Carlos Araujo
  *    Data Alteracao: 24/05/2007            Por: Carlos Eduardo
  *    Alteração: Campo seg_per_id_atualizado_por renomeado para seg_usu_id_usuario
  *
  *    Funcao: Obtém os perfis associados à Unidade, Módulo e Usuario
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
    FROM TB_SEG_PER_PERFIL PER,
         TB_SEG_PEU_PERMISSAO_USUARIO PEU         
    WHERE
         PER.SEG_PER_ID_PERFIL  = PEU.SEG_PER_ID_PERFIL
    AND (PEU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND (PEU.SEG_MOD_ID_MODULO  = pSEG_MOD_ID_MODULO)
    AND (PEU.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO)
    ORDER BY PER.SEG_PER_NM_PERFIL;       
        
    io_cursor := v_cursor;
  end PRC_SEG_PER_PERFIL_ASSOC_S;
/
