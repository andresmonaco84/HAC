--PRC_REP_RPA_RESUMO_PAGTO_S
create or replace procedure PRC_REP_RPA_RESUMO_PAGTO_S 
(
     pREP_RPA_ID IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_REP_RPA_RESUMO_PAGTO_S
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
       REP_RPA_ID,
       CAD_CLC_ID,
       REP_RPA_DT_PAGAMENTO,
       REP_RPA_MES_PAGTO,
       REP_RPA_ANO_PAGTO,
       REP_RPA_TP_CREDENCIA_PROF,
       REP_RPA_VL_PAGTO_CLINICA,
       SEG_USU_ID_USUARIO,
       REP_RPA_DT_ULTIMA_ATUALIZACAO,
       REP_RPA_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       REP_RPA_VL_DESCONTO,
       CAD_UNI_ID_UNIDADE,
       REP_RPA_VL_ACRESCIMO,
       REP_RPA_DT_INICIO,
       REP_RPA_DT_FIM,
       ID_CAD_JPG,
       REP_PRA_VL_IMPOSTO,
       REP_RPA_FL_STATUS,
       REP_RPA_FONTE_PAGADORA,
       CAD_UNI_ID_UNIDADE_ATEND,
       CAD_LAT_ID_LOCAL_ATEND,
       REP_RPA_FL_ANTECIPACAO
FROM TB_REP_RPA_RESUMO_PAGTO
WHERE
        REP_RPA_ID = pREP_RPA_ID;          
io_cursor := v_cursor;
end PRC_REP_RPA_RESUMO_PAGTO_S;
