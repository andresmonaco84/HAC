CREATE OR REPLACE PROCEDURE "PRC_FAT_EXCLUI_TISS"
  (
    pn_atendimento int,
    pn_parcela int,
    pn_mesfat int,
    pn_anofat int,
    pn_paciente int,
    pn_conta int,
     pn_convenio int,
    psVersaoAtualTISS varchar2
  )
  is
begin    
tiss.pkg_tiss_SGS.EXCLUI_GUIA_SP_SADT_SGS(pn_ATENDIMENTO, pn_parcela, pn_MESFAT, pn_ANOFAT, pn_paciente, pn_conta);
tiss.pkg_tiss_sgs.EXCLUI_GUIA_RESUMO_INTERNA_SGS(pn_ATENDIMENTO, pn_parcela, pn_MESFAT, pn_ANOFAT, pn_paciente, pn_conta);


tiss.pkg_tiss_SGS_v3.EXCLUI_GUIA_SP_SADT_v3(pn_ATENDIMENTO, pn_parcela, pn_MESFAT, pn_ANOFAT, pn_paciente, pn_conta);
tiss.pkg_tiss_sgs_v3.EXCLUI_GUIA_RESUMO_INTERNA_v3(pn_ATENDIMENTO, pn_parcela, pn_MESFAT, pn_ANOFAT, pn_paciente, pn_conta);



end PRC_FAT_EXCLUI_TISS;
 