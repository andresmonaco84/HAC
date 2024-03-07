  create or replace procedure PRC_SEG_USU_USUARIO_SENHA_U 
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type,
     pSEG_USU_CD_PASSWORD IN TB_SEG_USU_USUARIO.SEG_USU_CD_PASSWORD%type,
     pSEG_USU_DT_EXPIRACAO IN TB_SEG_USU_USUARIO.SEG_USU_DT_EXPIRACAO%type default null
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_USUARIO_SENHA_U
  *
  *    Data Criacao: 	05/03/2007   Por: Carlos Araujo
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: Realiza a troca de senha e atualiza a data de expiração da senha 
  *
  *******************************************************************/  
  begin
    UPDATE TB_SEG_USU_USUARIO
    SET	   
        SEG_USU_CD_PASSWORD         = pSEG_USU_CD_PASSWORD,
        SEG_USU_DT_EXPIRACAO        = pSEG_USU_DT_EXPIRACAO,
        SEG_USU_ID_ATUALIZADO_POR   = pSEG_USU_ID_USUARIO,
        SEG_USU_FL_TROCAR_SENHA_OK  = 'N'
    WHERE
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;	
  end PRC_SEG_USU_USUARIO_SENHA_U;
/
