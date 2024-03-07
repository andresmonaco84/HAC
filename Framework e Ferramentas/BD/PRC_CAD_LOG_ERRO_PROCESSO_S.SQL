

--PRC_CAD_LOG_ERRO_PROCESSO_S
create or replace procedure PRC_CAD_LOG_ERRO_PROCESSO_S 
(
     pCAD_LOG_ATE_ATD IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_ATE_ATD%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_LOG_ERRO_PROCESSO_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       CAD_LOG_DATA_PROCESSO,
       CAD_LOG_ATE_ATD,
       CAD_LOG_ATS_ATE,
       SEG_USU_ID_USUARIO,
       CAD_LOG_MSG_ERRO,
       CAD_LOG_ORIGEM,
       CAD_LOG_CLASS,
       CAD_LOG_METODO,
       CAD_LOG_PRD_ID,
       CAD_PRD_NM_MNEMONICO
FROM TB_CAD_LOG_ERRO_PROCESSO
WHERE
        CAD_LOG_ATE_ATD = pCAD_LOG_ATE_ATD;          
io_cursor := v_cursor;
end PRC_CAD_LOG_ERRO_PROCESSO_S;
