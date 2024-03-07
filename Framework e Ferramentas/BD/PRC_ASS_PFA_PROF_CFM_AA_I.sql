create or replace procedure PRC_ASS_PFA_PROF_CFM_AA_I
(
     pNewIdt OUT integer,
     --pASS_PFA_ID_PROF_CFM_AA IN TB_ASS_PFA_PROF_CFM_AA.ASS_PFA_ID_PROF_CFM_AA%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PFA_PROF_CFM_AA.CAD_PRO_ID_PROFISSIONAL%type,
     pCAD_CAA_ID_AREA_ATUACAO IN TB_ASS_PFA_PROF_CFM_AA.CAD_CAA_ID_AREA_ATUACAO%type,
     pCAD_CFM_ID_CFM IN TB_ASS_PFA_PROF_CFM_AA.CAD_CFM_ID_CFM%type,
     --pASS_PFA_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PFA_PROF_CFM_AA.ASS_PFA_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_PFA_PROF_CFM_AA.SEG_USU_ID_USUARIO%type	
) 
is
/********************************************************************
*    Procedure: PRC_ASS_PFA_PROF_CFM_AA_I
* 
*    Data Criacao: 	16/04/2012   Por: André
*
*    Funcao: Inclui associação de Esp. CFM com profissional e área de atuação
*
*******************************************************************/  
lIdtRetorno integer; 
begin
	  
SELECT SEQ_ASS_PFA_01.NextVal INTO lIdtRetorno FROM DUAL;
      
INSERT INTO TB_ASS_PFA_PROF_CFM_AA
(
       ASS_PFA_ID_PROF_CFM_AA,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_CAA_ID_AREA_ATUACAO,
       CAD_CFM_ID_CFM,
       ASS_PFA_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
)
VALUES
(
	     lIdtRetorno,
	     pCAD_PRO_ID_PROFISSIONAL,
	     pCAD_CAA_ID_AREA_ATUACAO,
	     pCAD_CFM_ID_CFM,
	     SYSDATE,
	     pSEG_USU_ID_USUARIO
);
	
pNewIdt := lIdtRetorno;

end PRC_ASS_PFA_PROF_CFM_AA_I;