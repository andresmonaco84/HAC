/*
select * from ALM_RESUMO_MOVIMENTO_CTB
WHERE MESANO >= TO_DATE('01022012','DDMMYYYY')
AND   MESANO <= TO_DATE('29022012','DDMMYYYY')
AND   CODHOS = 2
AND TIPO_BAIXA = 'D'

delete ALM_RESUMO_MOVIMENTO_CTB
WHERE MESANO >= TO_DATE('01022012','DDMMYYYY')
AND   MESANO <= TO_DATE('29022012','DDMMYYYY')
AND   CODHOS = 2
AND   TIPO_BAIXA = 'D'

UPDATE ALM_RESUMO_MOVIMENTO_CTB
SET ATD_ATE_ID = NULL
WHERE MESANO >= TO_DATE('01022012','DDMMYYYY')
AND   MESANO <= TO_DATE('29022012','DDMMYYYY')
AND   CODHOS = 2
AND TIPO_BAIXA = 'D'
AND ATD_ATE_ID = 0

update almox.alm_resumo_movimento_ctb t 
--set t.atd_ate_id = (select bnf_ben_id from sgs.tb_bnf_homecare b where b.bnf_homecare_id = t.atd_ate_id)
set t.atd_ate_id = NULL
where t.codhos = 2 and t.atd_ate_id < 10000
*/
DECLARE vCODCONTA_CRED VARCHAR(20);    
        vCODCONTA_DEB VARCHAR(20);
        vCODFILIAL NUMBER(5);
        vID_CCUSTO NUMBER;
        vCD_CCUSTO VARCHAR(25);
        vCODUNIHOS VARCHAR(4);
        vATD_ATE_ID NUMBER(10);
        vSEQ NUMBER(5);
        vValor NUMBER;
        vCount NUMBER;
        vTP_ATRIBUTO CHAR(3);
BEGIN

FOR X IN (
SELECT DIAP.MTMD_MOV_DATA,         
          DIAP.CAD_MTMD_FILIAL_ID,
          DIAP.CAD_UNI_ID_UNIDADE,
          --DIAP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
          DIAP.CAD_SET_ID, 
          DIAP.CAD_MTMD_GRUPO_ID,
          DIAP.CAD_MTMD_SUBTP_ID,
          MTMD.CAD_MTMD_ID,        
          MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,                   
          SUM(
              (CASE
               WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (1) THEN DIAP.MTMD_VALOR_ENTRADA
               ELSE 0
               END )              
             ) MTMD_VALOR_ENTRADA
  FROM TB_CAD_MTMD_MAT_MED MTMD,
       TB_MTMD_MOV_ESTOQUE_DIA DIAP,
       (
         SELECT *
         FROM TB_MTMD_MOV_ESTOQUE_DIA
         WHERE MTMD_MOV_DATA                = TO_DATE('01022012 0000','DDMMYYYY HH24MI')
         AND   (CAD_MTMD_FILIAL_ID = 2)
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
         AND   CAD_UNI_ID_UNIDADE           = 244
         AND   CAD_SET_ID                   = 29       
         AND   CAD_MTMD_TPMOV_ID            = 0
         AND   CAD_MTMD_SUBTP_ID            = 0
       ) LINHA_ZERO,
       (
         SELECT *
         FROM TB_MTMD_MOV_ESTOQUE_DIA
         WHERE CAD_MTMD_TPMOV_ID            = 1
         AND   CAD_MTMD_SUBTP_ID            = 1
         AND   MTMD_MOV_DATA >= TO_DATE('01022012 0000','DDMMYYYY HH24MI')
         AND   MTMD_MOV_DATA <= TO_DATE('29022012 2359','DDMMYYYY HH24MI')
         AND   (CAD_MTMD_FILIAL_ID = 2)       
       ) NOTAS                
  WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('01022012 0000','DDMMYYYY HH24MI')
  AND   DIAP.MTMD_MOV_DATA <= TO_DATE('29022012 2359','DDMMYYYY HH24MI')
  AND   DIAP.CAD_MTMD_FILIAL_ID             = 2
  AND  MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
  AND  LINHA_ZERO.CAD_MTMD_ID(+)            = DIAP.CAD_MTMD_ID
  AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)     = DIAP.CAD_MTMD_FILIAL_ID
  AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)      = DIAP.CAD_MTMD_GRUPO_ID
  AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)         = DIAP.CAD_MTMD_SUBGRUPO_ID
  AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
  AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
  AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
  AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID
  AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID
  AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
  AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
  --AND  DIAP.CAD_SET_ID IN (8)
  --AND  DIAP.CAD_MTMD_ID IN (9434)
  --AND DIAP.CAD_MTMD_SUBTP_ID = 29
  GROUP BY DIAP.MTMD_MOV_DATA,
           DIAP.CAD_UNI_ID_UNIDADE,
           DIAP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           DIAP.CAD_SET_ID,
           DIAP.CAD_MTMD_GRUPO_ID,
           DIAP.CAD_MTMD_SUBTP_ID,
           MTMD.CAD_MTMD_ID,   
           DIAP.CAD_MTMD_FILIAL_ID,  
           MTMD.CAD_MTMD_NOMEFANTASIA,
           LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
           LINHA_ZERO.MTMD_SALDO_ATUAL,       
           LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
           LINHA_ZERO.MTMD_VALOR_ATUAL,       
           LINHA_ZERO.MTMD_SALDO_ANTERIOR,
           LINHA_ZERO.MTMD_VALOR_ANTERIOR
  having SUM(
              (CASE
               WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (1) THEN DIAP.MTMD_VALOR_ENTRADA
               ELSE 0
               END )              
             ) > 0
  ORDER BY DIAP.CAD_SET_ID
) 
LOOP
    
   SELECT U.CAD_UNI_CD_UNID_HOSPITALAR INTO vCODUNIHOS FROM TB_CAD_UNI_UNIDADE U WHERE U.CAD_UNI_ID_UNIDADE = X.CAD_UNI_ID_UNIDADE;
   
   vTP_ATRIBUTO := 'MAT';
   IF (X.CAD_MTMD_GRUPO_ID = 1) THEN
      vTP_ATRIBUTO := 'MED';
   END IF;
   
   --BUSCA CENTRO DE CUSTO
   vID_CCUSTO := FNC_OBTER_CCUSTO(X.CAD_SET_ID,
                                vTP_ATRIBUTO,
                                NULL,
                                NULL,
                                NULL,
                                NULL,
                                SYSDATE);                                                                    
    IF (vID_CCUSTO = 0) THEN
       RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CD_CCUSTO PARA: '||
                                      ' CODUNIHOS '||TO_CHAR(vCODUNIHOS)||
                                      ' SETOR '||TO_CHAR(X.cad_set_id));
    END IF;
    IF (vID_CCUSTO IS NULL) THEN
          RAISE_APPLICATION_ERROR(-20000,' ERRO CD_CCUSTO NULL GRUPO '||TO_CHAR(X.CAD_MTMD_GRUPO_ID)||
                                           ' DATA '||TO_CHAR(X.MTMD_MOV_DATA)||
                                           ' SETOR '||TO_CHAR(X.CAD_SET_ID)||                                               
                                          -- ' CODUNIHOS '||TO_CHAR(X.CODUNIHOS)||
                                           ' CD_CCUSTO '||TO_CHAR(vCD_CCUSTO)||
                                           SQLERRM);  
    END IF;
    
    SELECT C.CAD_CEC_CD_CCUSTO INTO vCD_CCUSTO 
    FROM TB_CAD_CEC_CENTRO_CUSTO C 
    WHERE C.CAD_CEC_ID_CCUSTO = vID_CCUSTO;   
   
   --BUSCA CENTRO DE CUSTO
   /*BEGIN
     SELECT CD_CCUSTO INTO vCD_CCUSTO
       FROM HOSPITAL.TB_SETOR 
       WHERE CD_SETOR  = (SELECT S.CAD_SET_CD_SETOR FROM TB_CAD_SET_SETOR S WHERE S.CAD_SET_ID = X.CAD_SET_ID) AND 
             CODUNIHOS = vCODUNIHOS;
   EXCEPTION 
          WHEN NO_DATA_FOUND THEN 
             RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CD_CCUSTO PARA: '||
                                            ' CODUNIHOS '||TO_CHAR(vCODUNIHOS)||
                                            ' SETOR '||TO_CHAR(X.cad_set_id));
   END;*/
   
   --BUSCA FILIAL   
   BEGIN
       SELECT SUBSTR(PSU.CAD_PES_NR_CNPJ_CPF, 11, 2) INTO vCODFILIAL
          FROM TB_CAD_UNI_UNIDADE     UNI,
               TB_CAD_PES_PESSOA      PSU
         WHERE UNI.CAD_UNI_ID_UNIDADE = X.CAD_UNI_ID_UNIDADE
           AND UNI.CAD_PES_ID_PESSOA = PSU.CAD_PES_ID_PESSOA;
     /*SELECT CODFILIAL INTO vCODFILIAL
       FROM UNIDADE_HOSPITALAR
       WHERE CODUNIHOS = vCODUNIHOS;*/
   EXCEPTION 
          WHEN NO_DATA_FOUND THEN 
             RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CODFILIAL PARA: '||
                                            ' CODUNIHOS '||TO_CHAR(vCODUNIHOS)||
                                            ' SETOR '||TO_CHAR(X.cad_set_id));
   END;

   -- BUSCA CONTAS
   IF (  NVL(X.CAD_MTMD_GRUPO_ID,0) >0 ) THEN 
      BEGIN
         SELECT C.CAD_COD_CONTA_CRED, C.CAD_COD_CONTA_DEB 
          INTO   vCODCONTA_CRED,       vCODCONTA_DEB
          FROM SGS.TB_CAD_MTMD_CCONTAB_GRUPO C
          WHERE C.CAD_MTMD_COD_COLIGADA = X.CAD_MTMD_FILIAL_ID AND
                C.CAD_MTMD_GRUPO_ID     = X.CAD_MTMD_GRUPO_ID AND
                C.CAD_MTMD_TIPO_MOV     = DECODE(X.CAD_MTMD_SUBTP_ID, 6, 'Q', 'B') AND
                ( X.MTMD_MOV_DATA  BETWEEN C.CAD_MTMD_DT_INI_VIG AND C.CAD_MTMD_DT_FIM_VIG
                   OR X.MTMD_MOV_DATA >= C.CAD_MTMD_DT_INI_VIG AND C.CAD_MTMD_DT_FIM_VIG IS NULL );
                 
         /*SELECT CTB.CODCONTA_CRED, CTB.CODCONTA_DEB
         INTO   vCODCONTA_CRED,    vCODCONTA_DEB
         FROM ALM_CONTA_CONTAB_GRUPO_CTB       CTB
         WHERE CTB.CODHOS          = X.CAD_MTMD_FILIAL_ID
         AND   CTB.CD_GRUPO_MATMED = X.CAD_MTMD_GRUPO_ID
         AND   CTB.TIPO_BAIXA   = DECODE(X.CAD_MTMD_SUBTP_ID, 6, 'Q', 'B')
         AND   CTB.CODCOLIGADA  = 1
         AND   CTB.CODUNIHOS    = vCODUNIHOS
         --AND   CTB.CODCLADESAMB = DECODE( EXP.CODUNIHOS, 8, 32 , 9, 32, 24, 32, 27, 11, 18 )
         AND   CTB.CODCLADESAMB = DECODE( 2, 30, 32, 8, 32 , 9, 32, 24, 32, 27, 11, 28, 24, 18 )
         AND   ( X.mtmd_mov_data  between CTB.dt_inicio_vigencia and CTB.dt_fim_vigencia
                 or x.mtmd_mov_data >= cTB.dt_inicio_vigencia and cTB.dt_fim_vigencia is null );*/
      EXCEPTION 
          WHEN NO_DATA_FOUND THEN 
             RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU  GRUPO '||TO_CHAR(X.CAD_MTMD_GRUPO_ID)||
                                            ' UNIHOS '||TO_CHAR(vCODUNIHOS)||
                                            ' DATA '||TO_CHAR(X.mtmd_mov_data));
   --      WHEN OTHERS
      END;
      
      IF (vCD_CCUSTO IS NULL) THEN
          RAISE_APPLICATION_ERROR(-20000,' ERRO CD_CCUSTO NULL GRUPO '||TO_CHAR(x.CAD_MTMD_GRUPO_ID)||
                                           ' DATA '||TO_CHAR(x.MTMD_MOV_DATA)||
                                           ' SETOR '||TO_CHAR(x.CAD_SET_ID)||                                               
                                           ' CODUNIHOS '||TO_CHAR(vCODUNIHOS)||
                                           ' CD_CCUSTO '||TO_CHAR(vCD_CCUSTO)||
                                           SQLERRM);  
      END IF;   
      
      IF (X.MTMD_VALOR_ENTRADA > 0) THEN
      
         --vATD_ATE_ID --vSEQ
         FOR MOV IN (
                     SELECT NVL(M.ATD_ATE_ID,0) ATD_ATE_ID, SUM(M.MTMD_MOV_QTDE)
                       FROM TB_MTMD_MOV_MOVIMENTACAO M 
                      WHERE M.CAD_MTMD_ID = X.CAD_MTMD_ID
                      AND TRUNC(M.MTMD_MOV_DATA) = TRUNC(X.MTMD_MOV_DATA)
                      AND M.CAD_MTMD_TPMOV_ID = 1
                      AND M.CAD_MTMD_SUBTP_ID = X.CAD_MTMD_SUBTP_ID
                      AND M.CAD_SET_ID        = X.CAD_SET_ID 
                      AND M.CAD_MTMD_FILIAL_ID = X.CAD_MTMD_FILIAL_ID
                      GROUP BY ATD_ATE_ID )
         LOOP
         
           select count(*) into vCount from
            (SELECT NVL(M.ATD_ATE_ID,0) ATD_ATE_ID, SUM(M.MTMD_MOV_QTDE) FROM TB_MTMD_MOV_MOVIMENTACAO M 
               WHERE M.CAD_MTMD_ID = X.CAD_MTMD_ID
              AND TRUNC(M.MTMD_MOV_DATA) = TRUNC(X.MTMD_MOV_DATA)
              AND M.CAD_MTMD_TPMOV_ID = 1
              AND M.CAD_MTMD_SUBTP_ID = X.CAD_MTMD_SUBTP_ID
              AND M.CAD_SET_ID        = X.CAD_SET_ID 
              AND M.CAD_MTMD_FILIAL_ID = X.CAD_MTMD_FILIAL_ID
              GROUP BY ATD_ATE_ID);
         
           /*SELECT ((e.mtmd_qtde_entrada*e.mtmd_custo_medio_atual)/mov.QTD_REG) into vValor
             FROM TB_MTMD_MOV_ESTOQUE_DIA e
             WHERE TRUNC(MTMD_MOV_DATA)= TRUNC(X.MTMD_MOV_DATA)
             AND   CAD_MTMD_FILIAL_ID  = X.CAD_MTMD_FILIAL_ID
             AND   CAD_SET_ID          = X.CAD_SET_ID
             AND   CAD_MTMD_TPMOV_ID   = 1
             AND   CAD_MTMD_SUBTP_ID   = X.CAD_MTMD_SUBTP_ID
             AND   E.CAD_MTMD_ID       = X.CAD_MTMD_ID;*/            

            vValor := X.MTMD_VALOR_ENTRADA / vCount;
                                                     
           --CODCLADESAMB neste caso é um sequencial para não dar erro de constraint
           BEGIN
                SELECT CODCLADESAMB INTO vSEQ 
                  FROM ALM_RESUMO_MOVIMENTO_CTB
                  WHERE MESANO           = X.MTMD_MOV_DATA
                   AND CODHOS             = X.CAD_MTMD_FILIAL_ID
                   AND CODUNIHOS          = 2
                   AND TIPO_BAIXA         = 'D'
                   AND IND_TIPO_BAIXA     = 'N'
                   --AND CODCLADESAMB       = 18
                   AND CD_GRUPO_MATMED    = X.CAD_MTMD_GRUPO_ID
                   AND CD_SUBGRUPO_MATMED = 0
                   AND CD_CCUSTO          = vCD_CCUSTO
                   AND CODFILIAL          = 1
                   AND ATD_ATE_ID         = MOV.ATD_ATE_ID;
                   
                   UPDATE ALM_RESUMO_MOVIMENTO_CTB
                   SET VALOR = NVL(VALOR,0) + vValor
                   WHERE MESANO           = X.MTMD_MOV_DATA
                   AND CODHOS             = X.CAD_MTMD_FILIAL_ID
                   AND CODUNIHOS          = 2
                   AND TIPO_BAIXA         = 'D'
                   AND IND_TIPO_BAIXA     = 'N'
                   AND CODCLADESAMB       = vSEQ
                   AND CD_GRUPO_MATMED    = X.CAD_MTMD_GRUPO_ID
                   AND CD_SUBGRUPO_MATMED = 0
                   AND CD_CCUSTO          = vCD_CCUSTO
                   AND CODFILIAL          = 1
                   AND ATD_ATE_ID         = MOV.ATD_ATE_ID;
           EXCEPTION           
               WHEN NO_DATA_FOUND THEN 
               
                    SELECT NVL(MAX(CODCLADESAMB),0) INTO vSEQ 
                      FROM ALM_RESUMO_MOVIMENTO_CTB
                      WHERE MESANO            = X.MTMD_MOV_DATA
                       AND CODHOS             = X.CAD_MTMD_FILIAL_ID
                       AND CODUNIHOS          = 2
                       AND TIPO_BAIXA         = 'D'
                       AND IND_TIPO_BAIXA     = 'N'
                       --AND CODCLADESAMB       = 18
                       AND CD_GRUPO_MATMED    = X.CAD_MTMD_GRUPO_ID
                       AND CD_SUBGRUPO_MATMED = 0
                       AND CD_CCUSTO          = vCD_CCUSTO
                       AND CODFILIAL          = 1;
                   
                    INSERT INTO ALM_RESUMO_MOVIMENTO_CTB
                     ( MESANO,                CODHOS,                  CODUNIHOS,                TIPO_BAIXA,           IND_TIPO_BAIXA, 
                       CODCLADESAMB,          CD_GRUPO_MATMED,         CD_SUBGRUPO_MATMED,       VALOR,                CODCONTA_CRED,  
                       CODCONTA_DEB,          CODCONTA_DEB_GRUPO,      CD_CONTA_CRED,            CD_CONTA_DEB,         CD_CONTA_DEB_GRUPO,  
                       CD_PLANO,              CD_CCUSTO,               CODFILIAL,                ATD_ATE_ID )
                     VALUES
                     ( X.MTMD_MOV_DATA,       X.CAD_MTMD_FILIAL_ID,    2,                        'D',                  'N',
                       vSEQ+1,                X.CAD_MTMD_GRUPO_ID,     0,                        vValor,               vCODCONTA_DEB,
                       vCODCONTA_CRED,        NULL,                    NULL,                     NULL,                 NULL,
                       0,                     vCD_CCUSTO,              1,                        MOV.ATD_ATE_ID );
           END;
          END LOOP;         
       END IF;
   END IF;   

END LOOP;             
             
END;

/*

select * from ALM_RESUMO_MOVIMENTO_CTB
WHERE MESANO >= TO_DATE('01012012','DDMMYYYY')
AND   MESANO <= TO_DATE('31012012','DDMMYYYY')
AND   CODHOS = 2
AND TIPO_BAIXA = 'D'

*/

