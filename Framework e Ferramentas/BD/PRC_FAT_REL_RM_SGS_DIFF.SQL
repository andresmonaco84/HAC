CREATE OR REPLACE PROCEDURE SGS.PRC_FAT_REL_RM_SGS_DIFF(pMES in number, pANO in number, io_cursor OUT PKG_CURSOR.t_cursor)
is
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR   
select * from
/*Somente no RM*/          
(select 'RM' as tipo, 
        to_number(tmov.numeromov) as numeromov, 
        to_number(tmov.codfilial) as codfilial, 
        tmov.valorbruto as valor, 
        to_char(tmov.dataemissao,'MM-yyyy') as mesano,
        decode(upper(gfilial.cidade),'SÃO VICENTE','SAO VICENTE','GUARUJÁ','GUARUJA','CUBATÃO','CUBATAO',upper(gfilial.cidade)) as cidade
from rm.tmov@RMDB
     ,rm.gfilial@RMDB
where  to_char(tmov.dataemissao,'MM') = pMES
   and to_char(tmov.dataemissao,'yyyy') = pANO   
   and tmov.codcoligada = 1
   and status != 'C'
   and (tmov.codtmv like '2.2%'  AND  tmov.codtmv not in ('2.2.03','2.2.09','2.2.10','2.2.11','2.2.14', '2.2.15', '2.2.16', '2.2.04')
   and gfilial.codfilial = tmov.codfilial)
minus
 select 'RM' as tipo, 
        nof.fat_nof_nr_notafiscal as numeromov, 
        to_number(substr(psu.cad_pes_nr_cnpj_cpf, 11, 2)) as codfilial, 
        nof.fat_nfo_vl_faturado,
         lpad(nof.fat_nof_mes_fat,2,'0') || '-' || nof.fat_nof_ano_fat as mesano,
       nof.cad_uni_ds_municipio 
    from tb_fat_nof_nota_fiscal nof 
    join tb_cad_uni_unidade     uni on nof.cad_uni_id_unidade = uni.cad_uni_id_unidade
    join tb_cad_pes_pessoa      psu on uni.cad_pes_id_pessoa = psu.cad_pes_id_pessoa
   where nof.fat_nof_mes_fat = pMES 
         and nof.fat_nof_ano_fat = pANO
         and nof.fat_nof_fl_status = 'A')
union
/*Somente no SGS*/   
(select 'SGS' as tipo, 
        nof.fat_nof_nr_notafiscal as numeromov, 
        to_number(substr(psu.cad_pes_nr_cnpj_cpf, 11, 2)) as codfilial, 
        nof.fat_nfo_vl_faturado,
       lpad(nof.fat_nof_mes_fat,2,'0') || '-' || nof.fat_nof_ano_fat as mesano,
       nof.cad_uni_ds_municipio
    from tb_fat_nof_nota_fiscal nof 
    join tb_cad_uni_unidade     uni on nof.cad_uni_id_unidade = uni.cad_uni_id_unidade
    join tb_cad_pes_pessoa      psu on uni.cad_pes_id_pessoa = psu.cad_pes_id_pessoa
   where nof.fat_nof_mes_fat = pMES 
         and nof.fat_nof_ano_fat = pANO
         and nof.fat_nof_fl_status = 'A'
minus
       select 'SGS' as tipo, 
       to_number(tmov.numeromov) as numeromov, 
       to_number(tmov.codfilial) as codfilial,  
       tmov.valorbruto, 
       to_char(tmov.dataemissao,'MM-yyyy') as mesano,
       decode(upper(gfilial.cidade),'SÃO VICENTE','SAO VICENTE','GUARUJÁ','GUARUJA','CUBATÃO','CUBATAO',upper(gfilial.cidade))
       from rm.tmov@RMDB
			      ,rm.gfilial@RMDB
where  to_char(tmov.dataemissao,'MM') = pMES
   and to_char(tmov.dataemissao,'yyyy') = pANO   
   and tmov.codcoligada = 1
   and status != 'C'
   and (tmov.codtmv like '2.2%'  AND  tmov.codtmv not in ('2.2.03','2.2.09','2.2.10','2.2.11','2.2.14', '2.2.15', '2.2.16', '2.2.04'))
   and gfilial.codfilial = tmov.codfilial)
	 order by 6,2;
   io_cursor := v_cursor;
end prc_fat_rel_rm_sgs_diff;
/
