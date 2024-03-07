--PRC_CAD_TPE_TIPOEMPRESA_S
create or replace procedure PRC_CAD_TPE_TIPOEMPRESA_S 
(
     pCAD_TPE_CD_CODIGO IN TB_CAD_TPE_TIPOEMPRESA.CAD_TPE_CD_CODIGO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_TPE_TIPOEMPRESA_S
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
       CAD_TPE_CD_CODIGO,
       CAD_TPE_DS_DESCRICAO,
       CAD_TPE_FL_STATUS,
       CAD_TPE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_TPE_TIPOEMPRESA
WHERE
        CAD_TPE_CD_CODIGO = pCAD_TPE_CD_CODIGO;          
io_cursor := v_cursor;
end PRC_CAD_TPE_TIPOEMPRESA_S;