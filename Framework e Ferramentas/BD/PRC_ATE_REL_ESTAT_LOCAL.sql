CREATE OR REPLACE PROCEDURE "PRC_ATE_REL_ESTAT_LOCAL"
  (
     pCAD_UNI_ID_UNIDADE in TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%type default null,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
     pTIS_CBO_CD_CBOS in TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pATD_DT_INICIO in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pATD_DT_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type default null,
          pCAD_CGC_ID IN tb_cad_cnv_convenio.cad_cgc_id%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATE_REL_ESTAT_LOCAL
  *
  *    Data Criacao:  07/5/2008   Por: Pedro
  *
  *    Data Criacao:  15/6/2008   Por: Pedro
  *    Alteracao:   nao considerar retorno    ATD_ATE_FL_RETORNO_OK = N
  *
  *    Funcao: Alimentar relatorio das estatisticas de tipo de Atendimento por Local
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
SELECT  ATD.CAD_UNI_ID_UNIDADE, UNI.CAD_UNI_DS_UNIDADE, ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO, LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO ,
        ATD.TIS_TAT_CD_TPATENDIMENTO, TAT.TIS_TAT_DS_TPATENDIMENTO,
        DECODE(PLA.CAD_PLA_CD_TIPOPLANO,
                  'FU', 'FUNCIONARIO',
                  'PA', 'PA',
                  'GB', 'ACS',
                  'PL', 'ACS',
                  'SP', 'SERVICOS PRESTADOS') TIPO_EMPRESA,
         COUNT(ATD.ATD_ATE_ID )  TOTAL_ATEND
     FROM TB_ATD_ATE_ATENDIMENTO ATD
     JOIN TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
     JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO    
     JOIN TB_TIS_TAT_TP_ATENDIMENTO TAT ON TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO
     JOIN TB_ASS_PAT_PACIEATEND PAT ON ATD.ATD_ATE_ID = PAT.ATD_ATE_ID
     JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
     JOIN TB_CAD_PLA_PLANO PLA ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
                 JOIN TB_CAD_CNV_CONVENIO CNV ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO     
     WHERE (ATD.ATD_ATE_DT_ATENDIMENTO BETWEEN pATD_DT_INICIO AND pATD_DT_FIM)
        AND (ATD.ATD_ATE_FL_STATUS = 'A')
        AND (ATD.ATD_ATE_FL_RETORNO_OK = 'N')
        AND (PCAD_UNI_ID_UNIDADE IS NULL OR ATD.CAD_UNI_ID_UNIDADE = PCAD_UNI_ID_UNIDADE)
        AND (ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = PCAD_LAT_ID_LOCAL_ATENDIMENTO)
        AND (PCAD_SET_ID IS NULL OR ATD.CAD_SET_ID = PCAD_SET_ID)
        AND (PTIS_CBO_CD_CBOS IS NULL OR ATD.TIS_CBO_CD_CBOS = PTIS_CBO_CD_CBOS)
        AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
         AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID)
      GROUP BY ATD.CAD_UNI_ID_UNIDADE, UNI.CAD_UNI_DS_UNIDADE, ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO, LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO ,
               ATD.TIS_TAT_CD_TPATENDIMENTO, TAT.TIS_TAT_DS_TPATENDIMENTO, DECODE(PLA.CAD_PLA_CD_TIPOPLANO,
                                                                        'FU', 'FUNCIONARIO',
                                                                        'PA', 'PA',
                                                                        'GB', 'ACS',
                                                                        'PL', 'ACS',
                                                                        'SP', 'SERVICOS PRESTADOS')
UNION ALL
SELECT ATD.CAD_UNI_ID_UNIDADE, UNI.CAD_UNI_DS_UNIDADE, ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO, LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO ,
       'R' TIS_TAT_CD_TPATENDIMENTO, 'RETORNO' TIS_TAT_CD_TPATENDIMENTO,
                DECODE(PLA.CAD_PLA_CD_TIPOPLANO,
                            'FU', 'FUNCIONARIO',
                            'PA', 'PA',
                            'GB', 'ACS',
                            'PL', 'ACS',
                            'SP', 'SERVICOS PRESTADOS') CAD_PLA_CD_TIPOPLANO,
                           COUNT(ATD.ATD_ATE_ID ) TOTAL_RETORNO
                FROM TB_ATD_ATE_ATENDIMENTO ATD
                 JOIN TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
                 JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO    
                 JOIN TB_TIS_TAT_TP_ATENDIMENTO TAT ON TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO
                 JOIN TB_ASS_PAT_PACIEATEND PAT ON ATD.ATD_ATE_ID = PAT.ATD_ATE_ID
                 JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
                 JOIN TB_CAD_PLA_PLANO PLA ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
                 JOIN TB_CAD_CNV_CONVENIO CNV ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
                WHERE (ATD.ATD_ATE_DT_ATENDIMENTO BETWEEN pATD_DT_INICIO AND pATD_DT_FIM)
                AND (ATD.ATD_ATE_FL_STATUS = 'A')
                AND (ATD.ATD_ATE_FL_RETORNO_OK = 'S')
                AND ATD.TIS_TAT_CD_TPATENDIMENTO = '4' --CONSULTA
                AND (PCAD_UNI_ID_UNIDADE IS NULL OR ATD.CAD_UNI_ID_UNIDADE = PCAD_UNI_ID_UNIDADE)
                AND (ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = PCAD_LAT_ID_LOCAL_ATENDIMENTO)
                AND (PCAD_SET_ID IS NULL OR ATD.CAD_SET_ID = PCAD_SET_ID)
                AND (PTIS_CBO_CD_CBOS IS NULL OR ATD.TIS_CBO_CD_CBOS = PTIS_CBO_CD_CBOS)
                AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
                 AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID)
              GROUP BY  ATD.CAD_UNI_ID_UNIDADE, UNI.CAD_UNI_DS_UNIDADE, ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO, LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO ,
                        DECODE(PLA.CAD_PLA_CD_TIPOPLANO,
                                    'FU', 'FUNCIONARIO',
                                    'PA', 'PA',
                                    'GB', 'ACS',
                                    'PL', 'ACS',
                                    'SP', 'SERVICOS PRESTADOS')
         ORDER BY TIS_TAT_CD_TPATENDIMENTO
;    io_cursor := v_cursor;
  end PRC_ATE_REL_ESTAT_LOCAL;
