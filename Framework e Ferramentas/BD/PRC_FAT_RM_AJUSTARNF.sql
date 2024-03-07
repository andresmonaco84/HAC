CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_RM_AJUSTARNF" (pNUMEROMOV       in varchar2,
                             pCODFILIAL       in number,
                             pSERIE           in varchar2,
														 pFAT_NOF_ID      in number,
														 pDATA_EMISSAO    in date) is
v_idmov number;
begin
  /* Ajustar data de emissao de NF */
  begin
    select m.idmov
    into v_idmov
    from rm.tmov@rm
    m
    where m.codcoligada = 1
    and m.codfilial = pCODFILIAL
    and m.numeromov = pNUMEROMOV
    and m.serie = pSERIE
		and m.status <> 'C';
  exception when others then
    raise_application_error(-20000,'NENHUM MOVIMENTO ENCONTRADO OU MAIS DE UM MOVIMENTO PARA ESSA NF');
  end;
  begin
  	update tb_fat_nof_nota_fiscal nof
		set nof.fat_nfo_dt_emissao = pDATA_EMISSAO
		where nof.fat_nof_id = pFAT_NOF_ID;
    update rm.flan@rm
    f
    set f.dataemissao = pDATA_EMISSAO
    where f.codcoligada = 1 and f.idmov = v_idmov;
    update rm.tmov@rm
    m
    set m.dataemissao = pDATA_EMISSAO,		
				m.DATASAIDA = pDATA_EMISSAO,
				m.DATAEXTRA1 = pDATA_EMISSAO,
				m.DATAMOVIMENTO = pDATA_EMISSAO,
				m.DATAENTREGA	= pDATA_EMISSAO,
				m.DATALANCAMENTO	= pDATA_EMISSAO,
				m.DATABASEMOV = pDATA_EMISSAO,
				m.HORASAIDA	= pDATA_EMISSAO
    where m.codcoligada = 1 and m.idmov = v_idmov;
    commit;
  exception when others then
    rollback;
    raise_application_error(-20018,'ERRO AO AJUSTAR NF');
  end;
end PRC_FAT_RM_AJUSTARNF;
/
