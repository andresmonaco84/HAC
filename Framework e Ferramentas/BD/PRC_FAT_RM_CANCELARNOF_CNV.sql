CREATE OR REPLACE PROCEDURE "PRC_FAT_RM_CANCELARNOF_CNV"
(pFAT_NOF_ID in number,
 pSEG_USU_ID_USUARIO in number) is

v_codunihos number;
v_numfat  number;
v_serie    varchar2(10);
v_codcon   varchar2(4);
begin
  /* Cancelar movimentos com NOF */
  /* Marcus Relva 31/05/2012 */

  update tb_fat_ccp_conta_cons_parc ccp
       set ccp.fat_nof_id = null
     where ccp.fat_nof_id = pFAT_NOF_ID;

    update tb_fat_afr_atend_fatur_res afr
       set afr.fat_nof_id = null
     where afr.fat_nof_id = pFAT_NOF_ID;

    update tb_fat_nof_nota_fiscal nof
    set nof.fat_nof_fl_status = 'C', nof.seg_usu_id_usuario_cancela = pSEG_USU_ID_USUARIO, nof.fat_nof_dt_cancelamento = sysdate
     where nof.fat_nof_id = pFAT_NOF_ID;

begin

    select codunihos, numfat, serie, codcon
  into   v_codunihos, v_numfat, v_serie, v_codcon
  from tb_fatura1  f
  where f.fat_nof_id = pFAT_NOF_ID;

    delete tb_fatura_psac psac
  where psac.codunihos = v_codunihos
  and   psac.numfat    = v_numfat
  and   psac.serie     = v_serie;

    delete tb_fatura_sp sp
  where sp.codunihos = v_codunihos
  and   sp.numfat    = v_numfat
  and   sp.serie     = v_serie;

  /* cobranca-legado */
	/*
  delete cbr_fatura_guia g
  where g.codunihos = v_codunihos
  and   g.serie     = v_serie
  and   g.numfat    = v_numfat
  and   g.codcon    = v_codcon;

  delete cbr_hist_envio_retorno h
  where h.codunihos = v_codunihos
  and   h.serie     = v_serie
  and   h.numfat    = v_numfat
  and   h.codcon    = v_codcon;

  delete cbr_envio_retorno r
  where r.codunihos = v_codunihos
  and   r.serie     = v_serie
  and   r.numfat    = v_numfat
  and   r.codcon    = v_codcon;
	*/

  delete tb_fatura1 f
  where  f.fat_nof_id = pFAT_NOF_ID;

exception when others then
  -- tenta excluir do legado
  v_numfat := null;
end;

begin
  delete tb_cob_ccp_conta_cons_parc cob
 where cob.fat_nof_id = pFAT_NOF_ID;
exception when others then
    raise_application_error(-20002,'ERRO AO GRAVAR INFORMACOES DE COBRANCA');
end;

end PRC_FAT_RM_CANCELARNOF_CNV;
 