-- Add/modify columns 
alter table TB_CTS_RES_RESUMO_GERAL add cts_res_resu_cod_descricao NUMBER(3);
alter table TB_CTS_RES_RESUMO_GERAL add cts_res_resu_vl_pacientes_dia NUMBER(12,2);
-- Add comments to the columns 
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_cod_descricao
  is 'CodigoDescricao';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_vl_pacientes_dia
  is 'ValorPacientesDia';