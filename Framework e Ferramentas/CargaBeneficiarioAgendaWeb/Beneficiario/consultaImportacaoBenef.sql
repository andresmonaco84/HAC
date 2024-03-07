
select COUNT(CAD_BAW_NM_BENEFICIARIO) BENEF_ATUALIZ, cast(CAD_BAW_DT_ULTIMA_ATUALIZACAO as date) DATA
  from tb_cad_baw_benef_acs_web
 where (CAD_BAW_DT_ULTIMA_ATUALIZACAO > GETDATE() - 10 or CAD_BAW_DT_ULTIMA_ATUALIZACAO is null)
 group by cast(CAD_BAW_DT_ULTIMA_ATUALIZACAO as date)
 order by cast(CAD_BAW_DT_ULTIMA_ATUALIZACAO as date) desc