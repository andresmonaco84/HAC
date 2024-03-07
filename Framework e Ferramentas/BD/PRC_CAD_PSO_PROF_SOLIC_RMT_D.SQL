

  --PRC_CAD_PSO_PROF_SOLIC_RMT_D
  create or replace procedure PRC_CAD_PSO_PROF_SOLIC_RMT_D 
  (
     pCAD_PSO_CD_CONSELHO IN TB_CAD_PSO_PROF_SOLICITANTE.CAD_PSO_CD_CONSELHO%type,
     pCAD_PSO_SG_UF_CONSELHO IN TB_CAD_PSO_PROF_SOLICITANTE.CAD_PSO_SG_UF_CONSELHO%type,
     pTIS_CPR_CD_CONSELHOPROF IN TB_CAD_PSO_PROF_SOLICITANTE.TIS_CPR_CD_CONSELHOPROF%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PSO_PROF_SOLIC_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_PSO_PROF_SOLICITANTE
    WHERE  
        CAD_PSO_CD_CONSELHO = pCAD_PSO_CD_CONSELHO
    AND CAD_PSO_SG_UF_CONSELHO = pCAD_PSO_SG_UF_CONSELHO
    AND TIS_CPR_CD_CONSELHOPROF = pTIS_CPR_CD_CONSELHOPROF;	   
  end PRC_CAD_PSO_PROF_SOLIC_RMT_D;
