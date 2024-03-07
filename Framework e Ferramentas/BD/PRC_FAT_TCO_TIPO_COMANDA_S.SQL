

--PRC_FAT_TCO_TIPO_COMANDA_S
create or replace procedure PRC_FAT_TCO_TIPO_COMANDA_S 
(
     pFAT_TCO_ID IN TB_FAT_TCO_TIPO_COMANDA.FAT_TCO_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_TCO_TIPO_COMANDA_S
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
       FAT_TCO_ID,
       FAT_TCO_DS_COMANDA,
       FAT_TCO_FL_STATUS,
       FAT_TCO_FL_VERIFICA_ITENS,
       FAT_TCO_QT_MAX_LANCAMENTO,
       FAT_TCO_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PRO_ID_PROFISSIONAL
FROM TB_FAT_TCO_TIPO_COMANDA
WHERE
        FAT_TCO_ID = pFAT_TCO_ID;          
io_cursor := v_cursor;
end PRC_FAT_TCO_TIPO_COMANDA_S;
