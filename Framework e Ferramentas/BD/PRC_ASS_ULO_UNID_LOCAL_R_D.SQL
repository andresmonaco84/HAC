

--PRC_ASS_ULO_UNID_LOCAL_R_D
create or replace procedure PRC_ASS_ULO_UNID_LOCAL_R_D 
(
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULO_UNID_LOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULO_UNID_LOCAL.CAD_UNI_ID_UNIDADE%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_ULO_UNID_LOCAL_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_ULO_UNID_LOCAL
WHERE  
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;	   
end PRC_ASS_ULO_UNID_LOCAL_R_D;
