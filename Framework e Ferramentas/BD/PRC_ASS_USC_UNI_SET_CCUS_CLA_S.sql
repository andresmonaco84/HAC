

--PRC_ASS_USC_UNI_SET_CCUS_CLA_S
create or replace procedure PRC_ASS_USC_UNI_SET_CCUS_CLA_S 
(
     pASS_USC_ID IN TB_ASS_USC_UNI_SET_CCUS_CLA.ASS_USC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_USC_UNI_SET_CCUS_CLA_S
* 
*	 Data Criacao: 	 12/2009    Por: Pedro
*    Data Alteracao: 06/09/2010 Por: André Souza Monaco
*         Alteração: Adição do campo FAT_TCO_ID
*
*    Data Alteracao: 24/09/2010 Por: Rafael Coimbra
*         Alteração: Adição do campo CAD_PRD_ID
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       ASS_USC_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_SET_ID,
       CAD_CEC_ID_CCUSTO,
       CAD_CAC_ID_CLASSCONTABIL,
       ASS_USC_FL_STATUS,
       ASS_USC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       AUX_EPP_CD_ESPECPROC,
       TIS_MED_CD_TABELAMEDICA,
       ASS_USC_DT_INICIO_VIGENCIA,
       ASS_USC_DT_FIM_VIGENCIA,
       TIS_CBO_CD_CBOS,
       CAD_TAP_TP_ATRIBUTO,
       FAT_TCO_ID,
       CAD_PRD_ID
FROM TB_ASS_USC_UNI_SET_CCUS_CLA
WHERE
        ASS_USC_ID = pASS_USC_ID;          
io_cursor := v_cursor;
end PRC_ASS_USC_UNI_SET_CCUS_CLA_S;
