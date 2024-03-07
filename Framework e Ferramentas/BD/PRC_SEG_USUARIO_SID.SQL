

---bozo

  --PRC_SEG_USU_USUARIO_SID
  create or replace procedure PRC_SEG_USU_USUARIO_SID 
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_USUARIO_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
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
       SEG_USU_CD_PASSWORD,
       SEG_USU_CD_MATRICULA,
       SEG_USU_DS_TELEFONE,
       SEG_USU_DS_RAMAL,
       SEG_USU_FL_TROCAR_SENHA_OK,
       SEG_USU_FL_SENHA_NAO_EXPIRA_OK,
       SEG_USU_DT_EXPIRACAO,
       SEG_USU_FL_STATUS,
       SEG_USU_FL_RESPONS_PERFIL_OK,
       SEG_USU_QT_LOGIN_INVALIDO,
       SEG_USU_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_DT_LOGIN_INVALIDO,
       SEG_USU_ID_ATUALIZADO_POR,
       SEG_USU_TP_INTER_EXTER,
       SEG_USU_DS_CARGO,
       SEG_USU_ID_USU_RESP_SUPERIOR
    FROM TB_SEG_USU_USUARIO
    WHERE
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;          
    io_cursor := v_cursor;
  end PRC_SEG_USU_USUARIO_SID;
