create or replace procedure PRC_AUX_RMN_RESTRICAO_MUNIC_D
  (
     pAUX_RMN_SG_UF IN TB_AUX_RMN_RESTRICAO_MUNICIPIO.AUX_RMN_SG_UF%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_RMN_RESTRICAO_MUNIC_D
  *
  *    Data Criacao: 	31/07/2007         Por: Fabiola R. Lopes
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: Excluir os MunicÃ­pios restritos
  *
  *******************************************************************/
  begin
    DELETE  TB_AUX_RMN_RESTRICAO_MUNICIPIO
    WHERE   AUX_RMN_SG_UF   = pAUX_RMN_SG_UF;
  end PRC_AUX_RMN_RESTRICAO_MUNIC_D;