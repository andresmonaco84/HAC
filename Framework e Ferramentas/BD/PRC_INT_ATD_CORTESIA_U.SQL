  --PRC_INT_ATD_CORTESIA_U
  create or replace procedure PRC_INT_ATD_CORTESIA_U
  (
     pATD_INC_ID IN TB_ATD_INC_INT_CORTESIA.ATD_INC_ID%type,
     pATD_ATE_ID IN TB_ATD_INC_INT_CORTESIA.ATD_ATE_ID%type,
     pATD_IML_ID IN TB_ATD_INC_INT_CORTESIA.ATD_IML_ID%type,
     pATD_INC_DS_CORTESIA IN TB_ATD_INC_INT_CORTESIA.ATD_INC_DS_CORTESIA%type,
     pSEG_USU_ID_USUARIO_CORT IN TB_ATD_INC_INT_CORTESIA.SEG_USU_ID_USUARIO_CORT%type,
     pATD_INC_DT_CORTESIA IN TB_ATD_INC_INT_CORTESIA.ATD_INC_DT_CORTESIA%type,
     pSEG_USU_ID_USUARIO IN TB_ATD_INC_INT_CORTESIA.SEG_USU_ID_USUARIO%type,
     pATD_INC_DT_ULTIMA_ATUALIZACAO IN TB_ATD_INC_INT_CORTESIA.ATD_INC_DT_ULTIMA_ATUALIZACAO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_CORTESIA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ATD_INC_INT_CORTESIA
    SET	   
        ATD_ATE_ID = pATD_ATE_ID,
        ATD_IML_ID = pATD_IML_ID,
        ATD_INC_DS_CORTESIA = pATD_INC_DS_CORTESIA,
        SEG_USU_ID_USUARIO_CORT = pSEG_USU_ID_USUARIO_CORT,
        ATD_INC_DT_CORTESIA = pATD_INC_DT_CORTESIA,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ATD_INC_DT_ULTIMA_ATUALIZACAO = pATD_INC_DT_ULTIMA_ATUALIZACAO 
    WHERE
        ATD_INC_ID = pATD_INC_ID;	
  end PRC_INT_ATD_CORTESIA_U;

