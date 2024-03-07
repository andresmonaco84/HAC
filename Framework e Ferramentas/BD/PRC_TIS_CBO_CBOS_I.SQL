CREATE OR REPLACE PROCEDURE "PRC_TIS_CBO_CBOS_I" (
     pTIS_CBO_CD_CBOS             IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type,
     pTIS_CBO_DS_CBOS             IN TB_TIS_CBO_CBOS.TIS_CBO_DS_CBOS%type,
     pTIS_CBO_FL_STATUS_ENCAMINHA IN TB_TIS_CBO_CBOS.TIS_CBO_FL_STATUS_ENCAMINHA%type,
     pTIS_CBO_CD_CBOS_HAC         IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS_HAC%type default null,
     pTIS_CBO_DS_CBOS_HAC         IN TB_TIS_CBO_CBOS.TIS_CBO_DS_CBOS_HAC%type default null,
     pTIS_CBO_FL_QTD_ATE_LIMITADA IN TB_TIS_CBO_CBOS.TIS_CBO_FL_QTD_ATE_LIMITADA%type default null,
     PTIS_CBO_QT_ATEND_PERM_ANO   IN TB_TIS_CBO_CBOS.TIS_CBO_QT_ATEND_PERM_ANO%type default null,
     PTIS_CBO_VL_IDADE_LIMITE_ESP IN TB_TIS_CBO_CBOS.TIS_CBO_VL_IDADE_LIMITE_ESP%type default null,
     PTIS_CBO_CD_CBOS_NOVO        IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS_NOVO%type default null,
     PTIS_CBO_FL_STATUS           IN TB_TIS_CBO_CBOS.TIS_CBO_FL_STATUS%type,
     PTIS_CBO_CD_CBOS_V3          IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS_V3%type default null,
     pSEG_USU_ID_USUARIO          IN TB_TIS_CBO_CBOS.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_CBOS_I
  *
  *    Data Criacao:   07/03/2007    Por: Andréa Cazuca
  *    Data Alteracao:  25/05/2007    Por: Silmara
  *    Alteração:    Foi alterado os parâmetros para gravar em maiúsculo
  *    Funcao:      Insere dados de CBO-S na tabela TB_TIS_CBO_CBOS
  *
  *
  *    Alteração:  31/08/2007      Por: Guilherme Holdack
  *    Descrição:  inclusão de novo campo na tabela (TIS_CBO_FL_STATUS_ENCAMINHA)
  *
  *
  *     Data Alteração:  20/09/2009    Por:  Fabíola Lopes
  *     Função:      Inclusão de novos campo na tabela (TIS_CBO_CD_CBOS_HAC, TIS_CBO_DS_CBOS_HAC)
  *
  *     Data Alteração:  28/07/2008    Por:  Pedro Carvalho
  *     Função:      Inclusão de novos campo na tabela (TIS_CBO_FL_QTD_ATE_LIMITADA CHAR(1), TIS_CBO_QT_ATEND_PERM_ANO NUMBER(3))
  *
  *     Data Alteração:  30/10/2013    Por:  Andréa Cazuca
  *     Alteração:    Inclusão de novos campos na tabela (TIS_CBO_VL_IDADE_LIMITE_ESP, TIS_CBO_CD_CBOS_NOVO e TIS_CBO_FL_STATUS
  *
  *     Data Alteração:  20/03/2014     Por: Andréa Cazuca
  *     Alteração:    Inclusão de novos campos na tabela (TIS_CBO_CD_CBOS_V3)
  *
  *******************************************************************/

  begin

    INSERT INTO TB_TIS_CBO_CBOS
    (
       TIS_CBO_CD_CBOS,
       TIS_CBO_DS_CBOS,
       TIS_CBO_FL_STATUS_ENCAMINHA,
       TIS_CBO_CD_CBOS_HAC,
       TIS_CBO_DS_CBOS_HAC,
       TIS_CBO_FL_QTD_ATE_LIMITADA,
       TIS_CBO_QT_ATEND_PERM_ANO,
       TIS_CBO_VL_IDADE_LIMITE_ESP,
       TIS_CBO_CD_CBOS_NOVO,
       TIS_CBO_FL_STATUS,
       TIS_CBO_CD_CBOS_V3,
       TIS_CBO_DT_CRIACAO ,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_CBO_DT_ULT_ATUALIZACAO ,
       SEG_USU_ID_USUARIO_ULT_ATUALIZ 
    )
    VALUES
    (
       pTIS_CBO_CD_CBOS,
       UPPER(pTIS_CBO_DS_CBOS),
       pTIS_CBO_FL_STATUS_ENCAMINHA,
       UPPER(pTIS_CBO_CD_CBOS_HAC),
       UPPER(pTIS_CBO_DS_CBOS_HAC),
       UPPER(pTIS_CBO_FL_QTD_ATE_LIMITADA),
       PTIS_CBO_QT_ATEND_PERM_ANO,
       PTIS_CBO_VL_IDADE_LIMITE_ESP,
       PTIS_CBO_CD_CBOS_NOVO,
       PTIS_CBO_FL_STATUS,
       PTIS_CBO_CD_CBOS_V3,
       SYSDATE,
       pSEG_USU_ID_USUARIO,
       SYSDATE,
       pSEG_USU_ID_USUARIO 
    );

  end PRC_TIS_CBO_CBOS_I;
