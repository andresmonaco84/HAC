create or replace procedure PRC_CAD_CNV_CONVENIO_I(pNewIdt                       OUT integer,
                                                   pCAD_CNV_CD_HAC_PRESTADOR     IN TB_CAD_CNV_CONVENIO.CAD_CNV_CD_HAC_PRESTADOR%type default NULL,
                                                   pCAD_CNV_CD_REG_ANS           IN TB_CAD_CNV_CONVENIO.CAD_CNV_CD_REG_ANS%type default NULL,
                                                   pCAD_CNV_DT_INI_VIGENCIA      IN TB_CAD_CNV_CONVENIO.CAD_CNV_DT_INI_VIGENCIA%type default null,
                                                   pCAD_CNV_DT_FIM_VIGENCIA      IN TB_CAD_CNV_CONVENIO.CAD_CNV_DT_FIM_VIGENCIA%type default NULL,
                                                   pCAD_CNV_QT_DIA_CONTA_PARCIAL IN TB_CAD_CNV_CONVENIO.CAD_CNV_QT_DIA_CONTA_PARCIAL%type default NULL,
                                                   pCAD_CNV_QT_DIA_REALIZ_FATUR  IN TB_CAD_CNV_CONVENIO.CAD_CNV_QT_DIA_REALIZ_FATUR%type default NULL,
                                                   pCAD_CNV_DS_DIA_EMI_CONTA     IN TB_CAD_CNV_CONVENIO.CAD_CNV_DS_DIA_EMI_CONTA%type default NULL,
                                                   pCAD_CNV_DS_DIA_ENTR_CONTA    IN TB_CAD_CNV_CONVENIO.CAD_CNV_DS_DIA_ENTR_CONTA%type default NULL,
                                                   pCAD_CNV_DS_DIA_AUDIT_CONTA   IN TB_CAD_CNV_CONVENIO.CAD_CNV_DS_DIA_AUDIT_CONTA%type default NULL,
                                                   pCAD_CNV_HR_EXPIRA_DIARIA     IN TB_CAD_CNV_CONVENIO.CAD_CNV_HR_EXPIRA_DIARIA%type default NULL,
                                                   pCAD_CNV_VL_FAT_MIN           IN TB_CAD_CNV_CONVENIO.CAD_CNV_VL_FAT_MIN%type default NULL,
                                                   pSEG_USU_ID_USUARIO           IN TB_CAD_CNV_CONVENIO.SEG_USU_ID_USUARIO%type,
                                                   pCAD_CNV_CD_CONVENIO_LEG      IN TB_CAD_CNV_CONVENIO.CAD_CNV_CD_CONVENIO_LEG%type default NULL,
                                                   pCAD_PES_ID_PESSOA            IN TB_CAD_CNV_CONVENIO.CAD_PES_ID_PESSOA%type,
                                                   pAUX_FPG_CD_FORMAPAGTO        IN TB_CAD_CNV_CONVENIO.AUX_FPG_CD_FORMAPAGTO%type default NULL,
                                                   pCAD_CNV_FL_STATUS            IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_STATUS%type,
                                                   pTIS_TFA_CD_TPFATURAMENTO     IN TB_CAD_CNV_CONVENIO.TIS_TFA_CD_TPFATURAMENTO%type default NULL,
                                                   pCAD_CNV_DS_MSK_BENEFIC       IN TB_CAD_CNV_CONVENIO.CAD_CNV_DS_MSK_BENEFIC%type default NULL,
                                                   pCAD_CNV_DS_MASC_MASCARAMATRI IN TB_CAD_CNV_CONVENIO.CAD_CNV_DS_MASC_MASCARAMATRI%TYPE DEFAULT NULL,
                                                   pCAD_CNV_DS_MASCI_MASCARAGUIA IN TB_CAD_CNV_CONVENIO.CAD_CNV_DS_MASCI_MASCARAGUIA%TYPE DEFAULT NULL,
                                                   pCAD_CNV_DS_MASC_MASCARASENH  IN TB_CAD_CNV_CONVENIO.CAD_CNV_DS_MASC_MASCARASENH%TYPE DEFAULT NULL,
                                                   pCAD_CNV_FL_VLD_VALIDADV      IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_VLD_VALIDADV%TYPE DEFAULT NULL,
                                                   pCAD_CNV_FL_GERA_NRGUIA_OK    IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_GERA_NRGUIA_OK%TYPE DEFAULT NULL,
                                                   pCAD_CNV_CD_MODVALIDADOR      IN TB_CAD_CNV_CONVENIO.CAD_CNV_CD_MODVALIDADOR%TYPE DEFAULT NULL,
                                                   pCAD_CNV_NR_INICREDVALIDADOR  IN TB_CAD_CNV_CONVENIO.CAD_CNV_NR_INICREDVALIDADOR%TYPE DEFAULT NULL,
                                                   pCAD_CNV_NR_FIMCREDVALIDADOR  IN TB_CAD_CNV_CONVENIO.CAD_CNV_NR_FIMCREDVALIDADOR%TYPE DEFAULT NULL,
                                                   pCAD_CNV_QT_DIGCREDVALIDADOR  IN Tb_Cad_Cnv_Convenio.Cad_Cnv_Qt_Digcredvalidador%TYPE DEFAULT NULL,
                                                   pCAD_CNV_DS_RAZAOSOCIAL       IN TB_CAD_CNV_CONVENIO.CAD_CNV_DS_RAZAOSOCIAL%TYPE DEFAULT NULL,
                                                   pCAD_CNV_NM_FANTASIA          IN TB_CAD_CNV_CONVENIO.CAD_CNV_NM_FANTASIA%TYPE DEFAULT NULL,
                                                   pCAD_CNV_FL_VERIF_HORA_LOCAL  IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_VERIF_HORARIO_LOCAL%TYPE DEFAULT 'N',                                                   
                                                   pCAD_CNV_FL_VALIDA_SUBPLANOCRE IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_VALIDA_SUBPLANOCRE%TYPE DEFAULT NULL,
                                                   pCAD_CNV_NR_INISUBPLANOCRE     IN TB_CAD_CNV_CONVENIO.CAD_CNV_NR_INISUBPLANOCRE%TYPE DEFAULT NULL,
                                                   pCAD_CNV_NR_FIMSUBPLANOCRE     IN TB_CAD_CNV_CONVENIO.CAD_CNV_NR_FIMSUBPLANOCRE%TYPE DEFAULT NULL,
                                                   pCAD_CNV_FL_EXIGE_VALIDA_CRED IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_EXIGE_VALIDA_CRED%TYPE DEFAULT NULL,
                                                   pCAD_TPE_CD_CODIGO            IN TB_CAD_CNV_CONVENIO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
                                                   pCAD_CNV_FL_VALID_CD_ANS IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_VALID_CD_ANS%TYPE DEFAULT NULL) is
  /********************************************************************
  *    Procedure: PRC_CAD_CNV_CONVENIO_I
  *
  *   Data Alteracao: 04/11/2010  Por: André Souza Monaco
  *   Alteracao: Inclusao dos campos CAD_CNV_FL_VALIDA_SUBPLANOCRE,
  *                                  CAD_CNV_NR_INISUBPLANOCRE e,
  *                                  CAD_CNV_NR_FIMSUBPLANOCRE (tarefa 11787)
  *
  *   Data Alteracao: 16/11/2010  Por: pedro
  *   Alteracao: Inclusao do campo CAD_CNV_FL_EXIGE_VALIDA_CRED
  *
  *   Data Alteracao: 23/08/2011  Por: Fabíola
  *   Alteracao: Inclusão do campo CAD_TPE_CD_CODIGO
  *   Data Alteracao: 03/12/2012  Por: Eduardo Hyppolito
  *   Alteracao: Inclusao do campo CAD_CNV_FL_VALID_CD_ANS
  *
  *******************************************************************/
  lIdtRetorno integer;

begin

  SELECT SEQ_CAD_CNV_01.NextVal INTO lIdtRetorno FROM DUAL;

  INSERT INTO TB_CAD_CNV_CONVENIO
    (CAD_CNV_ID_CONVENIO,
     CAD_CNV_CD_HAC_PRESTADOR,
     CAD_CNV_CD_REG_ANS,
     CAD_CNV_DT_INCLUSAO,
     CAD_CNV_DT_INI_VIGENCIA,
     CAD_CNV_DT_FIM_VIGENCIA,
     CAD_CNV_QT_DIA_CONTA_PARCIAL,
     CAD_CNV_QT_DIA_REALIZ_FATUR,
     CAD_CNV_DS_DIA_EMI_CONTA,
     CAD_CNV_DS_DIA_ENTR_CONTA,
     CAD_CNV_DS_DIA_AUDIT_CONTA,
     CAD_CNV_HR_EXPIRA_DIARIA,
     CAD_CNV_VL_FAT_MIN,
     SEG_USU_ID_USUARIO,
     CAD_CNV_CD_CONVENIO_LEG,
     CAD_CNV_DT_ULTIMA_ATUALIZACAO,
     CAD_PES_ID_PESSOA,
     AUX_FPG_CD_FORMAPAGTO,
     CAD_CNV_FL_STATUS,
     TIS_TFA_CD_TPFATURAMENTO,
     CAD_CNV_DS_MSK_BENEFIC,
     CAD_CNV_DS_MASC_MASCARAMATRI,
     CAD_CNV_DS_MASCI_MASCARAGUIA,
     CAD_CNV_DS_MASC_MASCARASENH,
     CAD_CNV_FL_VLD_VALIDADV,
     CAD_CNV_FL_GERA_NRGUIA_OK,
     CAD_CNV_CD_MODVALIDADOR,
     CAD_CNV_NR_INICREDVALIDADOR,
     CAD_CNV_NR_FIMCREDVALIDADOR,
     CAD_CNV_QT_DIGCREDVALIDADOR,
     CAD_CNV_DS_RAZAOSOCIAL,
     CAD_CNV_NM_FANTASIA,
     CAD_CNV_FL_VERIF_HORARIO_LOCAL,
     CAD_CNV_FL_VALIDA_SUBPLANOCRE,
     CAD_CNV_NR_INISUBPLANOCRE,
     CAD_CNV_NR_FIMSUBPLANOCRE,
     CAD_CNV_FL_EXIGE_VALIDA_CRED,
     CAD_TPE_CD_CODIGO,
     CAD_CNV_FL_VALID_CD_ANS  )
  VALUES
    (lIdtRetorno,
     UPPER(pCAD_CNV_CD_HAC_PRESTADOR),
     pCAD_CNV_CD_REG_ANS,
     sysdate,
     pCAD_CNV_DT_INI_VIGENCIA,
     pCAD_CNV_DT_FIM_VIGENCIA,
     pCAD_CNV_QT_DIA_CONTA_PARCIAL,
     pCAD_CNV_QT_DIA_REALIZ_FATUR,
     UPPER(pCAD_CNV_DS_DIA_EMI_CONTA),
     UPPER(pCAD_CNV_DS_DIA_ENTR_CONTA),
     UPPER(pCAD_CNV_DS_DIA_AUDIT_CONTA),
     pCAD_CNV_HR_EXPIRA_DIARIA,
     pCAD_CNV_VL_FAT_MIN,
     pSEG_USU_ID_USUARIO,
     pCAD_CNV_CD_CONVENIO_LEG,
     sysdate,
     pCAD_PES_ID_PESSOA,
     pAUX_FPG_CD_FORMAPAGTO,
     pCAD_CNV_FL_STATUS,
     pTIS_TFA_CD_TPFATURAMENTO,
     UPPER(pCAD_CNV_DS_MSK_BENEFIC),
     pCAD_CNV_DS_MASC_MASCARAMATRI,
     pCAD_CNV_DS_MASCI_MASCARAGUIA,
     pCAD_CNV_DS_MASC_MASCARASENH,
     pCAD_CNV_FL_VLD_VALIDADV,
     pCAD_CNV_FL_GERA_NRGUIA_OK,
     TRIM(pCAD_CNV_CD_MODVALIDADOR),
     pCAD_CNV_NR_INICREDVALIDADOR,
     pCAD_CNV_NR_FIMCREDVALIDADOR,
     pCAD_CNV_QT_DIGCREDVALIDADOR,
     UPPER(pCAD_CNV_DS_RAZAOSOCIAL),
     UPPER(pCAD_CNV_NM_FANTASIA),
     pCAD_CNV_FL_VERIF_HORA_LOCAL,
     pCAD_CNV_FL_VALIDA_SUBPLANOCRE,
     pCAD_CNV_NR_INISUBPLANOCRE,
     pCAD_CNV_NR_FIMSUBPLANOCRE,
     pCAD_CNV_FL_EXIGE_VALIDA_CRED,
     pCAD_TPE_CD_CODIGO,
     pCAD_CNV_FL_VALID_CD_ANS );

  pNewIdt := lIdtRetorno;

end PRC_CAD_CNV_CONVENIO_I;