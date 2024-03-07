
--PRC_CAD_UNI_UNIDADE_R_S
create or replace procedure PRC_CAD_UNI_UNIDADE_R_S 
(
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_UNI_UNIDADE_R_S
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
       CAD_UNI_DS_IMAGEM_ASSOCIADA,
       CAD_UNI_FL_STATUS,
       CAD_UNI_DT_ULTIMO_STATUS,
       CAD_UNI_FL_GRAVA_ATEND_OK,
       CAD_UNI_FL_LIBERA_AGENDA_OK,
       CAD_UNI_FL_GRAVA_CD_PAC_OK,
       CAD_UNI_ID_UNIDADE_MASTER,
       CAD_PES_ID_PESSOA,
       CAD_UNI_NR_CNES,
       CAD_UNI_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_UNI_CD_HOSPITALAR,
       CAD_UNI_CD_UNID_HOSPITALAR,
       CAD_UNI_FL_CRONICO_OK,
       CAD_UNI_FL_PRIORIDADE_OK,
       CAD_UNI_DS_UNIDADE,
       CAD_UNI_FL_LIB_LOC_SETOR_OK
FROM TB_CAD_UNI_UNIDADE
WHERE
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;          
io_cursor := v_cursor;
end PRC_CAD_UNI_UNIDADE_R_S;
