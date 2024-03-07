

--PRC_CAD_CUR_CONV_UNI_REFER_I
create or replace procedure PRC_CAD_CUR_CONV_UNI_REFER_I
(
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CUR_CONV_UNI_REFER.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_CUR_CONV_UNI_REFER.CAD_UNI_ID_UNIDADE%type,
     pCAD_CUR_CD_REFERENCIADO IN TB_CAD_CUR_CONV_UNI_REFER.CAD_CUR_CD_REFERENCIADO%type,
     pCAD_CUR_DT_ULTIMA_ATUALIZACAO IN TB_CAD_CUR_CONV_UNI_REFER.CAD_CUR_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_CUR_CONV_UNI_REFER.SEG_USU_ID_USUARIO%type,
     pCAD_CUR_FL_STATUS IN TB_CAD_CUR_CONV_UNI_REFER.CAD_CUR_FL_STATUS%type,
     pCAD_SET_ID IN TB_CAD_CUR_CONV_UNI_REFER.CAD_SET_ID%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CUR_CONV_UNI_REFER_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_CAD_CUR_CONV_UNI_REFER
(
       CAD_CNV_ID_CONVENIO,
       CAD_UNI_ID_UNIDADE,
       CAD_CUR_CD_REFERENCIADO,
       CAD_CUR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_CUR_FL_STATUS,
       CAD_SET_ID
)
VALUES
(
	     pCAD_CNV_ID_CONVENIO,
	     pCAD_UNI_ID_UNIDADE,
	     pCAD_CUR_CD_REFERENCIADO,
	     pCAD_CUR_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pCAD_CUR_FL_STATUS,
	     pCAD_SET_ID
);
	
end PRC_CAD_CUR_CONV_UNI_REFER_I;

