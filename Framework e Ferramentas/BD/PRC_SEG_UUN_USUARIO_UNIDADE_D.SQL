  create or replace procedure PRC_SEG_UUN_USUARIO_UNIDADE_D 
  (
     pCAD_UNI_ID_UNIDADE IN TB_SEG_UUN_USUARIO_UNIDADE.CAD_UNI_ID_UNIDADE%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_UUN_USUARIO_UNIDADE_D
  *
  *    Data Criacao: 	22/02/2007   Por: Carlos Araujo
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: Exclui todos os usuários associados à uma Unidade
  *
  *******************************************************************/ 
  begin
    DELETE TB_SEG_UUN_USUARIO_UNIDADE
    WHERE  
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;
  end PRC_SEG_UUN_USUARIO_UNIDADE_D;
/
