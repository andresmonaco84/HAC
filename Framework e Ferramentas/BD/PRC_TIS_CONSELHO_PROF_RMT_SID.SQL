  --PRC_TIS_CONSELHO_PROF_RMT_SID
  create or replace procedure PRC_TIS_CONSELHO_PROF_RMT_SID 
  (
     pTIS_CPR_CD_CONSELHOPROF IN TB_TIS_CPR_CONSELHO_PROF.TIS_CPR_CD_CONSELHOPROF%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CONSELHO_PROF_RMT_SID
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
       TIS_CPR_CD_CONSELHOPROF,
       TIS_CPR_DS_CONSELHOPROF
    FROM TB_TIS_CPR_CONSELHO_PROF
    WHERE
        TIS_CPR_CD_CONSELHOPROF = pTIS_CPR_CD_CONSELHOPROF;          
    io_cursor := v_cursor;
  end PRC_TIS_CONSELHO_PROF_RMT_SID;
