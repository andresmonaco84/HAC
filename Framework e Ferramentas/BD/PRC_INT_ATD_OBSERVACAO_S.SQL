  --PRC_INT_ATD_OBSERVACAO_S
  create or replace procedure PRC_INT_ATD_OBSERVACAO_S 
  (
     pATD_ATE_ID IN TB_ATD_INO_INT_OBSERVACAO.ATD_ATE_ID%type DEFAULT NULL,
     pATD_INO_DT_OBS IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_DT_OBS%type DEFAULT NULL,
     pATD_INO_HR_OBS IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_HR_OBS%type DEFAULT NULL,
     pATD_INO_OBSERVACAO IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_OBSERVACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ATD_INO_INT_OBSERVACAO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pATD_ION_DT_ULTIMA_ATUALIZACAO IN TB_ATD_INO_INT_OBSERVACAO.ATD_ION_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pATD_INO_ID IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_OBSERVACAO_S
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
       ATD_ATE_ID,
       ATD_INO_DT_OBS,
       ATD_INO_HR_OBS,
       ATD_INO_OBSERVACAO,
       SEG_USU_ID_USUARIO,
       ATD_ION_DT_ULTIMA_ATUALIZACAO,
       ATD_INO_ID
    FROM TB_ATD_INO_INT_OBSERVACAO
    WHERE
        (pATD_ATE_ID is null OR ATD_ATE_ID = pATD_ATE_ID) AND 
        (pATD_INO_DT_OBS is null OR ATD_INO_DT_OBS = pATD_INO_DT_OBS) AND 
        (pATD_INO_HR_OBS is null OR ATD_INO_HR_OBS = pATD_INO_HR_OBS) AND 
        (pATD_INO_OBSERVACAO is null OR ATD_INO_OBSERVACAO = pATD_INO_OBSERVACAO) AND 
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO) AND 
        (pATD_ION_DT_ULTIMA_ATUALIZACAO is null OR ATD_ION_DT_ULTIMA_ATUALIZACAO = pATD_ION_DT_ULTIMA_ATUALIZACAO) AND 
        (pATD_INO_ID is null OR ATD_INO_ID = pATD_INO_ID);          
    io_cursor := v_cursor;
  end PRC_INT_ATD_OBSERVACAO_S;
