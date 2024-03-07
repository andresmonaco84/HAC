CREATE OR REPLACE PROCEDURE "PRC_CAD_PAC_PACIENTE_RMT_SID"
  (
     pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PAC_PACIENTE_RMT_SID
  *
  *    Data Criacao:  data da  criac?o   Por: Nome do Analista
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_PAC_ID_PACIENTE,
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_PAC_CD_CREDENCIAL,
       CAD_EMP_ID_EMPRESA,
       CAD_PAC_NR_PRONTUARIO,
       CAD_PAC_NM_TITULAR,
       CAD_PAC_DT_VALIDADECREDENCIAL,
       CAD_PAC_CD_CNS,
       CAD_PAC_DS_OBSERVACAO,
       CAD_PAC_FL_VIP_OK,
       CAD_PAC_CD_CODCIP,
       CAD_PAC_CD_CODBEN,
       CAD_PAC_CD_CODBENSEQ,
       SEG_USU_ID_USUARIO,
       CAD_PAC_DT_ULTIMA_ATUALIZACAO,
       CAD_PES_ID_PESSOA,
       CAD_PAC_CD_SUBPLANO,
       CAD_PAC_TP_SANGUINEO,
       AUX_PRF_CD_CODIGO,
       AUX_NAC_CD_CODIGO,
       CAD_PAC_FL_DOADORORGAOS_OK,
       CAD_PAC_FL_RESTRICAO_PA_OK,
       CAD_PAC_IDT_RN,
       CAD_PES_RESP_RN,
       CAD_PAC_FL_PRE_ATENDIMENTO,
       CAD_PAC_FL_ATIVO_OK,
       CAD_PAC_CD_AUTORIZADOR
    FROM TB_CAD_PAC_PACIENTE
    WHERE
        CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE;
    io_cursor := v_cursor;
  end PRC_CAD_PAC_PACIENTE_RMT_SID;
 