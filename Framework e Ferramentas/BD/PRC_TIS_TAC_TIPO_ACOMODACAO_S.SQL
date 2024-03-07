  --PRC_TIS_TAC_TIPO_ACOMODACAO_S
  create or replace procedure PRC_TIS_TAC_TIPO_ACOMODACAO_S 
  (
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_CD_TIPO_ACOMODACAO%type DEFAULT NULL,
     pTIS_TAC_DS_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_DS_TIPO_ACOMODACAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TAC_TIPO_ACOMODACAO_S
  * 
  *    Data Criacao: 	12/04/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 02/05/2007   Por: Cristiane Gomes da Silva
  *
  *    Funcao: Obtém Tipo(s) de Acomodação(ões) - TISS
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
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
	   TIS_TAC_FL_PERM_DIF_CLASSE,
	   TIS_TAC_FL_UTILIZA_REPASSE,
	   TIS_TAC_FL_STATUS
    FROM TB_TIS_TAC_TIPO_ACOMODACAO
    WHERE
        ((pTIS_TAC_CD_TIPO_ACOMODACAO is null OR TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO)
        AND (pTIS_TAC_DS_TIPO_ACOMODACAO is null OR TIS_TAC_DS_TIPO_ACOMODACAO LIKE UPPER('%'||pTIS_TAC_DS_TIPO_ACOMODACAO||'%')))
        ORDER BY TIS_TAC_DS_TIPO_ACOMODACAO;
    io_cursor := v_cursor;
  end PRC_TIS_TAC_TIPO_ACOMODACAO_S;
/
