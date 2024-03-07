CREATE OR REPLACE PROCEDURE SGS."PRC_INT_REL_GUIASAVENCER" (pCAD_CNV_ID_CONVENIO          IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
                                                     pCAD_PLA_ID_PLANO             IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
                                                     pATD_GUI_DT_VALIDADE_INI      IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_VALIDADE%TYPE DEFAULT NULL,
                                                     pATD_GUI_DT_VALIDADE_FIM      IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_VALIDADE%TYPE DEFAULT NULL,
                                                     pCAD_UNI_ID_UNIDADE           IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
                                                     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
                                                     pATD_ATE_TP_PACIENTE          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
                                                     pATD_AIC_TP_SITUACAO_PAC      IN TB_ATD_AIC_ATE_INT_COMPL.ATD_AIC_TP_SITUACAO_PAC%TYPE DEFAULT NULL,
                                                     pCAD_PLA_CD_TIPOPLANO_GB      IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
                                                     pCAD_PLA_CD_TIPOPLANO_PL      IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
                                                     pCAD_PLA_CD_TIPOPLANO_FU      IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
                                                     pCAD_PLA_CD_TIPOPLANO_SP      IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
                                                     io_cursor OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_GUIASAVENCER
  *
  *    Data Criacao:  31/08/2009    Por: pedro
  *    Funcao: Popula o Relatorio de Guias a vencer
  *
  *    Data Alteracao:  11/12/2012  Por: Cristiane Gomes
  *    Alteracao: Nao utilizar OR para tratar parametros nulos para melhorar a performance
  *    Data Alteracao:  12/12/2012  Por: Cristiane Gomes
  *    Alteracao: Considerar somente internac?es e externos ativos
  *******************************************************************/
  v_cursor    PKG_CURSOR.t_cursor;
  V_WHERE     varchar2(2000);
  V_WHERE_AUX varchar2(2000);
  V_SELECT    varchar2(4000);
begin
  V_WHERE     := NULL;
  V_WHERE_AUX := NULL;
  IF pATD_GUI_DT_VALIDADE_INI IS NOT NULL THEN V_WHERE := V_WHERE || ' AND GUI.ATD_GUI_DT_VALIDADE >= ' || CHR(39) || pATD_GUI_DT_VALIDADE_INI || CHR(39); END IF;
  IF pATD_GUI_DT_VALIDADE_FIM IS NOT NULL THEN V_WHERE := V_WHERE || ' AND GUI.ATD_GUI_DT_VALIDADE <= ' || CHR(39) || pATD_GUI_DT_VALIDADE_FIM || CHR(39); END IF;
  IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
  IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
  IF pATD_AIC_TP_SITUACAO_PAC IS NOT NULL THEN V_WHERE := V_WHERE || ' AND AIC.ATD_AIC_TP_SITUACAO_PAC = ' || CHR(39) || pATD_AIC_TP_SITUACAO_PAC || CHR(39); END IF;
  IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CNV.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO; END IF;
  IF pCAD_PLA_ID_PLANO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND PLA.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO; END IF;
  IF pATD_ATE_TP_PACIENTE IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.ATD_ATE_TP_PACIENTE = ' || CHR(39) || pATD_ATE_TP_PACIENTE || CHR(39); END IF;
  IF pCAD_PLA_CD_TIPOPLANO_GB IS NOT NULL AND
     pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND
     pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND
     pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PLA.CAD_PLA_CD_TIPOPLANO NOT IN (' ||
               CHR(39) || 'PA' || CHR(39) || ',' || CHR(39) || 'NP' ||
               CHR(39) || ')';
  ELSE
    IF pCAD_PLA_CD_TIPOPLANO_GB IS NOT NULL OR
       pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL OR
       pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL OR
       pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL THEN
      IF pCAD_PLA_CD_TIPOPLANO_GB IS NOT NULL THEN
        V_WHERE_AUX := V_WHERE_AUX || ' AND PLA.CAD_PLA_CD_TIPOPLANO IN (' ||
                       CHR(39) || 'GB' || CHR(39);
      END IF;
      IF pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL THEN
        IF V_WHERE_AUX IS NULL THEN
          V_WHERE_AUX := V_WHERE_AUX ||
                         ' AND PLA.CAD_PLA_CD_TIPOPLANO IN (' || CHR(39) || 'PL' ||
                         CHR(39);
        ELSE
          V_WHERE_AUX := V_WHERE_AUX || ',' || CHR(39) || 'PL' || CHR(39);
        END IF;
      END IF;
      IF pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL THEN
        IF V_WHERE_AUX IS NULL THEN
          V_WHERE_AUX := V_WHERE_AUX ||
                         ' AND PLA.CAD_PLA_CD_TIPOPLANO IN (' || CHR(39) || 'SP' ||
                         CHR(39);
        ELSE
          V_WHERE_AUX := V_WHERE_AUX || ',' || CHR(39) || 'SP' || CHR(39);
        END IF;
      END IF;
      IF pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL THEN
        IF V_WHERE_AUX IS NULL THEN
          V_WHERE_AUX := V_WHERE_AUX ||
                         ' AND PLA.CAD_PLA_CD_TIPOPLANO IN (' || CHR(39) || 'FU' ||
                         CHR(39);
        ELSE
          V_WHERE_AUX := V_WHERE_AUX || ',' || CHR(39) || 'FU' || CHR(39);
        END IF;
      END IF;
      V_WHERE := V_WHERE || V_WHERE_AUX || ')';
    END IF;
  END IF;
  V_SELECT := ' SELECT DISTINCT ATD.ATD_ATE_ID,CASE
      WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = ' || CHR(39) || 'A' ||
              CHR(39) || '
        AND INA.ATD_INA_DT_ALTA_ADM IS NOT NULL THEN
       NVL(ROUND(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
      WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = ' || CHR(39) || 'I' ||
              CHR(39) || ' THEN
       NVL(ROUND(TRUNC(SYSDATE) - ATD.ATD_ATE_DT_ATENDIMENTO),0)
      ELSE
       0
    END PERMANENCIA,
    UNI.CAD_UNI_DS_UNIDADE UNIDADE,
    LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
    PAC.CAD_PAC_NR_PRONTUARIO,
    PES.CAD_PES_NM_PESSOA PACIENTE,
    DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,' || CHR(39) || 'I' ||
              CHR(39) || ',' || CHR(39) || 'INTERNADO' || CHR(39) || ',' ||
              CHR(39) || 'A' || CHR(39) || ',' || CHR(39) || 'ALTA' ||
              CHR(39) ||
              ') ATD_AIC_TP_SITUACAO_PAC,
       INA.ATD_INA_DT_ALTA_ADM,
       CNV.CAD_CNV_CD_HAC_PRESTADOR,
       CNV.CAD_CNV_NM_FANTASIA,
       PLA.CAD_PLA_CD_TIPOPLANO,
       PLA.CAD_PLA_CD_PLANO_HAC,
       ATD.ATD_ATE_DT_ATENDIMENTO,
       ATD.ATD_ATE_HR_ATENDIMENTO,
       GUI.ATD_GUI_CD_CODIGO,
       GUI.ATD_GUI_CD_SENHA,
       GUI.ATD_GUI_DT_AUTORIZGUIA,
       GUI.ATD_GUI_DT_VALIDADE,
       GUI.ATD_GUI_DIAS_VALIDADE
              FROM TB_ATD_ATE_ATENDIMENTO ATD,
              TB_ASS_PAT_PACIEATEND PAT,
              TB_CAD_PAC_PACIENTE PAC,
              TB_CAD_PES_PESSOA PES,
              TB_CAD_CNV_CONVENIO CNV,
              TB_CAD_PLA_PLANO PLA,
              TB_ATD_AIC_ATE_INT_COMPL AIC,
              TB_ATD_INA_INT_ALTA INA,
              TB_CAD_UNI_UNIDADE UNI,
              TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
              TB_ATD_GUI_GUIAATEND GUI
              WHERE PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
              AND ATD.ATD_ATE_FL_STATUS = '|| CHR(39) ||'A'|| CHR(39) ||
              'AND PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(ATD.ATD_ATE_ID)
              AND PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
              AND CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
              AND PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
              AND AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
              AND INA.ATD_ATE_ID (+) = ATD.ATD_ATE_ID
              AND UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
              AND LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
              AND ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29
              AND GUI.ATD_ATE_ID (+) = ATD.ATD_ATE_ID ' ||
              V_WHERE;
  OPEN v_cursor FOR V_SELECT;
  io_cursor := v_cursor;
end PRC_INT_REL_GUIASAVENCER;


 