

--PRC_COB_TRG_TP_RET_GUIA_D
create or replace procedure PRC_COB_TRG_TP_RET_GUIA_D 
(
     pCAD_CNV_ID_CONVENIO IN TB_COB_TRG_TIPO_RETENCAO_GUIA.CAD_CNV_ID_CONVENIO%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_TRG_TP_RET_GUIA_D
* 
*    Data Criacao: 13/06/2012   Por: Pedro
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_TRG_TIPO_RETENCAO_GUIA
WHERE  
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;	   
end PRC_COB_TRG_TP_RET_GUIA_D;
