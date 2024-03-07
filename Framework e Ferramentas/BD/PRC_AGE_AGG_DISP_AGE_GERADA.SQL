CREATE OR REPLACE PROCEDURE "PRC_AGE_AGG_DISP_AGE_GERADA"
(pCAD_UNI_ID_UNIDADE           IN TB_AGE_ESM_ESCALA_MEDICA.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_AGE_ESM_ESCALA_MEDICA.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
pTIS_CBO_CD_CBOS              IN TB_AGE_ESM_ESCALA_MEDICA.TIS_CBO_CD_CBOS%type DEFAULT NULL,
pAGE_PEE_ID                   IN TB_AGE_ESM_ESCALA_MEDICA.AGE_PEE_ID%type DEFAULT NULL,
pCAD_PRO_ID_PROFISSIONAL      IN TB_AGE_ESM_ESCALA_MEDICA.CAD_PRO_ID_PROFISSIONAL%type DEFAULT NULL,
pAGE_AGG_TP_HORARIO           IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_TP_HORARIO%type DEFAULT NULL,
pCAD_PLA_ID_PLANO             IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type,
pAGE_ESM_NR_DIA_SEMANA        IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_NR_DIA_SEMANA%TYPE DEFAULT NULL,
pAGE_AGG_DT_AGENDA            IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_DT_AGENDA%TYPE DEFAULT NULL,
pCAD_UNI_ID_UNIDADE_ORIGEM    IN TB_AGE_ESM_ESCALA_MEDICA.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
pFLAGINSTGER                  VARCHAR2 DEFAULT NULL,
pDATA_FIM_CARENCIA            IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_AGENDA%TYPE DEFAULT NULL,
     io_cursor                     OUT PKG_CURSOR.t_cursor
   --   vteste OUT LONG
) is
  /********************************************************************
  *    Procedure: PRC_AGE_AGG_DISP_AGE_GERADA
  *
  *    Data Alteracao: 19/12/2011            Por: Pedro
  *    Alterac?o: add pCAD_UNI_ID_UNIDADE_ORIGEM e pFLAGINSTGER
  *
  *********************************************************************/
  v_cursor   PKG_CURSOR.t_cursor;
  V_WHEREESF VARCHAR2(2000);
  V_WHERE    VARCHAR2(2000);
  V_SELECT   VARCHAR2(32000);
  V_DATA_INICIO DATE;
begin
  V_WHERE    := NULL;
  V_WHEREESF := NULL;
  IF pTIS_CBO_CD_CBOS IS NOT NULL THEN
    V_WHEREESF := V_WHEREESF || ' AND ESM.TIS_CBO_CD_CBOS = ' || CHR(39) ||
                  pTIS_CBO_CD_CBOS || CHR(39);
    V_WHERE    := V_WHEREESF;
  END IF;
  IF pCAD_PRO_ID_PROFISSIONAL IS NOT NULL THEN
    V_WHEREESF := V_WHEREESF || ' AND ESM.CAD_PRO_ID_PROFISSIONAL = ' ||
                  pCAD_PRO_ID_PROFISSIONAL;
    V_WHERE    := V_WHEREESF;
  END IF;
  IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND ESM.CAD_UNI_ID_UNIDADE = ' ||
               pCAD_UNI_ID_UNIDADE;
  END IF;
  IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' ||
               pCAD_LAT_ID_LOCAL_ATENDIMENTO;
  END IF;
  IF pAGE_PEE_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND ESM.AGE_PEE_ID = ' || pAGE_PEE_ID;
  END IF;
  IF pAGE_AGG_TP_HORARIO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND AGG.AGE_AGG_TP_HORARIO = ' ||
               pAGE_AGG_TP_HORARIO;
  END IF;
  IF pAGE_ESM_NR_DIA_SEMANA IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND ESM.AGE_ESM_NR_DIA_SEMANA = ' ||
               pAGE_ESM_NR_DIA_SEMANA;
  END IF;
  IF pAGE_AGG_DT_AGENDA IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND AGG.AGE_AGG_DT_AGENDA = ' || CHR(39) ||
               pAGE_AGG_DT_AGENDA || CHR(39);
  END IF;
  V_DATA_INICIO:= TRUNC(SYSDATE+1);
  IF pDATA_FIM_CARENCIA IS NOT NULL AND pDATA_FIM_CARENCIA > TRUNC(SYSDATE+1) THEN 
    V_DATA_INICIO:= pDATA_FIM_CARENCIA;
  END IF;
  V_SELECT := 'SELECT * FROM
           (SELECT
                   AGG.AGE_AGG_ID,
                   AGG.AGE_ESM_ID,
                   AGG.AGE_ESF_ID,
                   AGG.AGE_AGG_DT_AGENDA,
                   AGG.AGE_AGG_HR_AGENDA,
                   AGG.AGE_AGG_TP_HORARIO,
                   AGG.SEG_USU_ID_USUARIO,
                   AGG.AGE_AGG_FL_STATUS_HORARIO,
                   AGG.AGE_AGG_DT_ULTIMA_ATUALIZACAO,
                   AGG.AGE_AGG_DS_BLOQUEIO,
                   UNI.CAD_UNI_DS_UNIDADE,
                   UNI.CAD_UNI_ID_UNIDADE,
                   MUN.AUX_MUN_CD_IBGE,
                   MUN.AUX_MUN_NM_MUNICIPIO,
                   MUN_ORIGEM.AUX_MUN_CD_IBGE AUX_MUN_CD_IBGE_ORIGEM,
                   MUN_ORIGEM.AUX_MUN_NM_MUNICIPIO AUX_MUN_NM_MUNICIPIO_ORIGEM
            FROM   TB_AGE_AGG_AGENDA_GERADA AGG,
                   TB_AGE_ESM_ESCALA_MEDICA ESM,
                   TB_ASS_CLP_CNV_UND_LOC_PLANO CLP,
                   TB_ASS_CUL_CONV_UNI_LOCATEND CUL,
                   TB_CAD_PLA_PLANO PLA,
                   TB_ASS_CNU_CONVENIO_UNIDADE CNU,
                   TB_CAD_UNI_UNIDADE UNI,
                     (SELECT MUN1.AUX_MUN_CD_IBGE,MUN1.AUX_MUN_SG_UF,MUN1.AUX_MUN_NM_MUNICIPIO,PES1.CAD_PES_ID_PESSOA,UNI1.CAD_UNI_ID_UNIDADE,
                           UNI1.CAD_UNI_DS_UNIDADE
                    FROM TB_CAD_PES_PESSOA PES1,
                         TB_CAD_END_ENDERECO ENDD1,
                         TB_AUX_MUN_MUNICIPIO MUN1,
                         TB_CAD_UNI_UNIDADE UNI1
                    WHERE MUN1.AUX_MUN_SG_UF = '||CHR(39)||'SP'||CHR(39)||'
                    AND PES1.CAD_PES_ID_PESSOA = UNI1.CAD_PES_ID_PESSOA
                    AND ENDD1.CAD_PES_ID_PESSOA = PES1.CAD_PES_ID_PESSOA
                    AND MUN1.AUX_MUN_CD_IBGE = ENDD1.AUX_MUN_CD_IBGE
                    AND ENDD1.AUX_TTE_CD_TP_TEL_END = 2 --EMPRESA              
                    ) MUN,
                    (SELECT MUN1.AUX_MUN_CD_IBGE,MUN1.AUX_MUN_SG_UF,MUN1.AUX_MUN_NM_MUNICIPIO,PES1.CAD_PES_ID_PESSOA,UNI1.CAD_UNI_ID_UNIDADE,
                            UNI1.CAD_UNI_DS_UNIDADE
                    FROM TB_CAD_PES_PESSOA PES1,
                         TB_CAD_END_ENDERECO ENDD1,
                         TB_AUX_MUN_MUNICIPIO MUN1,
                         TB_CAD_UNI_UNIDADE UNI1
                    WHERE MUN1.AUX_MUN_SG_UF = '||CHR(39)||'SP'||CHR(39)||'
                    AND PES1.CAD_PES_ID_PESSOA = UNI1.CAD_PES_ID_PESSOA
                    AND ENDD1.CAD_PES_ID_PESSOA = PES1.CAD_PES_ID_PESSOA
                    AND MUN1.AUX_MUN_CD_IBGE = ENDD1.AUX_MUN_CD_IBGE
                    AND ENDD1.AUX_TTE_CD_TP_TEL_END = 2 --EMPRESA
                    AND UNI1.CAD_UNI_ID_UNIDADE = ' ||chr(39)|| pCAD_UNI_ID_UNIDADE_ORIGEM ||chr(39)|| '
                    ) MUN_ORIGEM,
                   (SELECT ESF.AGE_ESM_ID, ESF.AGE_ESF_FL_SUBSTITUTO_OK, ESF.AGE_ESF_ID
                    FROM   TB_AGE_AGG_AGENDA_GERADA AGG,
                           TB_AGE_ESF_ESCALA_FALTAS ESF,
                           TB_AGE_ESM_ESCALA_MEDICA ESM,
                           TB_ASS_CLP_CNV_UND_LOC_PLANO CLP,
                           TB_ASS_CUL_CONV_UNI_LOCATEND CUL,
                           TB_CAD_PLA_PLANO PLA,
                           TB_ASS_CNU_CONVENIO_UNIDADE CNU
                    WHERE  AGG.AGE_ESM_ID = ESM.AGE_ESM_ID
                    AND    ESF.age_esm_id = AGG.age_esm_id
                    AND(((TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) <  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND AGG.AGE_AGG_DT_AGENDA >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' )
                    OR (TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND AGG.AGE_AGG_DT_AGENDA BETWEEN  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' 
                   AND ADD_MONTHS( ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' , 3)))
                   -- AND    AGG.AGE_AGG_HR_AGENDA  > TO_NUMBER(  TO_CHAR(SYSDATE+1,' ||  chr(39) || 'HH24MI' || chr(39) || '))
                     )
                    AND    TRUNC(AGG.AGE_AGG_DT_AGENDA) BETWEEN TRUNC(ESF.AGE_ESF_DT_INI_FALTA) AND TRUNC(ESF.AGE_ESF_DT_FIM_FALTA)
                    AND    ESF.AGE_ESM_ID = ESM.AGE_ESM_ID
                    AND ((TRUNC(AGG.AGE_AGG_DT_AGENDA) BETWEEN  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND
                       TRUNC(ESM.AGE_ESM_DT_FIM_ESCALA)) OR
                       (ESM.AGE_ESM_DT_FIM_ESCALA IS NULL))
                   AND AGG.AGE_AGG_FL_STATUS_HORARIO = 1
                   AND PLA.CAD_PLA_ID_PLANO = ' ||            pCAD_PLA_ID_PLANO || '
                   AND CLP.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
                   AND CLP.ASS_CUL_ID = CUL.ASS_CUL_ID
                   AND ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO =    CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO
                   AND CUL.ASS_CNU_ID = CNU.ASS_CNU_ID
                   AND ESM.CAD_UNI_ID_UNIDADE = CNU.CAD_UNI_ID_UNIDADE
                   AND CNU.CAD_CNV_ID_CONVENIO = PLA.CAD_CNV_ID_CONVENIO
                   AND (ESM.AGE_ESM_DT_FIM_ESCALA IS NULL OR
                       TRUNC(ESM.AGE_ESM_DT_FIM_ESCALA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' )
                   AND((TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) <  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND AGG.AGE_AGG_DT_AGENDA >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' )
                   OR (TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND AGG.AGE_AGG_DT_AGENDA BETWEEN  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' 
                   AND ADD_MONTHS( ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' , 3)))
                   AND (TRUNC(CLP.ASS_CLP_DT_INI_VIGENCIA) <=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND  (CLP.ASS_CLP_DT_FIM_VIGENCIA IS NULL OR
                       TRUNC(CLP.ASS_CLP_DT_FIM_VIGENCIA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' ))
                   AND (TRUNC(CUL.ASS_CUL_DT_INI_VIGENCIA) <=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND  (CUL.ASS_CUL_DT_FIM_VIGENCIA IS NULL OR
                       TRUNC(CUL.ASS_CUL_DT_FIM_VIGENCIA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' ))
                   AND (TRUNC(CNU.ASS_CNU_DT_INI_VIGENCIA) <=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND  (CNU.ASS_CNU_DT_FIM_VIGENCIA IS NULL OR
                       TRUNC(CNU.ASS_CNU_DT_FIM_VIGENCIA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' )) ' ||
              V_WHEREESF || ') ESF
            WHERE  ESM.AGE_ESM_FL_SITUACAO = ' || chr(39) || 'A' ||
              chr(39) || '
            AND    AGG.AGE_ESM_ID = ESM.AGE_ESM_ID
            AND    ((TRUNC(AGG.AGE_AGG_DT_AGENDA) BETWEEN  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND TRUNC(ESM.AGE_ESM_DT_FIM_ESCALA))
            OR     (ESM.AGE_ESM_DT_FIM_ESCALA IS NULL))
            AND    AGG.AGE_AGG_FL_STATUS_HORARIO = 1
            AND    ESM.CAD_UNI_ID_UNIDADE = CNU.CAD_UNI_ID_UNIDADE
            AND    ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO
            AND    AGG.AGE_ESM_ID                   = ESF.AGE_ESM_ID(+)
            AND    AGG.AGE_ESF_ID                   = ESF.AGE_ESF_ID(+)
            AND   (ESM.AGE_ESM_DT_FIM_ESCALA IS NULL OR TRUNC(ESM.AGE_ESM_DT_FIM_ESCALA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' )
            AND    (ESF.AGE_ESF_FL_SUBSTITUTO_OK = ' ||  chr(39) || 'S' || chr(39) || '
             OR     ESF.AGE_ESF_FL_SUBSTITUTO_OK IS NULL)
           AND((TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) <  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND AGG.AGE_AGG_DT_AGENDA >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' )
           OR (TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND AGG.AGE_AGG_DT_AGENDA BETWEEN  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' 
            AND ADD_MONTHS( ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' , 3)))
            AND   CLP.ASS_CUL_ID = CUL.ASS_CUL_ID
            AND   CLP.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
            AND   CUL.ASS_CNU_ID = CNU.ASS_CNU_ID
            AND   CNU.CAD_CNV_ID_CONVENIO = PLA.CAD_CNV_ID_CONVENIO
            AND   ESM.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
            AND   UNI.CAD_UNI_ID_UNIDADE = MUN.CAD_UNI_ID_UNIDADE (+)
             AND   (('||CHR(39)|| pFLAGINSTGER ||CHR(39)||' = '||CHR(39)||'S'||CHR(39)||' and 1=1)     --se nao vem nulo mostra inst ger            
                  OR (ESM.CAD_UNI_ID_UNIDADE != 381)
                  )
            AND   PLA.CAD_PLA_ID_PLANO = ' ||   pCAD_PLA_ID_PLANO || '
            AND   (
                  TRUNC(CLP.ASS_CLP_DT_INI_VIGENCIA) <=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND
                  (CLP.ASS_CLP_DT_FIM_VIGENCIA IS NULL OR TRUNC(CLP.ASS_CLP_DT_FIM_VIGENCIA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' )
                  )
            AND   (
                  TRUNC(CUL.ASS_CUL_DT_INI_VIGENCIA) <=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND
                  (CUL.ASS_CUL_DT_FIM_VIGENCIA IS NULL OR TRUNC(CUL.ASS_CUL_DT_FIM_VIGENCIA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' )
                  )
            AND   (
                  TRUNC(CNU.ASS_CNU_DT_INI_VIGENCIA) <=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| '  AND
                  (CNU.ASS_CNU_DT_FIM_VIGENCIA IS NULL OR TRUNC(CNU.ASS_CNU_DT_FIM_VIGENCIA) >=  ' ||CHR(39)||  V_DATA_INICIO ||CHR(39)|| ' )
                  )
            AND   ((ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO != 28 AND  AGG.AGE_AGG_DT_AGENDA NOT IN 
                  (SELECT FER.CAD_FER_DT_FERIADO FROM TB_CAD_FER_FERIADO FER WHERE FER.CAD_UNI_ID_UNIDADE IS NULL OR FER.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE)
                  ) OR
                  ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = 28)
                  ' || V_WHERE || 'ORDER BY AGG.AGE_AGG_DT_AGENDA, AGG.AGE_AGG_HR_AGENDA)
    WHERE ROWNUM <= 20
   ORDER BY 
                CASE WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3548500'||chr(39)||' THEN   --SANTOS
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3548500'||chr(39)||','||chr(39)||'3548500'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3551009'||chr(39)||' THEN  --SV
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3551009'||chr(39)||','||chr(39)||'3551009'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3541000'||chr(39)||' THEN  --PG
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3541000'||chr(39)||','||chr(39)||'3541000'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3513504'||chr(39)||' THEN  --CB
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3513504'||chr(39)||','||chr(39)||'3513504'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3518701'||chr(39)||' THEN  --GUA
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3518701'||chr(39)||','||chr(39)||'3518701'||chr(39)||')
                END, --1
                CASE WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3548500'||chr(39)||' THEN   --SANTOS
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3551009'||chr(39)||','||chr(39)||'3551009'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3551009'||chr(39)||' THEN  --SV
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3541000'||chr(39)||','||chr(39)||'3541000'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3541000'||chr(39)||' THEN  --PG
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3551009'||chr(39)||','||chr(39)||'3551009'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3513504'||chr(39)||' THEN  --CB
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3551009'||chr(39)||','||chr(39)||'3551009'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3518701'||chr(39)||' THEN  --GUA
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3513504'||chr(39)||','||chr(39)||'3513504'||chr(39)||')
                END  , --2
                CASE WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3548500'||chr(39)||' THEN   --SANTOS
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3518701'||chr(39)||','||chr(39)||'3518701'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3551009'||chr(39)||' THEN  --SV
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3513504'||chr(39)||','||chr(39)||'3513504'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3541000'||chr(39)||' THEN  --PG
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3513504'||chr(39)||','||chr(39)||'3513504'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3513504'||chr(39)||' THEN  --CB
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3541000'||chr(39)||','||chr(39)||'3541000'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3518701'||chr(39)||' THEN  --GUA
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3551009'||chr(39)||','||chr(39)||'3551009'||chr(39)||')
                END  , --3
                CASE WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3548500'||chr(39)||' THEN   --SANTOS
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3513504'||chr(39)||','||chr(39)||'3513504'||chr(39)||')                      
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3551009'||chr(39)||' THEN  --SV
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3518701'||chr(39)||','||chr(39)||'3518701'||chr(39)||')       
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3541000'||chr(39)||' THEN  --PG
                     DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3518701'||chr(39)||','||chr(39)||'3518701'||chr(39)||')       
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3513504'||chr(39)||' THEN  --CB
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3518701'||chr(39)||','||chr(39)||'3518701'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3518701'||chr(39)||' THEN  --GUA
                     DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3541000'||chr(39)||','||chr(39)||'3541000'||chr(39)||')
                END  , --4
                CASE WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3548500'||chr(39)||' THEN   --SANTOS                     
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3541000'||chr(39)||','||chr(39)||'3541000'||chr(39)||')   
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3551009'||chr(39)||' THEN  --SV         
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3548500'||chr(39)||','||chr(39)||'3548500'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3541000'||chr(39)||' THEN  --PG
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3548500'||chr(39)||','||chr(39)||'3548500'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3513504'||chr(39)||' THEN  --CB
                  DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3548500'||chr(39)||','||chr(39)||'3548500'||chr(39)||')
                  WHEN AUX_MUN_CD_IBGE_ORIGEM = '||chr(39)||'3518701'||chr(39)||' THEN  --GUA
                      DECODE(AUX_MUN_CD_IBGE ,'||chr(39)||'3548500'||chr(39)||','||chr(39)||'3548500'||chr(39)||')
                END         --5';
  /*  ORDER BY CASE WHEN ' || chr(39) || pCAD_UNI_ID_UNIDADE_ORIGEM ||chr(39)|| ' IS NOT NULL THEN       
                    DECODE(CAD_UNI_ID_UNIDADE ,' ||chr(39)|| pCAD_UNI_ID_UNIDADE_ORIGEM ||chr(39)|| ',' ||chr(39)|| pCAD_UNI_ID_UNIDADE_ORIGEM ||chr(39)|| ')
               ELSE NULL END,
               CASE WHEN ' ||chr(39)|| pCAD_UNI_ID_UNIDADE_ORIGEM ||chr(39)|| ' IS NOT NULL THEN       
                    CASE WHEN CAD_UNI_ID_UNIDADE != 248 THEN CAD_UNI_DS_UNIDADE END
               ELSE NULL END,
               CASE WHEN ' ||chr(39)|| pCAD_UNI_ID_UNIDADE_ORIGEM ||chr(39)|| ' IS NOT NULL THEN       
                    CAD_UNI_DS_UNIDADE 
               ELSE NULL END,
               CASE WHEN ' ||chr(39)|| pCAD_UNI_ID_UNIDADE_ORIGEM ||chr(39)|| ' IS  NULL THEN  
                    AGE_AGG_DT_AGENDA END,
               CASE WHEN ' ||chr(39)|| pCAD_UNI_ID_UNIDADE_ORIGEM ||chr(39)|| ' IS  NULL THEN
                    AGE_AGG_HR_AGENDA END
                ASC
                */
   -- ORDER BY DECODE(CAD_UNI_ID_UNIDADE ,' || pCAD_UNI_ID_UNIDADE_ORIGEM || ',' || pCAD_UNI_ID_UNIDADE_ORIGEM || '),CASE WHEN CAD_UNI_ID_UNIDADE != 248 THEN
--             CAD_UNI_DS_UNIDADE END,CAD_UNI_DS_UNIDADE ASC
   --  vteste:= v_select;
  OPEN v_cursor 
  FOR 
   --   SELECT 1 FROM dual;
     v_select;
   io_cursor := v_cursor;
end PRC_AGE_AGG_DISP_AGE_GERADA;
