create or replace procedure PRC_ATE_REL_ESTAT_TPEMP_ESPEC
  (
     pCAD_UNI_ID_UNIDADE in TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     pTIS_CBO_CD_CBOS in TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pATD_DT_INICIO in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pATD_DT_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
          pCAD_CGC_ID IN tb_cad_cnv_convenio.cad_cgc_id%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATE_REL_ESTAT_TPEMP_ESPEC
  *
  *    Data Criacao:  25/5/2008   Por: Pedro
  *
  *    Data alteracao:  15/6/2008   Por: Pedro
  *    alteracao: pCAD_UNI_ID_UNIDADE e  pCAD_LAT_ID_LOCAL_ATENDIMENTO default null e sem order by
  *
  *    Data Alteracao:  13/07/2008   Por: Pedro
  *    Alteracao: tirar duplicidade do plano acs
  *
  *    Funcao: Alimentar relatorio das estatisticas de Atendimento por tipo empresa e especialidade
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
      SELECT DISTINCT UNI.CAD_UNI_DS_UNIDADE CAD_PES_NM_PESSOA,
                      UNI.CAD_UNI_DS_UNIDADE,
                      LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                      CASE
                        WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'PLANO ACS'
                           WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'FU' THEN 'FUNCIONARIO'
                           WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'SP' THEN 'S.PRESTADO'
                           ELSE 'PARTICULAR'
                      END TIPO_EMPRESA,
                      CBO.TIS_CBO_DS_CBOS_HAC,
                      SUM(COUNT(ATD.ATD_ATE_ID))
                      OVER(PARTITION BY CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'PLANO ACS'
                                             WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'FU' THEN 'FUNCIONARIO'
                                             WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'SP' THEN 'S.PRESTADO'
                                             ELSE 'PARTICULAR'
                                             END||UNI.CAD_UNI_DS_UNIDADE||LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO||CBO.TIS_CBO_DS_CBOS_HAC) TOTAL_ATEND
                 FROM TB_ATD_ATE_ATENDIMENTO ATD
            JOIN TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
            JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
            JOIN TB_TIS_CBO_CBOS CBO ON CBO.TIS_CBO_CD_CBOS = ATD.TIS_CBO_CD_CBOS
            JOIN TB_TIS_TAT_TP_ATENDIMENTO TAT ON TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO
            JOIN TB_ASS_PAT_PACIEATEND PAT ON ATD.ATD_ATE_ID = PAT.ATD_ATE_ID
            JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
            JOIN TB_CAD_PLA_PLANO PLA ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
            JOIN TB_CAD_CNV_CONVENIO CNV ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
                WHERE (ATD.ATD_ATE_DT_ATENDIMENTO BETWEEN PATD_DT_INICIO AND PATD_DT_FIM)
                  AND (ATD.ATD_ATE_FL_STATUS = 'A')
                  AND (PCAD_UNI_ID_UNIDADE IS NULL OR ATD.CAD_UNI_ID_UNIDADE = PCAD_UNI_ID_UNIDADE)
                  AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = PCAD_LAT_ID_LOCAL_ATENDIMENTO)
                  AND (pTIS_CBO_CD_CBOS IS NULL OR ATD.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
                  AND (pCAD_PLA_CD_TIPOPLANO IS NULL OR PLA.CAD_PLA_CD_TIPOPLANO = pCAD_PLA_CD_TIPOPLANO)
                   AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID)
             GROUP BY UNI.CAD_UNI_DS_UNIDADE,
                      UNI.CAD_UNI_DS_UNIDADE,
                      LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                      PLA.CAD_PLA_CD_TIPOPLANO,
                      CBO.TIS_CBO_DS_CBOS_HAC;
  IO_CURSOR := V_CURSOR;
  end PRC_ATE_REL_ESTAT_TPEMP_ESPEC;
