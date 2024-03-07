create or replace procedure PRC_TIS_UTD_UNIDTEMPODOENCA_U
  (
     pTIS_UTD_CD_UNIDTEMPODOENCA IN TB_TIS_UTD_UNIDTEMPODOENCA.TIS_UTD_CD_UNIDTEMPODOENCA%type,
     pTIS_UTD_DS_UNIDTEMPODOENCA IN TB_TIS_UTD_UNIDTEMPODOENCA.TIS_UTD_DS_UNIDTEMPODOENCA%type,
     pTIS_UTD_DT_ULT_ATUALIZACAO IN TB_TIS_UTD_UNIDTEMPODOENCA.TIS_UTD_DT_ULT_ATUALIZACAO%TYPE DEFAULT NULL,
     pSEG_USU_ID_USU_ULT_ATUALIZ IN TB_TIS_UTD_UNIDTEMPODOENCA.SEG_USU_ID_USU_ULT_ATUALIZ%TYPE DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_UTD_UNIDTEMPODOENCA_U
  *
  *    Data Criacao: 	16/04/2007   Por: Silmara
  *    Data Alteracao:	28/05/2007   Por: Silmara
  *    Altera???#o: Foi alterado os par??metros para gravar em mai??sculo
  *    Funcao: Altera???#o da(s)  unidade(s) de tempo de doen??a(s)-TISS
  *
  *******************************************************************/
  begin
    UPDATE TB_TIS_UTD_UNIDTEMPODOENCA
    SET
        TIS_UTD_DS_UNIDTEMPODOENCA = UPPER(pTIS_UTD_DS_UNIDTEMPODOENCA),
       TIS_UTD_DT_ULT_ATUALIZACAO = SYSDATE,
       SEG_USU_ID_USU_ULT_ATUALIZ = pSEG_USU_ID_USU_ULT_ATUALIZ
    WHERE
        TIS_UTD_CD_UNIDTEMPODOENCA = UPPER(pTIS_UTD_CD_UNIDTEMPODOENCA);
  end PRC_TIS_UTD_UNIDTEMPODOENCA_U;
 