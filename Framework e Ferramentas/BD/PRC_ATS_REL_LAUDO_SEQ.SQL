create or replace procedure PRC_ATS_REL_LAUDO_SEQ
  (
     pNewIdt OUT INTEGER
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_REL_LAUDO_SEQ
  *
  *    Data Criacao:    21/02/09           Por: Fabíola
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Retorna uma sequence para tratar o retorno de uma tabela temporário
  *		   (garantir os dados do usuário no momento da execucao)
  *******************************************************************/
  lIdtRetorno integer;

  BEGIN

    SELECT SEQ_ATS_REL_LAUDO_01.NextVal INTO lIdtRetorno FROM DUAL;

    pNewIdt := lIdtRetorno;

  end PRC_ATS_REL_LAUDO_SEQ;