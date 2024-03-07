  create or replace procedure PRC_SEG_PER_PERFIL_U 
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type,
     pSEG_PER_NM_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_NM_PERFIL%type,
     pSEG_PER_FL_STATUS IN TB_SEG_PER_PERFIL.SEG_PER_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PER_PERFIL_U
  * 
  *    Data Criacao: 	 01/03/2007            Por: Carlos Eduardo
  *    Data Alteracao: 24/05/2007            Por: Carlos Eduardo
  *    Alteração: Campo seg_per_id_atualizado_por renomeado para seg_usu_id_usuario
  *    Data Alteracao: 28/05/2007              Por:Silmara
  *    Alteracao:Foi alterado os parametros para gravar em maiusculo
  *    Funcao: Altera um Perfil de segurança 
  *
  *******************************************************************/                                
  begin
    UPDATE TB_SEG_PER_PERFIL
    SET	   
        SEG_PER_NM_PERFIL = UPPER(pSEG_PER_NM_PERFIL),
        SEG_PER_FL_STATUS = pSEG_PER_FL_STATUS,
        SEG_PER_DT_ULTIMA_ATUALIZACAO = SYSDATE(),
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;	
  end PRC_SEG_PER_PERFIL_U;
/
