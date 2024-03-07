  --PRC_ATD_IDF_INT_DIF_CLASSE_U
  create or replace procedure PRC_ATD_IDF_INT_DIF_CLASSE_U
  (
     pATD_IDF_ID IN TB_ATD_IDF_INT_DIF_CLASSE.ATD_IDF_ID%type,
     pATD_ATE_ID IN TB_ATD_IDF_INT_DIF_CLASSE.ATD_ATE_ID%type,
     pATD_IML_ID IN TB_ATD_IDF_INT_DIF_CLASSE.ATD_IML_ID%type,
     pATD_IDF_DS_DIF_CLASSE IN TB_ATD_IDF_INT_DIF_CLASSE.ATD_IDF_DS_DIF_CLASSE%type,
     pSEG_USU_ID_USUARIO_DIF_CLASSE IN TB_ATD_IDF_INT_DIF_CLASSE.SEG_USU_ID_USUARIO_DIF_CLASSE%type,
     pATD_IDF_DT_DIF_CLASSE IN TB_ATD_IDF_INT_DIF_CLASSE.ATD_IDF_DT_DIF_CLASSE%type,
     pSEG_USU_ID_USUARIO IN TB_ATD_IDF_INT_DIF_CLASSE.SEG_USU_ID_USUARIO%type,
     pATD_INC_DT_ULTIMA_ATUALIZACAO IN TB_ATD_IDF_INT_DIF_CLASSE.ATD_INC_DT_ULTIMA_ATUALIZACAO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATD_IDF_INT_DIF_CLASSE_U
  * 
  *    Data Criacao: 	31/08/2009         Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ATD_IDF_INT_DIF_CLASSE
    SET	   
        ATD_ATE_ID = pATD_ATE_ID,
        ATD_IML_ID = pATD_IML_ID,
        ATD_IDF_DS_DIF_CLASSE = pATD_IDF_DS_DIF_CLASSE,
        SEG_USU_ID_USUARIO_DIF_CLASSE = pSEG_USU_ID_USUARIO_DIF_CLASSE,
        ATD_IDF_DT_DIF_CLASSE = pATD_IDF_DT_DIF_CLASSE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ATD_INC_DT_ULTIMA_ATUALIZACAO = pATD_INC_DT_ULTIMA_ATUALIZACAO 
    WHERE
        ATD_IDF_ID = pATD_IDF_ID;	
  end PRC_ATD_IDF_INT_DIF_CLASSE_U;