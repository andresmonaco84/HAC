create or replace procedure PRC_INT_REL_CENSO_MENSAL
      (
      pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE,
      pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
      pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
     PATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ICD_INT_CENSODIARIO.ATD_ICD_DATA_CENSO%TYPE,
     PATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ICD_INT_CENSODIARIO.ATD_ICD_DATA_CENSO%TYPE,

     io_cursor              OUT PKG_CURSOR.t_cursor
       ) is
      /********************************************************************
      *    Procedure: PRC_INT_REL_CENSO_MENSAL
      *
      *    Data Criacao:  12/11/09   Por: pedro
      *    Data Alteracao:           Por:
      *
      *    Funcao: RETORNA O CENSO DO PERIODO INFORMADO
      *
      *******************************************************************/
      v_cursor PKG_CURSOR.t_cursor;

    begin

      OPEN v_cursor FOR

  SELECT      CENSO.ATD_ICD_DATA_CENSO,
              SETOR.CAD_SET_DS_SETOR,
              LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
              UNI.CAD_UNI_DS_UNIDADE,
               CASE WHEN CENSO.CAD_PLA_CD_TIPOPLANO IS NULL THEN '.'
              else CENSO.CAD_PLA_CD_TIPOPLANO
              END CAD_PLA_CD_TIPOPLANO,
              
              
              
              /*CASE WHEN PLANO.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS'
                   WHEN PLANO.CAD_PLA_CD_TIPOPLANO = 'FU' THEN 'FU'
                   WHEN PLANO.CAD_PLA_CD_TIPOPLANO = 'SP' THEN 'SP'
                   WHEN PLANO.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
              END  TP_PLANO_PRINCIPAL     ,*/
              
              NVL(CENSO.MEDIA_DIARIA,0)                   MEDIA_DIARIA,
              NVL(CENSO.LEITOS_DIA,0)                     LEITOS_DIA,
              NVL(CENSO.LEITOS_MES,0)                     LEITOS_MES,
              NVL(CENSO.LEITOS_TOTAL_MES,0)               LEITOS_TOTAL_MES,
              NVL(CENSO.PCT_OCUPACAO,0)                   PCT_OCUPACAO,
              NVL(CENSO.ITS,0)                            ITS,
              NVL(CENSO.MEDIA_PERMANENCIA,0)              MEDIA_PERMANENCIA,
              NVL(CENSO.COEFICIENTE_48MAIS,0)             COEFICIENTE_48MAIS,
              NVL(CENSO.COEFICIENTE_48MENOS,0)            COEFICIENTE_48MENOS,
              NVL(CENSO.TOTAL_COEFICIENTES,0)             TOTAL_COEFICIENTES,
              NVL(CENSO.IR_GR,0)                          IR_GR,
              NVL(CENSO.ATD_ICD_QT_INTERNACAO,0)          ATD_ICD_QT_INTERNACAO,
              NVL(CENSO.ATD_ICD_QT_SAIDA,0)               ATD_ICD_QT_SAIDA,
              NVL(CENSO.ATD_IAC_QT_SAIDA_OBITO_MAIS48,0)  ATD_IAC_QT_SAIDA_OBITO_MAIS48,
              NVL(CENSO.ATD_IAC_QT_SAIDA_OBITO_MENOS48,0) ATD_IAC_QT_SAIDA_OBITO_MENOS48,
              NVL(CENSO.ATD_IAC_QT_MOV_RECEBIDAS,0)       ATD_IAC_QT_MOV_RECEBIDAS,
              NVL(CENSO.ATD_IAC_QT_MOV_ENVIADAS,0)        ATD_IAC_QT_MOV_ENVIADAS,
              NVL(CENSO.ATD_IAC_QT_PACIENTE_DIA,0)        ATD_IAC_QT_PACIENTE_DIA,
              NVL(CENSO.ATD_IAC_QT_NASCIDOS,0)            ATD_IAC_QT_NASCIDOS,
              NVL(CENSO.ATD_IAC_QT_PARTONORMAL,0)         ATD_IAC_QT_PARTONORMAL,
              NVL(CENSO.ATD_IAC_QT_PARTOCESARIA,0)        ATD_IAC_QT_PARTOCESARIA,
              NVL(CENSO.ATD_IAC_QT_PARTOFORCEPS,0)        ATD_IAC_QT_PARTOFORCEPS,
              NVL(CENSO.ATD_IAC_QT_NASCIDOSMORTOS,0)      ATD_IAC_QT_NASCIDOSMORTOS,
              NVL(CENSO.ATD_IAC_QT_GEMELAR,0)             ATD_IAC_QT_GEMELAR
             
              
  FROM        TB_CAD_SET_SETOR                   SETOR  
  JOIN        TB_CAD_UNI_UNIDADE                 UNI
  ON          UNI.CAD_UNI_ID_UNIDADE           = SETOR.CAD_UNI_ID_UNIDADE
  JOIN        TB_CAD_LAT_LOCAL_ATENDIMENTO       LAT
  ON          LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
 
  
  LEFT JOIN  (

           SELECT DISTINCT  ICD.ATD_ICD_DATA_CENSO,
                   SETOR.CAD_SET_DS_SETOR,
                   SETOR.CAD_SET_ID,
                   LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                   LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                   UNI.CAD_UNI_ID_UNIDADE,
                   UNI.CAD_UNI_DS_UNIDADE,
                
                   CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END CAD_PLA_CD_TIPOPLANO,-----------------------------


                   Round((SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY
                      CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                       )) / ((TO_DATE(PATD_ATE_DT_ATENDIMENTO_FIM,'dd-MM-yyyy') - TO_DATE(PATD_ATE_DT_ATENDIMENTO_INI,'dd-MM-yyyy') + 1)),2)  
                     MEDIA_DIARIA, ---------------

                   (TO_DATE(PATD_ATE_DT_ATENDIMENTO_FIM,'dd-MM-yyyy') - TO_DATE(PATD_ATE_DT_ATENDIMENTO_INI,'dd-MM-yyyy') +1) * (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I'))
                                                                  FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE QLE.CAD_SET_ID = SETOR.CAD_SET_ID)
                    LEITOS_DIA, ----------------

                   (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I'))
                       FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE QLE.CAD_SET_ID = SETOR.CAD_SET_ID) LEITOS_MES,
 
                   (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I'))
                       FROM  TB_CAD_QLE_QUARTO_LEITO QLE) LEITOS_TOTAL_MES,

                 NVL(ROUND((SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY
                              CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                               )) * 100
                        /
                       ((TO_DATE(PATD_ATE_DT_ATENDIMENTO_FIM,'dd-MM-yyyy') - TO_DATE(PATD_ATE_DT_ATENDIMENTO_INI,'dd-MM-yyyy')+1) * (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I'))
                                                                  FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE QLE.CAD_SET_ID = SETOR.CAD_SET_ID))
                   ,2),0) PCT_OCUPACAO, ---------------

                   --ITS = 100 - PCT_OCUPACAO * MEDIA DE PERMANENCIA / PCT_OCUPACAO
                 NVL(round( CASE WHEN                     
                                    NVL(((SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY
                                   CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                                   )) * 100 ) /
                                   ((TO_DATE(PATD_ATE_DT_ATENDIMENTO_FIM,'dd-MM-yyyy') - TO_DATE(PATD_ATE_DT_ATENDIMENTO_INI,'dd-MM-yyyy')+1) * 
                                   (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I')) FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE QLE.CAD_SET_ID = SETOR.CAD_SET_ID))
                                   ,0)
                               > 0 THEN --CASO PCT OCUPACAO N SEJA ZERO ITS =
                   (
                        (100 -  ((SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY
                                  CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                                  WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                                  WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                                  WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                                  ELSE 'NP'  END ||SETOR.CAD_SET_ID
                                   )) * 100 ) /
                                   ((TO_DATE(PATD_ATE_DT_ATENDIMENTO_FIM,'dd-MM-yyyy') - TO_DATE(PATD_ATE_DT_ATENDIMENTO_INI,'dd-MM-yyyy')+1) * 
                                   (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I')) FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE QLE.CAD_SET_ID = SETOR.CAD_SET_ID)
                          ))
                     
                    *  NVL(round( CASE WHEN 
                    (
                        (SUM(ICD.ATD_ICD_QT_SAIDA)  OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                        WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                        WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                        WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                        ELSE 'NP'  END ||SETOR.CAD_SET_ID         ))
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)  OVER(PARTITION BY
                        CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         )) 
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                        CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         )) 
                        
                        ) > 0 THEN
                       (
                         (SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY
                         CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END  ||SETOR.CAD_SET_ID --|| ICD.ATD_ICD_DATA_CENSO
                          ))
                          /
                           (
                           (SUM(ICD.ATD_ICD_QT_SAIDA)                  OVER(PARTITION BY
                           CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID) )
                            +
                            (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)   OVER(PARTITION BY
                          CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         )) 
                            +
                            (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                           CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         ))               
                         )
                        )
                   END,2),0)
                   /
                       (
                       NVL(ROUND((SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY
                                  CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                                   )) * 100 ,2),0)
                            /
                           ((TO_DATE(PATD_ATE_DT_ATENDIMENTO_FIM,'dd-MM-yyyy') - TO_DATE(PATD_ATE_DT_ATENDIMENTO_INI,'dd-MM-yyyy')+1) * (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I'))
                                                                      FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE QLE.CAD_SET_ID = SETOR.CAD_SET_ID))
                        )
                   )
                   END,2),0) ITS,


                    NVL(round( CASE WHEN 
                    (
                      (SUM(ICD.ATD_ICD_QT_SAIDA)  OVER(PARTITION BY
                     CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         ))
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         )) 
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         )) 
                        
                        ) > 0 THEN

                       (
                       (SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID --|| ICD.ATD_ICD_DATA_CENSO
                        ))
                        /
                         (SUM(ICD.ATD_ICD_QT_SAIDA)    OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         ))
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)  OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         ))
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         ))
                        )
                   END,2),0)   MEDIA_PERMANENCIA,--------------Média permanência: (total de paciente dia)21 / ( total de saídas )--------

                  -- Coeficientes óbitos: mais de 48 horas
                  --(total de óbito mais de 48 horas * 100) / (total de saídas + total de óbito mais de 48 horas).
                  NVL(round(CASE WHEN 
                             ( (
                             (SUM(ICD.ATD_ICD_QT_SAIDA)     OVER(PARTITION BY
                               CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                              )) +
                              (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)   OVER(PARTITION BY
                              CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                              )) +
                              (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)   OVER(PARTITION BY
                               CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                               )) +
                              (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48) OVER(PARTITION BY
                               CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                             )   
                             > 0 ) THEN
                            (
                        ((SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID )) * 100)
                    / (
                     (SUM(ICD.ATD_ICD_QT_SAIDA)     OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                      )) +
                      (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)   OVER(PARTITION BY
                      CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                      )) +
                      (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)   OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                      )) +
                      (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                        )
                    )END,2),0) COEFICIENTE_48MAIS, ----------------------------------------------------

            --Coeficientes óbitos: menos de 48 horas --(total de óbito menos de 48 horas * 100) / (total de saídas + total de óbito menos de 48 horas).
              NVL(round(CASE WHEN 
                        (
                        (
                        (SUM(ICD.ATD_ICD_QT_SAIDA)     OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                         +
                      (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)   OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID )) 
                        +
                      (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)  OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                        +
                    (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                        )
                         > 0 )THEN
                    (
                    ((SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID )) * 100)
                    / (
                     (SUM(ICD.ATD_ICD_QT_SAIDA)     OVER(PARTITION BY
                      CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                         +
                      (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)     OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID )) 
                        +
                      (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)
                     OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                        +
                    (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                       )
                    )END,2),0) COEFICIENTE_48MENOS, --------------------------------------

            --Total de coeficientes óbitos:
            NVL(round( CASE WHEN 
                    (
                        (SUM(ICD.ATD_ICD_QT_SAIDA)  OVER(PARTITION BY
                        CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         ))
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)  OVER(PARTITION BY
                        CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         )) 
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                        CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID         )) 
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)   OVER(PARTITION BY
                        CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID  )) 
                        
                        ) > 0 THEN
            (
            ((SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48) OVER(PARTITION BY
                      CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID )) * 100)
            /
             (
             (SUM(ICD.ATD_ICD_QT_SAIDA)   OVER(PARTITION BY
              CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID  )  )
                +
             (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)   OVER(PARTITION BY
              CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID  ))
                +
             (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)   OVER(PARTITION BY
               CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID  ))
                 +
             (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)   OVER(PARTITION BY
              CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID  ))   
             )
             )
              END,2),0)
             +
              NVL(Round(CASE WHEN 
                        (
                        (SUM(ICD.ATD_ICD_QT_SAIDA)     OVER(PARTITION BY
                        CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)  OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)  OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                        +
                        (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)     OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                        ) > 0 THEN
            (
              
              ((SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID )) * 100)
                 /
                  (
                   (SUM(ICD.ATD_ICD_QT_SAIDA)     OVER(PARTITION BY
                  CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                    +
                    (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)  OVER(PARTITION BY
                   CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                    +
                    (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)  OVER(PARTITION BY
                  CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                    +
                    (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)     OVER(PARTITION BY
                   CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID ))
                  )
            )
               END,2),0)
               TOTAL_COEFICIENTES, ------------------------------------------


                   NVL(round((SUM(ICD.ATD_ICD_QT_SAIDA) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) / (SELECT COUNT(QLE.CAD_QLE_ID) FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE QLE.CAD_SET_ID = SETOR.CAD_SET_ID)
                   ,2),0) IR_GR,
         

                   (SUM(ICD.ATD_ICD_QT_INTERNACAO) OVER(PARTITION BY
                      CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_ICD_QT_INTERNACAO,

                   NVL((SUM(ICD.ATD_ICD_QT_SAIDA) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )),0) ATD_ICD_QT_SAIDA,

                  (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_SAIDA_OBITO_MAIS48,

                   (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_SAIDA_OBITO_MENOS48,

                   (SUM(ICD.ATD_IAC_QT_MOV_RECEBIDAS) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_MOV_RECEBIDAS,

                   (SUM(ICD.ATD_IAC_QT_MOV_ENVIADAS) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_MOV_ENVIADAS,

                   (SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID --|| ICD.ATD_ICD_DATA_CENSO
                   )) ATD_IAC_QT_PACIENTE_DIA,

                   (SUM(ICD.ATD_IAC_QT_NASCIDOS) OVER(PARTITION BY
                      CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_NASCIDOS,

                   (SUM(ICD.ATD_IAC_QT_PARTONORMAL) OVER(PARTITION BY
                      CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_PARTONORMAL,

                   (SUM(ICD.ATD_IAC_QT_PARTOCESARIA) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_PARTOCESARIA,

                   (SUM(ICD.ATD_IAC_QT_PARTOFORCEPS) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_PARTOFORCEPS,

                    (SUM(ICD.ATD_IAC_QT_NASCIDOSMORTOS) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_NASCIDOSMORTOS,

                    (SUM(ICD.ATD_IAC_QT_GEMELAR) OVER(PARTITION BY
                       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' 
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'FU' THEN 'FU'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO   = 'SP' THEN 'SP'
                    WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'PA' THEN 'PA'
                    ELSE 'NP'  END ||SETOR.CAD_SET_ID
                   )) ATD_IAC_QT_GEMELAR

                 FROM TB_ATD_ICD_INT_CENSODIARIO         ICD

                 JOIN TB_CAD_SET_SETOR                   SETOR
                 ON   SETOR.CAD_SET_ID                 = ICD.CAD_SET_ID
                 LEFT JOIN TB_CAD_PLA_PLANO                   PLA
                 ON   PLA.CAD_PLA_ID_PLANO             = ICD.CAD_PLA_ID_PLANO       
                 JOIN TB_CAD_UNI_UNIDADE                 UNI
                 ON   UNI.CAD_UNI_ID_UNIDADE           = SETOR.CAD_UNI_ID_UNIDADE
                 JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO       LAT
                 ON   LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO

                 WHERE (ICD.ATD_ICD_DATA_CENSO BETWEEN PATD_ATE_DT_ATENDIMENTO_INI AND PATD_ATE_DT_ATENDIMENTO_FIM)
                  AND   (pCAD_UNI_ID_UNIDADE IS NULL OR UNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                  AND   (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
                  AND   (pCAD_SET_ID  IS NULL OR SETOR.CAD_SET_ID = pCAD_SET_ID)
                 -- AND   LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO   = 'INTERNADO' 
                  and   SETOR.CAD_SET_FL_ATIVO_OK          = 'S'
                  AND   SETOR.CAD_SET_FL_PERMITEINTERN_OK  = 'S'
                  GROUP BY
                          ICD.ATD_ICD_DATA_CENSO,
                          SETOR.CAD_SET_DS_SETOR,
                          SETOR.CAD_SET_ID,
                          LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                          LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                          UNI.CAD_UNI_ID_UNIDADE,
                          UNI.CAD_UNI_DS_UNIDADE,
                          PLA.CAD_PLA_CD_TIPOPLANO,
                          ICD.ATD_ICD_QT_INTERNACAO,
                          ICD.ATD_IAC_QT_PACIENTE_DIA,
                          ICD.ATD_ICD_QT_SAIDA,
                          ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48,
                          ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48,
                          ICD.ATD_IAC_QT_MOV_RECEBIDAS,
                          ICD.ATD_IAC_QT_MOV_ENVIADAS,
                          ICD.ATD_IAC_QT_NASCIDOS,
                          ICD.ATD_IAC_QT_PARTONORMAL,
                          ICD.ATD_IAC_QT_PARTOCESARIA,
                          ICD.ATD_IAC_QT_PARTOFORCEPS,
                          ICD.ATD_IAC_QT_NASCIDOSMORTOS,
                          ICD.ATD_IAC_QT_GEMELAR
                  

  )         CENSO
  ON        CENSO.CAD_SET_ID                   = SETOR.CAD_SET_ID
  AND       CENSO.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
  AND       CENSO.CAD_UNI_ID_UNIDADE           = UNI.CAD_UNI_ID_UNIDADE
   
  WHERE (CENSO.ATD_ICD_DATA_CENSO BETWEEN PATD_ATE_DT_ATENDIMENTO_INI AND PATD_ATE_DT_ATENDIMENTO_FIM)
  AND   (pCAD_UNI_ID_UNIDADE IS NULL OR UNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
  AND   (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
  AND   (pCAD_SET_ID  IS NULL OR SETOR.CAD_SET_ID = pCAD_SET_ID)
 -- AND   LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO   = 'INTERNADO' 
  and   SETOR.CAD_SET_FL_ATIVO_OK          = 'S'
  AND   SETOR.CAD_SET_FL_PERMITEINTERN_OK  = 'S'

  
  ORDER BY  SETOR.CAD_SET_DS_SETOR,
            CENSO.CAD_PLA_CD_TIPOPLANO
     
      ;
      io_cursor := v_cursor;
    end PRC_INT_REL_CENSO_MENSAL;
/
