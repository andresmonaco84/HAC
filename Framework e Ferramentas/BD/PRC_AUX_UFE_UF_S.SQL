  --PRC_AUX_UFE_UF_S
  create or replace procedure PRC_AUX_UFE_UF_S 
  (
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_UFE_UF_S
  * 
  *    Data Criacao: 	 28/05/2007   Por: Carlos Araujo
  *    Data Alteracao:	            Por: 
  *
  *    Funcao: Lista as UFs em ordem crescente
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       AUX_UFE_SG_UF,
       AUX_UFE_NM_UF
    FROM TB_AUX_UFE_UF
    ORDER BY AUX_UFE_SG_UF;
    io_cursor := v_cursor;
  end PRC_AUX_UFE_UF_S;
/
