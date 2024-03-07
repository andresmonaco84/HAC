  --PRC_ATD_IDF_INT_DIF_CLASSE_I
  create or replace procedure PRC_ATD_IDF_INT_DIF_CLASSE_I
  (
     pNewIdt OUT integer,
     pATD_IDF_ID IN TB_ATD_IDF_INT_DIF_CLASSE.ATD_IDF_ID%type default NULL,
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
  *    Procedure: PRC_ATD_IDF_INT_DIF_CLASSE_I
  * 
  *    Data Criacao: 	31/08/2009         Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ATD_IDF_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ATD_IDF_INT_DIF_CLASSE
    (
       ATD_IDF_ID,
       ATD_ATE_ID,
       ATD_IML_ID,
       ATD_IDF_DS_DIF_CLASSE,
       SEG_USU_ID_USUARIO_DIF_CLASSE,
       ATD_IDF_DT_DIF_CLASSE,
       SEG_USU_ID_USUARIO,
       ATD_INC_DT_ULTIMA_ATUALIZACAO
    )
    VALUES
    (
      lIdtRetorno,
	  pATD_ATE_ID,
	  pATD_IML_ID,
	  pATD_IDF_DS_DIF_CLASSE,
	  pSEG_USU_ID_USUARIO_DIF_CLASSE,
	  pATD_IDF_DT_DIF_CLASSE,
	  pSEG_USU_ID_USUARIO,
	  pATD_INC_DT_ULTIMA_ATUALIZACAO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ATD_IDF_INT_DIF_CLASSE_I;