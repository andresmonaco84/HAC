
--PRC_SEG_PAR_PARAMETRO_R_S
create or replace procedure PRC_SEG_PAR_PARAMETRO_R_S 
(
     pSEG_PAR_CD IN TB_SEG_PAR_PARAMETRO.SEG_PAR_CD%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PAR_PARAMETRO_R_S
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
       SEG_PAR_CD,
       SEG_PAR_NM_PARAMETRO,
       SEG_PAR_VL_PARAMETRO
FROM TB_SEG_PAR_PARAMETRO
WHERE
        SEG_PAR_CD = pSEG_PAR_CD;          
io_cursor := v_cursor;
end PRC_SEG_PAR_PARAMETRO_R_S;
