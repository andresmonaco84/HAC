CREATE OR REPLACE PROCEDURE "PRC_FAT_RM_EXCLUIRMOV_CNV" (pNUMEROMOV       in varchar2,
                             pCODFILIAL       in number,
                             pSERIE           in varchar2) is
v_idmov number;
v_statuslan number;
v_statusexport number(5);
v_idlan number;

begin
  /* Excluir movimentos do RM */  

  begin

    select m.idmov, l.statuslan, m.statusexportcont
    into v_idmov, v_statuslan, v_statusexport
    from rm.tmov--@rm
    m,
    rm.flan--@rm
    l
    where m.codcoligada = l.codcoligada
    and m.idmov = l.idmov
    and m.codcoligada = 1
    and m.codfilial = pCODFILIAL
    and m.numeromov = pNUMEROMOV
    and m.dataemissao >= to_date('01/05/2012','dd/MM/yyyy');
  exception when others then
    raise_application_error(-20000,'NENHUM MOVIMENTO ENCONTRADO OU MAIS DE UM MOVIMENTO PARA ESSA NF');
  end;

  if(nvl(v_statuslan,0) = 1 or nvl(v_statusexport,0) != 0 ) then
    raise_application_error(-20001,'OPERAÇÃO NÃO PERMITIDA - MOVIMENTO JÁ QUITADO OU CONTABILIZADO.');
  end if;

  begin

    select idlan into v_idlan from rm.flan--@rm
    where codcoligada = 1 and idmov = v_idmov;

    delete rm.ftrblan--@rm
    r where r.codcoligada = 1 and r.idlan = v_idlan;

    delete rm.flancompl--@rm
    c where c.codcoligada = 1 and c.idlan = v_idlan;

    delete rm.flanlog--@rm
  u where u.codcoligada = 1 and u.idlan = v_idlan;

    delete rm.tmovlan--@rm
    l where l.codcoligada = 1 and l.idmov = v_idmov;

    delete rm.flan--@rm
    f where f.codcoligada = 1 and f.idmov = v_idmov;

    delete rm.ttrbmov--@rm
    t where t.codcoligada = 1 and t.idmov = v_idmov;

    delete rm.titmmov--@rm
    i where i.codcoligada = 1 and i.idmov = v_idmov;

    delete rm.tmovcompl--@rm
    o where o.codcoligada = 1 and o.idmov = v_idmov;

    delete rm.tmov--@rm
    m where m.codcoligada = 1 and m.idmov = v_idmov;

    commit;

  exception when others then
    rollback;
    raise_application_error(-20002,'ERRO AO CANCELAR MOVIMENTOS');
  end;

end PRC_FAT_RM_EXCLUIRMOV_CNV;
 