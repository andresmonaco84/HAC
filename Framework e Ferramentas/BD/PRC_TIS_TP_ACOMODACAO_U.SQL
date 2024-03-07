create or replace procedure PRC_TIS_TP_ACOMODACAO_U
  (
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_CD_TIPO_ACOMODACAO%type,
     pTIS_TAC_DS_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_DS_TIPO_ACOMODACAO%type,
     pTIS_TAC_PC_ACOMODACAO_HM IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_PC_ACOMODACAO_HM%type default NULL,
     pTIS_TAC_DT_ULTIMA_ATUALIZACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_DT_ULTIMA_ATUALIZACAO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_TIS_TAC_TIPO_ACOMODACAO.SEG_USU_ID_USUARIO%type default NULL,
     pTIS_TAC_FL_PERM_DIF_CLASSE IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_FL_PERM_DIF_CLASSE%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TP_ACOMODACAO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_TIS_TAC_TIPO_ACOMODACAO
    SET	   
        TIS_TAC_DS_TIPO_ACOMODACAO = pTIS_TAC_DS_TIPO_ACOMODACAO,
        TIS_TAC_PC_ACOMODACAO_HM = pTIS_TAC_PC_ACOMODACAO_HM,
        TIS_TAC_DT_ULTIMA_ATUALIZACAO = pTIS_TAC_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        TIS_TAC_FL_PERM_DIF_CLASSE = pTIS_TAC_FL_PERM_DIF_CLASSE 
    WHERE
        TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO;
  end PRC_TIS_TP_ACOMODACAO_U;

