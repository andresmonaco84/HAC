create or replace procedure PRC_INT_GUIAATEND_S(pATD_ATE_ID          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
                                                pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
                                                IO_CURSOR            OUT PKG_CURSOR.T_CURSOR) is
  /********************************************************************
  *    Procedure: PRC_INT_GUIAATEND_S
  *  
  *    Data Alteracao:  14/07/2010  Por: Marcus Relva
  *    Alteracao: Trazer produto se existir guia na ppg
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
begin
  OPEN V_CURSOR FOR
  
    SELECT GUI.ATD_GUI_CD_CODIGO,
           GUI.ATD_GUI_DT_ULTIMA_ATUALIZACAO,
           GUI.ATD_GUI_FL_GUIAPRINC_OK,
           GUI.ATD_ATE_ID,
           GUI.ATD_GUI_DT_EMISSAOGUIA,
           GUI.SEG_USU_ID_USUARIO,
           GUI.ATD_GUI_DT_AUTORIZGUIA,
           GUI.ATD_GUI_FL_ATIVO_OK,
           GUI.ATD_GUI_CD_SENHA,
           GUI.ATD_GUI_DT_VALIDADE,
           GUI.ATD_GUI_DT_VALIDADE_FIM,
           GUI.ATD_GUI_DIAS_VALIDADE,
           GUI.ATD_GUI_DS_OBSERVACAO,
           GUI.ATD_GUI_FL_GUIA_ENTREGUE,
           GUI.ATD_GUI_FL_DT_GUIA_ENTREGUE,
           GUI.CAD_PAC_ID_PACIENTE,
           PAC.CAD_PAC_CD_CREDENCIAL,
           PAC.CAD_PAC_ID_PACIENTE idtPaciente,
           PES.CAD_PES_NM_PESSOA,
           CNV.CAD_CNV_ID_CONVENIO,
           PLA.CAD_PLA_ID_PLANO,
           PRD.CAD_PRD_CD_CODIGO || ' ' || PRD.CAD_PRD_DS_DESCRICAO as CAD_PRD_DS_DESCRICAO
      FROM TB_ATD_ATE_ATENDIMENTO       ATD,
           TB_ASS_PAT_PACIEATEND        PAT,
           TB_ATD_AIC_ATE_INT_COMPL     AIC,
           TB_CAD_PAC_PACIENTE          PAC,
           TB_CAD_CNV_CONVENIO          CNV,
           TB_CAD_PLA_PLANO             PLA,
           TB_CAD_PES_PESSOA            PES,
           TB_ATD_GUI_GUIAATEND         GUI,
           TB_ASS_PPG_PAC_ATE_PROC_GUIA PPG,
           TB_CAD_PRD_PRODUTO           PRD
     WHERE ATD.ATD_ATE_ID = PAT.ATD_ATE_ID
       AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
       AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
       AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
       AND ATD.ATD_ATE_ID = pATD_ATE_ID
       AND CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
       AND PAT.ATD_ATE_ID = GUI.ATD_ATE_ID(+)
       AND PAT.CAD_PAC_ID_PACIENTE = GUI.CAD_PAC_ID_PACIENTE(+)
          /* PPG */
       AND GUI.ATD_ATE_ID = PPG.ATD_ATE_ID(+)
       AND GUI.ATD_GUI_CD_CODIGO = PPG.ATE_GUI_CD_CODIGO(+)
       AND GUI.ATD_GUI_CD_SENHA = PPG.ASS_PPG_CD_SENHA(+)
       AND PPG.CAD_PRD_ID = PRD.CAD_PRD_ID(+)
     ORDER BY 1;

  IO_CURSOR := V_CURSOR;
end PRC_INT_GUIAATEND_S;