

--PRC_FAT_COF_CONTROLE_FECHA_S
create or replace procedure PRC_FAT_COF_CONTROLE_FECHA_S 
(
     pATD_ATE_TP_PACIENTE IN TB_FAT_COF_CONTROLE_FECHA.ATD_ATE_TP_PACIENTE%type,
     pCAD_CNV_ID_CONVENIO IN TB_FAT_COF_CONTROLE_FECHA.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_FAT_COF_CONTROLE_FECHA.CAD_UNI_ID_UNIDADE%type,
     pFAT_COF_NR_ANO_FATURAMENTO IN TB_FAT_COF_CONTROLE_FECHA.FAT_COF_NR_ANO_FATURAMENTO%type,
     pFAT_COF_NR_MES_FATURAMENTO IN TB_FAT_COF_CONTROLE_FECHA.FAT_COF_NR_MES_FATURAMENTO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_COF_CONTROLE_FECHA_S
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
       CAD_CNV_ID_CONVENIO,
       CAD_UNI_ID_UNIDADE,
       FAT_COF_NR_MES_FATURAMENTO,
       FAT_COF_NR_ANO_FATURAMENTO,
       FAT_COF_FL_SITUACAO_FECHA,
       FAT_COF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_ATE_TP_PACIENTE
FROM TB_FAT_COF_CONTROLE_FECHA
WHERE
        ATD_ATE_TP_PACIENTE = pATD_ATE_TP_PACIENTE
    AND CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND FAT_COF_NR_ANO_FATURAMENTO = pFAT_COF_NR_ANO_FATURAMENTO
    AND FAT_COF_NR_MES_FATURAMENTO = pFAT_COF_NR_MES_FATURAMENTO;          
io_cursor := v_cursor;
end PRC_FAT_COF_CONTROLE_FECHA_S;
