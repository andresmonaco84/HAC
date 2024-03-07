  --PRC_AUX_TP_TEL_END_RMT_SID
  create or replace procedure PRC_AUX_TP_TEL_END_RMT_SID 
  (
     pAUX_TTE_CD_TP_TEL_END IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TP_TEL_END%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_TP_TEL_END_RMT_SID
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
       AUX_TTE_CD_TP_TEL_END,
       AUX_TTE_NM_TIPO,
       AUX_TTE_CD_TIPO
    FROM TB_AUX_TTE_TP_TEL_ENDERECO
    WHERE
        AUX_TTE_CD_TP_TEL_END = pAUX_TTE_CD_TP_TEL_END;          
    io_cursor := v_cursor;
  end PRC_AUX_TP_TEL_END_RMT_SID;
