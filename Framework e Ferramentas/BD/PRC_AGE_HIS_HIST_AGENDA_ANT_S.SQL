create or replace procedure sgs.PRC_AGE_HIS_HIST_AGENDA_ANT_S
  (
     pCAD_PES_ID_PESSOA IN TB_CAD_PAC_PACIENTE.CAD_PES_ID_PESSOA%TYPE,
--     pCAD_PAC_NR_PRONTUARIO IN TB_CAD_PAC_PACIENTE.CAD_PAC_NR_PRONTUARIO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_HIS_HIST_AGENDA_ANT_S
  *    Func?o:         Lista historico de atendimentos do paciente
  *
  *    Data Criacao:   31/10/2007           Por: Carlos Eduardo
  *
  *    Data Alterac?o: 01/11/2007           Por: Carlos Eduardo
  *    Alterac?o: Retirada dos decodes e implementac?o da descric?o na pagina
  *    Data Alterac?o: 23/11/2007           Por: Silmara
  *    Alterac?o: Comparac?o da data de atendimento menor =  a data atual
  *
  *    Data Alterac?o: 17/12/2007           Por: Guilherme Holdack
  *    Alterac?o: Retornando o status do atendimento
  *
  *    Data Alterac?o: 07/10/2008           Por: Andrea Cazuca
  *    Alterac?o: Incluido a ordenac?o por hora tambem
  *
  *    Data Alteracao: 18/04/2011           Por: Davi Silvestre M. dos Reis
  *    Alteracao: Troca dos sistemas: deixar de pesquisar no legado 
  *               para consultar no SGS; troca do Nro. Prontuário pelo ID
  *               da pessoa, durante a pesquisa
  *
  *    Data Alteracao: 05/10/2012           Por: Cristiane Gomes
  *    Alteracao: Apresentar também os atendimentos(agendamentos) com falta
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT *
      FROM (select atd.atd_ate_id,
                   cnv.cad_cnv_cd_hac_prestador,
                   case when atd.atd_ate_ds_complemento is not null and atd.atd_ate_ds_complemento = 'TELEMEDICINA' then '99' else atd.tis_tat_cd_tpatendimento end tis_tat_cd_tpatendimento,
                   atd.atd_ate_dt_atendimento,
                   atd.atd_ate_hr_atendimento,
                   pro.cad_pro_nm_nome,
                   cbo.tis_cbo_cd_cbos_hac,
                   uni.cad_uni_ds_unidade,
                   atd.atd_ate_fl_status
              from tb_atd_ate_atendimento atd
             inner join tb_ass_pat_pacieatend pat
                on pat.atd_ate_id = atd.atd_ate_id
             inner join tb_cad_pac_paciente pac
                on pac.cad_pac_id_paciente = pat.cad_pac_id_paciente
             inner join tb_cad_cnv_convenio cnv
                on cnv.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
              left join tb_cad_pro_profissional pro
                on pro.cad_pro_id_profissional = atd.cad_pro_id_prof_exec
             inner join tb_tis_cbo_cbos cbo
                on cbo.tis_cbo_cd_cbos = atd.tis_cbo_cd_cbos
             inner join tb_cad_uni_unidade uni
                on uni.cad_uni_id_unidade = atd.cad_uni_id_unidade
             where pac.cad_pes_id_pessoa = pCAD_PES_ID_PESSOA
               and trunc(atd.atd_ate_dt_atendimento) <= trunc(sysdate)
            UNION ALL
            select AGD.AGE_AGD_CD_INTAMB,
                   cnv.cad_cnv_cd_hac_prestador,
                   case when agd.age_agd_fl_telemedicina is not null and agd.age_agd_fl_telemedicina = 'S' then '99' else '4' end tis_tat_cd_tpatendimento,
                   AGD.AGE_AGD_DT_ATENDIMENTO   ATD_ATE_DT_ATENDIMENTO,
                   AGD.AGE_AGD_HR_ATENDIMENTO   ATD_ATE_HR_ATENDIMENTO,
                   pro.cad_pro_nm_nome,
                   cbo.tis_cbo_cd_cbos_hac,
                   uni.cad_uni_ds_unidade,
                   AGD.AGE_AGD_FL_STATUS atd_ate_fl_status
              FROM TB_AGE_AGD_AGENDA AGD 
             inner join tb_cad_pac_paciente pac
                on pac.cad_pac_id_paciente = AGD.cad_pac_id_paciente
             inner join tb_cad_cnv_convenio cnv
                on cnv.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
              left join tb_cad_pro_profissional pro
                on pro.cad_pro_id_profissional =
                   AGD.CAD_PRO_ID_PROFISSIONALEXEC
             INNER JOIN TB_AGE_ESM_ESCALA_MEDICA ESM
                ON ESM.AGE_ESM_ID = AGD.AGE_ESM_ID
             inner join tb_tis_cbo_cbos cbo
                on cbo.tis_cbo_cd_cbos = ESM.TIS_CBO_CD_CBOS
             inner join tb_cad_uni_unidade uni
                on uni.cad_uni_id_unidade = ESM.cad_uni_id_unidade
               and trunc(AGD.AGE_AGD_DT_ATENDIMENTO) <= trunc(sysdate)
               AND PAC.CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA
               AND AGD.AGE_AGD_FL_STATUS = 'F'
             order by ATD_ATE_DT_ATENDIMENTO desc, ATD_ATE_HR_ATENDIMENTO desc)
     WHERE ROWNUM <= 10;
  io_cursor := v_cursor;
end PRC_AGE_HIS_HIST_AGENDA_ANT_S;
 