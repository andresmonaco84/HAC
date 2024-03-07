create or replace procedure PRC_TIS_TLG_TP_LOGRADOURO_I
  (
     pTIS_TLG_CD_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_CD_TPLOGRADOURO%type,
     pTIS_TLG_DS_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_DS_TPLOGRADOURO%type,
     pSEG_USU_ID_USUARIO      IN TB_TIS_TLG_TP_LOGRADOURO.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TLG_TP_LOGRADOURO_I
  *
  *    Data Criacao: 	    06/03/2007           Por: Fabiola R. Lopes
  *    Data Alteracao:	  28/05/2007           Por: Silmara
  *    Alteracao:         Foi alterado os parametros para gravar em maiusculo
  *    Funcao:            Cadastrar os Tipos de Logradouros
  *
  *******************************************************************/

  begin

    INSERT INTO TB_TIS_TLG_TP_LOGRADOURO
    (
       TIS_TLG_CD_TPLOGRADOURO,
       TIS_TLG_DS_TPLOGRADOURO,
       TIS_TLG_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_TLG_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ
    )
    VALUES
    (
	     pTIS_TLG_CD_TPLOGRADOURO,
	     UPPER(pTIS_TLG_DS_TPLOGRADOURO),
       SYSDATE,
       pSEG_USU_ID_USUARIO,
       SYSDATE,
       pSEG_USU_ID_USUARIO 
    );

  end PRC_TIS_TLG_TP_LOGRADOURO_I;
 