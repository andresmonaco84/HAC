

--PRC_CAD_CUR_CONV_UNI_REFER_U
create or replace procedure PRC_CAD_CUR_CONV_UNI_REFER_U
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
*    Procedure: PRC_CAD_CUR_CONV_UNI_REFER_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_CAD_CUR_CONV_UNI_REFER
SET	   
        CAD_CUR_DT_ULTIMA_ATUALIZACAO = pCAD_CUR_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_CUR_FL_STATUS = pCAD_CUR_FL_STATUS,
        CAD_SET_ID = pCAD_SET_ID 
WHERE
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_CUR_CD_REFERENCIADO = pCAD_CUR_CD_REFERENCIADO
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;	
end PRC_CAD_CUR_CONV_UNI_REFER_U;

