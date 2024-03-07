CREATE OR REPLACE PROCEDURE "PRC_ATD_HIST_PAC_S"
(
  pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%type DEFAULT NULL,
  pCAD_PES_NM_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type DEFAULT NULL,
  pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
  pCAD_PAC_NR_PRONTUARIO IN TB_CAD_PAC_PACIENTE.CAD_PAC_NR_PRONTUARIO%type DEFAULT NULL,
  pATD_ATE_DT_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type DEFAULT NULL,
  io_cursor OUT PKG_CURSOR.t_cursor
)
IS
/********************************************************************
*    Procedure: PRC_ATD_HIST_PAC_S
*
*    Data Criacao:    31/08/2009   Por: Caio H. B. Chagas
*    Data Alteracao:  09/04/2010   Por: PEDRO
*    Data Alteracao:  29/03/2011   Por: Fabiola
*    Alteracao: distinct
*
*    Funcao: Listar os atendimentos historicos de um paciente
*
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(3000);
  V_SELECT  varchar2(30000);

begin   --SELECT * FROM TB_FAT_FCL_CONTR_EMI_LOTE FCL ORDER BY 1 DESC
  V_WHERE := NULL;
    
IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_PES_NM_PESSOA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND PES.CAD_PES_NM_PESSOA LIKE ' || CHR(39) || pCAD_PES_NM_PESSOA || CHR(39) ;    END IF;
IF pATD_ATE_ID IS NOT NULL THEN    V_WHERE := V_WHERE || ' AND ATE.ATD_ATE_ID = ' || pATD_ATE_ID;    END IF;
IF pCAD_PAC_NR_PRONTUARIO IS NOT NULL THEN    V_WHERE := V_WHERE || ' AND PAC.CAD_PAC_NR_PRONTUARIO = ' || pCAD_PAC_NR_PRONTUARIO;    END IF;
IF pATD_ATE_DT_ATENDIMENTO IS NOT NULL THEN    V_WHERE := V_WHERE || ' AND ATE.ATD_ATE_DT_ATENDIMENTO = ' || CHR(39) || pATD_ATE_DT_ATENDIMENTO || CHR(39);    END IF;

V_SELECT:=
'
  SELECT  ATE.ATD_ATE_ID,
          UNI.CAD_UNI_DS_UNIDADE,
          LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
          PAC.CAD_PAC_NR_PRONTUARIO,
          PES.CAD_PES_NM_PESSOA,
          ATE.ATD_ATE_DT_ATENDIMENTO,
          ATE.ATD_ATE_HR_ATENDIMENTO,
          ATE.ATD_ATE_TP_PACIENTE,
          INA.ATD_INA_DT_ALTA_ADM,
          INA.ATD_INA_HR_ALTA_ADM,
          ATE.ATD_ATE_TP_PACIENTE,
          ATE.ATD_ATE_FL_STATUS,
          DECODE(MSI.TIS_MSI_CD_TIPOALTA, 1, ''ALTA'', 4, ''OBITO'') TIPOALTA
  FROM    TB_ATD_ATE_ATENDIMENTO             ATE
  JOIN    TB_CAD_UNI_UNIDADE                 UNI
  ON      ATE.CAD_UNI_ID_UNIDADE           = UNI.CAD_UNI_ID_UNIDADE
  JOIN    TB_CAD_LAT_LOCAL_ATENDIMENTO       LAT
  ON      ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
  JOIN    TB_ASS_PAT_PACIEATEND              PAT
  ON      ATE.ATD_ATE_ID                   = PAT.ATD_ATE_ID
  JOIN    TB_CAD_PAC_PACIENTE                PAC
  ON      PAT.CAD_PAC_ID_PACIENTE          = PAC.CAD_PAC_ID_PACIENTE
  JOIN    TB_CAD_PES_PESSOA                  PES
  ON      PAC.CAD_PES_ID_PESSOA            = PES.CAD_PES_ID_PESSOA
  LEFT    JOIN TB_ATD_INA_INT_ALTA           INA
  ON      INA.ATD_ATE_ID                   = ATE.ATD_ATE_ID
  LEFT    JOIN TB_TIS_MSI_MOTIVO_SAIDA_INT   MSI
  ON      MSI.TIS_MSI_CD_MOTIVOSAIDAINT    = INA.TIS_MSI_CD_MOTIVOSAIDAINT
  WHERE   ATE.ATD_ATE_TP_PACIENTE          IN (''I'', ''E'')
' || V_WHERE || '
  ORDER   BY  ATE.ATD_ATE_DT_ATENDIMENTO DESC,
              ATE.ATD_ATE_HR_ATENDIMENTO DESC '    ;
OPEN v_cursor FOR
  V_SELECT ;
  io_cursor := v_cursor;
END PRC_ATD_HIST_PAC_S;
 