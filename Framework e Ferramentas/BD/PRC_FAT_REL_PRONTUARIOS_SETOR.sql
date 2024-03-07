CREATE OR REPLACE PROCEDURE PRC_FAT_REL_PRONTUARIOS_SETOR
(
    pCAD_UNI_ID_UNIDADE TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE,
    pCAD_SET_ID TB_FAT_COP_CONTROLE_PRONTUARIO.CAD_SET_ID%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO TB_CAD_CNV_CONVENIO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
    pFAT_CCP_DT_PARCELA_INI TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_DT_PARCELA%TYPE DEFAULT NULL,
    pFAT_CCP_DT_PARCELA_FIM TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_DT_PARCELA%TYPE DEFAULT NULL,
    pFAT_COP_DT_CHEGADA_INI TB_FAT_COP_CONTROLE_PRONTUARIO.FAT_COP_DT_CHEGADA%TYPE DEFAULT NULL,
    pFAT_COP_DT_CHEGADA_FIM TB_FAT_COP_CONTROLE_PRONTUARIO.FAT_COP_DT_CHEGADA%TYPE DEFAULT NULL,
    pFAT_COP_DT_LIBERACAO_INI TB_FAT_COP_CONTROLE_PRONTUARIO.FAT_COP_DT_LIBERACAO%TYPE DEFAULT NULL,
    pFAT_COP_DT_LIBERACAO_FIM TB_FAT_COP_CONTROLE_PRONTUARIO.FAT_COP_DT_LIBERACAO%TYPE DEFAULT NULL,
    pNO_FATURAMENTO IN DECIMAL DEFAULT NULL, --Quando = 1, so traz registros sem data de liberac?o
    pHORA_CHEGADA_INI IN VARCHAR DEFAULT NULL,
    pHORA_CHEGADA_FIM IN VARCHAR DEFAULT NULL,
    pHORA_LIBERACAO_INI IN VARCHAR DEFAULT NULL,
    pHORA_LIBERACAO_FIM IN VARCHAR DEFAULT NULL,
    pCAD_SET_ID_CHEGADA TB_FAT_COP_CONTROLE_PRONTUARIO.CAD_SET_ID_CHEGADA%TYPE DEFAULT NULL,
    OBSERVACAOSETORORIGEM  IN VARCHAR DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
)
IS
/********************************************************************
*    Procedure: PRC_FAT_REL_PRONTUARIOS_SETOR
*
*    Data Alteracao: 27/12/2012  Por: Andre
*    Data Alteracao: 22/03/2013  Por: Andre
*         Alterac?o: Ajuste da query nos 1? e 3? union 
*                    e adic?o do param. de hora
*    Data Alteracao: 19/04/2013  Por: Andre
*         Alterac?o: Ajuste da query no 3? union 
*    Data Alteracao: 14/02/2014  Por: Andre
*         Alterac?o: Mudanca da query puxando com base do que tiver 
*                    apenas na TB_FAT_COP_CONTROLE_PRONTUARIO 
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
V_WHERE   varchar2(3000);
V_SELECT  varchar2(10000);
V_PERIODO varchar2(500);
begin
V_WHERE := NULL;
IF pCAD_SET_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND COP.CAD_SET_ID = ' || pCAD_SET_ID; END IF;
IF pCAD_SET_ID_CHEGADA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND COP.CAD_SET_ID_CHEGADA = ' || pCAD_SET_ID_CHEGADA; END IF;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pATD_ATE_TP_PACIENTE IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATE.ATD_ATE_TP_PACIENTE = ' ||CHR(39)|| pATD_ATE_TP_PACIENTE ||CHR(39); END IF;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CNV.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO; END IF;
IF pCAD_TPE_CD_CODIGO = 'ACS' THEN
   V_WHERE := V_WHERE || ' AND CNV.CAD_TPE_CD_CODIGO = ''ACS''';
ELSIF pCAD_TPE_CD_CODIGO IS NOT NULL THEN
   V_WHERE := V_WHERE || ' AND CNV.CAD_TPE_CD_CODIGO != ''ACS''';
END IF;
IF NVL(pNO_FATURAMENTO, 0) = 1 THEN V_WHERE := V_WHERE || ' AND COP.FAT_COP_DT_LIBERACAO IS NULL '; END IF;
IF (pFAT_CCP_DT_PARCELA_INI IS NOT NULL) THEN
   V_PERIODO := ' AND (COP.ATD_INA_DT_ALTA BETWEEN ' || CHR(39) || pFAT_CCP_DT_PARCELA_INI || CHR(39) || ' AND ' || CHR(39) || TRUNC(NVL(pFAT_CCP_DT_PARCELA_FIM, SYSDATE)) || CHR(39) || ')';
END IF;
IF (pFAT_COP_DT_CHEGADA_INI IS NOT NULL) THEN
   V_PERIODO := V_PERIODO || ' AND (TO_DATE(TO_CHAR(COP.FAT_COP_DT_CHEGADA, ''DD/MM/YYYY HH24:MI''), ''DD/MM/YYYY HH24:MI'') BETWEEN FNC_JUNTAR_DATA_HORA(TO_DATE(''' || pFAT_COP_DT_CHEGADA_INI || '''), ''' || NVL(pHORA_CHEGADA_INI, 0) || ''') AND NVL(FNC_JUNTAR_DATA_HORA(TO_DATE(''' || pFAT_COP_DT_CHEGADA_FIM || '''), ''' || NVL(pHORA_CHEGADA_FIM, 2359) || '''), SYSDATE))';
END IF;
IF (pFAT_COP_DT_LIBERACAO_INI IS NOT NULL) THEN
   V_WHERE := V_WHERE || ' AND COP.FAT_COP_DT_LIBERACAO IS NOT NULL ';
   V_PERIODO := V_PERIODO || ' AND (TO_DATE(TO_CHAR(COP.FAT_COP_DT_LIBERACAO, ''DD/MM/YYYY HH24:MI''), ''DD/MM/YYYY HH24:MI'') BETWEEN FNC_JUNTAR_DATA_HORA(TO_DATE(''' || pFAT_COP_DT_LIBERACAO_INI || '''), ''' || NVL(pHORA_LIBERACAO_INI, 0) || ''') AND NVL(FNC_JUNTAR_DATA_HORA(TO_DATE(''' || pFAT_COP_DT_LIBERACAO_FIM || '''), ''' || NVL(pHORA_LIBERACAO_FIM, 2359) || '''), SYSDATE))';
   /*V_WHERE := V_WHERE || ' AND COP.FAT_COP_DT_CHEGADA = (SELECT MAX(COP.FAT_COP_DT_CHEGADA)
                                                           FROM TB_FAT_COP_CONTROLE_PRONTUARIO COP
                                                          WHERE COP.ATD_ATE_ID = ATE.ATD_ATE_ID
                                                            AND COP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE 
                                                            AND COP.FAT_COP_DT_LIBERACAO IS NOT NULL) '; */
ELSIF (pFAT_COP_DT_CHEGADA_INI IS NULL) THEN
   V_WHERE := V_WHERE || ' AND COP.FAT_COP_DT_CHEGADA = (SELECT MAX(COP.FAT_COP_DT_CHEGADA)
                                                           FROM TB_FAT_COP_CONTROLE_PRONTUARIO COP
                                                          WHERE COP.ATD_ATE_ID = ATE.ATD_ATE_ID
                                                            AND COP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE) '; 
END IF;

IF (OBSERVACAOSETORORIGEM IS NOT NULL) THEN 
  V_WHERE := V_WHERE || ' and COP.FAT_COP_DS_OBSERVACAO = ' || CHR(39) || OBSERVACAOSETORORIGEM || CHR(39) ;
END IF;

V_SELECT:='SELECT CNV.CAD_CNV_CD_HAC_PRESTADOR,
                   COP.ATD_ATE_ID,
                   PES.CAD_PES_NM_PESSOA,
                   PAC.CAD_PAC_NR_PRONTUARIO,
                   ATE.ATD_ATE_TP_PACIENTE,
                   COP.ATD_INA_DT_ALTA FAT_CCP_DT_PARCELA,
                   COP.FAT_COP_DT_CHEGADA,
                   COP.FAT_COP_DT_LIBERACAO,
                   NVL(SETOR.CAD_SET_DS_SETOR, COP.FAT_COP_DS_OBSERVACAO) CAD_SET_DS_SETOR_DESTINO,
                   COP.CAD_SET_ID,
                   COP.CAD_SET_ID_CHEGADA,
                   SETORC.CAD_SET_DS_SETOR CAD_SET_DS_SETOR_ORIGEM
            FROM TB_FAT_COP_CONTROLE_PRONTUARIO COP
            JOIN TB_ATD_ATE_ATENDIMENTO         ATE  ON ATE.ATD_ATE_ID = COP.ATD_ATE_ID
            JOIN TB_CAD_PAC_PACIENTE            PAC  ON PAC.CAD_PAC_ID_PACIENTE  = COP.CAD_PAC_ID_PACIENTE
            JOIN TB_CAD_PES_PESSOA              PES  ON PES.CAD_PES_ID_PESSOA    = PAC.CAD_PES_ID_PESSOA
            JOIN TB_CAD_CNV_CONVENIO            CNV  ON CNV.CAD_CNV_ID_CONVENIO  = PAC.CAD_CNV_ID_CONVENIO
            LEFT JOIN TB_CAD_SET_SETOR          SETOR ON SETOR.CAD_SET_ID = COP.CAD_SET_ID
            LEFT JOIN TB_CAD_SET_SETOR          SETORC ON SETORC.CAD_SET_ID = COP.CAD_SET_ID_CHEGADA
            WHERE ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO != 46 
           ' || V_WHERE || V_PERIODO ||
           ' ORDER BY 3';
  OPEN v_cursor FOR
   V_SELECT ;
    io_cursor := v_cursor;
END PRC_FAT_REL_PRONTUARIOS_SETOR;
