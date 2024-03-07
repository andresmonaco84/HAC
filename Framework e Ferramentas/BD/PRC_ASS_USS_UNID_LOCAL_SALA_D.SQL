create or replace procedure PRC_ASS_USS_UNID_LOCAL_SALA_D
  (
       pASS_USS_ID IN TB_ASS_USS_UNID_LOC_SET_SALA.ASS_USS_ID%TYPE
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_USS_UNID_LOCAL_SALA_D
  *
  *    Data Criacao: 	15/01/2008           Por: Davi S. M. dos Reis
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Excluir Associacao de Unidade x Local x Setor x Sala
  *
  *    Data Alteracao: 25/08/2008          Por: Fabiola  R. Lopes
  *    Alteracao: ref. task 3471 - A tela deixou de ser listbox
  *
  *******************************************************************/
  begin
    DELETE TB_ASS_USS_UNID_LOC_SET_SALA
    WHERE
        ASS_USS_ID  = pASS_USS_ID;
  end PRC_ASS_USS_UNID_LOCAL_SALA_D;