CREATE OR REPLACE PROCEDURE PRC_FAT_REL_RESUM_CIRUR_CEC
(
    pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO     IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_PLA_ID_PLANO        IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
    pTIS_TAT_CD_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%TYPE DEFAULT NULL,
    pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_GB IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
    pCAD_PLA_CD_TIPOPLANO_PL IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
    pCAD_PLA_CD_TIPOPLANO_FU IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_NP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PA IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_SP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pFAT_CCP_MES_FAT IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT%TYPE,
    pFAT_CCP_ANO_FAT IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT%TYPE,

    IO_CURSOR OUT PKG_CURSOR.T_CURSOR
)
IS
/********************************************************************
*    PROCEDURE: PRC_FAT_REL_RESUM_CIRUR_CEC
*    DATA ALTERACAO: 15/12/2010  POR: PEDRO
*    ALTERAÇÃO:
*******************************************************************/
V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR

 

 SELECT  DISTINCT
              NVL(TOTAL_PEQUENO.TOTAL,0) TOTAL_PEQUENO,
              NVL(TOTAL_MEDIO.TOTAL,0) TOTAL_MEDIO,
              NVL(TOTAL_GRANDE.TOTAL,0) TOTAL_GRANDE,
              UNI.CAD_UNI_DS_UNIDADE,
              case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS'               
               ELSE pla.cad_pla_cd_tipoplano
              END CAD_PLA_CD_TIPOPLANO,
              CEC.CAD_CEC_DS_CCUSTO,
              CEC.CAD_CEC_CD_SUBGRUPOCCUSTO,
              UNI.CAD_UNI_ID_UNIDADE,
              CCI.CAD_CEC_ID_CCUSTO

              FROM    TB_FAT_CCI_CONTA_CONSU_ITEM  CCI
              JOIN    TB_FAT_COC_CONTA_CONSUMO     COC
              ON      COC.ATD_ATE_ID             = CCI.ATD_ATE_ID
              AND     COC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
              AND     COC.FAT_COC_ID             = CCI.FAT_COC_ID
              JOIN    TB_FAT_CCP_CONTA_CONS_PARC   CCP
              ON      CCP.FAT_CCP_ID             = CCI.FAT_CCP_ID
              AND     CCP.ATD_ATE_ID             = CCI.ATD_ATE_ID
              AND     CCP.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
              AND     CCP.FAT_COC_ID             = CCI.FAT_COC_ID
              JOIN    TB_CAD_PRD_PRODUTO           PRD
              ON      PRD.CAD_PRD_ID             = CCI.CAD_PRD_ID_COBRADO
              JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
              ON      CCI.ATD_ATE_ID             = ATE.ATD_ATE_ID
              JOIN    TB_CAD_UNI_UNIDADE           UNI
              ON      UNI.CAD_UNI_ID_UNIDADE     = ATE.CAD_UNI_ID_UNIDADE
              JOIN    TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
              ON      LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
              JOIN    TB_CAD_PAC_PACIENTE          PAC
              ON      PAC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE --fnc_buscar_paciente_atual(PAT.ATD_ATE_ID)
              JOIN    TB_CAD_PLA_PLANO             PLA
              ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
              JOIN    TB_CAD_CEC_CENTRO_CUSTO      CEC
              ON      CEC.CAD_CEC_ID_CCUSTO      = CCI.CAD_CEC_ID_CCUSTO

               
            LEFT JOIN  (SELECT  COUNT(*) TOTAL,ATE.CAD_UNI_ID_UNIDADE,case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS'               
                       ELSE pla.cad_pla_cd_tipoplano END CAD_PLA_CD_TIPOPLANO, CCI.CAD_CEC_ID_CCUSTO, cec.cad_cec_cd_subgrupoccusto
                       
                    from tb_fat_cci_conta_consu_item cci
                   JOIN    TB_FAT_CCP_CONTA_CONS_PARC   CCP
                  ON      CCP.FAT_CCP_ID             = CCI.FAT_CCP_ID
                  AND     CCP.ATD_ATE_ID             = CCI.ATD_ATE_ID
                  AND     CCP.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                  AND     CCP.FAT_COC_ID             = CCI.FAT_COC_ID
                  JOIN    TB_FAT_COC_CONTA_CONSUMO     COC
                  ON      COC.ATD_ATE_ID             = CCI.ATD_ATE_ID
                  AND     COC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                  AND     COC.FAT_COC_ID             = CCI.FAT_COC_ID
                  JOIN    TB_CAD_PRD_PRODUTO           PRD
                  ON      PRD.CAD_PRD_ID             = CCI.CAD_PRD_ID_COBRADO
                  JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
                  ON      CCI.ATD_ATE_ID             = ATE.ATD_ATE_ID
                  JOIN    TB_CAD_PAC_PACIENTE          PAC
                  ON      PAC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                  JOIN    TB_CAD_PLA_PLANO             PLA
                  ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
                  JOIN    TB_CAD_CEC_CENTRO_CUSTO      CEC
                  ON      CEC.CAD_CEC_ID_CCUSTO      = CCI.CAD_CEC_ID_CCUSTO
                   where CCI.FAT_CCI_TP_PORTEANESTESICO in (0,1,2)
                   AND   CCI.TIS_GPP_CD_GRAU_PART_PROF = '0'
                   and   (CCP.FAT_CCP_FL_FATURADA = 'S')
                  AND     (ATE.ATD_ATE_FL_STATUS = 'A')
                  AND     (CCP.FAT_CCP_FL_STATUS = 'A')
                  AND     (COC.FAT_COC_FL_STATUS = 'A')
                  AND     (CCI.FAT_CCI_FL_STATUS = 'A')
                  AND     (CCI.FAT_CCI_TP_PORTEANESTESICO IS NOT NULL)
                  AND     (cec.cad_cec_cd_ccusto = cec.cad_cec_cd_subgrupoccusto)
                  AND     (PRD.CAD_PRD_FL_CIRURGIA = 'S')
                  AND     (CCP.FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
                  AND     (CCP.FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
                  AND    (pATD_ATE_DT_ATENDIMENTO_INI IS NULL OR CCI.FAT_CCI_DT_INICIO_CONSUMO >= pATD_ATE_DT_ATENDIMENTO_INI)
                  AND    (pATD_ATE_DT_ATENDIMENTO_FIM IS NULL OR CCI.FAT_CCI_DT_FIM_CONSUMO <= pATD_ATE_DT_ATENDIMENTO_FIM)
                  AND     (pCAD_UNI_ID_UNIDADE IS NULL OR ATE.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                  AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
                  AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
                  AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)

                  AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
                   OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
                   OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
                   OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'
                   OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP'
                   OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU')
               
                  GROUP BY ATE.CAD_UNI_ID_UNIDADE, case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS'               
                                                   ELSE pla.cad_pla_cd_tipoplano  END ,CCI.CAD_CEC_ID_CCUSTO, cec.cad_cec_cd_subgrupoccusto
              ) TOTAL_PEQUENO
              ON  TOTAL_PEQUENO.CAD_UNI_ID_UNIDADE = ATE.CAD_UNI_ID_UNIDADE
              AND TOTAL_PEQUENO.CAD_PLA_CD_TIPOPLANO = case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS'               
                                                       ELSE pla.cad_pla_cd_tipoplano END 
              AND TOTAL_PEQUENO.CAD_CEC_ID_CCUSTO = CCI.CAD_CEC_ID_CCUSTO
          
              
            LEFT JOIN  (SELECT  COUNT(*) TOTAL,ATE.CAD_UNI_ID_UNIDADE,case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS'               
                       ELSE pla.cad_pla_cd_tipoplano END CAD_PLA_CD_TIPOPLANO, CCI.CAD_CEC_ID_CCUSTO, cec.cad_cec_cd_subgrupoccusto
                       
                    from tb_fat_cci_conta_consu_item cci
                   JOIN    TB_FAT_CCP_CONTA_CONS_PARC   CCP
                  ON      CCP.FAT_CCP_ID             = CCI.FAT_CCP_ID
                  AND     CCP.ATD_ATE_ID             = CCI.ATD_ATE_ID
                  AND     CCP.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                  AND     CCP.FAT_COC_ID             = CCI.FAT_COC_ID
                  JOIN    TB_FAT_COC_CONTA_CONSUMO     COC
                  ON      COC.ATD_ATE_ID             = CCI.ATD_ATE_ID
                  AND     COC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                  AND     COC.FAT_COC_ID             = CCI.FAT_COC_ID
                  JOIN    TB_CAD_PRD_PRODUTO           PRD
                  ON      PRD.CAD_PRD_ID             = CCI.CAD_PRD_ID_COBRADO
                  JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
                  ON      CCI.ATD_ATE_ID             = ATE.ATD_ATE_ID
                  JOIN    TB_CAD_PAC_PACIENTE          PAC
                  ON      PAC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                  JOIN    TB_CAD_PLA_PLANO             PLA
                  ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
                  JOIN    TB_CAD_CEC_CENTRO_CUSTO      CEC
                  ON      CEC.CAD_CEC_ID_CCUSTO      = CCI.CAD_CEC_ID_CCUSTO
                   where CCI.FAT_CCI_TP_PORTEANESTESICO in(3,4)
                   AND   CCI.TIS_GPP_CD_GRAU_PART_PROF = '0'
                    and   (CCP.FAT_CCP_FL_FATURADA = 'S')
                  AND     (ATE.ATD_ATE_FL_STATUS = 'A')
                  AND     (CCP.FAT_CCP_FL_STATUS = 'A')
                  AND     (COC.FAT_COC_FL_STATUS = 'A')
                  AND     (CCI.FAT_CCI_FL_STATUS = 'A')
                  AND     (CCI.FAT_CCI_TP_PORTEANESTESICO IS NOT NULL)
                  AND     (PRD.CAD_PRD_FL_CIRURGIA = 'S')
                  AND     (cec.cad_cec_cd_ccusto = cec.cad_cec_cd_subgrupoccusto)
                  AND     (CCP.FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
                  AND     (CCP.FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
                  AND    (pATD_ATE_DT_ATENDIMENTO_INI IS NULL OR CCI.FAT_CCI_DT_INICIO_CONSUMO >= pATD_ATE_DT_ATENDIMENTO_INI)
                  AND    (pATD_ATE_DT_ATENDIMENTO_FIM IS NULL OR CCI.FAT_CCI_DT_FIM_CONSUMO <= pATD_ATE_DT_ATENDIMENTO_FIM)
                  AND     (pCAD_UNI_ID_UNIDADE IS NULL OR ATE.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                  AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
                  AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
                  AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)

                  AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
                   OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
                   OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
                   OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'
                   OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP'
                   OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU')
                 
                  GROUP BY ATE.CAD_UNI_ID_UNIDADE,case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS'               
                                                       ELSE pla.cad_pla_cd_tipoplano END  ,CCI.CAD_CEC_ID_CCUSTO, cec.cad_cec_cd_subgrupoccusto
              )   TOTAL_MEDIO
              ON  TOTAL_MEDIO.CAD_UNI_ID_UNIDADE = ATE.CAD_UNI_ID_UNIDADE
              AND TOTAL_MEDIO.CAD_PLA_CD_TIPOPLANO = case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS' ELSE pla.cad_pla_cd_tipoplano END 
              AND TOTAL_MEDIO.CAD_CEC_ID_CCUSTO = CCI.CAD_CEC_ID_CCUSTO
           
              
            LEFT JOIN  (SELECT  COUNT(*) TOTAL,ATE.CAD_UNI_ID_UNIDADE,case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS'               
                       ELSE pla.cad_pla_cd_tipoplano END CAD_PLA_CD_TIPOPLANO, CCI.CAD_CEC_ID_CCUSTO, cec.cad_cec_cd_subgrupoccusto
                       
                    from  tb_fat_cci_conta_consu_item cci
                   JOIN    TB_FAT_CCP_CONTA_CONS_PARC   CCP
                  ON      CCP.FAT_CCP_ID             = CCI.FAT_CCP_ID
                  AND     CCP.ATD_ATE_ID             = CCI.ATD_ATE_ID
                  AND     CCP.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                  AND     CCP.FAT_COC_ID             = CCI.FAT_COC_ID
                  JOIN    TB_FAT_COC_CONTA_CONSUMO     COC
                  ON      COC.ATD_ATE_ID             = CCI.ATD_ATE_ID
                  AND     COC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                  AND     COC.FAT_COC_ID             = CCI.FAT_COC_ID
                  JOIN    TB_CAD_PRD_PRODUTO           PRD
                  ON      PRD.CAD_PRD_ID             = CCI.CAD_PRD_ID_COBRADO
                  JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
                  ON      CCI.ATD_ATE_ID             = ATE.ATD_ATE_ID
                  JOIN    TB_CAD_PAC_PACIENTE          PAC
                  ON      PAC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                  JOIN    TB_CAD_PLA_PLANO             PLA
                  ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
                  JOIN    TB_CAD_CEC_CENTRO_CUSTO      CEC
                  ON      CEC.CAD_CEC_ID_CCUSTO      = CCI.CAD_CEC_ID_CCUSTO
                   where CCI.FAT_CCI_TP_PORTEANESTESICO in(5,6,7)
                   AND   CCI.TIS_GPP_CD_GRAU_PART_PROF = '0' 
                   and   (CCP.FAT_CCP_FL_FATURADA = 'S')
                  AND     (ATE.ATD_ATE_FL_STATUS = 'A')
                  AND     (CCP.FAT_CCP_FL_STATUS = 'A')
                  AND     (COC.FAT_COC_FL_STATUS = 'A')
                  AND     (CCI.FAT_CCI_FL_STATUS = 'A')
                  AND     (CCI.FAT_CCI_TP_PORTEANESTESICO IS NOT NULL)
                  AND     (PRD.CAD_PRD_FL_CIRURGIA = 'S')
                  AND     (cec.cad_cec_cd_ccusto = cec.cad_cec_cd_subgrupoccusto)
                  AND     (CCP.FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
                  AND     (CCP.FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
                  AND    (pATD_ATE_DT_ATENDIMENTO_INI IS NULL OR CCI.FAT_CCI_DT_INICIO_CONSUMO >= pATD_ATE_DT_ATENDIMENTO_INI)
                  AND    (pATD_ATE_DT_ATENDIMENTO_FIM IS NULL OR CCI.FAT_CCI_DT_FIM_CONSUMO <= pATD_ATE_DT_ATENDIMENTO_FIM)
                  AND     (pCAD_UNI_ID_UNIDADE IS NULL OR ATE.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                  AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
                  AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
                  AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)

                  AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
                   OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
                   OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
                   OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'
                   OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP'
                   OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU')
                          GROUP BY ATE.CAD_UNI_ID_UNIDADE,case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS'               
                                                               ELSE pla.cad_pla_cd_tipoplano END ,CCI.CAD_CEC_ID_CCUSTO, cec.cad_cec_cd_subgrupoccusto
              )  TOTAL_GRANDE
              ON TOTAL_GRANDE.CAD_UNI_ID_UNIDADE = ATE.CAD_UNI_ID_UNIDADE
              AND TOTAL_GRANDE.CAD_PLA_CD_TIPOPLANO = case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS' ELSE pla.cad_pla_cd_tipoplano END 
              AND TOTAL_GRANDE.CAD_CEC_ID_CCUSTO = CCI.CAD_CEC_ID_CCUSTO

              WHERE   (CCP.FAT_CCP_FL_FATURADA = 'S')
              AND     (ATE.ATD_ATE_FL_STATUS = 'A')
              AND     (CCP.FAT_CCP_FL_STATUS = 'A')
              AND     (COC.FAT_COC_FL_STATUS = 'A')
              AND     (CCI.FAT_CCI_FL_STATUS = 'A')
              AND     (CCI.TIS_GPP_CD_GRAU_PART_PROF = '0')
              AND     (CCI.FAT_CCI_TP_PORTEANESTESICO IS NOT NULL)
              AND     (PRD.CAD_PRD_FL_CIRURGIA = 'S')
              AND     (cec.cad_cec_cd_ccusto = cec.cad_cec_cd_subgrupoccusto)
              AND     (CCP.FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
              AND     (CCP.FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
              AND    (pATD_ATE_DT_ATENDIMENTO_INI IS NULL OR CCI.FAT_CCI_DT_INICIO_CONSUMO >= pATD_ATE_DT_ATENDIMENTO_INI)
                  AND    (pATD_ATE_DT_ATENDIMENTO_FIM IS NULL OR CCI.FAT_CCI_DT_FIM_CONSUMO <= pATD_ATE_DT_ATENDIMENTO_FIM)
              AND     (pCAD_UNI_ID_UNIDADE IS NULL OR ATE.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
              AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
              AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
              AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)

              AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
               OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
               OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
               OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'
               OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP'
               OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU')

              group by  TOTAL_PEQUENO.TOTAL,
                        TOTAL_MEDIO.TOTAL,
                        TOTAL_GRANDE.TOTAL,
                        UNI.CAD_UNI_DS_UNIDADE,
                        case when pla.cad_pla_cd_tipoplano in ('GB','PL') then 'ACS'               
                        ELSE pla.cad_pla_cd_tipoplano              END ,
                        CEC.CAD_CEC_DS_CCUSTO,
                        CEC.CAD_CEC_CD_SUBGRUPOCCUSTO,
                        UNI.CAD_UNI_ID_UNIDADE,
                        CCI.CAD_CEC_ID_CCUSTO

  ;
  IO_CURSOR := V_CURSOR;
END PRC_FAT_REL_RESUM_CIRUR_CEC;
/
