CREATE OR REPLACE PROCEDURE PRC_FAT_LISTA_COMANDA_PRODUTO
       (
       pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE,
       pCAD_PRD_CD_CODIGO IN TB_CAD_PRD_PRODUTO.CAD_PRD_CD_CODIGO %TYPE,
       io_cursor OUT PKG_CURSOR.t_cursor
       )
       is
         /********************************************************************
  *    Procedure:   PRC_FAT_LISTA_COMANDA_PRODUTO
  *    Data da Crianção: 15/03/2011  Por: Eduardo Hyppolito
  *    Função: Listar tipo de comandas por produto e convênio
  **************************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR

SELECT        TCO.FAT_TCO_DS_COMANDA,
              PRD.CAD_PRD_DS_DESCRICAO

FROM          TB_FAT_TCP_TP_COMANDA_PROD TCP

JOIN          TB_FAT_TCO_TIPO_COMANDA TCO
ON            TCO.FAT_TCO_ID = TCP.FAT_TCO_ID

JOIN          TB_CAD_PRD_PRODUTO PRD
ON            PRD.CAD_PRD_ID = TCP.CAD_PRD_ID


JOIN          TB_ASS_CTU_CNV_TAB_UTILIZA CTU
ON            CTU.CAD_TAP_TP_ATRIBUTO = PRD.CAD_TAP_TP_ATRIBUTO
AND           CTU.TIS_MED_CD_TABELAMEDICA = PRD.TIS_MED_CD_TABELAMEDICA

WHERE         CTU.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
AND           PRD.CAD_PRD_CD_CODIGO =  pCAD_PRD_CD_CODIGO
 ;
io_cursor := v_cursor;
end PRC_FAT_LISTA_COMANDA_PRODUTO;