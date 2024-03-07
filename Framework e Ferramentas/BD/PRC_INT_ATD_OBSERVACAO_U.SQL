  --PRC_INT_ATD_OBSERVACAO_U
  create or replace procedure PRC_INT_ATD_OBSERVACAO_U
  (
     pATD_ATE_ID IN TB_ATD_INO_INT_OBSERVACAO.ATD_ATE_ID%type,
     pATD_INO_DT_OBS IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_DT_OBS%type,
     pATD_INO_HR_OBS IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_HR_OBS%type,
     pATD_INO_OBSERVACAO IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_OBSERVACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATD_INO_INT_OBSERVACAO.SEG_USU_ID_USUARIO%type,
     pATD_ION_DT_ULTIMA_ATUALIZACAO IN TB_ATD_INO_INT_OBSERVACAO.ATD_ION_DT_ULTIMA_ATUALIZACAO%type,
     pATD_INO_ID IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_ID%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_OBSERVACAO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ATD_INO_INT_OBSERVACAO
    SET	   
        ATD_ATE_ID = pATD_ATE_ID,
        ATD_INO_DT_OBS = pATD_INO_DT_OBS,
        ATD_INO_HR_OBS = pATD_INO_HR_OBS,
        ATD_INO_OBSERVACAO = pATD_INO_OBSERVACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ATD_ION_DT_ULTIMA_ATUALIZACAO = pATD_ION_DT_ULTIMA_ATUALIZACAO 
    WHERE
        ATD_INO_ID = pATD_INO_ID;	
  end PRC_INT_ATD_OBSERVACAO_U;

