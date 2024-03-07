create or replace procedure PRC_CAD_HQL_HIS_SIT_QTO_LEI_D
(
     pCAD_HQL_ID IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_HQL_ID%type
)
is
/********************************************************************
*    Procedure: PRC_CAD_HQL_HIS_SIT_QTO_LEI_D
*
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
DELETE TB_CAD_HQL_HIS_SIT_QTO_LEITO
WHERE
        CAD_HQL_ID = pCAD_HQL_ID;
end PRC_CAD_HQL_HIS_SIT_QTO_LEI_D;