--PRC_REP_PPC_PAG_PROF_CLI_S
create or replace procedure PRC_REP_PPC_PAG_PROF_CLI_S 
(
     pREP_PPC_ID IN TB_REP_PPC_PAG_PROF_CLI.REP_PPC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_REP_PPC_PAG_PROF_CLI_S
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
       REP_PPC_ID,
       CAD_CLC_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL,
       CAD_PRO_ID_PROFISSIONAL,
       REP_PPC_VL_PAGO_HAC,
       REP_PPC_VL_PAGO_ACS,
       REP_PPC_MES_PAGTO,
       REP_PPC_ANO_PAGTO,
       SEG_USU_ID_USUARIO,
       REP_PPC_DT_ULTIMA_ATUALIZACAO,
       REP_RPA_ID,
       REP_PPC_FL_PAGTO,
       CAD_REP_TP_BASE_CALCULO,
       REP_PPC_MES_FECHAMENTO,
       REP_PPC_ANO_FECHAMENTO,
       REP_PPC_VL_HE_PAGO_HAC,
       REP_PPC_VL_HE_PAGO_ACS,
       REP_PPC_TP_CREDENCIA_PROF,
       REP_PPC_FONTE_PAGADORA,
       SEG_USU_ID_USUARIO_CRIACAO,
       REP_PPC_DT_CRIACAO,
	   REP_PPC_FL_ANTECIPACAO
       
FROM TB_REP_PPC_PAG_PROF_CLI
WHERE
        REP_PPC_ID = pREP_PPC_ID;          
io_cursor := v_cursor;
end PRC_REP_PPC_PAG_PROF_CLI_S;
