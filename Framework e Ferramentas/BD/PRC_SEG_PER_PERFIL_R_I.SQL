
--PRC_SEG_PER_PERFIL_R_I
create or replace procedure PRC_SEG_PER_PERFIL_R_I
(
     pNewIdt OUT integer,
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type default NULL,
     pSEG_PER_NM_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_NM_PERFIL%type,
     pSEG_PER_FL_STATUS IN TB_SEG_PER_PERFIL.SEG_PER_FL_STATUS%type,
     pSEG_PER_DT_ULTIMA_ATUALIZACAO IN TB_SEG_PER_PERFIL.SEG_PER_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_PER_PERFIL.SEG_USU_ID_USUARIO%type	
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PER_PERFIL_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_SEG_PER_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_SEG_PER_PERFIL
(
       SEG_PER_ID_PERFIL,
       SEG_PER_NM_PERFIL,
       SEG_PER_FL_STATUS,
       SEG_PER_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
)
VALUES
(
      lIdtRetorno,
	     pSEG_PER_NM_PERFIL,
	     pSEG_PER_FL_STATUS,
	     pSEG_PER_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
);
    pNewIdt := lIdtRetorno;	
end PRC_SEG_PER_PERFIL_R_I;

