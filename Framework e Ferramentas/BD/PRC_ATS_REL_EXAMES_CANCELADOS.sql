CREATE OR REPLACE PROCEDURE "PRC_ATS_REL_EXAMES_CANCELADOS"
 (
     pCAD_UNI_ID_UNIDADE in TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_ATS_ATE_ATENDIMENTO_SADT.Aux_Epp_Cd_Especproc%type DEFAULT NULL,
     pCAD_PRD_ID IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE DEFAULT NULL,
     pCAD_PRO_ID_PROFISSIONAL IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
     pATS_APL_STATUS_LAUDO IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_STATUS_LAUDO%TYPE DEFAULT NULL,
     pATS_ATE_TP_PROCED IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_TP_PROCED%TYPE DEFAULT NULL,
     pATS_ATE_IN_INTLIB IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_IN_INTLIB%type DEFAULT NULL,
     pDT_INI_CONSULTA IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_DT_REALIZ_PROCED%TYPE DEFAULT NULL,
     pDT_FIM_CONSULTA IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_DT_REALIZ_PROCED%TYPE DEFAULT NULL,
     pHR_INI_CONSULTA IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_HR_REALIZ_PROCED%TYPE DEFAULT NULL,
     pHR_FIM_CONSULTA IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_HR_REALIZ_PROCED%TYPE DEFAULT NULL,
     pREALIZADO NUMBER DEFAULT NULL,
          pATS_ATE_FL_REPETICAO IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_FL_REPETICAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_REL_EXAMES_CANCELADOS
  *
  *    Data Criacao:   04/06/2009       Por: Pedro
  *    Data Alteracao:  29/03/2010       Pedro
  *    JOIN EPP - TIS_MED_CD_TABELAMEDICA
  *
  *    Funcao: Alimentar o relatorio de Atendimentos Cancelados
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
   V_WHERE  varchar2(3000);
  V_ORDERBY  varchar2(1000);
  V_SELECT  varchar2(28000);
  begin
    V_WHERE := NULL;
    V_ORDERBY := NULL;

     IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE := V_WHERE || ' AND UNI.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
    IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
    IF pCAD_PRD_ID IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATS.CAD_PRD_ID = ' || pCAD_PRD_ID; END IF;
    IF pCAD_SET_ID IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATS.CAD_SET_ID_ATEN = ' || pCAD_SET_ID; END IF;
   IF pAUX_EPP_CD_ESPECPROC IS NOT NULL THEN V_WHERE := V_WHERE || ' AND EPP.AUX_EPP_CD_ESPECPROC = ' ||CHR(39)|| pAUX_EPP_CD_ESPECPROC ||CHR(39); END IF;
   IF pCAD_PRO_ID_PROFISSIONAL IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATS.CAD_PRO_ID_PROF_EXECUTANTE = ' || pCAD_PRO_ID_PROFISSIONAL; END IF;

   IF pATS_ATE_IN_INTLIB IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATS.ATS_ATE_IN_INTLIB = ' ||CHR(39)|| pATS_ATE_IN_INTLIB ||CHR(39); END IF;
   IF pATS_APL_STATUS_LAUDO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND APL.ATS_APL_STATUS_LAUDO = ' ||CHR(39)|| pATS_APL_STATUS_LAUDO ||CHR(39); END IF;
   IF pATS_ATE_TP_PROCED IS NOT NULL THEN V_WHERE := V_WHERE || ' AND APL.ATS_ATE_TP_PROCED = ' ||CHR(39)|| pATS_ATE_TP_PROCED ||CHR(39); END IF;

   IF pATS_ATE_FL_REPETICAO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATS.ATS_ATE_FL_REPETICAO = ' ||CHR(39)||    pATS_ATE_FL_REPETICAO ||CHR(39); END IF;
   IF pREALIZADO IS NOT NULL AND pREALIZADO = 0 THEN V_WHERE := V_WHERE || ' AND APL.ATS_APL_STATUS_LAUDO IS NULL ' ; END IF;
 --if (((pHR_INI_CONSULTA IS NULL) AND (pHR_FIM_CONSULTA IS NULL)) OR (pHR_INI_CONSULTA < pHR_FIM_CONSULTA)  ) THEN
    IF pDT_INI_CONSULTA IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND TRUNC(ATS.ATS_ATE_DT_REALIZ_PROCED) >= ' ||CHR(39)|| pDT_INI_CONSULTA ||CHR(39);    END IF;
    IF pDT_FIM_CONSULTA IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND TRUNC(ATS.ATS_ATE_DT_REALIZ_PROCED) <= ' ||CHR(39)|| pDT_FIM_CONSULTA ||CHR(39);    END IF;
    IF pHR_INI_CONSULTA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ats.ats_ate_hr_realiz_proced >= ' || pHR_INI_CONSULTA; end if;
    IF pHR_FIM_CONSULTA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ats.ats_ate_hr_realiz_proced <= ' || pHR_FIM_CONSULTA; end if;
-- END IF;
 --if ((pHR_INI_CONSULTA IS NOT NULL) AND (pHR_FIM_CONSULTA IS NOT NULL)) AND  (pHR_INI_CONSULTA > pHR_FIM_CONSULTA) THEN
 --   IF pDT_INI_CONSULTA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND fnc_juntar_data_hora(ATS.ATS_ATE_DT_REALIZ_PROCED,ATS.ats_ate_hr_realiz_proced) >= ' ||CHR(39)|| fnc_juntar_data_hora(pDT_INI_CONSULTA,pHR_INI_CONSULTA) ||CHR(39);    END IF;
 --   IF pDT_FIM_CONSULTA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND fnc_juntar_data_hora(ATS.ATS_ATE_DT_REALIZ_PROCED,ATS.ats_ate_hr_realiz_proced) <= ' ||CHR(39)|| fnc_juntar_data_hora(pDT_FIM_CONSULTA,pHR_FIM_CONSULTA) ||CHR(39);    END IF;
 --end if;


 V_SELECT :=
   '
    SELECT distinct
      ATS.ATS_ATE_ID,
      ATS.ATS_ATE_CD_INTLIB,
      ATS.ATS_ATE_IN_INTLIB,
      UNI.CAD_UNI_DS_UNIDADE,
      PRD.CAD_PRD_DS_DESCRICAO,
      EPP.AUX_EPP_DS_DESCRICAO ,
       case when ATS.ATS_ATE_FL_RN = ''S'' then IDR.ATD_IDR_NM_NOME
           -- WHEN PAC.CAD_PAC_IDT_RN = 1 AND PES_PAC.CAD_PES_NM_RN IS NOT NULL THEN PES_PAC.CAD_PES_NM_RN
            ELSE PES_PAC.CAD_PES_NM_PESSOA
        END CAD_PES_NM_PESSOA,
        case when ATS.ATS_ATE_FL_RN = ''S'' then IDR.ATD_IDR_DT_NASCIMENTO
            ELSE PES_PAC.CAD_PES_DT_NASCIMENTO
        END CAD_PES_DT_NASCIMENTO,
      ATS.ATS_ATE_DT_REALIZ_PROCED,
      ATS.ATS_ATE_HR_REALIZ_PROCED,
      LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
      DECODE(ATS.ATS_ATE_TP_PROCED,''R'',''ROTINA'',''U'',''URGENCIA'')ATS_ATE_TP_PROCED,
      SETOR_EXEC.CAD_SET_DS_SETOR SETOR_EXECUCAO,
      SETOR_PROCED.CAD_SET_DS_PROCEDENCIA,
      DECODE(APL.ATS_APL_STATUS_LAUDO, ''L'',''LAUDADO'',''I'',
      ''IMPRESSO'',''P'',''PROTOCOLADO'',''E'',''ENTREGUE'',''R'',''ATENDIDO'','''',''ATENDIDO'')ATS_APL_STATUS_LAUDO,
      PRD.CAD_PRD_NM_MNEMONICO,
       ATS.ATS_ATE_FL_REPETICAO
FROM TB_ATS_ATE_ATENDIMENTO_SADT ATS
      LEFT JOIN TB_ATS_APL_ATEN_PROCED_LAUDO APL
     ON APL.ATS_ATE_ID = ATS.ATS_ATE_ID
     AND APL.ATS_ATE_CD_INTLIB = ATS.ATS_ATE_CD_INTLIB
     AND APL.ATS_ATE_IN_INTLIB = ATS.ATS_ATE_IN_INTLIB
     AND APL.AUX_EPP_CD_ESPECPROC = ATS.AUX_EPP_CD_ESPECPROC
     AND APL.CAD_PRD_ID = ATS.CAD_PRD_ID
     AND APL.TIS_MED_CD_TABELAMEDICA = ATS.TIS_MED_CD_TABELAMEDICA
     LEFT JOIN TB_CAD_SET_SETOR SETOR_EXEC
     ON SETOR_EXEC.CAD_SET_ID = ATS.CAD_SET_ID_ATEN
     LEFT JOIN TB_CAD_SET_SETOR SETOR_PROCED
     ON SETOR_PROCED.CAD_SET_ID = ATS.CAD_SET_ID
     LEFT JOIN TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR_EXEC.CAD_UNI_ID_UNIDADE
     LEFT JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = SETOR_EXEC.CAD_LAT_ID_LOCAL_ATENDIMENTO
     LEFT JOIN TB_CAD_PRD_PRODUTO PRD ON PRD.CAD_PRD_ID = ATS.CAD_PRD_ID
     LEFT JOIN TB_AUX_EPP_ESPECPROC EPP ON EPP.AUX_EPP_CD_ESPECPROC = ATS.AUX_EPP_CD_ESPECPROC
               AND EPP.TIS_MED_CD_TABELAMEDICA = ATS.TIS_MED_CD_TABELAMEDICA
     LEFT JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = ATS.CAD_PAC_ID_PACIENTE_INT
     LEFT JOIN TB_CAD_PES_PESSOA PES_PAC ON PES_PAC.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
   LEFT JOIN TB_ATD_IDR_INT_DADOS_RN IDR ON IDR.ATD_IDR_ID = ATS.ATS_ATE_ID_RN     
WHERE (ATS.ATS_ATE_FL_STATUS = ''C'')' || V_WHERE ;

   -- TESTE :=  V_SELECT ;
OPEN v_cursor FOR
   V_SELECT ;
   -- SELECT 1 FROM DUAL;
    io_cursor := v_cursor;
  end PRC_ATS_REL_EXAMES_CANCELADOS;
