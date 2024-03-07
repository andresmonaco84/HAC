CREATE OR REPLACE PROCEDURE "PRC_ASS_ARE_ATD_RESPONSAVEL_S"
(
     pATD_ATE_ID IN TB_ASS_ARE_ATD_RESPONSAVEL.ATD_ATE_ID%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_ARE_ATD_RESPONSAVEL.CAD_PES_ID_PESSOA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_ARE_ATD_RESPONSAVEL_S
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
       CAD_PES_ID_PESSOA,
       SEG_USU_ID_USUARIO,
       ASS_ARE_DT_ULTIMA_ATUALIZACAO,
       FAT_CCP_ID,
			 ASS_ARE_FL_RECUSA_INF_CPF
FROM TB_ASS_ARE_ATD_RESPONSAVEL
WHERE
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA;
io_cursor := v_cursor;
end PRC_ASS_ARE_ATD_RESPONSAVEL_S;
 