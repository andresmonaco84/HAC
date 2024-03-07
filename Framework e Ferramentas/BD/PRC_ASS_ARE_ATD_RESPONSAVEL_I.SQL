CREATE OR REPLACE PROCEDURE SGS."PRC_ASS_ARE_ATD_RESPONSAVEL_I"
(
     pATD_ATE_ID IN TB_ASS_ARE_ATD_RESPONSAVEL.ATD_ATE_ID%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_ARE_ATD_RESPONSAVEL.CAD_PES_ID_PESSOA%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_ARE_ATD_RESPONSAVEL.SEG_USU_ID_USUARIO%type,
     pASS_ARE_DT_ULTIMA_ATUALIZACAO IN TB_ASS_ARE_ATD_RESPONSAVEL.ASS_ARE_DT_ULTIMA_ATUALIZACAO%type,
     pFAT_CCP_ID IN TB_ASS_ARE_ATD_RESPONSAVEL.FAT_CCP_ID%type,
     pASS_ARE_FL_RECUSA_INF_CPF IN TB_ASS_ARE_ATD_RESPONSAVEL.ASS_ARE_FL_RECUSA_INF_CPF%type
)
is
/********************************************************************
*    Procedure: PRC_ASS_ARE_ATD_RESPONSAVEL_I
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao: data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/

begin

INSERT INTO TB_ASS_ARE_ATD_RESPONSAVEL
(
       ATD_ATE_ID,
       CAD_PES_ID_PESSOA,
       SEG_USU_ID_USUARIO,
       ASS_ARE_DT_ULTIMA_ATUALIZACAO,
       FAT_CCP_ID,
			 ASS_ARE_FL_RECUSA_INF_CPF
)
VALUES
(
      pATD_ATE_ID,
      pCAD_PES_ID_PESSOA,
      pSEG_USU_ID_USUARIO,
      pASS_ARE_DT_ULTIMA_ATUALIZACAO,
      pFAT_CCP_ID,
			pASS_ARE_FL_RECUSA_INF_CPF
);

end PRC_ASS_ARE_ATD_RESPONSAVEL_I;

 