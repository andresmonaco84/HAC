create or replace procedure PRC_FAT_REL_PRD_SEM_SIM_BRAS
  (
     pCAD_UNI_ID_UNIDADE in TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%type default null,
     pCAD_CNV_CD_HAC_PRESTADOR IN TB_CAD_CNV_CONVENIO.CAD_CNV_CD_HAC_PRESTADOR%TYPE DEFAULT NULL,
     pFAT_CCP_MES_FAT IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT%TYPE,
     pFAT_CCP_ANO_FAT IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_PRD_SEM_SIM_BRAS
  *
  *    Data da criação: 16/05/2011  Por: Eduardo Hyppolito
  *
  *    Função: listar as contas do convênio selecionado que utilizaram produtos (mat/med)
  *    que não têm correspondência nas tabelas Brasindice e Simpro.
  *
  *
    ******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
BEGIN
    OPEN v_cursor FOR
SELECT distinct SUBSTR(CD_PROC_REAL,4,7) CODIGO,
       PRD.CAD_PRD_NM_FANTASIA DESCRICAO,
       PRD.CAD_PRD_CD_TABELA_MATMED CODIGO,
       ate.atd_ate_dt_atendimento,
       ate.atd_ate_tp_paciente,
       ate.atd_ate_id,
       pes.cad_pes_nm_pessoa,
       uni.cad_uni_ds_unidade,
       ccp.fat_ccp_id,
       nof.fat_nof_nr_notafiscal

FROM   TSS_RESUMO_INT_SGS INT,
       TSS_OUTRASDESP_PROC_SGS PROC,
       TB_CAD_PRD_PRODUTO PRD,
       Tb_Atd_Ate_Atendimento ate,
       Tb_Cad_Uni_Unidade uni,
       tb_ass_pat_pacieatend pat,
       tb_cad_pac_paciente pac,
       tb_cad_pes_pessoa pes,
       tb_fat_ccp_conta_cons_parc ccp,
       tb_fat_nof_nota_fiscal nof

WHERE INT.CD_CONVENIO = pCAD_CNV_CD_HAC_PRESTADOR
AND   INT.MM_RECEITA = pFAT_CCP_MES_FAT
AND   INT.AA_RECEITA = pFAT_CCP_ANO_FAT
AND   PROC.NR_ATENDIMENTO = INT.NR_ATENDIMENTO
AND   PROC.CD_PARCELA = INT.CD_PARCELA
AND   PROC.MM_RECEITA = INT.MM_RECEITA
AND   PROC.AA_RECEITA = INT.AA_RECEITA
AND   PROC.CD_TP_DESPESA IN (2,3)
AND   SUBSTR(PROC.CD_PROC_REAL,4,7) = PRD.CAD_PRD_NM_MNEMONICO
AND   INT.NR_FATURA IS NOT NULL
AND   ATE.ATD_ATE_ID = INT.NR_ATENDIMENTO
AND   UNI.CAD_UNI_ID_UNIDADE = ATE.CAD_UNI_ID_UNIDADE
AND   (pCAD_UNI_ID_UNIDADE IS NULL OR ate.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
AND   pat.atd_ate_id = ate.atd_ate_id
AND   pac.cad_pac_id_paciente = pat.cad_pac_id_paciente
AND   pac.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
AND   ccp.atd_ate_id = ate.atd_ate_id
AND   nof.fat_nof_id = ccp.fat_nof_id

UNION

SELECT DISTINCT SUBSTR(CD_PROC_REAL,4,7),
                PRD.CAD_PRD_NM_FANTASIA,
                PRD.CAD_PRD_CD_TABELA_MATMED,
                ate.atd_ate_dt_atendimento,
                ate.atd_ate_tp_paciente,
                ate.atd_ate_id,
                pes.cad_pes_nm_pessoa,
                uni.cad_uni_ds_unidade,
                ccp.fat_ccp_id,
                nof.fat_nof_nr_notafiscal

FROM   TSS_SPSADT_SGS INT,
       TSS_OUTRASDESP_PROC_SGS PROC,
       TB_CAD_PRD_PRODUTO PRD,
       Tb_Atd_Ate_Atendimento ate,
       Tb_Cad_Uni_Unidade uni,
       tb_ass_pat_pacieatend pat,
       tb_cad_pac_paciente pac,
       tb_cad_pes_pessoa pes,
       tb_fat_ccp_conta_cons_parc ccp,
       tb_fat_nof_nota_fiscal nof

WHERE  (pCAD_CNV_CD_HAC_PRESTADOR IS NULL OR INT.CD_CONVENIO = pCAD_CNV_CD_HAC_PRESTADOR)
AND    (pFAT_CCP_MES_FAT IS NULL OR INT.MM_RECEITA = pFAT_CCP_MES_FAT)
AND    (pFAT_CCP_ANO_FAT IS NULL OR INT.AA_RECEITA = pFAT_CCP_ANO_FAT)
AND    PROC.NR_ATENDIMENTO = INT.NR_ATENDIMENTO
AND    PROC.CD_PARCELA = INT.CD_PARCELA
AND    PROC.MM_RECEITA = INT.MM_RECEITA
AND    PROC.AA_RECEITA = INT.AA_RECEITA
AND    PROC.CD_TP_DESPESA IN (2,3)
AND    SUBSTR(PROC.CD_PROC_REAL,4,7) = PRD.CAD_PRD_NM_MNEMONICO
AND   INT.NR_FATURA IS NOT NULL
AND   ATE.ATD_ATE_ID = INT.NR_ATENDIMENTO
AND   UNI.CAD_UNI_ID_UNIDADE = ATE.CAD_UNI_ID_UNIDADE
AND   (pCAD_UNI_ID_UNIDADE IS NULL OR ate.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
AND   pat.atd_ate_id = ate.atd_ate_id
AND   pac.cad_pac_id_paciente = pat.cad_pac_id_paciente
AND   pac.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
AND   ccp.atd_ate_id = ate.atd_ate_id
AND   nof.fat_nof_id = ccp.fat_nof_id

ORDER BY 2
;    io_cursor := v_cursor;
  end PRC_FAT_REL_PRD_SEM_SIM_BRAS;
