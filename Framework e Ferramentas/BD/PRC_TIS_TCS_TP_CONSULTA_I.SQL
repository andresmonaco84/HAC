create or replace procedure PRC_TIS_TCS_TP_CONSULTA_I
  (
     pTIS_TCS_CD_TPCONSULTA IN TB_TIS_TCS_TP_CONSULTA.TIS_TCS_CD_TPCONSULTA%type,
     pTIS_TCS_DS_TPCONSULTA IN TB_TIS_TCS_TP_CONSULTA.TIS_TCS_DS_TPCONSULTA%type,
     pSEG_USU_ID_USUARIO    IN TB_TIS_TCS_TP_CONSULTA.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TCS_TP_CONSULTA_I
  *
  *    Data Criacao: 	17/04/2007   Por: Andrea Cazuca
  *    Data Alteracao: 28/05/2007	 Por: Silmara
  *    Altera???#o:Foi alterado os par??metros para gravar em mai??sculo
  *    Funcao: Insere Tipo de consulta
  *
  *******************************************************************/

  begin

    INSERT INTO TB_TIS_TCS_TP_CONSULTA
    (
       TIS_TCS_CD_TPCONSULTA,
       TIS_TCS_DS_TPCONSULTA,
       TIS_TCS_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_TCS_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ
    )
    VALUES
    (
	     pTIS_TCS_CD_TPCONSULTA,
	     UPPER(pTIS_TCS_DS_TPCONSULTA),
       SYSDATE,
       pSEG_USU_ID_USUARIO,
       SYSDATE,
       pSEG_USU_ID_USUARIO 
    );

  end PRC_TIS_TCS_TP_CONSULTA_I;
 