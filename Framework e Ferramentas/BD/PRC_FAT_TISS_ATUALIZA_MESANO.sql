CREATE OR REPLACE PROCEDURE "PRC_FAT_TISS_ATUALIZA_MESANO" (
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
  /* Marcus Relva - 16/05/2011 */
  begin
    
  tiss.pkg_tiss_sgs.atualiza_mes_ano_sgs(pn_atendimento, pn_parcela,  pn_paciente, pn_conta, pn_mesfat,  pn_anofat); 
  
  tiss.pkg_tiss_sgs_v3.atualiza_mes_ano_sgs_v3(pn_atendimento, pn_parcela,  pn_paciente, pn_conta, pn_mesfat,  pn_anofat);
  
end PRC_FAT_TISS_ATUALIZA_MESANO;
 