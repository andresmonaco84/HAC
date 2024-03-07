declare 
mtmd_id    NUMBER;
begin

for x in (
          select /*tmov.idmov, tmov.numeromov, tmov.codtmv, tmov.serie, 
                 m.cad_mtmd_id, tprd.nomefantasia, tmov.horultimaalteracao,
                 tt.nseqitmmov, tt.quantidade, tt.precounitario*/       
                 tt.codfilial, tmov.idmov, tmov.numeromov, tmov.codtmv, tmov.serie, 
                 m.cad_mtmd_id, tt.nseqitmmov, tt.quantidade qtde_rm, tt.quantidade*TUND.FATORCONVERSAO qtde_sgs,  
                 tt.valorfinanceiro, tt.precounitario precounitario_rm, 
                 tt.valorfinanceiro / (tt.quantidade*TUND.FATORCONVERSAO) precounitario_sgs, tt.codund, FCFO.NOMEFANTASIA, tmov.datamovimento
          from tmov@rm tmov, TITMMOV@rm tt, tprd@rm, tb_cad_mtmd_mat_med m, TUND@rm, FCFO@rm
          where tt.idprd = tprd.idprd and
          tt.idmov = tmov.idmov and
          m.cad_mtmd_cd_rm = tprd.idprd and
          TUND.CODUND = tt.codund and
          FCFO.CODCOLIGADA = 1 and FCFO.CODCFO = tmov.CODCFO and
          horultimaalteracao >= to_date('09052011 1530','DDMMYYYY HH24MI') and 
          horultimaalteracao <= to_date('10052011 0853','DDMMYYYY HH24MI') and 
          codtmv like '1.2.%'
          and tmov.codcoligada = 1
          and tmov.tipo = 'P'
          and nvl(tt.valorfinanceiro,0) > 0
          --and m.cad_mtmd_id = 38093
          order by tmov.horultimaalteracao
          ) 
          LOOP
          
            BEGIN
            
                 select h.cad_mtmd_id into mtmd_id from tb_mtmd_historico_nota_fiscal h
                 where h.cad_mtmd_id = x.cad_mtmd_id and h.idmov = x.idmov and h.mtmd_nr_nota = x.numeromov;
            
                 dbms_output.put_line('NAO INSERIU');
            EXCEPTION WHEN NO_DATA_FOUND THEN
            
                 if (x.codfilial = 51) THEN
                    x.codfilial := 2;
                 else
                    x.codfilial := 1;
                 end if;
                 
                 SGS.PRC_MTMD_MOV_ESTOQUE_ENTRADA ( x.cad_mtmd_id,
                                                     null,
                                                     x.codfilial,
                                                     244,
                                                     33,
                                                     29,
                                                     x.qtde_sgs,
                                                     x.precounitario_sgs,
                                                     1,
                                                     1,
                                                     x.numeromov,
                                                     x.datamovimento,
                                                     x.idmov,
                                                     1,
                                                     x.nseqitmmov,
                                                     x.codtmv,
                                                     x.nomefantasia,
                                                     x.codund,
                                                     x.serie,
                                                     x.qtde_rm
                                                   );
            
                 dbms_output.put_line('INSERIU: CAD_MTMD_ID= ' || X.CAD_MTMD_ID || ' IDMOV=' || X.IDMOV);
            END;
          
          
          END LOOP;
END;


 