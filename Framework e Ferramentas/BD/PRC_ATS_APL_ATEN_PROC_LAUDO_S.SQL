create or replace procedure PRC_ATS_APL_ATEN_PROC_LAUDO_S(pATS_APL_ID                    IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_ID%type DEFAULT NULL,
                                                          pATS_ATE_ID                    IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_ATE_ID%type DEFAULT NULL,
                                                          pATS_APL_DT_LAUDO              IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_DT_LAUDO%type DEFAULT NULL,
                                                          pATS_APL_HR_LAUDO              IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_HR_LAUDO%type DEFAULT NULL,
                                                          pATS_APL_DS_OBSERVACAO         IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_DS_OBSERVACAO%type DEFAULT NULL,
                                                          pCAD_PRO_ID_PROF               IN TB_ATS_APL_ATEN_PROCED_LAUDO.CAD_PRO_ID_PROF%type DEFAULT NULL,
                                                          pCAD_CLC_ID                    IN TB_ATS_APL_ATEN_PROCED_LAUDO.CAD_CLC_ID%type DEFAULT NULL,
                                                          pATS_APL_STATUS_LAUDO          IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_STATUS_LAUDO%type DEFAULT NULL,
                                                          pATS_APL_DT_ULTIMA_ATUALIZACAO IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
                                                          pSEG_USU_ID_USUARIO            IN TB_ATS_APL_ATEN_PROCED_LAUDO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
                                                          -- pATS_APL_TEXTO_LAUDO IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_TEXTO_LAUDO%type DEFAULT NULL,
                                                          pAUX_EPP_CD_ESPECPROC    IN TB_ATS_APL_ATEN_PROCED_LAUDO.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
                                                          pATS_ATE_IN_INTLIB       IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_ATE_IN_INTLIB%type DEFAULT NULL,
                                                          pATS_ATE_CD_INTLIB       IN TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_ATE_CD_INTLIB%type DEFAULT NULL,
                                                          pCAD_PRD_ID              IN TB_ATS_APL_ATEN_PROCED_LAUDO.CAD_PRD_ID%type DEFAULT NULL,
                                                          pTIS_MED_CD_TABELAMEDICA IN TB_ATS_APS_ATEN_PROC_SEGMENTO.TIS_MED_CD_TABELAMEDICA%type default null,
                                                          io_cursor                OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_ATS_APL_ATEN_PROC_LAUDO_S
  * 
  *    Data Criacao:  18/11/2008       Por: FabÃ­ola Lopes
  *    Data Alteracao:  27/03/2010  Por: Pedro
  *    Alteração: pTIS_MED_CD_TABELAMEDICA
  *
  *    Funcao: Recupera os dados do Laudo do Procedimento/Exame
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT varchar2(4000);
begin
  V_WHERE := NULL;
  IF pATS_APL_ID IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATS_APL_ID = ' || pATS_APL_ID;
    ELSE
      V_WHERE := V_WHERE || ' ATS_APL_ID =  ' || pATS_APL_ID;
    END IF;
  END IF;
  IF pATS_ATE_ID IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATS_ATE_ID = ' || pATS_ATE_ID;
    ELSE
      V_WHERE := V_WHERE || ' ATS_ATE_ID = ' || pATS_ATE_ID;
    END IF;
  END IF;
  IF pATS_APL_DT_LAUDO IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATS_APL_DT_LAUDO = ' || pATS_APL_DT_LAUDO;
    ELSE
      V_WHERE := V_WHERE || ' ATS_APL_DT_LAUDO = ' || pATS_APL_DT_LAUDO;
    END IF;
  END IF;
  IF pATS_APL_HR_LAUDO IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATS_APL_HR_LAUDO = ' || pATS_APL_HR_LAUDO;
    ELSE
      V_WHERE := V_WHERE || ' ATS_APL_HR_LAUDO = ' || pATS_APL_HR_LAUDO;
    END IF;
  END IF;
  IF pATS_APL_DS_OBSERVACAO IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATS_APL_DS_OBSERVACAO = ' || CHR(39) ||
                 pATS_APL_DS_OBSERVACAO || CHR(39);
    ELSE
      V_WHERE := V_WHERE || ' ATS_APL_DS_OBSERVACAO = ' || CHR(39) ||
                 pATS_APL_DS_OBSERVACAO || CHR(39);
    END IF;
  END IF;
  IF pCAD_PRO_ID_PROF IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_PRO_ID_PROF = ' || pCAD_PRO_ID_PROF;
    ELSE
      V_WHERE := V_WHERE || ' CAD_PRO_ID_PROF = ' || pCAD_PRO_ID_PROF;
    END IF;
  END IF;
  IF pCAD_CLC_ID IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_CLC_ID = ' || pCAD_CLC_ID;
    ELSE
      V_WHERE := V_WHERE || ' CAD_CLC_ID = ' || pCAD_CLC_ID;
    END IF;
  END IF;
  IF pATS_APL_STATUS_LAUDO IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATS_APL_STATUS_LAUDO = ' || CHR(39) ||
                 pATS_APL_STATUS_LAUDO || CHR(39);
    ELSE
      V_WHERE := V_WHERE || ' ATS_APL_STATUS_LAUDO = ' || CHR(39) ||
                 pATS_APL_STATUS_LAUDO || CHR(39);
    END IF;
  END IF;
  IF pATS_APL_DT_ULTIMA_ATUALIZACAO IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATS_APL_DT_ULTIMA_ATUALIZACAO = ' ||
                 pATS_APL_DT_ULTIMA_ATUALIZACAO;
    ELSE
      V_WHERE := V_WHERE || ' ATS_APL_DT_ULTIMA_ATUALIZACAO = ' ||
                 pATS_APL_DT_ULTIMA_ATUALIZACAO;
    END IF;
  END IF;
  IF pSEG_USU_ID_USUARIO IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND SEG_USU_ID_USUARIO = ' ||
                 pSEG_USU_ID_USUARIO;
    ELSE
      V_WHERE := V_WHERE || ' SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO;
    END IF;
  END IF;
  IF pAUX_EPP_CD_ESPECPROC IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND AUX_EPP_CD_ESPECPROC = ' || CHR(39) ||
                 pAUX_EPP_CD_ESPECPROC || CHR(39);
    ELSE
      V_WHERE := V_WHERE || ' AUX_EPP_CD_ESPECPROC = ' || CHR(39) ||
                 pAUX_EPP_CD_ESPECPROC || CHR(39);
    END IF;
  END IF;
  IF pATS_ATE_IN_INTLIB IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATS_ATE_IN_INTLIB = ' || CHR(39) ||
                 pATS_ATE_IN_INTLIB || CHR(39);
    ELSE
      V_WHERE := V_WHERE || ' ATS_ATE_IN_INTLIB = ' || CHR(39) ||
                 pATS_ATE_IN_INTLIB || CHR(39);
    END IF;
  END IF;
  IF pATS_ATE_CD_INTLIB IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATS_ATE_CD_INTLIB = ' ||
                 pATS_ATE_CD_INTLIB;
    ELSE
      V_WHERE := V_WHERE || ' ATS_ATE_CD_INTLIB = ' || pATS_ATE_CD_INTLIB;
    END IF;
  END IF;
  IF pCAD_PRD_ID IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_PRD_ID = ' || pCAD_PRD_ID;
    ELSE
      V_WHERE := V_WHERE || ' CAD_PRD_ID = ' || pCAD_PRD_ID;
    END IF;
  END IF;
  IF pTIS_MED_CD_TABELAMEDICA IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND TIS_MED_CD_TABELAMEDICA = ' || CHR(39) ||
                 pTIS_MED_CD_TABELAMEDICA || CHR(39);
    ELSE
      V_WHERE := V_WHERE || ' TIS_MED_CD_TABELAMEDICA = ' || CHR(39) ||
                 pTIS_MED_CD_TABELAMEDICA || CHR(39);
    END IF;
  END IF;
  V_SELECT := '    SELECT ATS_APL_ID,
           ATS_ATE_ID,
           ATS_APL_DT_LAUDO,
           ATS_APL_HR_LAUDO,
           ATS_APL_DS_OBSERVACAO,
           CAD_PRO_ID_PROF,
           CAD_CLC_ID,
           ATS_APL_STATUS_LAUDO,
           ATS_APL_DT_ULTIMA_ATUALIZACAO,
           SEG_USU_ID_USUARIO,
           ATS_APL_TEXTO_LAUDO,
           AUX_EPP_CD_ESPECPROC,
           ATS_ATE_IN_INTLIB,
           ATS_ATE_CD_INTLIB,
           CAD_PRD_ID,
           TIS_MED_CD_TABELAMEDICA
      FROM TB_ATS_APL_ATEN_PROCED_LAUDO
     WHERE ' || V_WHERE;
  OPEN v_cursor FOR V_SELECT;
  io_cursor := v_cursor;
end PRC_ATS_APL_ATEN_PROC_LAUDO_S;
/
