CREATE OR REPLACE PROCEDURE "PRC_FAT_INCLUIR_NOF_CNV"
(
  pNUMERONF in varchar2,
  pSERIENF in varchar2,
  pSEG_USU_ID_USUARIO in number,
  pFAT_LNF_ID_SPLIT in varchar2,
  pCAD_UNI_ID_UNIDADE in number,
  pCAD_CNV_ID_CONVENIO in number,
  pPERCENTUALISS in number,
  pPERCENTUALPIS in number,
  pPERCENTUALCOFINS in number,
  pPERCENTUALCSLL in number,
  pPERCENTUALIR in number,
  pVALORISS in number,
  pVALORPIS in number,
  pVALORCOFINS in number,
  pVALORCSLL in number,
  pVALORIR in number,
  pVALORLIQUIDO in number,
  pDATAVENCIMENTO in date,
  pAMBINT in varchar2,
  pFAT_NOF_NR_DOCUMENTO in number default null,
  pFAT_NOF_NR_PROTOCOLO_ENVIO in varchar2 default null,
  pFAT_NOF_VL_NOTAFISCAL in number default null
)
IS
v_idnof number;
v_valor_nf number := 0;
v_mes number;
v_ano number;
v_codcfo varchar2(25);
v_codunihos number;
v_codcon varchar2(10);
v_lote number;
v_ret number;
v_municipio varchar2(200);
v_inscricaomunicipal varchar2(100);
v_tipoempresa varchar2(10);
v_cad_cur_cd_referenciado number;
v_verifica_valor_nf number;
BEGIN

if(pFAT_NOF_VL_NOTAFISCAL is not null and pFAT_NOF_VL_NOTAFISCAL > 0) then
    v_verifica_valor_nf := pFAT_NOF_VL_NOTAFISCAL;
end if;

  select seq_fat_nof_01.nextval
         into v_idnof
  from dual;
  begin
    select mun.aux_mun_nm_municipio,
    pes.cad_pes_cd_inscr_munic,
    cnv.cad_tpe_cd_codigo
    into v_municipio,
         v_inscricaomunicipal,
         v_tipoempresa
    from tb_cad_uni_unidade uni
    join tb_cad_pes_pessoa pes
    on uni.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
    join tb_cad_end_endereco e
    on pes.cad_pes_id_pessoa = e.cad_pes_id_pessoa
    and e.aux_tte_cd_tp_tel_end = 2
    join tb_aux_mun_municipio mun
    on e.aux_mun_cd_ibge = mun.aux_mun_cd_ibge
    cross join tb_cad_cnv_convenio cnv
    where uni.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
    and cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO;
  exception when others then
     v_municipio := null;
     v_inscricaomunicipal := null;
     v_tipoempresa := null;
  end;
  begin
    select pes.codcfo, cnv.cad_cnv_cd_hac_prestador
    into v_codcfo, v_codcon
    from tb_cad_pes_pessoa pes,
         tb_cad_cnv_convenio cnv
    where cnv.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
    and cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO;
  exception when others then
    raise_application_error(-20000,'NAO FOI POSSIVEL OBTER O CODCFO DO CONVENIO');
  end;
  select uni.cad_uni_cd_unid_hospitalar
  into v_codunihos
  from tb_cad_uni_unidade uni
  where uni.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE;
  if(pAMBINT = 'A') then
   v_lote := 0;
  else
   v_lote := 1;
  end if;
  begin
  select sum(ccp.fat_ccp_vl_tot_conta), ccp.fat_ccp_mes_fat, ccp.fat_ccp_ano_fat
  into v_valor_nf, v_mes, v_ano
  from tb_fat_ccp_conta_cons_parc ccp
  where ccp.fat_nof_id is null
   and ccp.fat_lnf_id in (select column_value from table(fnc_split(pFAT_LNF_ID_SPLIT)))
   and ccp.fat_ccp_fl_status = 'A'
   and ccp.fat_ccp_fl_faturada = 'S'
   group by ccp.fat_ccp_mes_fat, ccp.fat_ccp_ano_fat;
   exception when others then
     raise_application_error(-20001,'ERRO AO OBTER INFORMACOES DOS LOTES');
   end;
--verificar se setor unico para gravar
begin
  select distinct to_number(cur.cad_cur_cd_referenciado)
    into v_cad_cur_cd_referenciado
    from tb_fat_ccp_conta_cons_parc ccp
    join tb_atd_ate_atendimento atd
      on ccp.atd_ate_id = atd.atd_ate_id
      join tb_cad_cur_conv_uni_refer cur
      on cur.cad_set_id = atd.cad_set_id
      and cur.cad_cnv_id_convenio = ccp.cad_cnv_id_convenio
      and cur.cad_uni_id_unidade = ccp.cad_uni_id_unidade
      and ccp.cad_cnv_id_convenio IN (740,3422)
   where ccp.fat_lnf_id in
         (select column_value from table(fnc_split(pFAT_LNF_ID_SPLIT)))
     and ccp.fat_ccp_fl_status = 'A';
exception
  when others then
    v_cad_cur_cd_referenciado := null;
end;
   insert into tb_fat_nof_nota_fiscal
    (CAD_CNV_ID_CONVENIO,
    CAD_MCN_ID,
    CAD_PLA_ID_PLANO,
    CAD_UNI_ID_UNIDADE,
    FAT_NFO_DT_EMISSAO,
    FAT_NFO_DT_VENCIMENTO,
    FAT_NFO_VL_FATURADO,
    FAT_NFO_VL_LIQUIDO,
    FAT_NFO_VL_RETENCAO,
    FAT_NOF_ANO_FAT,
    FAT_NOF_DS_DESCONTO,
    FAT_NOF_DT_CANCELAMENTO,
    FAT_NOF_DT_ULTIMA_ATUALIZACAO,
    FAT_NOF_FL_JURIDICA,
    FAT_NOF_FL_STATUS,
    FAT_NOF_ID,
    FAT_NOF_MES_FAT,
    FAT_NOF_NR_DOCUMENTO,
    FAT_NOF_NR_NOTAFISCAL,
    FAT_NOF_PC_COFINS,
    FAT_NOF_PC_CSLL,
    FAT_NOF_PC_IR,
    FAT_NOF_PC_ISS,
    FAT_NOF_PC_PIS,
    FAT_NOF_TP_SERIEFISCAL,
    FAT_NOF_VL_COFINS,
    FAT_NOF_VL_CSLL,
    FAT_NOF_VL_DESCONTO,
    FAT_NOF_VL_IR,
    FAT_NOF_VL_ISS,
    FAT_NOF_VL_PIS,
    SEG_USU_ID_USUARIO,
    SEG_USU_ID_USUARIO_CANCELA,
    cad_uni_ds_municipio,
    cad_uni_cd_inscr_munic,
    cad_tpe_cd_codigo,
    fat_nof_tp_grupo_pac,
    FAT_NOF_NR_PROTOCOLO_ENVIO,
    fat_nof_vl_notafiscal)
    values
    (pCAD_CNV_ID_CONVENIO,           --CAD_CNV_ID_CONVENIO
    null,                            --CAD_MCN_ID
    null,                            --CAD_PLA_ID_PLANO
    pCAD_UNI_ID_UNIDADE,             --CAD_UNI_ID_UNIDADE
    trunc(sysdate),                  --FAT_NFO_DT_EMISSAO
    pDATAVENCIMENTO,                 --FAT_NFO_DT_VENCIMENTO
    v_valor_nf,                      --FAT_NFO_VL_FATURADO
    pVALORLIQUIDO,                   --FAT_NFO_VL_LIQUIDO
    nvl(v_verifica_valor_nf, v_valor_nf) - pVALORLIQUIDO,      --FAT_NFO_VL_RETENCAO
    v_ano,                           --FAT_NOF_ANO_FAT
    null,                            --FAT_NOF_DS_DESCONTO
    null,                            --FAT_NOF_DT_CANCELAMENTO
    sysdate,                         --FAT_NOF_DT_ULTIMA_ATUALIZACAO
    'S',                             --FAT_NOF_FL_JURIDICA  S
    'A',                             --FAT_NOF_FL_STATUS  A
    v_idnof,                         --FAT_NOF_ID
    v_mes,                           --FAT_NOF_MES_FAT
    v_cad_cur_cd_referenciado,       --FAT_NOF_NR_DOCUMENTO
    pNUMERONF,                       --FAT_NOF_NR_NOTAFISCAL
    pPERCENTUALCOFINS,               --FAT_NOF_PC_COFINS
    pPERCENTUALCSLL,                 --FAT_NOF_PC_CSLL
    pPERCENTUALIR,                   --FAT_NOF_PC_IR
    pPERCENTUALISS,                  --FAT_NOF_PC_ISS
    pPERCENTUALPIS,                  --FAT_NOF_PC_PIS
    pSERIENF,                        --FAT_NOF_TP_SERIEFISCAL  A
    pVALORCOFINS,                    --FAT_NOF_VL_COFINS
    pVALORCSLL,                      --FAT_NOF_VL_CSLL
    null,                            --FAT_NOF_VL_DESCONTO
    pVALORIR,                        --FAT_NOF_VL_IR
    pVALORISS,                       --FAT_NOF_VL_ISS
    pVALORPIS,                       --FAT_NOF_VL_PIS
    pSEG_USU_ID_USUARIO,             --SEG_USU_ID_USUARIO
    null,
    v_municipio,
    v_inscricaomunicipal,
    v_tipoempresa,
    decode(pAMBINT, 'I', 'INT', 'A', 'AMB'),
    pFAT_NOF_NR_PROTOCOLO_ENVIO,
    nvl(pFAT_NOF_VL_NOTAFISCAL, v_valor_nf));
    /*Atualizar CCP*/
    update tb_fat_ccp_conta_cons_parc ccp
        set ccp.fat_nof_id = v_idnof
    where ccp.fat_lnf_id in (select column_value from table(fnc_split(pFAT_LNF_ID_SPLIT)))
    and ccp.fat_ccp_fl_status = 'A' and ccp.fat_nof_id is null;
    /*Atualizar AFR*/
    update tb_fat_afr_atend_fatur_res afr
        set afr.fat_nof_id = v_idnof
    where afr.fat_lnf_id in (select column_value from table(fnc_split(pFAT_LNF_ID_SPLIT)))
    and afr.fat_afr_fl_status = 'A' and afr.fat_nof_id is null;
    /*Incluir no Legado*/
    insert into tb_fatura1 f1
     (codunihos,
      numfat,
      serie,
      codcon,
      numlote,
      servico,
      codhos,
      mesfat,
      anofat,
      cd_matricula,
      datemifat,
      datvenfat,
      in_cancelada,
      nr_nota_cred,
      codtippag,
      valfat,
      valfatdif,
      valfatdes,
      cd_tipo_fatura,
      st_descont_fat,
      cd_ref_descont,
      nr_remessa_salutia,
      nr_duplicata,
      in_nota_eletronica,
      cd_serie_fisica,
      nr_carta_remessa,
      fat_nof_id,
      nr_lote,
      nr_rps)
      values(
      v_codunihos, --codunihos
      pNUMERONF, --numfat
      pSERIENF,--serie
      v_codcon, --codcon
      0, --numlote
      pAMBINT, --servico
      1, --codhos
      v_mes, --mesfat
      v_ano, --anofat
      1101,--cd_matricula
      trunc(sysdate), --datemifat
      pDATAVENCIMENTO, --datvenfat
      'N', --in_cancelada
      null, --nr_nota_cred
      'B',--codtippag
      v_valor_nf, --valfat
      null,--valfatdif
      pVALORLIQUIDO,--valfatdes
      1,--cd_tipo_fatura
      null,--st_descont_fat
      null,--cd_ref_descont
      v_idnof,--nr_remessa_salutia
      null,--nr_duplicata
      null,--in_nota_eletronica
      null,--cd_serie_fisica
      null,--nr_carta_remessa
      v_idnof,--fat_nof_id
      v_lote,--nr_lote
      null);--nr_rps
      if(v_codcon = 'SD01') then
        insert into tb_fatura_psac
        (codunihos, numfat, serie,
         vl_adiantamento, vl_honorarios, vl_exames,
         vl_outros, valfatiss, valretir,
         valcsll, valcofins, valpispasep)
        values
        (v_codunihos, pNUMERONF, pSERIENF,
        0, 0, 0,
        0, pVALORISS, pVALORIR,
        pVALORCSLL, pVALORCOFINS, pVALORPIS);
        else
          if (pVALORLIQUIDO < v_valor_nf) then
            insert into tb_fatura_sp
            (codunihos, numfat, serie,
             valretir, valcoffins, valpispasep,
             valcsll, valfatiss)
            values
            (v_codunihos, pNUMERONF, pSERIENF,
             pVALORIR, pVALORCOFINS, pVALORPIS,
             pVALORCSLL, pVALORISS);
          end if;
      end if;
      PKG_TISS_SGS.ATUALIZA_FATURA_SGS (v_codunihos,
                pNUMERONF,
                pSERIENF,
                v_mes,
                v_ano,
                v_ret);
                PRC_FAT_TISS_ASSOCIAR_NOF(v_idnof, 'S');
begin
      /*Atualizar nas tabelas de cobran¿a*/
      insert into tb_cob_ccp_conta_cons_parc cobi
  (cobi.cob_ccp_id,
   cobi.cob_coc_id,
   cobi.cad_pac_id_paciente,
   cobi.cob_ccp_dt_parcela,
   cobi.cob_ccp_hr_parcela,
   cobi.cob_ccp_vl_tot_conta,
   cobi.cob_ccp_vl_tot_desconto,
   cobi.cob_ccp_pc_tot_desconto,
   cobi.atd_gui_cd_codigo,
   cobi.cob_ccp_mes_fat,
   cobi.cob_ccp_ano_fat,
   cobi.cob_ccp_fl_status,
   cobi.fat_nof_id,
   cobi.cob_ccp_nr_remessa,
   cobi.cob_ccp_dt_ultima_atualizacao,
   cobi.seg_usu_id_usuario,
   cobi.atd_ate_id,
   cobi.cob_ccp_dt_parcela_ini,
   cobi.cob_ccp_hr_parcela_ini,
   cobi.cad_cnv_id_convenio,
   cobi.cad_uni_id_unidade,
   cobi.cad_lat_id_local_atendimento,
   cobi.atd_ate_tp_paciente,
   cobi.atd_gui_dt_validade,
   cobi.atd_gui_cd_senha,
   cobi.cad_pes_nm_pessoa,
   cobi.cob_ccp_vl_ir_faturado,
   cobi.cob_ccp_vl_iss_faturado,
   cobi.cob_ccp_vl_cofins_faturado,
   cobi.cob_ccp_vl_csll_faturado,
   cobi.cob_ccp_vl_pis_faturado,
   cobi.cad_pac_cd_credencial,
   cobi.atd_ate_dt_atendimento)
  (select ccp.fat_ccp_id,
          ccp.fat_coc_id,
          ccp.cad_pac_id_paciente,
          ccp.fat_ccp_dt_parcela,
          ccp.fat_ccp_hr_parcela,
          ccp.fat_ccp_vl_tot_conta,
          ccp.fat_ccp_vl_tot_desconto,
          ccp.fat_ccp_pc_tot_desconto,
          nvl(ccp.atd_gui_cd_codigo,ccp.atd_ate_id) atd_gui_cd_codigo,
          ccp.fat_ccp_mes_fat,
          ccp.fat_ccp_ano_fat,
          ccp.fat_ccp_fl_status,
          ccp.fat_nof_id,
          ccp.fat_ccp_nr_remessa,
          ccp.fat_ccp_dt_ultima_atualizacao,
          ccp.seg_usu_id_usuario,
          ccp.atd_ate_id,
          ccp.fat_ccp_dt_parcela_ini,
          ccp.fat_ccp_hr_parcela_ini,
          ccp.cad_cnv_id_convenio,
          ccp.cad_uni_id_unidade,
          ccp.cad_lat_id_local_atendimento,
          ccp.atd_ate_tp_paciente,
          nvl(ccp.atd_gui_dt_validade,ccp.fat_ccp_dt_parcela) atd_gui_dt_validade,
          nvl(nvl(tiss_s.cd_senha, tiss_i.cd_senha),ccp.atd_gui_cd_senha) as atd_gui_cd_senha,
          pes.cad_pes_nm_pessoa,
          (fat_ccp_vl_tot_conta * nof.fat_nof_pc_ir) / 100 cob_ccp_vl_ir_faturado,
          (fat_ccp_vl_tot_conta * nof.fat_nof_pc_iss) / 100 cob_ccp_vl_iss_faturado,
          (fat_ccp_vl_tot_conta * nof.fat_nof_pc_cofins) / 100 cob_ccp_vl_cofins_faturado,
          (fat_ccp_vl_tot_conta * nof.fat_nof_pc_csll) / 100 cob_ccp_vl_csll_faturado,
          (fat_ccp_vl_tot_conta * nof.fat_nof_pc_pis) / 100 cob_ccp_vl_pis_faturado,
          pac.cad_pac_cd_credencial,
          ate.atd_ate_dt_atendimento
     from tb_fat_ccp_conta_cons_parc ccp,
          tb_fat_nof_nota_fiscal     nof,
          tb_cad_cnv_convenio        cnv,
          tb_cad_pac_paciente        pac,
          tb_cad_pes_pessoa          pes,
          tb_atd_ate_atendimento     ate,
          tss_spsadt_sgs_v3          tiss_s,
          tss_resumo_int_sgs_v3      tiss_i
    where ccp.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
      and ccp.atd_ate_id = ate.atd_ate_id
      and cnv.cad_cnv_cd_opcao_pagto = 1
      and pac.cad_pac_id_paciente = ccp.cad_pac_id_paciente
      and pac.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
      and ccp.fat_nof_id = nof.fat_nof_id
      and nof.fat_nof_id = v_idnof
      and ccp.atd_ate_id = tiss_s.nr_atendimento(+)
      and ccp.cad_pac_id_paciente = tiss_s.idt_paciente(+)
      and ccp.fat_ccp_id = tiss_s.cd_parcela(+)
      and ccp.atd_ate_id = tiss_i.nr_atendimento(+)
      and ccp.cad_pac_id_paciente = tiss_i.idt_paciente(+)
      and ccp.fat_ccp_id = tiss_i.cd_parcela(+)
      and not exists
    (select cob.cob_ccp_id,
                  cob.cob_coc_id,
                  cob.cad_pac_id_paciente,
                  cob.cob_ccp_dt_parcela,
                  cob.cob_ccp_hr_parcela,
                  cob.cob_ccp_vl_tot_conta,
                  cob.cob_ccp_vl_tot_desconto,
                  cob.cob_ccp_pc_tot_desconto,
                  cob.atd_gui_cd_codigo,
                  cob.cob_ccp_mes_fat,
                  cob.cob_ccp_ano_fat,
                  cob.cob_ccp_fl_status,
                  cob.fat_nof_id,
                  cob.cob_ccp_nr_remessa,
                  cob.cob_ccp_dt_ultima_atualizacao,
                  cob.seg_usu_id_usuario,
                  cob.atd_ate_id,
                  cob.cob_ccp_dt_parcela_ini,
                  cob.cob_ccp_hr_parcela_ini,
                  cob.cad_cnv_id_convenio,
                  cob.cad_uni_id_unidade,
                  cob.cad_lat_id_local_atendimento,
                  cob.atd_ate_tp_paciente,
                  cob.atd_gui_dt_validade,
                  cob.atd_gui_cd_senha,
                  cob.cad_pes_nm_pessoa,
                  cob.cob_ccp_vl_ir_faturado,
                  cob.cob_ccp_vl_iss_faturado,
                  cob.cob_ccp_vl_cofins_faturado,
                  cob.cob_ccp_vl_csll_faturado,
                  cob.cob_ccp_vl_pis_faturado,
                  cob.cad_pac_cd_credencial,
                  cob.atd_ate_dt_atendimento
             from tb_cob_ccp_conta_cons_parc cob
            where cob.cob_ccp_id = ccp.fat_ccp_id
              and cob.atd_ate_id = ccp.atd_ate_id
              and cob.cad_pac_id_paciente = ccp.cad_pac_id_paciente
              and cob.cob_coc_id = ccp.fat_coc_id));
   exception when others then
     raise_application_error(-20002,'ERRO AO GRAVAR INFORMACOES DE COBRANCA');
   end;
end PRC_FAT_INCLUIR_NOF_CNV;