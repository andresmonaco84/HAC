

--PRC_FAT_COF_CONTROLE_FECHA_D
create or replace procedure PRC_FAT_COF_CONTROLE_FECHA_D 
(
     pATD_ATE_TP_PACIENTE IN TB_FAT_COF_CONTROLE_FECHA.ATD_ATE_TP_PACIENTE%type,
     pCAD_CNV_ID_CONVENIO IN TB_FAT_COF_CONTROLE_FECHA.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_FAT_COF_CONTROLE_FECHA.CAD_UNI_ID_UNIDADE%type,
     pFAT_COF_NR_ANO_FATURAMENTO IN TB_FAT_COF_CONTROLE_FECHA.FAT_COF_NR_ANO_FATURAMENTO%type,
     pFAT_COF_NR_MES_FATURAMENTO IN TB_FAT_COF_CONTROLE_FECHA.FAT_COF_NR_MES_FATURAMENTO%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_COF_CONTROLE_FECHA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_COF_CONTROLE_FECHA
WHERE  
        ATD_ATE_TP_PACIENTE = pATD_ATE_TP_PACIENTE
    AND CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND FAT_COF_NR_ANO_FATURAMENTO = pFAT_COF_NR_ANO_FATURAMENTO
    AND FAT_COF_NR_MES_FATURAMENTO = pFAT_COF_NR_MES_FATURAMENTO;	   
end PRC_FAT_COF_CONTROLE_FECHA_D;
