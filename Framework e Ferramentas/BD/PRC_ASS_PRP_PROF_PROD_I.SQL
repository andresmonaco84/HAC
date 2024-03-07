

  --PRC_ASS_PRP_PROFISSIONAL_PROD_I
  create or replace procedure PRC_ASS_PRP_PROF_PROD_I
  (
     pASS_PRP_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_ID%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRO_ID_PROFISSIONAL%type default NULL,
     pCAD_PRD_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRD_ID%type default NULL,
     pASS_PRP_FL_ATIVO_OK IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_FL_ATIVO_OK%type default NULL,
     pASS_PRP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_DT_ULTIMA_ATUALIZACAO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PRP_PROFISSIONAL_PROD.SEG_USU_ID_USUARIO%type default NULL,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_UNI_ID_UNIDADE%type default NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PRP_PROFISSIONAL_PROD_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_PRP_PROFISSIONAL_PROD
    (
       ASS_PRP_ID,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_PRD_ID,
       ASS_PRP_FL_ATIVO_OK,
       ASS_PRP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO
    )
    VALUES
    (
	     pASS_PRP_ID,
	     pCAD_PRO_ID_PROFISSIONAL,
	     pCAD_PRD_ID,
	     pASS_PRP_FL_ATIVO_OK,
	     pASS_PRP_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pCAD_UNI_ID_UNIDADE,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO
    );
	
  end PRC_ASS_PRP_PROF_PROD_I;

