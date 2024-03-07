  --PRC_CAD_ECM_EXCEC_COBRANCA_MTM_S
  create or replace procedure PRC_CAD_ECM_EXCEC_COBR_MTM_S 
  (
     pCAD_ECM_ID IN TB_CAD_ECM_EXCEC_COBRANCA_MTM.CAD_ECM_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_ECM_EXCEC_COBRANCA_MTM.CAD_CNV_ID_CONVENIO%type,
     pCAD_PRD_ID IN TB_CAD_ECM_EXCEC_COBRANCA_MTM.CAD_PRD_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_ECM_EXCEC_COBR_MTM_S
  * 
 *    Data Criacao: 	04/12/2009   Por: PEDRO
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_ECM_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_PRD_ID,
       CAD_ECM_FL_UTILIZA_VL_NF,
       TIS_MED_CD_TABELAMEDICA,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_ECM_TP_PACIENTE,
       TIS_CDE_CD_CODIGO_DESPESA,
       CAD_ECM_VL_UNITARIO,
       CAD_ECM_VL_CUSTO,
       CAD_ECM_PC_MARGEM,
       CAD_ECM_FL_ISENTO_COBRANCA,
       CAD_ECM_DT_INICIO_VIGENCIA,
       CAD_ECM_DT_FIM_VIGENCIA,
       ASS_CPE_ID,
       CAD_ECM_FL_INT_FRAC,
       CAD_ECM_VL_FATOR_CONVERSAO,
       CAD_ECM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_CAD_ECM_EXCEC_COBRANCA_MTM
    WHERE
       (pCAD_ECM_ID IS NULL OR CAD_ECM_ID = pCAD_ECM_ID)
        AND CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
        AND CAD_PRD_ID = pCAD_PRD_ID
        ;          
    io_cursor := v_cursor;
  end PRC_CAD_ECM_EXCEC_COBR_MTM_S;

