CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_REC_SP"
(
    pCAD_UNI_ID_UNIDADE                   IN varchar2 default null,
    pFAT_CCP_MES_FAT                      IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT%TYPE,
    pFAT_CCP_ANO_FAT                      IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT%TYPE,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO         IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_SET_ID                           IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_I                IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_A                IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_E                IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_U                IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO                  IN TB_CAD_PAC_PACIENTE.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_PLA_ID_PLANO                     IN TB_CAD_PAC_PACIENTE.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_GB              IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PL              IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_FU              IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_NP              IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PA              IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_SP              IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
)
IS
/* Marcus Relva - 08/02/2011 */
/*Eduardo Hyppolito - reduçao de custo - retirada da PAC e da ATE */
v_cursor PKG_CURSOR.t_cursor;
BEGIN
  OPEN v_cursor FOR
 select cnv.cad_cnv_cd_hac_prestador,
       cnv.cad_cnv_ds_razaosocial,
       sum(ccP.Fat_Ccp_Vl_Tot_Conta) valor,
       COUNT(DISTINCT CCP.ATD_ATE_ID|| CCP.FAT_CCP_ID|| CCP.CAD_CNV_ID_CONVENIO) quantidade,
       null quantidade_diarias
  from 
       tb_fat_ccp_conta_cons_parc  ccp,
       tb_cad_pla_plano            pla,
       tb_cad_cnv_convenio         cnv
 where 
    ccp.cad_pla_id_plano         = pla.cad_pla_id_plano
   and ccp.cad_cnv_id_convenio      = cnv.cad_cnv_id_convenio
   /*Somente Faturados*/
   and ccp.fat_nof_id is not null
   and ccp.fat_ccp_fl_faturada = 'S'
   /*Filtros*/
   and ccp.fat_ccp_fl_status = 'A'
   and ccp.fat_ccp_mes_fat = pFAT_CCP_MES_FAT
   and ccp.fat_ccp_ano_fat = pFAT_CCP_ANO_FAT
   and (pCAD_UNI_ID_UNIDADE is null or ccp.cad_uni_id_unidade in (select column_value from table(fnc_split(pCAD_UNI_ID_UNIDADE))))
   and (ccp.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO or pCAD_LAT_ID_LOCAL_ATENDIMENTO is null)
   and  ccp.atd_ate_tp_paciente in (pATD_ATE_TP_PACIENTE_A, pATD_ATE_TP_PACIENTE_I, pATD_ATE_TP_PACIENTE_E, pATD_ATE_TP_PACIENTE_U)
   and (ccp.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO or pCAD_CNV_ID_CONVENIO is null)
   and (ccp.cad_pla_id_plano = pCAD_PLA_ID_PLANO or pCAD_PLA_ID_PLANO is null)
   and ((pCAD_PLA_CD_TIPOPLANO_GB IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO   = 'GB')
     OR (pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL')
     OR (pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA')
     OR (pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP')
     OR (pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU')
     OR (pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP'))
 group by cnv.cad_cnv_cd_hac_prestador,
          cnv.cad_cnv_ds_razaosocial
union
/*Diarias*/
select null,
       null,
       null,
       null,
       sum(cci.fat_cci_qt_consumo) quantidade_diarias
  from tb_fat_cci_conta_consu_item cci,
       tb_fat_ccp_conta_cons_parc  ccp,
       tb_cad_pla_plano            pla,
       tb_cad_cnv_convenio         cnv
 where cci.fat_cci_fl_status        = 'A'
   and cci.atd_ate_id               = ccp.atd_ate_id
   and cci.cad_pac_id_paciente      = ccp.cad_pac_id_paciente
   and cci.fat_ccp_id               = ccp.fat_ccp_id
   and ccp.cad_pla_id_plano         = pla.cad_pla_id_plano
   and ccp.cad_cnv_id_convenio      = cnv.cad_cnv_id_convenio
   /*Somente Faturados*/
   and ccp.fat_nof_id is not null
   and ccp.fat_ccp_fl_faturada = 'S'
   and cci.cad_tap_tp_atributo = 'DIA'
   and (cci.fat_cci_fl_pacote is null or cci.fat_cci_fl_pacote = 'N')
   /*Filtros*/
   and ccp.fat_ccp_mes_fat = pFAT_CCP_MES_FAT
   and ccp.fat_ccp_ano_fat = pFAT_CCP_ANO_FAT
   and (pCAD_UNI_ID_UNIDADE is null or ccp.cad_uni_id_unidade in (select column_value from table(fnc_split(pCAD_UNI_ID_UNIDADE))))
   and (ccp.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO or pCAD_LAT_ID_LOCAL_ATENDIMENTO is null)
   and ccp.atd_ate_tp_paciente in (pATD_ATE_TP_PACIENTE_I)
   and (ccp.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO or pCAD_CNV_ID_CONVENIO is null)
   and (ccp.cad_pla_id_plano = pCAD_PLA_ID_PLANO or pCAD_PLA_ID_PLANO is null)
   and ((pCAD_PLA_CD_TIPOPLANO_GB IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO   = 'GB')
     OR (pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL')
     OR (pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA')
     OR (pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP')
     OR (pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU')
     OR (pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP'))
   order by 1,2;
  io_cursor := v_cursor;
END PRC_FAT_REL_REC_SP; 