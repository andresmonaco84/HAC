CREATE OR REPLACE PROCEDURE PRC_CAD_PRD_RET_VALOR_NF_GLOB
(
     dfsCodmnemat                IN MTM_MAT_MED.CODMNEMAT%TYPE,
     sCodtmv                     IN VARCHAR,
     dNfgbValida                 OUT DATE,
     dDtMovimento                OUT DATE,
     nVlCusto                    OUT FLOAT
) IS
  /********************************************************************
   *    Procedure: PRC_CAD_PRD_RET_VALOR_NF_GLOB
   *
   *    Data Alteracao: 4/8/2011  Por: PEDRO
   *    Alterado: trim(m.cad_prd_cd_codigo)
   *    Data Alteracao: 30/1/2011  Por: Andre
   *    Alterado: mudanca para busca nas tabelas do SGS
   *    Data Alteracao: 11/6/2013  Por: Andre
   *    Alterado: estava pegando custo medio ao inves do val. unitario
   *    Data Alteracao: 29/8/2016  Por: Andre
   *    Alterado: retirada de busca no RM
   *
   *    Funcao: RETORNA VALOR DO PRODUTO DE NOTA FISCAL DO PLANO
   *            BUSCA POR:
   *            MNEMONICO E CODTMV
   *******************************************************************/
BEGIN
  /*select distinct add_months(mov.dataemissao, -6), mov.dataemissao,
  nvl(IT.PRECOUNITARIO / DECODE(TU.FATORCONVERSAO, NULL, 1, 0, 1, TU.FATORCONVERSAO),0)
     into dNfgbValida, dDtMovimento, nVlCusto
  from rm.titmmov it, rm.tprd pr, rm.tmov mov, tb_cad_prd_produto m, rm.TUND TU
  where mov.idmov = it.idmov
   and mov.codcoligada = it.codcoligada
   and it.idprd = pr.idprd
   and it.codcoligada = pr.codcoligada
   and m.cad_prd_nm_mnemonico = dfsCodmnemat
   and pr.codigoprd = trim(m.cad_prd_cd_codigo)
   and mov.codtmv = sCodtmv
   and mov.campolivre1 is not null
   and ((mov.codcoligada = 1 and mov.codfilial = 51) OR mov.codcoligada = 2)
   AND TU.CODUND = IT.CODUND
   and mov.dataemissao =
       (select max(m.dataemissao)
          from rm.tmov m,
               rm.titmmov i,
               rm.tprd t
         where I.IDPRD = IT.IDPRD
         and m.idmov = i.idmov
         and m.codcoligada = i.codcoligada
           and i.idprd = t.idprd
           and i.codcoligada = t.codcoligada
           and m.codtmv = mov.codtmv
           and m.campolivre1 is not null
           and ((m.codcoligada = 1 and m.codfilial = 51) OR m.codcoligada = 2)
           and i.precounitario > 0);*/
   SELECT ADD_MONTHS(MTMD_DATA_PRC_MEDIO, -6), MTMD_DATA_PRC_MEDIO, NVL(NVL(MTMD_PRECO_UNITARIO, MTMD_CUSTO_MEDIO),0)
     INTO dNfgbValida, dDtMovimento, nVlCusto
     FROM (SELECT T.MTMD_PRECO_UNITARIO, T.MTMD_CUSTO_MEDIO, T.MTMD_DATA_PRC_MEDIO
    FROM TB_MTMD_HISTORICO_NOTA_FISCAL T,
         TB_CAD_MTMD_MAT_MED M
    WHERE M.CAD_MTMD_ID = T.CAD_MTMD_ID AND
          M.CAD_MTMD_CODMNE = TRIM(dfsCodmnemat) AND
          T.CAD_MTMD_FILIAL_ID = 2
    ORDER BY T.MTMD_DATA_PRC_MEDIO DESC)
    WHERE ROWNUM = 1;
EXCEPTION
WHEN NO_DATA_FOUND THEN
   dNfgbValida :=  TO_DATE('01/01/1900', 'DD/MM/YYYY');
   dDtMovimento := TO_DATE('01/01/1900', 'DD/MM/YYYY');
   nVlCusto := 0;
     /*BEGIN
     select distinct add_months(mov.dataemissao, -6), mov.dataemissao,
      round(nvl(IT.PRECOUNITARIO / DECODE(TU.FATORCONVERSAO, NULL, 1, 0, 1, TU.FATORCONVERSAO),0),2)
           into dNfgbValida, dDtMovimento, nVlCusto
        from titmmov@RMDB it, TPRODUTO@RMDB pr, tmov@RMDB mov, tb_cad_prd_produto m,
       TUND@RMDB TU
       where mov.idmov = it.idmov
         and mov.codcoligada = it.codcoligada
         and it.idprd = pr.idprd
         and it.codcoligada = pr.codcolprd
         and m.cad_prd_nm_mnemonico = trim(dfsCodmnemat)
         and pr.codigoprd = trim(m.cad_prd_cd_codigo)
         and mov.codtmv LIKE '1.2.%'
         and mov.campolivre1 is null
         and ((mov.codcoligada = 1 and mov.codfilial = 51) OR mov.codcoligada = 2)
         AND TU.CODUND = IT.CODUND
         AND ROWNUM = 1
         and mov.dataemissao =
             (select max(m.dataemissao)
                from tmov@RMDB m,
                     titmmov@RMDB i,
                     TPRODUTO@RMDB t
               where I.IDPRD = IT.IDPRD
               and m.idmov = i.idmov
               and m.codcoligada = i.codcoligada
                 and i.idprd = t.idprd
                 and i.codcoligada = t.codcolprd
                 and m.codtmv LIKE '1.2.%'
                 and m.campolivre1 is null
                 and ((m.codcoligada = 1 and m.codfilial = 51) OR m.codcoligada = 2)
                 and i.precounitario > 0);
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
       dNfgbValida :=  TO_DATE('01/01/1900', 'DD/MM/YYYY');
       dDtMovimento := TO_DATE('01/01/1900', 'DD/MM/YYYY');
       nVlCusto := 0;
    END;*/
END PRC_CAD_PRD_RET_VALOR_NF_GLOB;
