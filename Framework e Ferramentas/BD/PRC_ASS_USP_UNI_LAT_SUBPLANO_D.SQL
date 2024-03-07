create or replace procedure PRC_ASS_USP_UNI_LAT_SUBPLANO_D
  (
     pASS_USP_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_USP_UNI_LAT_SUBPLANO_D
  *
  *    Data Criacao:   17/07/2008        Por: Fabiola Lopes
  *    Data Alteracao:  data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Exclui as Associagues de Unidade x Local e Sub-Plano cadastradas
  *
  *******************************************************************/
  begin
    DELETE TB_ASS_USP_UNI_LAT_SUB_PLANO
    WHERE
        ASS_USP_ID = pASS_USP_ID;
  end PRC_ASS_USP_UNI_LAT_SUBPLANO_D;
/
