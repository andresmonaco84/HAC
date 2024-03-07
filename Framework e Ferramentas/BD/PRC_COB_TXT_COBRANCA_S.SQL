

--PRC_COB_TXT_COBRANCA_S
create or replace procedure PRC_COB_TXT_COBRANCA_S 
(
     pASS_BCT_ID IN TB_COB_TXT_COBRANCA.ASS_BCT_ID%type,
     pCAD_PES_ID_PESSOA IN TB_COB_TXT_COBRANCA.CAD_PES_ID_PESSOA%type,
     pCOB_TXT_DT_CRIACAO IN TB_COB_TXT_COBRANCA.COB_TXT_DT_CRIACAO%type,
     pCOB_TXT_DT_PAGTO IN TB_COB_TXT_COBRANCA.COB_TXT_DT_PAGTO%type,
     pCOB_TXT_ID IN TB_COB_TXT_COBRANCA.COB_TXT_ID%type,
     pCOB_TXT_SEQ_GERAL IN TB_COB_TXT_COBRANCA.COB_TXT_SEQ_GERAL%type,
     pCOB_TXT_FL_PROCESSAR IN TB_COB_TXT_COBRANCA.COB_TXT_FL_PROCESSAR%TYPE DEFAULT NULL,
			
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_TXT_COBRANCA_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       COB_TXT_ID,
       COB_TXT_DT_CRIACAO,
       COB_TXT_FL_STATUS,
       CAD_PES_ID_PESSOA,
       COB_TXT_SEQ_GERAL,
       COB_TXT_CD_BENEF,
       COB_TXT_NM_BENEF,
       COB_TXT_NR_GUIA,
       COB_TXT_NR_LOTE_TISS,
       COB_TXT_DT_ATEND,
       COB_TXT_CD_SERVICO,
       COB_TXT_DS_SERVICO,
       COB_TXT_VL_MOVIMENTO,
       COB_TXT_PC_COFINS,
       COB_TXT_VL_COFINS,
       COB_TXT_PC_PIS,
       COB_TXT_VL_PIS,
       COB_TXT_PC_CSLL,
       COB_TXT_VL_CSLL,
       COB_TXT_PC_IR,
       COB_TXT_VL_IR,
       COB_TXT_PC_ISS,
       COB_TXT_VL_ISS,
       COB_TXT_DT_PAGTO,
       COB_TXT_DT_ATUALIZA_MGC,
       ASS_BCT_ID,
       COB_CCP_ID,
       COB_COC_ID,
       ATD_ATE_ID,
       CAD_PAC_ID_PACIENTE,
       FAT_NOF_ID,
       ATD_GUI_CD_CODIGO,
       ATD_GUI_DT_VALIDADE,
       COB_TXT_NR_SEQ_PAGTO,
       COB_TXT_NR_ANEXO,
       COB_TXT_VL_ITEM,
       COB_TXT_VL_GLOSA,
       COB_TXT_CD_GLOSA,
       COB_TXT_CD_ITEM,
       COB_TXT_QT_SEPAG,
       COB_TXT_NR_GUIA_ORIGEM,
       COB_TXT_VL_MOVIMENTO_ORIGEM,
       COB_TXT_FL_PROCESSAR
FROM TB_COB_TXT_COBRANCA
WHERE
        ASS_BCT_ID = pASS_BCT_ID
    AND CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA
    AND COB_TXT_DT_CRIACAO = pCOB_TXT_DT_CRIACAO
    AND COB_TXT_DT_PAGTO = pCOB_TXT_DT_PAGTO
    AND COB_TXT_ID = pCOB_TXT_ID
    AND COB_TXT_SEQ_GERAL = pCOB_TXT_SEQ_GERAL
    AND (pCOB_TXT_FL_PROCESSAR IS NULL OR COB_TXT_FL_PROCESSAR = pCOB_TXT_FL_PROCESSAR);
io_cursor := v_cursor;
end PRC_COB_TXT_COBRANCA_S;
