create or replace procedure PRC_CAD_END_ENDERECO_D
  (
     pCAD_END_ID_ENDERECO IN TB_CAD_END_ENDERECO.CAD_END_ID_ENDERECO%type,
     pCAD_PES_ID_PESSOA IN TB_CAD_END_ENDERECO.CAD_PES_ID_PESSOA%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_END_ENDERECO_D
  *
  *    Data Criacao: 	31/05/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:              Por:
  *
  *    Funcao: Exclui Endereco e Associac?o com a Pessoa
  *
  *******************************************************************/
  begin
    DELETE FROM TB_CAD_END_ENDERECO
    WHERE  CAD_END_ID_ENDERECO = pCAD_END_ID_ENDERECO;
  end PRC_CAD_END_ENDERECO_D;
