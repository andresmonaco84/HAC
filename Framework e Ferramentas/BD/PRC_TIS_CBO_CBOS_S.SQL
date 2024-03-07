create or replace procedure PRC_TIS_CBO_CBOS_S
  (
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type DEFAULT NULL,
     pTIS_CBO_DS_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_DS_CBOS%type DEFAULT NULL,
     pTIS_CBO_CD_CBOS_HAC IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS_HAC%type DEFAULT NULL,
     pTIS_CBO_DS_CBOS_HAC IN TB_TIS_CBO_CBOS.TIS_CBO_DS_CBOS_HAC%type DEFAULT NULL,
     pTIS_CBO_FL_QTD_ATE_LIMITADA IN TB_TIS_CBO_CBOS.TIS_CBO_FL_QTD_ATE_LIMITADA%type DEFAULT NULL,
     pTIS_CBO_QT_ATEND_PERM_ANO IN TB_TIS_CBO_CBOS.TIS_CBO_QT_ATEND_PERM_ANO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_CBOS_S
  *
  *    Data Criacao: 	07/03/2007   Por: Andréa Cazuca
  *    Data Alteracao:	           Por:
  *
  *    Funcao: Seleciona o CBO-S pelo Código
  *
  *	   Data Alteração:	20/09/2009		Por:	Fabíola Lopes
  *	   Função:			Inclusão de novos campo na tabela (TIS_CBO_CD_CBOS_HAC, TIS_CBO_DS_CBOS_HAC)
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *
  *    Data Alteracao: 18/12/2007  Por: Andréa Cazuca
  *    Alteração: Inclusão do campo TIS_CBO_CD_CBOS_HAC como parametro
  *
  *	   Data Alteração:	28/07/2008		Por:	Pedro Carvalho
  *	   Função:			Inclusão de novos campo na tabela (TIS_CBO_FL_QTD_ATE_LIMITADA CHAR(1), TIS_CBO_QT_ATEND_PERM_ANO NUMBER(3))
  *
  *******************************************************************/


  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
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
     TIS_CBO_CD_CBOS_V3
    FROM TB_TIS_CBO_CBOS
    WHERE
        (pTIS_CBO_CD_CBOS is null OR TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
    AND (pTIS_CBO_DS_CBOS is null OR TIS_CBO_DS_CBOS LIKE UPPER(pTIS_CBO_DS_CBOS))
    AND (pTIS_CBO_CD_CBOS_HAC is null OR TIS_CBO_CD_CBOS_HAC = UPPER(pTIS_CBO_CD_CBOS_HAC))
    AND (pTIS_CBO_DS_CBOS_HAC is null OR TIS_CBO_DS_CBOS_HAC LIKE UPPER(pTIS_CBO_DS_CBOS_HAC))
    AND (pTIS_CBO_FL_QTD_ATE_LIMITADA is null or TIS_CBO_FL_QTD_ATE_LIMITADA LIKE UPPER(pTIS_CBO_FL_QTD_ATE_LIMITADA))
    AND (pTIS_CBO_QT_ATEND_PERM_ANO is null or TIS_CBO_QT_ATEND_PERM_ANO LIKE pTIS_CBO_QT_ATEND_PERM_ANO)
    ORDER BY TIS_CBO_DS_CBOS_HAC;
    io_cursor := v_cursor;
  end PRC_TIS_CBO_CBOS_S;