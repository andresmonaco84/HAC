  --PRC_ASS_CNV_UNI_LOCATE_RMT_I
  create or replace procedure PRC_ASS_CNV_UNI_LOCATE_RMT_I
  (
     pNewIdt OUT integer,
     pASS_CUL_ID IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_ID%type default NULL,
     pASS_CUL_DT_INI_VIGENCIA IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DT_INI_VIGENCIA%type,
     pASS_CUL_DS_MOT_FIM_VIGENCIA IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_CUL_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DT_ULTIMA_ATUALIZACAO%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CUL_CONV_UNI_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pASS_CUL_DT_FIM_VIGENCIA IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CUL_CONV_UNI_LOCATEND.SEG_USU_ID_USUARIO%type,
     pASS_CNU_ID IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CNU_ID%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNI_LOCATE_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ASS_CUL_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_CUL_CONV_UNI_LOCATEND
    (
       ASS_CUL_ID,
       ASS_CUL_DT_INI_VIGENCIA,
       ASS_CUL_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CUL_DT_ULTIMA_ATUALIZACAO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ASS_CUL_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO,
       ASS_CNU_ID
    )
    VALUES
    (
      lIdtRetorno,
	     pASS_CUL_DT_INI_VIGENCIA,
	     pASS_CUL_DS_MOT_FIM_VIGENCIA,
	     pASS_CUL_DT_ULTIMA_ATUALIZACAO,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	     pASS_CUL_DT_FIM_VIGENCIA,
	     pSEG_USU_ID_USUARIO,
	     pASS_CNU_ID
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ASS_CNV_UNI_LOCATE_RMT_I;

