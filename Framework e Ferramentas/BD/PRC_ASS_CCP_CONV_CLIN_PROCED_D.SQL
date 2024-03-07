create or replace procedure PRC_ASS_CCP_CONV_CLIN_PROCED_D
  (
 
   pASS_CCP_ID IN TB_ASS_CCP_CONV_CLINICA_PROCED.ASS_CCP_ID%TYPE
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CCP_CONV_CLIN_PROCED_D
  *
  *    Data Criacao:  25/01/2008   Por: Fabiola Lopes
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Data Alteracao: 22/07/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do novo atributo AUX_GPC_CD_GRUPOPROCED
  *
  *    Data Alteracao:  04/02/2009  Por Andrea Cazuca
  *    Alteracao:  Incluido o campo TIS_MED_CD_TABELAMEDICA
  *
  *    Data Alteracao:  22/05/2009  Por Pedro
  *    Alteracao:  refeita
  *
  *    Funcao: Exclusão das associacoes de convenio x clinca x procedimento
  *
  *******************************************************************/
  begin
    DELETE TB_ASS_CCP_CONV_CLINICA_PROCED
    WHERE
       ASS_CCP_ID = pASS_CCP_ID;
   
  end PRC_ASS_CCP_CONV_CLIN_PROCED_D;
/
