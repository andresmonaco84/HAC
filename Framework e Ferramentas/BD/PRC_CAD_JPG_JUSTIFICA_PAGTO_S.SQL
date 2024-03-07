--PRC_CAD_JPG_JUSTIFICA_PAGTO_S
create or replace procedure PRC_CAD_JPG_JUSTIFICA_PAGTO_S 
(
     pID_CAD_JPG IN TB_CAD_JPG_JUSTIFICA_PAGTO.ID_CAD_JPG%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_JPG_JUSTIFICA_PAGTO_S
* 
*    Data Criacao: 	  28/02/2012         Por: Fabíola Lopes
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Lista as Justificativas de Pagamento
*
*******************************************************************/  
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       ID_CAD_JPG,
       CAD_JPG_DS_JUSTIFICATIVA,
       SEG_USU_ID_USUARIO,
       CAD_JPG_DT_ULTIMA_ATUALIZACAO
FROM TB_CAD_JPG_JUSTIFICA_PAGTO
WHERE
        ID_CAD_JPG = pID_CAD_JPG;          
io_cursor := v_cursor;
end PRC_CAD_JPG_JUSTIFICA_PAGTO_S;