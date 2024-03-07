

--PRC_FAT_OBS_OBSERV_SETOR_I
create or replace procedure PRC_FAT_OBS_OBSERV_SETOR_I
(
     pNewIdt OUT integer,
     pFAT_OBS_ID IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_ID%type default NULL,
     pFAT_OBS_DS_OBSERVACAO IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_DS_OBSERVACAO%type,
     pCAD_SET_ID_SETOR IN TB_FAT_OBS_OBSERV_SETOR.CAD_SET_ID_SETOR%type default NULL,
     pFAT_OBS_FL_STATUS IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_FL_STATUS%type,
     pFAT_OBS_DT_ULTIMA_ATUALIZACAO IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_OBS_OBSERV_SETOR.SEG_USU_ID_USUARIO%type	
) 
is
/********************************************************************
*    Procedure: PRC_FAT_OBS_OBSERV_SETOR_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_FAT_OBS_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_FAT_OBS_OBSERV_SETOR
(
       FAT_OBS_ID,
       FAT_OBS_DS_OBSERVACAO,
       CAD_SET_ID_SETOR,
       FAT_OBS_FL_STATUS,
       FAT_OBS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
)
VALUES
(
      lIdtRetorno,
	     pFAT_OBS_DS_OBSERVACAO,
	     pCAD_SET_ID_SETOR,
	     pFAT_OBS_FL_STATUS,
	     pFAT_OBS_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
);
    pNewIdt := lIdtRetorno;	
end PRC_FAT_OBS_OBSERV_SETOR_I;

