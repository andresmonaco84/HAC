

--PRC_FAT_CRC_CRONOG_FECH_CONV_S
create or replace procedure PRC_FAT_CRC_CRONOG_FECH_CONV_S 
(
     pFAT_CRC_ID IN TB_FAT_CRC_CRONOG_FECH_CONV.FAT_CRC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_CRC_CRONOG_FECH_CONV_S
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
       FAT_CRC_ID,
       CAD_CNV_ID_CONVENIO,
       FAT_CRC_NR_MES_REFERENCIA,
       FAT_CRC_NR_ANO_REFERENCIA,
       FAT_CRC_NR_DIA_EMISSAO_CONTA,
       FAT_CRC_FL_STATUS,
       FAT_CRC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       FAT_CRC_FL_EMISSAO_AUTOMATICA,
       FAT_CRC_NR_DIA_AUD_EXT_CONTA,
       FAT_CRC_NR_DIA_FECHA_CONTA,
       FAT_CRC_NR_DIA_FATUR_CONTA,
       FAT_CRC_FL_FATUR_AUTOMATICO,
       FAT_CRC_NR_DIA_EMISSAO_NF,
       FAT_CRC_NR_DIA_VENCTO_NF,
       FAT_CRC_NR_DIA_ENTREGA_NF,
       FAT_CRC_HR_LIMITE_ENTREGA_NF
FROM TB_FAT_CRC_CRONOG_FECH_CONV
WHERE
        FAT_CRC_ID = pFAT_CRC_ID;          
io_cursor := v_cursor;
end PRC_FAT_CRC_CRONOG_FECH_CONV_S;
