create or replace procedure prc_int_rel_estat_pac_dia2
  (
pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
   io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_ESTAT_PAC_DIA
  *
  *    Data Criacao:  15/06/2010   Por: pedro
  *    Data Alteracao:28/12/2010  Por: Eduardo Hyppolito
  *    Alterac?o: Mostrar Somente setores com internacoes 
  *     
  *    Funcao: Popula o Relatorio de Relatorio Estat. Paciente/Dia/Taxa de Ocupac?o
  *    
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
   SELECT   DISTINCT    SETOR.CAD_SET_DS_SETOR,
              LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
              UNI.CAD_UNI_DS_UNIDADE,
              ''  MES_1,
              to_char(ADD_MONTHS(pATD_ATE_DT_ATENDIMENTO_FIM,-1),'MM/yyyy')  MES_2,
              ''  MES_3,
              NVL(CENSO.LEITOS_DIA,0)                     LEITOS_DIA,
              NVL(CENSO.LEITOS_MES,0)                     LEITOS_MES,
              NVL(CENSO.LEITOS_TOTAL_MES,0)               LEITOS_TOTAL_MES,
              NVL(CENSO.PCT_OCUPACAO,0)                   PCT_OCUPACAO,
              NVL(CENSO.MEDIA_PERMANENCIA,0)              MEDIA_PERMANENCIA,
              NVL(CENSO.ATD_IAC_QT_PACIENTE_DIA,0)        ATD_IAC_QT_PACIENTE_DIA,
              NVL(CENSO.ATD_ICD_QT_INTERNACAO,0)          ATD_ICD_QT_INTERNACAO,
              NVL(CENSO.ATD_ICD_QT_SAIDA,0)               ATD_ICD_QT_SAIDA
  FROM        TB_CAD_SET_SETOR                   SETOR
  JOIN        TB_ATD_ICD_INT_CENSODIARIO         ICD
  ON          ICD.CAD_SET_ID                   = SETOR.CAD_SET_ID
  JOIN        TB_CAD_UNI_UNIDADE                 UNI
  ON          UNI.CAD_UNI_ID_UNIDADE           = SETOR.CAD_UNI_ID_UNIDADE
  JOIN        TB_CAD_LAT_LOCAL_ATENDIMENTO       LAT
  ON          LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
  LEFT JOIN  ( SELECT
               SETOR.CAD_SET_ID,
               LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
               UNI.CAD_UNI_ID_UNIDADE,
               to_char(ADD_MONTHS(pATD_ATE_DT_ATENDIMENTO_FIM,-1),'MM/yyyy') MES,
               CASE WHEN ((
                                 ((to_date(TO_CHAR(LAST_DAY(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1)),'DD')||to_char(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1),'mm/yyyy'),'dd/mm/yyyy')
                                - to_date( '01/'||to_char(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1), 'mm/yyyy'),'dd/mm/yyyy')+1)
                                 * (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I')) FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE
                                                                                    QLE.CAD_SET_ID = SETOR.CAD_SET_ID))
                                      ) > 0) THEN
                                      (
               (to_date(TO_CHAR(LAST_DAY(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1)),'DD')||to_char(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1),'mm/yyyy'),'dd/mm/yyyy')
                - to_date( '01/'||to_char(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1), 'mm/yyyy'),'dd/mm/yyyy')+1)
                 * (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I')) FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE
                                                                                    QLE.CAD_SET_ID = SETOR.CAD_SET_ID)
                                      ) END
                                  LEITOS_DIA, ----------------
                     (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I'))
                       FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE QLE.CAD_SET_ID = SETOR.CAD_SET_ID) LEITOS_MES,
                       (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I'))
                       FROM  TB_CAD_QLE_QUARTO_LEITO QLE) LEITOS_TOTAL_MES,
                  NVL(ROUND(CASE WHEN ((
                                 ((to_date(TO_CHAR(LAST_DAY(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1)),'DD')||to_char(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1),'mm/yyyy'),'dd/mm/yyyy')
                                - to_date( '01/'||to_char(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1), 'mm/yyyy'),'dd/mm/yyyy')+1)
                                 * (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I')) FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE
                                                                                    QLE.CAD_SET_ID = SETOR.CAD_SET_ID))
                                      ) > 0) THEN
                                      (
                           (SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy'))) * 100
                              /
                             ((to_date(TO_CHAR(LAST_DAY(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1)),'DD')||to_char(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1),'mm/yyyy'),'dd/mm/yyyy')
                                - to_date( '01/'||to_char(add_months(pATD_ATE_DT_ATENDIMENTO_FIM,-1), 'mm/yyyy'),'dd/mm/yyyy')+1)
                                 * (SELECT COUNT(DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','I')) FROM  TB_CAD_QLE_QUARTO_LEITO QLE WHERE
                                                                                    QLE.CAD_SET_ID = SETOR.CAD_SET_ID))
                                       )      END
                         ,2),0) PCT_OCUPACAO, ---------------
                    NVL(round(
                      CASE WHEN
                      (
                          (SUM(ICD.ATD_ICD_QT_SAIDA)  OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy')))
                          +
                          (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48) OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy')))
                          +
                          (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy')))
                          ) > 0 THEN
                         (
                          SUM(ICD.ATD_IAC_QT_PACIENTE_DIA) OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy'))
                          /
                          (
                           (SUM(ICD.ATD_ICD_QT_SAIDA)    OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy')))
                          +
                          (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)  OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy')))
                          +
                          (SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48) OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy')))
                          )
                          )
                     END
                   ,2),0)   MEDIA_PERMANENCIA,--------------Media permanencia: (total de paciente dia)21 / ( total de saidas )--------
                  NVL((SUM(ICD.ATD_IAC_QT_PACIENTE_DIA)
                            OVER(PARTITION BY  SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy'))),0) ATD_IAC_QT_PACIENTE_DIA,
                  NVL((SUM(ICD.ATD_ICD_QT_INTERNACAO)
                            OVER(PARTITION BY  SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy'))),0) ATD_ICD_QT_INTERNACAO,
                 ( NVL((SUM(ICD.ATD_ICD_QT_SAIDA)
                       OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy'))),0)
                  +
                  NVL((SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48)
                       OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy'))),0)
                  +
                  NVL((SUM(ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48)
                       OVER(PARTITION BY SETOR.CAD_SET_ID||TO_CHAR(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy'))),0) 
)ATD_ICD_QT_SAIDA
                 FROM TB_ATD_ICD_INT_CENSODIARIO         ICD
                 JOIN TB_CAD_SET_SETOR                   SETOR
                 ON   SETOR.CAD_SET_ID                 = ICD.CAD_SET_ID
                 JOIN TB_CAD_UNI_UNIDADE                 UNI
                 ON   UNI.CAD_UNI_ID_UNIDADE           = SETOR.CAD_UNI_ID_UNIDADE
                 JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO       LAT
                 ON   LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                 WHERE
                       (to_char(ICD.ATD_ICD_DATA_CENSO,'MM/yyyy') = to_char(ADD_MONTHS(pATD_ATE_DT_ATENDIMENTO_FIM,-1),'MM/yyyy'))
                 AND   (pCAD_UNI_ID_UNIDADE IS NULL OR UNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                 AND   (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
                 AND   (pCAD_SET_ID  IS NULL OR SETOR.CAD_SET_ID = pCAD_SET_ID)
                  GROUP BY
                          ICD.ATD_ICD_DATA_CENSO,
                          SETOR.CAD_SET_DS_SETOR,
                          LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                          UNI.CAD_UNI_DS_UNIDADE,
                           SETOR.CAD_SET_ID,
                           LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                           UNI.CAD_UNI_ID_UNIDADE,
                          ICD.ATD_ICD_QT_INTERNACAO,
                          ICD.ATD_IAC_QT_PACIENTE_DIA,
                          ICD.ATD_ICD_QT_SAIDA,
                          ICD.ATD_IAC_QT_SAIDA_OBITO_MAIS48,
                          ICD.ATD_IAC_QT_SAIDA_OBITO_MENOS48
  )         CENSO
  ON        CENSO.CAD_SET_ID                   = SETOR.CAD_SET_ID
  AND       CENSO.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
  AND       CENSO.CAD_UNI_ID_UNIDADE           = UNI.CAD_UNI_ID_UNIDADE
  WHERE     LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO   = 'INTERNADO'
  AND       UNI.CAD_UNI_ID_UNIDADE             = pCAD_UNI_ID_UNIDADE
   AND       (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
  AND       (pCAD_SET_ID  IS NULL OR SETOR.CAD_SET_ID = pCAD_SET_ID)
  and       SETOR.CAD_SET_FL_ATIVO_OK          = 'S' 
 --and NVL(CENSO.PCT_OCUPACAO,0) > 0
  group by
 SETOR.CAD_SET_DS_SETOR,
              LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
              UNI.CAD_UNI_DS_UNIDADE,
              to_char(pATD_ATE_DT_ATENDIMENTO_FIM,'MM/yyyy')  ,
              ''  ,
              ''  ,
              NVL(CENSO.LEITOS_DIA,0)                     ,
              NVL(CENSO.LEITOS_MES,0)                     ,
              NVL(CENSO.LEITOS_TOTAL_MES,0)               ,
              NVL(CENSO.PCT_OCUPACAO,0)                   ,
              NVL(CENSO.MEDIA_PERMANENCIA,0)              ,
              NVL(CENSO.ATD_IAC_QT_PACIENTE_DIA,0)        ,
              NVL(CENSO.ATD_ICD_QT_INTERNACAO,0)          ,
              NVL(CENSO.ATD_ICD_QT_SAIDA,0)             
  ORDER BY  1
  ;
  io_cursor := v_cursor;
end PRC_INT_REL_ESTAT_PAC_DIA2;
/
