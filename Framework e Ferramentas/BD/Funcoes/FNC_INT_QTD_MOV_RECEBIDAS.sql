create or replace function FNC_INT_QTD_MOV_RECEBIDAS(pCAD_SET_ID           IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
                                                     pATD_IML_DT_ENTRADA   IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_DT_ENTRADA%TYPE,
                                                     pCAD_PLA_ID_PLANO     IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE default null,
                                                     pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE default null,
                                                     pCAD_UNI_ID_UNIDADE   IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL
                                                     ,
                                           pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
                                           pSUBGRUPO VARCHAR2 DEFAULT NULL,
                                           pCOM_HOSP_DIA VARCHAR2 DEFAULT NULL,
                                           pCAD_CSE_ID IN TB_CAD_SET_SETOR.CAD_CSE_ID%TYPE DEFAULT NULL
                                           )
---retorna a qtd de internacoes por movimentacao
 return NUMBER is
  Result NUMBER;
begin
  SELECT COUNT( IML.ATD_ATE_ID)
    INTO RESULT
    FROM TB_ATD_IML_INT_MOV_LEITO IML
    JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
    JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID
    JOIN TB_ATD_AIC_ATE_INT_COMPL AIC ON AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
    JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(ATD.ATD_ATE_ID)
    JOIN TB_CAD_PLA_PLANO PLA ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
    JOIN TB_CAD_CNV_CONVENIO CNV ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
    JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID
    LEFT JOIN (SELECT IML7.ATD_ATE_ID,
                      IML7.ATD_IML_DT_SAIDA,
                      IML7.ATD_IML_HR_SAIDA,
                      IML7.ATD_IML_DT_ENTRADA,
                      IML7.ATD_IML_HR_ENTRADA,
                      SETOR7.CAD_SET_CD_SETOR,
                      SETOR7.CAD_SET_ID
                 FROM TB_ATD_IML_INT_MOV_LEITO IML7
                 LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE7 ON QLE7.CAD_QLE_ID = IML7.CAD_CAD_QLE_ID
                 LEFT JOIN TB_ATD_ATE_ATENDIMENTO ATD7 ON ATD7.ATD_ATE_ID = IML7.ATD_ATE_ID
                 LEFT JOIN TB_CAD_SET_SETOR SETOR7 ON SETOR7.CAD_SET_ID = QLE7.CAD_SET_ID
                WHERE (IML7.ATD_IML_FL_STATUS = 'A')
                  AND (IML7.ATD_IML_DT_SAIDA = pATD_IML_DT_ENTRADA)
                  AND (ATD7.ATD_ATE_FL_STATUS = 'A')
                  AND (pCAD_UNI_ID_UNIDADE IS NULL OR ATD7.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
              ) ORIGEM7
      ON ORIGEM7.ATD_ATE_ID = IML.ATD_ATE_ID
     AND ORIGEM7.ATD_IML_DT_SAIDA <= IML.ATD_IML_DT_ENTRADA
     AND ORIGEM7.ATD_IML_HR_SAIDA = IML.ATD_IML_HR_ENTRADA
    LEFT JOIN (SELECT IML3.ATD_ATE_ID,
                      IML3.ATD_IML_DT_SAIDA,
                      IML3.ATD_IML_HR_SAIDA,
                      IML3.ATD_IML_DT_ENTRADA,
                      IML3.ATD_IML_HR_ENTRADA,
                      SETOR3.CAD_SET_CD_SETOR
                 FROM TB_ATD_IML_INT_MOV_LEITO IML3
                 JOIN TB_CAD_QLE_QUARTO_LEITO QLE3 ON QLE3.CAD_QLE_ID = IML3.CAD_CAD_QLE_ID
                 JOIN TB_ATD_ATE_ATENDIMENTO ATD3 ON ATD3.ATD_ATE_ID = IML3.ATD_ATE_ID
                 JOIN TB_CAD_SET_SETOR SETOR3 ON SETOR3.CAD_SET_ID = QLE3.CAD_SET_ID
                WHERE (IML3.ATD_IML_FL_STATUS = 'A')
                  AND (IML3.ATD_IML_DT_ENTRADA = pATD_IML_DT_ENTRADA)
                  AND (ATD3.ATD_ATE_FL_STATUS = 'A')
                  AND (pCAD_UNI_ID_UNIDADE IS NULL OR ATD3.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)) DESTINO
      ON DESTINO.ATD_ATE_ID = IML.ATD_ATE_ID
     AND (DESTINO.ATD_IML_DT_SAIDA IS NULL OR DESTINO.ATD_IML_DT_SAIDA >= IML.ATD_IML_DT_ENTRADA)
     AND DESTINO.ATD_IML_HR_ENTRADA = IML.ATD_IML_HR_SAIDA
   WHERE (IML.ATD_IML_FL_STATUS = 'A')
     AND (ATD.ATD_ATE_FL_STATUS = 'A')
     AND (SETOR.CAD_SET_ID NOT IN (5))
--     and (ORIGEM7.CAD_SET_ID NOT IN (2072,2312,5,140))
     AND (ORIGEM7.CAD_SET_CD_SETOR IS NOT NULL)
     AND (SETOR.CAD_SET_CD_SETOR != ORIGEM7.CAD_SET_CD_SETOR)
     and (pCAD_SET_ID IS NULL OR QLE.CAD_SET_ID = pCAD_SET_ID)
     AND (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)

     AND ((pCOM_HOSP_DIA IS NULL) OR
          (pCOM_HOSP_DIA = '0' AND (PCAD_CSE_ID = '8') AND SETOR.CAD_CSE_ID = 8) OR
(pCOM_HOSP_DIA = '0' AND (PCAD_CSE_ID NOT IN ('8','9') OR PCAD_CSE_ID IS NULL) AND SETOR.CAD_CSE_ID NOT IN ('8','9')) OR
          (pCOM_HOSP_DIA = '1' AND SETOR.CAD_CSE_ID = 8) )


     AND (ORIGEM7.ATD_IML_DT_SAIDA = pATD_IML_DT_ENTRADA)
     AND (atd.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
   AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
   AND ((pSUBGRUPO = 'ACS' AND CNV.CAD_CNV_ID_CONVENIO = 281) OR
         (pSUBGRUPO = 'AMIL' AND cnv.cad_cgc_id = 1 and cnv.cad_tpe_cd_codigo = 'SP' and cnv.cad_cnv_cd_hac_prestador != 'S077') OR
         (pSUBGRUPO = 'FUNCIONARIO' AND cnv.cad_cnv_cd_hac_prestador in ('GG05', 'HAC', 'NP01', 'NR14', 'S077') ) OR
         (pSUBGRUPO = 'MERCADO' AND CNV.cad_cgc_id = 2 AND cnv.cad_cnv_id_convenio!=282 ) OR
         (pSUBGRUPO = 'PARTICULAR' AND CNV.cad_cgc_id = 2 AND CNV.CAD_CNV_ID_CONVENIO = 282))
                  ;
  return(Result);
end FNC_INT_QTD_MOV_RECEBIDAS;
