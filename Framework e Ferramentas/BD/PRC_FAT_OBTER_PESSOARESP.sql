create or replace procedure PRC_FAT_OBTER_PESSOARESP
                              (pCAD_PES_ID_PESSOA in TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%TYPE,
                               io_cursor          out PKG_CURSOR.t_cursor) is
  v_cursor PKG_CURSOR.t_cursor;
  v_flag_juridica varchar(1);
begin
 select pes.cad_pes_fl_juridica_ok
 into   v_flag_juridica
 from tb_cad_pes_pessoa pes
 where pes.cad_pes_id_pessoa = pCAD_PES_ID_PESSOA;
 if(v_flag_juridica IS NULL OR v_flag_juridica = 'N') then
  OPEN v_cursor FOR     
 select       pes.cad_pes_id_pessoa,
              pes.cad_pes_nm_pessoa,
              to_char(pes.cad_pes_dt_nascimento, 'dd/MM/yyyy') as cad_pes_dt_nascimento,
              lpad(pes.cad_pes_nr_cnpj_cpf,11,'0') as cad_pes_nr_cnpj_cpf,
              pes.cad_pes_nr_rg,
              pes.cad_pes_cd_orgaoemissorrg,
              ede.cad_end_cd_cep,
              ede.cad_end_ds_complemento,
              ede.cad_end_nm_bairro,
              ede.cad_end_sg_uf,
              ede.cad_end_ds_numero,
              ede.cad_end_nm_logradouro,
              tel.cad_tel_nr_num_tel,
              cel.cad_tel_nr_num_tel as cel,
              email.ass_pem_id_pessoa_email idemail,
              email.ass_pem_nm_email email,
              substr(ede.aux_mun_cd_ibge, 3, 5) as aux_mun_cd_ibge,
              pes.codcfo,
              mun.aux_mun_nm_municipio,
              pes.aux_nac_cd_codigo,
              pes.cad_pes_tp_sexo,
              pes.cad_pes_fl_juridica_ok
         from tb_cad_pes_pessoa pes
         left join tb_cad_end_endereco ede
           on pes.cad_pes_id_pessoa = ede.cad_pes_id_pessoa
         left join tb_aux_mun_municipio mun
           on ede.aux_mun_cd_ibge = mun.aux_mun_cd_ibge
         left join tb_cad_tel_telefone tel
           on pes.cad_pes_id_pessoa = tel.cad_pes_id_pessoa
          and tel.aux_tte_cd_tp_tel_end <> 8
         left join tb_cad_tel_telefone cel
           on pes.cad_pes_id_pessoa = cel.cad_pes_id_pessoa
          and cel.aux_tte_cd_tp_tel_end = 8         
          left join tb_ass_pem_pessoa_email email
           on pes.cad_pes_id_pessoa = email.cad_pes_id_pessoa 
        where pes.cad_pes_id_pessoa = pCAD_PES_ID_PESSOA;
else
 OPEN v_cursor FOR 
   select     pes.cad_pes_id_pessoa,
              pes.cad_pes_nm_pessoa,
              to_char(pes.cad_pes_dt_nascimento, 'dd/MM/yyyy') as cad_pes_dt_nascimento,
              lpad(pes.cad_pes_nr_cnpj_cpf,14,'0') as cad_pes_nr_cnpj_cpf,
              pes.cad_pes_nr_rg,
              pes.cad_pes_cd_orgaoemissorrg,
              ede.cad_end_cd_cep,
              ede.cad_end_ds_complemento,
              ede.cad_end_nm_bairro,
              ede.cad_end_sg_uf,
              ede.cad_end_ds_numero,
              ede.cad_end_nm_logradouro,
              tel.cad_tel_nr_num_tel,
              cel.cad_tel_nr_num_tel as cel,
              substr(ede.aux_mun_cd_ibge, 3, 5) as aux_mun_cd_ibge,
              pes.codcfo,
              mun.aux_mun_nm_municipio,
              pes.aux_nac_cd_codigo,
              pes.cad_pes_tp_sexo,
              email.ass_pem_id_pessoa_email idemail,
              email.ass_pem_nm_email email,
              pes.cad_pes_fl_juridica_ok
    from tb_cad_pes_pessoa pes
  left join tb_cad_end_endereco ede
    on pes.cad_pes_id_pessoa = ede.cad_pes_id_pessoa
   and ede.aux_tte_cd_tp_tel_end = 2
  left join tb_aux_mun_municipio mun
    on ede.aux_mun_cd_ibge = mun.aux_mun_cd_ibge
  left join tb_cad_tel_telefone tel
    on pes.cad_pes_id_pessoa = tel.cad_pes_id_pessoa
   and tel.aux_tte_cd_tp_tel_end = 2
  left join tb_cad_tel_telefone cel
    on pes.cad_pes_id_pessoa = cel.cad_pes_id_pessoa
   and cel.aux_tte_cd_tp_tel_end = 8
  left join tb_ass_pem_pessoa_email email
   on pes.cad_pes_id_pessoa = email.cad_pes_id_pessoa 
 where pes.cad_pes_id_pessoa = pCAD_PES_ID_PESSOA;
end if;
  io_cursor := v_cursor;
end PRC_FAT_OBTER_PESSOARESP;
 