CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_INT_M2_FILME"
(
    pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO     IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_PLA_ID_PLANO        IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
    pTIS_TAT_CD_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%TYPE DEFAULT NULL,
    pTIS_TIN_CD_INTER IN TB_ATD_AIC_ATE_INT_COMPL.TIS_TIN_CD_INTERNACAO%TYPE DEFAULT NULL,
      pCAD_PLA_CD_TIPOPLANO_GB IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PL IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_FU IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PA IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_SP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
)
IS
/********************************************************************
*    Procedure: PRC_FAT_REL_INT_M2_FILME
*
*    Data Alteracao: 04/09/2013  Por: PEDRO
*    Altera��o: CUSTO
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(3000);
  V_SELECT  varchar2(30000);
begin
  V_WHERE := NULL;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CCI.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
IF pCAD_SET_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_SET_ID = ' || pCAD_SET_ID; END IF;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CCI.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;    END IF;
IF pCAD_PLA_ID_PLANO IS NOT NULL THEN    V_WHERE := V_WHERE || ' AND PAC.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO;    END IF;

IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATE.ATD_ATE_DT_ATENDIMENTO >= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_INI ||CHR(39);    END IF;
IF pATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATE.ATD_ATE_DT_ATENDIMENTO <= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_FIM ||CHR(39);    END IF;
IF pTIS_TIN_CD_INTER IS NOT NULL THEN V_WHERE := V_WHERE || ' AND AIC.TIS_TIN_CD_INTERNACAO = ' || chr(39) || pTIS_TIN_CD_INTER || chr(39) ;    END IF;
IF pTIS_TAT_CD_TPATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATE.TIS_TAT_CD_TPATENDIMENTO = ' || chr(39) || pTIS_TAT_CD_TPATENDIMENTO || chr(39) ;    END IF;

V_SELECT:=
    '   SELECT  CNV.CAD_CNV_CD_HAC_PRESTADOR,
            CNV.CAD_CNV_DS_RAZAOSOCIAL,
            UNI.CAD_UNI_DS_UNIDADE,
            CCI.ATD_ATE_ID,
            PES.CAD_PES_NM_PESSOA,
            PRD.CAD_PRD_CD_CODIGO,
            PRD.CAD_PRD_DS_DESCRICAO,
            CCI.FAT_CCI_DT_INICIO_CONSUMO,
            CCI.FAT_CCI_QT_CONSUMO,
            CCI.FAT_CCI_VL_FATURADO,
            CCI.FAT_CCI_VL_M2FILME,
            CCI.ATS_APL_ID
    FROM    TB_FAT_CCI_CONTA_CONSU_ITEM CCI
    join    TB_ATD_ATE_ATENDIMENTO      ATE    ON      ATE.ATD_ATE_ID              = CCI.ATD_ATE_ID
    JOIN    TB_CAD_PAC_PACIENTE         PAC    ON      PAC.CAD_PAC_ID_PACIENTE     = CCI.CAD_PAC_ID_PACIENTE
    JOIN    TB_CAD_CNV_CONVENIO         CNV    ON      CNV.CAD_CNV_ID_CONVENIO     = CCI.CAD_CNV_ID_CONVENIO
    JOIN    TB_CAD_PES_PESSOA           PES    ON      PAC.CAD_PES_ID_PESSOA       = PES.CAD_PES_ID_PESSOA
    JOIN    TB_CAD_UNI_UNIDADE          UNI    ON      UNI.CAD_UNI_ID_UNIDADE      = CCI.CAD_UNI_ID_UNIDADE
    JOIN    TB_ATD_AIC_ATE_INT_COMPL    AIC    ON      AIC.ATD_ATE_ID              = CCI.ATD_ATE_ID   
    JOIN    TB_CAD_PRD_PRODUTO          PRD    ON      PRD.CAD_PRD_ID              = CCI.CAD_PRD_ID
    WHERE   (CCI.CAD_TAP_TP_ATRIBUTO = '||chr(39)||'EXA'||chr(39)||') 
  --  AND     (CCI.ATS_APL_ID IS NOT NULL)
    AND     (CCI.FAT_CCI_VL_M2FILME > 0)
    AND     (CCI.FAT_CCI_FL_STATUS = '||chr(39)||'A'||chr(39)||')
   ' || V_WHERE || '
      AND    ('||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB ||chr(39)||' IS not NULL and CNV.CAD_TPE_CD_CODIGO = '||chr(39)||'ACS'||chr(39)||'
             OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PA ||chr(39)||' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = '||chr(39)||'PA'||chr(39)||'
             OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_SP ||chr(39)||' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = '||chr(39)||'SP'||chr(39)||'
             OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_FU ||chr(39)||' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = '||chr(39)||'FU'||chr(39)||')
   
    ORDER   BY CNV.CAD_CNV_CD_HAC_PRESTADOR,
            CNV.CAD_CNV_DS_RAZAOSOCIAL,
            UNI.CAD_UNI_DS_UNIDADE,
            CCI.ATD_ATE_ID,
            PES.CAD_PES_NM_PESSOA,
            PRD.CAD_PRD_CD_CODIGO,
            PRD.CAD_PRD_DS_DESCRICAO,
            CCI.FAT_CCI_DT_INICIO_CONSUMO' ;
 --   TESTE :=  V_SELECT ;
  OPEN v_cursor FOR
   V_SELECT ;
    io_cursor := v_cursor;
END PRC_FAT_REL_INT_M2_FILME;
 