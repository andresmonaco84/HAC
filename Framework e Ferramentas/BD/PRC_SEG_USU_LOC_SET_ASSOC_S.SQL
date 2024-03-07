CREATE OR REPLACE PROCEDURE PRC_SEG_USU_LOC_SET_ASSOC_S (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_UNI_ID_UNIDADE%TYPE,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO  IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID  IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_SET_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_LOC_SET_ASSOC_S
  *
  *    Data Criacao: 	31/01/2008   Por: Andrea Cazuca
  *
  *    Funcao: Obtém os usuários associados à Unidade, Local Atendimento e Setor
  *
  *    Data Alteracao: 22/12/2008   Por: Davi Silvestre M. dos Reis
  *    Alteração: Inclusao do campo ID do Responsavel Superior
  * 
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       USU.SEG_USU_ID_USUARIO,
       USU.SEG_USU_DS_NOME,
       USU.SEG_USU_DS_LOGIN,
       USU.SEG_USU_DS_EMAIL,
       USU.SEG_USU_CD_MATRICULA,
       USU.SEG_USU_DS_TELEFONE,
       USU.SEG_USU_DS_RAMAL,
       USU.SEG_USU_FL_TROCAR_SENHA_OK,
       USU.SEG_USU_FL_SENHA_NAO_EXPIRA_OK,
       USU.SEG_USU_DT_EXPIRACAO,
       USU.SEG_USU_FL_STATUS,
       USU.SEG_USU_FL_RESPONS_PERFIL_OK,
       USU.SEG_USU_ID_USU_RESP_SUPERIOR,
       USU.SEG_USU_QT_LOGIN_INVALIDO,
       USU.SEG_USU_TP_INTER_EXTER,
       USU.SEG_USU_DT_ULTIMA_ATUALIZACAO,
       USU.SEG_USU_DT_LOGIN_INVALIDO,
       USU.SEG_USU_ID_ATUALIZADO_POR,
       USU.SEG_USU_DS_CARGO
    FROM TB_SEG_USU_USUARIO USU,
         TB_ASS_ULS_UNID_LOC_SET_USU ULS
    WHERE
         USU.SEG_USU_ID_USUARIO = ULS.SEG_USU_ID_USUARIO
    AND (ULS.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND (ULS.CAD_LAT_ID_LOCAL_ATENDIMENTO  = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
    AND (ULS.CAD_SET_ID  = pCAD_SET_ID)
    ORDER BY USU.SEG_USU_DS_NOME;
    
    io_cursor := v_cursor;
  end PRC_SEG_USU_LOC_SET_ASSOC_S;
/
