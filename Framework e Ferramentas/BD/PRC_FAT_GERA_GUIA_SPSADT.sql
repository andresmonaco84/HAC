CREATE OR REPLACE PROCEDURE "PRC_FAT_GERA_GUIA_SPSADT"
  (
    pn_atendimento int,
    pn_parcela int,
    pn_mesfat int,
    pn_anofat int,
    pn_paciente int,
    pn_conta int,
    ps_codloc varchar2,
    pn_usuario int,
    pn_lote int,
    pnRetorno out int,
    pn_convenio int,
    psVersaoAtualTISS varchar2
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_GERA_GUIA_SPSADT
  *
  *    Data Alteracao: 09/08/2010  Por: Pedro
  *    Alterac?o:
  *
  *******************************************************************/
  begin
    if(psVersaoAtualTISS = 'S') then
      tiss.pkg_tiss_SGS_v3.GERA_GUIA_SPSADT_v3( pn_atendimento, pn_parcela, pn_mesfat , pn_anofat, pn_paciente , pn_conta , ps_codloc ,pn_lote, pn_usuario, pnRetorno );
    ELSE 
      pkg_tiss_SGS.GERA_GUIA_SPSADT_SGS( pn_atendimento, pn_parcela, pn_mesfat , pn_anofat, pn_paciente , pn_conta , ps_codloc ,pn_lote, pn_usuario, pnRetorno );
end if;
  end PRC_FAT_GERA_GUIA_SPSADT;
 