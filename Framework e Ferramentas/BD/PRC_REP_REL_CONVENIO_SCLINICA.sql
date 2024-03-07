CREATE OR REPLACE PROCEDURE "PRC_REP_REL_CONVENIO_SCLINICA" (
    pFAT_CCP_MES_FAT  IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT%TYPE DEFAULT NULL,
    pFAT_CCP_ANO_FAT  IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    IO_CURSOR                OUT PKG_CURSOR.T_CURSOR
    )
IS
/********************************************************************
*
*    PROCEDURE: PRC_REP_REL_CONVENIO_SCLINICA
*    
*********************************************************************/
V_CURSOR PKG_CURSOR.T_CURSOR;
-- V_CAD_CNV_ID_CONVENIO  VARCHAR(10);
BEGIN
--  IF (pCAD_CNV_ID_CONVENIO IS NOT NULL) THEN
--     V_CAD_CNV_ID_CONVENIO := pCAD_CNV_ID_CONVENIO;
--  ELSE
--     V_CAD_CNV_ID_CONVENIO := '%';
--  END IF;
  OPEN V_CURSOR FOR
SELECT DISTINCT 'Honorarios Medicos',
       atd.atd_ate_id,
       TO_CHAR(cci.fat_ccp_id),
       PES.CAD_PES_NM_PESSOA,
       substr(CNV.CAD_CNV_CD_HAC_PRESTADOR,0,5),
       cnv.cad_cnv_nm_fantasia,
       pac.cad_pac_nr_prontuario,
       decode(cci.fat_cci_pc_acomodacao_hm, null, 'BAS', 'MST'),
        ATD.ATD_ATE_DT_ATENDIMENTO,
       ccp.fat_ccp_dt_parcela,
       atd.atd_ate_hr_atendimento,
       DECODE(ccp.fat_ccp_hr_parcela,0, atd.atd_ate_hr_atendimento,ccp.fat_ccp_hr_parcela),
       idg.atd_idg_cd_cidprincipal,
       'Codigo : '||TO_CHAR(prd.cad_prd_cd_codigo),
       'Descricao : '||prd.cad_prd_ds_descricao,
       'Data : '||TO_CHAR(cci.fat_cci_dt_inicio_consumo,'dd/MM/yyyy'),
       'Hora :'||TO_CHAR(cci.fat_cci_hr_inicio_consumo,'0000'),
       'Qtd : '||to_char(cci.fat_cci_qt_consumo),
        'CRM : '||to_char(pro.cad_pro_nr_conselho),
       'Nome : '||pro.cad_pro_nm_nome,
       'Tipo : '||DECODE( CCI.TIS_GPP_CD_GRAU_PART_PROF, 0,'Principal',1,'Aux 1',2,'Aux 2',3,'Aux 3',6,'Anestesista'),
        pac.cad_pac_cd_credencial,
        gui.atd_gui_cd_senha,
        PAC.CAD_PAC_NM_TITULAR,
        pac.cad_pac_dt_validadecredencial,
        pes.cad_pes_nr_rg,
        cci.fat_cci_vl_calculado
FROM  tb_atd_ate_atendimento atd,
      tb_fat_cci_conta_consu_item cci,
      tb_fat_ccp_conta_cons_parc ccp,
      tb_cad_pro_profissional pro,
      tb_cad_pes_pessoa pes,
      tb_cad_prd_produto prd,
      tb_atd_gui_guiaatend gui,
      tb_cad_pac_paciente pac,
      tb_cad_cnv_convenio cnv,
      tb_cad_uni_unidade uni,
      tb_atd_idg_int_diagnostico idg,
      rep_clinica_conv c
        WHERE CCI.ATD_ATE_ID                = ATD.ATD_ATE_ID
        AND   ATD.ATD_ATE_ID                = CCP.ATD_ATE_ID
        AND   CCI.FAT_COC_ID                = CCP.FAT_COC_ID
        AND   CCI.CAD_PAC_ID_PACIENTE       = CCP.CAD_PAC_ID_PACIENTE
        AND   CCI.FAT_CCP_ID                = CCP.FAT_CCP_ID
        AND   CCP.CAD_PAC_ID_PACIENTE       = PAC.CAD_PAC_ID_PACIENTE
        AND   (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
        AND   CCI.FAT_CCI_CD_CLINICA_PROF   = 45
        AND   PRO.CAD_PRO_ID_PROFISSIONAL   = CCI.CAD_PRO_ID_PROFISSIONAL
        AND   CCI.CAD_PRD_ID                = PRD.CAD_PRD_ID
        AND   PAC.CAD_PES_ID_PESSOA         = PES.CAD_PES_ID_PESSOA
        AND   c.cd_clinica                  = CCI.FAT_CCI_CD_CLINICA_PROF
        AND   ATD.CAD_UNI_ID_UNIDADE        = UNI.CAD_UNI_ID_UNIDADE
        AND   c.codunihos                   = UNI.CAD_UNI_CD_UNID_HOSPITALAR
        AND   c.codloc                      = 'INT'
        AND   c.codcon                      = CNV.CAD_CNV_CD_HAC_PRESTADOR
        AND   GUI.ATD_ATE_ID(+)             = ATD.ATD_ATE_ID
        and   idg.atd_ate_id                = atd.atd_ate_id
        AND   CCP.FAT_CCP_FL_EMITIDA        = 'S'
        AND   CCP.FAT_CCP_FL_FATURADA       = 'S'
        AND   c.indclacon                   = 'S'
        AND   CCP.FAT_CCP_MES_FAT           = pFAT_CCP_MES_FAT
        AND   CCP.FAT_CCP_ANO_FAT           = pFAT_CCP_ANO_FAT
        AND   atd.atd_ate_tp_paciente       IN  ('I', 'E')
        AND   CCI.CAD_TAP_TP_ATRIBUTO       IN ('HM')
        AND   CCI.FAT_CCI_FL_STATUS         <> 'C'
--        AND ( CCI.FAT_FL_PENDENTE_AUTORIZA  NOT IN ('P', 'N')
         or   CCI.FAT_FL_PENDENTE_AUTORIZA  is null)
        AND   CCI.FAT_CCI_TP_CREDENCIA_PROF = 'MC'
        AND   PRD.TIS_MED_CD_TABELAMEDICA   <> 'IP'
UNION ALL
SELECT DISTINCT 'Diarias',
       atd.atd_ate_id,
       TO_CHAR(cci.fat_ccp_id),
       PES.CAD_PES_NM_PESSOA,
       substr(CNV.CAD_CNV_CD_HAC_PRESTADOR,0,5),
       cnv.cad_cnv_nm_fantasia,
      pac.cad_pac_nr_prontuario,
       decode(cci.fat_cci_pc_acomodacao_hm, null, 'BAS', 'MST'),
       CCP.FAT_CCP_DT_PARCELA_INI,
       ccp.fat_ccp_dt_parcela,
       atd.atd_ate_hr_atendimento,
       ccp.fat_ccp_hr_parcela,
       idg.atd_idg_cd_cidprincipal,
       'Codigo : '||TO_CHAR(prd.cad_prd_cd_codigo),
       'Descricao : '||prd.cad_prd_ds_descricao,
       'Data : '||TO_CHAR(cci.fat_cci_dt_inicio_consumo,'dd/MM/yyyy'),
       'Hora :'||TO_CHAR(cci.fat_cci_hr_inicio_consumo,'0000'),
       'Qtd : '||to_char(cci.fat_cci_qt_consumo),
       NULL,
       NULL,
       NULL,
        pac.cad_pac_cd_credencial,
        gui.atd_gui_cd_senha,
        PAC.CAD_PAC_NM_TITULAR,
        pac.cad_pac_dt_validadecredencial,
        pes.cad_pes_nr_rg,
        null
FROM  tb_atd_ate_atendimento atd,
      tb_fat_cci_conta_consu_item cci,
      tb_fat_ccp_conta_cons_parc ccp,
     -- tb_cad_pro_profissional pro,
      tb_cad_pes_pessoa pes,
      tb_cad_prd_produto prd,
      TB_TIS_TAC_TIPO_ACOMODACAO tac,
      tb_atd_gui_guiaatend gui,
      tb_cad_pac_paciente pac,
      tb_cad_cnv_convenio cnv,
      tb_atd_idg_int_diagnostico idg,
      convenio_santos_clinica c
  WHERE CCI.ATD_ATE_ID                      = ATD.ATD_ATE_ID
        AND   ATD.ATD_ATE_ID                = CCP.ATD_ATE_ID
        AND   CCI.FAT_COC_ID                = CCP.FAT_COC_ID
        AND   CCI.CAD_PAC_ID_PACIENTE       = CCP.CAD_PAC_ID_PACIENTE
        AND   CCI.FAT_CCP_ID                = CCP.FAT_CCP_ID
        AND   CCP.CAD_PAC_ID_PACIENTE       = PAC.CAD_PAC_ID_PACIENTE
        AND   PAC.CAD_CNV_ID_CONVENIO       = CNV.CAD_CNV_ID_CONVENIO
       -- AND   PRO.CAD_PRO_ID_PROFISSIONAL   = ATD.CAD_PRO_ID_PROF_EXEC
        AND   CCI.CAD_PRD_ID                = PRD.CAD_PRD_ID
        AND   PAC.CAD_PES_ID_PESSOA         = PES.CAD_PES_ID_PESSOA
        AND   c.codcon                      = CNV.CAD_CNV_CD_HAC_PRESTADOR
        AND   GUI.ATD_ATE_ID(+)             = ATD.ATD_ATE_ID
        and   idg.atd_ate_id                = atd.atd_ate_id
        AND   TAC.TIS_TAC_CD_TIPO_ACOMODACAO = PRD.TIS_TAC_CD_TIPO_ACOMODACAO
        AND   CNV.CAD_CNV_CD_HAC_PRESTADOR  NOT IN ('GG05', 'SD01', 'NP01')
        AND   CCP.FAT_CCP_MES_FAT           = pFAT_CCP_MES_FAT
        AND   CCP.FAT_CCP_ANO_FAT           = pFAT_CCP_ANO_FAT
        AND   CCP.FAT_CCP_FL_EMITIDA        = 'S'
        AND   CCP.FAT_CCP_FL_FATURADA       = 'S'
        AND   atd.atd_ate_tp_paciente       IN  ('I', 'E')
        AND   CCI.CAD_TAP_TP_ATRIBUTO       IN ('DIA')
        AND   CCI.FAT_CCI_FL_STATUS         <> 'C'
--        AND ( CCI.FAT_FL_PENDENTE_AUTORIZA  NOT IN ('P', 'N')
         or   CCI.FAT_FL_PENDENTE_AUTORIZA  is null)
        AND   PRD.TIS_MED_CD_TABELAMEDICA   <> 'IP'
        AND EXISTS (SELECT 'x'
                      FROM TB_FAT_CCI_CONTA_CONSU_ITEM  CCI
                     WHERE CCI.ATD_ATE_ID = ATD.ATD_ATE_ID
                    AND CCI.FAT_CCP_ID = CCP.FAT_CCP_ID
                    AND CCI.FAT_CCI_TP_CREDENCIA_PROF   = 'MC'
                    AND CCI.FAT_CCI_CD_CLINICA_PROF = 45
                    AND CCI.CAD_TAP_TP_ATRIBUTO       IN ('HM'))
ORDER BY 5,2,3,1,15;
  IO_CURSOR := V_CURSOR;
END PRC_REP_REL_CONVENIO_SCLINICA;
 
/
