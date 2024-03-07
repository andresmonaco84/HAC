create or replace procedure PRC_SEG_USU_USUARIO_S
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pSEG_USU_CD_MATRICULA IN TB_SEG_USU_USUARIO.SEG_USU_CD_MATRICULA%type DEFAULT NULL,
     pSEG_USU_DS_NOME IN TB_SEG_USU_USUARIO.SEG_USU_DS_NOME%type DEFAULT NULL,
     pSEG_USU_DS_LOGIN IN TB_SEG_USU_USUARIO.SEG_USU_DS_LOGIN%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_USUARIO_S
  *
  *    Data Criacao: 	01/02/2007   Por: Carlos Araujo
  *    Data Alteracao: 27/06/2007   Por: Carlos Araujo
  *    Alteração: Inclusão de campo Tipo de Usuario (Interno/Externo)
  *
  *    Funcao: Obtém Usuário(s) por filtros específicos (opcional)
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *
  *    Data Alteracao: 18/01/2008  Por: Fabiola Lopes
  *    Alteracao: Inclusao de um campo (cargo)
  *
  *    Data Alteracao: 11/12/2008   Por: Davi Silvestre M. dos Reis
  *    Alteração: Inclusao do campo ID do Responsavel Superior
  * 
  *******************************************************************/      
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       SEG_USU_ID_USUARIO,
       SEG_USU_DS_NOME,
       SEG_USU_DS_LOGIN,
       SEG_USU_DS_EMAIL,
       SEG_USU_CD_MATRICULA,
       SEG_USU_DS_TELEFONE,
       SEG_USU_DS_RAMAL,
       SEG_USU_FL_TROCAR_SENHA_OK,
       SEG_USU_FL_SENHA_NAO_EXPIRA_OK,
       SEG_USU_DT_EXPIRACAO,
       SEG_USU_FL_STATUS,
       SEG_USU_FL_RESPONS_PERFIL_OK,
       SEG_USU_ID_USU_RESP_SUPERIOR,
       SEG_USU_QT_LOGIN_INVALIDO,
       SEG_USU_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_DT_LOGIN_INVALIDO,
       SEG_USU_TP_INTER_EXTER,
       SEG_USU_ID_ATUALIZADO_POR,
       SEG_USU_DS_CARGO
    FROM TB_SEG_USU_USUARIO
    WHERE
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO)
    AND (pSEG_USU_CD_MATRICULA is null OR SEG_USU_CD_MATRICULA  = PSEG_USU_CD_MATRICULA)        
    AND (pSEG_USU_DS_NOME is null OR SEG_USU_DS_NOME LIKE UPPER(pSEG_USU_DS_NOME))
    AND (pSEG_USU_DS_LOGIN is null OR SEG_USU_DS_LOGIN = UPPER(pSEG_USU_DS_LOGIN))
    ORDER BY SEG_USU_DS_NOME;
    io_cursor := v_cursor;
  end PRC_SEG_USU_USUARIO_S;
/
