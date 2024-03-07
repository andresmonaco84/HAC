CREATE OR REPLACE PROCEDURE "PRC_ASS_ARE_ATD_RESPONSAVEL_U"
(
     pATD_ATE_ID IN TB_ASS_ARE_ATD_RESPONSAVEL.ATD_ATE_ID%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_ARE_ATD_RESPONSAVEL.CAD_PES_ID_PESSOA%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_ARE_ATD_RESPONSAVEL.SEG_USU_ID_USUARIO%type,
     pASS_ARE_DT_ULTIMA_ATUALIZACAO IN TB_ASS_ARE_ATD_RESPONSAVEL.ASS_ARE_DT_ULTIMA_ATUALIZACAO%type,
		      pASS_ARE_FL_RECUSA_INF_CPF IN TB_ASS_ARE_ATD_RESPONSAVEL.ASS_ARE_FL_RECUSA_INF_CPF%type
)
is
/********************************************************************
*    Procedure: PRC_ASS_ARE_ATD_RESPONSAVEL_U
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao: data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
UPDATE TB_ASS_ARE_ATD_RESPONSAVEL
SET
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_ARE_DT_ULTIMA_ATUALIZACAO = pASS_ARE_DT_ULTIMA_ATUALIZACAO,
				ASS_ARE_FL_RECUSA_INF_CPF = pASS_ARE_FL_RECUSA_INF_CPF
WHERE
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA;
end PRC_ASS_ARE_ATD_RESPONSAVEL_U;

 