create or replace function FNC_INT_QTD_SAIDA_48MAIS
(
  pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE,
  pATD_IML_DT_ENTRADA IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_DT_ENTRADA%TYPE,
  pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE--,
)
---retorna a qtd de internacoes por alta 48mais
return NUMBER is Result NUMBER;
begin
              SELECT

                    COUNT(DISTINCT ATD.ATD_ATE_ID)
                    OVER (PARTITION BY AIC.ATD_AIC_TP_SITUACAO_PAC||IML_QLE.CAD_SET_ID||PLA.CAD_PLA_ID_PLANO ) INTO RESULT
                    FROM          TB_ATD_ATE_ATENDIMENTO    ATD
                    JOIN          TB_ASS_PAT_PACIEATEND     PAT
                    ON            PAT.ATD_ATE_ID          = ATD.ATD_ATE_ID
                    JOIN          TB_CAD_PAC_PACIENTE       PAC
                    ON            PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(PAT.ATD_ATE_ID)
                    JOIN          TB_CAD_PLA_PLANO          PLA
                    ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
                    JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC
                    ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
                    JOIN          TB_ATD_INA_INT_ALTA       INA
                    ON            INA.ATD_ATE_ID          = ATD.ATD_ATE_ID
                    JOIN          TB_TIS_MSI_MOTIVO_SAIDA_INT MSI
                    ON            MSI.TIS_MSI_CD_MOTIVOSAIDAINT = INA.TIS_MSI_CD_MOTIVOSAIDAINT
                    LEFT JOIN  (    SELECT   QLE.CAD_QLE_ID, QLE.CAD_SET_ID , QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO,
                          IML.ATD_ATE_ID, QLE.TIS_TAC_CD_TIPO_ACOMODACAO, QLE.CAD_QLE_TP_QUARTO_LEITO , IML.ATD_IML_FL_STATUS,
                          IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA
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
                   
                    WHERE         TO_DATE(TO_CHAR(INA.ATD_INA_DT_ALTA_ADM,'dd-MM-yyyy')||TO_CHAR(INA.ATD_INA_HR_ALTA_ADM,'0000'),'dd-MM-yyyy HH24MI')
                                   - TO_DATE(TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'dd-MM-yyyy')||TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO,'0000'),'dd-MM-yyyy HH24MI')
                                   >= 2
                    AND            (AIC.ATD_AIC_TP_SITUACAO_PAC = 'A')
                     AND           (MSI.TIS_MSI_CD_TIPOALTA = 4)
                    AND           (PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
                    AND           (IML_QLE.CAD_SET_ID = pCAD_SET_ID)
                    AND           (ATD.ATD_ATE_DT_ATENDIMENTO = pATD_IML_DT_ENTRADA)
                    AND           ((IML_QLE.ATD_IML_FL_STATUS != 'C') OR (IML_QLE.ATD_IML_FL_STATUS IS NULL))
;

  return(Result);
end FNC_INT_QTD_SAIDA_48MAIS;
