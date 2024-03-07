

--PRC_ASS_PAT_PACIEATEND_R_U
create or replace procedure PRC_ASS_PAT_PACIEATEND_R_U
(
     pATD_ATE_ID IN TB_ASS_PAT_PACIEATEND.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%type,
     pASS_PAT_DT_ENTRADA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_DT_ENTRADA%type,
     pASS_PAT_HR_ENTRADA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_HR_ENTRADA%type,
     pASS_PAT_DT_SAIDA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_DT_SAIDA%type default NULL,
     pASS_PAT_HR_SAIDA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_HR_SAIDA%type default NULL,
     pASS_PAT_FL_STATUS IN TB_ASS_PAT_PACIEATEND.ASS_PAT_FL_STATUS%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PAT_PACIEATEND.SEG_USU_ID_USUARIO%type,
     pASS_PAT_DT_ULT_ATUALIZACAO IN TB_ASS_PAT_PACIEATEND.ASS_PAT_DT_ULTIMA_ATUALIZACAO%type,
     pASS_PAT_NR_CONTA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_NR_CONTA%type default NULL,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PAT_PACIEATEND.CAD_CNV_ID_CONVENIO%type default NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_PAT_PACIEATEND.CAD_PLA_ID_PLANO%type default NULL,
     pCAD_PAC_CD_CREDENCIAL IN TB_ASS_PAT_PACIEATEND.CAD_PAC_CD_CREDENCIAL%type default NULL,
     pASS_PAT_DS_OBSERVACAO IN TB_ASS_PAT_PACIEATEND.ASS_PAT_DS_OBSERVACAO%type default NULL
) 
is
/********************************************************************
*    Procedure: PRC_ASS_PAT_PACIEATEND_R_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
  v_idconvenio number;
  v_idplano    number;
  v_credencial varchar2(20);

begin

IF(pCAD_CNV_ID_CONVENIO IS NULL) THEN 
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


  END IF;
  
  


UPDATE TB_ASS_PAT_PACIEATEND
SET	   
        ASS_PAT_DT_SAIDA = pASS_PAT_DT_SAIDA,
        ASS_PAT_HR_SAIDA = pASS_PAT_HR_SAIDA,
        ASS_PAT_FL_STATUS = pASS_PAT_FL_STATUS,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_PAT_DT_ULTIMA_ATUALIZACAO = pASS_PAT_DT_ULT_ATUALIZACAO,
        ASS_PAT_NR_CONTA = pASS_PAT_NR_CONTA,
        CAD_CNV_ID_CONVENIO = NVL(pCAD_CNV_ID_CONVENIO,v_idconvenio),
        CAD_PLA_ID_PLANO = NVL(pCAD_PLA_ID_PLANO,v_idplano),
        CAD_PAC_CD_CREDENCIAL = NVL(pCAD_PAC_CD_CREDENCIAL,v_credencial),
		ASS_PAT_DS_OBSERVACAO = pASS_PAT_DS_OBSERVACAO 
WHERE
        ASS_PAT_DT_ENTRADA = pASS_PAT_DT_ENTRADA
    AND ASS_PAT_HR_ENTRADA = pASS_PAT_HR_ENTRADA
    AND ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE;	
end PRC_ASS_PAT_PACIEATEND_R_U;

