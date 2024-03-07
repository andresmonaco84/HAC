

  --PRC_ASS_PMM_PLANO_MATMED_D
  create or replace procedure PRC_ASS_PMM_PLANO_MATMED_D 
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PMM_PLANO_MATMED.CAD_CNV_ID_CONVENIO%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PMM_PLANO_MATMED.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_MTMD_ID IN TB_ASS_PMM_PLANO_MATMED.CAD_MTMD_ID%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_PMM_PLANO_MATMED.CAD_PLA_ID_PLANO%type  
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PMM_PLANO_MATMED_D
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PMM_PLANO_MATMED
    WHERE  
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_MTMD_ID = pCAD_MTMD_ID
    AND CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;     
  end PRC_ASS_PMM_PLANO_MATMED_D;

