CREATE OR REPLACE PROCEDURE "PRC_ATE_REL_PROF_PAC_N_ATE"
  (
     pCAD_UNI_ID_UNIDADE in TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
     pCAD_SET_NR_ANDAR in TB_CAD_SET_SETOR.CAD_SET_NR_ANDAR%type default null,
     pCAD_CNV_ID_CONVENIO in TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type default null,
     pCAD_PLA_ID_PLANO in TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type default null,
     pTIS_CBO_CD_CBOS in TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pCAD_PRO_ID_PROFISSIONAL in TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
     pATD_DT_INICIO in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pATD_DT_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pATD_HR_INICIO in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%type default null,
     pATD_HR_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%type default null,
     pTIS_TAT_CD_TPATENDIMENTO in TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%type default null,
     pCAD_PLA_CD_TIPOPLANO in TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%type default null,
     pATD_ATE_FL_INDIC_RN_OK in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_INDIC_RN_OK%type default null,
     pATD_ATE_FL_RETORNO_OK in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_RETORNO_OK%type default null,
     pAGE_AGD_FL_FALTA in TB_AGE_AGD_AGENDA.AGE_AGD_FL_STATUS%type default null,
     pTIS_TSC_CD_TIPOSAIDACONSULTA in tb_tis_tcs_tp_consulta.tis_tcs_cd_tpconsulta%type default null,
     pPAC_NAO_ATENDIDOS varchar2 default null,
          pCAD_CGC_ID IN tb_cad_cnv_convenio.cad_cgc_id%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor--,
     --TESTE OUT LONG
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATE_REL_PROF_PAC_N_ATE
  *
  *    Data Alteracao:   Por: Pedro
  *    Alterac?o:
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
    V_WHERE  varchar2(2000);
    V_SELECT  varchar2(30000);
  begin
     V_WHERE := ' 1=1 ';
    IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
    IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO;   END IF;
    IF pCAD_SET_ID IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.CAD_SET_ID = ' || pCAD_SET_ID; END IF;
    IF pCAD_SET_NR_ANDAR IS NOT NULL THEN V_WHERE := V_WHERE || ' AND setor.CAD_SET_NR_ANDAR = ' || pCAD_SET_NR_ANDAR; END IF;
    IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND PAC.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO; END IF;
    IF pCAD_PLA_ID_PLANO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND PAC.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO; END IF;
    IF pTIS_CBO_CD_CBOS IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.TIS_CBO_CD_CBOS = ' ||CHR(39)|| pTIS_CBO_CD_CBOS ||CHR(39); END IF;
    IF pCAD_PRO_ID_PROFISSIONAL IS NOT NULL THEN  V_WHERE := V_WHERE || ' AND ATD.CAD_PRO_ID_PROF_EXEC = ' || pCAD_PRO_ID_PROFISSIONAL;  END IF;
    IF pTIS_TAT_CD_TPATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.TIS_TAT_CD_TPATENDIMENTO = ' ||CHR(39)|| pTIS_TAT_CD_TPATENDIMENTO ||CHR(39);    END IF;
    IF pCAD_PLA_CD_TIPOPLANO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND PLA.CAD_PLA_CD_TIPOPLANO = ' ||CHR(39)|| pCAD_PLA_CD_TIPOPLANO ||CHR(39);    END IF;
    IF pATD_ATE_FL_INDIC_RN_OK IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.ATD_ATE_FL_INDIC_RN_OK = ' ||CHR(39)|| pATD_ATE_FL_INDIC_RN_OK ||CHR(39);    END IF;
    IF pATD_ATE_FL_RETORNO_OK IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.ATD_ATE_FL_RETORNO_OK = ' ||CHR(39)|| pATD_ATE_FL_RETORNO_OK ||CHR(39);    END IF;
    --IF pAGE_AGD_FL_FALTA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND AGD.AGE_AGD_FL_FALTA = ' ||CHR(39)|| pAGE_AGD_FL_FALTA ||CHR(39);    END IF;
    IF pTIS_TSC_CD_TIPOSAIDACONSULTA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.TIS_TSC_CD_TIPOSAIDACONSULTA = ' ||CHR(39)|| pTIS_TSC_CD_TIPOSAIDACONSULTA ||CHR(39);  END IF;
    IF pATD_HR_INICIO is not null and pATD_HR_FIM is not null then
       V_WHERE := V_WHERE ||' and (('|| pATD_HR_INICIO ||' < ' || pATD_HR_FIM
        ||' and (atd.atd_ate_hr_atendimento between ' || pATD_HR_INICIO || ' and ' || pATD_HR_FIM || ')) '
        ||' or (' || pATD_HR_INICIO || ' > '|| pATD_HR_FIM || ' and '
        ||' ((atd.atd_ate_hr_atendimento between 0 and ' || pATD_HR_INICIO || ') or (atd.atd_ate_hr_atendimento between ' || pATD_HR_FIM || ' and 2359))))';
    end if;
    --IF pATD_DT_INICIO is not null and pATD_DT_FIM is not null then
    --       V_WHERE := V_WHERE ||' and (atd.atd_ate_dt_atendimento between '||chr(39)|| pATD_DT_INICIO ||chr(39)||' and ' ||chr(39)||pATD_DT_FIM ||chr(39)|| ') ';
    --end if;
    IF pATD_DT_INICIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND atd.ATD_ATE_DT_ATENDIMENTO >= TO_DATE('||CHR(39)||TO_CHAR(pATD_DT_INICIO,'DDMMYYYY')||CHR(39)||','||CHR(39)||'DDMMYYYY'||CHR(39)|| ')' ; END IF;
    IF pATD_DT_FIM IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND atd.ATD_ATE_DT_ATENDIMENTO <= TO_DATE('||CHR(39)||TO_CHAR(pATD_DT_FIM,'DDMMYYYY')||CHR(39)||','||CHR(39)||'DDMMYYYY'||CHR(39)|| ')' ; END IF;
    IF pPAC_NAO_ATENDIDOS IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.CAD_PRO_ID_PROF_EXEC IS NOT NULL AND (ATD.Cad_Cid_Cd_Cid10 IS NULL OR ATD.ATD_ATE_FL_PRONT_ELETR_ATIVO = ' ||CHR(39)|| 'N' ||CHR(39)||')';    END IF;
        IF pCAD_CGC_ID IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CNV.CAD_CGC_ID = ' || pCAD_CGC_ID; END IF;    
       V_SELECT := 'select
       atd.cad_uni_id_unidade id_unidade,
       uni.cad_uni_ds_unidade ds_unidade,
       atd.cad_lat_id_local_atendimento id_local_atd,
       lat.cad_lat_ds_local_atendimento ds_local_atd,
       setor.cad_set_ds_setor ds_setor,
       setor.cad_set_nr_andar CAD_SET_NR_ANDAR,
       atd.atd_ate_dt_atendimento ATD_ATE_DT_ATENDIMENTO,
       atd.atd_ate_hr_atendimento hr_atendimento,
       decode(pla.cad_pla_cd_tipoplano, '
                                        ||chr(39)|| '48' ||chr(39)|| ', ' ||chr(39)|| '48' ||chr(39)|| ','
                                        ||chr(39)|| 'FU' ||chr(39)|| ', ' ||chr(39)|| 'FUNCIONARIO' ||chr(39)|| ','
                                        ||chr(39)|| 'PA' ||chr(39)|| ', ' ||chr(39)|| 'PA' ||chr(39)|| ','
                                        ||chr(39)|| 'GB' ||chr(39)|| ', ' ||chr(39)|| 'GLOBAL' ||chr(39)|| ','
                                        ||chr(39)|| 'PL' ||chr(39)|| ', ' ||chr(39)|| 'PESSOA FISICA' ||chr(39)|| ','
                                        ||chr(39)|| 'SP' ||chr(39)|| ', ' ||chr(39)|| 'SERVICOS PRESTADOS' ||chr(39)|| ','
                                        ||chr(39)|| 'TODOS' ||chr(39)|| ') tipo_empresa,
       cbo.tis_cbo_ds_cbos_hac ds_especialidade,
       pro.cad_pro_nr_conselho nr_conselho,
       pro.cad_pro_nm_nome nm_medico,
       pro.cad_pro_nm_apelido apelido_medico,
       atd.atd_ate_id nr_atd,
       pac.cad_pac_nr_prontuario nr_prontuario,
       pes_pac.cad_pes_nm_pessoa nm_paciente,
       PES_pac.CAD_PES_DT_NASCIMENTO,
       cnv.cad_cnv_cd_hac_prestador cd_convenio,
       cnv.cad_cnv_nm_fantasia ds_convenio,
       pla.cad_pla_cd_plano_hac cd_plano,
       tat.tis_tat_ds_tpatendimento ds_tipo_atendimento,
       atd.atd_ate_fl_indic_rn_ok RN,
       atd.atd_ate_fl_retorno_ok retorno,
       atd.atd_ate_fl_status fl_atendimento,
       null fl_faltoso,
       tsc.tis_tsc_ds_tiposaidaconsulta
      FROM TB_ATD_ATE_ATENDIMENTO       ATD
      JOIN TB_CAD_UNI_UNIDADE           UNI      ON UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
      JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT      ON   LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
      JOIN TB_CAD_SET_SETOR             SETOR    ON   SETOR.CAD_SET_ID = ATD.CAD_SET_ID
      JOIN TB_TIS_CBO_CBOS              CBO      ON   CBO.TIS_CBO_CD_CBOS = ATD.TIS_CBO_CD_CBOS
      LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO      ON   PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC
      JOIN TB_ASS_PAT_PACIEATEND        PAT      ON   PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
      JOIN TB_CAD_PAC_PACIENTE          PAC      ON   PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
      LEFT JOIN TB_AGE_AGD_AGENDA       AGD      ON   AGD.AGE_AGD_CD_INTAMB = ATD.ATD_ATE_ID
      JOIN TB_CAD_PES_PESSOA            PES_PAC  ON   PES_PAC.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
      JOIN TB_CAD_CNV_CONVENIO          CNV      ON   CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
      JOIN TB_CAD_PLA_PLANO             PLA      ON   PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
      JOIN TB_TIS_TAT_TP_ATENDIMENTO    TAT      ON   TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO
      LEFT JOIN TB_TIS_TSC_TIPOSAIDACONSULTA TSC ON   TSC.TIS_TSC_CD_TIPOSAIDACONSULTA = ATD.TIS_TSC_CD_TIPOSAIDACONSULTA
     where    '
      || V_WHERE
      || ' and atd.atd_ate_fl_status = ' ||chr(39)|| 'D' || chr(39)
      || ' order by atd.atd_ate_dt_atendimento, pes_pac.cad_pes_nm_pessoa, atd.atd_ate_hr_atendimento';
--dbms_output.put_line(v_select);
   --TESTE :=  V_SELECT ;
  OPEN v_cursor FOR
   V_SELECT ;
--select sysdate from dual;
    io_cursor := v_cursor;
  end PRC_ATE_REL_PROF_PAC_N_ATE;
