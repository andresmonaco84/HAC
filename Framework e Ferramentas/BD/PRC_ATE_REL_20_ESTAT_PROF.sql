CREATE OR REPLACE PROCEDURE "PRC_ATE_REL_20_ESTAT_PROF"
  (
     pCAD_UNI_ID_UNIDADE in TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
     pCAD_SET_NR_ANDAR in TB_CAD_SET_SETOR.CAD_SET_NR_ANDAR%type default null,
     pCAD_CNV_ID_CONVENIO in TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type default null,
     pCAD_PLA_ID_PLANO in TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type default null,
     pTIS_CBO_CD_CBOS in TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pCAD_PRO_ID_PROFISSIONAL in TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
     pATD_DT_INICIO in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pATD_DT_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pATD_HR_INICIO in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%type default null,
     pATD_HR_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%type default null,
     pTIS_TAT_CD_TPATENDIMENTO in TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%type default null,
     pCAD_PLA_CD_TIPOPLANO in TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%type default null,
     pATD_ATE_FL_INDIC_RN_OK in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_INDIC_RN_OK%type default null,
     pATD_ATE_FL_RETORNO_OK in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_RETORNO_OK%type default null,
    -- pATD_ATE_FL_STATUS in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_STATUS%type default null,
     pAGE_AGD_FL_FALTA in TB_AGE_AGD_AGENDA.AGE_AGD_FL_STATUS%type default null,
     pTIS_TSC_CD_TIPOSAIDACONSULTA in tb_tis_tcs_tp_consulta.tis_tcs_cd_tpconsulta%type default null,
          pCAD_CGC_ID IN tb_cad_cnv_convenio.cad_cgc_id%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATE_REL_ATEND_TPEMPR_CONV
  *
  *    Data Alteracao: 19/8/2010  Por: Pedro
  *    Alterac?o: RIGHT JOIN TB_ATD_GUI_GUIAATEND GUI
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR 
SELECT CAD_UNI_DS_UNIDADE,
      CAD_PLA_CD_TIPOPLANO,
      TIS_CBO_DS_CBOS_HAC,
      CAD_PRO_NR_CONSELHO,
      CAD_PRO_NM_NOME,
      CAD_PRO_NM_APELIDO,
      SUM(QTD_CONSULTA) QTD_CONSULTA,
      SUM(QTD_RETORNO) QTD_RETORNO
 FROM (
  SELECT UNI.CAD_UNI_DS_UNIDADE ,
         DECODE(PLA.CAD_PLA_CD_TIPOPLANO,
                                          '48', '48',
                                          'FU', 'FUNCIONARIO',
                                          'PA', 'PA',
                                          'GB', 'GLOBAL',
                                          'PL', 'PESSOA FISICA',
                                          'SP', 'SERVICOS PRESTADOS',
                                          'TODOS') CAD_PLA_CD_TIPOPLANO,
         CBO.TIS_CBO_DS_CBOS_HAC ,
         PRO.CAD_PRO_NR_CONSELHO ,
         PRO.CAD_PRO_NM_NOME,
         PRO.CAD_PRO_NM_APELIDO,
         COUNT(ATD.ATD_ATE_ID) QTD_CONSULTA,
         0 QTD_RETORNO
      FROM TB_ATD_ATE_ATENDIMENTO ATD
      JOIN TB_CAD_UNI_UNIDADE     UNI ON   UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
      JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON   LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
      JOIN TB_CAD_SET_SETOR       SETOR ON   SETOR.CAD_SET_ID     = ATD.CAD_SET_ID
      JOIN TB_TIS_CBO_CBOS        CBO ON   CBO.TIS_CBO_CD_CBOS  = ATD.TIS_CBO_CD_CBOS
      JOIN TB_CAD_PRO_PROFISSIONAL PRO ON   PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC
      JOIN TB_ASS_PAT_PACIEATEND  PAT ON   PAT.ATD_ATE_ID       = ATD.ATD_ATE_ID
      JOIN TB_CAD_PAC_PACIENTE    PAC ON   PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
      JOIN TB_CAD_CNV_CONVENIO    CNV ON   CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
      JOIN TB_CAD_PLA_PLANO       PLA ON   PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
      JOIN TB_TIS_TAT_TP_ATENDIMENTO TAT ON   TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO
      LEFT JOIN TB_TIS_TSC_TIPOSAIDACONSULTA TSC ON   TSC.TIS_TSC_CD_TIPOSAIDACONSULTA = ATD.TIS_TSC_CD_TIPOSAIDACONSULTA
     WHERE
           (ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
     AND   ATD.ATD_ATE_FL_STATUS    = 'A'
     AND   ATD.TIS_TAT_CD_TPATENDIMENTO = '4'
     AND   TO_DATE(TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO, 'ddMMyyyy') || LPAD(TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO), 4, '0'), 'ddMMyyyyhh24mi')
           BETWEEN TO_DATE(TO_CHAR(pATD_DT_INICIO, 'ddMMyyyy') || LPAD(TO_CHAR(pATD_HR_INICIO), 4, '0'), 'ddMMyyyyhh24mi')
           AND TO_DATE(TO_CHAR(pATD_DT_FIM, 'ddMMyyyy') || LPAD(TO_CHAR(NVL(pATD_HR_FIM,'2359')), 4, '0'), 'ddMMyyyyhh24mi')
     and (pCAD_SET_NR_ANDAR  is null or setor.cad_set_nr_andar = pCAD_SET_NR_ANDAR)
        and (pATD_ATE_FL_INDIC_RN_OK is null or atd.atd_ate_fl_indic_rn_ok = pATD_ATE_FL_INDIC_RN_OK)
        and (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR atd.CAD_LAT_ID_LOCAL_ATENDIMENTO   = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
        and (pCAD_SET_ID is null or  setor.cad_set_id  = pCAD_SET_ID)
        and (pTIS_CBO_CD_CBOS is null or atd.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS)
        and (pCAD_PRO_ID_PROFISSIONAL is null or atd.cad_pro_id_prof_exec = pCAD_PRO_ID_PROFISSIONAL)
        and (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
        and (pCAD_PLA_ID_PLANO is null or pac.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
        and (pCAD_PLA_CD_TIPOPLANO is null or pla.cad_pla_cd_tipoplano = pCAD_PLA_CD_TIPOPLANO)
         AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID)
        and (pTIS_TSC_CD_TIPOSAIDACONSULTA is null or atd.tis_tsc_cd_tiposaidaconsulta = pTIS_TSC_CD_TIPOSAIDACONSULTA)
     GROUP BY UNI.CAD_UNI_DS_UNIDADE ,
               DECODE(PLA.CAD_PLA_CD_TIPOPLANO,
                                                '48', '48',
                                                'FU', 'FUNCIONARIO',
                                                'PA', 'PA',
                                                'GB', 'GLOBAL',
                                                'PL', 'PESSOA FISICA',
                                                'SP', 'SERVICOS PRESTADOS',
                                                'TODOS') ,
               CBO.TIS_CBO_DS_CBOS_HAC ,
               PRO.CAD_PRO_NR_CONSELHO ,
               PRO.CAD_PRO_NM_NOME,
               PRO.CAD_PRO_NM_APELIDO
UNION
  SELECT UNI.CAD_UNI_DS_UNIDADE ,
         DECODE(PLA.CAD_PLA_CD_TIPOPLANO,
                                          '48', '48',
                                          'FU', 'FUNCIONARIO',
                                          'PA', 'PA',
                                          'GB', 'GLOBAL',
                                          'PL', 'PESSOA FISICA',
                                          'SP', 'SERVICOS PRESTADOS',
                                          'TODOS') CAD_PLA_CD_TIPOPLANO,
         CBO.TIS_CBO_DS_CBOS_HAC ,
         PRO.CAD_PRO_NR_CONSELHO ,
         PRO.CAD_PRO_NM_NOME,
         PRO.CAD_PRO_NM_APELIDO,
         0 QTD_CONSULTA,
         COUNT(ATD.ATD_ATE_ID) QTD_RETORNO
      FROM TB_ATD_ATE_ATENDIMENTO ATD
      JOIN TB_CAD_UNI_UNIDADE     UNI ON   UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
      JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON   LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
      JOIN TB_CAD_SET_SETOR       SETOR ON   SETOR.CAD_SET_ID     = ATD.CAD_SET_ID
      JOIN TB_TIS_CBO_CBOS        CBO ON   CBO.TIS_CBO_CD_CBOS  = ATD.TIS_CBO_CD_CBOS
      LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO ON   PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC
      JOIN TB_ASS_PAT_PACIEATEND  PAT ON   PAT.ATD_ATE_ID       = ATD.ATD_ATE_ID
      JOIN TB_CAD_PAC_PACIENTE    PAC ON   PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
      JOIN TB_CAD_CNV_CONVENIO    CNV ON   CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
      JOIN TB_CAD_PLA_PLANO       PLA ON   PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
      JOIN TB_TIS_TAT_TP_ATENDIMENTO TAT ON   TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO
      LEFT JOIN TB_TIS_TSC_TIPOSAIDACONSULTA TSC ON   TSC.TIS_TSC_CD_TIPOSAIDACONSULTA = ATD.TIS_TSC_CD_TIPOSAIDACONSULTA
     WHERE
           (ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
     AND   ATD.ATD_ATE_FL_STATUS    = 'A'
     AND   ATD.ATD_ATE_FL_RETORNO_OK = 'S'
     AND   ATD.TIS_TAT_CD_TPATENDIMENTO = '4'
     and (pCAD_SET_NR_ANDAR  is null or setor.cad_set_nr_andar = pCAD_SET_NR_ANDAR)
        and (pATD_ATE_FL_INDIC_RN_OK is null or atd.atd_ate_fl_indic_rn_ok = pATD_ATE_FL_INDIC_RN_OK)
     
        and (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR atd.CAD_LAT_ID_LOCAL_ATENDIMENTO   = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
        and (pCAD_SET_ID is null or  setor.cad_set_id  = pCAD_SET_ID)
        and (pTIS_CBO_CD_CBOS is null or atd.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS)
        and (pCAD_PRO_ID_PROFISSIONAL is null or atd.cad_pro_id_prof_exec = pCAD_PRO_ID_PROFISSIONAL)
        and (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
        and (pCAD_PLA_ID_PLANO is null or pac.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
        and (pCAD_PLA_CD_TIPOPLANO is null or pla.cad_pla_cd_tipoplano = pCAD_PLA_CD_TIPOPLANO)
        AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID)
        and (pTIS_TSC_CD_TIPOSAIDACONSULTA is null or atd.tis_tsc_cd_tiposaidaconsulta = pTIS_TSC_CD_TIPOSAIDACONSULTA)
     AND   TO_DATE(TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO, 'ddMMyyyy') || LPAD(TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO), 4, '0'), 'ddMMyyyyhh24mi')
           BETWEEN TO_DATE(TO_CHAR(pATD_DT_INICIO, 'ddMMyyyy') || LPAD(TO_CHAR(pATD_HR_INICIO), 4, '0'), 'ddMMyyyyhh24mi')
           AND TO_DATE(TO_CHAR(pATD_DT_FIM, 'ddMMyyyy') || LPAD(TO_CHAR(NVL(pATD_HR_FIM,'2359')), 4, '0'), 'ddMMyyyyhh24mi')
     GROUP BY UNI.CAD_UNI_DS_UNIDADE ,
               DECODE(PLA.CAD_PLA_CD_TIPOPLANO,
                                                '48', '48',
                                                'FU', 'FUNCIONARIO',
                                                'PA', 'PA',
                                                'GB', 'GLOBAL',
                                                'PL', 'PESSOA FISICA',
                                                'SP', 'SERVICOS PRESTADOS',
                                                'TODOS') ,
               CBO.TIS_CBO_DS_CBOS_HAC ,
               PRO.CAD_PRO_NR_CONSELHO ,
               PRO.CAD_PRO_NM_NOME,
               PRO.CAD_PRO_NM_APELIDO
)
GROUP BY
CAD_UNI_DS_UNIDADE,
         CAD_PLA_CD_TIPOPLANO,
         TIS_CBO_DS_CBOS_HAC,
         CAD_PRO_NR_CONSELHO,
         CAD_PRO_NM_NOME,
         CAD_PRO_NM_APELIDO
    ;
  
 io_cursor := v_cursor;
  end PRC_ATE_REL_20_ESTAT_PROF;
 