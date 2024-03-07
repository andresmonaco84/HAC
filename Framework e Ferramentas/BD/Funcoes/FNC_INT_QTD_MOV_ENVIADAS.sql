create or replace function FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID           IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
                                                    pATD_IML_DT_ENTRADA   IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_DT_ENTRADA%TYPE,
                                                    pCAD_PLA_ID_PLANO     IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE default null,
                                                    pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE default null,
                                                    pCAD_UNI_ID_UNIDADE   IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
                                           pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
                                           pSUBGRUPO VARCHAR2 DEFAULT NULL,
                                           pCOM_HOSP_DIA VARCHAR2 DEFAULT NULL,
                                           pCAD_CSE_ID IN TB_CAD_SET_SETOR.CAD_CSE_ID%TYPE DEFAULT NULL                                           )
---retorna a qtd de sa?das por movimentacao
 return NUMBER is
  Result NUMBER;
begin
  SELECT COUNT( IML3.ATD_ATE_ID)
    INTO RESULT
    FROM TB_ATD_IML_INT_MOV_LEITO IML3
    JOIN TB_CAD_QLE_QUARTO_LEITO QLE3 ON QLE3.CAD_QLE_ID = IML3.CAD_CAD_QLE_ID
    JOIN TB_ATD_ATE_ATENDIMENTO ATD3 ON ATD3.ATD_ATE_ID = IML3.ATD_ATE_ID
    JOIN TB_ATD_AIC_ATE_INT_COMPL AIC3 ON AIC3.ATD_ATE_ID = ATD3.ATD_ATE_ID
    JOIN TB_CAD_PAC_PACIENTE PAC3 ON PAC3.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(ATD3.ATD_ATE_ID)
    JOIN TB_CAD_PLA_PLANO PLA3 ON PLA3.CAD_PLA_ID_PLANO = PAC3.CAD_PLA_ID_PLANO
    JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE3.CAD_SET_ID
        JOIN TB_CAD_CNV_CONVENIO CNV ON CNV.CAD_CNV_ID_CONVENIO = PAC3.CAD_CNV_ID_CONVENIO
    LEFT JOIN (SELECT IML2.ATD_ATE_ID,
                      IML2.ATD_IML_DT_SAIDA,
                      IML2.ATD_IML_HR_SAIDA,
                      IML2.ATD_IML_DT_ENTRADA,
                      IML2.ATD_IML_HR_ENTRADA,
                      SETOR2.CAD_SET_CD_SETOR,
                      SETOR2.CAD_SET_ID
                 FROM TB_ATD_IML_INT_MOV_LEITO IML2
                 JOIN TB_CAD_QLE_QUARTO_LEITO QLE2 ON QLE2.CAD_QLE_ID = IML2.CAD_CAD_QLE_ID
                 JOIN TB_ATD_ATE_ATENDIMENTO ATD2 ON ATD2.ATD_ATE_ID = IML2.ATD_ATE_ID
                 JOIN TB_CAD_SET_SETOR SETOR2 ON SETOR2.CAD_SET_ID = QLE2.CAD_SET_ID
                WHERE (IML2.ATD_IML_FL_STATUS = 'A')
                and atd2.atd_ate_fl_status = 'A'
                and iml2.atd_iml_dt_saida = pATD_IML_DT_ENTRADA) ORIGEM
      ON ORIGEM.ATD_ATE_ID = IML3.ATD_ATE_ID
     AND ORIGEM.ATD_IML_DT_SAIDA <= IML3.ATD_IML_DT_ENTRADA
     AND ORIGEM.ATD_IML_HR_SAIDA = IML3.ATD_IML_HR_ENTRADA
    LEFT JOIN (SELECT IML.ATD_ATE_ID,
                      IML.ATD_IML_DT_SAIDA,
                      IML.ATD_IML_HR_SAIDA,
                      IML.ATD_IML_DT_ENTRADA,
                      IML.ATD_IML_HR_ENTRADA,
                      SETOR.CAD_SET_CD_SETOR,
                      SETOR.CAD_SET_ID
                 FROM TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID
                WHERE (IML.ATD_IML_FL_STATUS = 'A')
                and atd.atd_ate_fl_status = 'A'
                and iml.atd_iml_dt_entrada = pATD_IML_DT_ENTRADA) DESTINO
      ON DESTINO.ATD_ATE_ID = IML3.ATD_ATE_ID
     AND (DESTINO.ATD_IML_DT_SAIDA IS NULL OR DESTINO.ATD_IML_DT_SAIDA >= IML3.ATD_IML_DT_ENTRADA)
     AND DESTINO.ATD_IML_HR_ENTRADA = IML3.ATD_IML_HR_SAIDA
   where (IML3.ATD_IML_FL_STATUS = 'A')
       AND (ATD3.ATD_ATE_FL_STATUS = 'A')
     AND (DESTINO.CAD_SET_CD_SETOR IS NOT NULL) --mov entre mesmo setor n?o conta
     AND (SETOR.CAD_SET_CD_SETOR != DESTINO.CAD_SET_CD_SETOR)
     AND (DESTINO.CAD_SET_ID NOT IN (5))

     AND (SETOR.CAD_SET_ID NOT IN (5))
     AND (pCAD_SET_ID IS NULL OR QLE3.CAD_SET_ID = pCAD_SET_ID)
     AND (pCAD_PLA_ID_PLANO IS NULL OR PLA3.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)

AND ((pCOM_HOSP_DIA IS NULL) OR
          (pCOM_HOSP_DIA = '0' AND (PCAD_CSE_ID = '8') AND SETOR.CAD_CSE_ID = 8) OR
(pCOM_HOSP_DIA = '0' AND (PCAD_CSE_ID NOT IN ('8','9') OR PCAD_CSE_ID IS NULL) AND SETOR.CAD_CSE_ID NOT IN ('8','9')) OR
          (pCOM_HOSP_DIA = '1' AND SETOR.CAD_CSE_ID = 8)
           )
    -- and ((setor.cad_set_cd_setor = origem.cad_set_cd_setor)  OR (origem.cad_set_cd_setor is null))
    -- AND (DESTINO.ATD_IML_DT_ENTRADA = pATD_IML_DT_ENTRADA)
     AND (IML3.ATD_IML_DT_SAIDA = pATD_IML_DT_ENTRADA)
     AND (atd3.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
     AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC3.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
     AND ((pSUBGRUPO = 'ACS' AND CNV.CAD_CNV_ID_CONVENIO = 281) OR
         (pSUBGRUPO = 'AMIL' AND cnv.cad_cgc_id = 1 and cnv.cad_tpe_cd_codigo = 'SP' and cnv.cad_cnv_cd_hac_prestador != 'S077') OR
         (pSUBGRUPO = 'FUNCIONARIO' AND cnv.cad_cnv_cd_hac_prestador in ('GG05', 'HAC', 'NP01', 'NR14', 'S077') ) OR
         (pSUBGRUPO = 'MERCADO' AND CNV.cad_cgc_id = 2 AND cnv.cad_cnv_id_convenio!=282 ) OR
         (pSUBGRUPO = 'PARTICULAR' AND CNV.cad_cgc_id = 2 AND CNV.CAD_CNV_ID_CONVENIO = 282))
          ;
  return(Result);
end FNC_INT_QTD_MOV_ENVIADAS;
