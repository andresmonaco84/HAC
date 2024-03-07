create or replace function FNC_INT_QTD_MOV_ENVIADAS
(
  pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
  pATD_IML_DT_ENTRADA IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_DT_ENTRADA%TYPE,
  pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE default null,
  pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE default null,
  pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL
)
---retorna a qtd de saídas por movimentacao
return NUMBER is Result NUMBER;
begin
SELECT                    COUNT(DISTINCT IML3.ATD_ATE_ID)INTO RESULT
    --                OVER (PARTITION BY AIC3.ATD_AIC_TP_SITUACAO_PAC||QLE3.CAD_SET_ID||PLA3.CAD_PLA_CD_TIPOPLANO) TOTAL
         --           IML3.ATD_ATE_ID, IML3.ATD_IML_DT_SAIDA, IML3.ATD_IML_HR_SAIDA,
          --          IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA--, SETOR3.CAD_SET_DS_SETOR
           FROM      TB_ATD_IML_INT_MOV_LEITO IML3
           JOIN      TB_CAD_QLE_QUARTO_LEITO QLE3
           ON        QLE3.CAD_QLE_ID      = IML3.CAD_CAD_QLE_ID
           JOIN      TB_ATD_ATE_ATENDIMENTO ATD3
           ON        ATD3.ATD_ATE_ID      = IML3.ATD_ATE_ID
           JOIN      TB_ATD_AIC_ATE_INT_COMPL   AIC3
           ON        AIC3.ATD_ATE_ID          = ATD3.ATD_ATE_ID
           JOIN      TB_ASS_PAT_PACIEATEND      PAT3
           ON        PAT3.ATD_ATE_ID          = ATD3.ATD_ATE_ID
           JOIN      TB_CAD_PAC_PACIENTE        PAC3
           ON        PAC3.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(pat3.atd_ate_id)
           JOIN      TB_CAD_PLA_PLANO           PLA3
           ON        PLA3.CAD_PLA_ID_PLANO    = PAC3.CAD_PLA_ID_PLANO
            JOIN      TB_CAD_SET_SETOR           SETOR
                 ON        SETOR.CAD_SET_ID         = QLE3.CAD_SET_ID
             LEFT JOIN (SELECT   IML2.ATD_ATE_ID, IML2.ATD_IML_DT_SAIDA, IML2.ATD_IML_HR_SAIDA,
                      IML2.ATD_IML_DT_ENTRADA,IML2.ATD_IML_HR_ENTRADA, SETOR2.CAD_SET_CD_SETOR
                             FROM      TB_ATD_IML_INT_MOV_LEITO IML2
                             JOIN      TB_CAD_QLE_QUARTO_LEITO QLE2
                             ON        QLE2.CAD_QLE_ID  = IML2.CAD_CAD_QLE_ID
                             JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                             ON        ATD2.ATD_ATE_ID  = IML2.ATD_ATE_ID
                             JOIN      TB_CAD_SET_SETOR SETOR2
                             ON        SETOR2.CAD_SET_ID = QLE2.CAD_SET_ID
                            WHERE     (IML2.ATD_IML_FL_STATUS = 'A')

                      ) ORIGEM
                  ON        ORIGEM.ATD_ATE_ID = IML3.ATD_ATE_ID
                  AND       ORIGEM.ATD_IML_DT_SAIDA <= IML3.ATD_IML_DT_ENTRADA
                  AND       ORIGEM.ATD_IML_HR_SAIDA = IML3.ATD_IML_HR_ENTRADA
                 -- AND ORIGEM.ATD_IML_DT_ENTRADA = IML.ATD_IML_DT_ENTRADA

                   LEFT JOIN (  SELECT    IML.ATD_ATE_ID, IML.ATD_IML_DT_SAIDA, IML.ATD_IML_HR_SAIDA,
                                          IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA, SETOR.CAD_SET_CD_SETOR
                                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                                 JOIN      TB_CAD_QLE_QUARTO_LEITO QLE
                                 ON        QLE.CAD_QLE_ID  = IML.CAD_CAD_QLE_ID
                                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD
                                 ON        ATD.ATD_ATE_ID = IML.ATD_ATE_ID
                                 JOIN      TB_CAD_SET_SETOR SETOR
                                 ON        SETOR.CAD_SET_ID = QLE.CAD_SET_ID
                                 WHERE     (IML.ATD_IML_FL_STATUS = 'A')

                                 ) DESTINO
                  ON             DESTINO.ATD_ATE_ID = IML3.ATD_ATE_ID
                  AND            (DESTINO.ATD_IML_DT_SAIDA IS NULL OR DESTINO.ATD_IML_DT_SAIDA >= IML3.ATD_IML_DT_ENTRADA)
                  AND            DESTINO.ATD_IML_HR_ENTRADA = IML3.ATD_IML_HR_SAIDA
  
           where
                  ((SETOR.CAD_SET_CD_SETOR != ORIGEM.CAD_SET_CD_SETOR) or (ORIGEM.CAD_SET_CD_SETOR is null) )
            AND   ((SETOR.CAD_SET_CD_SETOR != DESTINO.CAD_SET_CD_SETOR) or (DESTINO.CAD_SET_CD_SETOR is null) )
           AND    (IML3.ATD_IML_FL_STATUS = 'A')
           AND    (DESTINO.CAD_SET_CD_SETOR IS NOT NULL)  --mov entre mesmo setor não conta           
           AND    (pCAD_SET_ID IS NULL OR QLE3.CAD_SET_ID = pCAD_SET_ID)
           AND    (pCAD_PLA_ID_PLANO IS NULL OR PLA3.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
           AND    (pCAD_PLA_CD_TIPOPLANO IS NULL OR PLA3.CAD_PLA_CD_TIPOPLANO = pCAD_PLA_CD_TIPOPLANO)
           AND    (DESTINO.ATD_IML_DT_ENTRADA = pATD_IML_DT_ENTRADA)
           AND    (pCAD_UNI_ID_UNIDADE IS NULL OR atd3.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
;

  return(Result);
end FNC_INT_QTD_MOV_ENVIADAS;
/
