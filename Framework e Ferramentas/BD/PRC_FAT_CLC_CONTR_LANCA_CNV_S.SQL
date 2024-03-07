

--PRC_FAT_CLC_CONTR_LANCA_CNV_S
create or replace procedure PRC_FAT_CLC_CONTR_LANCA_CNV_S 
(
     pFAT_CLC_ID IN TB_FAT_CLC_CONTR_LANCA_CNV.FAT_CLC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_CLC_CONTR_LANCA_CNV_S
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
       FAT_CLC_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_SET_ID,
       TIS_CBO_CD_CBOS,
       CAD_PRD_ID,
       FAT_CLC_FL_LIGADO,
       FAT_CLC_FL_ABERTURA_ATEND,
       FAT_CLC_FL_LANCAMENTO_PROD,
       FAT_CLC_FL_STATUS,
       FAT_CLC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       FAT_CLC_QT_PRODUTO,
       TIS_TAT_CD_TPATENDIMENTO
FROM TB_FAT_CLC_CONTR_LANCA_CNV
WHERE
        FAT_CLC_ID = pFAT_CLC_ID;          
io_cursor := v_cursor;
end PRC_FAT_CLC_CONTR_LANCA_CNV_S;
