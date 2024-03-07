
  --PRC_AUX_UFE_UF_RMT_SID
  create or replace procedure PRC_AUX_UFE_UF_RMT_SID 
  (
     pAUX_UFE_SG_UF IN TB_AUX_UFE_UF.AUX_UFE_SG_UF%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_UFE_UF_RMT_SID
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
       AUX_UFE_SG_UF,
       AUX_UFE_NM_UF
    FROM TB_AUX_UFE_UF
    WHERE
        AUX_UFE_SG_UF = pAUX_UFE_SG_UF;          
    io_cursor := v_cursor;
  end PRC_AUX_UFE_UF_RMT_SID;
