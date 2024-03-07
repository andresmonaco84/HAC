

  --PRC_ASS_PSP_PLANO_SETOR_PRD_D
  create or replace procedure PRC_ASS_PSP_PLANO_SETOR_PRD_D 
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_CNV_ID_CONVENIO%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_PLA_ID_PLANO%type,
     pCAD_PRD_ID IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_PRD_ID%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_PSP_PLANO_SETOR_PRD.CAD_UNI_ID_UNIDADE%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PSP_PLANO_SETOR_PRD_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PSP_PLANO_SETOR_PRD
    WHERE  
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
    AND CAD_PRD_ID = pCAD_PRD_ID
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;	   
  end PRC_ASS_PSP_PLANO_SETOR_PRD_D;
