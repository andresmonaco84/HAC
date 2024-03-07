create or replace procedure PRC_TIS_TDO_TIPODOENCA_I
  (
     pTIS_TDO_CD_TIPODOENCA IN TB_TIS_TDO_TIPODOENCA.TIS_TDO_CD_TIPODOENCA%type,
     pTIS_TDO_DS_TIPODOENCA IN TB_TIS_TDO_TIPODOENCA.TIS_TDO_DS_TIPODOENCA%type,
     
     pTIS_TDO_DT_CRIACAO IN TB_TIS_TDO_TIPODOENCA.TIS_TDO_DT_CRIACAO%TYPE DEFAULT NULL,     
     pSEG_USU_ID_USUARIO_CRIACAO IN TB_TIS_TDO_TIPODOENCA.SEG_USU_ID_USUARIO_CRIACAO%TYPE DEFAULT NULL,
     pTIS_TDO_DT_ULT_ATUALIZACAO IN TB_TIS_TDO_TIPODOENCA.TIS_TDO_DT_ULT_ATUALIZACAO%TYPE DEFAULT NULL,
     pSEG_USU_ID_USU_ULT_ATUALIZ IN TB_TIS_TDO_TIPODOENCA.SEG_USU_ID_USU_ULT_ATUALIZ%TYPE DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TDO_TIPODOENCA_I
  *
  *    Data Criacao: 	16/04/2007   Por: Silmara
  *    Data Alteracao:	28/05/2007  Por: Silmara
  *    Altera???#o: Foi alterado os par??metros para gravar em mai??sculo
  *    Funcao: Inclui tipo(s) de doen??a(s) - TISS
  *
  *******************************************************************/

  begin

    INSERT INTO TB_TIS_TDO_TIPODOENCA
    (
       TIS_TDO_CD_TIPODOENCA,
       TIS_TDO_DS_TIPODOENCA,
       TIS_TDO_DT_CRIACAO,
      SEG_USU_ID_USUARIO_CRIACAO,
      TIS_TDO_DT_ULT_ATUALIZACAO,
      SEG_USU_ID_USU_ULT_ATUALIZ

    )
    VALUES
    (
	     UPPER(pTIS_TDO_CD_TIPODOENCA),
	     UPPER(pTIS_TDO_DS_TIPODOENCA),
       SYSDATE,
       pSEG_USU_ID_USUARIO_CRIACAO,
       SYSDATE,
       pSEG_USU_ID_USU_ULT_ATUALIZ

    );

  end PRC_TIS_TDO_TIPODOENCA_I;
 