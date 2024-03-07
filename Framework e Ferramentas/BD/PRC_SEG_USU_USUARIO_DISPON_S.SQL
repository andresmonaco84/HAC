CREATE OR REPLACE PROCEDURE "PRC_SEG_USU_USUARIO_DISPON_S" (
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type,
     pSEG_MOD_ID_MODULO  IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_MOD_ID_MODULO%type,
     pSEG_PER_ID_PERFIL  IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_PER_ID_PERFIL%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_USUARIO_DISPON_S
  *
  *    Data Criacao: 	21/02/2007   Por: Carlos Araujo
  *    Data Alteracao: 27/06/2007   Por: Carlos Araujo
  *     Data Alteracao: 15/02/2008   Por: Silmara
  *    Alteração: Inclusão de campo Tipo de Usuario (Interno/Externo)
  *    Alteração: Inclusão do campo SEG_USU_DS_CARGO 
  *
  *    Data Alteracao: 22/12/2008   Por: Davi Silvestre M. dos Reis
  *    Alteração: Inclusao do campo ID do Responsavel Superior
  * 
  *    Funcao: Obtém os usuários "NÃO" associados à Unidade, Módulo e Perfil
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
         USU.SEG_USU_DT_ULTIMA_ATUALIZACAO,
         USU.SEG_USU_DT_LOGIN_INVALIDO,
         USU.SEG_USU_TP_INTER_EXTER,
         USU.SEG_USU_ID_ATUALIZADO_POR,
         USU.SEG_USU_DS_CARGO
    FROM TB_SEG_USU_USUARIO USU,
         TB_SEG_UUN_USUARIO_UNIDADE UUN
    WHERE
        USU.SEG_USU_ID_USUARIO = UUN.SEG_USU_ID_USUARIO
    AND UUN.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND NOT EXISTS (SELECT 1
                    FROM   TB_SEG_PEU_PERMISSAO_USUARIO PEU
                    WHERE  USU.SEG_USU_ID_USUARIO = PEU.SEG_USU_ID_USUARIO
                    AND (PEU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                    AND (PEU.SEG_MOD_ID_MODULO  = pSEG_MOD_ID_MODULO)
                    AND (PEU.SEG_PER_ID_PERFIL  = pSEG_PER_ID_PERFIL)
                    )
    ORDER BY USU.SEG_USU_DS_NOME;

    io_cursor := v_cursor;
  end PRC_SEG_USU_USUARIO_DISPON_S;
/
