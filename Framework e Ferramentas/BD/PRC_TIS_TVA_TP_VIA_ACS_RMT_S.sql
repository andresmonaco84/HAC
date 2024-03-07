create or replace procedure PRC_TIS_TVA_TP_VIA_ACS_RMT_S
(
     pTIS_TVA_CD_VIAACESSO IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_CD_VIAACESSO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_TIS_TVA_TP_VIA_ACS_RMT_S
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
       TIS_TVA_CD_VIAACESSO,
       TIS_TVA_DS_VIAACESSO
FROM TB_TIS_TVA_TP_VIA_ACESSO
WHERE
        TIS_TVA_CD_VIAACESSO = pTIS_TVA_CD_VIAACESSO;          
io_cursor := v_cursor;
end PRC_TIS_TVA_TP_VIA_ACS_RMT_S;
