DECLARE

valBaixar NUMBER := 0;
valEntrar NUMBER := 0;
qtdBaixar NUMBER := 0;
qtdEntrar NUMBER := 0;
CAD_UNI_ID_UNIDADE_MOV   NUMBER := 244;
ID_LOCAL_ATENDIMENTO_MOV NUMBER := 33;
CAD_SET_ID_MOV           NUMBER := 29;
vCAD_MTMD_TPMOV_ID NUMBER;
vCAD_MTMD_SUBTP_ID NUMBER;
vSALDO_ATUAL NUMBER;
vVALOR_ATUAL NUMBER;
BEGIN

FOR CONT IN (SELECT MTMD.CAD_MTMD_ID,
                     MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,
                     MTMD.CAD_MTMD_CODMNE,
                     MTMD.CAD_MTMD_UNID_CONTROLE_DS,
                     LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                     LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                     GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                     SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
                     --DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO,
                     LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL MTMD_CUSTO_MEDIO,
                     (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                        FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                               WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                     --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                     --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                     --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                     --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                     --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                     MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2016 || LPAD(TO_CHAR(12), 2, '0')
                                     ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                               WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) MTMD_SALDO_FISICO,
                      /*TRUNC((SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                        FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                               WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                     --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                     --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                     --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                     --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                     --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                     MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                     ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                               WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) *
                               LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 2) MTMD_VALOR_FISICO,*/
                      DECODE(LINHA_ZERO.MTMD_SALDO_ATUAL, 
                             (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                                FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                                       WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                             --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                             --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                             --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                             --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                             --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                             MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2016 || LPAD(TO_CHAR(12), 2, '0')
                                             ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                                       WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ), 
                              NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0),
                              TRUNC((SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                                FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                                       WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                             --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                             --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                             --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                             --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                             --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                             MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2016 || LPAD(TO_CHAR(12), 2, '0')
                                             ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                                       WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) * LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 2)) MTMD_VALOR_FISICO,
                      LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,
                      LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL
              FROM TB_CAD_MTMD_MAT_MED MTMD,
                   TB_CAD_MTMD_GRUPO GRUPO,
                   TB_CAD_MTMD_SUBGRUPO SUBGRUPO,
                   TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                   (
                     SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = TO_DATE( '01122016 0000','DDMMYYYY HH24MI')
                     AND   ( CAD_MTMD_FILIAL_ID = 1 )
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO
              WHERE DIAP.MTMD_MOV_DATA >= TO_DATE( '01122016 0000','DDMMYYYY HH24MI')
              AND   DIAP.MTMD_MOV_DATA <= TO_DATE( '31122016 0000','DDMMYYYY HH24MI')
              AND   ( DIAP.CAD_MTMD_FILIAL_ID = 1 )
              AND   ( DIAP.CAD_MTMD_ID = 775 )
            --  AND   ( pCAD_MTMD_GRUPO_ID IS NULL OR DIAP.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )
              AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
              AND   GRUPO.CAD_MTMD_GRUPO_ID             = LINHA_ZERO.CAD_MTMD_GRUPO_ID
              AND   (SUBGRUPO.CAD_MTMD_GRUPO_ID(+)         = LINHA_ZERO.CAD_MTMD_GRUPO_ID
              AND   SUBGRUPO.CAD_MTMD_SUBGRUPO_ID(+)       = LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID)
              AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
              AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
              AND  (LINHA_ZERO.CAD_MTMD_GRUPO_ID != 4 OR LINHA_ZERO.MTMD_VALOR_ATUAL != 0) -- N?o trazer SND
              AND  NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL
             /* AND  (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                      FROM (SELECT CAD_MTMD_ID, MTMD_MOV_SALDO FROM TB_MTMD_MOV_MES MM
                             WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                   MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2016 || LPAD(TO_CHAR(12), 2, '0')
                                   ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                             WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) != LINHA_ZERO.MTMD_SALDO_ATUAL*/
              GROUP BY MTMD.CAD_MTMD_ID,
                       DIAP.CAD_MTMD_FILIAL_ID,
                       MTMD.CAD_MTMD_NOMEFANTASIA,
                       MTMD.CAD_MTMD_CODMNE,
                       MTMD.CAD_MTMD_UNID_CONTROLE_DS,
                       LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                       LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                       GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                       SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                       LINHA_ZERO.MTMD_SALDO_ATUAL,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                       LINHA_ZERO.MTMD_VALOR_ATUAL,
                       LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                       LINHA_ZERO.MTMD_VALOR_ANTERIOR
              --HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
              HAVING (SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0 OR LINHA_ZERO.MTMD_SALDO_ATUAL = 0)
              UNION
              SELECT MES.CAD_MTMD_ID,
                     M.CAD_MTMD_NOMEFANTASIA DESCRICAO,
                     M.CAD_MTMD_CODMNE,
                     M.CAD_MTMD_UNID_CONTROLE_DS,
                     M.CAD_MTMD_GRUPO_ID,
                     M.CAD_MTMD_SUBGRUPO_ID,
                     G.CAD_MTMD_GRUPO_DESCRICAO,
                     S.CAD_MTMD_SUBGRUPO_DESCRICAO,       
                     FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, 
                                            ADD_MONTHS(TO_DATE('01122016 0000','DDMMYYYY HH24MI'),-12), 
                                            TO_DATE('31122016 0000','DDMMYYYY HH24MI')) MTMD_CUSTO_MEDIO,                              
                     MES.MTMD_MOV_SALDO MTMD_SALDO_FISICO,
                     (TRUNC(FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, 
                                                    ADD_MONTHS(TO_DATE('01122016 0000','DDMMYYYY HH24MI'),-12), 
                                                    TO_DATE('31122016 0000','DDMMYYYY HH24MI')) *
                     MES.MTMD_MOV_SALDO,2)) MTMD_VALOR_FISICO,       
                     0 MTMD_SALDO_ATUAL,
                     0 MTMD_VALOR_ATUAL
              FROM TB_MTMD_MOV_MES MES JOIN 
                   TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = MES.CAD_MTMD_ID JOIN
                   TB_CAD_MTMD_GRUPO G ON G.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID JOIN
                   TB_CAD_MTMD_SUBGRUPO S ON S.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID AND S.CAD_MTMD_SUBGRUPO_ID = M.CAD_MTMD_SUBGRUPO_ID
              WHERE MES.MTMD_MOV_ANO = 2016 
                AND MES.MTMD_MOV_MES = 12
                AND MES.CAD_MTMD_FILIAL_ID = 1 AND M.CAD_MTMD_GRUPO_ID NOT IN (4)
                AND MES.MTMD_MOV_SALDO > 0
                AND ( MES.CAD_MTMD_ID = 775 ) --AND DIAP.CAD_MTMD_ID = 775 )
                AND MES.CAD_MTMD_ID 
              NOT IN (SELECT DISTINCT MTMD.CAD_MTMD_ID
                        FROM TB_CAD_MTMD_MAT_MED MTMD,
                             TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                             (
                               SELECT *
                               FROM TB_MTMD_MOV_ESTOQUE_DIA
                               WHERE MTMD_MOV_DATA                = TO_DATE( '01122016 0000','DDMMYYYY HH24MI')
                               AND   ( CAD_MTMD_FILIAL_ID = 1 )
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
                               AND   MTMD_MOV_DATA >= TO_DATE( '01122016 0000','DDMMYYYY HH24MI')
                               AND   MTMD_MOV_DATA <= TO_DATE( '31122016 0000','DDMMYYYY HH24MI')
                               AND   ( CAD_MTMD_FILIAL_ID = 1 )
                             ) NOTAS                
                        WHERE DIAP.MTMD_MOV_DATA >= TO_DATE( '01122016 0000','DDMMYYYY HH24MI')
                        AND   DIAP.MTMD_MOV_DATA <= TO_DATE( '31122016 0000','DDMMYYYY HH24MI')
                        AND   ( DIAP.CAD_MTMD_FILIAL_ID = 1 )
                        AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
                        AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
                        AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
                        AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
                        AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
                        AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
                        AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
                        AND  NOTAS.CAD_MTMD_TPMOV_ID(+)   = DIAP.CAD_MTMD_TPMOV_ID
                        AND  NOTAS.CAD_MTMD_SUBTP_ID(+)   = DIAP.CAD_MTMD_SUBTP_ID
                        AND NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL                        
                        GROUP BY MTMD.CAD_MTMD_ID,   
                                 DIAP.CAD_MTMD_FILIAL_ID,  
                                 MTMD.CAD_MTMD_NOMEFANTASIA,
                                 LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                                 LINHA_ZERO.MTMD_SALDO_ATUAL,       
                                 LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                                 LINHA_ZERO.MTMD_VALOR_ATUAL,       
                                 LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                                 LINHA_ZERO.MTMD_VALOR_ANTERIOR
                        HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0)
                        
) 
LOOP        
    qtdBaixar := 0; 
    qtdEntrar := 0;       
    valBaixar := 0;
    valEntrar := 0;
    
    IF (CONT.MTMD_VALOR_ATUAL > CONT.MTMD_VALOR_FISICO OR CONT.MTMD_SALDO_ATUAL > CONT.MTMD_SALDO_FISICO) THEN
       --FALTA (DAR BAIXA)
       valEntrar := 0;
       qtdEntrar := 0;       
       valBaixar := CONT.MTMD_VALOR_ATUAL - CONT.MTMD_VALOR_FISICO;       
       qtdBaixar := CONT.MTMD_SALDO_ATUAL - CONT.MTMD_SALDO_FISICO;
       
       vCAD_MTMD_TPMOV_ID := 2;
       vCAD_MTMD_SUBTP_ID := 43;
       --vCAD_MTMD_SUBTP_ID := 6;
    ELSIF (CONT.MTMD_VALOR_FISICO > CONT.MTMD_VALOR_ATUAL OR CONT.MTMD_SALDO_FISICO > CONT.MTMD_SALDO_ATUAL) THEN
       --EXCEDENTE (DAR ENTRADA)
       valBaixar := 0;
       qtdBaixar := 0;       
       valEntrar := CONT.MTMD_VALOR_FISICO - CONT.MTMD_VALOR_ATUAL;       
       qtdEntrar := CONT.MTMD_SALDO_FISICO - CONT.MTMD_SALDO_ATUAL;              
       
       vCAD_MTMD_TPMOV_ID := 1;
       vCAD_MTMD_SUBTP_ID := 44;       
       --vCAD_MTMD_SUBTP_ID := 13;
    END IF;
    
    IF ((valBaixar > 0 OR valEntrar > 0) OR (qtdBaixar > 0 OR qtdEntrar > 0)) THEN
      --Buscar setor de centro de custo
      IF (CONT.CAD_MTMD_GRUPO_ID IN (4,11)) THEN
          CAD_UNI_ID_UNIDADE_MOV           := 244;
          ID_LOCAL_ATENDIMENTO_MOV         := 33;
          CAD_SET_ID_MOV                   := 183; --ALMOXARIFADO SND
      ELSIF (CONT.CAD_MTMD_GRUPO_ID IN (12)) THEN
          CAD_UNI_ID_UNIDADE_MOV           := 244;
          ID_LOCAL_ATENDIMENTO_MOV         := 33;
          CAD_SET_ID_MOV                   := 533; --ALMOXARIFADO HIGIENIZAÇÃO
      ELSIF (CONT.CAD_MTMD_GRUPO_ID IN (8)) THEN
          CAD_UNI_ID_UNIDADE_MOV           := 244;
          ID_LOCAL_ATENDIMENTO_MOV         := 33;
          CAD_SET_ID_MOV                   := 532; --ALMOXARIFADO MANUTENÇÃO
      ELSIF ((CONT.CAD_MTMD_GRUPO_ID = 61 AND CONT.CAD_MTMD_SUBGRUPO_ID = 60) OR
             (CONT.CAD_MTMD_GRUPO_ID = 6  AND CONT.CAD_MTMD_SUBGRUPO_ID = 60) OR
             (CONT.CAD_MTMD_GRUPO_ID = 6  AND CONT.CAD_MTMD_SUBGRUPO_ID = 65)) THEN
          CAD_UNI_ID_UNIDADE_MOV           := 244;
          ID_LOCAL_ATENDIMENTO_MOV         := 29;
          CAD_SET_ID_MOV                   := 61; --CENTRO CIRURGICO
      ELSIF (CONT.CAD_MTMD_GRUPO_ID = 6 AND CONT.CAD_MTMD_SUBGRUPO_ID = 63) THEN
          CAD_UNI_ID_UNIDADE_MOV           := 248;
          ID_LOCAL_ATENDIMENTO_MOV         := 27;
          CAD_SET_ID_MOV                   := 113; --HEMODINAMICA
      ELSIF (CONT.CAD_MTMD_GRUPO_ID = 1 AND CONT.CAD_MTMD_SUBGRUPO_ID = 16) THEN
          CAD_UNI_ID_UNIDADE_MOV           := 248;
          ID_LOCAL_ATENDIMENTO_MOV         := 27;
          CAD_SET_ID_MOV                   := 159; --QUIMIO
      ELSIF (CONT.CAD_MTMD_GRUPO_ID = 34) THEN
          CAD_UNI_ID_UNIDADE_MOV           := 361;
          ID_LOCAL_ATENDIMENTO_MOV         := 27;
          CAD_SET_ID_MOV                   := 2292; --LABORATORIO
      ELSE 
          CAD_UNI_ID_UNIDADE_MOV           := 244;
          ID_LOCAL_ATENDIMENTO_MOV         := 33;
          CAD_SET_ID_MOV                   := 29; --ALMOXARIFADO CENTRAL
      END IF;    
  
      --GERAR MOVIMENTO
      BEGIN
        INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
        (MTMD_MOV_DATA,                   CAD_MTMD_ID,                    CAD_MTMD_FILIAL_ID,            
         CAD_UNI_ID_UNIDADE,              CAD_SET_ID,                     CAD_LAT_ID_LOCAL_ATENDIMENTO,    
         MTMD_SALDO_ANTERIOR,             MTMD_VALOR_ANTERIOR,            MTMD_CUSTO_MEDIO_ANTERIOR,
         MTMD_QTDE_ENTRADA,               MTMD_VALOR_ENTRADA,            
         MTMD_QTDE_SAIDA,                 MTMD_VALOR_SAIDA,
         MTMD_SALDO_ATUAL,                MTMD_VALOR_ATUAL,               MTMD_CUSTO_MEDIO_ATUAL,                                         
         CAD_MTMD_GRUPO_ID,               CAD_MTMD_SUBGRUPO_ID,   
         MTMD_QTDE_ACERTO,                SEG_USU_ID_USUARIO,            
         SEG_DT_ATUALIZACAO,              CAD_MTMD_TPMOV_ID,              CAD_MTMD_SUBTP_ID )
        VALUES
        (TO_DATE('31122016','ddMMyyyy'), CONT.CAD_MTMD_ID,                1,     
         CAD_UNI_ID_UNIDADE_MOV,         CAD_SET_ID_MOV,                  ID_LOCAL_ATENDIMENTO_MOV,    
         0,                              0,                               0,           
         qtdEntrar,                      valEntrar,             
         qtdBaixar,                      valBaixar,
         0,                              0,                               CONT.MTMD_CUSTO_MEDIO,       
         CONT.CAD_MTMD_GRUPO_ID,         CONT.CAD_MTMD_SUBGRUPO_ID,
         0,                              1,           
         SYSDATE,                        vCAD_MTMD_TPMOV_ID,              vCAD_MTMD_SUBTP_ID);
      EXCEPTION 
        WHEN DUP_VAL_ON_INDEX THEN
           UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
           MTMD_QTDE_ENTRADA        =  NVL(MTMD_QTDE_ENTRADA,0)  + qtdEntrar,
           MTMD_VALOR_ENTRADA       =  NVL(MTMD_VALOR_ENTRADA,0) + valEntrar,
           MTMD_QTDE_SAIDA          =  NVL(MTMD_QTDE_SAIDA,0)    + qtdBaixar,
           MTMD_VALOR_SAIDA         =  NVL(MTMD_VALOR_SAIDA,0)   + valBaixar,
           MTMD_CUSTO_MEDIO_ATUAL   =  CONT.MTMD_CUSTO_MEDIO,
           SEG_DT_ATUALIZACAO       =  SYSDATE
           WHERE MTMD_MOV_DATA                = TO_DATE('31122016','ddMMyyyy')
           AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
           AND   CAD_MTMD_FILIAL_ID           = 1
           AND   CAD_MTMD_GRUPO_ID            = CONT.CAD_MTMD_GRUPO_ID
           AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = ID_LOCAL_ATENDIMENTO_MOV
           AND   CAD_UNI_ID_UNIDADE           = CAD_UNI_ID_UNIDADE_MOV
           AND   CAD_SET_ID                   = CAD_SET_ID_MOV
           AND   CAD_MTMD_TPMOV_ID            = vCAD_MTMD_TPMOV_ID
           AND   CAD_MTMD_SUBTP_ID            = vCAD_MTMD_SUBTP_ID;           
        WHEN OTHERS THEN
           RAISE_APPLICATION_ERROR(-20000,' ERRO INSERINDO '||SQLERRM);
      END;
      
      --Atualizar LinhaZero
      vVALOR_ATUAL := valEntrar-valBaixar;
      vSALDO_ATUAL := qtdEntrar-qtdBaixar;
      
      BEGIN
         INSERT INTO TB_MTMD_MOV_ESTOQUE_DIA
            (MTMD_MOV_DATA,                            CAD_MTMD_ID,                           CAD_MTMD_FILIAL_ID,
             CAD_LAT_ID_LOCAL_ATENDIMENTO,             CAD_UNI_ID_UNIDADE,                    CAD_SET_ID,
             MTMD_CUSTO_MEDIO_ANTERIOR,                MTMD_SALDO_ANTERIOR,                   MTMD_VALOR_ANTERIOR,
             MTMD_QTDE_ENTRADA,                        MTMD_VALOR_ENTRADA,                    MTMD_QTDE_SAIDA,
             MTMD_VALOR_SAIDA,                         MTMD_CUSTO_MEDIO_ATUAL,                
             MTMD_SALDO_ATUAL,
             MTMD_VALOR_ATUAL,                         CAD_MTMD_GRUPO_ID,                     CAD_MTMD_SUBGRUPO_ID,
             MTMD_QTDE_ACERTO,                         SEG_USU_ID_USUARIO,                    SEG_DT_ATUALIZACAO,
             CAD_MTMD_TPMOV_ID,                        CAD_MTMD_SUBTP_ID )
            VALUES
            (TO_DATE('01122016','ddMMyyyy'),           CONT.CAD_MTMD_ID,                      1,
             33,                                       244,                                   29,
             0,                                        0,                                     0,
             0,                                        0,                                     0,
             0,                                        decode(round((qtdEntrar  - qtdBaixar),4),0,0,round((valEntrar - valBaixar),4) / round((qtdEntrar  - qtdBaixar),4)), 
             (qtdEntrar - qtdBaixar),
             (valEntrar - valBaixar), CONT.CAD_MTMD_GRUPO_ID, CONT.CAD_MTMD_SUBGRUPO_ID,
             0,                                        1,                                     SYSDATE,
             0,                                        0);
      EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
            BEGIN
               UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
               MTMD_CUSTO_MEDIO_ATUAL   =  round(((NVL(MTMD_VALOR_ATUAL,0) + valEntrar) - valBaixar),4)/round(((NVL(MTMD_SALDO_ATUAL,0) + qtdEntrar)  - qtdBaixar),4),
               MTMD_SALDO_ATUAL         =  (NVL(MTMD_SALDO_ATUAL,0) + qtdEntrar) - qtdBaixar ,
               MTMD_VALOR_ATUAL         =  (NVL(MTMD_VALOR_ATUAL,0) + valEntrar) - valBaixar,
               SEG_DT_ATUALIZACAO       =  SYSDATE
               WHERE MTMD_MOV_DATA                = TO_DATE('01122016','ddMMyyyy')
               AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
               AND   CAD_MTMD_FILIAL_ID           = 1
               --AND   CAD_MTMD_GRUPO_ID            = pCAD_MTMD_GRUPO_ID
               AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
               AND   CAD_UNI_ID_UNIDADE           = 244
               AND   CAD_SET_ID                   = 29
               AND   CAD_MTMD_TPMOV_ID            = 0
               AND   CAD_MTMD_SUBTP_ID            = 0;
            EXCEPTION 
               WHEN ZERO_DIVIDE THEN                
                  UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
                  MTMD_CUSTO_MEDIO_ATUAL   =  0,
                  MTMD_SALDO_ATUAL         =  (NVL(MTMD_SALDO_ATUAL,0) + qtdEntrar) - qtdBaixar,
                  MTMD_VALOR_ATUAL         =  (NVL(MTMD_VALOR_ATUAL,0) + valEntrar) - valBaixar,
                  SEG_DT_ATUALIZACAO       =  SYSDATE
                  WHERE MTMD_MOV_DATA                = TO_DATE('01122016','ddMMyyyy')
                  AND   CAD_MTMD_ID                  = CONT.CAD_MTMD_ID
                  AND   CAD_MTMD_FILIAL_ID           = 1
                  --AND   CAD_MTMD_GRUPO_ID            = pCAD_MTMD_GRUPO_ID
                  AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                  AND   CAD_UNI_ID_UNIDADE           = 244
                  AND   CAD_SET_ID                   = 29
                  AND   CAD_MTMD_TPMOV_ID            = 0
                  AND   CAD_MTMD_SUBTP_ID            = 0;
            END;
      END;
    
    END IF;   
END LOOP;

END;


/*

SELECT MTMD.CAD_MTMD_ID,
                     MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,
                     MTMD.CAD_MTMD_CODMNE,
                     MTMD.CAD_MTMD_UNID_CONTROLE_DS,
                     LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                     LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                     GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                     SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
                     --DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO,
                     LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL MTMD_CUSTO_MEDIO,
                     (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                        FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                               WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                     --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                     --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                     --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                     --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                     --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                     MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                     ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                               WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) MTMD_SALDO_FISICO,
                      TRUNC((SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                        FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                               WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                     --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                     --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                     --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                     --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                     --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                     MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                     ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                               WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) *
                               LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 2) MTMD_VALOR_FISICO,
                      LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,
                      LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL
              FROM TB_CAD_MTMD_MAT_MED MTMD,
                   TB_CAD_MTMD_GRUPO GRUPO,
                   TB_CAD_MTMD_SUBGRUPO SUBGRUPO,
                   TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                   (
                     SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = TO_DATE( '01122015 0000','DDMMYYYY HH24MI')
                     AND   ( CAD_MTMD_FILIAL_ID = 1 )
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO
              WHERE DIAP.MTMD_MOV_DATA >= TO_DATE( '01122015 0000','DDMMYYYY HH24MI')
              AND   DIAP.MTMD_MOV_DATA <= TO_DATE( '31122015 0000','DDMMYYYY HH24MI')
              AND   ( DIAP.CAD_MTMD_FILIAL_ID = 1 )
              --AND   ( DIAP.CAD_MTMD_ID = 775 )
            --  AND   ( pCAD_MTMD_GRUPO_ID IS NULL OR DIAP.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )
              AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
              AND   GRUPO.CAD_MTMD_GRUPO_ID             = LINHA_ZERO.CAD_MTMD_GRUPO_ID
              AND   (SUBGRUPO.CAD_MTMD_GRUPO_ID(+)         = LINHA_ZERO.CAD_MTMD_GRUPO_ID
              AND   SUBGRUPO.CAD_MTMD_SUBGRUPO_ID(+)       = LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID)
              AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
              AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
              AND  (LINHA_ZERO.CAD_MTMD_GRUPO_ID != 4 OR LINHA_ZERO.MTMD_VALOR_ATUAL != 0) -- N?o trazer SND
              AND  NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL              
              GROUP BY MTMD.CAD_MTMD_ID,
                       DIAP.CAD_MTMD_FILIAL_ID,
                       MTMD.CAD_MTMD_NOMEFANTASIA,
                       MTMD.CAD_MTMD_CODMNE,
                       MTMD.CAD_MTMD_UNID_CONTROLE_DS,
                       LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                       LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                       GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                       SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                       LINHA_ZERO.MTMD_SALDO_ATUAL,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                       LINHA_ZERO.MTMD_VALOR_ATUAL,
                       LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                       LINHA_ZERO.MTMD_VALOR_ANTERIOR
              --HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
              HAVING (SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0 OR LINHA_ZERO.MTMD_SALDO_ATUAL = 0)
              UNION
              SELECT MES.CAD_MTMD_ID,
                     M.CAD_MTMD_NOMEFANTASIA DESCRICAO,
                     M.CAD_MTMD_CODMNE, 
                     M.CAD_MTMD_UNID_CONTROLE_DS,
                     M.CAD_MTMD_GRUPO_ID,
                     M.CAD_MTMD_SUBGRUPO_ID, 
                     GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                     SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
                     CASE WHEN (LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL IS NULL) THEN --OR LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL = 0) THEN
                          FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(TO_DATE( '01122015 0000','DDMMYYYY HH24MI'), -12), TO_DATE( '31122015 0000','DDMMYYYY HH24MI'))
                     ELSE
                          NVL(LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 
                              FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(TO_DATE( '01122015 0000','DDMMYYYY HH24MI'), -12), TO_DATE( '31122015 0000','DDMMYYYY HH24MI')))  
                     END  MTMD_CUSTO_MEDIO,
                     MES.MTMD_MOV_SALDO MTMD_SALDO_FISICO,
                     TRUNC((MES.MTMD_MOV_SALDO * 
                      CASE WHEN (LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL IS NULL) THEN-- OR LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL = 0) THEN
                          FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(TO_DATE( '01122015 0000','DDMMYYYY HH24MI'), -12), TO_DATE( '31122015 0000','DDMMYYYY HH24MI'))
                     ELSE
                          NVL(LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 
                              FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(TO_DATE( '01122015 0000','DDMMYYYY HH24MI'), -12), TO_DATE( '31122015 0000','DDMMYYYY HH24MI')))  
                     END),2) MTMD_VALOR_FISICO,
                     NVL(LINHA_ZERO.MTMD_SALDO_ATUAL,0) MTMD_SALDO_ATUAL,
                     NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0) MTMD_VALOR_ATUAL
              FROM (SGS.TB_MTMD_MOV_MES MES JOIN
                   TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = MES.CAD_MTMD_ID JOIN 
                   TB_CAD_MTMD_GRUPO GRUPO ON GRUPO.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID LEFT JOIN
                   TB_CAD_MTMD_SUBGRUPO SUBGRUPO ON (SUBGRUPO.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID AND SUBGRUPO.CAD_MTMD_SUBGRUPO_ID = M.CAD_MTMD_SUBGRUPO_ID)
                   ) LEFT JOIN
                   ( SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = TO_DATE( '01122015 0000','DDMMYYYY HH24MI')
                     AND   ( CAD_MTMD_FILIAL_ID         = 1 )
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO ON LINHA_ZERO.CAD_MTMD_ID = MES.CAD_MTMD_ID AND MES.CAD_MTMD_FILIAL_ID = LINHA_ZERO.CAD_MTMD_FILIAL_ID
              WHERE MES.CAD_MTMD_FILIAL_ID = 1 AND
                    MES.MTMD_MOV_ANO = 2015 AND
                    MES.MTMD_MOV_MES = 12 AND
                    M.CAD_MTMD_GRUPO_ID != 4 
--                    AND MES.CAD_MTMD_ID = 775

*/



/*

SELECT MTMD.CAD_MTMD_ID,                
                   LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                   LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                   --DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO,
                   LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL MTMD_CUSTO_MEDIO,
                   (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                      FROM (SELECT CAD_MTMD_ID, MTMD_MOV_SALDO FROM TB_MTMD_MOV_MES MM
                             WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                   --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND                                   
                                   MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2013 || LPAD(TO_CHAR(12), 2, '0')
                                   ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                             WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) MTMD_SALDO_FISICO,
                    TRUNC((SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                      FROM (SELECT CAD_MTMD_ID, MTMD_MOV_SALDO FROM TB_MTMD_MOV_MES MM
                             WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                   --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                   MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2013 || LPAD(TO_CHAR(12), 2, '0')
                                   ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                             WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) *
                             LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 2) MTMD_VALOR_FISICO,
                    LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,
                    LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL
              FROM TB_CAD_MTMD_MAT_MED MTMD,
                   --TB_CAD_MTMD_GRUPO GRUPO,
                   --TB_CAD_MTMD_SUBGRUPO SUBGRUPO,
                   TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                   (
                     SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = TO_DATE('01122013','ddMMyyyy')
                     AND   ( CAD_MTMD_FILIAL_ID = 1 )                     
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO
              WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('01122013','ddMMyyyy')
              AND   DIAP.MTMD_MOV_DATA <= TO_DATE('31122013','ddMMyyyy')
              AND   ( DIAP.CAD_MTMD_FILIAL_ID = 1 )              
              AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
              --AND   GRUPO.CAD_MTMD_GRUPO_ID             = LINHA_ZERO.CAD_MTMD_GRUPO_ID
              --AND   (SUBGRUPO.CAD_MTMD_GRUPO_ID(+)         = LINHA_ZERO.CAD_MTMD_GRUPO_ID
              --AND   SUBGRUPO.CAD_MTMD_SUBGRUPO_ID(+)       = LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID)
              AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
              AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
              AND  (LINHA_ZERO.CAD_MTMD_GRUPO_ID != 4 OR LINHA_ZERO.MTMD_VALOR_ATUAL != 0) -- Não trazer SND
              AND  NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL              
              GROUP BY MTMD.CAD_MTMD_ID,
                       DIAP.CAD_MTMD_FILIAL_ID,
                       MTMD.CAD_MTMD_NOMEFANTASIA,
                       LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                       LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                       LINHA_ZERO.MTMD_SALDO_ATUAL,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                       LINHA_ZERO.MTMD_VALOR_ATUAL,
                       LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                       LINHA_ZERO.MTMD_VALOR_ANTERIOR
              --HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
              HAVING (SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0 OR LINHA_ZERO.MTMD_SALDO_ATUAL = 0)
              ORDER BY MTMD.CAD_MTMD_NOMEFANTASIA
*/

/*
--OLD (query base)
SELECT MTMD.CAD_MTMD_ID,
                     MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,
                     MTMD.CAD_MTMD_CODMNE,
                     MTMD.CAD_MTMD_UNID_CONTROLE_DS,
                     LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                     LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                     GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                     SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
                     --DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO,
                     LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL MTMD_CUSTO_MEDIO,
                     (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                        FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                               WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                     --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                     --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                     --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                     --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                     --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                     MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                     ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                               WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) MTMD_SALDO_FISICO,
                      \*TRUNC((SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                        FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                               WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                     --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                     --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                     --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                     --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                     --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                     MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                     ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                               WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) *
                               LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 2) MTMD_VALOR_FISICO,*\
                      DECODE(LINHA_ZERO.MTMD_SALDO_ATUAL, 
                             (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                                FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                                       WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                             --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                             --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                             --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                             --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                             --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                             MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                             ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                                       WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ), 
                              NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0),
                              TRUNC((SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                                FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                                       WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                             --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                                             --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                                             --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                                             --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                                             --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                                             MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                             ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                                       WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) * LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 2)) MTMD_VALOR_FISICO,
                      LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,
                      LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL
              FROM TB_CAD_MTMD_MAT_MED MTMD,
                   TB_CAD_MTMD_GRUPO GRUPO,
                   TB_CAD_MTMD_SUBGRUPO SUBGRUPO,
                   TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                   (
                     SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = TO_DATE( '01122015 0000','DDMMYYYY HH24MI')
                     AND   ( CAD_MTMD_FILIAL_ID = 1 )
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO
              WHERE DIAP.MTMD_MOV_DATA >= TO_DATE( '01122015 0000','DDMMYYYY HH24MI')
              AND   DIAP.MTMD_MOV_DATA <= TO_DATE( '31122015 0000','DDMMYYYY HH24MI')
              AND   ( DIAP.CAD_MTMD_FILIAL_ID = 1 )
             -- AND   ( DIAP.CAD_MTMD_ID = 15353 )
            --  AND   ( pCAD_MTMD_GRUPO_ID IS NULL OR DIAP.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )
              AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
              AND   GRUPO.CAD_MTMD_GRUPO_ID             = LINHA_ZERO.CAD_MTMD_GRUPO_ID
              AND   (SUBGRUPO.CAD_MTMD_GRUPO_ID(+)         = LINHA_ZERO.CAD_MTMD_GRUPO_ID
              AND   SUBGRUPO.CAD_MTMD_SUBGRUPO_ID(+)       = LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID)
              AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
              AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
              AND  (LINHA_ZERO.CAD_MTMD_GRUPO_ID != 4 OR LINHA_ZERO.MTMD_VALOR_ATUAL != 0) -- N?o trazer SND
              AND  NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL
              AND  (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                      FROM (SELECT CAD_MTMD_ID, MTMD_MOV_SALDO FROM TB_MTMD_MOV_MES MM
                             WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                   MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                   ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                             WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) != LINHA_ZERO.MTMD_SALDO_ATUAL
              GROUP BY MTMD.CAD_MTMD_ID,
                       DIAP.CAD_MTMD_FILIAL_ID,
                       MTMD.CAD_MTMD_NOMEFANTASIA,
                       MTMD.CAD_MTMD_CODMNE,
                       MTMD.CAD_MTMD_UNID_CONTROLE_DS,
                       LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                       LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                       GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                       SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                       LINHA_ZERO.MTMD_SALDO_ATUAL,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                       LINHA_ZERO.MTMD_VALOR_ATUAL,
                       LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                       LINHA_ZERO.MTMD_VALOR_ANTERIOR
              --HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
              HAVING (SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0 OR LINHA_ZERO.MTMD_SALDO_ATUAL = 0)
              UNION
              SELECT MES.CAD_MTMD_ID,
                     M.CAD_MTMD_NOMEFANTASIA DESCRICAO,
                     M.CAD_MTMD_CODMNE, 
                     M.CAD_MTMD_UNID_CONTROLE_DS,
                     M.CAD_MTMD_GRUPO_ID,
                     M.CAD_MTMD_SUBGRUPO_ID, 
                     GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                     SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
                     CASE WHEN (LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL IS NULL) THEN --OR LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL = 0) THEN
                          FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(TO_DATE( '01122015 0000','DDMMYYYY HH24MI'), -12), TO_DATE( '31122015 0000','DDMMYYYY HH24MI'))
                     ELSE
                          NVL(LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 
                              FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(TO_DATE( '01122015 0000','DDMMYYYY HH24MI'), -12), TO_DATE( '31122015 0000','DDMMYYYY HH24MI')))  
                     END  MTMD_CUSTO_MEDIO,
                     MES.MTMD_MOV_SALDO MTMD_SALDO_FISICO,
                     DECODE(LINHA_ZERO.MTMD_SALDO_ATUAL, MES.MTMD_MOV_SALDO, NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0),
                     TRUNC((MES.MTMD_MOV_SALDO * 
                      CASE WHEN (LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL IS NULL) THEN-- OR LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL = 0) THEN
                          FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(TO_DATE( '01122015 0000','DDMMYYYY HH24MI'), -12), TO_DATE( '31122015 0000','DDMMYYYY HH24MI'))
                     ELSE
                          NVL(LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 
                              FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(TO_DATE( '01122015 0000','DDMMYYYY HH24MI'), -12), TO_DATE( '31122015 0000','DDMMYYYY HH24MI')))  
                     END),2)) MTMD_VALOR_FISICO,
                     NVL(LINHA_ZERO.MTMD_SALDO_ATUAL,0) MTMD_SALDO_ATUAL,
                     NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0) MTMD_VALOR_ATUAL
              FROM (SGS.TB_MTMD_MOV_MES MES JOIN
                   TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = MES.CAD_MTMD_ID JOIN 
                   TB_CAD_MTMD_GRUPO GRUPO ON GRUPO.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID LEFT JOIN
                   TB_CAD_MTMD_SUBGRUPO SUBGRUPO ON (SUBGRUPO.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID AND SUBGRUPO.CAD_MTMD_SUBGRUPO_ID = M.CAD_MTMD_SUBGRUPO_ID)
                   ) LEFT JOIN
                   ( SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = TO_DATE( '01122015 0000','DDMMYYYY HH24MI')
                     AND   ( CAD_MTMD_FILIAL_ID         = 1 )
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO ON LINHA_ZERO.CAD_MTMD_ID = MES.CAD_MTMD_ID AND MES.CAD_MTMD_FILIAL_ID = LINHA_ZERO.CAD_MTMD_FILIAL_ID
              WHERE MES.CAD_MTMD_FILIAL_ID = 1 AND
                    MES.MTMD_MOV_ANO = 2015 AND
                    MES.MTMD_MOV_MES = 12 AND
                    M.CAD_MTMD_GRUPO_ID != 4 
                    --AND MES.CAD_MTMD_ID = 15353
                    AND NVL(LINHA_ZERO.MTMD_SALDO_ATUAL,0) != MES.MTMD_MOV_SALDO  */

/*SELECT MTMD.CAD_MTMD_ID,                
                   LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                   LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                   --DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO,
                   LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL MTMD_CUSTO_MEDIO,
                   (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                      FROM (SELECT CAD_MTMD_ID, MTMD_MOV_SALDO FROM TB_MTMD_MOV_MES MM
                             WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                   MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                   ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                             WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) MTMD_SALDO_FISICO,
                    TRUNC((SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                      FROM (SELECT CAD_MTMD_ID, MTMD_MOV_SALDO FROM TB_MTMD_MOV_MES MM
                             WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                   MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                   ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                             WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) *
                             LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 2) MTMD_VALOR_FISICO,
                    LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,
                    LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL
              FROM TB_CAD_MTMD_MAT_MED MTMD,
                   TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                   (
                     SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = TO_DATE('01122015','ddMMyyyy')
                     AND   ( CAD_MTMD_FILIAL_ID = 1 )
                     --AND   ( CAD_MTMD_ID = 775 )
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO
              WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('01122015','ddMMyyyy')
              AND   DIAP.MTMD_MOV_DATA <= TO_DATE('31122015','ddMMyyyy')
              AND   ( DIAP.CAD_MTMD_FILIAL_ID = 1 )
              AND   ( DIAP.CAD_MTMD_ID = 775 )
              AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
              AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
              AND  (LINHA_ZERO.CAD_MTMD_GRUPO_ID != 4 OR LINHA_ZERO.MTMD_VALOR_ATUAL != 0) -- Não trazer SND
              AND  NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL
              AND  (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                      FROM (SELECT CAD_MTMD_ID, MTMD_MOV_SALDO FROM TB_MTMD_MOV_MES MM
                             WHERE MM.CAD_MTMD_FILIAL_ID = 1 AND
                                   MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= 2015 || LPAD(TO_CHAR(12), 2, '0')
                                   ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                             WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) != LINHA_ZERO.MTMD_SALDO_ATUAL
              GROUP BY MTMD.CAD_MTMD_ID,
                       DIAP.CAD_MTMD_FILIAL_ID,
                       MTMD.CAD_MTMD_NOMEFANTASIA,
                       LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                       LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                       LINHA_ZERO.MTMD_SALDO_ATUAL,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                       LINHA_ZERO.MTMD_VALOR_ATUAL,
                       LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                       LINHA_ZERO.MTMD_VALOR_ANTERIOR
              --HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
              HAVING (SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0 OR LINHA_ZERO.MTMD_SALDO_ATUAL = 0)
              UNION
              SELECT MES.CAD_MTMD_ID,
                     M.CAD_MTMD_GRUPO_ID,
                     M.CAD_MTMD_SUBGRUPO_ID, 
                     CASE WHEN (LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL IS NULL) THEN --OR LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL = 0) THEN
                          FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, TO_DATE('01012015','ddMMyyyy'), TO_DATE('31122015','ddMMyyyy'))
                     ELSE
                          NVL(LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 
                              FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, TO_DATE('01012015','ddMMyyyy'), TO_DATE('31122015','ddMMyyyy')))  
                     END  MTMD_CUSTO_MEDIO,
                     MES.MTMD_MOV_SALDO MTMD_SALDO_FISICO,
                     TRUNC((MES.MTMD_MOV_SALDO * 
                      CASE WHEN (LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL IS NULL) THEN-- OR LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL = 0) THEN
                          FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, TO_DATE('01012015','ddMMyyyy'), TO_DATE('31122015','ddMMyyyy'))
                     ELSE
                          NVL(LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 
                              FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, TO_DATE('01012015','ddMMyyyy'), TO_DATE('31122015','ddMMyyyy')))  
                     END),2),
                     NVL(LINHA_ZERO.MTMD_SALDO_ATUAL,0),
                     NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0)
              FROM (SGS.TB_MTMD_MOV_MES MES JOIN
                     TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = MES.CAD_MTMD_ID JOIN 
                     TB_CAD_MTMD_GRUPO GRUPO ON GRUPO.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID LEFT JOIN
                     TB_CAD_MTMD_SUBGRUPO SUBGRUPO ON (SUBGRUPO.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID AND SUBGRUPO.CAD_MTMD_SUBGRUPO_ID = M.CAD_MTMD_SUBGRUPO_ID)
                   ) LEFT JOIN                   
                   ( SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = TO_DATE('01122015','ddMMyyyy')
                     AND   ( CAD_MTMD_FILIAL_ID         = 1 )
                    -- AND   ( CAD_MTMD_ID = 356 )
              --       AND   CAD_MTMD_GRUPO_ID = 1
                     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                     AND   CAD_UNI_ID_UNIDADE           = 244
                     AND   CAD_SET_ID                   = 29
                     AND   CAD_MTMD_TPMOV_ID            = 0
                     AND   CAD_MTMD_SUBTP_ID            = 0
                   ) LINHA_ZERO ON LINHA_ZERO.CAD_MTMD_ID = MES.CAD_MTMD_ID AND MES.CAD_MTMD_FILIAL_ID = LINHA_ZERO.CAD_MTMD_FILIAL_ID
              WHERE MES.CAD_MTMD_FILIAL_ID = 1 AND
                    MES.MTMD_MOV_ANO = 2015 AND
                    MES.MTMD_MOV_MES = 12 AND
                    M.CAD_MTMD_GRUPO_ID != 4
                    AND MES.CAD_MTMD_ID = 775
                    AND NVL(LINHA_ZERO.MTMD_SALDO_ATUAL,0) != MES.MTMD_MOV_SALDO   
              --ORDER BY MTMD.CAD_MTMD_NOMEFANTASIA
*/
