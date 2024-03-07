

--PRC_ATD_PAA_ANTIBIOTICO_S
create or replace procedure PRC_ATD_PAA_ANTIBIOTICO_S 
(
     pATD_PAA_ID IN TB_ATD_PAA_ANTIBIOTICO.ATD_PAA_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ATD_PAA_ANTIBIOTICO_S
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
       ATD_PAA_ID,
       ATD_ATE_ID,
       ATD_PAA_FL_STATUS,
       ATD_PAA_ID_USU_CRIACAO,
       ATD_PAA_DT_ULT_CRIACAO,
       ATD_PAA_ID_USU_ATUALIZ,
       ATD_PAA_DT_ULT_ATUALIZ,
       ATD_PAA_DS_PRESCRICAO,
       ATD_PAA_CD_VIAADM,
       ATD_PAA_CD_ACESSO,
       ATD_PAA_DS_ACESSO,
       ATD_PAA_VL_DURACAO,
       ATD_PAA_VL_QTD,
       ATD_PAA_DT_DATAINI,
       ATD_PAA_HR_HORAINI,
       ATD_PAA_DT_DATAFIM,
       ATD_PAA_HR_HORAFIM,
       ATD_PAA_FL_LOCAL_DOM,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO
FROM TB_ATD_PAA_ANTIBIOTICO
WHERE
        ATD_PAA_ID = pATD_PAA_ID;          
io_cursor := v_cursor;
end PRC_ATD_PAA_ANTIBIOTICO_S;
