  --PRC_AUX_NACIONALIDADE_RMT_SID
  create or replace procedure PRC_AUX_NACIONALIDADE_RMT_SID 
  (
     pAUX_NAC_CD_CODIGO IN TB_AUX_NAC_NACIONALIDADE.AUX_NAC_CD_CODIGO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_NACIONALIDADE_RMT_SID
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
       AUX_NAC_CD_CODIGO,
       AUX_NAC_NM_NOME
    FROM TB_AUX_NAC_NACIONALIDADE
    WHERE
        AUX_NAC_CD_CODIGO = pAUX_NAC_CD_CODIGO;          
    io_cursor := v_cursor;
  end PRC_AUX_NACIONALIDADE_RMT_SID;
