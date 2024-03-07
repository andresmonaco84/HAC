  --PRC_TIS_CBO_CBOS_RMT_U
  create or replace procedure PRC_TIS_CBO_CBOS_RMT_U
  (
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type,
     pTIS_CBO_DS_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_DS_CBOS%type,
     pTIS_CBO_FL_STATUS_ENCAMINHA IN TB_TIS_CBO_CBOS.TIS_CBO_FL_STATUS_ENCAMINHA%type,
     pTIS_CBO_CD_CBOS_HAC IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS_HAC%type default NULL,
     pTIS_CBO_DS_CBOS_HAC IN TB_TIS_CBO_CBOS.TIS_CBO_DS_CBOS_HAC%type default NULL,
     pTIS_CBO_FL_QTD_ATE_LIMITADA IN TB_TIS_CBO_CBOS.TIS_CBO_FL_QTD_ATE_LIMITADA%type default NULL,
     pTIS_CBO_QT_ATEND_PERM_ANO IN TB_TIS_CBO_CBOS.TIS_CBO_QT_ATEND_PERM_ANO%type default NULL,
     pTIS_CBO_VL_IDADE_LIMITE_ESP IN TB_TIS_CBO_CBOS.TIS_CBO_VL_IDADE_LIMITE_ESP%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_CBOS_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_TIS_CBO_CBOS
    SET	   
        TIS_CBO_DS_CBOS = pTIS_CBO_DS_CBOS,
        TIS_CBO_FL_STATUS_ENCAMINHA = pTIS_CBO_FL_STATUS_ENCAMINHA,
        TIS_CBO_CD_CBOS_HAC = pTIS_CBO_CD_CBOS_HAC,
        TIS_CBO_DS_CBOS_HAC = pTIS_CBO_DS_CBOS_HAC,
        TIS_CBO_FL_QTD_ATE_LIMITADA = pTIS_CBO_FL_QTD_ATE_LIMITADA,
        TIS_CBO_QT_ATEND_PERM_ANO = pTIS_CBO_QT_ATEND_PERM_ANO,
        TIS_CBO_VL_IDADE_LIMITE_ESP = pTIS_CBO_VL_IDADE_LIMITE_ESP 
    WHERE
        TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;	
  end PRC_TIS_CBO_CBOS_RMT_U;

