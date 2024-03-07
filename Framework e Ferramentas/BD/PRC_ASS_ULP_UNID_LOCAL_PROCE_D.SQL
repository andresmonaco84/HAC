create or replace procedure PRC_ASS_ULP_UNID_LOCAL_PROCE_D
 (
	pASS_ULP_ID IN TB_ASS_ULP_UNID_LOCAL_PROCED.ASS_ULP_ID%TYPE
 )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_ULP_UNID_LOCAL_PROCE_D
  *
  *    Data Criacao: 	24/01/2008           Por: Fabiola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Excluir Associação de Unidade x Local x Procedimento
  *
  *    Data Alteracao:  04/07/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao dos atributos dos codigos da tabela,
  *               do grupo e do procedimento
  *
  *    Data Alteracao: 24/09/2008        Por: Fabiola Lopes
  *    Alteracao: Modifiquei para excluir pelo Idt
  *
  *******************************************************************/
  begin
    DELETE TB_ASS_ULP_UNID_LOCAL_PROCED
    WHERE  ASS_ULP_ID = pASS_ULP_ID;

  end PRC_ASS_ULP_UNID_LOCAL_PROCE_D;
/
