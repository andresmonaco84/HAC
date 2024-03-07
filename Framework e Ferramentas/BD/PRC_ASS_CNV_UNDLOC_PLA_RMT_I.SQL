  --PRC_ASS_CNV_UNDLOC_PLA_RMT_I
  create or replace procedure PRC_ASS_CNV_UNDLOC_PLA_RMT_I
  (
     pNewIdt OUT integer,
     pASS_CLP_ID IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_ID%type default NULL,
     pASS_CUL_ID IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CUL_ID%type,
     pASS_CLP_DT_INI_VIGENCIA IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_DT_INI_VIGENCIA%type,
     pASS_CLP_DT_FIM_VIGENCIA IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_DT_FIM_VIGENCIA%type default NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_CLP_CNV_UND_LOC_PLANO.CAD_PLA_ID_PLANO%type,
     pASS_CLP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CLP_CNV_UND_LOC_PLANO.SEG_USU_ID_USUARIO%type,
     pASS_CLP_FL_BLOQUEIA_UNI_OK IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_FL_BLOQUEIA_UNIDADE_OK%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNDLOC_PLA_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ASS_CLP_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_CLP_CNV_UND_LOC_PLANO
    (
       ASS_CLP_ID,
       ASS_CUL_ID,
       ASS_CLP_DT_INI_VIGENCIA,
       ASS_CLP_DT_FIM_VIGENCIA,
       CAD_PLA_ID_PLANO,
       ASS_CLP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_CLP_FL_BLOQUEIA_UNIDADE_OK
    )
    VALUES
    (
      lIdtRetorno,
	     pASS_CUL_ID,
	     pASS_CLP_DT_INI_VIGENCIA,
	     pASS_CLP_DT_FIM_VIGENCIA,
	     pCAD_PLA_ID_PLANO,
	     pASS_CLP_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pASS_CLP_FL_BLOQUEIA_UNI_OK
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ASS_CNV_UNDLOC_PLA_RMT_I;