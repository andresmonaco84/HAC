
---fim


  --PRC_CAD_PSO_PROF_SOLIC_RMT_I
  create or replace procedure PRC_CAD_PSO_PROF_SOLIC_RMT_I
  (
     pTIS_CPR_CD_CONSELHOPROF IN TB_CAD_PSO_PROF_SOLICITANTE.TIS_CPR_CD_CONSELHOPROF%type,
     pCAD_PSO_CD_CONSELHO IN TB_CAD_PSO_PROF_SOLICITANTE.CAD_PSO_CD_CONSELHO%type,
     pCAD_PSO_SG_UF_CONSELHO IN TB_CAD_PSO_PROF_SOLICITANTE.CAD_PSO_SG_UF_CONSELHO%type,
     pCAD_PSO_FL_ATIVO_OK IN TB_CAD_PSO_PROF_SOLICITANTE.CAD_PSO_FL_ATIVO_OK%type,
     pCAD_PSO_NM_PROFISSIONAL IN TB_CAD_PSO_PROF_SOLICITANTE.CAD_PSO_NM_PROFISSIONAL%type,
     pCAD_PSO_DT_ULTIMA_ATUALIZACAO IN TB_CAD_PSO_PROF_SOLICITANTE.CAD_PSO_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_PSO_PROF_SOLICITANTE.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PSO_PROF_SOLIC_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_CAD_PSO_PROF_SOLICITANTE
    (
       TIS_CPR_CD_CONSELHOPROF,
       CAD_PSO_CD_CONSELHO,
       CAD_PSO_SG_UF_CONSELHO,
       CAD_PSO_FL_ATIVO_OK,
       CAD_PSO_NM_PROFISSIONAL,
       CAD_PSO_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	     pTIS_CPR_CD_CONSELHOPROF,
	     pCAD_PSO_CD_CONSELHO,
	     pCAD_PSO_SG_UF_CONSELHO,
	     pCAD_PSO_FL_ATIVO_OK,
	     pCAD_PSO_NM_PROFISSIONAL,
	     pCAD_PSO_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
    );
	
  end PRC_CAD_PSO_PROF_SOLIC_RMT_I;

