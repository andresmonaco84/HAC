CREATE OR REPLACE PROCEDURE PRC_ASS_PAT_PACIATEND_U
(
  pATD_ATE_ID                 IN TB_ASS_PAT_PACIEATEND.ATD_ATE_ID%TYPE,
  pCAD_PAC_ID_PACIENTE_ANTIGO IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%TYPE,
  pCAD_PAC_ID_PACIENTE_NOVO   IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%TYPE
) IS
  /********************************************************************
  *    Procedure: PRC_ASS_PAT_PACIATEND_U
  *
  *    Data Criacao:   19/01/2011            Por: Fabiola R. Lopes
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Atualiza o id do paciente com novo convenio, plano e credencial
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
     where pac.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE_NOVO;
  exception
    when others then
      v_idconvenio := null;
      v_idplano    := null;
      v_credencial := null;
  end;

  UPDATE TB_ASS_PAT_PACIEATEND
     SET CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE_NOVO,
		 		 CAD_CNV_ID_CONVENIO           = v_idconvenio,
         CAD_PLA_ID_PLANO              = v_idplano,
         CAD_PAC_CD_CREDENCIAL         = v_credencial
   WHERE ATD_ATE_ID = pATD_ATE_ID
     AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE_ANTIGO;

END PRC_ASS_PAT_PACIATEND_U;
