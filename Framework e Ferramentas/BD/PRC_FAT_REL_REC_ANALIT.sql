CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_REC_ANALIT" (
    pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pTIS_TAT_CD_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_GB IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
    pCAD_PLA_CD_TIPOPLANO_PL IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
    pCAD_PLA_CD_TIPOPLANO_FU IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_NP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PA IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_SP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_I in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pATD_ATE_TP_PACIENTE_E in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pATD_ATE_TP_PACIENTE_A in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pATD_ATE_TP_PACIENTE_U in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pFAT_CCP_MES_FAT in tb_fat_ccp_conta_cons_parc.fat_ccp_mes_fat%type default null,
    pFAT_CCP_ANO_FAT in tb_fat_ccp_conta_cons_parc.fat_ccp_ano_fat%type default null,
    IO_CURSOR                OUT PKG_CURSOR.T_CURSOR
)
IS
/********************************************************************
*    PROCEDURE: PRC_FAT_REL_REC_ANALIT
*    DATA 05/09/2013   POR: PEDRO
*    ALT: CUSTO
*******************************************************************/
V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
select
           CCP.ATD_ATE_ID,
           PES.CAD_PES_NM_PESSOA,
           PAC.CAD_PAC_NR_PRONTUARIO,
         --  COUNT(CNV.CAD_CNV_CD_HAC_PRESTADOR),
           CCP.FAT_CCP_VL_TOT_CONTA VALOR,
           CCP.FAT_CCP_ID,
           UNI.CAD_UNI_DS_UNIDADE,
           LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
           NOTA.NRONF,
           NOTA.SERIE,
           NOTA.DATNF,
           NOTA.VL_ISS,
           NOTA.QUITACAO,
           COUNT(DECODE(NOTA.QUITACAO,'S','S')) OVER() QTD_QUITADOS, 
           COUNT(DECODE(NOTA.QUITACAO,'N','N')) OVER() QTD_QUITADOS_N,
           SUM(DECODE(NOTA.QUITACAO,'S',CCP.FAT_CCP_VL_TOT_CONTA)) OVER() VL_QUITADOS, 
           SUM(DECODE(NOTA.QUITACAO,'N',CCP.FAT_CCP_VL_TOT_CONTA)) OVER() VL_QUITADOS_N,
           (SELECT    COUNT(DISTINCT CCI.ATD_ATE_ID)
            FROM          TB_FAT_CCI_CONTA_CONSU_ITEM CCI
            where        ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
            AND           (CCI.FAT_CCI_FL_STATUS = 'A')
            And           CCI.FAT_CCI_MES_FECHAMENTO = pFAT_CCP_MES_FAT
            AND           CCI.FAT_CCI_ANO_FECHAMENTO = pFAT_CCP_ANO_FAT
            AND          CCI.atd_ate_tp_paciente IN ('E','I')
            AND          CCI.CAD_CNV_ID_CONVENIO = 282
        ) QTD_PENDENTE_EMITIR,
        (   SELECT    SUM(CCI.FAT_CCI_VL_FATURADO)
            FROM      TB_FAT_CCI_CONTA_CONSU_ITEM CCI
            WHERE     (CCI.FAT_CCI_FL_STATUS = 'A')    
            AND       ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
            And       CCI.FAT_CCI_MES_FECHAMENTO = pFAT_CCP_MES_FAT
            AND       CCI.FAT_CCI_ANO_FECHAMENTO = pFAT_CCP_ANO_FAT
            AND       CCI.atd_ate_tp_paciente IN ('E','I')
            AND       CCI.CAD_CNV_ID_CONVENIO = 282
            AND       CCI.ATD_ATE_ID NOT IN (SELECT CCP.ATD_ATE_ID FROM TB_FAT_CCP_CONTA_CONS_PARC CCP 
                                            WHERE CCP.ATD_ATE_ID        = CCI.ATD_ATE_ID
                                            AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
                                            AND CCP.FAT_CCP_ID          = CCI.FAT_CCP_ID
                                            AND CCP.FAT_COC_ID          = CCI.FAT_COC_ID
                                            AND CCP.FAT_NOF_ID is NOT null
                                            AND CCP.FAT_CCP_FL_STATUS = 'A' 
                                            AND CCP.CAD_CNV_ID_CONVENIO = 282
                                            AND CCP.atd_ate_tp_paciente IN ('E','I')
                                            )
        ) VL_TOTAL_PENDENTE_EMITIR
        
    from   TB_ATD_ATE_ATENDIMENTO     ATD
    JOIN   TB_FAT_CCP_CONTA_CONS_PARC CCP ON ccp.atd_ate_id          = atd.atd_ate_id
    JOIN   TB_CAD_PAC_PACIENTE        PAC ON pac.cad_pac_id_paciente = ccp.cad_pac_id_paciente
    JOIN   TB_CAD_PLA_PLANO           PLA ON pla.cad_pla_id_plano    = CCP.cad_pla_id_plano
    JOIN   TB_CAD_PES_PESSOA          PES ON PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
    JOIN   TB_FAT_NOF_NOTA_FISCAL     NOF ON NOF.FAT_NOF_ID          = CCP.FAT_NOF_ID
    JOIN   TB_CAD_CNV_CONVENIO        CNV ON CNV.CAD_CNV_ID_CONVENIO = CCP.CAD_CNV_ID_CONVENIO
    JOIN   TB_CAD_UNI_UNIDADE         UNI ON UNI.CAD_UNI_ID_UNIDADE  = CCP.CAD_UNI_ID_UNIDADE
    JOIN   TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = CCP.CAD_LAT_ID_LOCAL_ATENDIMENTO
     JOIN (select nvl(n.valtotnf, 0) + nvl(n.vl_desconto_iss, 0) vl_nota,
                   nvl(n.vl_desconto_iss, 0) vl_iss,
                   DECODE(N.NRONF,NULL,'N',
                          DECODE(N.DT_PAGAMENTO,
                                 NULL,'N',
                                 DECODE(N.CODUNIHOS_REG,
                                        NULL,'N',
                                        DECODE(N.CODCXA_REG, NULL, 'N', 'S')))) QUITACAO,
                   n.nronf,
                   N.SERIE,
                   N.DATNF,
                   n.nr_seqinter,
                   n.tp_cobranca
              from TB_NOTA_FISCAL N
             where N.SITNF = 'I'
               AND N.NR_SEQINTER IS NOT NULL
               AND N.DATNF > '01-MAR-2011' --A PARTIR DE MARÇO DE 2011 NAO TERÁ VALOR CHAR PARA PODER FAZER JOIN COM A TB_FAT_CCP
               and not exists (select 'x'
                      from tb_item_nf tin
                     where tin.nronf = n.nronf
                       and tin.serie = n.serie
                       and tin.codcxa = n.codcxa
                       and tin.codunihos = n.codunihos
                       and tin.codatomed = 8299999)
     )     nota
     ON    ccp.atd_ate_id          = NOTA.NR_SEQINTER
     and   ccp.fat_ccp_id          = TO_NUMBER(NOTA.TP_COBRANCA)
    where     (pCAD_UNI_ID_UNIDADE IS NULL OR CCP.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND       (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR CCP.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
    AND       (pCAD_SET_ID IS NULL OR ATD.CAD_SET_ID = pCAD_SET_ID)
    and   CCP.FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT
    AND   CCP.FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT
    AND   CCP.atd_ate_tp_paciente IN ('I','E')
    AND   CCP.CAD_CNV_ID_CONVENIO = 282
    AND      (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATD.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
  ;
  IO_CURSOR := V_CURSOR;
END PRC_FAT_REL_REC_ANALIT;
 