

--PRC_FAT_TCP_TP_COMANDA_PROD_S
create or replace procedure PRC_FAT_TCP_TP_COMANDA_PROD_S 
(
     pFAT_TCP_ID IN TB_FAT_TCP_TP_COMANDA_PROD.FAT_TCP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_TCP_TP_COMANDA_PROD_S
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
       FAT_TCP_ID,
       FAT_TCO_ID,
       CAD_PRD_ID,
       FAT_TCP_DT_ULTIMA_ATUALIZACAO,
       FAT_TCP_FL_STATUS,
       SEG_USU_ID_USUARIO
FROM TB_FAT_TCP_TP_COMANDA_PROD
WHERE
        FAT_TCP_ID = pFAT_TCP_ID;          
io_cursor := v_cursor;
end PRC_FAT_TCP_TP_COMANDA_PROD_S;
