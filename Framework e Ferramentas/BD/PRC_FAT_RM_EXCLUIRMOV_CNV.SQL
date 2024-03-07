CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_RM_EXCLUIRMOV_CNV" (pNUMEROMOV       in varchar2,
                             pCODFILIAL       in number,
                             pSERIE           in varchar2) is
v_idmov number;
v_statuslan number;
v_statusexport number(5);
v_idlan number;
begin
  /* Excluir movimentos do RM */
  /* Marcus Relva 06/01/2012 */
  begin
    select m.idmov, l.statuslan, m.statusexportcont
    into v_idmov, v_statuslan, v_statusexport
    from rm.tmov@RMDB
    m,
    rm.flan@RMDB
    l
    where m.codcoligada = l.codcoligada
    and m.idmov = l.idmov
    and m.codcoligada = 1
    and m.codfilial = pCODFILIAL
    and m.numeromov = pNUMEROMOV
	and m.dataemissao >= to_date('01/05/2014','dd/MM/yyyy');
--    and m.dataemissao >= to_date('01/05/2012','dd/MM/yyyy');
  exception when others then
    raise_application_error(-20000,'NENHUM MOVIMENTO ENCONTRADO OU MAIS DE UM MOVIMENTO PARA ESSA NF');
  end;
  if(nvl(v_statuslan,0) = 1 or nvl(v_statusexport,0) != 0 ) then
    raise_application_error(-20001,'OPERAÇÃO NÃO PERMITIDA - MOVIMENTO JÁ QUITADO OU CONTABILIZADO.');
  end if;
  begin
    select idlan into v_idlan from rm.flan@RMDB
    where codcoligada = 1 and idmov = v_idmov;
    delete rm.ftrblan@RMDB
    r where r.codcoligada = 1 and r.idlan = v_idlan;
    delete rm.flancompl@RMDB
    c where c.codcoligada = 1 and c.idlan = v_idlan;
    delete rm.flanlog@RMDB
  u where u.codcoligada = 1 and u.idlan = v_idlan;
    delete rm.tmovlan@RMDB
    l where l.codcoligada = 1 and l.idmov = v_idmov;
    /*novos*/
    delete fxcxcompl@RMDB f 
    where f.codcoligada = 1 and idxcx in (select idxcx from fxcx@rmdb f where f.codcoligada = 1 and (f.idsessao, f.idoperacao) in (select f.idsessao, f.idoperacao from flogsessaocaixa@rmdb f where f.codcoligada = 1 and f.idlan = v_idlan));
    delete fxcx@RMDB f 
    where f.codcoligada = 1 and (f.idsessao, f.idoperacao) in (select f.idsessao, f.idoperacao from flogsessaocaixa@rmdb f where f.codcoligada = 1 and f.idlan = v_idlan);
    delete rm.flogsessaocaixa@RMDB
    f where f.codcoligada = 1 and f.idlan = v_idlan;
    delete rm.flogvalores@RMDB
    f where f.codcoligada = 1 and f.idlan = v_idlan;
    delete rm.flanbaixa@RMDB
    f where f.codcoligada = 1 and f.idlan = v_idlan;    
    /**/
    delete rm.flan@RMDB
    f where f.codcoligada = 1 and f.idmov = v_idmov;
    delete rm.ttrbmov@RMDB
    t where t.codcoligada = 1 and t.idmov = v_idmov;
    delete rm.titmmov@RMDB
    i where i.codcoligada = 1 and i.idmov = v_idmov;
    delete rm.tmovcompl@RMDB
    o where o.codcoligada = 1 and o.idmov = v_idmov;
    delete rm.tmov@RMDB
    m where m.codcoligada = 1 and m.idmov = v_idmov;
    commit;
  exception when others then
    rollback;
    raise_application_error(-20002,'ERRO AO CANCELAR MOVIMENTOS');
  end;
end PRC_FAT_RM_EXCLUIRMOV_CNV;
/