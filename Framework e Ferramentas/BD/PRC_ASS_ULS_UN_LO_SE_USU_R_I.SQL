
--PRC_ASS_ULS_UNID_LOC_SET_USU_R_I
create or replace procedure PRC_ASS_ULS_UN_LO_SE_USU_R_I
(
     pNewIdt OUT integer,
     pASS_ULS_ID IN TB_ASS_ULS_UNID_LOC_SET_USU.ASS_ULS_ID%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_ULS_UNID_LOC_SET_USU.SEG_USU_ID_USUARIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_UNI_ID_UNIDADE%type,
     pCAD_SET_ID IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_SET_ID%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pASS_ULS_FL_STATUS IN TB_ASS_ULS_UNID_LOC_SET_USU.ASS_ULS_FL_STATUS%type,
     pASS_DT_ULTIMA_ATUALIZACAO IN TB_ASS_ULS_UNID_LOC_SET_USU.ASS_DT_ULTIMA_ATUALIZACAO%type,
     pASS_ULS_ID_USUARIO IN TB_ASS_ULS_UNID_LOC_SET_USU.ASS_ULS_ID_USUARIO%type	
) 
is
/********************************************************************
*    Procedure: PRC_ASS_ULS_UNID_LOC_SET_USU_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_ASS_ULS_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_ASS_ULS_UNID_LOC_SET_USU
(
       ASS_ULS_ID,
       SEG_USU_ID_USUARIO,
       CAD_UNI_ID_UNIDADE,
       CAD_SET_ID,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ASS_ULS_FL_STATUS,
       ASS_DT_ULTIMA_ATUALIZACAO,
       ASS_ULS_ID_USUARIO
)
VALUES
(
      lIdtRetorno,
	     pSEG_USU_ID_USUARIO,
	     pCAD_UNI_ID_UNIDADE,
	     pCAD_SET_ID,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	     pASS_ULS_FL_STATUS,
	     pASS_DT_ULTIMA_ATUALIZACAO,
	     pASS_ULS_ID_USUARIO
);
    pNewIdt := lIdtRetorno;	
end PRC_ASS_ULS_UN_LO_SE_USU_R_I;

