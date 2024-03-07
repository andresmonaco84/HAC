create or replace procedure PRC_ATD_AIC_ATE_INT_COMPL_S
(
     pATD_ATE_ID IN TB_ATD_AIC_ATE_INT_COMPL.ATD_ATE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_AIC_ATE_INT_COMPL_S
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao: data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ATD_ATE_ID,
       TIS_TIN_CD_INTERNACAO,
       CAD_PRO_ID_PROF_ADM,
       ATD_AIC_DS_CONTATO,
       ATD_AIC_DS_PROCEDIMENTO,
       TIS_TRI_CD_REGINTENNACAO,
       ATD_AIC_QT_DIARIA_SOLICITADA,
       ATD_AIC_DS_EMPRESA,
       ATD_AIC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_AIC_TP_SITUACAO_PAC,
       CAD_PRD_ID,
       ATD_AIC_FL_PAC_ESTADOGRAVE,
       ATD_ATE_ID_ORIGEM
FROM TB_ATD_AIC_ATE_INT_COMPL
WHERE
        ATD_ATE_ID = pATD_ATE_ID;
io_cursor := v_cursor;
end PRC_ATD_AIC_ATE_INT_COMPL_S;
 