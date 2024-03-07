  --PRC_INT_ATD_CORTESIA_S
  create or replace procedure PRC_INT_ATD_CORTESIA_S 
  (
     pATD_INC_ID IN TB_ATD_INC_INT_CORTESIA.ATD_INC_ID%type DEFAULT NULL,
     pATD_ATE_ID IN TB_ATD_INC_INT_CORTESIA.ATD_ATE_ID%type DEFAULT NULL,
     pATD_IML_ID IN TB_ATD_INC_INT_CORTESIA.ATD_IML_ID%type DEFAULT NULL,
     pATD_INC_DS_CORTESIA IN TB_ATD_INC_INT_CORTESIA.ATD_INC_DS_CORTESIA%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO_CORT IN TB_ATD_INC_INT_CORTESIA.SEG_USU_ID_USUARIO_CORT%type DEFAULT NULL,
     pATD_INC_DT_CORTESIA IN TB_ATD_INC_INT_CORTESIA.ATD_INC_DT_CORTESIA%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ATD_INC_INT_CORTESIA.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pATD_INC_DT_ULTIMA_ATUALIZACAO IN TB_ATD_INC_INT_CORTESIA.ATD_INC_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_CORTESIA_S
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
       ATD_INC_ID,
       ATD_ATE_ID,
       ATD_IML_ID,
       ATD_INC_DS_CORTESIA,
       SEG_USU_ID_USUARIO_CORT,
       ATD_INC_DT_CORTESIA,
       SEG_USU_ID_USUARIO,
       ATD_INC_DT_ULTIMA_ATUALIZACAO
    FROM TB_ATD_INC_INT_CORTESIA
    WHERE
        (pATD_INC_ID is null OR ATD_INC_ID = pATD_INC_ID) AND 
        (pATD_ATE_ID is null OR ATD_ATE_ID = pATD_ATE_ID) AND 
        (pATD_IML_ID is null OR ATD_IML_ID = pATD_IML_ID) AND 
        (pATD_INC_DS_CORTESIA is null OR ATD_INC_DS_CORTESIA = pATD_INC_DS_CORTESIA) AND 
        (pSEG_USU_ID_USUARIO_CORT is null OR SEG_USU_ID_USUARIO_CORT = pSEG_USU_ID_USUARIO_CORT) AND 
        (pATD_INC_DT_CORTESIA is null OR ATD_INC_DT_CORTESIA = pATD_INC_DT_CORTESIA) AND 
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO) AND 
        (pATD_INC_DT_ULTIMA_ATUALIZACAO is null OR ATD_INC_DT_ULTIMA_ATUALIZACAO = pATD_INC_DT_ULTIMA_ATUALIZACAO);          
    io_cursor := v_cursor;
  end PRC_INT_ATD_CORTESIA_S;
