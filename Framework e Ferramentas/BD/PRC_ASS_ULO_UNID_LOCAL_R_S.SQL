

--PRC_ASS_ULO_UNID_LOCAL_R_S
create or replace procedure PRC_ASS_ULO_UNID_LOCAL_R_S 
(
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULO_UNID_LOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULO_UNID_LOCAL.CAD_UNI_ID_UNIDADE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_ULO_UNID_LOCAL_R_S
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
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       SEG_USU_ID_USUARIO,
       ASS_ULO_DT_ULTIMA_ATUALIZACAO,
       ASS_ULO_FL_STATUS,
       ASS_ULO_FL_LIBERA_AGENDA_OK,
       ASS_ULO_HR_INICIAL_ATEND,
       ASS_ULO_HR_FINAL_ATEND
FROM TB_ASS_ULO_UNID_LOCAL
WHERE
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;          
io_cursor := v_cursor;
end PRC_ASS_ULO_UNID_LOCAL_R_S;
