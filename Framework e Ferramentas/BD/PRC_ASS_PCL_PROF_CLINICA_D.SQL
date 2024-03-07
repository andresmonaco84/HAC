create or replace procedure PRC_ASS_PCL_PROF_CLINICA_D
  (
     pASS_PCL_ID IN TB_ASS_PCL_PROF_CLINICA.ASS_PCL_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PCL_PROF_CLINICA_D
  *
  *    Data Criacao:   22/09/2008   Por: Pedro H. A. de Carvalho
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Deleta associação Prof x Clinica
  *
  *******************************************************************/
  begin
    DELETE TB_ASS_PCL_PROF_CLINICA
    WHERE
        ASS_PCL_ID = pASS_PCL_ID;
  end PRC_ASS_PCL_PROF_CLINICA_D;
/
