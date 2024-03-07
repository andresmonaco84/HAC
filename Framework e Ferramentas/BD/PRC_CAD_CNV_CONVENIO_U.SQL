CREATE OR REPLACE PROCEDURE "PRC_CAD_CNV_CONVENIO_U" (pCAD_CNV_ID_CONVENIO          IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,
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
                                                   pCAD_CNV_QT_DIGCREDVALIDADOR  IN TB_CAD_CNV_CONVENIO.CAD_CNV_QT_DIGCREDVALIDADOR%TYPE DEFAULT NULL,
                                                   pCAD_CNV_DS_RAZAOSOCIAL       IN TB_CAD_CNV_CONVENIO.CAD_CNV_DS_RAZAOSOCIAL%TYPE DEFAULT NULL,
                                                   pCAD_CNV_NM_FANTASIA          IN TB_CAD_CNV_CONVENIO.CAD_CNV_NM_FANTASIA%TYPE DEFAULT NULL,
                                                   pCAD_CNV_FL_VERIF_HORA_LOCAL  IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_VERIF_HORARIO_LOCAL%TYPE DEFAULT 'N',
                                                   pCAD_CNV_FL_VALIDA_SUBPLANOCRE IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_VALIDA_SUBPLANOCRE%TYPE DEFAULT NULL,
                                                   pCAD_CNV_NR_INISUBPLANOCRE     IN TB_CAD_CNV_CONVENIO.CAD_CNV_NR_INISUBPLANOCRE%TYPE DEFAULT NULL,
                                                   pCAD_CNV_NR_FIMSUBPLANOCRE     IN TB_CAD_CNV_CONVENIO.CAD_CNV_NR_FIMSUBPLANOCRE%TYPE DEFAULT NULL,
                                                   pCAD_CNV_FL_EXIGE_VALIDA_CRED IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_EXIGE_VALIDA_CRED%TYPE DEFAULT NULL,
                                                   pCAD_TPE_CD_CODIGO             IN TB_CAD_CNV_CONVENIO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
                                                   pCAD_CNV_FL_VALID_CD_ANS IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_VALID_CD_ANS%TYPE DEFAULT NULL) is
  /********************************************************************
  *    Procedure: PRC_CAD_CNV_CONVENIO_U
  *
  *
  *   Data Alteracao: 04/11/2010  Por: Andre Souza Monaco
  *   Alteracao: Inclusao dos campos CAD_CNV_FL_VALIDA_SUBPLANOCRE,
  *                                  CAD_CNV_NR_INISUBPLANOCRE e,
  *                                  CAD_CNV_NR_FIMSUBPLANOCRE (tarefa 11787)
  *
  *   Data Alteracao: 16/11/2010  Por: pedro
  *   Alteracao: Inclusao do campo CAD_CNV_FL_EXIGE_VALIDA_CRED 
  *
  *    Data Alteracao: 23/08/2011   Por: Fabiola
  *    Alterac?o: Inclus?o do campo CAD_TPE_CD_CODIGO
  *
  *   Data Alteracao: 03/12/2012  Por: Eduardo Hyppolito
  *   Alteracao: Inclusao do campo CAD_CNV_FL_VALID_CD_ANS
  *******************************************************************/
vCAD_CNV_DT_FIM_VIGENCIA_AUX TB_CAD_CNV_CONVENIO.CAD_CNV_DT_FIM_VIGENCIA%type;
vFinalizarVigencia boolean;
begin
  vFinalizarVigencia := true;
  vCAD_CNV_DT_FIM_VIGENCIA_AUX := pCAD_CNV_DT_FIM_VIGENCIA;
  --Valida se o status ou data de fim de vigencia informados s?o iguais dos ja existentes
  FOR vConvenio IN (SELECT CNV.CAD_CNV_ID_CONVENIO
                      FROM TB_CAD_CNV_CONVENIO CNV
                     WHERE CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                       AND ((TO_CHAR(CNV.CAD_CNV_DT_FIM_VIGENCIA, 'dd/mm/yyyy') = TO_CHAR(vCAD_CNV_DT_FIM_VIGENCIA_AUX, 'dd/mm/yyyy')) OR (CNV.CAD_CNV_DT_FIM_VIGENCIA IS NULL AND vCAD_CNV_DT_FIM_VIGENCIA_AUX IS NULL))
                       AND UPPER(CNV.CAD_CNV_FL_STATUS) = UPPER(pCAD_CNV_FL_STATUS))
  LOOP
      vFinalizarVigencia := false;
  END LOOP;
  --Quando o convenio e inativado, a data de fim de vigencia deve ser nula.
  IF (pCAD_CNV_FL_STATUS = 'I') THEN
     vCAD_CNV_DT_FIM_VIGENCIA_AUX := NULL;
  END IF;
  UPDATE TB_CAD_CNV_CONVENIO
     SET CAD_CNV_CD_HAC_PRESTADOR       = UPPER(pCAD_CNV_CD_HAC_PRESTADOR),
         CAD_CNV_CD_REG_ANS             = pCAD_CNV_CD_REG_ANS,
         CAD_CNV_DT_INI_VIGENCIA        = pCAD_CNV_DT_INI_VIGENCIA,
         CAD_CNV_DT_FIM_VIGENCIA        = vCAD_CNV_DT_FIM_VIGENCIA_AUX,
         CAD_CNV_QT_DIA_CONTA_PARCIAL  = pCAD_CNV_QT_DIA_CONTA_PARCIAL,
    --     CAD_CNV_QT_DIA_REALIZ_FATUR   = pCAD_CNV_QT_DIA_REALIZ_FATUR,
     --    CAD_CNV_DS_DIA_EMI_CONTA      = UPPER(pCAD_CNV_DS_DIA_EMI_CONTA),
    --     CAD_CNV_DS_DIA_ENTR_CONTA     = UPPER(pCAD_CNV_DS_DIA_ENTR_CONTA),
     --    CAD_CNV_DS_DIA_AUDIT_CONTA    = UPPER(pCAD_CNV_DS_DIA_AUDIT_CONTA),
         CAD_CNV_HR_EXPIRA_DIARIA       = pCAD_CNV_HR_EXPIRA_DIARIA,
     --    CAD_CNV_VL_FAT_MIN            = pCAD_CNV_VL_FAT_MIN,
         SEG_USU_ID_USUARIO             = pSEG_USU_ID_USUARIO,
         CAD_CNV_CD_CONVENIO_LEG        = pCAD_CNV_CD_CONVENIO_LEG,
         CAD_CNV_DT_ULTIMA_ATUALIZACAO  = sysdate,
         CAD_PES_ID_PESSOA              = pCAD_PES_ID_PESSOA,
     --    AUX_FPG_CD_FORMAPAGTO         = pAUX_FPG_CD_FORMAPAGTO,
         CAD_CNV_FL_STATUS              = pCAD_CNV_FL_STATUS,
     --    TIS_TFA_CD_TPFATURAMENTO      = pTIS_TFA_CD_TPFATURAMENTO,
         CAD_CNV_DS_MSK_BENEFIC         = UPPER(pCAD_CNV_DS_MSK_BENEFIC),
         CAD_CNV_DS_MASC_MASCARAMATRI   = pCAD_CNV_DS_MASC_MASCARAMATRI,
         CAD_CNV_DS_MASCI_MASCARAGUIA   = pCAD_CNV_DS_MASCI_MASCARAGUIA,
         CAD_CNV_DS_MASC_MASCARASENH    = pCAD_CNV_DS_MASC_MASCARASENH,
         CAD_CNV_FL_VLD_VALIDADV        = pCAD_CNV_FL_VLD_VALIDADV,
         CAD_CNV_FL_GERA_NRGUIA_OK      = pCAD_CNV_FL_GERA_NRGUIA_OK,
         CAD_CNV_CD_MODVALIDADOR        = pCAD_CNV_CD_MODVALIDADOR,
         CAD_CNV_NR_INICREDVALIDADOR    = pCAD_CNV_NR_INICREDVALIDADOR,
         CAD_CNV_NR_FIMCREDVALIDADOR    = pCAD_CNV_NR_FIMCREDVALIDADOR,
         CAD_CNV_QT_DIGCREDVALIDADOR    = pCAD_CNV_QT_DIGCREDVALIDADOR,
         CAD_CNV_DS_RAZAOSOCIAL         = UPPER(pCAD_CNV_DS_RAZAOSOCIAL),
         CAD_CNV_NM_FANTASIA            = UPPER(pCAD_CNV_NM_FANTASIA),
         CAD_CNV_FL_VERIF_HORARIO_LOCAL = pCAD_CNV_FL_VERIF_HORA_LOCAL,
         CAD_CNV_FL_VALIDA_SUBPLANOCRE  = pCAD_CNV_FL_VALIDA_SUBPLANOCRE,
         CAD_CNV_NR_INISUBPLANOCRE      = pCAD_CNV_NR_INISUBPLANOCRE,
         CAD_CNV_NR_FIMSUBPLANOCRE      = pCAD_CNV_NR_FIMSUBPLANOCRE,
         CAD_CNV_FL_EXIGE_VALIDA_CRED   = pCAD_CNV_FL_EXIGE_VALIDA_CRED,
         CAD_TPE_CD_CODIGO              = pCAD_TPE_CD_CODIGO,
         CAD_CNV_FL_VALID_CD_ANS      = pCAD_CNV_FL_VALID_CD_ANS
   WHERE CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;
   --Quando o convenio e inativado, a data de fim de
   --vigencia dos seus itens deve ser a data atual.
   IF (pCAD_CNV_FL_STATUS = 'I') THEN
     SELECT SYSDATE INTO vCAD_CNV_DT_FIM_VIGENCIA_AUX FROM DUAL;
   END IF;
   IF vFinalizarVigencia THEN
     --Finaliza a vigencia dos itens
     PRC_CAD_CNV_FINALIZAR_VIGENCIA(pCAD_CNV_ID_CONVENIO,
                                    vCAD_CNV_DT_FIM_VIGENCIA_AUX,
                                    pCAD_CNV_FL_STATUS,
                                    pSEG_USU_ID_USUARIO);
   END IF;
end PRC_CAD_CNV_CONVENIO_U;
 