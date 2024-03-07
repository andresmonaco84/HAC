  create or replace procedure PRC_ASS_CLP_CNV_UND_LOC_PLAN_U
  (
     pASS_CLP_ID IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_ID%type,
     pASS_CUL_ID IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CUL_ID%type,
     pASS_CLP_DT_INI_VIGENCIA IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_DT_INI_VIGENCIA%type,
     pASS_CLP_DT_FIM_VIGENCIA IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_DT_FIM_VIGENCIA%type DEFAULT NULL,
     pASS_CLP_FL_BLOQUEIA_UNID_OK IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_FL_BLOQUEIA_UNIDADE_OK%type,         
     pCAD_PLA_ID_PLANO IN TB_ASS_CLP_CNV_UND_LOC_PLANO.CAD_PLA_ID_PLANO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CLP_CNV_UND_LOC_PLANO.SEG_USU_ID_USUARIO%type
  ) 
  is 
  /********************************************************************
  *    Procedure: PRC_ASS_CLP_CNV_UND_LOC_PLAN_U
  * 
  *    Data Criacao: 	  26/06/2007   Por: Andrea Cazuca
  *    Data Alteracao:	26/09/2007   Por: Carlos Araujo
  *    Alteração: Inclusão de campo ASS_CLP_FL_BLOQUEIA_UNIDADE_OK
  *
  *    Funcao: Altera Local de Atendimento para Convenio X Plano
  *
  *******************************************************************/  
  begin
    	
    UPDATE TB_ASS_CLP_CNV_UND_LOC_PLANO
    SET	   
        ASS_CUL_ID = pASS_CUL_ID,
        ASS_CLP_DT_INI_VIGENCIA = pASS_CLP_DT_INI_VIGENCIA,
        ASS_CLP_DT_FIM_VIGENCIA = pASS_CLP_DT_FIM_VIGENCIA,
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO,
        ASS_CLP_FL_BLOQUEIA_UNIDADE_OK = pASS_CLP_FL_BLOQUEIA_UNID_OK,
        ASS_CLP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        ASS_CLP_ID = pASS_CLP_ID;	
        
  end PRC_ASS_CLP_CNV_UND_LOC_PLAN_U;
/
