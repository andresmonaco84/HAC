CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_RESUM_CIRUR_CAC"
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
    --,TESTE OUT LONG
)
IS
/********************************************************************
*    PROCEDURE: PRC_FAT_REL_RESUM_CIRUR_CAC
*    DATA ALTERACAO: 15/12/2010  POR: PEDRO
*    ALTERAC?O:
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(3000);
  V_SELECT  varchar2(30000);
begin
  V_WHERE := NULL;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CCP.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CCP.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
IF pCAD_SET_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_SET_ID = ' || pCAD_SET_ID; END IF;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CCP.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;    END IF;
IF pCAD_PLA_ID_PLANO IS NOT NULL THEN    V_WHERE := V_WHERE || ' AND CCP.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO;    END IF;
IF pFAT_CCP_MES_FAT IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CCP.FAT_CCP_MES_FAT = ' || pFAT_CCP_MES_FAT; END IF;
IF pFAT_CCP_ANO_FAT IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CCP.FAT_CCP_ANO_FAT = ' || pFAT_CCP_ANO_FAT; END IF;
IF pTIS_TAT_CD_TPATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATE.TIS_TAT_CD_TPATENDIMENTO = ' ||CHR(39)|| pTIS_TAT_CD_TPATENDIMENTO ||CHR(39); END IF;
IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_DT_INICIO_CONSUMO >= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_INI ||CHR(39);    END IF;
IF pATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_DT_FIM_CONSUMO <= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_FIM ||CHR(39);    END IF;
IF pTIS_CBO_CD_CBOS IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATE.TIS_CBO_CD_CBOS <= ' ||CHR(39)|| pTIS_CBO_CD_CBOS ||CHR(39);    END IF;
V_SELECT:=
'
  SELECT  DISTINCT
              NVL(TOTAL_PEQUENO.TOTAL,0) TOTAL_PEQUENO,
              NVL(TOTAL_MEDIO.TOTAL,0) TOTAL_MEDIO,
              NVL(TOTAL_GRANDE.TOTAL,0) TOTAL_GRANDE,
              UNI.CAD_UNI_DS_UNIDADE,
              CCP.CAD_TPE_CD_CODIGO CAD_PLA_CD_TIPOPLANO,
              CAC.CAD_CAC_DS_CLASSCONTABIL,
              UNI.CAD_UNI_ID_UNIDADE,
              CCI.CAD_CAC_ID_CLASSCONTABIL
              FROM    TB_FAT_CCI_CONTA_CONSU_ITEM  CCI              
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
              ON      UNI.CAD_UNI_ID_UNIDADE     = CCP.CAD_UNI_ID_UNIDADE              
             
              JOIN    TB_CAD_CAC_CLASSIF_CONTAB    CAC
              ON      CAC.CAD_CAC_ID_CLASSCONTABIL = CCI.CAD_CAC_ID_CLASSCONTABIL
             LEFT JOIN  (SELECT  COUNT(*) TOTAL, CCP.CAD_UNI_ID_UNIDADE,CCP.CAD_TPE_CD_CODIGO CAD_PLA_CD_TIPOPLANO, CCI.CAD_CAC_ID_CLASSCONTABIL
                        from tb_fat_cci_conta_consu_item cci
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
                      ON      UNI.CAD_UNI_ID_UNIDADE     = CCP.CAD_UNI_ID_UNIDADE
                       where CCI.FAT_CCI_TP_PORTEANESTESICO in (0,1,2)
                       AND     (CCI.TIS_GPP_CD_GRAU_PART_PROF = '||chr(39)||'0'||chr(39)||')
                       and   (CCP.FAT_CCP_FL_FATURADA = '||chr(39)||'S'||chr(39)||')
                      AND     (ATE.ATD_ATE_FL_STATUS = '||chr(39)||'A'||chr(39)||')
                      AND     (CCP.FAT_CCP_FL_STATUS = '||chr(39)||'A'||chr(39)||')
                      AND     (CCI.FAT_CCI_FL_STATUS = '||chr(39)||'A'||chr(39)||')
                      AND     (CCI.FAT_CCI_TP_PORTEANESTESICO IS NOT NULL)
                      AND     (PRD.CAD_PRD_FL_CIRURGIA = '||chr(39)||'S'||chr(39)||')
                      AND    (UNI.CAD_UNI_FL_FATURA_UNID_OK = '||chr(39)||'S'||chr(39)||')
                     ' || V_WHERE || '
                      AND    ('||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB ||chr(39)||' IS not NULL and CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'ACS'||chr(39)||'
                 OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PA ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'PA'||chr(39)||'
                 OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_SP ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'SP'||chr(39)||'
                 OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_FU ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'FU'||chr(39)||'
                 OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_NP ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'NP'||chr(39)||')
                      GROUP BY CCP.CAD_UNI_ID_UNIDADE,CCP.CAD_TPE_CD_CODIGO ,CCI.CAD_CAC_ID_CLASSCONTABIL
              ) TOTAL_PEQUENO
              ON  TOTAL_PEQUENO.CAD_UNI_ID_UNIDADE = CCP.CAD_UNI_ID_UNIDADE
              AND TOTAL_PEQUENO.CAD_PLA_CD_TIPOPLANO =  CCP.CAD_TPE_CD_CODIGO  
              AND TOTAL_PEQUENO.CAD_CAC_ID_CLASSCONTABIL = CCI.CAD_CAC_ID_CLASSCONTABIL
           --   AND TOTAL_PEQUENO.cad_prd_id = CCI.cad_prd_id
            --  AND TOTAL_PEQUENO.atd_ate_id = CCI.atd_ate_id
             LEFT JOIN  (SELECT  COUNT(*) TOTAL, CCP.CAD_UNI_ID_UNIDADE, CCP.CAD_TPE_CD_CODIGO  CAD_PLA_CD_TIPOPLANO, CCI.CAD_CAC_ID_CLASSCONTABIL
                  from tb_fat_cci_conta_consu_item cci
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
                ON      UNI.CAD_UNI_ID_UNIDADE     = CCP.CAD_UNI_ID_UNIDADE
                 where CCI.FAT_CCI_TP_PORTEANESTESICO in(3,4)
                 AND     (CCI.TIS_GPP_CD_GRAU_PART_PROF = '||chr(39)||'0'||chr(39)||')
                  and   (CCP.FAT_CCP_FL_FATURADA = '||chr(39)||'S'||chr(39)||')
                AND     (ATE.ATD_ATE_FL_STATUS = '||chr(39)||'A'||chr(39)||')
                AND     (CCP.FAT_CCP_FL_STATUS = '||chr(39)||'A'||chr(39)||')

                AND     (CCI.FAT_CCI_FL_STATUS = '||chr(39)||'A'||chr(39)||')
                AND     (CCI.FAT_CCI_TP_PORTEANESTESICO IS NOT NULL)
                AND     (PRD.CAD_PRD_FL_CIRURGIA = '||chr(39)||'S'||chr(39)||')
                AND    (UNI.CAD_UNI_FL_FATURA_UNID_OK = '||chr(39)||'S'||chr(39)||')
                ' || V_WHERE || '
               AND    ('||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB ||chr(39)||' IS not NULL and CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'ACS'||chr(39)||'

               OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PA ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'PA'||chr(39)||'
               OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_SP ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'SP'||chr(39)||'
               OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_FU ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'FU'||chr(39)||'
               OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_NP ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'NP'||chr(39)||')
                GROUP BY CCP.CAD_UNI_ID_UNIDADE,CCP.CAD_TPE_CD_CODIGO  , CCI.CAD_CAC_ID_CLASSCONTABIL
              )   TOTAL_MEDIO
              ON  TOTAL_MEDIO.CAD_UNI_ID_UNIDADE = CCP.CAD_UNI_ID_UNIDADE
              AND TOTAL_MEDIO.CAD_PLA_CD_TIPOPLANO = CCP.CAD_TPE_CD_CODIGO 
              AND TOTAL_MEDIO.CAD_CAC_ID_CLASSCONTABIL = CCI.CAD_CAC_ID_CLASSCONTABIL
           --   AND TOTAL_MEDIO.cad_prd_id = CCI.cad_prd_id
            --  AND TOTAL_MEDIO.atd_ate_id = CCI.atd_ate_id
             LEFT JOIN  (SELECT  COUNT(*) TOTAL, CCP.CAD_UNI_ID_UNIDADE,CCP.CAD_TPE_CD_CODIGO  CAD_PLA_CD_TIPOPLANO, CCI.CAD_CAC_ID_CLASSCONTABIL
                  from  tb_fat_cci_conta_consu_item cci
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
                ON      UNI.CAD_UNI_ID_UNIDADE     = CCP.CAD_UNI_ID_UNIDADE
                 where CCI.FAT_CCI_TP_PORTEANESTESICO in(5,6,7)
                 AND     (CCI.TIS_GPP_CD_GRAU_PART_PROF = '||chr(39)||'0'||chr(39)||')
                  and   (CCP.FAT_CCP_FL_FATURADA = '||chr(39)||'S'||chr(39)||')
                AND     (ATE.ATD_ATE_FL_STATUS = '||chr(39)||'A'||chr(39)||')
                AND     (CCP.FAT_CCP_FL_STATUS = '||chr(39)||'A'||chr(39)||')

                AND     (CCI.FAT_CCI_FL_STATUS = '||chr(39)||'A'||chr(39)||')
                AND     (CCI.FAT_CCI_TP_PORTEANESTESICO IS NOT NULL)
                AND     (PRD.CAD_PRD_FL_CIRURGIA = '||chr(39)||'S'||chr(39)||')
                AND    (UNI.CAD_UNI_FL_FATURA_UNID_OK = '||chr(39)||'S'||chr(39)||')
              ' || V_WHERE || '
               AND    ('||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB ||chr(39)||' IS not NULL and CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'ACS'||chr(39)||'

                 OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PA ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'PA'||chr(39)||'
                 OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_SP ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'SP'||chr(39)||'
                 OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_FU ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'FU'||chr(39)||'
                 OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_NP ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'NP'||chr(39)||')
                GROUP BY CCP.CAD_UNI_ID_UNIDADE, CCP.CAD_TPE_CD_CODIGO  ,CCI.CAD_CAC_ID_CLASSCONTABIL
              )  TOTAL_GRANDE
              ON TOTAL_GRANDE.CAD_UNI_ID_UNIDADE = CCP.CAD_UNI_ID_UNIDADE
              AND TOTAL_GRANDE.CAD_PLA_CD_TIPOPLANO =  CCP.CAD_TPE_CD_CODIGO 
              AND TOTAL_GRANDE.CAD_CAC_ID_CLASSCONTABIL = CCI.CAD_CAC_ID_CLASSCONTABIL
              WHERE   (CCP.FAT_CCP_FL_FATURADA = '||chr(39)||'S'||chr(39)||')
              AND     (ATE.ATD_ATE_FL_STATUS = '||chr(39)||'A'||chr(39)||')
              AND     (CCP.FAT_CCP_FL_STATUS = '||chr(39)||'A'||chr(39)||')

              AND     (CCI.FAT_CCI_FL_STATUS = '||chr(39)||'A'||chr(39)||')
              AND     (CCI.FAT_CCI_TP_PORTEANESTESICO IS NOT NULL)
              AND     (CCI.TIS_GPP_CD_GRAU_PART_PROF = '||chr(39)||'0'||chr(39)||')
              AND     (PRD.CAD_PRD_FL_CIRURGIA = '||chr(39)||'S'||chr(39)||')
              AND    (UNI.CAD_UNI_FL_FATURA_UNID_OK = '||chr(39)||'S'||chr(39)||')
            ' || V_WHERE || '
              AND    ('||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB ||chr(39)||' IS not NULL and CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'ACS'||chr(39)||'
               OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PA ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'PA'||chr(39)||'
               OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_SP ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'SP'||chr(39)||'
               OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_FU ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'FU'||chr(39)||'
               OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_NP ||chr(39)||' IS NOT NULL AND CCP.CAD_TPE_CD_CODIGO = '||chr(39)||'NP'||chr(39)||')
              group by  TOTAL_PEQUENO.TOTAL,
                        TOTAL_MEDIO.TOTAL,
                        TOTAL_GRANDE.TOTAL,
                        UNI.CAD_UNI_DS_UNIDADE,
                        CCP.CAD_TPE_CD_CODIGO,
                        CAC.CAD_CAC_DS_CLASSCONTABIL,
                        UNI.CAD_UNI_ID_UNIDADE,
                        CCI.CAD_CAC_ID_CLASSCONTABIL'
  ;
  --  TESTE :=  V_SELECT ;
  OPEN v_cursor FOR
   V_SELECT ;
 --select 1 from dual;
    io_cursor := v_cursor;
END PRC_FAT_REL_RESUM_CIRUR_CAC;
 