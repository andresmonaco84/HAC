  --PRC_TIS_TSC_TIPOSAIDACONSULTA_S
  create or replace procedure PRC_TIS_TSC_TIPOSAIDACONS_S 
  (
     pTIS_TSC_CD_TIPOSAIDACONSULTA IN TB_TIS_TSC_TIPOSAIDACONSULTA.TIS_TSC_CD_TIPOSAIDACONSULTA%type DEFAULT NULL,
     pTIS_TSC_DS_TIPOSAIDACONSULTA IN TB_TIS_TSC_TIPOSAIDACONSULTA.TIS_TSC_DS_TIPOSAIDACONSULTA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TSC_TIPOSAIDACONS_S 
  * 
  *    Data Criacao: 	12/04/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 02/05/2007   Por: Cristiane Gomes da Silva
  *
  *    Funcao: Obtém Tipo(s) de Saída para Consulta - TISS
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       TIS_TSC_CD_TIPOSAIDACONSULTA,
       TIS_TSC_DS_TIPOSAIDACONSULTA,
	   TIS_TSC_FL_STATUS
    FROM TB_TIS_TSC_TIPOSAIDACONSULTA
    WHERE
        ((pTIS_TSC_CD_TIPOSAIDACONSULTA is null OR TIS_TSC_CD_TIPOSAIDACONSULTA = pTIS_TSC_CD_TIPOSAIDACONSULTA)          
        AND (pTIS_TSC_DS_TIPOSAIDACONSULTA is null OR TIS_TSC_DS_TIPOSAIDACONSULTA LIKE UPPER('%'||pTIS_TSC_DS_TIPOSAIDACONSULTA||'%')))
        ORDER BY TIS_TSC_CD_TIPOSAIDACONSULTA;
    io_cursor := v_cursor;
  end PRC_TIS_TSC_TIPOSAIDACONS_S;
/
