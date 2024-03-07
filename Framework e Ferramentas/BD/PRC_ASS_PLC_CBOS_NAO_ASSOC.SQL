CREATE OR REPLACE PROCEDURE "PRC_ASS_PLC_CBOS_NAO_ASSOC"
  (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLC_CBOS_NAO_ASSOC
  *
  *    Data Criacao:   03/09/2009   Por: Alexandre M. Muniz
  *    Funcao: Recupera as especialidades que não estão associadas
  *            a todos os planos de um convênio.
  *
  *    Data Alteracao:  data da altera???#o  Por: Nome do Analista
  *
  *
  *******************************************************************/

  v_cursor PKG_CURSOR.t_cursor;

  begin

    OPEN v_cursor FOR
    SELECT DISTINCT CBOS.TIS_CBO_CD_CBOS,
                    CBOS.TIS_CBO_DS_CBOS,
                    CBOS.TIS_CBO_FL_STATUS_ENCAMINHA,
                    CBOS.TIS_CBO_CD_CBOS_HAC,
                    CBOS.TIS_CBO_DS_CBOS_HAC,
                    CBOS.TIS_CBO_FL_QTD_ATE_LIMITADA,
                    CBOS.TIS_CBO_QT_ATEND_PERM_ANO,
                    CBOS.TIS_CBO_VL_IDADE_LIMITE_ESP,
                    CBOS.TIS_CBO_CD_CBOS_NOVO,
                    CBOS.TIS_CBO_CD_CBOS_V3,
                    CBOS.TIS_CBO_FL_STATUS
      FROM                  TB_ASS_PLC_PLANO_CBOS PLC
           RIGHT OUTER JOIN (SELECT CBOS.TIS_CBO_CD_CBOS,
                                    PLA.CAD_PLA_ID_PLANO
                               FROM TB_TIS_CBO_CBOS CBOS,
                                    TB_CAD_PLA_PLANO PLA
                              WHERE PLA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                                AND PLA.CAD_PLA_FL_SITUACAO_PLANO = 'A'
                                AND (PLA.CAD_PLA_DT_FIM_VIGENCIA IS NULL OR PLA.CAD_PLA_DT_FIM_VIGENCIA > TO_DATE(TO_CHAR(SYSDATE, 'dd/mm/yyyy')))) CBOSPLANO
                         ON (PLC.CAD_PLA_ID_PLANO = CBOSPLANO.CAD_PLA_ID_PLANO AND PLC.TIS_CBO_CD_CBOS = CBOSPLANO.TIS_CBO_CD_CBOS)
                 INNER JOIN TB_TIS_CBO_CBOS CBOS
                         ON CBOSPLANO.TIS_CBO_CD_CBOS = CBOS.TIS_CBO_CD_CBOS
     WHERE PLC.TIS_CBO_CD_CBOS IS NULL;

    io_cursor := v_cursor;

  end PRC_ASS_PLC_CBOS_NAO_ASSOC;
 