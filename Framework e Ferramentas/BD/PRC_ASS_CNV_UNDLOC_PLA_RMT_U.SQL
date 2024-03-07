  --PRC_ASS_CNV_UNDLOC_PLA_RMT_U
  create or replace procedure PRC_ASS_CNV_UNDLOC_PLA_RMT_U
  (
     pASS_CLP_ID IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_ID%type,
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
  *    Procedure: PRC_ASS_CNV_UNDLOC_PLA_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_CLP_CNV_UND_LOC_PLANO
    SET	   
        ASS_CUL_ID = pASS_CUL_ID,
        ASS_CLP_DT_INI_VIGENCIA = pASS_CLP_DT_INI_VIGENCIA,
        ASS_CLP_DT_FIM_VIGENCIA = pASS_CLP_DT_FIM_VIGENCIA,
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO,
        ASS_CLP_DT_ULTIMA_ATUALIZACAO = pASS_CLP_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_CLP_FL_BLOQUEIA_UNIDADE_OK = pASS_CLP_FL_BLOQUEIA_UNI_OK 
    WHERE
        ASS_CLP_ID = pASS_CLP_ID;	
  end PRC_ASS_CNV_UNDLOC_PLA_RMT_U;

