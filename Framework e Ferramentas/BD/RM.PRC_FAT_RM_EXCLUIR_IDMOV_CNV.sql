CREATE OR REPLACE PROCEDURE PRC_FAT_RM_EXCLUIR_IDMOV_CNV (pIDMOV in number) is
v_idlan number;
begin
  /* Excluir movimentos do RM por ERRO */
  /* Marcus Relva 03/06/2014 */

  begin
    select idlan into v_idlan from rm.flan
    where codcoligada = 1 and idmov = pIDMOV;
    delete rm.ftrblan
    r where r.codcoligada = 1 and r.idlan = v_idlan;
    delete rm.flancompl
    c where c.codcoligada = 1 and c.idlan = v_idlan;
    delete rm.flanlog
    u where u.codcoligada = 1 and u.idlan = v_idlan;
    delete rm.tmovlan
    l where l.codcoligada = 1 and l.idmov = pIDMOV;
    delete rm.flan
    f where f.codcoligada = 1 and f.idmov = pIDMOV;
    delete rm.ttrbmov
    t where t.codcoligada = 1 and t.idmov = pIDMOV;
    delete rm.titmmov
    i where i.codcoligada = 1 and i.idmov = pIDMOV;
    delete rm.tmovcompl
    o where o.codcoligada = 1 and o.idmov = pIDMOV;
    delete rm.tmov
    m where m.codcoligada = 1 and m.idmov = pIDMOV;
    commit;
  exception when others then
    rollback;
    raise_application_error(-20002,'ERRO AO EXCLUIR MOVIMENTOS POR ERRO');
  end;
end PRC_FAT_RM_EXCLUIR_IDMOV_CNV;
 
