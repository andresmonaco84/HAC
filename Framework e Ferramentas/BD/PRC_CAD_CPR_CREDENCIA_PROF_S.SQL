

--PRC_CAD_CPR_CREDENCIA_PROF_S
create or replace procedure PRC_CAD_CPR_CREDENCIA_PROF_S 
(
     pCAD_CPR_TP_CREDENCIA_PROF IN TB_CAD_CPR_CREDENCIA_PROF.CAD_CPR_TP_CREDENCIA_PROF%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CPR_CREDENCIA_PROF_S
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
       CAD_CPR_TP_CREDENCIA_PROF,
       CAD_CPR_DS_CREDENCIA_PROF
FROM TB_CAD_CPR_CREDENCIA_PROF
WHERE
        CAD_CPR_TP_CREDENCIA_PROF = pCAD_CPR_TP_CREDENCIA_PROF;          
io_cursor := v_cursor;
end PRC_CAD_CPR_CREDENCIA_PROF_S;
