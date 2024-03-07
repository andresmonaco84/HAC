create or replace procedure PRC_INT_PAC_S(pATD_AIC_TP_SITUACAO_PAC    IN TB_ATD_AIC_ATE_INT_COMPL.ATD_AIC_TP_SITUACAO_PAC%TYPE DEFAULT NULL,
                                          pCAD_PES_NM_PESSOA          IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%TYPE DEFAULT NULL,
                                          pCAD_UNI_ID_UNIDADE         IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
                                          pATD_ATE_DT_ATENDIMENTO     IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
                                          pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
                                          pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
                                          io_cursor                   OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_PAC_S
  *
  *    Data Criacao:   data da  cria??o   Por: PEDRO
  *    Data Alteracao:  21/6/2011  Por: PEDRO
  *    AND IML3.ATD_IML_DT_SAIDA IS NULL e join com a pat retirado
  *
  *    Funcao: Pesquisa de Pacientes Internados ou com Alta
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT PAC.CAD_PAC_CD_CREDENCIAL,
           PAC.CAD_PAC_NR_PRONTUARIO,
           PES.CAD_PES_NM_PESSOA,
           TRUNC(PES.CAD_PES_DT_NASCIMENTO) CAD_PES_DT_NASCIMENTO,
           CBOS.TIS_CBO_DS_CBOS_HAC,
           AIC.ATD_AIC_TP_SITUACAO_PAC,
           ATD.ATD_ATE_ID,
           TRUNC(IML_QLE.ATD_IML_DT_SAIDA) ATD_IML_DT_SAIDA,
           TRUNC(INA.ATD_INA_DT_ALTA_ADM) ATD_INA_DT_ALTA_ADM,
           CNV.CAD_CNV_CD_HAC_PRESTADOR,
           PLA.CAD_PLA_CD_PLANO_HAC,
           TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO) ATD_ATE_DT_ATENDIMENTO,
           ATD.ATD_ATE_HR_ATENDIMENTO,
           IML_QLE.CAD_QLE_NR_QUARTO,
           IML_QLE.CAD_QLE_NR_LEITO,
           SETOR.CAD_SET_DS_SETOR,
           IML_QLE.ATD_IML_ID
       FROM
                    TB_ATD_ATE_ATENDIMENTO    ATD
      JOIN          TB_CAD_PAC_PACIENTE       PAC
      ON            PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(atd.atd_ate_id)
      JOIN          TB_CAD_PES_PESSOA         PES
      ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
      JOIN          TB_CAD_CNV_CONVENIO       CNV
      ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
      JOIN          TB_CAD_PLA_PLANO          PLA
      ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO      
      JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC
      ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
      LEFT JOIN TB_ATD_INA_INT_ALTA INA ON INA.ATD_ATE_ID = 
                                           ATD.ATD_ATE_ID
       JOIN TB_TIS_CBO_CBOS CBOS ON CBOS.TIS_CBO_CD_CBOS =
                                        ATD.TIS_CBO_CD_CBOS
      LEFT JOIN  (    SELECT   QLE.CAD_QLE_ID, QLE.CAD_SET_ID , QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO,
                          IML.ATD_ATE_ID, QLE.TIS_TAC_CD_TIPO_ACOMODACAO, QLE.CAD_QLE_TP_QUARTO_LEITO ,
                          IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA,iml.ATD_IML_ID, IML.ATD_IML_DT_SAIDA
                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                 ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                 WHERE       FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) = 
                                         (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                                                       WHERE IML3.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A')
              )  IML_QLE
      ON IML_QLE.ATD_ATE_ID = ATD.ATD_ATE_ID
      JOIN TB_CAD_SET_SETOR SETOR ON IML_QLE.CAD_SET_ID =
                                     SETOR.CAD_SET_ID
     WHERE (ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
       AND (ATD.ATD_ATE_FL_STATUS = 'A')
       AND (AIC.ATD_AIC_TP_SITUACAO_PAC = pATD_AIC_TP_SITUACAO_PAC)
       AND (PES.CAD_PES_NM_PESSOA LIKE PCAD_PES_NM_PESSOA)
       AND (pATD_ATE_DT_ATENDIMENTO IS NULL OR ATD.ATD_ATE_DT_ATENDIMENTO >= pATD_ATE_DT_ATENDIMENTO)
       AND (pATD_ATE_DT_ATENDIMENTO_INI IS NULL OR ATD.ATD_ATE_DT_ATENDIMENTO >= pATD_ATE_DT_ATENDIMENTO_INI)
       AND (pATD_ATE_DT_ATENDIMENTO_FIM IS NULL OR ATD.ATD_ATE_DT_ATENDIMENTO <= pATD_ATE_DT_ATENDIMENTO_FIM)
       ;            
  io_cursor := v_cursor;
end PRC_INT_PAC_S;
/
