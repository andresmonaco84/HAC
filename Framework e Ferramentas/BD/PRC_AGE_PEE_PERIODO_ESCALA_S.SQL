  --PRC_AGE_PEE_PERIODO_ESCALA_S
  create or replace procedure PRC_AGE_PEE_PERIODO_ESCALA_S 
  (
     pAGE_PEE_ID IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_PEE_PERIODO_ESCALA_S
  * 
  *    Data Criacao: 	  10/07/2007   Por: Carlos Eduardo
  *    Data Alteracao:	             Por:
  *
  *    Funcao: Lista todos os períodos de escalas médicas
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       AGE_PEE_CD_PERIODO_ESCALA,
       AGE_PEE_ID,
       AGE_PEE_DS_PERIODO_ESCALA,
       AGE_PEE_HR_INI_PERIODO_ESCALA,
       AGE_PEE_HR_FIM_PERIODO_ESCALA
    FROM TB_AGE_PEE_PERIODO_ESCALA
    WHERE
        (pAGE_PEE_ID is null OR AGE_PEE_ID = pAGE_PEE_ID)
    ORDER BY AGE_PEE_HR_INI_PERIODO_ESCALA;
    io_cursor := v_cursor;
  end PRC_AGE_PEE_PERIODO_ESCALA_S;
/
