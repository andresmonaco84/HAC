

--PRC_CAD_CUR_CONV_UNI_REFER_D
create or replace procedure PRC_CAD_CUR_CONV_UNI_REFER_D 
(
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CUR_CONV_UNI_REFER.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_CUR_CONV_UNI_REFER.CAD_UNI_ID_UNIDADE%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_CUR_CONV_UNI_REFER_D
* 
*    Data Criacao: 	27/07/2010   Por: André Souza Monaco
*    Data Alteracao:	           Por: 
*
*    Funcao: Exclui código referência de convênio e unidade
*
*******************************************************************/    
begin
DELETE TB_CAD_CUR_CONV_UNI_REFER
WHERE  
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;	   
end PRC_CAD_CUR_CONV_UNI_REFER_D;
