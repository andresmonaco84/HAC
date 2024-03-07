
select COUNT(HIS_INT_CD_INTERNACAO) INTERN_ATUALIZ, cast(HIS_INT_DT_SAIDA as date) DATA_ALTA
  from TB_HIS_INT_HIST_INTERNACAO_WEB
 where HIS_INT_DT_SAIDA > GETDATE() - 10
 group by HIS_INT_DT_SAIDA 
 order by HIS_INT_DT_SAIDA desc 
