--PRC_CAD_TPE_TIPOEMPRESA_U
create or replace procedure PRC_CAD_TPE_TIPOEMPRESA_U
(
     pCAD_TPE_CD_CODIGO IN TB_CAD_TPE_TIPOEMPRESA.CAD_TPE_CD_CODIGO%type,
     pCAD_TPE_DS_DESCRICAO IN TB_CAD_TPE_TIPOEMPRESA.CAD_TPE_DS_DESCRICAO%type,
     pCAD_TPE_FL_STATUS IN TB_CAD_TPE_TIPOEMPRESA.CAD_TPE_FL_STATUS%type,
     pCAD_TPE_DT_ULTIMA_ATUALIZACAO IN TB_CAD_TPE_TIPOEMPRESA.CAD_TPE_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_TPE_TIPOEMPRESA.SEG_USU_ID_USUARIO%type
) 
is
/********************************************************************
*    Procedure: PRC_CAD_TPE_TIPOEMPRESA_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_CAD_TPE_TIPOEMPRESA
SET	   
        CAD_TPE_DS_DESCRICAO = pCAD_TPE_DS_DESCRICAO,
        CAD_TPE_FL_STATUS = pCAD_TPE_FL_STATUS,
        CAD_TPE_DT_ULTIMA_ATUALIZACAO = pCAD_TPE_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
WHERE
        CAD_TPE_CD_CODIGO = pCAD_TPE_CD_CODIGO;	
end PRC_CAD_TPE_TIPOEMPRESA_U;