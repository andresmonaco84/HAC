create or replace procedure PRC_TIS_TSS_TIPOSAIDA_SADT_U
  (
     pTIS_TSS_CD_TIPOSAIDA IN TB_TIS_TSS_TIPOSAIDA_SADT.TIS_TSS_CD_TIPOSAIDA%type,
     pTIS_TSS_DS_TIPOSAIDA IN TB_TIS_TSS_TIPOSAIDA_SADT.TIS_TSS_DS_TIPOSAIDA%type,
     pSEG_USU_ID_USUARIO   IN TB_TIS_TSS_TIPOSAIDA_SADT.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: {nome da procedure}
  *
  *    Data Criacao: 	data da  cria???#o   Por: Nome do Analista
  *    Data Alteracao:	28/05/2007         Por: Silmara
  *    Altera???#o:Foi alterado os par??metros para gravar em mai??sculo
  *    Funcao: Descri???#o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  begin
    UPDATE TB_TIS_TSS_TIPOSAIDA_SADT
    SET
        TIS_TSS_DS_TIPOSAIDA = UPPER(pTIS_TSS_DS_TIPOSAIDA),
        TIS_TSS_DT_ULT_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USU_ULT_ATUALIZ = pSEG_USU_ID_USUARIO
    WHERE
        TIS_TSS_CD_TIPOSAIDA = pTIS_TSS_CD_TIPOSAIDA;
  end PRC_TIS_TSS_TIPOSAIDA_SADT_U;
 