

--PRC_CAD_CMM_CARACT_MATMED_I
create or replace procedure PRC_CAD_CMM_CARACT_MATMED_I
(
     pCAD_CMM_CD_CARACMATMED IN TB_CAD_CMM_CARACT_MATMED.CAD_CMM_CD_CARACMATMED%type,
     pCAD_CMM_DS_CARACMATMED IN TB_CAD_CMM_CARACT_MATMED.CAD_CMM_DS_CARACMATMED%type,
     pCAD_CMM_FL_STATUS IN TB_CAD_CMM_CARACT_MATMED.CAD_CMM_FL_STATUS%type,
     pCAD_CMM_DT_ULTIMA_ATUALIZACAO IN TB_CAD_CMM_CARACT_MATMED.CAD_CMM_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_CMM_CARACT_MATMED.SEG_USU_ID_USUARIO%type	
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CMM_CARACT_MATMED_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_CAD_CMM_CARACT_MATMED
(
       CAD_CMM_CD_CARACMATMED,
       CAD_CMM_DS_CARACMATMED,
       CAD_CMM_FL_STATUS,
       CAD_CMM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
)
VALUES
(
	     pCAD_CMM_CD_CARACMATMED,
	     pCAD_CMM_DS_CARACMATMED,
	     pCAD_CMM_FL_STATUS,
	     pCAD_CMM_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
);
	
end PRC_CAD_CMM_CARACT_MATMED_I;

