create or replace procedure PRC_FAT_OBTER_RESPONSAVEL(pATD_ATE_ID IN TB_ASS_PAT_PACIEATEND.ATD_ATE_ID%type default null,
                                                      pCPF                 IN TB_CAD_PES_PESSOA.CAD_PES_NR_CNPJ_CPF%type default null,
                                                      io_cursor            OUT PKG_CURSOR.t_cursor) is
  v_cursor PKG_CURSOR.t_cursor;
begin

  OPEN v_cursor FOR
    
 select pes.cad_pes_id_pessoa,
              pes.cad_pes_nm_pessoa         as FAT_RES_NOME_RESPONSAVEL,
              pes.cad_pes_dt_nascimento		as FAT_RES_DATA_NASCIMENTO,
              pes.cad_pes_nr_cnpj_cpf       as FAT_RES_CNPJCPF,
              pes.cad_pes_nr_rg             as FAT_RES_DOC_IDENTIDADE,
              pes.cad_pes_cd_orgaoemissorrg as FAT_RES_DOC_ORGAO,
              ede.cad_end_cd_cep            as FAT_RES_END_CEP,
              ede.cad_end_ds_complemento    as FAT_RES_END_COMPLEMENTO,
              ede.cad_end_nm_bairro         as FAT_RES_END_BAIRRO,
              ede.cad_end_sg_uf             as FAT_RES_END_UF,
              ede.cad_end_sg_uf             as FAT_RES_DOC_UF,
              ede.cad_end_ds_numero         as FAT_RES_END_NUMERO,
              ede.cad_end_nm_logradouro     as FAT_RES_END_RUA,
              tel.cad_tel_nr_num_tel        as FAT_RES_TELEFONE,
              cel.cad_tel_nr_num_tel        as FAT_RES_CELULAR,
              null                          as FAT_RES_COD_CLI_FOR,
              substr(ede.aux_mun_cd_ibge, 3, 5) as FAT_RES_COD_MUNICIPIO  
         from tb_ass_pat_pacieatend pat
        inner join tb_cad_pac_paciente pac
           on pac.cad_pac_id_paciente = pat.cad_pac_id_paciente
        inner join tb_cad_pes_pessoa pes
           on pac.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
         left join tb_cad_end_endereco ede
           on pes.cad_pes_id_pessoa = ede.cad_pes_id_pessoa
         left join tb_cad_tel_telefone tel
           on pes.cad_pes_id_pessoa = tel.cad_pes_id_pessoa
          and tel.aux_tte_cd_tp_tel_end <> 8
         left join tb_cad_tel_telefone cel
           on pes.cad_pes_id_pessoa = cel.cad_pes_id_pessoa
          and cel.aux_tte_cd_tp_tel_end = 8
        where (pat.atd_ate_id = pATD_ATE_ID or pATD_ATE_ID is null)
        and (pCPF is null or pCPF = pes.cad_pes_nr_cnpj_cpf)
        and rownum = 1;

  io_cursor := v_cursor;

end PRC_FAT_OBTER_RESPONSAVEL;
