create or replace procedure PRC_TIS_TSS_TIPOSAIDA_SADT_I
  (
     pTIS_TSS_CD_TIPOSAIDA IN TB_TIS_TSS_TIPOSAIDA_SADT.TIS_TSS_CD_TIPOSAIDA%type,
     pTIS_TSS_DS_TIPOSAIDA IN TB_TIS_TSS_TIPOSAIDA_SADT.TIS_TSS_DS_TIPOSAIDA%type,
     pSEG_USU_ID_USUARIO      IN TB_TIS_TSS_TIPOSAIDA_SADT.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: {nome da procedure}
  *
  *    Data Criacao: 	data da  cria???#o   Por: Nome do Analista
  *    Data Alteracao:	28/05/2007         Por: Silmara
  *    Altera???#o: Foi alterado os par??metros para gravar em mai??sculo
  *    Funcao: Descri???#o da funcionalidade da Stored Procedure
  *
  *******************************************************************/

  begin

    INSERT INTO TB_TIS_TSS_TIPOSAIDA_SADT
    (
       TIS_TSS_CD_TIPOSAIDA,
       TIS_TSS_DS_TIPOSAIDA,
       TIS_TSS_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_TSS_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ
    )
    VALUES
    (
	     pTIS_TSS_CD_TIPOSAIDA,
	     UPPER(pTIS_TSS_DS_TIPOSAIDA),
       SYSDATE,
       pSEG_USU_ID_USUARIO,
       SYSDATE,
       pSEG_USU_ID_USUARIO 
    );

  end PRC_TIS_TSS_TIPOSAIDA_SADT_I;
 