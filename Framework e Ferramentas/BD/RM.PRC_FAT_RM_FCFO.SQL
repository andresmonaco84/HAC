CREATE OR REPLACE PROCEDURE "PRC_FAT_RM_FCFO"(pNOME           in varchar2,
                                              pCGCCFO         in varchar2,
                                              pRUA            in varchar2,
                                              pNUMERO         in varchar2,
                                              pBAIRRO         in varchar2,
                                              pCIDADE         in varchar2,
                                              pCODETD         in varchar2,
                                              pCEP            in varchar2,
                                              pTELEFONE       in varchar2,
                                              pCELULAR        in varchar2,
                                              pCODMUNICIPIO   in varchar2,
                                              pPESSOAFISOUJUR in varchar2,
                                              pCOMPLEMENTO    in varchar2,
                                              pNACIONALIDADE  in varchar2 default null,
                                              pEMAIL  in varchar2 default null,
                                              io_cursor       out PKG_CURSOR.t_cursor) is
  v_idcfo        number;
  v_codcfo       varchar2(20);
  v_idmovcfo     number;
  v_seqtmov      number;
  v_cursor       PKG_CURSOR.t_cursor;
  v_cgccpf       varchar2(20);
  v_idpais       number;
  v_codetd       varchar2(2);
  v_codmunicipio varchar2(20);
begin
  v_idpais       := 1;
  v_codetd       := pCODETD;
  v_codmunicipio := pCODMUNICIPIO;
  if (trim(pCGCCFO) is not null) then
    begin
      select fcfo.codcfo
        into v_codcfo
        from rm.fcfo --@rm
       where replace(replace(replace(cgccfo, '.', ''), '-', ''), '/', '') =
             pCGCCFO
         and fcfo.idcfo =
             (select max(fcfo.idcfo)
                from rm.fcfo --@rm
               where codcoligada = 1 
               and replace(replace(replace(cgccfo, '.', ''), '-', ''),
                             '/',
                             '') = pCGCCFO
                    --Não sobreescrever fornecedores/clientes nao gravador por aqui
                 and (fcfo.codcfo like 'C8%' or fcfo.codcfo like 'C9%' or fcfo.codcfo like 'C10%'));
    exception
      when others then
        v_codcfo := null;
    end;
    if (length(pCGCCFO) < 11) then
      v_cgccpf := lpad(pCGCCFO, 11, '0');
  	else
				v_cgccpf := pCGCCFO;
    end if;  
  else
    begin
      select a.idpais
        into v_idpais
        from rm.gpais a
        join rm.dpais b
          on a.idpais = b.idpais
       where b.codpais = pNACIONALIDADE
         and rownum = 1;
    exception
      when others then
        v_idpais := 2;
    end;
    v_codetd       := 'EX';
    v_codmunicipio := null;
  end if;
  --obter maior movimentaçãocfo
  select max(g.valautoinc) + 1
    into v_idmovcfo
    from rm.gautoinc --@rm
         g
   where g.codcoligada = 1
     and g.codsistema = 'T'
     and g.codautoinc = 'IDMOVCFO';
  --atualizar tabela de incrementocfo
  update rm.gautoinc --@rm
         g
     set g.valautoinc = v_idmovcfo
   where g.codcoligada = 1
     and g.codsistema = 'T'
     and g.codautoinc = 'IDMOVCFO';
  commit;
  if (v_codcfo is null) then
    select 'C' || SEQ_FAT_RMFCFO.nextval into v_codcfo from dual;
    select max(g.valautoinc) + 1
      into v_idcfo
      from rm.gautoinc --@rm
           g
     where g.codcoligada = 0
       and g.codsistema = 'F'
       and g.codautoinc = 'IDCFO';
    update rm.gautoinc --@rm
           g
       set g.valautoinc = v_idcfo
     where g.codcoligada = 0
       and g.codsistema = 'F'
       and g.codautoinc = 'IDCFO';
    commit;
    insert into rm.fcfo --@rm
      (CODCOLIGADA,
       CODCFO,
       NOMEFANTASIA,
       NOME,
       PAGREC, --1 cliente
       CGCCFO,
       RUA,
       NUMERO,
       BAIRRO,
       CIDADE,
       CODETD, --uf
       CEP,
       TELEFONE,
       CODTCF, --1 cliente particular
       ATIVO,
       CODCOLTCF,
       CODMUNICIPIO, -- tabela gmunicipio
       PESSOAFISOUJUR,
       IDPAIS,
       IDCFO,
       TIPOCONTRIBUINTEINSS,
       fcfo.telex,
       fcfo.dataultalteracao,
       fcfo.Datacriacao,
       fcfo.complemento,
       fcfo.ruapgto,
       fcfo.Numeropgto,
       fcfo.bairropgto,
       fcfo.cidadepgto,
       fcfo.codetdpgto,
       fcfo.ceppgto,
       fcfo.codmunicipiopgto,
       fcfo.complementopgto,
       fcfo.ruaentrega,
       fcfo.Numeroentrega,
       fcfo.bairroentrega,
       fcfo.cidadeentrega,
       fcfo.codetdentrega,
       fcfo.cepentrega,
       fcfo.codmunicipioentrega,
       fcfo.complementrega,
       fcfo.email)
    values
      (1,
       v_codcfo,
       upper(pNOME),
       upper(pNOME),
       1,
       v_cgccpf,
       upper(pRUA),
       substr(pNUMERO, 0, 8),
       upper(pBAIRRO),
       pCIDADE,
       pCODETD,
       pCEP,
       pTELEFONE,
       '01',
       1,
       1,
       v_codmunicipio,
       pPESSOAFISOUJUR,
       v_idpais,
       v_idcfo,
       0,
       pCELULAR,
       sysdate,
       sysdate,
       upper(pCOMPLEMENTO),
       upper(pRUA), --fcfo.ruapgto,
       substr(pNUMERO, 0, 8), --fcfo.Numeropgto,
       upper(pBAIRRO), --fcfo.bairropgto,
       pCIDADE, --fcfo.cidadepgto,
       v_codetd, --fcfo.codetdpgto, 
       pCEP, --fcfo.ceppgto,
       v_codmunicipio, --fcfo.codmunicipiopgto,
       upper(pCOMPLEMENTO), --fcfo.complementopgto,
       upper(pRUA), --fcfo.ruaentrega,
       substr(pNUMERO, 0, 8), --fcfo.Numeroentrega,
       upper(pBAIRRO), --fcfo.bairroentrega,
       pCIDADE, --fcfo.cidadeentrega,
       v_codetd, --fcfo.codetdentrega, 
       pCEP, --fcfo.cepentrega,
       v_codmunicipio, --fcfo.codmunicipioentrega,
       upper(pCOMPLEMENTO), --fcfo.complementoentrega
       pEMAIL
       );
  else
    update rm.fcfo --@rm
       set NOMEFANTASIA             = upper(pNOME),
           NOME                     = upper(pNOME),
           CGCCFO                   = v_cgccpf,
           RUA                      = upper(pRUA),
           NUMERO                   = substr(pNUMERO, 0, 8),
           BAIRRO                   = upper(pBAIRRO),
           CIDADE                   = pCIDADE,
           CODETD                   = v_codetd,
           CEP                      = pCEP,
           TELEFONE                 = pTELEFONE,
           CODMUNICIPIO             = v_codmunicipio,
           PESSOAFISOUJUR           = pPESSOAFISOUJUR,
           TELEX                    = substr(pCELULAR, 0, 15),
           DATAULTALTERACAO         = SYSDATE,
           COMPLEMENTO              = upper(pCOMPLEMENTO),
           fcfo.ruapgto             = upper(pRUA),
           fcfo.Numeropgto          = substr(pNUMERO, 0, 8),
           fcfo.bairropgto          = upper(pBAIRRO),
           fcfo.cidadepgto          = pCIDADE,
           fcfo.codetdpgto          = v_codetd,
           fcfo.ceppgto             = pCEP,
           fcfo.codmunicipiopgto    = v_codmunicipio,
           fcfo.complementopgto     = upper(pCOMPLEMENTO),
           fcfo.ruaentrega          = upper(pRUA),
           fcfo.Numeroentrega       = substr(pNUMERO, 0, 8),
           fcfo.bairroentrega       = upper(pBAIRRO),
           fcfo.cidadeentrega       = pCIDADE,
           fcfo.codetdentrega       = pCODETD,
           fcfo.cepentrega          = pCEP,
           fcfo.codmunicipioentrega = v_codmunicipio,
           fcfo.complementrega      = upper(pCOMPLEMENTO),
           fcfo.email               = pEMAIL
     where CODCFO = v_codcfo;
  end if;
  commit;
  OPEN v_cursor FOR
    select v_codcfo as codcfo from dual;
  io_cursor := v_cursor;
end prc_fat_rm_fcfo;

 

 
 