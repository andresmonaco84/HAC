

--PRC_CAD_LOG_ERRO_PROCESSO_U
create or replace procedure PRC_CAD_LOG_ERRO_PROCESSO_U
(
     pCAD_LOG_DATA_PROCESSO IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_DATA_PROCESSO%type default NULL,
     pCAD_LOG_ATE_ATD IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_ATE_ATD%type,
     pCAD_LOG_ATS_ATE IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_ATS_ATE%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_LOG_ERRO_PROCESSO.SEG_USU_ID_USUARIO%type default NULL,
     pCAD_LOG_MSG_ERRO IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_MSG_ERRO%type default NULL,
     pCAD_LOG_ORIGEM IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_ORIGEM%type default NULL,
     pCAD_LOG_CLASS IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_CLASS%type default NULL,
     pCAD_LOG_METODO IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_METODO%type default NULL,
     pCAD_LOG_PRD_ID IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_PRD_ID%type default NULL,
     pCAD_PRD_NM_MNEMONICO IN TB_CAD_LOG_ERRO_PROCESSO.CAD_PRD_NM_MNEMONICO%type default NULL
) 
is
/********************************************************************
*    Procedure: PRC_CAD_LOG_ERRO_PROCESSO_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_CAD_LOG_ERRO_PROCESSO
SET	   
        CAD_LOG_DATA_PROCESSO = pCAD_LOG_DATA_PROCESSO,
        CAD_LOG_ATS_ATE = pCAD_LOG_ATS_ATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_LOG_MSG_ERRO = pCAD_LOG_MSG_ERRO,
        CAD_LOG_ORIGEM = pCAD_LOG_ORIGEM,
        CAD_LOG_CLASS = pCAD_LOG_CLASS,
        CAD_LOG_METODO = pCAD_LOG_METODO,
        CAD_LOG_PRD_ID = pCAD_LOG_PRD_ID,
        CAD_PRD_NM_MNEMONICO = pCAD_PRD_NM_MNEMONICO 
WHERE
        CAD_LOG_ATE_ATD = pCAD_LOG_ATE_ATD;	
end PRC_CAD_LOG_ERRO_PROCESSO_U;

