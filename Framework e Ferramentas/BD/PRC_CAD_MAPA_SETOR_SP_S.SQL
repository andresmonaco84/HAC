CREATE OR REPLACE PROCEDURE "PRC_CAD_MAPA_SETOR_SP_S"
(
  pCAD_PLA_ID_PLANO             IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.CAD_PLA_ID_PLANO%TYPE,
  pCAD_CNV_ID_CONVENIO          IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%TYPE,
  pCAD_UNI_ID_UNIDADE           IN TB_ASS_UTA_UNID_TPACOMOD.CAD_UNI_ID_UNIDADE%TYPE,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_SET_SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
  pCAD_PES_TP_SEXO              IN TB_CAD_PES_PESSOA.CAD_PES_TP_SEXO%TYPE,
  pRN                           IN VARCHAR2,
  pTIS_TAC_CD_TIPO_ACOM_PROV    IN TB_CAD_QLE_QUARTO_LEITO.TIS_TAC_CD_TIPO_ACOM_PROV%TYPE,
  io_cursor                     OUT PKG_CURSOR.t_cursor
)
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MAPA_SETOR_SP_S
  *
  *    Data Criacao:   data da  cria??o    Por: Nome do Analista
  *    Funcao: Descri??o da funcionalidade da Stored Procedure
  *
  *    Alteracao: 18/07/2014 Desconsiderar quartos/leitos desativados por reestruturacao
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  VARCHAR2(20000);
  V_SELECT VARCHAR2(20000);
  X_WHERE  VARCHAR2(1000);
begin
  IF (pRN = 'N') THEN
    X_WHERE := ' AND QLE.CAD_QLE_TP_SEXO IN ('||CHR(39)||pCAD_PES_TP_SEXO||CHR(39)||', '||CHR(39)||'A'||CHR(39)||') ';
  ELSE
    X_WHERE := NULL;
  END IF;
  V_WHERE := ' QLE.CAD_SQL_CD_SIT_QUARTO_LEITO IN (1,2,3,4,5,6,7,8) ';
  V_SELECT := 'SELECT DISTINCT CTP.CAD_PLA_ID_PLANO,
                      CNU.CAD_CNV_ID_CONVENIO,
                      SETOR.CAD_SET_ID,
                      QLE.CAD_QLE_NR_QUARTO,
                      QLE.CAD_QLE_NR_LEITO,
                      QLE.CAD_QLE_TP_SEXO,
                      QLE.CAD_QLE_ID,
                      CASE
                      WHEN SETOR.CAD_SET_ID IN (140,141) AND '||CHR(39)|| pRN ||CHR(39)||' = '||CHR(39)||'S'||CHR(39)||' AND
                           ' || V_WHERE || '
                      THEN
                       1
                      WHEN QLE.CAD_QLE_TP_SEXO = '||CHR(39)||'A'||CHR(39)||' AND
                          (QLE.CAD_QLE_FL_CONS_SEX_PRIM_PAC = '||CHR(39)||'N'||CHR(39)||' OR
                           QLE.CAD_QLE_FL_CONS_SEX_PRIM_PAC IS NULL) AND
                           QLE.TIS_TAC_CD_TIPO_ACOMODACAO NOT IN (3,51,52,53,21) AND
                           ( '||CHR(39)|| pRN ||CHR(39)||' = '||CHR(39)||'N'||CHR(39)||' OR SETOR.CAD_SET_ID NOT IN (140,141) ) AND
                           ' || V_WHERE || ' THEN
                       1
                      WHEN QLE.CAD_QLE_TP_SEXO = '||CHR(39)||'A'||CHR(39)||' AND
                           QLE.CAD_QLE_FL_CONS_SEX_PRIM_PAC = '||CHR(39)||'S'||CHR(39)||' AND
                           QLE.TIS_TAC_CD_TIPO_ACOMODACAO NOT IN (3,51,52,53,21) AND
                           ( '||CHR(39)|| pRN ||CHR(39)||' = '||CHR(39)||'N'||CHR(39)||' OR SETOR.CAD_SET_ID NOT IN (140,141) ) AND
                           ' || V_WHERE || ' AND
                           PACIENTE.CAD_PES_TP_SEXO = '||CHR(39)||pCAD_PES_TP_SEXO||CHR(39)||' THEN
                       1
                      WHEN QLE.CAD_QLE_TP_SEXO = '||CHR(39)||'A'||CHR(39)||' AND
                           QLE.CAD_QLE_FL_CONS_SEX_PRIM_PAC = '||CHR(39)||'S'||CHR(39)||' AND
                           QLE.TIS_TAC_CD_TIPO_ACOMODACAO NOT IN (3,51,52,53,21) AND
                           ( '||CHR(39)|| pRN ||CHR(39)||' = '||CHR(39)||'N'||CHR(39)||' OR SETOR.CAD_SET_ID NOT IN (140,141) ) AND
                           ' || V_WHERE || ' AND
                           PACIENTE.CAD_PES_TP_SEXO != '||CHR(39)||pCAD_PES_TP_SEXO||CHR(39)||' THEN
                       0
                      WHEN PACIENTE.CAD_PES_TP_SEXO IS NULL AND QLE.CAD_QLE_TP_SEXO = '||CHR(39)||'A'||CHR(39)||' AND
                           QLE.TIS_TAC_CD_TIPO_ACOMODACAO NOT IN (3,51,52,53,21) AND
                           ( '||CHR(39)|| pRN ||CHR(39)||' = '||CHR(39)||'N'||CHR(39)||' OR SETOR.CAD_SET_ID NOT IN (140,141) ) AND
                           ' || V_WHERE|| ' THEN
                       1
                      WHEN QLE.CAD_QLE_TP_SEXO = '||CHR(39)||pCAD_PES_TP_SEXO||CHR(39)||' AND
                           QLE.TIS_TAC_CD_TIPO_ACOMODACAO NOT IN (3,51,52,53,21) AND
                           ( '||CHR(39)|| pRN ||CHR(39)||' = '||CHR(39)||'N'||CHR(39)||' OR SETOR.CAD_SET_ID NOT IN (140,141) ) AND
                           ' || V_WHERE || ' THEN
                       1
                      WHEN QLE.TIS_TAC_CD_TIPO_ACOMODACAO IN (3,51,52,53,21) AND
                        ( '||CHR(39)|| pRN ||CHR(39)||' = '||CHR(39)||'N'||CHR(39)||' OR SETOR.CAD_SET_ID NOT IN (140,141) ) AND
                           ' || V_WHERE || ' THEN
                       1
                      ELSE
                       0
                      END PERMITE,
                      SETOR.CAD_SET_DS_SETOR,
                      QLE.CAD_SQL_CD_SIT_QUARTO_LEITO SITUACAOLEITO,
                      PACIENTE.CAD_PAC_ID_PACIENTE,
                      PACIENTE.CAD_PES_NM_PESSOA,
                      QLE.CAD_QLE_TP_SEXO SEXOQUARTO,
                      QLE.TIS_TAC_CD_TIPO_ACOMODACAO,
                      QLE.TIS_TAC_CD_TIPO_ACOM_PROV,
                      PACIENTE.CAD_PES_TP_SEXO,
                      PACIENTE.ATD_ATE_ID,
                      QLE.CAD_QLE_TP_QUARTO_LEITO
                FROM TB_CAD_QLE_QUARTO_LEITO QLE,
                     TB_ASS_CUT_CONV_UNI_TPACOMOD CUT,
                     TB_ASS_CTP_CNV_UN_TPACOM_PLA CTP,
                     TB_ASS_UTA_UNID_TPACOMOD UTA,
                     TB_ASS_CNU_CONVENIO_UNIDADE CNU,
                     TB_CAD_SET_SETOR SETOR,
                     (SELECT QLE.CAD_QLE_NR_QUARTO, PES.CAD_PES_TP_SEXO SEXO, QLE.CAD_QLE_NR_LEITO
                        FROM TB_ATD_IML_INT_MOV_LEITO     IML,
                             TB_CAD_PAC_PACIENTE          PAC,
                             TB_CAD_PES_PESSOA            PES,
                             TB_CAD_QLE_QUARTO_LEITO      QLE,
                             TB_ASS_CUT_CONV_UNI_TPACOMOD CUT,
                             TB_ASS_CTP_CNV_UN_TPACOM_PLA CTP,
                             TB_ASS_UTA_UNID_TPACOMOD     UTA,
                             TB_ASS_CNU_CONVENIO_UNIDADE  CNU,
                             TB_CAD_SET_SETOR             SETOR
                         WHERE IML.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
                           AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
                           AND IML.CAD_CAD_QLE_ID = QLE.CAD_QLE_ID
                           AND CUT.ASS_CUT_ID = CTP.ASS_CUT_ID
                           AND UTA.ASS_UTA_ID_UNID_TPACOMOD = CUT.ASS_UTA_ID_UNID_TPACOMOD
                           AND QLE.TIS_TAC_CD_TIPO_ACOM_PROV = UTA.TIS_TAC_CD_TIPO_ACOMODACAO
                           AND CTP.CAD_PLA_ID_PLANO = '||pCAD_PLA_ID_PLANO||'
                           AND CTP.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
                           AND (TRUNC(CTP.ASS_CTP_DT_INI_VIGENCIA) <= TRUNC(SYSDATE) AND
                               (CTP.ASS_CTP_DT_FIM_VIGENCIA IS NULL OR
                               TRUNC(CTP.ASS_CTP_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE)))
                           AND CUT.ASS_CNU_ID = CNU.ASS_CNU_ID
                           AND (TRUNC(CNU.ASS_CNU_DT_INI_VIGENCIA) <= TRUNC(SYSDATE) AND
                               (CNU.ASS_CNU_DT_FIM_VIGENCIA IS NULL OR
                               TRUNC(CNU.ASS_CNU_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE)))
                           AND (TRUNC(CUT.ASS_CUT_DT_INI_VIGENCIA) <= TRUNC(SYSDATE) AND
                               (CUT.ASS_CUT_DT_FIM_VIGENCIA IS NULL OR
                               TRUNC(CUT.ASS_CUT_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE)))
                           AND CNU.CAD_CNV_ID_CONVENIO = '||pCAD_CNV_ID_CONVENIO||'
                           AND UTA.CAD_UNI_ID_UNIDADE = '||pCAD_UNI_ID_UNIDADE||'
                           AND QLE.CAD_SET_ID = SETOR.CAD_SET_ID
                           AND SETOR.CAD_UNI_ID_UNIDADE = UTA.CAD_UNI_ID_UNIDADE
                           AND UTA.ASS_UTA_FL_ATIVO_OK = '||CHR(39)||'S'||CHR(39)||'
                           AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = '||pCAD_LAT_ID_LOCAL_ATENDIMENTO||'
                           AND QLE.CAD_QLE_TP_SEXO = '||CHR(39)||'A'||CHR(39)||'
                           AND SETOR.CAD_SET_FL_PERMITEINTERN_OK = '||CHR(39)||'S'||CHR(39)||'
                           AND SETOR.CAD_SET_FL_ATIVO_OK = '||CHR(39)||'S'||CHR(39)||'
                           AND IML.ATD_IML_DT_SAIDA IS NULL
                           AND IML.ATD_IML_HR_SAIDA IS NULL
                           AND IML.ATD_IML_FL_STATUS = '||CHR(39)||'A'||CHR(39)||') NEXISTE,
                       (SELECT IML.CAD_CAD_QLE_ID, IML.CAD_PAC_ID_PACIENTE, PES.CAD_PES_NM_PESSOA, PES.CAD_PES_TP_SEXO,
                               IML.ATD_ATE_ID
                        FROM TB_ATD_IML_INT_MOV_LEITO IML,
                             TB_CAD_QLE_QUARTO_LEITO QLE,
                             TB_CAD_SET_SETOR SETOR,
                             TB_CAD_PAC_PACIENTE PAC,
                             TB_CAD_PES_PESSOA PES
                         WHERE IML.ATD_IML_DT_SAIDA IS NULL
                           AND IML.ATD_IML_HR_SAIDA IS NULL
                           AND IML.CAD_CAD_QLE_ID = QLE.CAD_QLE_ID
                           AND SETOR.CAD_SET_ID = QLE.CAD_SET_ID
                           AND IML.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
                           AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
                           AND SETOR.CAD_SET_FL_PERMITEINTERN_OK = '||CHR(39)||'S'||CHR(39)||'
                           AND SETOR.CAD_SET_FL_ATIVO_OK = '||CHR(39)||'S'||CHR(39)||'
                           AND SETOR.CAD_UNI_ID_UNIDADE = '||pCAD_UNI_ID_UNIDADE||'
                           AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = '||pCAD_LAT_ID_LOCAL_ATENDIMENTO||'
                           AND IML.ATD_IML_FL_STATUS = '||CHR(39)||'A'||CHR(39)||') paciente
                 WHERE (QLE.TIS_TAC_CD_TIPO_ACOM_PROV = '||pTIS_TAC_CD_TIPO_ACOM_PROV||' OR QLE.TIS_TAC_CD_TIPO_ACOM_PROV in (51, 52, 53, 21))
                 AND  CUT.ASS_CUT_ID = CTP.ASS_CUT_ID
                 AND (TRUNC(CTP.ASS_CTP_DT_INI_VIGENCIA) <= TRUNC(SYSDATE) AND
                     (CTP.ASS_CTP_DT_FIM_VIGENCIA IS NULL OR
                     TRUNC(CTP.ASS_CTP_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE)))
                 AND UTA.ASS_UTA_ID_UNID_TPACOMOD = CUT.ASS_UTA_ID_UNID_TPACOMOD
                 AND QLE.TIS_TAC_CD_TIPO_ACOM_PROV = UTA.TIS_TAC_CD_TIPO_ACOMODACAO
                 AND CTP.CAD_PLA_ID_PLANO = '||pCAD_PLA_ID_PLANO||'
                 AND CUT.ASS_CNU_ID = CNU.ASS_CNU_ID
                 AND (TRUNC(CNU.ASS_CNU_DT_INI_VIGENCIA) <= TRUNC(SYSDATE) AND
                     (CNU.ASS_CNU_DT_FIM_VIGENCIA IS NULL OR
                     TRUNC(CNU.ASS_CNU_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE)))
                 AND (TRUNC(CUT.ASS_CUT_DT_INI_VIGENCIA) <= TRUNC(SYSDATE) AND
                     (CUT.ASS_CUT_DT_FIM_VIGENCIA IS NULL OR
                     TRUNC(CUT.ASS_CUT_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE)))
                 AND CNU.CAD_CNV_ID_CONVENIO = '||pCAD_CNV_ID_CONVENIO||'
                 AND UTA.CAD_UNI_ID_UNIDADE = '||pCAD_UNI_ID_UNIDADE||'
                 AND QLE.CAD_SET_ID = SETOR.CAD_SET_ID
                 AND SETOR.CAD_UNI_ID_UNIDADE = UTA.CAD_UNI_ID_UNIDADE
                 AND UTA.ASS_UTA_FL_ATIVO_OK = '||CHR(39)||'S'||CHR(39)||'
                 AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = '||pCAD_LAT_ID_LOCAL_ATENDIMENTO||'
                 AND QLE.CAD_QLE_NR_QUARTO = NEXISTE.CAD_QLE_NR_QUARTO(+)
                 AND QLE.CAD_QLE_NR_LEITO = NEXISTE.CAD_QLE_NR_LEITO(+)
                 ' || X_WHERE || '
                 AND SETOR.CAD_SET_FL_PERMITEINTERN_OK = '||CHR(39)||'S'||CHR(39)||'
                 AND SETOR.CAD_SET_FL_ATIVO_OK = '||CHR(39)||'S'||CHR(39)||'
                 AND PACIENTE.CAD_CAD_QLE_ID(+) = QLE.CAD_QLE_ID
                 AND QLE.CAD_SQL_CD_SIT_QUARTO_LEITO != 5 --DESCONSIDERANDO LEITOS DESATIVADOS POR REESTRUTURACAO
                 AND NOT EXISTS (SELECT QLE.CAD_QLE_ID
                                   FROM TB_CAD_QLE_QUARTO_LEITO QLE1
                                  WHERE QLE.CAD_QLE_ID = QLE1.CAD_QLE_ID
                                    AND QLE1.CAD_QLE_TP_QUARTO_LEITO = '||CHR(39)||'E'||CHR(39)||'
                                    AND QLE1.CAD_SQL_CD_SIT_QUARTO_LEITO IN ( 1))
                 ORDER BY 4, 5';
  OPEN v_cursor FOR
    V_SELECT;
  io_cursor := v_cursor;
end PRC_CAD_MAPA_SETOR_SP_S;
