

--PRC_CAD_REP_BCP_BASE_CALCULO_U 
create or replace procedure PRC_CAD_REP_BCP_BASE_CALCULO_U
(
     pCAD_REP_TP_BASE_CALCULO IN TB_CAD_REP_BCP_BASE_CALCULO.CAD_REP_TP_BASE_CALCULO%type,
     pREP_BCP_DS_BASE_CALCULO IN TB_CAD_REP_BCP_BASE_CALCULO.REP_BCP_DS_BASE_CALCULO%type,
     pREP_BCP_DS_CAMPO IN TB_CAD_REP_BCP_BASE_CALCULO.REP_BCP_DS_CAMPO%type,
     pREP_BCP_NM_CONTROLE IN TB_CAD_REP_BCP_BASE_CALCULO.REP_BCP_NM_CONTROLE%type,
     pREP_BCP_FL_ATIVO_OK IN TB_CAD_REP_BCP_BASE_CALCULO.REP_BCP_FL_ATIVO_OK%type,     
) 
is
/********************************************************************
*    Procedure: PRC_CAD_REP_BCP_BASE_CALCULO_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_CAD_REP_BCP_BASE_CALCULO
SET	   
        REP_BCP_DS_BASE_CALCULO = pREP_BCP_DS_BASE_CALCULO,
        REP_BCP_DS_CAMPO = pREP_BCP_DS_CAMPO,
        REP_BCP_NM_CONTROLE = pREP_BCP_NM_CONTROLE,
        REP_BCP_FL_ATIVO_OK = pREP_BCP_FL_ATIVO_OK        
WHERE
        CAD_REP_TP_BASE_CALCULO = pCAD_REP_TP_BASE_CALCULO;	
end PRC_CAD_REP_BCP_BASE_CALCULO_U;

