create or replace procedure PRC_CAD_REP_REGRA_PAGAMENTO_S
(
     pCAD_REP_ID IN TB_CAD_REP_REGRA_PAGAMENTO.CAD_REP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_REP_REGRA_PAGAMENTO_S
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
       CAD_REP_ID,
       CAD_REP_NM_REGRA,
       CAD_PRD_ID,
       TIS_MED_CD_TABELAMEDICA,
       AUX_EPP_CD_ESPECPROC,
       AUX_GPC_CD_GRUPOPROC,
       CAD_REP_VL_PAGTO,
       CAD_REP_VL_MINIMO,
       CAD_REP_QT_INDICE,
       CAD_REP_PC_REPASSE,
       CAD_REP_TP_BASE_CALCULO,
       CAD_REP_VL_PAGTO_FIXO,
       CAD_REP_DT_INICIO_VIGENCIA,
       CAD_REP_DT_FIM_VIGENCIA,
       CAD_REP_FL_PAGO_HORA,
       CAD_REP_FL_PAGO_PLANTAO,
       SEG_USU_ID_USUARIO,
       CAD_REP_DT_ULTIMA_ATUALIZACAO,
       CAD_REP_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_REP_VL_PAGTO_EXTRA,
       CAD_REP_CD_TIPO_EXTRA,
       CAD_REP_PC_RETENCAO,
       CAD_REP_VL_INDICE_HOSP,
       CAD_REP_FL_MENSAL,
       CAD_REP_FL_EXTRA_SAB,
       CAD_REP_FL_EXTRA_DOM,
       CAD_REP_FL_EXTRA_FER,
       TIS_TAC_CD_TIPO_ACOMOD_AUT,
       CAD_REP_DS_COMPLEMENTAR
FROM TB_CAD_REP_REGRA_PAGAMENTO
WHERE
        CAD_REP_ID = pCAD_REP_ID;          
io_cursor := v_cursor;
end PRC_CAD_REP_REGRA_PAGAMENTO_S;
