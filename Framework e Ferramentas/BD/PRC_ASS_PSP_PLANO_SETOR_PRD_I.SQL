

  --PRC_ASS_PSP_PLANO_SETOR_PRD_I
  create or replace procedure PRC_ASS_PSP_PLANO_SETOR_PRD_I
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_PLA_ID_PLANO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_SET_ID%type default NULL,
     pCAD_PRD_ID IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_PRD_ID%type,
     pASS_PSP_FL_ATIVO_OK IN TB_ASS_PSP_PLANO_SETOR_PRD.ASS_PSP_FL_ATIVO_OK%type,
     pASS_PSP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PSP_PLANO_SETOR_PRD.ASS_PSP_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_PSP_PLANO_SETOR_PRD.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PSP_PLANO_SETOR_PRD_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_PSP_PLANO_SETOR_PRD
    (
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_SET_ID,
       CAD_PRD_ID,
       ASS_PSP_FL_ATIVO_OK,
       ASS_PSP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	     pCAD_CNV_ID_CONVENIO,
	     pCAD_PLA_ID_PLANO,
	     pCAD_UNI_ID_UNIDADE,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	     pCAD_SET_ID,
	     pCAD_PRD_ID,
	     pASS_PSP_FL_ATIVO_OK,
	     pASS_PSP_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
    );
	
  end PRC_ASS_PSP_PLANO_SETOR_PRD_I;

