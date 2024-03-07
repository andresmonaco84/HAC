
--PRC_TIS_TTP_TPTECNICA_PROCED_S
create or replace procedure PRC_TIS_TTP_TPTECNICA_PROCED_S 
(
     pTIS_TTP_CD_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_CD_TPTECNICA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_TIS_TTP_TPTECNICA_PROCED_S
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
       TIS_TTP_CD_TPTECNICA,
       TIS_TTP_DS_TPTECNICA
FROM TB_TIS_TTP_TPTECNICA_PROCED
WHERE
        TIS_TTP_CD_TPTECNICA = pTIS_TTP_CD_TPTECNICA;          
io_cursor := v_cursor;
end PRC_TIS_TTP_TPTECNICA_PROCED_S;
