

--PRC_ASS_BCT_BANCO_CONTA_S
create or replace procedure PRC_ASS_BCT_BANCO_CONTA_S 
(
     pASS_BCT_ID IN TB_ASS_BCT_BANCO_CONTA.ASS_BCT_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_BCT_BANCO_CONTA_S
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
       ASS_BCT_ID,
       CAD_BAN_ID,
       ASS_BCT_CD_AGENCIA,
       ASS_BCT_NR_CONTA,
       ASS_BCT_CD_CTA_CAIXA_RM,
       ASS_BCT_FL_ATIVO,
       ASS_BCT_DV_AGENCIA,
       ASS_BCT_DV_CONTA,
       ASS_BCT_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       ASS_BCT_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ,
       ASS_BCT_CD_BANCO_LEG
FROM TB_ASS_BCT_BANCO_CONTA
WHERE
        ASS_BCT_ID = pASS_BCT_ID;          
io_cursor := v_cursor;
end PRC_ASS_BCT_BANCO_CONTA_S;
