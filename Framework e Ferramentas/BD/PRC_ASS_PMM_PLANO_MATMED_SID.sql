
  --PRC_ASS_PMM_PLANO_MATMED_SID
  create or replace procedure PRC_ASS_PMM_PLANO_MATMED_SID 
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PMM_PLANO_MATMED.CAD_CNV_ID_CONVENIO%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PMM_PLANO_MATMED.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_MTMD_ID IN TB_ASS_PMM_PLANO_MATMED.CAD_MTMD_ID%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_PMM_PLANO_MATMED.CAD_PLA_ID_PLANO%type,
    io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PMM_PLANO_MATMED_SID
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT  
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_MTMD_ID,
       ASS_PMM_FL_EXIGE_GUIA,
       ASS_PMM_FL_EXIGE_SENHA,
       ASS_PMM_FL_AUTORIZATEL,
       ASS_PMM_FL_AUTORIZAFAX,
       ASS_PMM_FL_AUTORIZAPES,
       ASS_PMM_FL_AUTORIZAWEB,
       ASS_PMM_FL_COBERTURA,
       ASS_PMM_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_PMM_DT_ULTIMA_ATUALIZACAO
    FROM TB_ASS_PMM_PLANO_MATMED
    WHERE
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_MTMD_ID = pCAD_MTMD_ID
    AND CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;          
    io_cursor := v_cursor;
  end PRC_ASS_PMM_PLANO_MATMED_SID;

