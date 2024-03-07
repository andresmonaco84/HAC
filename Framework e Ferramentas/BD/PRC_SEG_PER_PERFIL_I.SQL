  create or replace procedure PRC_SEG_PER_PERFIL_I 
  (
     pNewIdt OUT integer,
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type default NULL,
     pSEG_PER_NM_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_NM_PERFIL%type,
     pSEG_PER_FL_STATUS IN TB_SEG_PER_PERFIL.SEG_PER_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PER_PERFIL_I
  * 
  *    Data Criacao: 	01/03/2007             Por: Carlos Eduardo
  *    Data Alteracao: 24/05/2007            Por: Carlos Eduardo
  *    Alteração: Campo seg_per_id_atualizado_por renomeado para seg_usu_id_usuario
  *    Data Alteracao: 28/05/2007             Por:Silmara
  *    Alteracao:Foi alterado os parametros para gravar em maiusculo  
  *    Funcao: Inclui um Perfil de segurança 
  *
  *******************************************************************/                              
  lIdtRetorno integer;	  
  begin
    SELECT SEQ_SEG_PER_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_SEG_PER_PERFIL
    (
       SEG_PER_ID_PERFIL,
       SEG_PER_NM_PERFIL,
       SEG_PER_FL_STATUS,
       SEG_PER_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	     lIdtRetorno,
	     UPPER(pSEG_PER_NM_PERFIL),
	     pSEG_PER_FL_STATUS,
	     SYSDATE(),
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_SEG_PER_PERFIL_I;
/
