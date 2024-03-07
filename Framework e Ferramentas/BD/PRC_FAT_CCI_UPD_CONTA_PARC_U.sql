CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_CCI_UPD_CONTA_PARC_U"(pATD_ATE_ID           IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
                                                           pCAD_PAC_ID_PACIENTE  IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE DEFAULT NULL,
                                                           pFAT_CCI_DT_HR_LIMITE IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCI_DT_INICIO_CONSUMO%TYPE DEFAULT NULL,
                                                           pFAT_CCP_ID           IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCP_ID%TYPE DEFAULT NULL,
                                                           pFAT_COC_ID           IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_COC_ID%TYPE DEFAULT NULL) IS
  /********************************************************************
  *    Procedure: PRC_FAT_CCI_UPD_CONTA_PARC_U
  *
  *    Data Alteracao: 04/08/2010  Por: Caio
  *    Data Alteracao: 21/08/2010 - Nao considerar diaria-1 se tiver alta
  *    Alterac?o:
  *
  *******************************************************************/
  vDataAlta          Date;
  vDataSaidaPAT      Date;
  vTipoPaciente      varchar(1);
  vQtDiaContaParcial number;
BEGIN
  select ate.atd_ate_tp_paciente
    into vTipoPaciente
    from tb_atd_ate_atendimento ate
   where ate.atd_ate_id = pATD_ATE_ID;
  if (vTipoPaciente = 'I') then
    begin
      select  case when msi.tis_msi_cd_tipoalta = 4 then ina.atd_ina_dt_alta_clinica else ina.atd_ina_dt_alta_adm end
        into vDataAlta
        from tb_atd_ina_int_alta ina, tb_tis_msi_motivo_saida_int msi
       where ina.atd_ate_id = pATD_ATE_ID;
    exception
      when others then
        vDataAlta := null;
    end;
    begin
      select pat.ass_pat_dt_saida
        into vDataSaidaPAT
        from tb_ass_pat_pacieatend pat
       where pat.atd_ate_id = pATD_ATE_ID
         and pat.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
         and rownum = 1;
    exception
      when others then
        vDataSaidaPAT := null;
    end;
    if (vDataSaidaPAT is not null) then
      vDataAlta := vDataSaidaPAT;
    end if;
  end if;
  begin
    select nvl(cnv.cad_cnv_qt_dia_conta_parcial, 0)
      into vQtDiaContaParcial
      from tb_cad_cnv_convenio cnv, tb_cad_pac_paciente pac
     where cnv.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
       and pac.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE;
  exception
    when others then
      vQtDiaContaParcial := 0;
  end;
  if ((vDataAlta is null OR
     trunc(vDataAlta) <> trunc(pFAT_CCI_DT_HR_LIMITE)) AND
     vTipoPaciente = 'I' AND vQtDiaContaParcial <> 0) then
    UPDATE (SELECT FAT_CCP_ID, FAT_COC_ID
              FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI
              JOIN TB_FAT_MCC_MOV_COM_CONSUMO MCC
                ON CCI.FAT_MCC_ID = MCC.FAT_MCC_ID
              LEFT JOIN TB_CAD_MPF_MOTI_PEND_FATURAR MPF
                ON CCI.CAD_MPF_ID = MPF.CAD_MPF_ID
             WHERE MCC.FAT_COC_FL_FATURADO = 'N'
               AND MCC.FAT_MCC_FL_STATUS = 'A'
               AND CCI.FAT_CCI_FL_STATUS = 'A'
               AND (CCI.CAD_MPF_ID IS NULL OR MPF.CAD_MPF_FL_MOTIVO = 'J')
               AND CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H', 'T')
               AND CCI.ATD_ATE_ID = pATD_ATE_ID
               AND CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
               AND CCI.FAT_CCP_ID IS NULL
               AND ((cci.cad_lat_id_local_atendimento <> 46 and
							       CCI.CAD_TAP_TP_ATRIBUTO != 'DIA' AND FNC_JUNTAR_DATA_HORA(CCI.FAT_CCI_DT_INICIO_CONSUMO, CCI.FAT_CCI_HR_INICIO_CONSUMO) <= pFAT_CCI_DT_HR_LIMITE - 1)
									 OR ((CCI.CAD_TAP_TP_ATRIBUTO IN ('DIA','PCT') or cci.cad_lat_id_local_atendimento = 46) AND FNC_JUNTAR_DATA_HORA(CCI.FAT_CCI_DT_INICIO_CONSUMO, CCI.FAT_CCI_HR_INICIO_CONSUMO) <=  pFAT_CCI_DT_HR_LIMITE))) CCI
       SET FAT_CCP_ID = pFAT_CCP_ID, FAT_COC_ID = pFAT_COC_ID;
  else
    UPDATE (SELECT FAT_CCP_ID, FAT_COC_ID
              FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI
              JOIN TB_FAT_MCC_MOV_COM_CONSUMO MCC
                ON CCI.FAT_MCC_ID = MCC.FAT_MCC_ID
              LEFT JOIN TB_CAD_MPF_MOTI_PEND_FATURAR MPF
                ON CCI.CAD_MPF_ID = MPF.CAD_MPF_ID
             WHERE MCC.FAT_COC_FL_FATURADO = 'N'
               AND MCC.FAT_MCC_FL_STATUS = 'A'
               AND CCI.FAT_CCI_FL_STATUS = 'A'
               AND (CCI.CAD_MPF_ID IS NULL OR MPF.CAD_MPF_FL_MOTIVO = 'J')
               AND CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H', 'T')
               AND CCI.ATD_ATE_ID = pATD_ATE_ID
               AND CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
               AND CCI.FAT_CCP_ID IS NULL) CCI
       SET FAT_CCP_ID = pFAT_CCP_ID, FAT_COC_ID = pFAT_COC_ID;
  end if;
  /* Se nao houver nenhum item para parcela, deletar parcela*/
  if (sql%notfound) then
    delete tb_fat_ccp_conta_cons_parc ccp
     where ccp.atd_ate_id = pATD_ATE_ID
       and ccp.fat_coc_id = pFAT_COC_ID
       and ccp.fat_ccp_id = pFAT_CCP_ID
       and ccp.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE;
  end if;
END PRC_FAT_CCI_UPD_CONTA_PARC_U;
