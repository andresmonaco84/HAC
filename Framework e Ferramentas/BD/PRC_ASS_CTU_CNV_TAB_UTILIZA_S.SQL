create or replace procedure PRC_ASS_CTU_CNV_TAB_UTILIZA_S
(
     pASS_CTU_ID IN TB_ASS_CTU_CNV_TAB_UTILIZA.ASS_CTU_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_CTU_CNV_TAB_UTILIZA_S
* 
*    Data Criacao: 19/2/2010	   Por: Pedro
*    Data Alteracao: 24/08/2010  Por: André S. Monaco
*         Alteracao: Adição do campo TIS_MED_CD_TABELAMEDICA_COBRA
*
*    Funcao: Select de registro de Convenio X Tabela Utilizada
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       ASS_CTU_ID,
       CAD_CNV_ID_CONVENIO,
       TIS_MED_CD_TABELAMEDICA,
       ASS_CTU_DT_INICIO_VIGENCIA,
       SEG_USU_ID_USUARIO,
       ASS_CTU_DT_FIM_VIGENCIA,
       ASS_CTU_DT_ULTIMA_ATUALIZACAO,
       CAD_TAP_TP_ATRIBUTO,
       TIS_MED_CD_TABELAMEDICA_COBRA
FROM TB_ASS_CTU_CNV_TAB_UTILIZA
WHERE
        ASS_CTU_ID = pASS_CTU_ID;          
io_cursor := v_cursor;
end PRC_ASS_CTU_CNV_TAB_UTILIZA_S;

