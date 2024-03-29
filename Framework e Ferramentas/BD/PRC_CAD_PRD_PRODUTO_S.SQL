create or replace procedure PRC_CAD_PRD_PRODUTO_S
(pCAD_PRD_ID                 IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%type DEFAULT NULL,
pAUX_EPP_CD_ESPECPROC       IN TB_CAD_PRD_PRODUTO.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,
pAUX_GPC_CD_GRUPOPROC       IN TB_CAD_PRD_PRODUTO.AUX_GPC_CD_GRUPOPROC%TYPE DEFAULT NULL,
pCAD_PRD_CD_CODIGO          IN TB_CAD_PRD_PRODUTO.CAD_PRD_CD_CODIGO%TYPE DEFAULT NULL,
pCAD_PRD_FL_UTILIZAAGEND_OK IN TB_CAD_PRD_PRODUTO.CAD_PRD_FL_UTILIZAAGEND_OK%TYPE DEFAULT NULL,
pCAD_PRD_DS_DESCRICAO       IN TB_CAD_PRD_PRODUTO.CAD_PRD_DS_DESCRICAO%TYPE DEFAULT NULL,
pTIS_MED_CD_TABELAMEDICA    IN TB_CAD_PRD_PRODUTO.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL,
pCAD_PRD_NM_MNEMONICO       IN TB_CAD_PRD_PRODUTO.CAD_PRD_NM_MNEMONICO%TYPE DEFAULT NULL,
pCAD_PRD_FL_STATUS          IN TB_CAD_PRD_PRODUTO.CAD_PRD_FL_STATUS%TYPE DEFAULT NULL,
pCAD_CMM_CD_CARACMATMED     IN TB_CAD_PRD_PRODUTO.CAD_CMM_CD_CARACMATMED%TYPE DEFAULT NULL,
pCAD_CME_CLASSIF_MED        IN TB_CAD_PRD_PRODUTO.CAD_CME_CLASSIF_MED%TYPE DEFAULT NULL,
pCAD_APM_ID_MATMED          IN TB_CAD_PRD_PRODUTO.CAD_APM_ID_MATMED%TYPE DEFAULT NULL,
io_cursor                   OUT PKG_CURSOR.t_cursor
--,teste out long
) is
  /********************************************************************
  *    Procedure: PRC_CAD_PRD_PRODUTO_S
  *
  *    Data Alteracao: 1/6/2011            Por: Pedro
  *    Alteracao: campos no select + join TB_CAD_APM_APRES_PRO_MATMED APM e TB_CAD_CME_CLASSIF_MED CME
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(4000);
  V_SELECT varchar2(10000);
begin
  --V_WHERE := null;
  IF pCAD_PRD_ID IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND PRD.CAD_PRD_ID = ' || pCAD_PRD_ID;  END IF;

  IF pAUX_EPP_CD_ESPECPROC IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND PRD.AUX_EPP_CD_ESPECPROC = '|| CHR(39) || pAUX_EPP_CD_ESPECPROC || CHR(39);  END IF;

  IF pAUX_GPC_CD_GRUPOPROC IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND PRD.AUX_GPC_CD_GRUPOPROC = '|| CHR(39) || pAUX_GPC_CD_GRUPOPROC || CHR(39);  END IF;

  IF pCAD_PRD_CD_CODIGO IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_PRD_CD_CODIGO = '|| CHR(39) || pCAD_PRD_CD_CODIGO || CHR(39);  END IF;

  IF pCAD_PRD_FL_UTILIZAAGEND_OK IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_PRD_FL_UTILIZAAGEND_OK = '|| CHR(39) || pCAD_PRD_FL_UTILIZAAGEND_OK || CHR(39);     END IF;

  IF pCAD_PRD_DS_DESCRICAO IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND UPPER(CAD_PRD_DS_DESCRICAO) like '|| CHR(39) || UPPER(pCAD_PRD_DS_DESCRICAO) || CHR(39);      END IF;

  IF pTIS_MED_CD_TABELAMEDICA IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND PRD.TIS_MED_CD_TABELAMEDICA = '|| CHR(39) || pTIS_MED_CD_TABELAMEDICA || CHR(39);    END IF;

  IF pCAD_PRD_NM_MNEMONICO IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND UPPER(CAD_PRD_NM_MNEMONICO) = '|| CHR(39) || UPPER(pCAD_PRD_NM_MNEMONICO) || CHR(39);   END IF;

  IF pCAD_PRD_FL_STATUS IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_PRD_FL_STATUS = '|| CHR(39) || pCAD_PRD_FL_STATUS || CHR(39);      END IF;

   IF pCAD_CMM_CD_CARACMATMED IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_CMM_CD_CARACMATMED = ' || pCAD_CMM_CD_CARACMATMED;      END IF;

   IF pCAD_CME_CLASSIF_MED IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_CME_CLASSIF_MED = ' || pCAD_CME_CLASSIF_MED;      END IF;

   IF pCAD_APM_ID_MATMED IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_APM_ID_MATMED = ' ||  pCAD_APM_ID_MATMED;      END IF;

  V_SELECT := 'SELECT PRD.CAD_PRD_ID,
           CAD_PRD_CD_CODIGO,
           CAD_PRD_CD_GPREXA,
           CAD_PRD_DS_DESCRICAO,
           PRD.SEG_USU_ID_USUARIO,
           CAD_PRD_DT_ULTIMA_ATUALIZACAO,
           CAD_PRD_FL_STATUS,
           CAD_PRD_NM_MNEMONICO,
           PRD.AUX_EPP_CD_ESPECPROC,
           PRD.AUX_GPC_CD_GRUPOPROC,
           CAD_PRD_DS_RESUMIDA,
           CAD_PRD_TP_PRODUTO,
           PRD.TIS_MED_CD_TABELAMEDICA,
           CAD_PRD_FL_UTILIZAAGEND_OK,
           CAD_PRD_ID_PRODUTOTABELA,
           CAD_PRD_FL_CONTRASTADO,
           PRD.CAD_TAP_TP_ATRIBUTO,
           CAD_TIH_TP_INDICE_HOSP,
           CAD_PRD_QT_INDICE_HOSP,
           CAD_PRD_QT_AUXILIAR,
           CAD_PRD_PC_DOPPLER,
           CAD_PRD_TP_PORTE,
           CAD_DT_INICIO_VIGENCIA,
           CAD_PRD_QT_INCIDENCIA,
           CAD_PRD_QT_M2_FILME,
           CAD_PRD_QT_CUSTO_OPER,
           CAD_PRD_QT_HONORARIO,
           CAD_PRD_TP_SEXO_PERMITIDO,
           CAD_PRD_FL_COBRA_HEXTRA,
           TIS_TAC_CD_TIPO_ACOMODACAO,
           CAD_PRD_FL_PERMITE_RETORNO,
           CAD_PRD_CD_NAT_DESPESA_TISS,
           CAD_PRD_VL_PRODUTO,
           CAD_PRD_PC_HAC,
           CAD_UMC_CD_MEDIDA_CONSUMO,
           CAD_PRD_NM_FANTASIA,
           CAD_PRD_FL_FRACIONADO,
           CAD_PRD_PC_ACRESCIMO,
           CAD_PRD_VL_VENDA,
           CAD_PRD_VL_CUSTOMEDIO,
           CAD_PRD_VL_CUSTO,
           CAD_PRD_QT_MINIMA,
           CAD_PRD_QT_MAXIMA,
           prd.CAD_APM_ID_MATMED,
           CAD_PRD_QT_APR_MATMED,
           CAD_PRD_FL_ISENTO_COBRANCA,
           CAD_PRD_FL_ESTOQUE_ACS,
           CAD_PRD_PC_DESCONTO,
           CAD_PRD_FL_KIT,
           CAD_PRD_CD_BARRA,
           CAD_PRD_FL_ALTO_CUSTO,
           CAD_PRD_VL_UNITARIO,
           prd.CAD_CME_CLASSIF_MED,
           CAD_PRD_FL_USORESTRITOMED,
           CAD_PRD_VL_MATMED_FABRICA,
           CAD_PRD_FL_MATESPECIAL,
           CAD_CMM_CD_CARACMATMED,
           CAD_PRD_VL_MATMED_VEND_FRA,
           CAD_PRD_VL_MATMED_FABR_FRA,
           CAD_PRD_ID_PRODUTO_MATMED,
           CAD_PRD_CD_FABR_MATMED,
           CAD_PRD_NM_FABR_MATMED,
           CAD_PRD_TP_EMBALAG_MATMED,
           CAD_PRD_CD_TABELA_MATMED,
           CAD_PRD_CD_TAB_APRE_MATMED,
           CAD_PRD_NM_TAB_APRE_MATMED,
           CAD_PRD_FL_MAT_CONSIGNADO,
           CAD_PRD_CD_CODIGO_AMB92,
           CAD_PRD_FL_NOTAFISCALMATMED,
           CAD_PRD_FL_COBRAPCHMACO,
           CAD_PRD_TP_PORTE_CBHPM,
           CAD_PRD_TP_PORTE_SALA,
           CAD_PRD_FL_CIRURGIA,
           CAD_PRD_FL_LANCA_DIARIA,
           CAD_PRD_PC_PORTE_CBHPM,
         --  CAD_PRD_CD_SIMPRO,
          -- CAD_PRD_CD_BRASINDICE,

           MED.TIS_MED_DS_TABELAMEDICA,
           EPP.AUX_EPP_DS_DESCRICAO,
           GPC.AUX_GPC_DS_DESCRICAO,
           TAP.CAD_TAP_DS_ATRIBUTO,
           APM.CAD_APM_DS_PRODUTO,
           CME.CAD_CME_DS_CLASSIF_MED,
           prd.TIS_GPP_CD_GRAU_PART_PROF,
           prd.cad_prd_fl_cobrapcvideo
      FROM TB_CAD_PRD_PRODUTO PRD,
           TB_CAD_TAP_TP_ATRIB_PRODUTO TAP,
           TB_TIS_MED_TABELAMEDICA MED,
           TB_AUX_EPP_ESPECPROC EPP,
           TB_AUX_GPC_GRUPOPROC GPC,
           TB_CAD_APM_APRES_PRO_MATMED APM,
           TB_CAD_CME_CLASSIF_MED CME
     WHERE MED.TIS_MED_CD_TABELAMEDICA (+)= PRD.TIS_MED_CD_TABELAMEDICA
               AND (PRD.AUX_EPP_CD_ESPECPROC = EPP.AUX_EPP_CD_ESPECPROC(+) AND PRD.TIS_MED_CD_TABELAMEDICA = EPP.TIS_MED_CD_TABELAMEDICA(+))
               AND (PRD.AUX_GPC_CD_GRUPOPROC = GPC.AUX_GPC_CD_GRUPOPROC(+) AND PRD.TIS_MED_CD_TABELAMEDICA = GPC.TIS_MED_CD_TABELAMEDICA(+)
                    AND PRD.AUX_EPP_CD_ESPECPROC = GPC.AUX_EPP_CD_ESPECPROC(+))
               AND TAP.CAD_TAP_TP_ATRIBUTO (+)= PRD.CAD_TAP_TP_ATRIBUTO
               AND PRD.CAD_APM_ID_MATMED = APM.CAD_APM_ID_MATMED (+)
               AND PRD.CAD_CME_CLASSIF_MED = CME.CAD_CME_CLASSIF_MED (+)
               ' || V_WHERE;

     --TESTE:= V_SELECT;
    OPEN v_cursor FOR
   -- SELECT 1 FROM DUAL;
    V_SELECT;
		


  io_cursor := v_cursor;
end PRC_CAD_PRD_PRODUTO_S;

