CREATE OR REPLACE PROCEDURE "PRC_COB_REL_09_CNV_CARTEIRA"
(

     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/*****************************************************************************
*    Procedure: PRC_COB_REL_09_CNV_CARTEIRA
*
*    Data Criacao:   29/10/2012    Por: PEDRO
*    Data Alteracao:
*
*    Funcao: Lista CONVENIO CARTEIRA SGS
*******************************************************************************/
v_cursor PKG_CURSOR.t_cursor;

begin
  OPEN v_cursor FOR

SELECT    CNV.CAD_CNV_ID_CONVENIO,
          CNV.CAD_CNV_CD_HAC_PRESTADOR,
          CNV.CAD_CNV_DS_RAZAOSOCIAL,
          CNV.CAD_CNV_FL_STATUS,
          PES.CAD_PES_NR_CNPJ_CPF

FROM      TB_CAD_CNV_CONVENIO        CNV
JOIN      TB_CAD_PES_PESSOA          PES  ON  PES.CAD_PES_ID_PESSOA  =  CNV.CAD_PES_ID_PESSOA

WHERE     CNV.CAD_CNV_CD_OPCAO_PAGTO = '1' ;

     io_cursor := v_cursor;
end PRC_COB_REL_09_CNV_CARTEIRA;
