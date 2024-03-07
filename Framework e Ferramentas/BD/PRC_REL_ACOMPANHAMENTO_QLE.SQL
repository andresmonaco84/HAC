CREATE OR REPLACE PROCEDURE PRC_REL_ACOMPANHAMENTO_QLE
( pCAD_SET_ID             IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
  pCAD_HQL_DT_HR_INICIO   IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_HQL_DT_HR_INICIO%TYPE DEFAULT NULL,
  pCAD_HQL_DT_HR_FIM      IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_HQL_DT_HR_FIM%TYPE DEFAULT NULL,
  pCAD_SQL_CD_SIT_QUARTO_LEITO  IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_SQL_CD_SIT_QUARTO_LEITO%TYPE DEFAULT NULL
)
  IS
  nCount      INTEGER;
  nCountQLE   INTEGER;
  sQuartoLeito VARCHAR2(10);

  CURSOR CURSOR_QUARTOLEITO IS
    SELECT SETOR.CAD_SET_DS_SETOR SETOR,
           QLE.CAD_QLE_NR_QUARTO QUARTO,
           QLE.CAD_QLE_NR_LEITO LEITO,
           QLE.CAD_QLE_TP_QUARTO_LEITO TIPOQUARTOLEITO,
           SIT.CAD_SQL_DS_SIT_QUARTO_LEITO SITUACAO,
           HIS.CAD_HQL_DT_HR_INICIO INICIO,
           HIS.CAD_HQL_DT_HR_FIM FIM,
           TRUNC(24 * (HIS.CAD_HQL_DT_HR_FIM - HIS.CAD_HQL_DT_HR_INICIO)) || ':' || DECODE(LENGTH(ROUND(MOD(MOD(HIS.CAD_HQL_DT_HR_FIM - HIS.CAD_HQL_DT_HR_INICIO, 1) * 24, 1) * 60)), 1,
           LPAD(ROUND(MOD(MOD(HIS.CAD_HQL_DT_HR_FIM - HIS.CAD_HQL_DT_HR_INICIO, 1) * 24, 1) * 60), 2, 0),
           ROUND(MOD(MOD(HIS.CAD_HQL_DT_HR_FIM - HIS.CAD_HQL_DT_HR_INICIO, 1) * 24, 1) * 60)) HORAS,
           HIS.CAD_HQL_DS_OBSERVACAO OBSERVACAO

      FROM TB_CAD_HQL_HIS_SIT_QTO_LEITO HIS,
           TB_CAD_SQL_SIT_QUARTO_LEITO  SIT,
           TB_CAD_QLE_QUARTO_LEITO      QLE,
           TB_CAD_SET_SETOR             SETOR

     WHERE SIT.CAD_SQL_CD_SIT_QUARTO_LEITO = HIS.CAD_SQL_CD_SIT_QUARTO_LEITO
       AND (HIS.CAD_HQL_DT_HR_INICIO >= TO_DATE(TO_CHAR(pCAD_HQL_DT_HR_INICIO, 'dd/MM/yyyy') || ' 00:00:00', 'dd/MM/yyyy HH24:mi:ss')
       AND  HIS.CAD_HQL_DT_HR_INICIO <= TO_DATE(TO_CHAR(pCAD_HQL_DT_HR_FIM, 'dd/MM/yyyy') || ' 23:59:59', 'dd/MM/yyyy HH24:mi:ss'))
       AND (pCAD_SET_ID IS NULL OR QLE.CAD_SET_ID = pCAD_SET_ID) --19
       and (pCAD_SQL_CD_SIT_QUARTO_LEITO IS NULL OR HIS.CAD_SQL_CD_SIT_QUARTO_LEITO = pCAD_SQL_CD_SIT_QUARTO_LEITO)
       AND QLE.CAD_QLE_ID = HIS.CAD_QLE_ID
       AND QLE.CAD_SET_ID = SETOR.CAD_SET_ID
       AND SETOR.CAD_UNI_ID_UNIDADE = 244
       AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29
       -- AND QLE.CAD_QLE_ID = 350
       AND HIS.CAD_HQL_DT_HR_FIM IS NOT NULL
     ORDER BY 1, 2, 3, 4, 6, 7;

     BEGIN
           nCount := 0;
           sQuartoLeito := NULL;

           DELETE FROM TB_CAD_HQL_HIST_REL;
           COMMIT;

           FOR X IN CURSOR_QUARTOLEITO LOOP
                IF ((X.SITUACAO = 'OCUPADO') OR (sQuartoLeito != X.QUARTO||' '||X.LEITO)) THEN
                   nCount := nCount + 1;
                END IF;
                INSERT INTO TB_CAD_HQL_HIST_REL
                (           CAD_SET_DS_SETOR,
                            CAD_QLE_NR_QUARTO,
                            CAD_QLE_NR_LEITO,
                            CAD_SQL_CD_SIT_QUARTO_LEITO,
                            CAD_HQL_DT_HR_INICIO,
                            CAD_HQL_DT_HR_FIM,
                            CAD_HQL_HR,
                            CAD_HQL_DS_OBSERVACAO,
                            CAD_QLE_TP_QUARTO_LEITO,
                            CAD_HQL_CONT)
                VALUES
                (
                            X.SETOR,
                            X.QUARTO,
                            X.LEITO,
                            X.SITUACAO,
                            X.INICIO,
                            X.FIM,
                            X.HORAS,
                            X.OBSERVACAO,
                            X.TIPOQUARTOLEITO,
                            nCount
                 );
                sQuartoLeito := X.QUARTO||' '|| X.LEITO;
           END LOOP;
           COMMIT;
    EXCEPTION
    WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(SQLCODE, SQLERRM);
         ROLLBACK;
END PRC_REL_ACOMPANHAMENTO_QLE;
