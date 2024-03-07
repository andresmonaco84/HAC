CREATE OR REPLACE PROCEDURE "PRC_FAT_RM_TMOV" (pCODFILIAL       in number,
                                            pCODCFO          in varchar2,
                                            pNUMEROMOV       in varchar2,
                                            pDATAEMISSAO     in varchar2,
                                            pVALOR           in number,
                                            pOBSERVACAO      in varchar2,
                                            pCODUSUARIO      in varchar2,
                                            pCODMUNSERVICO   in number,
                                            pCODETDMUNSERV   in varchar2,                                           
                                            pDATAATENDIMENTO in DATE,
                                            pNUMERONF        in varchar2,
                                            pPERCENTUALISS   in number,
                                            pCODCAIXA        in varchar2,
                                            pHISTORICO       in varchar2,
																						pNASCIMENTOPACIENTE in date,
																						pCPFPACIENTE in varchar2,					
                                            pDESCONTO    in number default null,																
                                            io_cursor       out PKG_CURSOR.t_cursor) is                                            
v_idmov number;
v_idmovcfo number;
v_idlan number;
v_numeronof varchar2(10);
v_cursor PKG_CURSOR.t_cursor;
v_liquido number;

begin
  
v_liquido := pVALOR;
if(pDESCONTO is not null) then
  v_liquido := pVALOR - pDESCONTO;
end if;

v_numeronof := LPAD(pNUMERONF, 8, '0');


if(pCODCFO = '') then
           raise_application_error(-20000, 'CODCFO INVALIDO - ENTRE CONTATO COM A TI OU APP');
end if;  

  --obter maior movimentação
  select max(g.valautoinc) + 1
    into v_idmov
    from rm.gautoinc--@rm 
    g
   where g.codcoligada = 1
     and g.codsistema = 'T'
     and g.codautoinc = 'IDMOV';
  --atualizar tabela de incremento
  update rm.gautoinc--@rm
  g
     set g.valautoinc = v_idmov
   where g.codcoligada = 1
     and g.codsistema = 'T'
     and g.codautoinc = 'IDMOV';
 commit;
  --obter maior idlan
  select max(g.valautoinc) + 1
    into v_idlan
    from rm.gautoinc--@rm 
    g
   where g.codcoligada = 1
     and g.codsistema = 'F'
     and g.codautoinc = 'IDLAN';
  --atualizar tabela de incremento
  update rm.gautoinc--@rm 
  g
     set g.valautoinc = v_idlan
   where g.codcoligada = 1
     and g.codsistema = 'F'
     and g.codautoinc = 'IDLAN';
  commit;   
  --obter idmovcfo    
  select max(id) 
  into v_idmovcfo
  from rm.tmovcfo--@rm 
  c
  where c.codcfo = pCODCFO
  and c.codcoligada = 1;
  --inserir na tmov
  insert into rm.tmov--@rm
    (tmov.Idmovlctfluxus,
    tmov.codevento,
    tmov.idmovcfo,
     tmov.codloc,
     tmov.codcoligada,
     tmov.idmov,
     tmov.integraaplicacao,
     CODFILIAL,
     CODCFO,
     NUMEROMOV,
     SERIE,
     CODTMV,
     TIPO,
     STATUS,
     MOVIMPRESSO,
     DOCIMPRESSO,
     FATIMPRESSA,
     DATAEMISSAO,
     DATASAIDA,
     CODCPG,
     VALORBRUTO,
     VALORLIQUIDO,
     VALOROUTROS,
     OBSERVACAO,
     PESOLIQUIDO,
     PESOBRUTO,
     NUMERO,
     QUANTIDADE,
     CODMOEVALORLIQUIDO,
     DATABASEMOV,
     DATAMOVIMENTO,
     NUMEROLCTGERADO,
     GEROUFATURA,
     CODUSUARIO,
     FRETECIFOUFOB,
     USADESPFINANC,
     IDNAT, 
     DATAENTREGA,
     NUMEROCAIXA,
     NUMEROCUPOM,
     CODIGOSERVICO,
     CODMUNSERVICO,
     CODETDMUNSERV,
     CODTDO,
     PERCBASEINSSEMPREGADO,
     PERCENTBASEINSS,
     INSSEMOUTRAEMPRESA,
     DATALANCAMENTO,
     HORASAIDA,
     tmov.codtb2flx,
     tmov.codcolcfo,
     tmov.dataextra1,
     tmov.valorbrutointerno,
     tmov.valordesc)
  values
    (v_idmov,
     2003,
     v_idmovcfo,
     lpad(pCODFILIAL,2,'0')|| '.001',
     1,
     v_idmov,
     'T',
     pCODFILIAL,
     pCODCFO,
     v_numeronof,
     'NF01',
     '2.2.12', 
     'A',
     'F',
     '0',
     '0',
     '0',
     trunc(to_date(pDATAEMISSAO)),
     trunc(to_date(pDATAEMISSAO)),
     '33',
     pVALOR, --valorbruto
     v_liquido, --valorliquido
     pVALOR, --valoroutros
     pOBSERVACAO,
     0,
     0,
     0,
     1,
     'R$',
     trunc(to_date(pDATAEMISSAO)),
     trunc(to_date(pDATAEMISSAO)),
     '1',
     '0',
     pCODUSUARIO,
     '1',
     '0',
     '25',--'33', --prestacao de servicos (particular)
     trunc(to_date(pDATAEMISSAO)),
     0,
     0,
     '2.2.12',
     lpad(pCODMUNSERVICO,5,'0'),
     pCODETDMUNSERV,
     'NF',
     0,
     0,
     0,
     trunc(to_date(pDATAEMISSAO)),
     trunc(to_date(pDATAEMISSAO)),
     '01.02',
     1,
     trunc(to_date(pDATAEMISSAO)),
     pVALOR,
     nvl(pDESCONTO,0));
  --inserir na flan
  insert into rm.flan--@rm
     (
     ALIQUOTA,
ALTERACAOBLOQUEADA,
APLICFORMULA,
BAIXAAUTORIZADA,
BAIXAPENDENTE,
CAMPOALFAOP1,
CAMPOALFAOP2,
CAMPOALFAOP3,
CANCELADOFAT,
CAPMENSAL,
CARENCIAJUROS,
CATEGORIAAUTONOMO,
CHAPA,
CLASSIFICACAO,
CNABACEITE,
CNABAUTENTICACAO,
CNABBANCO,
CNABCARTEIRA,
CNABCODRETORNO,
CNABCOMANDO,
CNABINSTRUCAOCOD1,
CNABINSTRUCAOCOD2,
CNABNOSSONUMERO,
CNABSTATUS,
CODAPLICACAO,
CODBAIXA,
CODCCUSTO,
CODCFO,
CODCFOORIGEM,
CODCOLCFO,
CODCOLCFOORIGEM,
CODCOLCXA,
CODCOLIGADA,
CODCOLXCX,
CODCXA,
CODDEPARTAMENTO,
CODDIARIO,
CODDIARIOBAIXA,
CODEVENTO,
CODEVENTOBAIXA,
CODFILIAL,
CODIGOBARRA,
CODINDEXADOR,
CODMOEVALORORIGINAL,
CODRECEITA,
CODRPR,
CODTB1FLX,
CODTB2FLX,
CODTB3FLX,
CODTB4FLX,
CODTB5FLX,
CODTDO,
CODUSUDESBLOQUEIO1,
CODUSUDESBLOQUEIO2,
CODVEN,
CONVENIO,
COTA,
COTACAOBAIXA,
COTACAOINCLUSAO,
DATAALTERACAO,
DATABAIXA,
DATACANCELAMENTO,
DATACANCELBAIXA,
DATACHEQUE,
DATACONTABILIZ,
DATACONTABILIZBX,
DATACRIACAO,
DATAEMISSAO,
DATAESTORNOLAN,
DATAFATCNT,
DATAOP1,
DATAOP2,
DATAOP3,
DATAOP4,
DATAOP5,
DATAPAG,
DATAPREVBAIXA,
DATARECIBO,
DATAVENCIMENTO,
DATAVENCIMENTOANTECIP,
DESCONTADO,
DESCONTOCOMERCIAL,
DIGCONVENIO,
DTALT,
EMITIDO,
FATURADOFAT,
FILIALCONTABIL,
FORMULACAPITALIZACAO,
FORMULADESCONTO,
FORMULAJUROS,
FORMULAMULTA,
FORMULAVALOROP1,
FORMULAVALOROP2,
FORMULAVALOROP3,
FORMULAVALOROP4,
FORMULAVALOROP5,
FORMULAVALOROP6,
FORMULAVALOROP7,
FORMULAVALOROP8,
HISTORICO,
HRALT,
IDADIANTAMENTO,
IDBAIXAPARCIAL,
IDBOLETO,
IDCNT,
IDDEVOLUCAO,
IDFAT,
IDFORMAPAGTO,
IDGUIA,
IDHISTORICO,
IDIRRF,
IDLAN,
IDLANREPASSE,
IDMOV,
IDNOTACREDITO,
IDPGTO,
IDSESSAO,
IDXCX,
IMPOSTOEDITADO,
INSSEMOUTRAEMPRESA,
IPTE,
JAIMPRIMIU,
JUROSDIA,
JUROSVENDOR,
LIBAUTORIZADA,
LOCPAG,
LOTE,
MENSBAIXA,
MESDECOMPETENCIA,
MOEDAVINCULO,
MULTADIA,
MULTAFIXA,
NFOUDUP,
NSEQITMCNT,
NSEQITMPREVISAO,
NUMBLOQUEIOS,
NUMCONTABILBX,
NUMEROCHEQUE,
NUMEROCONTABIL,
NUMERODOCUMENTO,
NUMLOTECONTABIL,
NUMLOTECONTABILBX,
NUMRECIBO,
NUMSEQRECIBO,
OCAUTONOMO,
PAGREC,
PARCELA,
PERCBASEINSSEMPREGADO,
PERCENTBASEINSS,
PERLETIVO,
REEMBOLSAVEL,
REUTILIZACAO,
SEGUNDONUMERO,
SEQDIARIO,
SEQDIARIOBAIXA,
SEQDIARIOESTORNO,
SEQDIARIOESTORNOBAIXA,
SERIEDOCUMENTO,
SERVEXTRA,
STATUSDDA,
STATUSEXPORTACAO,
STATUSEXTRATO,
STATUSLAN,
TAXASVENDOR,
TEMCHEQUEPARCIAL,
TIPOCONTABILLAN,
TIPOJUROSDIA,
TIPOSAC,
USUARIO,
USUARIOCRIACAO,
VALORADIANTAMENTO,
VALORAUXILIAR,
VALORBAIXADO,
VALORBASEIRRF,
VALORCAP,
VALORCHEQUE,
VALORDEDUCAO,
VALORDEDUCAODEPENDENTES,
VALORDESCONTO,
VALORDEVOLUCAO,
VALORINSS,
VALORIRRF,
VALORJUROS,
VALORMULTA,
VALORNOTACREDITO,
VALOROP1,
VALOROP2,
VALOROP3,
VALOROP4,
VALOROP5,
VALOROP6,
VALOROP7,
VALOROP8,
VALOROPERACAODESCONTO,
VALORORIGINAL,
VALORREPASSE,
VALORSERVICO,
VALORSESTSENAT,
VALORVENCIMENTOANTECIP,
VRBASEINSS,
VRBASEINSSOUTRAEMPRESA,
VRBASEIRRF,
VRDEP,
VRPERDAFINANCEIRA)
values
(null, --ALIQUOTA  
0, --ALTERACAOBLOQUEADA  0
null, --APLICFORMULA  
1, --BAIXAAUTORIZADA  1
0, --BAIXAPENDENTE  0
null, --CAMPOALFAOP1  
null, --CAMPOALFAOP2  
null, --CAMPOALFAOP3  
null, --CANCELADOFAT  
0, --CAPMENSAL  0,0000
0, --CARENCIAJUROS  0
null, --CATEGORIAAUTONOMO  
null, --CHAPA  
0, --CLASSIFICACAO  0
0, --CNABACEITE  0
null, --CNABAUTENTICACAO  
null, --CNABBANCO  
null, --CNABCARTEIRA  
null, --CNABCODRETORNO  
null, --CNABCOMANDO  
null, --CNABINSTRUCAOCOD1  
null, --CNABINSTRUCAOCOD2  
null, --pNUMERONF, --CNABNOSSONUMERO  
0, --CNABSTATUS  1
'T', --CODAPLICACAO  T
null, --CODBAIXA  
null, --CODCCUSTO  
pCODCFO, --  C800144
null, --CODCFOORIGEM  
1, --CODCOLCFO  1
null, --CODCOLCFOORIGEM  
1, --CODCOLCXA  1
1, --CODCOLIGADA  1
null, --CODCOLXCX  
pCODCAIXA, --CODCXA  
null, --CODDEPARTAMENTO  
null, --CODDIARIO  
null, --CODDIARIOBAIXA  
null, --CODEVENTO  
null, --CODEVENTOBAIXA  
pCODFILIAL,--  1
null, --CODIGOBARRA  
null, --CODINDEXADOR  
'R$', --CODMOEVALORORIGINAL  R$
null, --CODRECEITA  
null, --CODRPR  
null, --CODTB1FLX  
'01.02', --CODTB2FLX  01.02 ****
null, --CODTB3FLX  
null, --CODTB4FLX  
null, --CODTB5FLX  
'NF', --CODTDO  NF
null, --CODUSUDESBLOQUEIO1  
null, --CODUSUDESBLOQUEIO2  
null, --CODVEN  
null, --CONVENIO  
null, --COTA  
0, --COTACAOBAIXA  0,0
0, -- COTACAOINCLUSAO  0,0
SYSDATE, --DATAALTERACAO  09/12/2011 ****
null, --DATABAIXA  
null, --DATACANCELAMENTO  
null, --DATACANCELBAIXA  
null, --DATACHEQUE  
null, --DATACONTABILIZ  
null, --DATACONTABILIZBX  
trunc(to_date(pDATAEMISSAO)), --DATACRIACAO  09/12/2011 ****
trunc(to_date(pDATAEMISSAO)), --DATAEMISSAO  09/12/2011
null, --DATAESTORNOLAN  
null, --DATAFATCNT  
null, --DATAOP1  
trunc(to_date(pDATAEMISSAO)), --DATAOP2  09/12/2011
null, --DATAOP3  
null, --DATAOP4  
null, --DATAOP5  
null, --DATAPAG  
trunc(to_date(pDATAEMISSAO)), --DATAPREVBAIXA  09/12/2011
null, --DATARECIBO  
trunc(to_date(pDATAEMISSAO) + 3), --DATAVENCIMENTO  09/12/2011
null, --DATAVENCIMENTOANTECIP  
0, --DESCONTADO  0
0, --DESCONTOCOMERCIAL  0,0000
null, --DIGCONVENIO  
null, --DTALT  
'N', --EMITIDO  N
0, --FATURADOFAT  0
null, --FILIALCONTABIL  
null, --FORMULACAPITALIZACAO  
null, --FORMULADESCONTO  
null, --FORMULAJUROS  
null, --FORMULAMULTA  
null, --FORMULAVALOROP1  
null, --FORMULAVALOROP2  
null, --FORMULAVALOROP3  
null, --FORMULAVALOROP4  
null, --FORMULAVALOROP5  
null, --FORMULAVALOROP6  
null, --FORMULAVALOROP7  
null, --FORMULAVALOROP8  
pHISTORICO, --HISTORICO  
null, --HRALT  
null, --IDADIANTAMENTO  
null, --IDBAIXAPARCIAL  
null, --IDBOLETO  
null, --IDCNT  
null, --IDDEVOLUCAO  
null, --IDFAT  
null, --IDFORMAPAGTO  
null, --IDGUIA  
null, --IDHISTORICO  
null, --IDIRRF  
v_idlan, --IDLAN  702093
null, --IDLANREPASSE  
v_idmov, --IDMOV  4674703
null, --IDNOTACREDITO  
null, --IDPGTO  
null, --IDSESSAO  
null, --IDXCX  
0, --IMPOSTOEDITADO  0
0, --INSSEMOUTRAEMPRESA  0,0000
null, --IPTE  
0, --JAIMPRIMIU  0
0, --JUROSDIA  0,0000
0, --JUROSVENDOR  0,0000
0, --LIBAUTORIZADA  0
null, --LOCPAG  
null, --LOTE  
null, --MENSBAIXA  
null, --MESDECOMPETENCIA  
null, --MOEDAVINCULO  
0, --MULTADIA  0,0000
0, --MULTAFIXA  0,0000
0, --NFOUDUP  0
null, --NSEQITMCNT  
null, --NSEQITMPREVISAO  
0, --NUMBLOQUEIOS  0
null, --NUMCONTABILBX  
null, --NUMEROCHEQUE  
null, --NUMEROCONTABIL  
v_numeronof, --NUMERODOCUMENTO  2016424201 
0, --NUMLOTECONTABIL  0
null, --NUMLOTECONTABILBX  
null, --NUMRECIBO  
null, --NUMSEQRECIBO  
0, --OCAUTONOMO  0
1, --PAGREC  1
null, --PARCELA  
0, --PERCBASEINSSEMPREGADO  0,0000
0, -- PERCENTBASEINSS  0,0000
null, --PERLETIVO  
0, --REEMBOLSAVEL  0
0, --REUTILIZACAO  0
null, --SEGUNDONUMERO  
null, --SEQDIARIO  
null, --SEQDIARIOBAIXA  
null, --SEQDIARIOESTORNO  
null, --SEQDIARIOESTORNOBAIXA  
'NF01', --'RPS', --SERIEDOCUMENTO  RPS
null, --SERVEXTRA  
0, --STATUSDDA  0
0, --STATUSEXPORTACAO  0
0, --STATUSEXTRATO  0
0, --STATUSLAN  0
0, --TAXASVENDOR  0,0000
0, --TEMCHEQUEPARCIAL  0
2, --TIPOCONTABILLAN  2 ****
0, --TIPOJUROSDIA  0
null, --TIPOSAC  
null, --USUARIO  randrade ****
null, --USUARIOCRIACAO  randrade ****
0, --VALORADIANTAMENTO  0,0000
0, --VALORAUXILIAR  0,0000
0, --VALORBAIXADO  0,0000
100, --VALORBASEIRRF  100,0000 ****
0, --VALORCAP  0,0000
0, --VALORCHEQUE  0,0000
0, --VALORDEDUCAO  0,0000
0, --VALORDEDUCAODEPENDENTES  0,0000
nvl(pDESCONTO,0), --VALORDESCONTO  0,0000
0, --VALORDEVOLUCAO  0,0000
0, --VALORINSS  0,0000
0, -- VALORIRRF  0,0000
0, --VALORJUROS  0,0000
0, --VALORMULTA  0,0000
0, --VALORNOTACREDITO  0,0000
0, --VALOROP1  0,0000
round((pVALOR * (pPERCENTUALISS/100)),2), --VALOROP2  0,0000 -- ISS --0, --VALOROP2  0,0000
0,--VALOROP3  0,0000
0,--VALOROP4  0,0000
0,--VALOROP5  0,0000
0,--VALOROP6  0,0000
0,--VALOROP7  0,0000
0,--VALOROP8  0,0000
null, --VALOROPERACAODESCONTO  
pVALOR, --VALORORIGINAL  244,5100
0, --VALORREPASSE  0,0000
pVALOR, --VALORSERVICO  244,5100
0, --VALORSESTSENAT  0,0000
null, --VALORVENCIMENTOANTECIP  
0, --VRBASEINSS  0,0000
0, --VRBASEINSSOUTRAEMPRESA  0,0000
0, --VRBASEIRRF  0,0000
0, --VRDEP  0,0000
0 --VRPERDAFINANCEIRA  0,0000)    
);
  --inserir na tmovlan   
insert into rm.tmovlan--@rm
  (tmovlan.codcoligada,
   tmovlan.idmov,
   tmovlan.idlan,
   tmovlan.idprocessofat)
values
  (1, v_idmov, v_idlan, null);
insert into rm.tmovcompl--@rm
(codcoligada, idmov, atendimento, dtnascpaciente, cpfpaciente)
values (1, v_idmov, pNUMEROMOV,	pNASCIMENTOPACIENTE, pCPFPACIENTE);  
commit;
     OPEN v_cursor FOR  
          select v_idmov from dual;
      io_cursor := v_cursor;  
end prc_fat_rm_tmov;

 

 

 
 
/
