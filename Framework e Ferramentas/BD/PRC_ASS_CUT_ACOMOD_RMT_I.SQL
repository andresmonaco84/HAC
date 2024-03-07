---fim


  --PRC_ASS_CUT_ACOMOD_RMT_I
  create or replace procedure PRC_ASS_CUT_ACOMOD_RMT_I
  (
     pASS_CUT_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_ID%type,
     pASS_CUT_DT_INI_VIGENCIA IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DT_INI_VIGENCIA%type,
     pASS_CUT_DS_MOTIVO_FIM_VIGENC IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_CUT_DT_FIM_VIGENCIA IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DT_FIM_VIGENCIA%type default NULL,
     pASS_CUT_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CUT_CONV_UNI_TPACOMOD.SEG_USU_ID_USUARIO%type,
     pASS_UTA_ID_UNID_TPACOMOD IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_UTA_ID_UNID_TPACOMOD%type default NULL,
     pASS_CNU_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CNU_ID%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUT_ACOMOD_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_CUT_CONV_UNI_TPACOMOD
    (
       ASS_CUT_ID,
       ASS_CUT_DT_INI_VIGENCIA,
       ASS_CUT_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CUT_DT_FIM_VIGENCIA,
       ASS_CUT_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_UTA_ID_UNID_TPACOMOD,
       ASS_CNU_ID
    )
    VALUES
    (
	     pASS_CUT_ID,
	     pASS_CUT_DT_INI_VIGENCIA,
	     pASS_CUT_DS_MOTIVO_FIM_VIGENC,
	     pASS_CUT_DT_FIM_VIGENCIA,
	     pASS_CUT_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pASS_UTA_ID_UNID_TPACOMOD,
	     pASS_CNU_ID
    );
	
  end PRC_ASS_CUT_ACOMOD_RMT_I;
