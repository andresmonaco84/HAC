CREATE OR REPLACE PROCEDURE "PRC_SEG_USU_USUARIO_UNI_DISP_S" (
     pCAD_UNI_ID_UNIDADE IN TB_SEG_UUN_USUARIO_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pSEG_USU_FL_STATUS  IN TB_SEG_USU_USUARIO.SEG_USU_FL_STATUS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_USUARIO_UNI_DISP_S
  *
  *    Data Criacao: 	 22/02/2007   Por: Carlos Araujo
  *    Data Alteracao: 27/06/2007   Por: Carlos Araujo
  *	   Data Alteracao: 15/02/2008   Por: Silmara
  *    Alteragco: Inclusco de campo Tipo de Usuario (Interno/Externo)
  *    Alteragco: inclusao do campo SEG_USU_DS_CARGO
  *
  *    Data Alteracao: 09/06/2008   Por: Fabiola Lopes
  *    Alteracao: Inclusao de um novo parbmetro (status)
  *
  *    Data Alteracao: 22/12/2008   Por: Davi Silvestre M. dos Reis
  *    Alteração: Inclusao do campo ID do Responsavel Superior
  * 
  *    Funcao: Obtim os usuarios "NCO" associados ` Unidade
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
    FROM TB_SEG_USU_USUARIO USU
    WHERE
    ( pSEG_USU_FL_STATUS IS NULL OR USU.SEG_USU_FL_STATUS = pSEG_USU_FL_STATUS )
    AND NOT EXISTS ( SELECT 1
                     FROM   TB_SEG_UUN_USUARIO_UNIDADE UUN
                     WHERE  USU.SEG_USU_ID_USUARIO = UUN.SEG_USU_ID_USUARIO
                     AND    (UUN.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE) )
    ORDER BY USU.SEG_USU_DS_NOME;

    io_cursor := v_cursor;
  end PRC_SEG_USU_USUARIO_UNI_DISP_S;
/
