CREATE OR REPLACE PROCEDURE "PRC_FAT_RM_CANCELARMOV"
                            (pNUMEROMOV       in varchar2) is
begin
  /* Excluir movimentos do RM */
  /* Marcus Relva 01/06/2012 */
  /* Excluir multimos IDMOVs 16/06/2014*/  
  
  for itens in ( select m.idmov, l.statuslan, m.statusexportcont    
    from rm.tmov--@rm
    m
    ,rm.flan--@rm
    l
    ,rm.tmovcompl--@rm
    p
    where m.codcoligada = l.codcoligada
    and m.idmov = p.idmov
    and p.codcoligada = m.codcoligada
    and m.idmov = l.idmov
    and m.codcoligada = 1
    and p.atendimento = pNUMEROMOV
  and m.status <> 'C') loop 
    if(nvl(itens.statuslan,0) = 1 or nvl(itens.statusexportcont,0) != 0 ) then
       raise_application_error(-20001,'OPERAÇÃO NÃO PERMITIDA - MOVIMENTO JÁ QUITADO OU CONTABILIZADO.');
    end if;
    
    begin

    update rm.flan--@rm
    f
    set f.statuslan = '2'
    where f.codcoligada = 1 and f.idmov = itens.idmov;

    update rm.tmov--@rm
    m
    set m.status = 'C'
    where m.codcoligada = 1 and m.idmov = itens.idmov;


    commit;

  exception when others then
    rollback;
    raise_application_error(-20002,'ERRO AO CANCELAR MOVIMENTOS');
  end;
    
  end loop;

end PRC_FAT_RM_CANCELARMOV;
 