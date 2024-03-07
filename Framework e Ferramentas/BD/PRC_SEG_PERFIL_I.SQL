PROCEDURE PRC_SEG_PERFIL_I
  (  
     pNewIdt OUT integer,
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type,
     pSEG_PER_NM_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_NM_PERFIL%type,
     pSEG_PER_FL_STATUS IN TB_SEG_PER_PERFIL.SEG_PER_FL_STATUS%type,
     pSEG_PER_DT_ULTIMA_ATUALIZACAO IN TB_SEG_PER_PERFIL.SEG_PER_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_MOD_ID_MODULO  IN TB_SEG_MPF_MODULO_PERFIL.seg_mod_id_modulo%TYPE DEFAULT NULL,     
     pSEG_USU_ID_USUARIO IN TB_SEG_PER_PERFIL.SEG_USU_ID_USUARIO%type
--     pSEG_ID_SISTEMA IN TB_SEG_PER_PERFIL.SEG_ID_SISTEMA%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PER_PERFIL_I
  * 
  *    Data Criacao: 	data da  criaÃ§Ã£o   Por: Nome do Analista
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: DescriÃ§Ã£o da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	      lIdtRetorno integer;	  
  begin
	    
	    
    SELECT NVL(MAX(SEG_PER_ID_PERFIL),0) + 1
    INTO lIdtRetorno 
    FROM TB_SEG_PER_PERFIL;	    
	    
    INSERT INTO TB_SEG_PER_PERFIL
    (
       SEG_PER_ID_PERFIL,
       SEG_PER_NM_PERFIL,
       SEG_PER_FL_STATUS,
       SEG_PER_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
--       SEG_ID_SISTEMA
    )
    VALUES
    (
	     lIdtRetorno,
	     pSEG_PER_NM_PERFIL,
	     pSEG_PER_FL_STATUS,
	     SYSDATE, -- pSEG_PER_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
--	     pSEG_ID_SISTEMA
    );

     IF ( pSEG_MOD_ID_MODULO IS NOT NULL ) THEN
      PRC_SEG_MPF_MODULO_PERFIL_I( lIdtRetorno, pSEG_MOD_ID_MODULO );
     END IF;
	
		pNewIdt := lIdtRetorno;	
  end PRC_SEG_PERFIL_I;