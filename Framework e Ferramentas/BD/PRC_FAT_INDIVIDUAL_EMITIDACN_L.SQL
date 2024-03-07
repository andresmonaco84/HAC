CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_INDIVIDUAL_EMITIDACN_L"
(
  pATD_ATE_ID          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
  pCAD_CNV_ID_CONVENIO IN TB_CAD_PAC_PACIENTE.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
  IO_CURSOR            OUT PKG_CURSOR.T_CURSOR
) 
  IS
/* Marcus Relva - 16/05/2013 - Integracao com historico */
  V_CURSOR PKG_CURSOR.T_CURSOR;
	v_select varchar2(30000);
	v_tabela varchar2(100);
  begin
	select case when count(1) > 0 then ' TB_FAT_CCI_CONTA_CONSU_ITEM ' else ' TB_FAT_CIH_ITEM_HISTORICO ' end as tabela 
	into v_tabela
	from tb_fat_cci_conta_consu_item cci
	where cci.atd_ate_id = pATD_ATE_ID 
	and cci.fat_ccp_id is not null;
 v_select := ' SELECT DISTINCT ATE.ATD_ATE_ID,
                    ATE.ATD_ATE_TP_PACIENTE,
                    PES.CAD_PES_NM_PESSOA,
                    ATE.ATD_ATE_DT_ATENDIMENTO,
                    ATE.ATD_ATE_HR_ATENDIMENTO,
                    NULL,
                    NULL,
                    CCP.FAT_COC_ID,
                    CCP.FAT_CCP_ID,
                    NOF.FAT_NOF_NR_NOTAFISCAL,
                    PAC.CAD_PAC_ID_PACIENTE,
                    PAC.CAD_CNV_ID_CONVENIO,
                    CCI.FAT_CCP_ID,
                    CCI.FAT_COC_ID,
                    CID10.CAD_CID_DS_CID10     
      FROM TB_ATD_ATE_ATENDIMENTO      ATE,
           TB_FAT_MCC_MOV_COM_CONSUMO  MCC,
           '|| v_tabela ||' CCI,
           TB_FAT_COC_CONTA_CONSUMO    COC,
           TB_FAT_CCP_CONTA_CONS_PARC  CCP,
           TB_CAD_PAC_PACIENTE         PAC,
           TB_CAD_PES_PESSOA           PES,
           TB_FAT_NOF_NOTA_FISCAL      NOF,
           TB_CAD_CID_CID10            CID10
     WHERE ATE.ATD_ATE_ID = ' || pATD_ATE_ID ||'
       AND PAC.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO || ' 
       AND ATE.CAD_CID_CD_CID10 = CID10.CAD_CID_CD_CID10(+)
       AND CCP.FAT_NOF_ID = NOF.FAT_NOF_ID(+)
       AND MCC.ATD_ATE_ID = ATE.ATD_ATE_ID       
       AND CCI.FAT_MCC_ID = MCC.FAT_MCC_ID
       AND CCI.ATD_ATE_ID = MCC.ATD_ATE_ID
       AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND COC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND COC.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND CCP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_CCP_ID = CCP.FAT_CCP_ID
       AND CCI.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCI.ATD_ATE_ID = ATE.ATD_ATE_ID       
       AND ATE.ATD_ATE_TP_PACIENTE IN (' ||chr(39)|| 'A' ||chr(39)|| ', ' ||chr(39)|| 'U' ||chr(39)|| ')
       AND ATE.ATD_ATE_FL_STATUS = ' ||chr(39)|| 'A' ||chr(39)|| '
       AND MCC.FAT_MCC_FL_STATUS = ' ||chr(39)|| 'A' ||chr(39)|| '
       AND CCI.FAT_CCI_FL_STATUS = ' ||chr(39)|| 'A' ||chr(39)|| '       
       AND CCI.FAT_CCP_ID IS NOT NULL
       AND CCI.FAT_COC_ID IS NOT NULL
       AND CCP.FAT_CCP_FL_FATURADA = ' ||chr(39)|| 'S' ||chr(39)|| '
    UNION ALL
    SELECT DISTINCT ATE.ATD_ATE_ID,
                    ATE.ATD_ATE_TP_PACIENTE,
                    PES.CAD_PES_NM_PESSOA,
                    ATE.ATD_ATE_DT_ATENDIMENTO,
                    ATE.ATD_ATE_HR_ATENDIMENTO,
                    INA.ATD_INA_DT_ALTA_ADM,
                    INA.ATD_INA_HR_ALTA_ADM,
                    CCP.FAT_COC_ID,
                    CCP.FAT_CCP_ID,
                    NOF.FAT_NOF_NR_NOTAFISCAL,
                    PAC.CAD_PAC_ID_PACIENTE,
                    PAC.CAD_CNV_ID_CONVENIO,
                    CCI.FAT_CCP_ID,
                    CCI.FAT_COC_ID,
                    CID10.CAD_CID_DS_CID10     
      FROM TB_ATD_ATE_ATENDIMENTO      ATE,
           TB_ATD_AIC_ATE_INT_COMPL    AIC,
           TB_ATD_INA_INT_ALTA         INA,
           TB_FAT_MCC_MOV_COM_CONSUMO  MCC,
                      '|| v_tabela ||' CCI,
           TB_FAT_COC_CONTA_CONSUMO    COC,
           TB_FAT_CCP_CONTA_CONS_PARC  CCP,
           TB_CAD_PAC_PACIENTE         PAC,
           TB_CAD_PES_PESSOA           PES,
           TB_FAT_NOF_NOTA_FISCAL      NOF,
           TB_CAD_CID_CID10            CID10
     WHERE ATE.ATD_ATE_ID = ' || pATD_ATE_ID || '
       AND PAC.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO || '
       AND ATE.CAD_CID_CD_CID10 = CID10.CAD_CID_CD_CID10(+)
       AND CCP.FAT_NOF_ID = NOF.FAT_NOF_ID(+)
       AND AIC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND INA.ATD_ATE_ID(+) = AIC.ATD_ATE_ID
       AND MCC.ATD_ATE_ID = ATE.ATD_ATE_ID       
       AND CCI.FAT_MCC_ID = MCC.FAT_MCC_ID
       AND CCI.ATD_ATE_ID = MCC.ATD_ATE_ID
       AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND COC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND COC.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND CCP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_CCP_ID = CCP.FAT_CCP_ID
       AND CCI.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCI.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND ATE.ATD_ATE_TP_PACIENTE IN (' ||chr(39)|| 'I' ||chr(39)|| ', ' ||chr(39)|| 'E' ||chr(39)|| ')
       AND ATE.ATD_ATE_FL_STATUS = ' ||chr(39)|| 'A' ||chr(39)|| '
       AND MCC.FAT_MCC_FL_STATUS = ' ||chr(39)|| 'A' ||chr(39)|| '
       AND CCI.FAT_CCI_FL_STATUS = ' ||chr(39)|| 'A' ||chr(39)|| '
       AND (CCI.FAT_FL_PENDENTE_AUTORIZA = ' ||chr(39)|| 'A' ||chr(39)|| ' OR CCI.FAT_FL_PENDENTE_AUTORIZA IS NULL)
       AND CCI.FAT_CCP_ID IS NOT NULL
       AND CCI.FAT_COC_ID IS NOT NULL       
       AND CCP.FAT_CCP_FL_FATURADA = ' ||chr(39)|| 'S' ||chr(39);			 
 OPEN V_CURSOR FOR
	v_select; 
  IO_CURSOR := V_CURSOR;
END PRC_FAT_INDIVIDUAL_EMITIDACN_L;
