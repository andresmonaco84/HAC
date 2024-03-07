CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_QTD_MAX_ITENS"
(
    pQTD_ITENS                    INTEGER DEFAULT NULL,
    pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO          IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_SET_ID                   IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_INI   IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_FIM   IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pTIS_TAT_CD_TPATENDIMENTO     IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_GB varchar2 default null,
    pCAD_PLA_CD_TIPOPLANO_PL varchar2 default null,
    pCAD_PLA_CD_TIPOPLANO_FU varchar2 default null,
    pCAD_PLA_CD_TIPOPLANO_NP varchar2 default null,
    pCAD_PLA_CD_TIPOPLANO_PA varchar2 default null,
    pCAD_PLA_CD_TIPOPLANO_SP varchar2 default null,
    pATD_ATE_TP_PACIENTE_I varchar2 default null,
    pATD_ATE_TP_PACIENTE_E varchar2 default null,
    pATD_ATE_TP_PACIENTE_A varchar2 default null,
    pATD_ATE_TP_PACIENTE_U varchar2 default null,
    pCAD_PRD_FL_FRACIONADO_I varchar2 default null,
    pCAD_PRD_FL_FRACIONADO_F varchar2 default null,
    pCAD_TAP_TP_ATRIBUTO_TAX varchar2 default null,
    pCAD_TAP_TP_ATRIBUTO_DIA varchar2 default null,
    pCAD_TAP_TP_ATRIBUTO_MAT varchar2 default null,
    pCAD_TAP_TP_ATRIBUTO_MED varchar2 default null,
    pCAD_TAP_TP_ATRIBUTO_HM  varchar2 default null,
    pCAD_TAP_TP_ATRIBUTO_EXA varchar2 default null,
    pCAD_TAP_TP_ATRIBUTO_GAS varchar2 default null,
    pCAD_TAP_TP_ATRIBUTO_PAC varchar2 default null,
    pCAD_PRD_ID              IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE DEFAULT NULL,
    pFAIXA_INI               varchar2 default null,
    pFAIXA_FIM               varchar2 default null,
    pFATURADO                varchar2 default null,
    pLOTEGERADO              varchar2 default null,
    pAUDITORIA               VARCHAR2 DEFAULT NULL,
    pEMITIDO                 varchar2 default null,
    pDIGITADO                varchar2 default null,
    pFAT_CCP_MES_FAT         IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT%TYPE DEFAULT NULL,
    pFAT_CCP_ANO_FAT         IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT%TYPE DEFAULT NULL,
    IO_CURSOR                OUT PKG_CURSOR.T_CURSOR--,
    --TESTE OU LONG
)
IS
/********************************************************************
*    PROCEDURE: PRC_FAT_REL_QTD_MAX_ITENS
*    DATA ALTERACAO: 18/7/2011  POR: PEDRO
*    ALTERAÇÃO:  AND  (UNI.CAD_UNI_FL_FATURA_UNID_OK = '||chr(39)||'S'||chr(39)||')
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(1000);
  V_WHERE2  varchar2(3000);
  V_SELECT  varchar2(30000);
  begin
    V_WHERE := NULL;
    IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND ATD.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE;
    END IF;
    IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO;
    END IF;
    IF pCAD_SET_ID IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND ATD.CAD_SET_ID = ' || pCAD_SET_ID;
    END IF;
    IF pFAT_CCP_MES_FAT IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_MES_FECHAMENTO = ' || pFAT_CCP_MES_FAT;
    END IF;
    IF pFAT_CCP_ANO_FAT IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_ANO_FECHAMENTO = ' || pFAT_CCP_ANO_FAT;
    END IF;
    IF pCAD_PRD_ID IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CCI.CAD_PRD_ID = ' || pCAD_PRD_ID;
    END IF;
    IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND ATD.ATD_ATE_DT_ATENDIMENTO >= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_INI ||CHR(39);
    END IF;
    IF pATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND ATD.ATD_ATE_DT_ATENDIMENTO <= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_FIM ||CHR(39);
    END IF;
    IF pFAIXA_INI IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_VL_CALCULADO >= ' ||CHR(39)|| pFAIXA_INI ||CHR(39);
    END IF;
    IF pFAIXA_FIM IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_VL_CALCULADO <= ' ||CHR(39)|| pFAIXA_FIM ||CHR(39);
    END IF;
    IF pTIS_TAT_CD_TPATENDIMENTO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND ATD.TIS_TAT_CD_TPATENDIMENTO = ' ||CHR(39)|| pTIS_TAT_CD_TPATENDIMENTO ||CHR(39);
    END IF;
  V_WHERE2 := NULL;
   IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN
       V_WHERE2 := V_WHERE2 || ' AND ATD.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE;
    END IF;
    IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
       V_WHERE2 := V_WHERE2 || ' AND ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO;
    END IF;
    IF pCAD_SET_ID IS NOT NULL THEN
       V_WHERE2 := V_WHERE2 || ' AND ATD.CAD_SET_ID = ' || pCAD_SET_ID;
    END IF;
    IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN
       V_WHERE2 := V_WHERE2 || ' AND PAC.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;
    END IF;
     IF pTIS_TAT_CD_TPATENDIMENTO IS NOT NULL THEN
       V_WHERE2 := V_WHERE2 || ' AND ATD.TIS_TAT_CD_TPATENDIMENTO = ' ||CHR(39)|| pTIS_TAT_CD_TPATENDIMENTO ||CHR(39);
    END IF;
     IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL THEN
       V_WHERE2 := V_WHERE2 || ' AND ATD.ATD_ATE_DT_ATENDIMENTO >= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_INI ||CHR(39);
    END IF;
    IF pATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL THEN
       V_WHERE2 := V_WHERE2 || ' AND ATD.ATD_ATE_DT_ATENDIMENTO <= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_FIM ||CHR(39);
    END IF;
     IF pQTD_ITENS IS NOT NULL THEN
       V_WHERE2 := V_WHERE2 || ' AND CCI_TEMP.QUANTIDADE >= ' ||CHR(39)|| pQTD_ITENS ||CHR(39);
    END IF;
    V_SELECT:=
 ' SELECT       *
   FROM  (
        SELECT        CCI.FAT_CCP_ID,
                      ATD.ATD_ATE_ID,
                      ATD.ATD_ATE_DT_ATENDIMENTO,
                      CCI.CAD_PRD_ID,
                      CCI.FAT_CCI_VL_UNITARIO,
                      CCI.CAD_PAC_ID_PACIENTE,
                      SUM(CCI.FAT_CCI_QT_CONSUMO) QUANTIDADE,
                      SUM(FAT_CCI_VL_CALCULADO) VALOR_TOTAL,
                      UNI.CAD_UNI_CD_UNID_HOSPITALAR
        FROM          TB_FAT_CCI_CONTA_CONSU_ITEM  CCI
        JOIN          TB_ATD_ATE_ATENDIMENTO       ATD
        ON            CCI.ATD_ATE_ID             = ATD.ATD_ATE_ID
        JOIN          Tb_Cad_Uni_Unidade           UNI
        ON            UNI.CAD_UNI_ID_UNIDADE     = ATD.CAD_UNI_ID_UNIDADE
        LEFT JOIN     TB_FAT_CCP_CONTA_CONS_PARC    CCP
        ON            CCP.FAT_CCP_ID              = CCI.FAT_CCP_ID
        AND           CCP.CAD_PAC_ID_PACIENTE     = CCI.CAD_PAC_ID_PACIENTE
        AND           CCP.FAT_COC_ID              = CCI.FAT_COC_ID
        AND           CCP.ATD_ATE_ID              = CCI.ATD_ATE_ID
        AND           CCP.FAT_CCP_FL_STATUS       = '||chr(39)||'A'||chr(39)||'
        WHERE         ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = '||chr(39)||'N'||chr(39)||'))
        AND           (CCI.FAT_CCI_FL_STATUS = '||chr(39)||'A'||chr(39)||')
        AND           (ATD.ATD_ATE_FL_STATUS = '||chr(39)||'A'||chr(39)||')
        AND           (UNI.CAD_UNI_FL_FATURA_UNID_OK = '||chr(39)||'S'||chr(39)||')
' || V_WHERE || '
        AND     (('||chr(39)||pFATURADO ||chr(39)||' IS NOT NULL AND CCP.FAT_NOF_ID IS NOT NULL )
            OR  ('||chr(39)||pAUDITORIA ||chr(39)||' IS NOT NULL AND CCP.FAT_CCP_FL_STATUS_AUDIT = '||chr(39)||'E'||chr(39)||')
            OR  ('||chr(39)||pLOTEGERADO ||chr(39)||' IS NOT NULL AND CCP.FAT_CCP_FL_FATURADA = '||chr(39)||'S'||chr(39)||' AND CCP.FAT_NOF_ID IS NULL)
            OR  ('||chr(39)||pEMITIDO ||chr(39)||' IS NOT NULL AND CCP.FAT_CCP_FL_EMITIDA = '||chr(39)||'S'||chr(39)||' AND CCP.FAT_CCP_FL_FATURADA = '||chr(39)||'N'||chr(39)||'
                AND (CCP.FAT_CCP_FL_STATUS_AUDIT = '||chr(39)||'A'||chr(39)||' OR CCP.FAT_CCP_DT_ENVIO_AUDIT IS NULL))
            OR  ('||chr(39)||pDIGITADO ||chr(39)||' IS NOT NULL AND CCI.FAT_CCP_ID IS NULL))
        AND     ('||chr(39)|| pCAD_TAP_TP_ATRIBUTO_MAT ||chr(39)||' IS not NULL and CCI.CAD_TAP_TP_ATRIBUTO = '||chr(39)||'MAT'||chr(39)||'
         OR     '||chr(39)|| pCAD_TAP_TP_ATRIBUTO_MED ||chr(39)||' IS NOT NULL AND CCI.CAD_TAP_TP_ATRIBUTO = '||chr(39)||'MED'||chr(39)||'
         OR     '||chr(39)|| pCAD_TAP_TP_ATRIBUTO_TAX ||chr(39)||' IS NOT NULL AND CCI.CAD_TAP_TP_ATRIBUTO = '||chr(39)||'TAX'||chr(39)||'
         OR     '||chr(39)|| pCAD_TAP_TP_ATRIBUTO_HM ||chr(39)||'  IS NOT NULL AND CCI.CAD_TAP_TP_ATRIBUTO = '||chr(39)||'HM'||chr(39)||'
         OR     '||chr(39)|| pCAD_TAP_TP_ATRIBUTO_DIA ||chr(39)||' IS NOT NULL AND CCI.CAD_TAP_TP_ATRIBUTO = '||chr(39)||'DIA'||chr(39)||'
         OR     '||chr(39)|| pCAD_TAP_TP_ATRIBUTO_GAS ||chr(39)||' IS NOT NULL AND CCI.CAD_TAP_TP_ATRIBUTO = '||chr(39)||'GAS'||chr(39)||'
         OR     '||chr(39)|| pCAD_TAP_TP_ATRIBUTO_PAC ||chr(39)||' IS NOT NULL AND CCI.CAD_TAP_TP_ATRIBUTO = '||chr(39)||'PAC'||chr(39)||'
         OR     '||chr(39)|| pCAD_TAP_TP_ATRIBUTO_EXA ||chr(39)||' IS NOT NULL AND CCI.CAD_TAP_TP_ATRIBUTO = '||chr(39)||'EXA'||chr(39)||')
        AND     ('||chr(39)|| pCAD_PRD_FL_FRACIONADO_I ||chr(39)||' IS not NULL and CCI.FAT_CCI_FL_FRACIONADO = '||chr(39)||'N'||chr(39)||'
         OR      '||chr(39)|| pCAD_PRD_FL_FRACIONADO_F ||chr(39)||' IS NOT NULL AND CCI.FAT_CCI_FL_FRACIONADO = '||chr(39)||'S'||chr(39)||')
        AND ('||chr(39)|| pATD_ATE_TP_PACIENTE_I ||chr(39)||' IS not NULL and atD.atd_ate_tp_paciente = '||chr(39)||'I'||chr(39)||'
         OR '||chr(39)|| pATD_ATE_TP_PACIENTE_E ||chr(39)||' IS NOT NULL AND atD.atd_ate_tp_paciente = '||chr(39)||'E'||chr(39)||'
         OR '||chr(39)|| pATD_ATE_TP_PACIENTE_A ||chr(39)||' IS NOT NULL AND atD.atd_ate_tp_paciente = '||chr(39)||'A'||chr(39)||'
         OR '||chr(39)|| pATD_ATE_TP_PACIENTE_U ||chr(39)||' IS NOT NULL AND atD.atd_ate_tp_paciente = '||chr(39)||'U'||chr(39)||')
        GROUP BY      CCI.FAT_CCP_ID,
                      ATD.ATD_ATE_ID,
                      ATD.ATD_ATE_DT_ATENDIMENTO,
                      CCI.CAD_PRD_ID,
                      CCI.FAT_CCI_VL_UNITARIO,
                      CCI.CAD_PAC_ID_PACIENTE,
                      UNI.CAD_UNI_CD_UNID_HOSPITALAR
      ) CCI_TEMP
  JOIN    TB_CAD_PRD_PRODUTO        PRD
  ON      CCI_TEMP.CAD_PRD_ID     = PRD.CAD_PRD_ID
  JOIN    TB_ATD_ATE_ATENDIMENTO    ATD
  ON      ATD.ATD_ATE_ID          = CCI_TEMP.ATD_ATE_ID
  JOIN    TB_CAD_PAC_PACIENTE       PAC
  ON      PAC.CAD_PAC_ID_PACIENTE = CCI_TEMP.CAD_PAC_ID_PACIENTE
  JOIN    TB_CAD_PLA_PLANO          PLA
  ON      PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  JOIN    TB_CAD_UNI_UNIDADE UNI
  ON      UNI.CAD_UNI_ID_UNIDADE           = ATD.CAD_UNI_ID_UNIDADE
  WHERE   (UNI.CAD_UNI_FL_FATURA_UNID_OK = '||chr(39)||'S'||chr(39)||')
  ' || V_WHERE2 || '
  AND    ('||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB ||chr(39)||' IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'GB'||chr(39)||'
       OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PL ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'PL'||chr(39)||'
       OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PA ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'PA'||chr(39)||'
       OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_SP ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'SP'||chr(39)||'
       OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_FU ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'FU'||chr(39)||'
       OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_NP ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'NP'||chr(39)||')
  AND ('||chr(39)|| pATD_ATE_TP_PACIENTE_I ||chr(39)||' IS not NULL and atD.atd_ate_tp_paciente = '||chr(39)||'I'||chr(39)||'
   OR '||chr(39)|| pATD_ATE_TP_PACIENTE_E ||chr(39)||' IS NOT NULL AND atD.atd_ate_tp_paciente = '||chr(39)||'E'||chr(39)||'
   OR '||chr(39)|| pATD_ATE_TP_PACIENTE_A ||chr(39)||' IS NOT NULL AND atD.atd_ate_tp_paciente = '||chr(39)||'A'||chr(39)||'
   OR '||chr(39)|| pATD_ATE_TP_PACIENTE_U ||chr(39)||' IS NOT NULL AND atD.atd_ate_tp_paciente = '||chr(39)||'U'||chr(39)||')'
  ;
  -- TESTE :=  V_SELECT ;
  OPEN v_cursor FOR
   V_SELECT ;
    io_cursor := v_cursor;
END PRC_FAT_REL_QTD_MAX_ITENS;
 