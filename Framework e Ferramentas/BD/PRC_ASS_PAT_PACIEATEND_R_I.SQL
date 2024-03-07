

--PRC_ASS_PAT_PACIEATEND_R_I
create or replace procedure PRC_ASS_PAT_PACIEATEND_R_I
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
*    Procedure: PRC_ASS_PAT_PACIEATEND_R_I
* 
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
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
  
      
INSERT INTO TB_ASS_PAT_PACIEATEND
(
       ATD_ATE_ID,
       CAD_PAC_ID_PACIENTE,
       ASS_PAT_DT_ENTRADA,
       ASS_PAT_HR_ENTRADA,
       ASS_PAT_DT_SAIDA,
       ASS_PAT_HR_SAIDA,
       ASS_PAT_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_PAT_DT_ULTIMA_ATUALIZACAO,
       ASS_PAT_NR_CONTA,
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_PAC_CD_CREDENCIAL,
       ASS_PAT_DS_OBSERVACAO
)
VALUES
(
       pATD_ATE_ID,
       pCAD_PAC_ID_PACIENTE,
       pASS_PAT_DT_ENTRADA,
       pASS_PAT_HR_ENTRADA,
       pASS_PAT_DT_SAIDA,
       pASS_PAT_HR_SAIDA,
       pASS_PAT_FL_STATUS,
       pSEG_USU_ID_USUARIO,
       pASS_PAT_DT_ULT_ATUALIZACAO,
       pASS_PAT_NR_CONTA,
       NVL(pCAD_CNV_ID_CONVENIO,v_idconvenio),
       NVL(pCAD_PLA_ID_PLANO,v_idplano),
       NVL(pCAD_PAC_CD_CREDENCIAL,v_credencial),
       pASS_PAT_DS_OBSERVACAO
);
  
end PRC_ASS_PAT_PACIEATEND_R_I;

