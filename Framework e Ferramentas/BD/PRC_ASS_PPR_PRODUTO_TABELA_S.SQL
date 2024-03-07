create or replace procedure PRC_ASS_PPR_PRODUTO_TABELA_S
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PPR_PLANOPRODUTO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO    IN TB_ASS_PPR_PLANOPRODUTO.CAD_PLA_ID_PLANO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is

  /********************************************************************
  *    Procedure: PRC_ASS_PPR_PRODUTO_TABELA_S
  *
  *    Data Criacao:   18/06/2008           Por: Andrea Cazuca
  *    Data Alteracao: data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Lista as tabelas relacionadas ao Plano Produto
  *
  ********************************************************************/

  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
         SELECT DISTINCT MED.TIS_MED_DS_TABELAMEDICA DESCRICAO,
                PPR.TIS_MED_CD_TABELAMEDICA CODIGO
         FROM   TB_ASS_PPR_PLANOPRODUTO PPR,
                TB_TIS_MED_TABELAMEDICA MED
         WHERE  PPR.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
         AND    PPR.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
         AND    PPR.TIS_MED_CD_TABELAMEDICA != 16
         AND    PPR.TIS_MED_CD_TABELAMEDICA = MED.TIS_MED_CD_TABELAMEDICA;

    io_cursor := v_cursor;
  end PRC_ASS_PPR_PRODUTO_TABELA_S;
/
