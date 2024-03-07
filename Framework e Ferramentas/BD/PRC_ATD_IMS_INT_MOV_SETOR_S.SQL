create or replace procedure PRC_ATD_IMS_INT_MOV_SETOR_S 
(
     pATD_IMS_ID IN TB_ATD_IMS_INT_MOV_SETOR.ATD_IMS_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ATD_IMS_INT_MOV_SETOR_S
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
       ATD_ATE_ID,
       ATD_IMS_DT_ENTRADA,
       ATD_IMS_HR_ENTRADA,
       ATD_IMS_DT_SAIDA,
       ATD_IMS_HR_SAIDA,
       CAD_SET_ID_SETOR,
       ATD_IMS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_IMS_DS_OBSERVACAO,
       ATD_IMS_ID,
       ATD_IMS_FL_STATUS,
	   TIS_TAC_CD_TIPO_ACOMOD_AUT,
       ATD_IMS_DT_INI_ACOMOD_AUT,
       ATD_IMS_HR_INI_ACOMOD_AUT
FROM TB_ATD_IMS_INT_MOV_SETOR
WHERE
        ATD_IMS_ID = pATD_IMS_ID;          
io_cursor := v_cursor;
end PRC_ATD_IMS_INT_MOV_SETOR_S;
