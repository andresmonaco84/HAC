--PRC_CAD_CTX_COMPOSICAO_TAXA_SID
  create or replace procedure PRC_CAD_CTX_COMPOSICAO_TX_SID 
  (
     pCAD_CTX_ID IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_CTX_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CTX_COMPOSICAO_TAXA_S
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
       CAD_CTX_ID,
       CAD_PRD_ID_TX,
       CAD_PRD_ID,
       CAD_CTX_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_CTX_FL_STATUS
FROM TB_CAD_CTX_COMPOSICAO_TAXA
WHERE
        CAD_CTX_ID = pCAD_CTX_ID;          
io_cursor := v_cursor;
  end PRC_CAD_CTX_COMPOSICAO_TX_SID;

