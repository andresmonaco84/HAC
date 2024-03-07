

--PRC_FAT_OBS_OBSERV_SETOR_U
create or replace procedure PRC_FAT_OBS_OBSERV_SETOR_U
(
     pFAT_OBS_ID IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_ID%type,
     pFAT_OBS_DS_OBSERVACAO IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_DS_OBSERVACAO%type,
     pCAD_SET_ID_SETOR IN TB_FAT_OBS_OBSERV_SETOR.CAD_SET_ID_SETOR%type default NULL,
     pFAT_OBS_FL_STATUS IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_FL_STATUS%type,
     pFAT_OBS_DT_ULTIMA_ATUALIZACAO IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_OBS_OBSERV_SETOR.SEG_USU_ID_USUARIO%type
) 
is
/********************************************************************
*    Procedure: PRC_FAT_OBS_OBSERV_SETOR_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_FAT_OBS_OBSERV_SETOR
SET	   
        FAT_OBS_DS_OBSERVACAO = pFAT_OBS_DS_OBSERVACAO,
        CAD_SET_ID_SETOR = pCAD_SET_ID_SETOR,
        FAT_OBS_FL_STATUS = pFAT_OBS_FL_STATUS,
        FAT_OBS_DT_ULTIMA_ATUALIZACAO = pFAT_OBS_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
WHERE
        FAT_OBS_ID = pFAT_OBS_ID;	
end PRC_FAT_OBS_OBSERV_SETOR_U;

