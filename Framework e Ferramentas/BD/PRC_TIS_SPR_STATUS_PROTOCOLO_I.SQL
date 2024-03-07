create or replace procedure PRC_TIS_SPR_STATUS_PROTOCOLO_I
  (
     pTIS_SPR_CD_STATUS  IN TB_TIS_SPR_STATUS_PROTOCOLO.TIS_SPR_CD_STATUS%type,
     pTIS_SPR_DS_STATUS  IN TB_TIS_SPR_STATUS_PROTOCOLO.TIS_SPR_DS_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_TIS_SPR_STATUS_PROTOCOLO.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: {nome da procedure}
  *
  *    Data Criacao: 	data da  cria???#o   Por: Nome do Analista
  *    Data Alteracao:	25/05/2007  Por: Silmara
  *    Altera???#o:Foi alterado os par??metros para gravar em mai??sculo
  *    Funcao: Descri???#o da funcionalidade da Stored Procedure
  *
  *******************************************************************/

  begin

    INSERT INTO TB_TIS_SPR_STATUS_PROTOCOLO
    (
       TIS_SPR_CD_STATUS,
       TIS_SPR_DS_STATUS,
       TIS_SPR_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_SPR_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_ULT_ATUALIZ 
    )
    VALUES
    (
	     pTIS_SPR_CD_STATUS,
	     UPPER(pTIS_SPR_DS_STATUS),
       SYSDATE,
       pSEG_USU_ID_USUARIO,
       SYSDATE,
       pSEG_USU_ID_USUARIO
    );

  end PRC_TIS_SPR_STATUS_PROTOCOLO_I;