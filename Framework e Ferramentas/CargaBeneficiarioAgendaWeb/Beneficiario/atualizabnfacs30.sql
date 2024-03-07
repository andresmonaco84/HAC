SET PAGESIZE 50000
SET LINESIZE 500
SET HEADING OFF
SET FEEDBACK OFF

SPOOL F:\AgendaWeb\Beneficiario\ATUALIZADADOSBNFACS.SQL

select  'TRUNCATE TABLE TB_CAD_BAW_BENEF_ACS_WEB_BK 
           GO
          BEGIN TRY
          BEGIN TRANSACTION' from dual
/

       
SELECT DISTINCT * FROM 
(           
select 'insert into webagenda.tb_cad_baw_benef_acs_web_bk '|| 
'('
||'cad_baw_cd_convenio_bk'|| ','
||'cad_baw_cd_plano_bk'||','
||'cad_baw_cd_estab_bk'||','
||'cad_baw_cd_credencial_bk'||','
||'cad_baw_cd_credencial_seq_bk' ||','
||'cad_baw_nm_beneficiario_bk'||','
||'cad_baw_dt_nascimento_bk'||','
||'cad_baw_tp_sexo_bk'||','
||'cad_baw_fl_situacao_bk'||','
||'cad_baw_ds_plano_bk'||','
||'cad_baw_dt_ultima_atualizacao_bk'||','
||'cad_baw_dt_carencia_fim_bk'
||' ) ' || ' values ',
'('|| CHR(39) || ('SD01')||CHR(39)||','|| CHR(39)||bnf.codcon|| CHR(39)||','||bnf.codest||','||bnf.codben||','
 ||bnf.codseqben||','
 || CHR(39)||replace(bnf.nomben,CHR(39),'')|| CHR(39)||
 ','|| CHR(39)||to_char(bnf.datnasben,'yyyy-dd-mm')|| CHR(39)
 ||','|| CHR(39)||bnf.sexben||CHR(39)||','
 || CHR(39)||bnf.Sitati||CHR(39)||','
 ||CHR(39)||replace(e.nomemp,CHR(39),'')|| CHR(39)||','|| 
 decode( bnf.datsaiconben,null,CHR(39)||to_char(bnf.datingconben,'yyyy-dd-mm')|| CHR(39),CHR(39)||to_char(bnf.datsaiconben,'yyyy-dd-mm')||CHR(39))||','|| 
 case when (bcb.CODSER = 4 and bcb.DATFIMCAR > TRUNC(SYSDATE - 1)) then CHR(39)|| to_char(bcb.DATFIMCAR,'yyyy-dd-mm')||CHR(39) ELSE 'null' END 
||' );'
   from convenio_cobertura cc,
   cobertura_atendimento ca,
   empresa e,
   bnf_beneficiario bnf  ,
   BNF_CARENCIA_BENEFICIARIO  bcb
      where cc.codcobate = ca.codcobate
     and ca.id_identificacao = 1
     and cc.codcon = e.codcon    
     AND DESCOBCART LIKE '%CONS%'	
     AND CC.CODPAD=BNF.CODPADATEBEN     
     and bnf.codcon=cc.codcon            
     and trunc(bnf.datingconben) >= trunc(sysdate -1)
     and bcb.codcon (+) = bnf.codcon
     and bcb.codben (+)  = bnf.codben
     and bcb.codest (+)  = bnf.codest
     and bcb.codseqben (+)  = bnf.codseqben  
     AND bcb.CODSER (+) = 4
union all
select 'insert into webagenda.tb_cad_baw_benef_acs_web_bk '|| 
'('
||'cad_baw_cd_convenio_bk'|| ','
||'cad_baw_cd_plano_bk'||','
||'cad_baw_cd_estab_bk'||','
||'cad_baw_cd_credencial_bk'||','
||'cad_baw_cd_credencial_seq_bk' ||','
||'cad_baw_nm_beneficiario_bk'||','
||'cad_baw_dt_nascimento_bk'||','
||'cad_baw_tp_sexo_bk'||','
||'cad_baw_fl_situacao_bk'||','
||'cad_baw_ds_plano_bk'||','
||'cad_baw_dt_ultima_atualizacao_bk'||','
||'cad_baw_dt_carencia_fim_bk'
||' ) ' || ' values ',
'('|| CHR(39) || ('SD01')||CHR(39)||','|| CHR(39)||bnf.codcon|| CHR(39)||','||bnf.codest||','||bnf.codben||','
 ||bnf.codseqben||','
 || CHR(39)||replace(bnf.nomben,CHR(39),'')|| CHR(39)||
 ','|| CHR(39)||to_char(bnf.datnasben,'yyyy-dd-mm')|| CHR(39)
 ||','|| CHR(39)||bnf.sexben||CHR(39)||','
 || CHR(39)||bnf.Sitati||CHR(39)||','
 ||CHR(39)||replace(e.nomemp,CHR(39),'')|| CHR(39)||','||  
 decode( bnf.datsaiconben,null,CHR(39)||to_char(bnf.datingconben,'yyyy-dd-mm')|| CHR(39),CHR(39)||to_char(bnf.datsaiconben,'yyyy-dd-mm')||CHR(39))||','|| 
 case when (bcb.CODSER = 4 and bcb.DATFIMCAR > TRUNC(SYSDATE - 1)) then CHR(39)|| to_char(bcb.DATFIMCAR,'yyyy-dd-mm')||CHR(39) ELSE 'null' END 
||' );'
   from convenio_cobertura cc,
   cobertura_atendimento ca,
   empresa e,
   bnf_beneficiario bnf,
   BNF_CARENCIA_BENEFICIARIO  bcb
     where cc.codcobate = ca.codcobate
     and ca.id_identificacao = 1
     and cc.codcon = e.codcon    
     AND DESCOBCART LIKE '%CONS%'	
     AND CC.CODPAD=BNF.CODPADATEBEN       
     and bnf.codcon=cc.codcon        
     and trunc(bnf.datsaiconben) >= trunc(sysdate -1)
     and bcb.codcon (+) = bnf.codcon
     and bcb.codben (+)  = bnf.codben
     and bcb.codest (+)  = bnf.codest
     and bcb.codseqben (+)  = bnf.codseqben    
     AND bcb.CODSER (+) = 4
UNION ALL
select 'insert into webagenda.tb_cad_baw_benef_acs_web_bk '|| 
'('
||'cad_baw_cd_convenio_bk'|| ','
||'cad_baw_cd_plano_bk'||','
||'cad_baw_cd_estab_bk'||','
||'cad_baw_cd_credencial_bk'||','
||'cad_baw_cd_credencial_seq_bk' ||','
||'cad_baw_nm_beneficiario_bk'||','
||'cad_baw_dt_nascimento_bk'||','
||'cad_baw_tp_sexo_bk'||','
||'cad_baw_fl_situacao_bk'||','
||'cad_baw_ds_plano_bk'||','
||'cad_baw_dt_ultima_atualizacao_bk'||','
||'cad_baw_dt_carencia_fim_bk'
||' ) ' || ' values ',
'('|| CHR(39) || ('SD01')||CHR(39)||','|| CHR(39)||bnf.codcon|| CHR(39)||','||bnf.codest||','||bnf.codben||','
 ||bnf.codseqben||','
 || CHR(39)||replace(bnf.nomben,CHR(39),'')|| CHR(39)||
 ','|| CHR(39)||to_char(bnf.datnasben,'yyyy-dd-mm')|| CHR(39)
 ||','|| CHR(39)||bnf.sexben||CHR(39)||','
 || CHR(39)||bnf.Sitati||CHR(39)||','
 ||CHR(39)||replace(e.nomemp,CHR(39),'')|| CHR(39)||','|| 
 decode( bnf.DATALTBEN,null,CHR(39)||to_char(bnf.DATALTBEN,'yyyy-dd-mm')|| CHR(39),CHR(39)||to_char(bnf.DATALTBEN,'yyyy-dd-mm')||CHR(39))||','|| 
 case when (bcb.CODSER = 4 and bcb.DATFIMCAR > TRUNC(SYSDATE - 1)) then CHR(39)|| to_char(bcb.DATFIMCAR,'yyyy-dd-mm')||CHR(39) ELSE 'null' END 
||' );'
   from convenio_cobertura cc,
   cobertura_atendimento ca,
   empresa e,
   bnf_beneficiario bnf,
   BNF_CARENCIA_BENEFICIARIO  bcb
     where cc.codcobate = ca.codcobate
     and ca.id_identificacao = 1
     and cc.codcon = e.codcon    
     AND DESCOBCART LIKE '%CONS%'  
     AND CC.CODPAD=BNF.CODPADATEBEN       
     and bnf.codcon=cc.codcon         
     AND TRUNC(BNF.DATMOVHAC) >= trunc(sysdate -1) 
     AND TRUNC (bnf.datingconben) <= trunc(sysdate -1) 
     and bcb.codcon (+) = bnf.codcon
     and bcb.codben (+)  = bnf.codben
     and bcb.codest (+)  = bnf.codest
     and bcb.codseqben (+)  = bnf.codseqben  
     AND bcb.CODSER (+) = 4
)
/

select 'COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION' from dual
	
/
select 'PRINT '|| CHR(39)||'ERRO'||CHR(39)|| ' + ERROR_MESSAGE()' from dual
/

select 	'END CATCH                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
GO
EXEC PRC_MANUTENCAO_BENEF' from dual
/

SPOOL OFF
EXIT

