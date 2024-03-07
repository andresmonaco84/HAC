  --PRC_ASS_CNV_UNIDADE_RMT_I
  create or replace procedure PRC_ASS_CNV_UNIDADE_RMT_I
  (
     pNewIdt OUT integer,
     pASS_CNU_ID IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_ID%type default NULL,
     pASS_CNU_DT_INI_VIGENCIA IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DT_INI_VIGENCIA%type,
     pASS_CNU_DT_FIM_VIGENCIA IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DT_FIM_VIGENCIA%type default NULL,
     pASS_CNU_DS_MOT_FIM_VIGENCIA IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_CNU_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DT_ULTIMA_ATUALIZACAO%type,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CNU_CONVENIO_UNIDADE.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNIDADE_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ASS_CNU_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_CNU_CONVENIO_UNIDADE
    (
       ASS_CNU_ID,
       ASS_CNU_DT_INI_VIGENCIA,
       ASS_CNU_DT_FIM_VIGENCIA,
       ASS_CNU_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CNU_DT_ULTIMA_ATUALIZACAO,
       CAD_CNV_ID_CONVENIO,
       CAD_UNI_ID_UNIDADE,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
      lIdtRetorno,
	     pASS_CNU_DT_INI_VIGENCIA,
	     pASS_CNU_DT_FIM_VIGENCIA,
	     pASS_CNU_DS_MOT_FIM_VIGENCIA,
	     pASS_CNU_DT_ULTIMA_ATUALIZACAO,
	     pCAD_CNV_ID_CONVENIO,
	     pCAD_UNI_ID_UNIDADE,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ASS_CNV_UNIDADE_RMT_I;

