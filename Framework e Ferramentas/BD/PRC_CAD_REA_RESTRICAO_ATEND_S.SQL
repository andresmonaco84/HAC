

--PRC_CAD_REA_RESTRICAO_ATEND_S
create or replace procedure PRC_CAD_REA_RESTRICAO_ATEND_S 
(
     pATD_ATE_ID IN TB_CAD_REA_RESTRICAO_ATEND.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_CAD_REA_RESTRICAO_ATEND.CAD_PAC_ID_PACIENTE%type,
     pCAD_PES_ID_PESSOA_RESPONSAVEL IN TB_CAD_REA_RESTRICAO_ATEND.CAD_PES_ID_PESSOA_RESPONSAVEL%type,
     pCAD_REA_DT_INICIO_VIGENCIA IN TB_CAD_REA_RESTRICAO_ATEND.CAD_REA_DT_INICIO_VIGENCIA%type,
     pFAT_CCP_ID IN TB_CAD_REA_RESTRICAO_ATEND.FAT_CCP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_REA_RESTRICAO_ATEND_S
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
       CAD_PAC_ID_PACIENTE,
       CAD_REA_DT_INICIO_VIGENCIA,
       CAD_REA_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_REA_DT_CRIACAO,
       SEG_USU_ID_USUARIO_ATUALIZ,
       CAD_REA_DT_ULTIMA_ATUALIZ,
       CAD_PES_ID_PESSOA_RESPONSAVEL,
       ATD_ATE_ID,
       FAT_CCP_ID,
       CAD_REA_DS_OBSERVACAO,
       FAT_NOF_ID
FROM TB_CAD_REA_RESTRICAO_ATEND
WHERE
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND CAD_PES_ID_PESSOA_RESPONSAVEL = pCAD_PES_ID_PESSOA_RESPONSAVEL
    AND CAD_REA_DT_INICIO_VIGENCIA = pCAD_REA_DT_INICIO_VIGENCIA
    AND FAT_CCP_ID = pFAT_CCP_ID;          
io_cursor := v_cursor;
end PRC_CAD_REA_RESTRICAO_ATEND_S;
