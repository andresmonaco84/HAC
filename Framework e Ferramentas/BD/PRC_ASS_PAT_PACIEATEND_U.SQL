  create or replace procedure PRC_ASS_PAT_PACIEATEND_U
  (
     pATD_ATE_ID IN TB_ASS_PAT_PACIEATEND.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%type,
     pASS_PAT_DT_ENTRADA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_DT_ENTRADA%type,
     pASS_PAT_HR_ENTRADA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_HR_ENTRADA%type,
     pASS_PAT_DT_SAIDA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_DT_SAIDA%type default NULL,
     pASS_PAT_HR_SAIDA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_HR_SAIDA%type default NULL,
     pASS_PAT_FL_STATUS IN TB_ASS_PAT_PACIEATEND.ASS_PAT_FL_STATUS%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PAT_PACIEATEND.SEG_USU_ID_USUARIO%type,
     pASS_PAT_NR_CONTA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_NR_CONTA%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PAT_PACIEATEND_U
  * 
  *    Data Criacao: 	17/01/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Altera Paciente Atendimento
  *
  *******************************************************************/  
  v_idconvenio number;
  v_idplano    number;
  v_credencial varchar2(20);

begin

  begin
    select pac.cad_cnv_id_convenio,
           pac.cad_pla_id_plano,
           pac.cad_pac_cd_credencial
      into v_idconvenio, v_idplano, v_credencial
      from tb_cad_pac_paciente pac
     where pac.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE;
  exception
    when others then
      v_idconvenio := null;
      v_idplano    := null;
      v_credencial := null;
  end;

  UPDATE TB_ASS_PAT_PACIEATEND
     SET ASS_PAT_DT_ENTRADA            = pASS_PAT_DT_ENTRADA,
         ASS_PAT_HR_ENTRADA            = pASS_PAT_HR_ENTRADA,
         ASS_PAT_DT_SAIDA              = pASS_PAT_DT_SAIDA,
         ASS_PAT_HR_SAIDA              = pASS_PAT_HR_SAIDA,
         ASS_PAT_FL_STATUS             = pASS_PAT_FL_STATUS,
         SEG_USU_ID_USUARIO            = pSEG_USU_ID_USUARIO,
         ASS_PAT_DT_ULTIMA_ATUALIZACAO = sysdate,
         ASS_PAT_NR_CONTA              = pASS_PAT_NR_CONTA,
		 CAD_CNV_ID_CONVENIO           = v_idconvenio,
         CAD_PLA_ID_PLANO              = v_idplano,
         CAD_PAC_CD_CREDENCIAL         = v_credencial
   WHERE ATD_ATE_ID = pATD_ATE_ID
     AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE;
  end PRC_ASS_PAT_PACIEATEND_U;
/
