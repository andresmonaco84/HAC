create or replace function FNC_INT_QTD_MOV_RECEBIDAS
(
  pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
  pATD_IML_DT_ENTRADA IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_DT_ENTRADA%TYPE,
  pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE default null,
  pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE default null,
  pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL
)
---retorna a qtd de internacoes por movimentacao
return NUMBER is Result NUMBER;
begin
SELECT    
                     COUNT(DISTINCT IML.ATD_ATE_ID)  INTO RESULT
           --          OVER (PARTITION BY AIC.ATD_AIC_TP_SITUACAO_PAC||QLE.CAD_SET_ID||PLA.CAD_PLA_CD_TIPOPLANO) TOTAL
                   --  IML.ATD_ATE_ID, IML.ATD_IML_DT_SAIDA, IML.ATD_IML_HR_SAIDA,
                  --    IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA, SETOR.CAD_SET_DS_SETOR
             FROM      TB_ATD_IML_INT_MOV_LEITO IML
             JOIN      TB_CAD_QLE_QUARTO_LEITO   QLE
             ON        QLE.CAD_QLE_ID         = IML.CAD_CAD_QLE_ID
             JOIN      TB_ATD_ATE_ATENDIMENTO     ATD
             ON        ATD.ATD_ATE_ID         = IML.ATD_ATE_ID
             JOIN      TB_ATD_AIC_ATE_INT_COMPL   AIC
             ON        AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
             JOIN      TB_ASS_PAT_PACIEATEND      PAT
             ON        PAT.ATD_ATE_ID          = ATD.ATD_ATE_ID
             JOIN      TB_CAD_PAC_PACIENTE        PAC
             ON        PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(pat.atd_ate_id)
             JOIN      TB_CAD_PLA_PLANO           PLA
             ON        PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
             JOIN      TB_CAD_SET_SETOR           SETOR
             ON        SETOR.CAD_SET_ID        = QLE.CAD_SET_ID 
              LEFT JOIN (SELECT   IML7.ATD_ATE_ID, IML7.ATD_IML_DT_SAIDA, IML7.ATD_IML_HR_SAIDA,
                                               IML7.ATD_IML_DT_ENTRADA,IML7.ATD_IML_HR_ENTRADA, SETOR7.CAD_SET_CD_SETOR
                         FROM      TB_ATD_IML_INT_MOV_LEITO IML7
                         LEFT JOIN      TB_CAD_QLE_QUARTO_LEITO QLE7
                         ON        QLE7.CAD_QLE_ID  = IML7.CAD_CAD_QLE_ID
                         LEFT JOIN      TB_ATD_ATE_ATENDIMENTO ATD7
                         ON        ATD7.ATD_ATE_ID  = IML7.ATD_ATE_ID
                         LEFT JOIN TB_CAD_SET_SETOR SETOR7
                         ON        SETOR7.CAD_SET_ID = QLE7.CAD_SET_ID
                         WHERE    (IML7.ATD_IML_FL_STATUS = 'A')
                        /* UNION 
                          SELECT    IMS2.ATD_ATE_ID, IMS2.ATD_IMS_DT_SAIDA, IMS2.ATD_IMS_HR_SAIDA,
                                    IMS2.ATD_IMS_DT_ENTRADA,IMS2.ATD_IMS_HR_ENTRADA, SETOR3.CAD_SET_CD_SETOR
                          FROM      TB_ATD_IMS_INT_MOV_SETOR IMS2
                          JOIN      TB_CAD_SET_SETOR         SETOR3 ON SETOR3.CAD_SET_ID = IMS2.CAD_SET_ID_SETOR                   
                          WHERE     IMS2.ATD_IMS_FL_STATUS = 'A'*/
             )ORIGEM7
              ON  ORIGEM7.ATD_ATE_ID = IML.ATD_ATE_ID
              AND ORIGEM7.ATD_IML_DT_SAIDA <= IML.ATD_IML_DT_ENTRADA
              AND ORIGEM7.ATD_IML_HR_SAIDA = IML.ATD_IML_HR_ENTRADA
               LEFT JOIN (  SELECT    IML3.ATD_ATE_ID, IML3.ATD_IML_DT_SAIDA, IML3.ATD_IML_HR_SAIDA,
                                        IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA, SETOR3.CAD_SET_CD_SETOR
                               FROM      TB_ATD_IML_INT_MOV_LEITO IML3
                               JOIN      TB_CAD_QLE_QUARTO_LEITO QLE3
                               ON        QLE3.CAD_QLE_ID  = IML3.CAD_CAD_QLE_ID
                               JOIN      TB_ATD_ATE_ATENDIMENTO ATD3
                               ON        ATD3.ATD_ATE_ID = IML3.ATD_ATE_ID
                               JOIN      TB_CAD_SET_SETOR SETOR3
                               ON        SETOR3.CAD_SET_ID = QLE3.CAD_SET_ID
                               WHERE     (IML3.ATD_IML_FL_STATUS = 'A')
                               ) DESTINO
                ON             DESTINO.ATD_ATE_ID = IML.ATD_ATE_ID
                AND            (DESTINO.ATD_IML_DT_SAIDA IS NULL OR DESTINO.ATD_IML_DT_SAIDA >= IML.ATD_IML_DT_ENTRADA)
                AND            DESTINO.ATD_IML_HR_ENTRADA = IML.ATD_IML_HR_SAIDA
             WHERE     (IML.ATD_IML_FL_STATUS = 'A')
             AND  ((SETOR.CAD_SET_CD_SETOR != ORIGEM7.CAD_SET_CD_SETOR) or (ORIGEM7.CAD_SET_CD_SETOR is null) )
             AND  ((SETOR.CAD_SET_CD_SETOR != DESTINO.CAD_SET_CD_SETOR) or (DESTINO.CAD_SET_CD_SETOR is null) )
             and  (pCAD_SET_ID IS NULL OR QLE.CAD_SET_ID = pCAD_SET_ID)
             AND  (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
             AND  (pCAD_PLA_CD_TIPOPLANO IS NULL OR PLA.CAD_PLA_CD_TIPOPLANO = pCAD_PLA_CD_TIPOPLANO)
             AND  (ORIGEM7.ATD_IML_DT_SAIDA = pATD_IML_DT_ENTRADA)
             AND  (pCAD_UNI_ID_UNIDADE IS NULL OR atd.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
;
  return(Result);
end FNC_INT_QTD_MOV_RECEBIDAS;
