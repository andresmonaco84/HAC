CREATE OR REPLACE PROCEDURE PRC_ATE_REL_LIBERACAO
(
  PATD_DT_INICIO IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_AGENDA%TYPE,
  PATD_DT_FIM IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_AGENDA%TYPE,
  pCAD_UNI_ID_UNIDADE_D IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO_ IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
  pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
  pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
  pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
  pCAD_CLC_ID IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE DEFAULT NULL,
  pATD_ATE_NR_CONSELHO_SOLIC IN TB_ASS_PAP_PAC_ATEN_PROC.ATD_ATE_NR_CONSELHO_SOLIC%TYPE DEFAULT NULL,
  pAUX_EPP_CD_ESPECPROC IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,
  pAUX_GPC_CD_GRUPOPROC IN TB_AUX_GPC_GRUPOPROC.AUX_GPC_CD_GRUPOPROC%TYPE DEFAULT NULL,
  pCAD_PRD_CD_CODIGO IN TB_CAD_PRD_PRODUTO.CAD_PRD_CD_CODIGO%TYPE DEFAULT NULL,
  pASS_PAP_FL_STATUS_AUTOR IN TB_ASS_PAP_PAC_ATEN_PROC.ASS_PAP_FL_STATUS_AUTOR%TYPE DEFAULT NULL,
  pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL, 
  pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
  pCAD_SET_ID_SETOR_LIBERACAO IN TB_ASS_PAP_PAC_ATEN_PROC.CAD_SET_ID_SETOR_LIBERACAO%TYPE DEFAULT NULL,
  io_cursor OUT PKG_CURSOR.t_cursor
)
IS
  /********************************************************************
  *    Procedure: PRC_ATE_REL_LIBERACAO
  *
  *    Data Criacao:  03/06/2008   Por: PEDRO
  *    Data Alteracao: data da altera��o  Por: Nome do Analista
  *
  *    Data Alteracao:  15/06/2009   Por: PEDRO   
  *   CORRE��O NO WHERE pCAD_UNI_ID_UNIDADE_D e pCAD_LAT_ID_LOCAL_ATENDIMENTO_
  *
  *    Funcao: Fornecer informacoes para impressao de relatorio de liberacao
  *
  *******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
  SELECT
         PAP.ATD_ATE_ID,
         CNV.CAD_CNV_CD_HAC_PRESTADOR || '/' || PLA.CAD_PLA_CD_PLANO_HAC CONV_PLANO,
         PES_PAC.CAD_PES_NM_PESSOA NM_PACIENTE,
         PRD.CAD_PRD_CD_CODIGO,
         PAP.ATD_ATE_NR_CONSELHO_SOLIC CRM_PRO,         
         PLA.CAD_PLA_CD_PLANO_HAC CD_PLANO,
         PLA.CAD_PLA_NM_NOME_PLANO NM_PLANO,
         CLC.CAD_CLC_DS_RESUMIDA,
         AUX_EPP.AUX_EPP_CD_ESPECPROC,
         AUX_EPP.AUX_EPP_DS_DESCRICAO,
         AUX_GPC.AUX_GPC_CD_GRUPOPROC,
         AUX_GPC.AUX_GPC_DS_DESCRICAO,
         PRD.CAD_PRD_CD_CODIGO,
         PRD.CAD_PRD_DS_DESCRICAO,
         PAP.ASS_PAP_DT_AUTOR,--
         PES_UNI_DESTINO.CAD_PES_NM_PESSOA UNIDADE_DESTINO,
         LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO LAT_DESTINO,
         PES_UNI_ORIGEM.CAD_PES_NM_PESSOA UNIDADE_ORIGEM,
         LAT_ORIGEM.CAD_LAT_DS_LOCAL_ATENDIMENTO LAT_ORIGEM,
         SETOR_ORIGEM.CAD_SET_DS_SETOR SETOR_ORIGEM,
         decode(pla.cad_pla_cd_tipoplano,
                                        '48', '48',
                                        'FU', 'Funcion�rio',
                                        'PA', 'Particular',
                                        'GB', 'Global',
                                        'PL', 'F�sica',
                                        'SP', 'Servi�o Prestado',
                                        'TODOS') tipo_empresa,
     CASE
      WHEN PAP.ASS_PAP_FL_STATUS_AUTOR = 'A' THEN 'AUTORIZADO'
      WHEN PAP.ASS_PAP_FL_STATUS_AUTOR = 'N' THEN 'N�O AUTORIZADO'
      ELSE 'PENDENTE'
     END STATUS
    FROM
         TB_ASS_PAP_PAC_ATEN_PROC PAP,
         TB_CAD_PAC_PACIENTE PAC,
         TB_CAD_PES_PESSOA PES_PAC,
         TB_CAD_CNV_CONVENIO CNV,
         TB_CAD_PLA_PLANO PLA,
         TB_CAD_PRD_PRODUTO PRD,
         TB_AUX_EPP_ESPECPROC AUX_EPP,
         TB_AUX_GPC_GRUPOPROC AUX_GPC,
         TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
         TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
         TB_CAD_PES_PESSOA PES_UNI_DESTINO,
         TB_CAD_UNI_UNIDADE UNI_DESTINO,
         TB_CAD_PES_PESSOA PES_UNI_ORIGEM,
         TB_CAD_UNI_UNIDADE UNI_ORIGEM,
         TB_CAD_SET_SETOR SETOR_ORIGEM,
         TB_CAD_LAT_LOCAL_ATENDIMENTO LAT_ORIGEM
   WHERE
         TRUNC(PAP.ASS_PAP_DT_AUTOR) BETWEEN PATD_DT_INICIO AND PATD_DT_FIM
     
     AND PAP.CAD_UNI_ID_UNIDADE  = UNI_DESTINO.CAD_UNI_ID_UNIDADE 
     AND PES_UNI_DESTINO.CAD_PES_ID_PESSOA = UNI_DESTINO.CAD_PES_ID_PESSOA
     AND PAP.ASS_PAP_FL_ORIGEM = 'L'
     
     AND PAP.CAD_SET_ID_SETOR_LIBERACAO = SETOR_ORIGEM.CAD_SET_ID
     AND SETOR_ORIGEM.CAD_UNI_ID_UNIDADE = UNI_ORIGEM.CAD_UNI_ID_UNIDADE
     AND SETOR_ORIGEM.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT_ORIGEM.CAD_LAT_ID_LOCAL_ATENDIMENTO
     AND UNI_ORIGEM.CAD_PES_ID_PESSOA = PES_UNI_ORIGEM.CAD_PES_ID_PESSOA
     
     AND PAP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
     AND PES_PAC.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
     AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
     AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
     AND PAP.CAD_PRD_ID  = PRD.CAD_PRD_ID (+)
     AND AUX_EPP.AUX_EPP_CD_ESPECPROC (+) = PRD.AUX_EPP_CD_ESPECPROC
     AND AUX_GPC.AUX_GPC_CD_GRUPOPROC (+) = PRD.AUX_GPC_CD_GRUPOPROC
     AND AUX_GPC.AUX_EPP_CD_ESPECPROC (+) = PRD.Aux_Epp_Cd_Especproc
     AND PAP.CAD_CLC_ID = CLC.CAD_CLC_ID (+)
     AND PAP.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
     AND (pCAD_CNV_ID_CONVENIO IS NULL OR CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
     AND (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
     AND (pCAD_PLA_CD_TIPOPLANO IS NULL OR PLA.CAD_PLA_CD_TIPOPLANO = pCAD_PLA_CD_TIPOPLANO)
     AND (pCAD_CLC_ID IS NULL OR CLC.CAD_CLC_ID = pCAD_CLC_ID)
     AND (pATD_ATE_NR_CONSELHO_SOLIC IS NULL OR PAP.ATD_ATE_NR_CONSELHO_SOLIC = pATD_ATE_NR_CONSELHO_SOLIC )
     AND (pAUX_EPP_CD_ESPECPROC IS NULL OR AUX_EPP.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC)
     AND (pAUX_GPC_CD_GRUPOPROC IS NULL OR AUX_GPC.AUX_GPC_CD_GRUPOPROC = pAUX_GPC_CD_GRUPOPROC)
     AND (pCAD_PRD_CD_CODIGO IS NULL OR PRD.CAD_PRD_CD_CODIGO = pCAD_PRD_CD_CODIGO )
     AND (pASS_PAP_FL_STATUS_AUTOR IS NULL OR PAP.ASS_PAP_FL_STATUS_AUTOR = pASS_PAP_FL_STATUS_AUTOR)
     AND (pCAD_SET_ID_SETOR_LIBERACAO IS NULL OR PAP.CAD_SET_ID_SETOR_LIBERACAO = pCAD_SET_ID_SETOR_LIBERACAO)
     AND (pCAD_UNI_ID_UNIDADE_D IS NULL OR PAP.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE_D)
     AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO_ IS NULL OR PAP.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO_)
     AND (pCAD_UNI_ID_UNIDADE IS NULL OR SETOR_ORIGEM.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
     AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR SETOR_ORIGEM.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
     order by PES_PAC.CAD_PES_NM_PESSOA
    ;
  io_cursor := v_cursor;
END PRC_ATE_REL_LIBERACAO;
/
