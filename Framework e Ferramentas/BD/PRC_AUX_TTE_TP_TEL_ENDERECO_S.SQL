  create or replace procedure PRC_AUX_TTE_TP_TEL_ENDERECO_S 
  (
     pAUX_TTE_CD_TP_TEL_END IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TP_TEL_END%type DEFAULT NULL,
     pAUX_TTE_CD_TIPO IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TIPO%type,     
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_TTE_TP_TEL_ENDERECO_S
  * 
  *    Data Criacao: 	25/05/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:	            Por:  
  *
  *    Funcao: Obtém Tipo(s) de Endereço
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       AUX_TTE_CD_TP_TEL_END,
       AUX_TTE_CD_TIPO,
       AUX_TTE_NM_TIPO
    FROM TB_AUX_TTE_TP_TEL_ENDERECO
    WHERE
        ((pAUX_TTE_CD_TP_TEL_END is null OR AUX_TTE_CD_TP_TEL_END = pAUX_TTE_CD_TP_TEL_END)
    AND (AUX_TTE_CD_TIPO = pAUX_TTE_CD_TIPO OR AUX_TTE_CD_TIPO = 'A'));          
    io_cursor := v_cursor;
  end PRC_AUX_TTE_TP_TEL_ENDERECO_S;
/
