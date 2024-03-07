create or replace procedure sgs.PRC_ATS_ATE_ALERT_INT
  (
     pATS_ATE_CD_INTLIB IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_CD_INTLIB%type,
     pCAD_PRD_ID IN TB_ATS_ATE_ATENDIMENTO_SADT.CAD_PRD_ID%type,
     pCAD_PAC_ID_PACIENTE_INT IN TB_ATS_ATE_ATENDIMENTO_SADT.CAD_PAC_ID_PACIENTE_INT%type default null
  )
  is

  v_aux_epp number;
  v_nome nvarchar2(1000);
  v_conv nvarchar2(100);
  v_texto_email nvarchar2(4000);
  v_nome_procedimento nvarchar2(2000);
  v_nome_convenio nvarchar2(2000);
v_ATS_ATE_IN_INTLIB char(1);
  v_nome_espec nvarchar2(100);

  begin
    begin
       --VERIFICAR SE ? INTERNADO
      SELECT ATS_ATE_IN_INTLIB INTO v_ATS_ATE_IN_INTLIB FROM TB_ATS_ATE_ATENDIMENTO_SADT ATS WHERE ATS.ATS_ATE_CD_INTLIB = pATS_ATE_CD_INTLIB and rownum=1;
      IF v_ATS_ATE_IN_INTLIB = 'I' THEN

      --verificar se tomografia ou ressonancia
        select prd.aux_epp_cd_especproc, prd.cad_prd_cd_codigo || ' - ' || prd.cad_prd_ds_descricao
               into v_aux_epp, v_nome_procedimento
        from tb_cad_prd_produto prd
        where prd.cad_prd_id = pCAD_PRD_ID;

        if(v_aux_epp in ('34','410','36','411')) then

          if(v_aux_epp in ('34','410'))
          then v_nome_espec:= 'ALERTA TOMOGRAFIA ';
          else v_nome_espec:= 'ALERTA RESSONANCIA ';
          end if;

          --verificar se convenio esta na lista
          select cnv.cad_cnv_cd_hac_prestador, pes.cad_pes_nm_pessoa, cnv.cad_cnv_nm_fantasia
                 into v_conv, v_nome, v_nome_convenio
          from tb_cad_cnv_convenio cnv
          join tb_cad_pac_paciente pac on cnv.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
          join tb_cad_pes_pessoa pes on pac.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
          where pac.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE_INT;

          if(v_conv in ('SX42', 'SW92', 'SW26', 'SP99', 'SW87', 'SW67', 'SW32')) then
            v_texto_email :='Exame Solicitado: <B> '|| v_nome_procedimento ||' </B><BR>
            Paciente: <B> '|| v_nome ||' </B><BR>
            Atendimento: <B> ' || pATS_ATE_CD_INTLIB || ' </B><br/>
            Conv.: <B> '|| v_conv || ' - ' || v_nome_convenio || ' </B><BR>';

            insert into tb_sgs_eml_envia_email
            (sgs_eml_id,
            sgs_eml_destino,
            sgs_eml_status,
            sgs_eml_assunto,
            sgs_eml_dt_ultima_atualizacao,
            sgs_eml_curto_texto)
            values
            (seq_sgs_eml_01.nextval,
            'tisgs@anacosta.com.br,secretarias.clinicas@anacosta.com.br,centraldeguias@anacosta.com.br',
            'N',
            v_nome_espec || v_conv,
            SYSDATE,
            v_texto_email);

           end if;
         end if;
      end if;
    EXCEPTION when others then
      dbms_output.put_line('err');
     end;
  end PRC_ATS_ATE_ALERT_INT;
