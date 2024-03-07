PROCEDURE PRC_SEG_PERFIL_U
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type,
     pSEG_PER_NM_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_NM_PERFIL%type,
     pSEG_PER_FL_STATUS IN TB_SEG_PER_PERFIL.SEG_PER_FL_STATUS%type,
     pSEG_PER_DT_ULTIMA_ATUALIZACAO IN TB_SEG_PER_PERFIL.SEG_PER_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type,     
     pSEG_USU_ID_USUARIO IN TB_SEG_PER_PERFIL.SEG_USU_ID_USUARIO%type
     -- pSEG_ID_SISTEMA IN TB_SEG_PER_PERFIL.SEG_ID_SISTEMA%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PER_PERFIL_U
  * 
  *    Data Criacao: 	data da  criaÃ§Ã£o   Por: Nome do Analista
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: DescriÃ§Ã£o da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_SEG_PER_PERFIL
    SET	   
        SEG_PER_NM_PERFIL = pSEG_PER_NM_PERFIL,
        SEG_PER_FL_STATUS = pSEG_PER_FL_STATUS,
        SEG_PER_DT_ULTIMA_ATUALIZACAO = sysdate,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
        -- SEG_ID_SISTEMA = pSEG_ID_SISTEMA 
    WHERE SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;	
    
    IF (  pSEG_MOD_ID_MODULO is not null ) THEN
       -- TENTA ATUALIZAR PERFIS QUE ESTAVAM SE RELACIONAMENTO COM MODULO
       BEGIN
          PRC_SEG_MPF_MODULO_PERFIL_I( pSEG_PER_ID_PERFIL, pSEG_MOD_ID_MODULO );
       EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
          -- SE JA EXISTIR NAO FAZ NADA, NÃO PODE SUBSTITUIR RELACIONAMETO QUE JA EXISTE
          NULL;
       END;
    END IF;
    
  end PRC_SEG_PERFIL_U;