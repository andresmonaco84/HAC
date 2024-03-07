create or replace procedure PRC_ASS_PCF_PROF_CFM_I
(
     pNewIdt OUT integer,
     --pASS_PCF_ID_PROF_CFM IN TB_ASS_PCF_PROF_CFM.ASS_PCF_ID_PROF_CFM%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PCF_PROF_CFM.CAD_PRO_ID_PROFISSIONAL%type,
     pCAD_CFM_ID_CFM IN TB_ASS_PCF_PROF_CFM.CAD_CFM_ID_CFM%type,
     --pASS_PCF_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PCF_PROF_CFM.ASS_PCF_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_PCF_PROF_CFM.SEG_USU_ID_USUARIO%type
)
is
/********************************************************************
*    Procedure: PRC_ASS_PCF_PROF_CFM_I
*
*    Data Criacao: 	13/04/2012   Por: André
*
*    Funcao: Inclui associação de Especialidade CFM com profissional
*
*******************************************************************/
lIdtRetorno integer;
begin

SELECT SEQ_ASS_PCF_01.NextVal INTO lIdtRetorno FROM DUAL;

INSERT INTO TB_ASS_PCF_PROF_CFM
(
       ASS_PCF_ID_PROF_CFM,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_CFM_ID_CFM,
       ASS_PCF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
)
VALUES
(
	     lIdtRetorno,
	     pCAD_PRO_ID_PROFISSIONAL,
	     pCAD_CFM_ID_CFM,
	     SYSDATE,
	     pSEG_USU_ID_USUARIO
);

pNewIdt := lIdtRetorno;

end PRC_ASS_PCF_PROF_CFM_I;
