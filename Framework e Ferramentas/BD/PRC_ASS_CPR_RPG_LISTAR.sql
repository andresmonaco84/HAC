 CREATE OR REPLACE PROCEDURE "PRC_ASS_CPR_RPG_LISTAR"
(
     pCAD_CPR_ID IN TB_ASS_CPR_CLINICA_PROF.ASS_CPR_ID%type,
     pCAD_REP_ID IN TB_CAD_REP_REGRA_PAGAMENTO.CAD_REP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_CPR_RPG_PAGTO_S
*
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT * FROM TB_ASS_RPG_REGRA_PAGTO RPG
WHERE RPG.ASS_CPR_ID = pCAD_CPR_ID AND RPG.CAD_REP_ID = pCAD_REP_ID;

io_cursor := v_cursor;
end PRC_ASS_CPR_RPG_LISTAR;
 