

--PRC_FAT_LNF_LOTE_CTA_PARC_NF_S
create or replace procedure PRC_FAT_LNF_LOTE_CTA_PARC_NF_S 
(
     pFAT_LNF_ID IN TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_LNF_LOTE_CTA_PARC_NF_S
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
       FAT_LNF_ID,
       FAT_LNF_DT_EMISSAO,
       FAT_LNF_HR_EMISSAO,
       FAT_LNF_VL_FATURADO,
       FAT_LNF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_FAT_LNF_LOTE_CTA_PARC_NF
WHERE
        FAT_LNF_ID = pFAT_LNF_ID;          
io_cursor := v_cursor;
end PRC_FAT_LNF_LOTE_CTA_PARC_NF_S;
