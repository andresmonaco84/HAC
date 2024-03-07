create or replace procedure PRC_SEG_USU_USUARIO_U
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type,
     pSEG_USU_DS_NOME IN TB_SEG_USU_USUARIO.SEG_USU_DS_NOME%type,
     pSEG_USU_DS_LOGIN IN TB_SEG_USU_USUARIO.SEG_USU_DS_LOGIN%type,
     pSEG_USU_DS_EMAIL IN TB_SEG_USU_USUARIO.SEG_USU_DS_EMAIL%type default NULL,
     pSEG_USU_CD_MATRICULA IN TB_SEG_USU_USUARIO.SEG_USU_CD_MATRICULA%type default NULL,
     pSEG_USU_DS_TELEFONE IN TB_SEG_USU_USUARIO.SEG_USU_DS_TELEFONE%type default NULL,
     pSEG_USU_DS_RAMAL IN TB_SEG_USU_USUARIO.SEG_USU_DS_RAMAL%type default NULL,
     pSEG_USU_FL_TROCAR_SENHA_OK IN TB_SEG_USU_USUARIO.SEG_USU_FL_TROCAR_SENHA_OK%type default NULL,
     pSEG_USU_FL_SENHA_NAO_EXPIRA IN TB_SEG_USU_USUARIO.SEG_USU_FL_SENHA_NAO_EXPIRA_OK%type default NULL,
     pSEG_USU_DT_EXPIRACAO IN TB_SEG_USU_USUARIO.SEG_USU_DT_EXPIRACAO%type default NULL,
     pSEG_USU_FL_STATUS IN TB_SEG_USU_USUARIO.SEG_USU_FL_STATUS%type default NULL,
     pSEG_USU_FL_RESPONS_PERFIL_OK IN TB_SEG_USU_USUARIO.SEG_USU_FL_RESPONS_PERFIL_OK%type,
     pSEG_USU_ID_USU_RESP_SUPERIOR IN TB_SEG_USU_USUARIO.SEG_USU_ID_USU_RESP_SUPERIOR%type default NULL,
     pSEG_USU_ID_ATUALIZADO_POR IN TB_SEG_USU_USUARIO.SEG_USU_ID_ATUALIZADO_POR%type default NULL,
     pSEG_USU_TP_INTER_EXTER IN TB_SEG_USU_USUARIO.SEG_USU_TP_INTER_EXTER%type,
     pSEG_USU_DS_CARGO IN TB_SEG_USU_USUARIO.SEG_USU_DS_CARGO%TYPE DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_USUARIO_U
  *
  *    Data Criacao: 	01/02/2007   Por: Carlos Araujo
  *    Data Alteracao:	28/05/2007   Por: Silmara
  *    Alteracao:Foi alterado os parametros para gravar em maiusculo e e-mail em minusculo
  *
  *    Data Alteracao: 27/06/2007   Por: Carlos Araujo
  *    Alteração: Inclusão de campo Tipo de Usuario (Interno/Externo)
  *
  *    Data Alteracao: 18/01/2008   Por: Fabiolal Lopes
  *    Alteração: Inclusão de um campo (Cargo)
  *
  *    Data Alteracao: 11/12/2008   Por: Davi Silvestre M. dos Reis
  *    Alteração: Inclusao do campo ID do Responsavel Superior
  *
  *    Funcao: Altera um Usuário
  *
  *******************************************************************/
  begin
    UPDATE TB_SEG_USU_USUARIO
    SET
        SEG_USU_DS_NOME = UPPER(pSEG_USU_DS_NOME),
        SEG_USU_DS_LOGIN = UPPER(pSEG_USU_DS_LOGIN),
        SEG_USU_DS_EMAIL = LOWER(pSEG_USU_DS_EMAIL),
        SEG_USU_CD_MATRICULA = pSEG_USU_CD_MATRICULA,
        SEG_USU_DS_TELEFONE = UPPER(pSEG_USU_DS_TELEFONE),
        SEG_USU_DS_RAMAL = UPPER(pSEG_USU_DS_RAMAL),
        SEG_USU_FL_TROCAR_SENHA_OK = pSEG_USU_FL_TROCAR_SENHA_OK,
        SEG_USU_FL_SENHA_NAO_EXPIRA_OK = pSEG_USU_FL_SENHA_NAO_EXPIRA,
        SEG_USU_DT_EXPIRACAO = pSEG_USU_DT_EXPIRACAO,
        SEG_USU_FL_STATUS = pSEG_USU_FL_STATUS,
        SEG_USU_FL_RESPONS_PERFIL_OK = pSEG_USU_FL_RESPONS_PERFIL_OK,
        SEG_USU_ID_USU_RESP_SUPERIOR = pSEG_USU_ID_USU_RESP_SUPERIOR,
        SEG_USU_DT_ULTIMA_ATUALIZACAO = sysdate(),
        SEG_USU_ID_ATUALIZADO_POR = pSEG_USU_ID_ATUALIZADO_POR,
        SEG_USU_TP_INTER_EXTER = pSEG_USU_TP_INTER_EXTER,
        SEG_USU_DS_CARGO = pSEG_USU_DS_CARGO
    WHERE
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;
  end PRC_SEG_USU_USUARIO_U;
/
