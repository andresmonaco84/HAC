---bozo

  --PRC_ASS_PMD_PESSOA_MD5_SID
  create or replace procedure PRC_ASS_PMD_PESSOA_MD5_SID 
  (
     pASS_PMD_ID IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PMD_PESSOA_MD5_SID
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
       ASS_PMD_ID,
       ASS_PMD_CD_MD5,
       CAD_PES_ID_PESSOA,
       ASS_PMD_NM_PESSOA,
       ASS_PMD_DT_NASCIMENTO,
       ASS_PMD_TP_SEXO,
       ASS_PMD_DT_CRIACAO,
       ASS_PMD_DT_DESATIVACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       SEG_USU_ID_USUARIO_DESATIVACAO
    FROM TB_ASS_PMD_PESSOA_MD5
    WHERE
        ASS_PMD_ID = pASS_PMD_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_PMD_PESSOA_MD5_SID;

