  --PRC_TIS_CBO_CBOS_RMT_SID
  create or replace procedure PRC_TIS_CBO_CBOS_RMT_SID 
  (
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_CBOS_RMT_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
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
       TIS_CBO_VL_IDADE_LIMITE_ESP
    FROM TB_TIS_CBO_CBOS
    WHERE
        TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;          
    io_cursor := v_cursor;
  end PRC_TIS_CBO_CBOS_RMT_SID;
