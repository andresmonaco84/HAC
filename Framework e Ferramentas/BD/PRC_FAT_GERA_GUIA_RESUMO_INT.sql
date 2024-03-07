CREATE OR REPLACE PROCEDURE "PRC_FAT_GERA_GUIA_RESUMO_INT" (
    pn_atendimento int,
    pn_parcela int,
    pn_mesfat int,
    pn_anofat int,
    pn_paciente int,
    pn_conta int,
    pn_usuario int,
    pn_lote int,
    pnRetorno out int,
    pn_convenio int,
    psVersaoAtualTISS varchar2
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_GERA_GUIA_RESUMO_INT
  *
  *    Data Alteracao: 09/08/2010  Por: Pedro
  *    Alterac?o:
  *
  *******************************************************************/
   begin
    if(psVersaoAtualTISS = 'S') then
       tiss.pkg_tiss_SGS_v3.GERA_GUIA_RESUMO_INTERNA_V3( pn_atendimento, pn_parcela, pn_mesfat , pn_anofat, pn_paciente , pn_conta ,pn_lote, pn_usuario, pnRetorno  );
    ELSE 
       pkg_tiss_SGS.GERA_GUIA_RESUMO_INTERNA_SGS( pn_atendimento, pn_parcela, pn_mesfat , pn_anofat, pn_paciente , pn_conta ,pn_lote, pn_usuario, pnRetorno  );
    end if;


  end PRC_FAT_GERA_GUIA_RESUMO_INT;
 