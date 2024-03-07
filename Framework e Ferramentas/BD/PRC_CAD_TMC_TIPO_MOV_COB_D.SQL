create or replace procedure PRC_CAD_TMC_TIPO_MOV_COB_D
(
     pCAD_TMC_ID IN TB_CAD_TMC_TIPO_MOV_COBRANCA.CAD_TMC_ID%type
)
is
/********************************************************************
*    Procedure: PRC_CAD_TMC_TIPO_MOV_COB_D
*
*    Data Criacao: 	30/03/2012   Por: André
*
*    Funcao: Exclui tipo movimento cobrança
*
*******************************************************************/
begin
DELETE TB_CAD_TMC_TIPO_MOV_COBRANCA
WHERE
        CAD_TMC_ID = pCAD_TMC_ID;
end PRC_CAD_TMC_TIPO_MOV_COB_D;
