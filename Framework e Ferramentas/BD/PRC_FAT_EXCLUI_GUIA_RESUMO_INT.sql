create or replace procedure PRC_FAT_EXCLUI_GUIA_RESUMO_INT
  (
    pn_atendimento int,
    pn_parcela int,
    pn_mesfat int,
    pn_anofat int,
    pn_paciente int,
    pn_conta int
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_EXCLUI_GUIA_RESUMO_INT
  *
  *    Data Alteracao: 09/08/2010  Por: Pedro
  *    Alteração:
  *
  *******************************************************************/
  begin
  pkg_tiss.EXCLUI_GUIA_RESUMO_INTERNACAO( pn_atendimento, pn_parcela, pn_mesfat , pn_anofat, pn_paciente ,
                           pn_conta   )
  ;

  end PRC_FAT_EXCLUI_GUIA_RESUMO_INT;
/
