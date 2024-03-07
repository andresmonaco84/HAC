  --PRC_INT_ATD_OBSERVACAO_I
  create or replace procedure PRC_INT_ATD_OBSERVACAO_I
  (
     pNewIdt OUT integer,
     pATD_ATE_ID IN TB_ATD_INO_INT_OBSERVACAO.ATD_ATE_ID%type,
     pATD_INO_DT_OBS IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_DT_OBS%type,
     pATD_INO_HR_OBS IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_HR_OBS%type,
     pATD_INO_OBSERVACAO IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_OBSERVACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATD_INO_INT_OBSERVACAO.SEG_USU_ID_USUARIO%type,
     pATD_ION_DT_ULTIMA_ATUALIZACAO IN TB_ATD_INO_INT_OBSERVACAO.ATD_ION_DT_ULTIMA_ATUALIZACAO%type,
     pATD_INO_ID IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_ID%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_OBSERVACAO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ATD_INO_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ATD_INO_INT_OBSERVACAO
    (
       ATD_ATE_ID,
       ATD_INO_DT_OBS,
       ATD_INO_HR_OBS,
       ATD_INO_OBSERVACAO,
       SEG_USU_ID_USUARIO,
       ATD_ION_DT_ULTIMA_ATUALIZACAO,
       ATD_INO_ID
    )
    VALUES
    (
	     pATD_ATE_ID,
	     pATD_INO_DT_OBS,
	     pATD_INO_HR_OBS,
	     pATD_INO_OBSERVACAO,
	     pSEG_USU_ID_USUARIO,
	     pATD_ION_DT_ULTIMA_ATUALIZACAO,
	     lIdtRetorno
    );
    pNewIdt := lIdtRetorno;	
  end PRC_INT_ATD_OBSERVACAO_I;

