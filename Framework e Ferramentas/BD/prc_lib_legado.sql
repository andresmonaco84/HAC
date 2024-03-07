create or replace procedure prc_lib_legado(idtatendimento in number) is

  mes     number;
  ano     number;
  unihos  varchar2(10);
  datasol date;
  codcon  varchar2(10);
begin

begin

  select uni.cad_uni_cd_unid_hospitalar,
         pap.ass_pap_dt_solic,
         decode(cnv.cad_cnv_cd_hac_prestador,
                'SD01',
                pla.cad_pla_cd_plano_hac,
                cnv.cad_cnv_cd_hac_prestador)
    into unihos, datasol, codcon
    from tb_ass_pap_pac_aten_proc pap
    join tb_cad_pac_paciente pac
      on pap.cad_pac_id_paciente = pac.cad_pac_id_paciente
    join tb_cad_uni_unidade uni
      on pap.cad_uni_id_unidade = uni.cad_uni_id_unidade
    join tb_cad_cnv_convenio cnv
      on pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
    join tb_cad_pla_plano pla
      on pac.cad_pla_id_plano = pla.cad_pla_id_plano
   where pap.atd_ate_id = idtatendimento
   and   pap.ass_pap_fl_status_autor = 'A'
   and   rownum = 1;

  DSADT.PKG_FATURAMENTO.BUSCA_MES_ANO_REFERENCIA(unihos,
                                                 codcon,
                                                 datasol,
                                                 'AMB',
                                                 mes,
                                                 ano);

  PRC_LEG_ATU_ATEAMB_LIB_I(idtatendimento, mes, ano, 1);
exception when others then
--nao encontrou
select sysdate into datasol from dual;
end;

end;
