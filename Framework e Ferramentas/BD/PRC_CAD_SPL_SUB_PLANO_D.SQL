create or replace procedure PRC_CAD_SPL_SUB_PLANO_D
  (
     pCAD_SPL_ID IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SPL_SUB_PLANO_D
  *
  *    Data Criacao: 	04/07/2008			Por: Fabmola Lopes
  *    Data Alteracao:	data da alteragco	Por: Nome do Analista
  *
  *    Funcao: Exclui os Sub-Planos cadastrados
  *
  *******************************************************************/
  begin
    DELETE TB_CAD_SPL_SUB_PLANO
    WHERE
        CAD_SPL_ID = pCAD_SPL_ID;
  end PRC_CAD_SPL_SUB_PLANO_D;
/
