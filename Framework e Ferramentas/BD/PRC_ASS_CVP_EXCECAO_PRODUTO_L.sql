create or replace procedure PRC_ASS_CVP_EXCECAO_PRODUTO_L
(
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PRD_ID IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_PRD_ID%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_PLA_ID_PLANO%type,
     pDATACONSUMO IN DATE,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_CVP_EXCECAO_PRODUTO_L
* 
*    Data Criacao: 	 17/09/2010     Por: Marcus
*    Data Alteracao: 20/09/2010     Por: André S. Monaco
*         Alteracao: Adição de campos (TIS_MED_CD_TABELAMEDICA,
*                                      AUX_EPP_CD_ESPECPROC,
*                                      AUX_GPC_CD_GRUPOPROC,
*                                      ASS_CVP_FL_STATUS)
*
*    Funcao: Pesquisa valor de procedimento do convênio vigente
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       CVP.ASS_CVP_ID,
       CVP.CAD_CNV_ID_CONVENIO,
       CVP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CVP.CAD_TAP_TP_ATRIBUTO,
       CVP.CAD_PRD_ID,
       CVP.CAD_TIH_TP_INDICE_HOSP,
       CVP.ASS_CVP_QT_INDICE_HOSP,
       CVP.ASS_CVP_VL_INDICE_HOSP,
       CVP.ASS_CVP_TP_PORTE,
       CVP.ASS_CVP_VL_PRODUTO,
       CVP.ASS_CVP_QT_MAXIMA_PERM,
       CVP.ASS_CVP_QT_MINIMA_PERM,
       CVP.ASS_CVP_PC_ACRESCIMO,
       CVP.ASS_CVP_PC_DESCONTO,
       CVP.ASS_CVP_VL_ACRESCIMO,
       CVP.ASS_CVP_VL_DESCONTO,
       CVP.ASS_CVP_PC_TAXAADM,
       CVP.ASS_CVP_PC_DOPPLER,
       CVP.ASS_CVP_DT_INICIO_VIGENCIA,
       CVP.ASS_CVP_DT_FIM_VIGENCIA,
       CVP.TIS_CDE_CD_CODIGO_DESPESA,
       CVP.ASS_CPE_ID,
       CVP.ASS_DT_ULTIMA_ATUALIZACAO,
       CVP.SEG_USU_ID_USUARIO,
       CVP.ASS_CVP_FL_PC_ACRESCIMOHR,
       CVP.ASS_CVP_FL_ISEN_COBRA,
       CVP.ASS_CVP_FL_COBERT_ANEST,
       CVP.ASS_CVP_TP_UNID_CONSUMO,
       CVP.ASS_CVP_PC_ACOMOD_HM,
       CVP.CAD_PLA_ID_PLANO,
       CVP.CAD_SPL_ID,
       CVP.CAD_UNI_ID_UNIDADE,
       CVP.TIS_MED_CD_TABELAMEDICA,
       CVP.AUX_EPP_CD_ESPECPROC,
       CVP.AUX_GPC_CD_GRUPOPROC,
       CVP.ASS_CVP_FL_STATUS
FROM TB_ASS_CVP_CONV_VLR_PRODUTO CVP
WHERE CVP.ASS_CVP_FL_STATUS = 'A'
AND CVP.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
AND CVP.CAD_PRD_ID = pCAD_PRD_ID
AND (CVP.CAD_PLA_ID_PLANO IS NULL OR CVP.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
AND fnc_validar_vigencia_data(ASS_CVP_DT_INICIO_VIGENCIA, ASS_CVP_DT_FIM_VIGENCIA, pDATACONSUMO) = 1;             
io_cursor := v_cursor;
end PRC_ASS_CVP_EXCECAO_PRODUTO_L;
