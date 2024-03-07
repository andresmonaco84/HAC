CREATE OR REPLACE PROCEDURE PRC_FAT_RM_CANCELARMOV_CNV (pNUMEROMOV       in varchar2,
                             pCODFILIAL       in number,
                             pSERIE           in varchar2) is
v_idmov number;
v_statuslan number;
v_statusexport number(5);
v_idlan number;
v_codigo_opcao_pgto number;	

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
	
  begin
		select c.cad_cnv_cd_opcao_pagto 
		into v_codigo_opcao_pgto
		from rm.tmov--@rm
									m, 
									tb_cad_pes_pessoa p, 
									tb_cad_cnv_convenio c
		where idmov = v_idmov
		and c.cad_pes_id_pessoa = p.cad_pes_id_pessoa
		and p.codcfo = m.codcfo
		and rownum = 1;
  exception when others then
		v_codigo_opcao_pgto := null;
  end;

  if((nvl(v_statuslan,0) = 1 or nvl(v_statusexport,0) != 0) and nvl(v_codigo_opcao_pgto,0) != 1 ) then
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
  