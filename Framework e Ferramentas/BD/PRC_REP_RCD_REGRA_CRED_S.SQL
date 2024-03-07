create or replace procedure PRC_REP_RCD_REGRA_CRED_S
(
     pREP_RCD_ID IN TB_REP_RCD_REGRA_CRED.REP_RCD_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_REP_RCD_REGRA_CRED_S
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
       REP_RCD_ID,
       REP_RCD_TP_CREDENCIA_PROF,
       REP_RCD_PC_CONTA,
			 REP_RCD_DS_DESCRICAO
FROM TB_REP_RCD_REGRA_CRED
WHERE
        REP_RCD_ID = pREP_RCD_ID;
io_cursor := v_cursor;
end PRC_REP_RCD_REGRA_CRED_S;
