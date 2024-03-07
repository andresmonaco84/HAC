CREATE OR REPLACE PROCEDURE "PRC_FAT_RM_TMOV_CNV" (--pCAD_CNV_ID_CONVENIO in number,
                                                pCODFILIAL        in number,                                                
                                                pDATAEMISSAO      in date,
                                                pDATAVENCIMENTO   in date,
                                                pVALORBRUTO       in number,
                                                pVALORLIQUIDO     in number,
                                                pCODUSUARIO       in varchar2,                                             
                                                pNUMERONF         in varchar2,
                                                pSERIENF          in varchar2,                                                
                                                pPERCENTUALISS    in number,
                                                pPERCENTUALIR     in number,
                                                pPERCENTUALPIS    in number,
                                                pPERCENTUALCSLL   in number,
                                                pPERCENTUALCOFINS in number,
                                                /*newinfo*/
																								pCTACAIXARM        in varchar2,
																								pCODCFO            in varchar2, 
																								pCODETD            in varchar2, 
																								pCODMUNICIPIO      in varchar2, 
																								pNOMECONVENIO      in varchar2, 
																								pCODTB1FLX         in varchar2, 
																								pCODIGO_OPCAO_PGTO in varchar,
                                                io_cursor        out PKG_CURSOR.t_cursor) is
  v_idmov             number;
  v_idmovcfo          number;
  v_idlan             number;
  v_cursor            PKG_CURSOR.t_cursor;
  v_idnat             number;
  v_codtmv            varchar2(10); 
--  v_codcfo            varchar2(25);
--  v_codetd            varchar2(2);
--  v_codmunicipio      varchar2(10);
--  v_nomeconvenio      varchar2(120);
  v_idtrblan_atual    number;
  v_idtrblan_iss      number;
  v_idtrblan_ir       number;
  v_idtrblan_cofins   number;
  v_idtrblan_csll     number;
  v_idtrblan_pis      number;
  v_codcpg            varchar2(5);

begin
  /* Marcus Relva - 13/02/2014*/

   if(pPERCENTUALIR > 0) then
     if(pCODETD = 'SP') then
       v_idnat  := 24;
       v_codcpg := '33';
     else
       v_idnat  := 35;
       v_codcpg := '33';
     end if;     
     v_codtmv := '2.2.01';                             
   else   
    if(pCODETD = 'SP') then
     v_idnat  := 25;
     v_codcpg := '33';
    else
     v_idnat  := 37;
     v_codcpg := '33';
    end if;
     v_codtmv := '2.2.08';   
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
--  commit;
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
--  commit;
  /* obter e atualizar incrementos*/  
    select max(g.valautoinc)
    into v_idtrblan_atual
    from rm.gautoinc--@rm 
         g
   where g.codcoligada = 1
     and g.codsistema = 'F'
     and g.codautoinc = 'IDTRBLAN';  
  update rm.gautoinc--@rm
         g
     set g.valautoinc = v_idtrblan_atual + 5
   where g.codcoligada = 1
     and g.codsistema = 'F'
     and g.codautoinc = 'IDTRBLAN';
--   commit;
  v_idtrblan_iss      := v_idtrblan_atual +1;
  v_idtrblan_ir       := v_idtrblan_atual +2;
  v_idtrblan_cofins   := v_idtrblan_atual +3;
  v_idtrblan_csll     := v_idtrblan_atual +4;
  v_idtrblan_pis      := v_idtrblan_atual +5; 
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
     tmov.valorbrutointerno)
  values
    (v_idmov,
     2001,
     v_idmovcfo,
     lpad(pCODFILIAL, 2, '0') || '.001',
     1,
     v_idmov,
     'T',
     pCODFILIAL,
     pCODCFO,
     pNUMERONF,
     pSERIENF,
     v_codtmv,
     'A',
     'F',
     '0',
     '0',
     '0',
     trunc(pDATAEMISSAO),
     trunc(pDATAEMISSAO),
     v_codcpg,--'33',
     pVALORBRUTO,
     pVALORBRUTO,
     pVALORBRUTO,
     pNOMECONVENIO,
     0,
     0,
     0,
     1,
     'R$',
     trunc(pDATAEMISSAO), --pDATAATENDIMENTO,
     trunc(pDATAEMISSAO), --pDATAATENDIMENTO,
     '1',
     '0',
     pCODUSUARIO,
     '1',
     '0',
     v_idnat,
     trunc(pDATAEMISSAO), --pDATAATENDIMENTO,
     0,
     0,
     v_codtmv,
     pCODMUNICIPIO,
     pCODETD,
     'NF',
     0,
     0,
     0,
     trunc(pDATAEMISSAO), --pDATAATENDIMENTO,
     trunc(pDATAEMISSAO), --pDATAATENDIMENTO, 
     '01.01',
     1,
     trunc(pDATAEMISSAO),
     pVALORBRUTO);
  --inserir na flan
  insert into rm.flan--@rm
    (ALIQUOTA,
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
     decode(pCODIGO_OPCAO_PGTO, 1, 'X-CPD', pCTACAIXARM), --CODCXA  
     null, --CODDEPARTAMENTO  
     null, --CODDIARIO  
     null, --CODDIARIOBAIXA  
     null, --CODEVENTO  
     null, --CODEVENTOBAIXA  
     pCODFILIAL, --  1
     null, --CODIGOBARRA  
     null, --CODINDEXADOR  
     'R$', --CODMOEVALORORIGINAL  R$
     null, --CODRECEITA  
     null, --CODRPR  
     pCODTB1FLX,--v_codtb1flx, --CODTB1FLX  
     '01.01', --CODTB2FLX  01.02 ****
     null, --CODTB3FLX  
     null, --CODTB4FLX  
     null, --CODTB5FLX  
     decode(pCODIGO_OPCAO_PGTO, 1, 'COB', 'NF'), --CODTDO  NF
     null, --CODUSUDESBLOQUEIO1  
     null, --CODUSUDESBLOQUEIO2  
     null, --CODVEN  
     null, --CONVENIO  
     null, --COTA  
     0, --COTACAOBAIXA  0,0
     0, -- COTACAOINCLUSAO  0,0
     SYSDATE, --DATAALTERACAO  09/12/2011 ****
     decode(pCODIGO_OPCAO_PGTO, 1, trunc(pDATAEMISSAO), null), --DATABAIXA  
     null, --DATACANCELAMENTO  
     null, --DATACANCELBAIXA  
     null, --DATACHEQUE  
     null, --DATACONTABILIZ  
     null, --DATACONTABILIZBX  
     trunc(pDATAEMISSAO), --DATACRIACAO  09/12/2011 ****
     trunc(pDATAEMISSAO), --DATAEMISSAO  09/12/2011
     null, --DATAESTORNOLAN  
     null, --DATAFATCNT  
     null, --DATAOP1  
     trunc(pDATAEMISSAO), --DATAOP2  09/12/2011
     null, --DATAOP3  
     null, --DATAOP4  
     null, --DATAOP5  
     null, --DATAPAG  
     trunc(pDATAEMISSAO), --DATAPREVBAIXA  09/12/2011
     null, --DATARECIBO  
     trunc(pDATAVENCIMENTO), --DATAVENCIMENTO  09/12/2011
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
     pNOMECONVENIO, --HISTORICO  
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
     pNUMERONF, --NUMERODOCUMENTO  2016424201 
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
     pSERIENF, --'RPS', --SERIEDOCUMENTO  RPS
     null, --SERVEXTRA  
     0, --STATUSDDA  0
     0, --STATUSEXPORTACAO  0
     0, --STATUSEXTRATO  0
     decode(pCODIGO_OPCAO_PGTO, 1, 1, 0), --STATUSLAN  0
     0, --TAXASVENDOR  0,0000
     0, --TEMCHEQUEPARCIAL  0
     decode(pCODIGO_OPCAO_PGTO, 1, 0,2),--decode(v_codigo_opcao_pgto, 1, 0,2), --TIPOCONTABILLAN  2 ****
     0, --TIPOJUROSDIA  0
     null, --TIPOSAC  
     null, --USUARIO  randrade ****
     null, --USUARIOCRIACAO  randrade ****
     0, --VALORADIANTAMENTO  0,0000
     0, --VALORAUXILIAR  0,0000
     decode(pCODIGO_OPCAO_PGTO, 1, pVALORBRUTO,0),--decode(v_codigo_opcao_pgto, 1, pVALORBRUTO,0), --VALORBAIXADO  0,0000
     100, --VALORBASEIRRF  100,0000 ****
     0, --VALORCAP  0,0000
     0, --VALORCHEQUE  0,0000
     0, --VALORDEDUCAO  0,0000
     0, --VALORDEDUCAODEPENDENTES  0,0000
     0, --VALORDESCONTO  0,0000
     0, --VALORDEVOLUCAO  0,0000
     0, --VALORINSS  0,0000
     0, -- VALORIRRF  0,0000
     0, --VALORJUROS  0,0000
     0, --VALORMULTA  0,0000
     0, --VALORNOTACREDITO  0,0000
     0, --VALOROP1  0,0000
     round((pVALORBRUTO * (pPERCENTUALISS/100)),2), --VALOROP2  0,0000 -- ISS
     0, --VALOROP3  0,0000
     0, --VALOROP4  0,0000
     0, --VALOROP5  0,0000
     0, --VALOROP6  0,0000
     0, --VALOROP7  0,0000
     0, --VALOROP8  0,0000
     null, --VALOROPERACAODESCONTO  
     pVALORBRUTO, --VALORORIGINAL  244,5100
     0, --VALORREPASSE  0,0000
     pVALORBRUTO, --VALORSERVICO  244,5100
     0, --VALORSESTSENAT  0,0000
     null, --VALORVENCIMENTOANTECIP  
     0, --VRBASEINSS  0,0000
     0, --VRBASEINSSOUTRAEMPRESA  0,0000
     0, --VRBASEIRRF  0,0000
     0, --VRDEP  0,0000
     0); --VRPERDAFINANCEIRA  0,0000)    
  --inserir na tmovlan   
  insert into rm.tmovlan--@rm
    (tmovlan.codcoligada,
     tmovlan.idmov,
     tmovlan.idlan,
     tmovlan.idprocessofat)
  values
    (1, v_idmov, v_idlan, null);
/* ir ftrblan */
insert into rm.ftrblan--@rm
  (CODCOLIGADA,
   IDTRBLAN,
   IDLAN,
   CODTRB,
   BASEDECALCULO,
   ALIQUOTA,
   VALOR,
   CODRETENCAO,
   EDITADO)
values
  (1, --CODCOLIGADA
   v_idtrblan_ir, --IDTRBLAN
   v_idlan, --IDLAN
   'IRRF', --CODTRB
   pVALORBRUTO, --BASEDECALCULO
   pPERCENTUALIR, --ALIQUOTA
   round((pVALORBRUTO * (pPERCENTUALIR / 100)),2), --VALOR
   null, --CODRETENCAO
   0 --EDITADO
   );
/* pis ftrblan */
insert into rm.ftrblan--@rm
  (CODCOLIGADA,
   IDTRBLAN,
   IDLAN,
   CODTRB,
   BASEDECALCULO,
   ALIQUOTA,
   VALOR,
   CODRETENCAO,
   EDITADO)
values
  (1, --CODCOLIGADA
   v_idtrblan_pis, --IDTRBLAN
   v_idlan, --IDLAN
   'PIS', --CODTRB
   pVALORBRUTO, --BASEDECALCULO
   pPERCENTUALPIS, --ALIQUOTA
   round((pVALORBRUTO * (pPERCENTUALPIS / 100)),2), --VALOR
   null, --CODRETENCAO
   0 --EDITADO
   );
/* csll ftrblan */
insert into rm.ftrblan--@rm
  (CODCOLIGADA,
   IDTRBLAN,
   IDLAN,
   CODTRB,
   BASEDECALCULO,
   ALIQUOTA,
   VALOR,
   CODRETENCAO,
   EDITADO)
values
  (1, --CODCOLIGADA
   v_idtrblan_csll, --IDTRBLAN
   v_idlan, --IDLAN
   'CSLL', --CODTRB
   pVALORBRUTO, --BASEDECALCULO
   pPERCENTUALCSLL, --ALIQUOTA
   round((pVALORBRUTO * (pPERCENTUALCSLL / 100)),2), --VALOR
   null, --CODRETENCAO
   0 --EDITADO
   );
/* cofins ftrblan */
insert into rm.ftrblan--@rm
  (CODCOLIGADA,
   IDTRBLAN,
   IDLAN,
   CODTRB,
   BASEDECALCULO,
   ALIQUOTA,
   VALOR,
   CODRETENCAO,
   EDITADO)
values
  (1, --CODCOLIGADA
   v_idtrblan_cofins, --IDTRBLAN
   v_idlan, --IDLAN
   'COFINS', --CODTRB
   pVALORBRUTO, --BASEDECALCULO
   pPERCENTUALCOFINS, --ALIQUOTA
   round((pVALORBRUTO * (pPERCENTUALCOFINS / 100)),2), --VALOR
   null, --CODRETENCAO
   0 --EDITADO
   );
--commit;
OPEN v_cursor FOR
    select v_idmov from dual;
  io_cursor := v_cursor;
end PRC_FAT_RM_TMOV_CNV;
