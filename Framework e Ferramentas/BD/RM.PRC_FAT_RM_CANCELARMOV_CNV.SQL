CREATE OR REPLACE PROCEDURE "PRC_FAT_RM_CANCELARMOV_CNV" (pNUMEROMOV       in varchar2,
                             pCODFILIAL       in number,
                             pSERIE           in varchar2,
														 pCODIGO_OPCAO_PGTO in varchar2) is
v_idmov number;
v_statuslan number;
v_statusexport number(5);
v_idlan number;

begin
  /* Cancelar movimentos do RM */
  /* Marcus Relva 01/06/2012 */

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
    and m.serie = pSERIE;
  exception when others then
    raise_application_error(-20000,'NENHUM MOVIMENTO ENCONTRADO OU MAIS DE UM MOVIMENTO PARA ESSA NF');
  end;

  if((nvl(v_statuslan,0) = 1 or nvl(v_statusexport,0) != 0) and nvl(pCODIGO_OPCAO_PGTO,0) != 1 ) then
    raise_application_error(-20001,'OPERAÇÃO NÃO PERMITIDA - MOVIMENTO JÁ QUITADO OU CONTABILIZADO.');
  end if;

  begin

    update rm.flan--@rm
    f
    set f.statuslan = '2'
    where f.codcoligada = 1 and f.idmov = v_idmov;

    update rm.tmov--@rm
    m
    set m.status = 'C'
    where m.codcoligada = 1 and m.idmov = v_idmov;

    commit;

  exception when others then
    rollback;
    raise_application_error(-20002,'ERRO AO CANCELAR MOVIMENTOS');
  end;

end PRC_FAT_RM_CANCELARMOV_CNV;
 