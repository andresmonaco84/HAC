create or replace procedure PRC_CAD_TEL_TELEFONE_D
  (
     pCAD_TEL_ID_TELEFONE IN TB_CAD_TEL_TELEFONE.CAD_TEL_ID_TELEFONE%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TEL_TELEFONE_D
  *
  *    Data Criacao: 	29/05/2007  Por: Silmara
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui telefone cadastrado
  *
  *******************************************************************/
  begin
    DELETE TB_CAD_TEL_TELEFONE
    WHERE  CAD_TEL_ID_TELEFONE = pCAD_TEL_ID_TELEFONE;
  end PRC_CAD_TEL_TELEFONE_D;
