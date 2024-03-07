create or replace procedure PRC_ATE_REL_IMPRESSAO_ETIQUETA
  (
  pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE ,
  io_cursor OUT PKG_CURSOR.t_cursor
  )
   IS
  /********************************************************************
  *    Procedure: PRC_ATE_REL_IMPRESSAO_ETIQUETA
  *
  *    Data Criacao:  30/01/2008   Por: Davi S. M. dos Reis
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Fornecer informacoes para impressao de etiquetas de atendimento
  *******************************************************************/
      v_cursor PKG_CURSOR.t_cursor;

      BEGIN
      
        OPEN v_cursor FOR
        
        SELECT DISTINCT
               atd.atd_ate_id
             , atd.atd_ate_dt_atendimento dt_atendimento
             , SUBSTR(lpad(to_char(atd.atd_ate_hr_atendimento), 4, '0'), 1, 2) 
               || ':' || SUBSTR(lpad(to_char(atd.atd_ate_hr_atendimento), 4, '0'), 3, 2) hr_atendimento
             , pes_pro.cad_pes_nm_pessoa profis_exec
             , pro.cad_pro_nm_apelido apelido_medico
             , cnv.cad_cnv_cd_hac_prestador || ' - ' || pes_cnv.cad_pes_nm_pessoa conv_cod_nome 
             , pla.cad_pla_cd_plano_hac || ' - ' || pla.cad_pla_nm_nome_plano plano_cod_nome
             , pla.cad_pla_cd_tipoplano tipo_plano
             , atd.codpad cod_padrao
             , pes_pac.cad_pes_nm_pessoa paciente
             , pac.cad_pac_nr_prontuario nro_prontuario
             , pes_pac.cad_pes_dt_nascimento dt_nasc
             , trunc((MONTHS_BETWEEN(sysdate, pes_pac.cad_pes_dt_nascimento))/12) idade 
             , pes_pac.cad_pes_tp_sexo sexo
             , tel.cad_tel_nr_num_tel telefone
             , ende.cad_end_nm_logradouro end_logr
             , ende.cad_end_ds_numero end_nro
             , ende.cad_end_ds_complemento end_compl
             , ende.cad_end_nm_logradouro || ', ' || ende.cad_end_ds_numero || ' ' || ende.cad_end_ds_complemento endereco
             , ende.cad_end_nm_bairro end_bairro
             , mun.aux_mun_nm_municipio municipio
             , mun.aux_mun_sg_uf uf
             , pes_uni.cad_pes_nm_pessoa unidade
             , pac.cad_pac_nm_titular titular
             , pac.cad_pac_cd_credencial credencial
             , pac.cad_pac_dt_validadecredencial validade
             , setor.cad_set_ds_setor ds_setor
             , tis_tat.tis_tat_ds_tpatendimento tipo_atend
        FROM 
             TB_ATD_ATE_ATENDIMENTO atd
       INNER JOIN TB_CAD_PRO_PROFISSIONAL pro 
          ON atd.cad_pro_id_prof_exec = pro.cad_pro_id_profissional
       INNER JOIN TB_CAD_PES_PESSOA pes_pro
          ON pro.cad_pes_id_pessoa = pes_pro.cad_pes_id_pessoa
       INNER JOIN TB_ASS_PAT_PACIEATEND ass_pat
          ON atd.atd_ate_id = ass_pat.atd_ate_id
       INNER JOIN TB_CAD_PAC_PACIENTE pac
          ON ass_pat.cad_pac_id_paciente = pac.cad_pac_id_paciente 
       INNER JOIN TB_CAD_PES_PESSOA pes_pac
          ON pac.cad_pes_id_pessoa = pes_pac.cad_pes_id_pessoa
        LEFT JOIN TB_ATD_GUI_GUIAATEND atd_gui
          ON atd.atd_ate_id = atd_gui.atd_ate_id
       INNER JOIN TB_CAD_CNV_CONVENIO cnv
          ON pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
       INNER JOIN TB_CAD_PES_PESSOA pes_cnv
          ON cnv.cad_pes_id_pessoa = pes_cnv.cad_pes_id_pessoa   
       INNER JOIN TB_CAD_PLA_PLANO pla
          ON pac.cad_pla_id_plano = pla.cad_pla_id_plano
       INNER JOIN TB_CAD_UNI_UNIDADE uni
          ON atd.cad_uni_id_unidade = uni.cad_uni_id_unidade
       INNER JOIN TB_CAD_PES_PESSOA pes_uni
          ON uni.cad_pes_id_pessoa = pes_uni.cad_pes_id_pessoa 
        LEFT JOIN TB_CAD_TEL_TELEFONE tel
          ON PES_PAC.CAD_PES_ID_PESSOA = TEL.CAD_PES_ID_PESSOA
        LEFT JOIN TB_CAD_END_ENDERECO ENDE
          ON PES_PAC.CAD_PES_ID_PESSOA = ENDE.CAD_PES_ID_PESSOA
        LEFT JOIN TB_AUX_MUN_MUNICIPIO mun
          ON ende.aux_mun_cd_ibge = mun.aux_mun_cd_ibge     
       INNER JOIN TB_CAD_SET_SETOR setor
          ON atd.cad_set_id = setor.cad_set_id
       INNER JOIN TB_TIS_TAT_TP_ATENDIMENTO tis_tat
          ON atd.tis_tat_cd_tpatendimento = tis_tat.tis_tat_cd_tpatendimento
        
        WHERE atd.atd_ate_id = pATD_ATE_ID;

      io_cursor := v_cursor;
  
    END PRC_ATE_REL_IMPRESSAO_ETIQUETA;
