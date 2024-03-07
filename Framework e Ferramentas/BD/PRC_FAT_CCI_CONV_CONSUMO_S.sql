CREATE OR REPLACE PROCEDURE "PRC_FAT_CCI_CONV_CONSUMO_S"
(
    pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
    IO_CURSOR OUT PKG_CURSOR.T_CURSOR
)
IS
/* Marcus Relva - 16/05/2013 - Integracao com historico */
V_CURSOR PKG_CURSOR.T_CURSOR;
v_select varchar2(30000);
v_tabela varchar2(100);
BEGIN
	select case when count(1) > 0 then ' TB_FAT_CCI_CONTA_CONSU_ITEM ' else ' TB_FAT_CIH_ITEM_HISTORICO ' end as tabela 
	into v_tabela
	from tb_fat_cci_conta_consu_item cci
	where cci.atd_ate_id = pATD_ATE_ID;
v_select :=   'SELECT  DISTINCT CNV.CAD_CNV_ID_CONVENIO,
          CNV.CAD_CNV_CD_HAC_PRESTADOR,
          CNV.CAD_CNV_DS_RAZAOSOCIAL,
          CNV.CAD_CNV_NM_FANTASIA,
          PAC.CAD_PAC_ID_PACIENTE,
          PES.CAD_PES_NM_PESSOA,
          ATE.ATD_ATE_TP_PACIENTE,
          ATE.ATD_ATE_FL_STATUS,
          ATE.ATD_ATE_FL_LIBERA_EMISSAO,
          ATE.ATD_ATE_DT_ATENDIMENTO,
          case when MSI.TIS_MSI_CD_TIPOALTA = 4 then INA.Atd_Ina_Dt_Alta_Clinica  
          else         INA.ATD_INA_DT_ALTA_ADM
          end ATD_INA_DT_ALTA_ADM,                     
          case when MSI.TIS_MSI_CD_TIPOALTA = 4 then INA.ATD_INA_HR_ALTA_CLINICA  
          else         INA.ATD_INA_HR_ALTA_ADM end ATD_INA_HR_ALTA_ADM,          
          CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL
  FROM    ' || v_tabela || ' CCI,
          TB_CAD_PAC_PACIENTE PAC,
          TB_CAD_CNV_CONVENIO CNV,
          TB_CAD_PES_PESSOA PES,
          TB_ATD_ATE_ATENDIMENTO ATE,
          TB_ATD_INA_INT_ALTA INA,
          TB_TIS_MSI_MOTIVO_SAIDA_INT MSI
  WHERE
          CCI.ATD_ATE_ID = ATE.ATD_ATE_ID
          AND MSI.TIS_MSI_CD_MOTIVOSAIDAINT(+) = INA.TIS_MSI_CD_MOTIVOSAIDAINT
          AND CCI.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
          AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
          AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
          AND INA.ATD_ATE_ID(+) = ATE.ATD_ATE_ID
					AND CCI.FAT_CCI_FL_STATUS =' || CHR(39) || 'A' || CHR(39) || '
          AND ATE.ATD_ATE_ID = ' || pATD_ATE_ID;
  OPEN V_CURSOR FOR
	v_select;
  IO_CURSOR := V_CURSOR;
END PRC_FAT_CCI_CONV_CONSUMO_S;
 