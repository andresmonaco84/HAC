create or replace procedure PRC_ATD_IDR_INT_DADOS_RN_S
(
     pATD_IDR_ID IN TB_ATD_IDR_INT_DADOS_RN.ATD_IDR_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_IDR_INT_DADOS_RN_S
*
*    Data Criacao: 	data da  cria??o   Por: Nome do Analista
*    Data Alteracao:	data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ATD_ATE_ID,
       ATD_IDR_ID,
       ATD_IDR_DT_NASCIMENTO,
       ATD_IDR_NM_NOME,
       ATD_IDR_APGAR1,
       ATD_IDR_APGAR2,
       ATD_IDR_APGAR3,
       ATD_IDR_TP_SEXO,
       ATD_IDR_DS_IDADE_GESTACIONAL,
       ATD_IDR_NR_DNV,
       ATD_IDR_QT_PESO,
       CAD_CID_CD_CID10,
       ATD_IDR_ST_MORTE_PARTO,
       ATD_IDR_FL_MAFORMACAO,
       ATD_IDR_DS_MAFORMACAO,
       ATD_IDR_FL_ATE_RN_SALA_PARTO,
       ATD_IDR_FL_COMPLIC_NEONATAL,
       ATD_IDR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_IDR_FL_PREMATURO,
       ATD_IDR_NR_DOCUMENTOOBITO,
       ATD_IDR_HR_NASCIMENTO,
       ATD_IDR_QT_PERIM_CEFALICO,
       ATD_IDR_FL_CONT_PELE_A_PELE,
       ATD_IDR_FL_TORCHS_1,
       ATD_IDR_FL_TORCHS_3,
       ATD_IDR_FL_RISCO_INFECCIOSO,
       ATD_IDR_FL_AMAMENT_PRIM_HORA,
       ATD_IDR_DS_MOTIVO_AMAM_PRI_HR,
       ATD_IDR_FL_TRANSF_UTI_NEO,
       ATD_IDR_DS_LOTE_VACINA_HEPAT_B,
       ATD_IDR_QT_ALTURA,
       ATD_IDR_DT_ALTA_CLINICA,
       ATD_IDR_HR_ALTA_CLINICA,
       ATD_IDR_DT_ALTA_ADM,
       ATD_IDR_HR_ALTA_ADM,
       SEG_USU_ID_USUARIO_ALTA,
       CAD_PRO_ID_PROFISSIONAL,
       TIS_CBO_CD_CBOS,
       ATD_IDR_FL_NATIMORTO,
	   TIS_MSI_CD_MOTIVOSAIDAINT,
	   ATD_IDR_DT_ATUALIZACAO_ALTA,
     ATD_IDR_APGAR4,
       ATD_IDR_EXAM_CORDAO_SOLIC,
       ATD_IDR_EXAM_SUMARIO,
       ATD_IDR_EXAM_RELEVANT,
       ATD_IDR_MED_ATUAIS,
       ATD_IDR_FL_ANTIBIOTICOS,
       ATD_IDR_DS_ANTIBIOTICOS,
       ATD_IDR_TESTE_PE,
       ATD_IDR_TESTE_ORELHA,
       ATD_IDR_TESTE_LINGUA,
       ATD_IDR_TESTE_REFLEX_VERM,
       ATD_IDR_TESTE_ORTOLANI,
       ATD_IDR_TESTE_CORACAO,
       ATD_IDR_TESTE_OUTROS_EXAMES,
       ATD_IDR_FL_BCG,
       ATD_IDR_FL_HEPATB_AO_NASCER,
       ATD_IDR_TIPAG_SANG,
       ATD_IDR_INTERCORRENCIA,
       ATD_IDR_INTERC_DIAG,
       ATD_IDR_ORIENTACOES,
       SEG_USU_ID_MEDICO,
       ATD_IDR_DT_ATUALIZ_MED,
       ATD_IDR_DROGAS,
       ATD_IDR_CLASSIF_PESO,
       ATD_IDR_TIPO_LEITE,
       ATD_IDR_QT_PESOALTA,
       ATD_IDR_FL_PREV_OFT,
       ATD_IDR_FL_PREV_HEM
       
FROM TB_ATD_IDR_INT_DADOS_RN
WHERE
        ATD_IDR_ID = pATD_IDR_ID;
io_cursor := v_cursor;
end PRC_ATD_IDR_INT_DADOS_RN_S;
/
