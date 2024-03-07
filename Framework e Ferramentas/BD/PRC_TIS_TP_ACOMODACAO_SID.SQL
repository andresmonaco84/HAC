create or replace procedure PRC_TIS_TP_ACOMODACAO_SID
  (
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_CD_TIPO_ACOMODACAO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TP_ACOMODACAO_SID
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
       TIS_TAC_CD_TIPO_ACOMODACAO,
       TIS_TAC_DS_TIPO_ACOMODACAO,
       TIS_TAC_PC_ACOMODACAO_HM,
       TIS_TAC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       TIS_TAC_FL_PERM_DIF_CLASSE
    FROM TB_TIS_TAC_TIPO_ACOMODACAO
    WHERE
        TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO;          
    io_cursor := v_cursor;
  end PRC_TIS_TP_ACOMODACAO_SID;
