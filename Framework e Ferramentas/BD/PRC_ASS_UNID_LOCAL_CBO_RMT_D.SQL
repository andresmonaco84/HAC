  --PRC_ASS_UNID_LOCAL_CBO_RMT_D
  create or replace procedure PRC_ASS_UNID_LOCAL_CBO_RMT_D 
  (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULC_UNID_LOCAL_CBOS.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULC_UNID_LOCAL_CBOS.CAD_UNI_ID_UNIDADE%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_ULC_UNID_LOCAL_CBOS.TIS_CBO_CD_CBOS%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNID_LOCAL_CBO_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_ULC_UNID_LOCAL_CBOS
    WHERE  
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;	   
  end PRC_ASS_UNID_LOCAL_CBO_RMT_D;
