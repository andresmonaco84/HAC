
--PRC_SEG_PER_PERFIL_R_U
create or replace procedure PRC_SEG_PER_PERFIL_R_U
(
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type,
     pSEG_PER_NM_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_NM_PERFIL%type,
     pSEG_PER_FL_STATUS IN TB_SEG_PER_PERFIL.SEG_PER_FL_STATUS%type,
     pSEG_PER_DT_ULTIMA_ATUALIZACAO IN TB_SEG_PER_PERFIL.SEG_PER_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_PER_PERFIL.SEG_USU_ID_USUARIO%type
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PER_PERFIL_R_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_SEG_PER_PERFIL
SET	   
        SEG_PER_NM_PERFIL = pSEG_PER_NM_PERFIL,
        SEG_PER_FL_STATUS = pSEG_PER_FL_STATUS,
        SEG_PER_DT_ULTIMA_ATUALIZACAO = pSEG_PER_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
WHERE
        SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;	
end PRC_SEG_PER_PERFIL_R_U;

