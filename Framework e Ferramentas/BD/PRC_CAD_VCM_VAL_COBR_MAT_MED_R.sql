CREATE OR REPLACE PROCEDURE PRC_CAD_VCM_VAL_COBR_MAT_MED_R
(
     pCAD_VCM_ID IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_PRD_ID IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_PRD_ID%type DEFAULT NULL,
     pCAD_VCM_FL_UTILIZA_VL_NF IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_FL_UTILIZA_VL_NF%type DEFAULT NULL,
     pCAD_VCM_FL_UTILIZA_VL_CUSTO IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_FL_UTILIZA_VL_CUSTO%type DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_CAD_VCM_VAL_COBR_MAT_MED.TIS_MED_CD_TABELAMEDICA%type DEFAULT NULL,
     pCAD_VCM_FL_ISENTO_COBRANCA IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_FL_ISENTO_COBRANCA%type DEFAULT NULL,
     pCAD_VCM_DT_INICIO_VIGENCIA IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_DT_INICIO_VIGENCIA%type DEFAULT NULL,
     pCAD_VCM_DT_FIM_VIGENCIA IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_DT_FIM_VIGENCIA%type DEFAULT NULL,
     pCAD_VCM_FL_INT_FRAC IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_FL_INT_FRAC%type DEFAULT NULL,
     pCAD_TAP_TP_ATRIBUTO IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_TAP_TP_ATRIBUTO%type DEFAULT NULL,
     pCAD_CMM_CD_CARACMATMED IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_CMM_CD_CARACMATMED%type DEFAULT NULL,
     pCAD_VCM_FL_STATUS IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_FL_STATUS%type DEFAULT NULL,
     pVIGENCIA IN VARCHAR2 DEFAULT NULL, -- 0 = TODOS; 1 = VIGENTES; -1 = NAO VIGENTES
     pMARGEM_SEM_PROD IN NUMBER DEFAULT NULL, -- 0 = TODOS; 1 = TRAZER APENAS REGISTROS SEM ID DO PRODUTO
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_VCM_VAL_COBR_MAT_MED_R
*
*    Data Criacao: 	 10/08/2010   Por: Andr� Souza Monaco
*    Data Alteracao: 30/01/2014   Por: Andr�
*         Alteracao: Passei a query para o padr�o de string e 
*                    adi��o dos par�metros pVIGENCIA e pMARGEM_SEM_PROD
*
*    Funcao: Lista valores de mat/med junto com outras tabelas
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
V_WHERE  varchar2(5000);
V_SELECT  varchar2(5000);
begin
IF pCAD_VCM_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_VCM_ID = ' || pCAD_VCM_ID; END IF;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO; END IF;
IF pCAD_PRD_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_PRD_ID = ' || pCAD_PRD_ID; END IF;
IF pCAD_VCM_FL_UTILIZA_VL_NF IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_VCM_FL_UTILIZA_VL_NF = ' || CHR(39) || pCAD_VCM_FL_UTILIZA_VL_NF || CHR(39); END IF;
IF pCAD_VCM_FL_UTILIZA_VL_CUSTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_VCM_FL_UTILIZA_VL_CUSTO = ' || CHR(39) || pCAD_VCM_FL_UTILIZA_VL_CUSTO || CHR(39); END IF;
IF pTIS_MED_CD_TABELAMEDICA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.TIS_MED_CD_TABELAMEDICA = ' || CHR(39) || pTIS_MED_CD_TABELAMEDICA || CHR(39); END IF;
IF pCAD_VCM_FL_ISENTO_COBRANCA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_VCM_FL_ISENTO_COBRANCA = ' || CHR(39) || pCAD_VCM_FL_ISENTO_COBRANCA || CHR(39); END IF;
IF pCAD_VCM_DT_INICIO_VIGENCIA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_VCM_DT_INICIO_VIGENCIA = ' || CHR(39) || pCAD_VCM_DT_INICIO_VIGENCIA || CHR(39); END IF;
IF pCAD_VCM_DT_FIM_VIGENCIA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_VCM_DT_FIM_VIGENCIA = ' || CHR(39) || pCAD_VCM_DT_FIM_VIGENCIA || CHR(39); END IF;
IF pCAD_VCM_FL_INT_FRAC IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_VCM_FL_INT_FRAC = ' || CHR(39) || pCAD_VCM_FL_INT_FRAC || CHR(39); END IF;
IF pCAD_TAP_TP_ATRIBUTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_TAP_TP_ATRIBUTO = ' || CHR(39) || pCAD_TAP_TP_ATRIBUTO || CHR(39); END IF;
IF pCAD_CMM_CD_CARACMATMED IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_CMM_CD_CARACMATMED = ' || pCAD_CMM_CD_CARACMATMED; END IF;
IF pCAD_VCM_FL_STATUS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_VCM_FL_STATUS = ' || CHR(39) || pCAD_VCM_FL_STATUS || CHR(39); END IF;
IF (NVL(pVIGENCIA, '0') = '1') THEN
   V_WHERE := V_WHERE || ' AND (VCM.CAD_VCM_FL_STATUS = ''A'' AND (FNC_VALIDAR_VIGENCIA(VCM.CAD_VCM_DT_INICIO_VIGENCIA, VCM.CAD_VCM_DT_FIM_VIGENCIA) = 1 OR VCM.CAD_VCM_DT_INICIO_VIGENCIA > TRUNC(SYSDATE))) ';
ELSIF (NVL(pVIGENCIA, '0') = '-1') THEN
   V_WHERE := V_WHERE || ' AND (VCM.CAD_VCM_FL_STATUS = ''I'' OR (FNC_VALIDAR_VIGENCIA(VCM.CAD_VCM_DT_INICIO_VIGENCIA, VCM.CAD_VCM_DT_FIM_VIGENCIA) = 0 AND VCM.CAD_VCM_DT_INICIO_VIGENCIA < TRUNC(SYSDATE))) ';
END IF;
IF (NVL(pMARGEM_SEM_PROD, '0') = '1') THEN V_WHERE:= V_WHERE || ' AND VCM.CAD_PRD_ID IS NULL '; END IF;
V_SELECT := 'SELECT VCM.CAD_VCM_ID,
                     VCM.CAD_CNV_ID_CONVENIO,
                     VCM.CAD_PRD_ID,
                     VCM.CAD_VCM_FL_UTILIZA_VL_NF,
                     VCM.TIS_MED_CD_TABELAMEDICA,
                     VCM.CAD_VCM_VL_FIXO,
                     VCM.CAD_VCM_VL_CUSTO,
                     VCM.CAD_VCM_PC_MARGEM,
                     VCM.CAD_VCM_FL_ISENTO_COBRANCA,
                     VCM.CAD_VCM_DT_INICIO_VIGENCIA,
                     VCM.CAD_VCM_DT_FIM_VIGENCIA,
                     VCM.CAD_VCM_FL_INT_FRAC,
                     VCM.CAD_VCM_DT_ULTIMA_ATUALIZACAO,
                     VCM.SEG_USU_ID_USUARIO,
                     VCM.CAD_VCM_VL_DIVISOR,
                     VCM.CAD_TAP_TP_ATRIBUTO,
                     VCM.CAD_CMM_CD_CARACMATMED,
                     VCM.CAD_VCM_VL_FRACIONADO,
                     VCM.CAD_VCM_VL_FINAL,
                     VCM.CAD_VCM_FL_STATUS,
                     VCM.CAD_VCM_VL_PRODUTO,
                     CNV.CAD_CNV_CD_HAC_PRESTADOR,
                     TAB.TIS_MED_DS_TABELAMEDICA,
                     TAT.CAD_TAP_DS_ATRIBUTO,
                     CMM.CAD_CMM_DS_CARACMATMED,
                     PRD.CAD_PRD_CD_CODIGO,
                     PRD.CAD_PRD_DS_DESCRICAO,
                     CASE WHEN CAD_VCM_FL_INT_FRAC = ''I'' THEN ''true'' ELSE ''false'' END INTEIRO,
                     CASE WHEN CAD_VCM_FL_INT_FRAC = ''F'' THEN ''true'' ELSE ''false'' END FRACIONADO,
                     CASE WHEN CAD_VCM_FL_UTILIZA_VL_NF = ''S'' THEN ''true'' ELSE ''false'' END UTILIZA_VALOR_NF,
                     CASE WHEN CAD_VCM_FL_UTILIZA_VL_CUSTO = ''S'' THEN ''true'' ELSE ''false'' END UTILIZA_VALOR_CUSTO,
                     CASE WHEN CAD_VCM_FL_ISENTO_COBRANCA = ''S'' THEN ''true'' ELSE ''false'' END ISENTO_COBRANCA,
                     CASE WHEN CAD_VCM_FL_STATUS = ''A'' THEN ''ATIVO'' ELSE ''INATIVO'' END STATUS
              FROM TB_CAD_VCM_VAL_COBR_MAT_MED VCM,
                   TB_CAD_CNV_CONVENIO CNV,
                   TB_TIS_MED_TABELAMEDICA TAB,
                   TB_CAD_TAP_TP_ATRIB_PRODUTO TAT,
                   TB_CAD_CMM_CARACT_MATMED CMM,
                   TB_CAD_PRD_PRODUTO PRD
              WHERE CNV.CAD_CNV_ID_CONVENIO (+)= VCM.CAD_CNV_ID_CONVENIO AND
                    TAB.TIS_MED_CD_TABELAMEDICA (+)= VCM.TIS_MED_CD_TABELAMEDICA AND
                    TAT.CAD_TAP_TP_ATRIBUTO (+)= VCM.CAD_TAP_TP_ATRIBUTO AND
                    CMM.CAD_CMM_CD_CARACMATMED (+)= VCM.CAD_CMM_CD_CARACMATMED AND
                    PRD.CAD_PRD_ID (+)= VCM.CAD_PRD_ID ';
OPEN v_cursor FOR
V_SELECT || V_WHERE ;
io_cursor := v_cursor;
end PRC_CAD_VCM_VAL_COBR_MAT_MED_R;
 