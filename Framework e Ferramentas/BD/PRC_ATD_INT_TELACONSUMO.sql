CREATE OR REPLACE PROCEDURE "PRC_ATD_INT_TELACONSUMO"
  (
     pATD_ATE_ID            IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  v_sUnidade          TB_CAD_UNI_UNIDADE.CAD_UNI_DS_UNIDADE%TYPE;
  v_sLocal            TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_DS_LOCAL_ATENDIMENTO%TYPE;
  v_sSetor            TB_CAD_SET_SETOR.CAD_SET_DS_SETOR%TYPE;
  v_idtSetor          TB_CAD_SET_SETOR.CAD_SET_ID%TYPE;
  v_sNomePaciente     TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%TYPE;
  v_sConvenio         VARCHAR2(200);
  v_sPlano            VARCHAR2(200);
  v_sCategoria        VARCHAR2(50);
  v_dataAtendimento   DATE;
  v_sProntuario       TB_CAD_PAC_PACIENTE.CAD_PAC_NR_PRONTUARIO%TYPE;
  v_idtPaciente       TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE;
  v_cTipoPaciente     TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE;
  v_sTipoAcomodacao   TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_DS_TIPO_ACOMODACAO%TYPE;
  v_nQuarto           TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_NR_QUARTO%TYPE;
  v_nLeito            TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_NR_LEITO%TYPE;
  v_dataAlta          DATE;
  v_sSetorQuartoLeito TB_CAD_SET_SETOR.CAD_SET_DS_SETOR%TYPE;
  v_idtSetorQuartoLeito TB_CAD_SET_SETOR.CAD_SET_ID%TYPE;
  v_erro              NUMBER;
  v_dataPesquisaIml   DATE;
  v_dataMaisAtualIml  DATE;
  v_sCortesia         VARCHAR2(100);
  v_sClinica          VARCHAR2(100);
  v_sTipoAtendimento  VARCHAR2(100);
  v_repouso           VARCHAR2(100);
  v_iLocal            TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE;
  v_cursor            PKG_CURSOR.t_cursor;
  begin
    begin
      select fnc_juntar_data_hora(ate.atd_ate_dt_atendimento, ate.atd_ate_hr_atendimento),
             cnv.cad_cnv_cd_hac_prestador || ' / ' ||  cnv.cad_cnv_nm_fantasia,
             pla.cad_pla_cd_plano_hac || ' / ' || pla.cad_pla_nm_nome_plano,
             DECODE(pla.cad_pla_ct_categoria_plano,'INF','INFERIOR',
                                                   'SUP','SUPERIOR',
                                                   'COM','COMMUNITY',
                                                   'MID','MIDMARKET',
                                                   'PRE','PREMIUM',
                                                   '') cad_pla_ct_categoria_plano,
             uni.cad_uni_ds_unidade,
             str.cad_set_ds_setor,
             str.cad_set_id,
             lat.cad_lat_id_local_atendimento,
             lat.cad_lat_ds_local_atendimento,
             pac.cad_pac_nr_prontuario,
             pes.cad_pes_nm_pessoa,
             ate.atd_ate_tp_paciente,
             pac.cad_pac_id_paciente,
             pcli.cad_pes_nm_pessoa as nomeclinica,
             tat.tis_tat_ds_tpatendimento,
             decode(ate.atd_ate_dt_ini_repouso, null, '', to_char(ate.atd_ate_dt_ini_repouso, 'dd/MM/yy HH24:mi') || ' - ')
             || nvl(to_char(ate.atd_ate_dt_fim_repouso, 'dd/MM/yy HH24:mi'), '')
        into v_dataAtendimento,
             v_sConvenio,
             v_sPlano,
             v_sCategoria,
             v_sUnidade,
             v_sSetor,
             v_idtSetor,
             v_iLocal,
             v_sLocal,
             v_sProntuario,
             v_sNomePaciente,
             v_cTipoPaciente,
             v_idtPaciente,
             v_sClinica,
             v_sTipoAtendimento,
             v_repouso
        from tb_atd_ate_atendimento       ate,
             tb_cad_uni_unidade           uni,
             tb_cad_set_setor             str,
             tb_cad_pac_paciente          pac,
             tb_cad_lat_local_atendimento lat,
             tb_cad_cnv_convenio          cnv,
             tb_cad_pla_plano             pla,
             tb_cad_pes_pessoa            pes,
             tb_cad_clc_clinica_credenciada clc,
             tb_cad_pes_pessoa            pcli,
             tb_tis_tat_tp_atendimento    tat
       where ate.cad_uni_id_unidade = uni.cad_uni_id_unidade
         and ate.cad_set_id = str.cad_set_id
         and ate.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
         and pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
         and pla.cad_pla_id_plano = pac.cad_pla_id_plano
         and pac.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
         and ate.atd_ate_id = pATD_ATE_ID
         and pac.cad_pac_id_paciente = fnc_buscar_paciente_atual(ate.atd_ate_id)
         and ate.codcli     = clc.cad_clc_id(+)
         and clc.cad_pes_id_pessoa = pcli.cad_pes_id_pessoa(+)
         and ate.tis_tat_cd_tpatendimento = tat.tis_tat_cd_tpatendimento;
    exception when others then
        v_erro := 1;
    end;
    /* Verificar DataHora da Alta*/
    begin
       select fnc_juntar_data_hora(ina.atd_ina_dt_alta_adm, ina.atd_ina_hr_alta_adm)
         into v_dataAlta
         from tb_atd_ina_int_alta ina
        where ina.atd_ate_id = pATD_ATE_ID;
    exception when others then
        v_erro := 1;
    end;
    /* Verificar DataHora da ultima movimentacao */
    begin
        select max(fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada))
         into v_dataMaisAtualIml
         from tb_atd_iml_int_mov_leito iml
        where iml.atd_ate_id = pATD_ATE_ID;
    exception when others then
        v_erro := 1;
    end;
    if v_dataAlta is not null then
    /* Se existir alta, deve procurar na IML com data 1min anterior a alta */
       v_dataPesquisaIml := (v_dataAlta - (1/1440));
    else
       if v_dataMaisAtualIml is not null then
          /* Utilizar a data mais atual da IML */
          v_dataPesquisaIml := v_dataMaisAtualIml;
       else
          /* Se nao, usa data do atendimento */
          v_dataPesquisaIml := v_dataAtendimento;
       end if;
    end if;
    begin
      select qle.cad_qle_nr_quarto,
             qle.cad_qle_nr_leito,
             tac.tis_tac_ds_tipo_acomodacao,
             str.cad_set_ds_setor,
             str.cad_set_id,
             /* Exibir Descricao do Tipo de Cortesia */
             decode(iml.atd_iml_fl_cortesia, 'S', '/CORTESIA', decode(iml.atd_iml_fl_dif_classe, 'S', '/DIFERENCA DE CLASSE', decode(iml.atd_iml_fl_falta_vaga, 'S', '/FALTA DE VAGA', ''))) cortesia
        into v_nQuarto,
             v_nLeito,
             v_sTipoAcomodacao,
             v_sSetorQuartoLeito,
             v_idtSetorQuartoLeito,
             v_sCortesia
        from tb_atd_iml_int_mov_leito   iml,
             tb_cad_qle_quarto_leito    qle,
             tb_tis_tac_tipo_acomodacao tac,
             tb_cad_set_setor str
       where iml.atd_ate_id = pATD_ATE_ID
         and iml.cad_cad_qle_id = qle.cad_qle_id
         and iml.tis_tac_cd_tipo_acomodacao = tac.tis_tac_cd_tipo_acomodacao
         and qle.cad_set_id = str.cad_set_id
         and fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada) <= v_dataPesquisaIml
         and (fnc_juntar_data_hora(iml.atd_iml_dt_saida, iml.atd_iml_hr_saida) > v_dataPesquisaIml or (iml.atd_iml_dt_saida is null));
    exception when others then
       v_erro := 1;
    end;
    /* Exibir o setor da Internacao ou do Atendimento*/
    if ((v_cTipoPaciente = 'I' or v_cTipoPaciente = 'E') and  v_sSetorQuartoLeito is not null) then
       v_sSetor := v_sSetorQuartoLeito;
       v_idtSetor := v_idtSetorQuartoLeito;
    end if;

    if(length(v_repouso) > 0) then
        v_sTipoAcomodacao := 'REPOUSO PRONTO SOCORRO';
    end if;

    OPEN v_cursor FOR
         select v_sNomePaciente                         as cad_pes_nm_pessoa,
                pATD_ATE_ID                             as atd_ate_id,
                v_dataAtendimento                       as atd_ate_dt_atendimento,
                v_sConvenio                             as cad_cnv_nm_fantasia,
                v_sPlano                                as cad_pla_nm_nome_plano,
                v_sUnidade                              as cad_uni_ds_unidade,
                v_sLocal                                as cad_lat_ds_local_atendimento,
                v_sSetor                                as cad_set_ds_setor,
                v_idtSetor                              as cad_set_id,
                v_sNomePaciente                         as cad_pes_nm_pessoa,
                v_sProntuario                           as cad_pac_nr_prontuario,
                v_sTipoAcomodacao || v_sCortesia        as tis_tac_ds_tipo_acomodacao,
                v_nQuarto                               as cad_qle_nr_quarto,
                v_nLeito                                as cad_qle_nr_leito,
                v_dataAlta                              as atd_ina_dt_alta_adm,
                v_idtPaciente                           as cad_pac_id_paciente,
                v_sClinica                              as nomeclinica,
                v_sTipoAtendimento                      as tis_tat_ds_tpatendimento,
                v_iLocal                                as cad_lat_id_local_atendimento,
                v_repouso                               as repouso,
                v_sCategoria                            as cad_pla_ct_categoria_plano
           from dual;
    io_cursor := v_cursor;
end PRC_ATD_INT_TELACONSUMO;