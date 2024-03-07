

--PRC_CAD_TAN_TIPO_ANESTESIA_I
create or replace procedure PRC_CAD_TAN_TIPO_ANESTESIA_I
(
     pCAD_TAN_TP_ANESTESIA IN TB_CAD_TAN_TIPO_ANESTESIA.CAD_TAN_TP_ANESTESIA%type,
     pCAD_TAN_DS_ANESTESIA IN TB_CAD_TAN_TIPO_ANESTESIA.CAD_TAN_DS_ANESTESIA%type,
     pCAD_TAN_FL_STATUS IN TB_CAD_TAN_TIPO_ANESTESIA.CAD_TAN_FL_STATUS%type,
     pCAD_TAN_DT_ULTIMA_ATUALIZACAO IN TB_CAD_TAN_TIPO_ANESTESIA.CAD_TAN_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_TAN_TIPO_ANESTESIA.SEG_USU_ID_USUARIO%type	
) 
is
/********************************************************************
*    Procedure: PRC_CAD_TAN_TIPO_ANESTESIA_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_CAD_TAN_TIPO_ANESTESIA
(
       CAD_TAN_TP_ANESTESIA,
       CAD_TAN_DS_ANESTESIA,
       CAD_TAN_FL_STATUS,
       CAD_TAN_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
)
VALUES
(
	     pCAD_TAN_TP_ANESTESIA,
	     pCAD_TAN_DS_ANESTESIA,
	     pCAD_TAN_FL_STATUS,
	     pCAD_TAN_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
);
	
end PRC_CAD_TAN_TIPO_ANESTESIA_I;

