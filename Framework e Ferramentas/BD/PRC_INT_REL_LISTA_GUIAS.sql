CREATE OR REPLACE PROCEDURE PRC_INT_REL_LISTA_GUIAS
(
  PCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
  --PCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
  --PCAD_SET_ID IN TB_ATD_ATE_ATENDIMENTO.CAD_SET_ID%type DEFAULT NULL,
  PATD_ATE_TP_PACIENTE IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%type DEFAULT NULL,
  PATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type DEFAULT NULL,
  PATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type DEFAULT NULL,
  PCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
  io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_INT_REL_LISTA_GUIAS
*
*    Data Criacao:   21/10/2010           Por: Eduardo Hyppolito
*    Data Alteração: 05/10/2010           Por: Eduardo Hyppolito
*    Data Alteração: 28/01/2014           Por: André Monaco
*         Alteração: Adição de todos os filtros 
*                    (só havia antes o parametro PCAD_UNI_ID_UNIDADE)
*    Data Alteração: 15/04/2015           Por: Andréa Cazuca
*         Alteração: Apresentar também as internação que não tem guia
*
*    Funcao: Lista de guias entregues ao faturamento
*********************************************************************/
V_WHERE  varchar2(5000) := NULL;
V_SELECT  varchar2(5000);
v_cursor PKG_CURSOR.t_cursor;
begin

IF PCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_UNI_ID_UNIDADE = ' || PCAD_UNI_ID_UNIDADE; END IF;
--IF PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || PCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
--IF PCAD_SET_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_SET_ID = ' || PCAD_SET_ID; END IF;
IF PATD_ATE_TP_PACIENTE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.ATD_ATE_TP_PACIENTE = ' || CHR(39) || PATD_ATE_TP_PACIENTE || CHR(39); END IF;
IF (PATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL AND PATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL) THEN
    V_WHERE := V_WHERE || ' AND TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO) BETWEEN '
                       ||       CHR(39) || PATD_ATE_DT_ATENDIMENTO_INI || CHR(39) || ' AND '
                       ||       CHR(39) || PATD_ATE_DT_ATENDIMENTO_FIM || CHR(39);
END IF;
IF PCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CNV.CAD_CNV_ID_CONVENIO = ' || PCAD_CNV_ID_CONVENIO; END IF;

V_SELECT := 'SELECT CNV.CAD_CNV_CD_HAC_PRESTADOR,
                    PES.CAD_PES_NM_PESSOA,
                    GUI.ATD_GUI_CD_CODIGO,
                    ATE.ATD_ATE_ID,
                    GUI.ATD_GUI_DT_VALIDADE_FIM,
                    GUI.ATD_GUI_DT_EMISSAOGUIA,
                    GUI.ATD_GUI_FL_GUIAPRINC_OK,
                    GUI.ATD_GUI_DT_AUTORIZGUIA,
                    DECODE(GUI.ATD_GUI_CD_CODIGO,NULL,''SEM GUIA'',GUI.ATD_GUI_CD_SENHA) ATD_GUI_CD_SENHA,
                    GUI.ATD_GUI_DIAS_VALIDADE              
              FROM    TB_ATD_ATE_ATENDIMENTO ATE
              JOIN    TB_ASS_PAT_PACIEATEND PAT
              ON      PAT.ATD_ATE_ID = ATE.ATD_ATE_ID
              JOIN    TB_CAD_PAC_PACIENTE PAC
              ON      PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
              JOIN    TB_CAD_PES_PESSOA PES
              ON      PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
              LEFT JOIN    TB_ATD_GUI_GUIAATEND GUI
              ON      GUI.ATD_ATE_ID = ATE.ATD_ATE_ID
              JOIN    TB_CAD_CNV_CONVENIO CNV
              ON      CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO              
              WHERE   (ATE.ATD_ATE_FL_STATUS = ''A'')
              AND     (ATE.ATD_ATE_TP_PACIENTE IN (''I'',''E''))
              AND (GUI.ATD_ATE_ID IS NULL OR (GUI.ATD_ATE_ID IS NOT NULL  
                                    AND (GUI.ATD_GUI_FL_ATIVO_OK = ''S'')
                                    AND (GUI.ATD_GUI_FL_GUIA_ENTREGUE != ''S'')))';

OPEN v_cursor FOR
V_SELECT || V_WHERE ;
io_cursor := v_cursor;
end PRC_INT_REL_LISTA_GUIAS;
 
