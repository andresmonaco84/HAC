--PRC_ASS_TCP_TAB_CNV_PORTANES_S
create or replace procedure PRC_ASS_TCP_TAB_CNV_PORTANES_S
(
     pASS_TCP_ID IN TB_ASS_TCP_TAB_CNV_PORTE_ANES.ASS_TCP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_TCP_TAB_CNV_PORTANES_S
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
       ASS_TCP_ID,
       TIS_MED_CD_TABELAMEDICA,
       ASS_TCP_TP_PORTE,
       CAD_TIH_TP_INDICE_HOSP,
       ASS_TCP_QT_INDICE_HOSPITALAR,
       ASS_TCP_DT_INICIO_VIGENCIA,
       ASS_TCP_DT_FIM_VIGENCIA,
       ASS_TCP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_CNV_ID_CONVENIO
FROM TB_ASS_TCP_TAB_CNV_PORTE_ANES
WHERE
        ASS_TCP_ID = pASS_TCP_ID;          
io_cursor := v_cursor;
end PRC_ASS_TCP_TAB_CNV_PORTANES_S;