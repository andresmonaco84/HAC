  --PRC_ASS_UNILOC_CBO_PRO_RMT_D
  create or replace procedure PRC_ASS_UNILOC_CBO_PRO_RMT_D 
  (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_PRO_ID_PROFISSIONAL%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_UNI_ID_UNIDADE%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.TIS_CBO_CD_CBOS%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNILOC_CBO_PRO_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_UCP_UNID_LOC_CBO_PROF
    WHERE  
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;	   
  end PRC_ASS_UNILOC_CBO_PRO_RMT_D;
