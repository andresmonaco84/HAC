--       SETOR.CAD_SET_ID,     
/*
SELECT (mtmd_qtde_saida*mtmd_custo_medio_atual) valor
FROM TB_MTMD_MOV_ESTOQUE_DIA@dblp 
where CAD_MTMD_FILIAL_ID = 1
AND   mtmd_mov_data <= TO_DATE('30112010','DDMMYYYY')
*/

-- SELECT * FROM ALM_RESUMO_MOVIMENTO_CTB@DBLP WHERE MESANO >= TO_DATE('01112010','DDMMYYYY')
/*

select count(*) from ALM_RESUMO_MOVIMENTO_CTB
WHERE MESANO >= TO_DATE('01032014','DDMMYYYY')
AND   MESANO <= TO_DATE('31032014','DDMMYYYY')
--AND   CODHOS = 1

DELETE ALM_RESUMO_MOVIMENTO_CTB
WHERE MESANO >= TO_DATE('01032014','DDMMYYYY')
AND   MESANO <= TO_DATE('31032014','DDMMYYYY')
--AND   CODHOS = 1

*/

-- EXECUCAO ------------------------------------------------------------------------------------------
DECLARE vCODCONTA_CRED VARCHAR(20);    
        vCODCONTA_DEB VARCHAR(20);
        vCODFILIAL NUMBER(5);
        vID_CCUSTO NUMBER;
        vCD_CCUSTO VARCHAR(25);
        vTP_ATRIBUTO CHAR(3);
BEGIN
FOR EXP IN (
SELECT EST_DIA.MTMD_MOV_DATA,
       EST_DIA.CAD_MTMD_FILIAL_ID,
       EST_DIA.CAD_UNI_ID_UNIDADE,
       EST_DIA.CAD_LAT_ID_LOCAL_ATENDIMENTO, 
       EST_DIA.CAD_SET_ID,
       UNID.CAD_UNI_CD_UNID_HOSPITALAR CODUNIHOS,
       SETOR.CAD_SET_CD_SETOR,
       EST_DIA.CAD_MTMD_GRUPO_ID,
       EST_DIA.CAD_MTMD_SUBTP_ID,
       SUM(EST_DIA.MTMD_VALOR_SAIDA) VALOR_BAIXA,
       SUM(EST_DIA.MTMD_VALOR_ENTRADA) VALOR_ENTRADA
  FROM
  (SELECT DIAP.MTMD_MOV_DATA,         
          DIAP.CAD_MTMD_FILIAL_ID,
          DIAP.CAD_UNI_ID_UNIDADE,
          DIAP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
          DIAP.CAD_SET_ID, 
          DIAP.CAD_MTMD_GRUPO_ID,
          DIAP.CAD_MTMD_SUBTP_ID,
          MTMD.CAD_MTMD_ID,        
          MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,         
          SUM(
              (CASE
               WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA
               ELSE 0
               END )              
             ) MTMD_VALOR_SAIDA,
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
         WHERE MTMD_MOV_DATA                = TO_DATE('01032014 0000','DDMMYYYY HH24MI')
         --AND   (1 IS NULL OR CAD_MTMD_FILIAL_ID = 1)
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
         AND   MTMD_MOV_DATA >= TO_DATE('01032014 0000','DDMMYYYY HH24MI')
         AND   MTMD_MOV_DATA <= TO_DATE('31032014 2359','DDMMYYYY HH24MI')
         --AND   (1 IS NULL OR CAD_MTMD_FILIAL_ID = 1)
         --AND   MTMD_VALOR_ENTRADA != 0
         --AND   MTMD_QTDE_ENTRADA > 0
       
       ) NOTAS                
  WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('01032014 0000','DDMMYYYY HH24MI')
  AND   DIAP.MTMD_MOV_DATA <= TO_DATE('31032014 2359','DDMMYYYY HH24MI')
  --AND   DIAP.CAD_MTMD_FILIAL_ID             = 1
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
  --HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0) + NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) + NVL(DIAP.MTMD_VALOR_SAIDA,0) ) > 0 
  ) EST_DIA,
  TB_CAD_SET_SETOR           SETOR,
  TB_CAD_UNI_UNIDADE         UNID
  WHERE SETOR.cad_set_id                   = EST_DIA.cad_set_id
  AND   SETOR.cad_uni_id_unidade           = EST_DIA.cad_uni_id_unidade
  AND   SETOR.cad_lat_id_local_atendimento = EST_DIA.cad_lat_id_local_atendimento
  AND   UNID.cad_uni_id_unidade            = SETOR.cad_uni_id_unidade
  --AND   EST_DIA.CAD_MTMD_FILIAL_ID = 1
  GROUP BY EST_DIA.MTMD_MOV_DATA, 
           EST_DIA.CAD_MTMD_FILIAL_ID,
           EST_DIA.CAD_UNI_ID_UNIDADE, 
           EST_DIA.CAD_LAT_ID_LOCAL_ATENDIMENTO, 
           EST_DIA.CAD_SET_ID, 
           UNID.CAD_UNI_CD_UNID_HOSPITALAR,
           SETOR.CAD_SET_CD_SETOR,
           EST_DIA.CAD_MTMD_GRUPO_ID,
           EST_DIA.CAD_MTMD_SUBTP_ID
--  HAVING SUM(EST_DIA.MTMD_VALOR_SAIDA) > 0 OR SUM(EST_DIA.MTMD_VALOR_ENTRADA) > 0
  HAVING SUM(EST_DIA.MTMD_VALOR_SAIDA) != 0 OR SUM(EST_DIA.MTMD_VALOR_ENTRADA) != 0
ORDER BY  EST_DIA.MTMD_MOV_DATA, EST_DIA.cad_mtmd_grupo_id, EST_DIA.cad_mtmd_filial_id

) LOOP

   vTP_ATRIBUTO := 'MAT';
   IF (EXP.CAD_MTMD_GRUPO_ID = 1) THEN
      vTP_ATRIBUTO := 'MED';
   END IF;
   
   --BUSCA CENTRO DE CUSTO
   vID_CCUSTO := FNC_OBTER_CCUSTO(EXP.CAD_SET_ID,
                                vTP_ATRIBUTO,
                                NULL,
                                NULL,
                                NULL,
                                NULL,
                                SYSDATE);                                                                    
    IF (vID_CCUSTO = 0) THEN
       RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CD_CCUSTO PARA: '||
                                      ' CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                      ' CD_SETOR '||TO_CHAR(EXP.CAD_SET_CD_SETOR));
    END IF;
    IF (vID_CCUSTO IS NULL) THEN
          RAISE_APPLICATION_ERROR(-20000,' ERRO CD_CCUSTO NULL GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID)||
                                           ' DATA '||TO_CHAR(EXP.MTMD_MOV_DATA)||
                                           ' SETOR '||TO_CHAR(EXP.CAD_SET_ID)||                                               
                                           ' CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                           ' CD_CCUSTO '||TO_CHAR(vCD_CCUSTO)||
                                           SQLERRM);  
    END IF;
    
    SELECT C.CAD_CEC_CD_CCUSTO INTO vCD_CCUSTO 
    FROM TB_CAD_CEC_CENTRO_CUSTO C 
    WHERE C.CAD_CEC_ID_CCUSTO = vID_CCUSTO;
    
   /*BEGIN
     SELECT CD_CCUSTO INTO vCD_CCUSTO
       FROM HOSPITAL.TB_SETOR 
       WHERE CD_SETOR  = EXP.CAD_SET_CD_SETOR AND 
             CODUNIHOS = EXP.CODUNIHOS;
   EXCEPTION 
          WHEN NO_DATA_FOUND THEN 
             RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CD_CCUSTO PARA: '||
                                            ' CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                            ' CD_SETOR '||TO_CHAR(EXP.CAD_SET_CD_SETOR));
   END;*/
   
   --BUSCA FILIAL
   BEGIN
        SELECT SUBSTR(PSU.CAD_PES_NR_CNPJ_CPF, 11, 2) INTO vCODFILIAL
          FROM TB_CAD_UNI_UNIDADE     UNI,
               TB_CAD_PES_PESSOA      PSU
         WHERE UNI.CAD_UNI_ID_UNIDADE = EXP.CAD_UNI_ID_UNIDADE
           AND UNI.CAD_PES_ID_PESSOA = PSU.CAD_PES_ID_PESSOA;
     /*SELECT CODFILIAL INTO vCODFILIAL
       FROM UNIDADE_HOSPITALAR
       WHERE CODUNIHOS = EXP.CODUNIHOS;*/
   EXCEPTION 
          WHEN NO_DATA_FOUND THEN 
             RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CODFILIAL PARA: '||
                                            ' CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                            ' CD_SETOR '||TO_CHAR(EXP.CAD_SET_CD_SETOR));
   END;

   -- BUSCA CONTAS
   IF (  NVL(EXP.CAD_MTMD_GRUPO_ID,0) >0 ) THEN 
      BEGIN
        SELECT C.CAD_COD_CONTA_CRED, C.CAD_COD_CONTA_DEB 
        INTO   vCODCONTA_CRED,       vCODCONTA_DEB
        FROM SGS.TB_CAD_MTMD_CCONTAB_GRUPO C
        WHERE C.CAD_MTMD_COD_COLIGADA = EXP.CAD_MTMD_FILIAL_ID AND
              C.CAD_MTMD_GRUPO_ID     = EXP.CAD_MTMD_GRUPO_ID AND
              C.CAD_MTMD_TIPO_MOV     = DECODE(EXP.CAD_MTMD_SUBTP_ID, 6, 'Q', 'B') AND
              ( EXP.MTMD_MOV_DATA  BETWEEN C.CAD_MTMD_DT_INI_VIG AND C.CAD_MTMD_DT_FIM_VIG
                 OR EXP.MTMD_MOV_DATA >= C.CAD_MTMD_DT_INI_VIG AND C.CAD_MTMD_DT_FIM_VIG IS NULL );
      
         /*SELECT CTB.CODCONTA_CRED, CTB.CODCONTA_DEB
         INTO   vCODCONTA_CRED,    vCODCONTA_DEB
         FROM ALM_CONTA_CONTAB_GRUPO_CTB       CTB
         WHERE CTB.CODHOS          = EXP.CAD_MTMD_FILIAL_ID
         AND   CTB.CD_GRUPO_MATMED = EXP.CAD_MTMD_GRUPO_ID
         AND   CTB.TIPO_BAIXA   = DECODE(EXP.CAD_MTMD_SUBTP_ID, 6, 'Q', 'B')
         AND   CTB.CODCOLIGADA  = 1
         AND   CTB.CODUNIHOS    = EXP.CODUNIHOS
         --AND   CTB.CODCLADESAMB = DECODE( EXP.CODUNIHOS, 8, 32 , 9, 32, 24, 32, 27, 11, 18 )
         AND   CTB.CODCLADESAMB = DECODE( EXP.CODUNIHOS, 30, 32, 8, 32 , 9, 32, 24, 32, 27, 11, 28, 24, 18 )
         AND   ( EXP.mtmd_mov_data  between CTB.dt_inicio_vigencia and CTB.dt_fim_vigencia
                 or EXP.mtmd_mov_data >= cTB.dt_inicio_vigencia and cTB.dt_fim_vigencia is null );*/
      EXCEPTION 
          WHEN NO_DATA_FOUND THEN 
             RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU  GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID)||
                                            ' UNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                            ' DATA '||TO_CHAR(EXP.mtmd_mov_data));
   --      WHEN OTHERS
      END;
      
      IF (EXP.Valor_Baixa != 0) THEN
          BEGIN             
               INSERT INTO ALM_RESUMO_MOVIMENTO_CTB
               ( MESANO,                CODHOS,                  CODUNIHOS,                TIPO_BAIXA,           IND_TIPO_BAIXA, 
                 CODCLADESAMB,          CD_GRUPO_MATMED,         CD_SUBGRUPO_MATMED,       VALOR,                CODCONTA_CRED,  
                 CODCONTA_DEB,          CODCONTA_DEB_GRUPO,      CD_CONTA_CRED,            CD_CONTA_DEB,         CD_CONTA_DEB_GRUPO,  
                 CD_PLANO,              CD_CCUSTO,               CODFILIAL )
               VALUES
               ( EXP.MTMD_MOV_DATA,     EXP.CAD_MTMD_FILIAL_ID,  EXP.CODUNIHOS,            DECODE(EXP.CAD_MTMD_SUBTP_ID, 6, 'Q', 'B'),  'N',
                 18,                    EXP.CAD_MTMD_GRUPO_ID,   0,                        EXP.Valor_Baixa,      vCODCONTA_CRED,
                 vCODCONTA_DEB,         NULL,                    NULL,                     NULL,                 NULL,
                 0,                     vCD_CCUSTO,              vCODFILIAL );
          EXCEPTION           
             WHEN DUP_VAL_ON_INDEX THEN         
                 UPDATE ALM_RESUMO_MOVIMENTO_CTB
                 SET VALOR = NVL(VALOR,0) + EXP.Valor_Baixa
                 WHERE MESANO           = EXP.MTMD_MOV_DATA
                 AND CODHOS             = EXP.CAD_MTMD_FILIAL_ID
                 AND CODUNIHOS          = EXP.CODUNIHOS
                 AND TIPO_BAIXA         = DECODE(EXP.CAD_MTMD_SUBTP_ID, 6, 'Q', 'B')
                 AND IND_TIPO_BAIXA     = 'N'
                 AND CODCLADESAMB       = 18
                 AND CD_GRUPO_MATMED    = EXP.CAD_MTMD_GRUPO_ID
                 AND CD_SUBGRUPO_MATMED = 0
                 AND CD_CCUSTO          = vCD_CCUSTO
                 AND CODFILIAL          = vCODFILIAL;
              WHEN OTHERS THEN
                RAISE_APPLICATION_ERROR(-20000,' ERRO INSERT OTHERS GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID)||
                                               ' DATA '||TO_CHAR(EXP.MTMD_MOV_DATA)||
                                               ' SETOR '||TO_CHAR(EXP.CAD_SET_ID)||                                               
                                               ' CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                               ' CD_CCUSTO '||TO_CHAR(vCD_CCUSTO)||
                                               SQLERRM);  
          END;  
          
          IF (EXP.CODUNIHOS <> 2) THEN
              BEGIN             
                   INSERT INTO ALM_RESUMO_MOVIMENTO_CTB
                   ( MESANO,                CODHOS,                  CODUNIHOS,                TIPO_BAIXA,           IND_TIPO_BAIXA, 
                     CODCLADESAMB,          CD_GRUPO_MATMED,         CD_SUBGRUPO_MATMED,       VALOR,                CODCONTA_CRED,  
                     CODCONTA_DEB,          CODCONTA_DEB_GRUPO,      CD_CONTA_CRED,            CD_CONTA_DEB,         CD_CONTA_DEB_GRUPO,  
                     CD_PLANO,              CD_CCUSTO,               CODFILIAL )
                   VALUES
                   ( EXP.MTMD_MOV_DATA,     EXP.CAD_MTMD_FILIAL_ID,  2,                        'T',                  'N',
                     EXP.CODUNIHOS,         EXP.CAD_MTMD_GRUPO_ID,   0,                        EXP.Valor_Baixa,      vCODCONTA_CRED,
                     vCODCONTA_CRED,        NULL,                    NULL,                     NULL,                 NULL,
                     0,                     vCD_CCUSTO,              1 );
              EXCEPTION           
                 WHEN DUP_VAL_ON_INDEX THEN         
                     UPDATE ALM_RESUMO_MOVIMENTO_CTB
                     SET VALOR = NVL(VALOR,0) + EXP.Valor_Baixa
                     WHERE MESANO           = EXP.MTMD_MOV_DATA
                     AND CODHOS             = EXP.CAD_MTMD_FILIAL_ID
                     AND CODUNIHOS          = 2
                     AND TIPO_BAIXA         = 'T'
                     AND IND_TIPO_BAIXA     = 'N'
                     AND CODCLADESAMB       = EXP.CODUNIHOS
                     AND CD_GRUPO_MATMED    = EXP.CAD_MTMD_GRUPO_ID
                     AND CD_SUBGRUPO_MATMED = 0
                     AND CD_CCUSTO          = vCD_CCUSTO
                     AND CODFILIAL          = 1;--vCODFILIAL;
                  WHEN OTHERS THEN
                    RAISE_APPLICATION_ERROR(-20000,' ERRO INSERT OTHERS GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID)||
                                                   ' SETOR '||TO_CHAR(EXP.CAD_SET_ID)||
                                                   ' DATA '||TO_CHAR(EXP.MTMD_MOV_DATA)||
                                                   SQLERRM);  
              END; 
          END IF;   
      END IF;  
      
      IF (EXP.Valor_Entrada > 0) THEN
         BEGIN             
               /*INSERT INTO ALM_RESUMO_MOVIMENTO_CTB
               ( MESANO,                CODHOS,                  CODUNIHOS,                TIPO_BAIXA,           IND_TIPO_BAIXA, 
                 CODCLADESAMB,          CD_GRUPO_MATMED,         CD_SUBGRUPO_MATMED,       VALOR,                CODCONTA_CRED,  
                 CODCONTA_DEB,          CODCONTA_DEB_GRUPO,      CD_CONTA_CRED,            CD_CONTA_DEB,         CD_CONTA_DEB_GRUPO,  
                 CD_PLANO,              CD_CCUSTO,               CODFILIAL )
               VALUES
               ( EXP.MTMD_MOV_DATA,     EXP.CAD_MTMD_FILIAL_ID,  EXP.CODUNIHOS,             'D',                  'N',
                 18,                    EXP.CAD_MTMD_GRUPO_ID,   0,                         EXP.Valor_Entrada,    vCODCONTA_DEB,
                 vCODCONTA_CRED,         NULL,                    NULL,                     NULL,                 NULL,
                 0,                     vCD_CCUSTO,               vCODFILIAL );*/
                 
               --PARA FEVEREIRO VOLTAR O INSERT E UPDATE COMENTADO (TROCAR)
               
               INSERT INTO ALM_RESUMO_MOVIMENTO_CTB
               ( MESANO,                CODHOS,                  CODUNIHOS,                TIPO_BAIXA,           IND_TIPO_BAIXA, 
                 CODCLADESAMB,          CD_GRUPO_MATMED,         CD_SUBGRUPO_MATMED,       VALOR,                CODCONTA_CRED,  
                 CODCONTA_DEB,          CODCONTA_DEB_GRUPO,      CD_CONTA_CRED,            CD_CONTA_DEB,         CD_CONTA_DEB_GRUPO,  
                 CD_PLANO,              CD_CCUSTO,               CODFILIAL )
               VALUES
               ( EXP.MTMD_MOV_DATA,     EXP.CAD_MTMD_FILIAL_ID,  2,                         'D',                  'N',
                 18,                    EXP.CAD_MTMD_GRUPO_ID,   0,                         EXP.Valor_Entrada,    vCODCONTA_DEB,
                 vCODCONTA_CRED,         NULL,                   NULL,                     NULL,                 NULL,
                 0,                     vCD_CCUSTO,              1 );
         EXCEPTION           
             WHEN DUP_VAL_ON_INDEX THEN         
                /* UPDATE ALM_RESUMO_MOVIMENTO_CTB
                 SET VALOR = NVL(VALOR,0) + EXP.Valor_Entrada
                 WHERE MESANO           = EXP.MTMD_MOV_DATA
                 AND CODHOS             = EXP.CAD_MTMD_FILIAL_ID
                 AND CODUNIHOS          = EXP.CODUNIHOS
                 AND TIPO_BAIXA         = 'D'
                 AND IND_TIPO_BAIXA     = 'N'
                 AND CODCLADESAMB       = 18
                 AND CD_GRUPO_MATMED    = EXP.CAD_MTMD_GRUPO_ID
                 AND CD_SUBGRUPO_MATMED = 0
                 AND CD_CCUSTO          = vCD_CCUSTO
                 AND CODFILIAL          = vCODFILIAL;*/
                 UPDATE ALM_RESUMO_MOVIMENTO_CTB
                 SET VALOR = NVL(VALOR,0) + EXP.Valor_Entrada
                 WHERE MESANO           = EXP.MTMD_MOV_DATA
                 AND CODHOS             = EXP.CAD_MTMD_FILIAL_ID
                 AND CODUNIHOS          = 2
                 AND TIPO_BAIXA         = 'D'
                 AND IND_TIPO_BAIXA     = 'N'
                 AND CODCLADESAMB       = 18
                 AND CD_GRUPO_MATMED    = EXP.CAD_MTMD_GRUPO_ID
                 AND CD_SUBGRUPO_MATMED = 0
                 AND CD_CCUSTO          = vCD_CCUSTO
                 AND CODFILIAL          = 1;
              WHEN OTHERS THEN
                RAISE_APPLICATION_ERROR(-20000,' ERRO INSERT OTHERS GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID)||
                                               ' SETOR '||TO_CHAR(EXP.CAD_SET_ID)||
                                               ' DATA '||TO_CHAR(EXP.MTMD_MOV_DATA)||
                                               SQLERRM);  
          END; 
       END IF;
   END IF;

END LOOP; 
-- COMMIT;
END;
-- FIM EXECUCAO ------------------------------------------------------------------------------------------









-- TESTE PRE-EXECUCAO ------------------------------------------------------------------------------------------
/*
DECLARE vCODCONTA_CRED VARCHAR(20);    
        vCODCONTA_DEB VARCHAR(20);
        vCODFILIAL NUMBER(5);
        vID_CCUSTO NUMBER;
        vCD_CCUSTO VARCHAR(25);
        vErro VARCHAR(3000):='';  
        vTP_ATRIBUTO CHAR(3);
        vTemErro boolean:=false;  
BEGIN
FOR EXP IN (
SELECT EST_DIA.MTMD_MOV_DATA,
       EST_DIA.CAD_MTMD_FILIAL_ID,
       EST_DIA.CAD_UNI_ID_UNIDADE,
       EST_DIA.CAD_LAT_ID_LOCAL_ATENDIMENTO, 
       EST_DIA.CAD_SET_ID,
       UNID.CAD_UNI_CD_UNID_HOSPITALAR CODUNIHOS,
       SETOR.CAD_SET_CD_SETOR,
       EST_DIA.CAD_MTMD_GRUPO_ID,
       SUM(EST_DIA.MTMD_VALOR_SAIDA) VALOR_BAIXA,
       SUM(EST_DIA.MTMD_VALOR_ENTRADA) VALOR_ENTRADA
  FROM
  (SELECT DIAP.MTMD_MOV_DATA,         
          DIAP.CAD_MTMD_FILIAL_ID,
          DIAP.CAD_UNI_ID_UNIDADE,
          DIAP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
          DIAP.CAD_SET_ID, 
          DIAP.CAD_MTMD_GRUPO_ID,
          MTMD.CAD_MTMD_ID,        
          MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,         
          SUM(
              (CASE
               WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA
               ELSE 0
               END )              
             ) MTMD_VALOR_SAIDA,
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
         AND   (1 IS NULL OR CAD_MTMD_FILIAL_ID = 1)
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
         AND   (1 IS NULL OR CAD_MTMD_FILIAL_ID = 1)
         AND   MTMD_VALOR_ENTRADA != 0
         AND   MTMD_QTDE_ENTRADA > 0
       
       ) NOTAS                
  WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('01022012 0000','DDMMYYYY HH24MI')
  AND   DIAP.MTMD_MOV_DATA <= TO_DATE('29022012 2359','DDMMYYYY HH24MI')
  AND   DIAP.CAD_MTMD_FILIAL_ID             = 1
  AND  MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
  AND  LINHA_ZERO.CAD_MTMD_ID(+)            = DIAP.CAD_MTMD_ID
  AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)     = DIAP.CAD_MTMD_FILIAL_ID
  AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)      = DIAP.CAD_MTMD_GRUPO_ID
  AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
  AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
  AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
  AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID
  AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID
  AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
  AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
  GROUP BY DIAP.MTMD_MOV_DATA,
           DIAP.CAD_UNI_ID_UNIDADE,
           DIAP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           DIAP.CAD_SET_ID,
           DIAP.CAD_MTMD_GRUPO_ID,
           MTMD.CAD_MTMD_ID,   
           DIAP.CAD_MTMD_FILIAL_ID,  
           MTMD.CAD_MTMD_NOMEFANTASIA,
           LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
           LINHA_ZERO.MTMD_SALDO_ATUAL,       
           LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
           LINHA_ZERO.MTMD_VALOR_ATUAL,       
           LINHA_ZERO.MTMD_SALDO_ANTERIOR,
           LINHA_ZERO.MTMD_VALOR_ANTERIOR
  --HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0) + NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0 
  ) EST_DIA,
  TB_CAD_SET_SETOR           SETOR,
  TB_CAD_UNI_UNIDADE         UNID
  WHERE SETOR.cad_set_id                   = EST_DIA.cad_set_id
  AND   SETOR.cad_uni_id_unidade           = EST_DIA.cad_uni_id_unidade
  AND   SETOR.cad_lat_id_local_atendimento = EST_DIA.cad_lat_id_local_atendimento
  AND   UNID.cad_uni_id_unidade            = SETOR.cad_uni_id_unidade
  GROUP BY EST_DIA.MTMD_MOV_DATA, 
           EST_DIA.CAD_MTMD_FILIAL_ID,
           EST_DIA.CAD_UNI_ID_UNIDADE, 
           EST_DIA.CAD_LAT_ID_LOCAL_ATENDIMENTO, 
           EST_DIA.CAD_SET_ID, 
           UNID.CAD_UNI_CD_UNID_HOSPITALAR,
           SETOR.CAD_SET_CD_SETOR,
           EST_DIA.CAD_MTMD_GRUPO_ID
  HAVING SUM(EST_DIA.MTMD_VALOR_SAIDA) > 0 OR SUM(EST_DIA.MTMD_VALOR_ENTRADA) > 0
ORDER BY  EST_DIA.MTMD_MOV_DATA, EST_DIA.cad_mtmd_grupo_id, EST_DIA.cad_mtmd_filial_id

) LOOP

   vTP_ATRIBUTO := 'MAT';
   IF (EXP.CAD_MTMD_GRUPO_ID = 1) THEN
      vTP_ATRIBUTO := 'MED';
   END IF;
   
   --BUSCA CENTRO DE CUSTO
   vID_CCUSTO := FNC_OBTER_CCUSTO(EXP.CAD_SET_ID,
                                vTP_ATRIBUTO,
                                NULL,
                                NULL,
                                NULL,
                                NULL,
                                SYSDATE);
                                
    IF (vID_CCUSTO = 0) THEN
       RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CD_CCUSTO PARA: '||
                                      ' CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                      ' CD_SETOR '||TO_CHAR(EXP.CAD_SET_CD_SETOR));
    END IF;
   
   --BUSCA FILIAL
   BEGIN
       SELECT SUBSTR(PSU.CAD_PES_NR_CNPJ_CPF, 11, 2) INTO vCODFILIAL
          FROM TB_CAD_UNI_UNIDADE     UNI,
               TB_CAD_PES_PESSOA      PSU
         WHERE UNI.CAD_UNI_ID_UNIDADE = EXP.CAD_UNI_ID_UNIDADE
           AND UNI.CAD_PES_ID_PESSOA = PSU.CAD_PES_ID_PESSOA;
     --SELECT CODFILIAL INTO vCODFILIAL
       --FROM UNIDADE_HOSPITALAR
       --WHERE CODUNIHOS = EXP.CODUNIHOS;
   EXCEPTION 
          WHEN NO_DATA_FOUND THEN 
             RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CODFILIAL PARA: '||
                                            ' CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                            ' CD_SETOR '||TO_CHAR(EXP.CAD_SET_CD_SETOR));
   END;
   
   IF (vCODFILIAL IS NULL) THEN   
      RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CODFILIAL PARA: '||
                                      ' CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                      ' CD_SETOR '||TO_CHAR(EXP.CAD_SET_CD_SETOR));
   END IF;

   -- BUSCA CONTAS
   IF (  NVL(EXP.CAD_MTMD_GRUPO_ID,0) >0 ) THEN 
      BEGIN
         SELECT C.CAD_COD_CONTA_CRED, C.CAD_COD_CONTA_DEB 
        INTO   vCODCONTA_CRED,       vCODCONTA_DEB
        FROM SGS.TB_CAD_MTMD_CCONTAB_GRUPO C
        WHERE C.CAD_MTMD_COD_COLIGADA = EXP.CAD_MTMD_FILIAL_ID AND
              C.CAD_MTMD_GRUPO_ID     = EXP.CAD_MTMD_GRUPO_ID AND
              C.CAD_MTMD_TIPO_MOV     = 'B' AND
              ( EXP.MTMD_MOV_DATA  BETWEEN C.CAD_MTMD_DT_INI_VIG AND C.CAD_MTMD_DT_FIM_VIG
                 OR EXP.MTMD_MOV_DATA >= C.CAD_MTMD_DT_INI_VIG AND C.CAD_MTMD_DT_FIM_VIG IS NULL );
      EXCEPTION 
          WHEN NO_DATA_FOUND THEN 
             --RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU CONTA GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID)||
                                            --' UNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                            --' DATA '||TO_CHAR(EXP.mtmd_mov_data));
             vTemErro := true;
             vErro := 'NAO ACHOU CONTA PARA: CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||' CD_SETOR '||TO_CHAR(EXP.CAD_SET_CD_SETOR)||' GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID||' CD_SETOR '||TO_CHAR(EXP.CAD_SET_CD_SETOR)||' '||EXP.CAD_SET_ID);                                            
             Dbms_Output.put_line(vErro);                                                                       
   --      WHEN OTHERS
      END;
   END IF;
   
   IF (vID_CCUSTO IS NULL) THEN
       vTemErro := true;
       vErro := 'CD_CCUSTO NULL PARA: CODUNIHOS '||TO_CHAR(EXP.CODUNIHOS)||' CD_SETOR '||TO_CHAR(EXP.CAD_SET_CD_SETOR)||' GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID||' ID_SETOR '||EXP.CAD_SET_ID);
       Dbms_Output.put_line(vErro);   
   END IF;

END LOOP; 

--IF (vTemErro) THEN
  --    RAISE_APPLICATION_ERROR(-20000,'1-NAO ACHOU CD_CCUSTO PARA: '|| vErro);                                            
--END IF;
   
-- COMMIT;
END;
*/
-- FIM TESTE PRE-EXECUCAO ------------------------------------------------------------------------------------------











-- VERSAO ANTIGA ------------------------------------------------------------------------------------------
/*DECLARE vCODCONTA_CRED VARCHAR(20);    vCODCONTA_DEB VARCHAR(20);
BEGIN
FOR EXP IN (
SELECT DIA.CAD_MTMD_FILIAL_ID,     
       DIA.mtmd_mov_data, 
       DIA.CAD_MTMD_GRUPO_ID,   
       SET_LEG.codunihos,       
       SET_LEG.CD_CCUSTO, 
       HOSP.CODFILIAL,
      SUM(DIA.MTMD_VALOR_SAIDA) VALOR_BAIXA,
      SUM(DIA.MTMD_VALOR_ENTRADA) VALOR_ENTRADA
FROM TB_MTMD_MOV_ESTOQUE_DIA    DIA,
     TB_CAD_SET_SETOR           SETOR,
     TB_CAD_UNI_UNIDADE         UNID,
     TB_SETOR                   SET_LEG,
     UNIDADE_HOSPITALAR         HOSP
WHERE --DIA.cad_mtmd_filial_id             = 1
      DIA.mtmd_mov_data >= TO_DATE('01022011 0000','DDMMYYYY HH24MI')
AND   DIA.mtmd_mov_data <= TO_DATE('28022011 2359','DDMMYYYY HH24MI')
AND   DIA.CAD_MTMD_SUBTP_ID NOT IN (1,15,0)
AND   SETOR.cad_set_id                   = DIA.cad_set_id
AND   SETOR.cad_uni_id_unidade           = DIA.cad_uni_id_unidade
AND   SETOR.cad_lat_id_local_atendimento = DIA.cad_lat_id_local_atendimento
AND   UNID.cad_uni_id_unidade            = SETOR.cad_uni_id_unidade
AND   SET_LEG.cd_setor                   = SETOR.CAD_SET_CD_SETOR
AND   SET_LEG.codunihos                  = UNID.CAD_UNI_CD_UNID_HOSPITALAR
AND   HOSP.CODUNIHOS                     = SET_LEG.CODUNIHOS
AND  DIA.CAD_MTMD_GRUPO_ID NOT IN (40,42)
GROUP BY DIA.cad_mtmd_filial_id,     
       DIA.mtmd_mov_data, 
       DIA.CAD_MTMD_GRUPO_ID,   
       SET_LEG.codunihos,       
       SET_LEG.CD_CCUSTO, 
       HOSP.CODFILIAL
ORDER BY  DIA.MTMD_MOV_DATA, DIA.cad_mtmd_grupo_id, DIA.cad_mtmd_filial_id

) LOOP

-- SELECT * FROM Alm_resumo_movimento_CTB WHERE MESANO >= TO_DATE('01112010','DDMMYYYY')
-- DELETE  Alm_resumo_movimento_CTB WHERE MESANO >= TO_DATE('01112010','DDMMYYYY')

   -- BUSCA CONTAS
   IF (  NVL(EXP.CAD_MTMD_GRUPO_ID,0) >0 ) THEN 
      BEGIN
         SELECT CTB.CODCONTA_CRED, CTB.CODCONTA_DEB
         INTO   vCODCONTA_CRED,    vCODCONTA_DEB
         FROM ALM_CONTA_CONTAB_GRUPO_CTB       CTB
         WHERE CTB.CODHOS          = EXP.CAD_MTMD_FILIAL_ID
         AND   CTB.CD_GRUPO_MATMED = EXP.CAD_MTMD_GRUPO_ID
         AND   CTB.TIPO_BAIXA   = 'B'
         AND   CTB.CODCOLIGADA  = 1
         AND   CTB.CODUNIHOS    = EXP.CODUNIHOS
         AND   CTB.CODCLADESAMB = DECODE( EXP.CODUNIHOS, 8, 32 , 9, 32, 24, 32, 27, 11, 18 )
         AND   ( EXP.mtmd_mov_data  between CTB.dt_inicio_vigencia and CTB.dt_fim_vigencia
                 or EXP.mtmd_mov_data >= cTB.dt_inicio_vigencia and cTB.dt_fim_vigencia is null );
      EXCEPTION 
          WHEN NO_DATA_FOUND THEN 
             RAISE_APPLICATION_ERROR(-20000,' NAO ACHOU  GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID)||
                                            ' UNIHOS '||TO_CHAR(EXP.CODUNIHOS)||
                                            ' DATA '||TO_CHAR(EXP.mtmd_mov_data));
   --      WHEN OTHERS
      END;
   
      BEGIN
         IF (EXP.Valor_Baixa > 0) THEN
           INSERT INTO ALM_RESUMO_MOVIMENTO_CTB
           ( MESANO,                CODHOS,                  CODUNIHOS,                TIPO_BAIXA,           IND_TIPO_BAIXA, 
             CODCLADESAMB,          CD_GRUPO_MATMED,         CD_SUBGRUPO_MATMED,       VALOR,                CODCONTA_CRED,  
             CODCONTA_DEB,          CODCONTA_DEB_GRUPO,      CD_CONTA_CRED,            CD_CONTA_DEB,         CD_CONTA_DEB_GRUPO,  
             CD_PLANO,              CD_CCUSTO,               CODFILIAL )
           VALUES
           ( EXP.MTMD_MOV_DATA,     EXP.CAD_MTMD_FILIAL_ID,  EXP.CODUNIHOS,            'B',                  'N',
             18,                    EXP.CAD_MTMD_GRUPO_ID,   0,                        EXP.Valor_Baixa,      vCODCONTA_CRED,
             vCODCONTA_DEB,         NULL,                    NULL,                     NULL,                 NULL,
             0,                     EXP.CD_CCUSTO,           exp.codfilial );             
             
            IF (CODUNIHOS <> 2) THEN
               INSERT INTO ALM_RESUMO_MOVIMENTO_CTB
               ( MESANO,                CODHOS,                  CODUNIHOS,                TIPO_BAIXA,           IND_TIPO_BAIXA, 
                 CODCLADESAMB,          CD_GRUPO_MATMED,         CD_SUBGRUPO_MATMED,       VALOR,                CODCONTA_CRED,  
                 CODCONTA_DEB,          CODCONTA_DEB_GRUPO,      CD_CONTA_CRED,            CD_CONTA_DEB,         CD_CONTA_DEB_GRUPO,  
                 CD_PLANO,              CD_CCUSTO,               CODFILIAL )
               VALUES
               ( EXP.MTMD_MOV_DATA,     EXP.CAD_MTMD_FILIAL_ID,  2,                        'T',                  'N',
                 EXP.CODUNIHOS,         EXP.CAD_MTMD_GRUPO_ID,   0,                        EXP.Valor_Baixa,      vCODCONTA_CRED,
                 vCODCONTA_CRED,        NULL,                    NULL,                     NULL,                 NULL,
                 0,                     EXP.CD_CCUSTO,           exp.codfilial );
            END IF;
         END IF;  
         
         IF (EXP.Valor_Entrada > 0) THEN
           INSERT INTO ALM_RESUMO_MOVIMENTO_CTB
           ( MESANO,                CODHOS,                  CODUNIHOS,                TIPO_BAIXA,           IND_TIPO_BAIXA, 
             CODCLADESAMB,          CD_GRUPO_MATMED,         CD_SUBGRUPO_MATMED,       VALOR,                CODCONTA_CRED,  
             CODCONTA_DEB,          CODCONTA_DEB_GRUPO,      CD_CONTA_CRED,            CD_CONTA_DEB,         CD_CONTA_DEB_GRUPO,  
             CD_PLANO,              CD_CCUSTO,               CODFILIAL )
           VALUES
           ( EXP.MTMD_MOV_DATA,     EXP.CAD_MTMD_FILIAL_ID,  EXP.CODUNIHOS,            'D',                  'N',
             18,                    EXP.CAD_MTMD_GRUPO_ID,   0,                         EXP.Valor_Entrada,    vCODCONTA_DEB,
             vCODCONTA_CRED,         NULL,                    NULL,                     NULL,                 NULL,
             0,                     EXP.CD_CCUSTO,           exp.codfilial );
         END IF;
      EXCEPTION           
         WHEN DUP_VAL_ON_INDEX THEN
         \*
             UPDATE ALM_RESUMO_MOVIMENTO_CTB
             SET VALOR = NVL(VALOR,0) + EXP.VALOR
             WHERE MESANO             = EXP.MTMD_MOV_DATA
             AND CODHOS             = EXP.CODHOS
             AND CODUNIHOS          = EXP.CODUNIHOS
             AND TIPO_BAIXA         = EXP.TIPO_BAIXA
             AND IND_TIPO_BAIXA     = 'N'
             AND CODCLADESAMB       = 18
             AND CD_GRUPO_MATMED    = EXP.CAD_MTMD_GRUPO_ID
             AND CD_SUBGRUPO_MATMED = 0
             AND CD_CCUSTO          = EXP.CD_CCUSTO
             AND CODFILIAL          = exp.codfilial;
         *\
            RAISE_APPLICATION_ERROR(-20000,' ERRO DUP_VAL_ON_INDEX GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID)||
   --                                        ' SETOR '||TO_CHAR(EXP.CAD_SET_ID)||
                                           ' DATA '||TO_CHAR(EXP.mtmd_mov_data)||
                                           SQLERRM);  
          WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,' ERRO OTHERS GRUPO '||TO_CHAR(EXP.CAD_MTMD_GRUPO_ID)||
                                           ' SETOR '||TO_CHAR(EXP.CODUNIHOS)||
                                           ' DATA '||TO_CHAR(EXP.mtmd_mov_data)||
                                           SQLERRM);  
      END;  
   END IF;

END LOOP; 
-- COMMIT;
END;*/

/*
select * from ALM_RESUMO_MOVIMENTO_CTB
WHERE MESANO >= TO_DATE('01022011','DDMMYYYY')
AND   MESANO <= TO_DATE('28022011','DDMMYYYY')
and tipo_baixa = 'B'
and codhos = 1
*/