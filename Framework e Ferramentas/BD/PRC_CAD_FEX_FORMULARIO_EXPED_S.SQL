

--PRC_CAD_FEX_FORMULARIO_EXPED_S
create or replace procedure PRC_CAD_FEX_FORMULARIO_EXPED_S 
(
     pCAD_FEX_ID IN TB_CAD_FEX_FORMULARIO_EXPED.CAD_FEX_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_FEX_FORMULARIO_EXPED_S
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
       CAD_FEX_ID,
       CAD_FEX_NOME_FANTASIA,
       CAD_FEX_RAZAO_SOCIAL,
       CAD_FEX_PESSOA_CONTATO,
       CAD_FEX_TELEFONE,
       CAD_FEX_EMAIL,
       CAD_FEX_NUMERO_FORMULARIO,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_FEX_DT_CRIACAO,
       SEG_USU_ID_USUARIO_ATUALIZ,
       CAD_FEX_DT_ULTIMA_ATUALIZ,
       CAD_FEX_DS_OBSERVACAO,
       CAD_FEX_INICIO_VIGENCIA,
       CAD_FEX_FIM_VIGENCIA
FROM TB_CAD_FEX_FORMULARIO_EXPED
WHERE
        CAD_FEX_ID = pCAD_FEX_ID;          
io_cursor := v_cursor;
end PRC_CAD_FEX_FORMULARIO_EXPED_S;
