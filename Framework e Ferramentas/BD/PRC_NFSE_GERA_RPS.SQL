create or replace PROCEDURE PRC_NFSE_GERA_RPS(p_cidade in varchar) IS

ERRO_SQL                    VARCHAR2(255);
V_ID_RPS                    TB_NFSE_CONTROLE_RPS.FAT_NOF_NR_RPS%TYPE;
V_FAT_NOF_FL_SITUACAO_ENVIO TB_NFSE_CONTROLE_XML.FAT_NOF_FL_SITUACAO_ENVIO%TYPE;
V_DESCRICAO                 TB_NFSE_CONTROLE_XML.DESCRICAO%TYPE;
CidadeNaoCadParaGerarRPS    NUMBER := 300;
RPSGERADO                   NUMBER := 1;
AguardandoGeracaoRps        NUMBER := 0; 
ErrodesconhecidoGeracaoRPS  NUMBER := 400;

BEGIN
       FOR GERA IN(
        SELECT NOF.FAT_NOF_ID,                  NULL FAT_NOF_NR_NOTAFISCAL,         NOF.FAT_NOF_TP_SERIEFISCAL,  
               NOF.CAD_UNI_ID_UNIDADE,          NOF.FAT_NOF_FL_STATUS,             NOF.FAT_NFO_DT_EMISSAO,  
               NOF.FAT_NFO_DT_VENCIMENTO,       NOF.FAT_NOF_MES_FAT,               NOF.FAT_NOF_ANO_FAT,  
               NOF.CAD_CNV_ID_CONVENIO,         NOF.CAD_PLA_ID_PLANO,              NOF.FAT_NFO_VL_FATURADO,  
               NOF.FAT_NFO_VL_RETENCAO,         NOF.FAT_NFO_VL_LIQUIDO,            NOF.FAT_NOF_VL_IR,  
               NOF.FAT_NOF_PC_IR,               NOF.FAT_NOF_VL_ISS,                NOF.FAT_NOF_PC_ISS,  
               NOF.FAT_NOF_VL_COFINS,           NOF.FAT_NOF_PC_COFINS,             NOF.FAT_NOF_VL_CSLL,  
               NOF.FAT_NOF_PC_CSLL,             NOF.FAT_NOF_VL_PIS,                NOF.FAT_NOF_PC_PIS,  
               NOF.SEG_USU_ID_USUARIO,          NOF.FAT_NOF_DT_ULTIMA_ATUALIZACAO, NOF.SEG_USU_ID_USUARIO_CANCELA,  
               NOF.FAT_NOF_DT_CANCELAMENTO,     NOF.CAD_MCN_ID,                    NOF.FAT_NOF_VL_DESCONTO,  
               NOF.FAT_NOF_DS_DESCONTO,         NOF.FAT_NOF_FL_JURIDICA,           NOF.FAT_NOF_NR_DOCUMENTO,  
               NOF.FAT_NFO_FL_LIBERADO_COB,     NOF.FAT_NOF_DT_LIBERA_COBRANCA,    NOF.FAT_NOF_FL_LIBERA_PROTOCOLO,  
               NOF.FAT_NOF_DT_LIBERA_PROTOCOLO, NOF.FAT_NOF_FL_ENVIO_ELET_REALIZ,  NOF.FAT_NOF_DT_ENVIO_ELETR_REALIZ,  
               NOF.CAD_UNI_DS_MUNICIPIO,        NOF.CAD_TPE_CD_CODIGO,             NOF.FAT_NOF_DS_DESCRICAO,
               CASE WHEN UNI.CAD_UNI_ID_UNIDADE_MASTER != UNI.CAD_UNI_ID_UNIDADE THEN
               (
                   SELECT  PESM.CAD_PES_CD_INSCR_MUNIC
                   FROM TB_CAD_UNI_UNIDADE UNIM,
                        TB_CAD_PES_PESSOA  PESM
                   WHERE UNIM.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE_MASTER
                   AND   PESM.CAD_PES_ID_PESSOA  = UNIM.CAD_PES_ID_PESSOA
               )
               ELSE 
                  NOF.CAD_UNI_CD_INSCR_MUNIC   
               END CAD_UNI_CD_INSCR_MUNIC,
               
               CASE WHEN UNI.CAD_UNI_ID_UNIDADE_MASTER != UNI.CAD_UNI_ID_UNIDADE THEN
               (
                   SELECT  PESM.CAD_PES_NR_CNPJ_CPF
                   FROM TB_CAD_UNI_UNIDADE UNIM,
                        TB_CAD_PES_PESSOA  PESM
                   WHERE UNIM.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE_MASTER
                   AND   PESM.CAD_PES_ID_PESSOA  = UNIM.CAD_PES_ID_PESSOA
               )
               ELSE 
                 (
                   SELECT  PESM.CAD_PES_NR_CNPJ_CPF
                   FROM TB_CAD_PES_PESSOA  PESM
                   WHERE PESM.CAD_PES_ID_PESSOA  = UNI.CAD_PES_ID_PESSOA                 
                 )   
               END CAD_PES_NR_CNPJ_CPF,
               
                              
               FAT_NOF_TP_GRUPO_PAC,        SEG_USU_ID_USUARIO_LIB_PROTOC, CAD_FEX_NUMERO_FORMULARIO,  
               FAT_NOF_OBS_PROTOCOLO,       CAD_FEX_ID,                    FAT_NOF_FL_HISTORICO,  
               FAT_NOF_ST_SITUACAO_SALDO,   FAT_NOF_DT_ENVIO_HISTORICO,    SEG_USU_ID_USUARIO_ENVIO_HIST,  
               FAT_NOF_FL_SITUACAO_ENVIO,   FAT_NOF_NR_RPS 
        FROM TB_FAT_NOF_NOTA_FISCAL NOF, 
             TB_CAD_UNI_UNIDADE     UNI
        WHERE NOF.FAT_NOF_FL_STATUS = 'A'
        AND   NOF.FAT_NOF_FL_SITUACAO_ENVIO = AguardandoGeracaoRps
        AND   NOF.CAD_UNI_DS_MUNICIPIO= p_cidade
        AND   UNI.CAD_UNI_ID_UNIDADE = NOF.CAD_UNI_ID_UNIDADE
        AND   UNI.CAD_UNI_FL_STATUS = 'A'        
        AND   ROWNUM <= 10 
        )
        LOOP
            BEGIN
                -- BUSCA NOVO ID RPS
                BEGIN
                    SELECT NVL(FAT_NOF_NR_RPS,0)
                    INTO   V_ID_RPS 
                    FROM TB_NFSE_CONTROLE_RPS NFS 
                    -- WHERE NFS.CAD_PES_CD_INSCR_MUNIC = GERA.CAD_UNI_CD_INSCR_MUNIC;
                    WHERE NFS.CAD_UNI_DS_MUNICIPIO = GERA.CAD_UNI_DS_MUNICIPIO;
                    
                    V_ID_RPS := V_ID_RPS + 1;
                    
                    UPDATE TB_NFSE_CONTROLE_RPS SET 
                    FAT_NOF_NR_RPS = V_ID_RPS
                    WHERE CAD_UNI_DS_MUNICIPIO = GERA.CAD_UNI_DS_MUNICIPIO;
                    -- MARCA RPS COMO GERADP                
                    V_FAT_NOF_FL_SITUACAO_ENVIO := RPSGerado; 
                    V_DESCRICAO := '';
                  
                EXCEPTION 
                    WHEN NO_DATA_FOUND THEN 
                       V_ID_RPS := 0;
                       V_FAT_NOF_FL_SITUACAO_ENVIO := CidadeNaoCadParaGerarRPS;
                       V_DESCRICAO := '';
                     WHEN OTHERS THEN
                       ERRO_SQL := SUBSTR(sqlerrm,1,255);
                       V_ID_RPS := 0;
                       V_FAT_NOF_FL_SITUACAO_ENVIO := ErrodesconhecidoGeracaoRPS;                     
                       V_DESCRICAO := SUBSTR(ERRO_SQL,1,255);
                END;
                -- ATUALIZA NUMERO DO RPS NA NOF
                UPDATE TB_FAT_NOF_NOTA_FISCAL SET 
                FAT_NOF_NR_RPS            = V_ID_RPS,
                FAT_NOF_FL_SITUACAO_ENVIO = V_FAT_NOF_FL_SITUACAO_ENVIO
                WHERE FAT_NOF_ID = GERA.FAT_NOF_ID;
                
                -- INSERE TABELA AUXILIAR PARA GERAÇÃO XML
                  INSERT INTO TB_NFSE_CONTROLE_XML
                  (FAT_NOF_ID,              FAT_NOF_FL_SITUACAO_ENVIO,         FAT_NOF_NR_RPS,
                   FAT_NOF_NR_NOTAFISCAL,   CAD_UNI_ID_UNIDADE,                FAT_NOF_FL_STATUS,
                   CAD_CNV_ID_CONVENIO,     CAD_PLA_ID_PLANO,                  FAT_NFO_VL_FATURADO,
                   FAT_NFO_VL_RETENCAO,     FAT_NFO_VL_LIQUIDO,                FAT_NOF_VL_IR,
                   FAT_NOF_PC_IR,           FAT_NOF_VL_ISS,                    ALIQUOTA,
                   FAT_NOF_VL_COFINS,       FAT_NOF_PC_COFINS,                 FAT_NOF_VL_CSLL,
                   FAT_NOF_PC_CSLL,         FAT_NOF_VL_PIS,                    FAT_NOF_PC_PIS,
                   FAT_NOF_VL_DESCONTO,     FAT_NOF_DS_DESCONTO,               FAT_NOF_FL_JURIDICA,
                   CAD_UNI_CD_INSCR_MUNIC,  DATA_ENVIO,                        DATA_RPS_GERADO,
                   NOME_TOMADOR,            CNPJ_CPF_TOMADOR,                  INSCRICAO_MUNICIPAL_TOMADOR,
                   DDD_TOMADOR,             LOGRADOURO_TOMADOR,
                   NUMERO_ENDERECO_TOMADOR, COMPLEMENTO_ENDERECO_TOMADOR,      TIPO_BAIRRO_TOMADOR,
                   MUNICIPIO_TOMADOR_CD,    MUNICIPIO_TOMADOR_DESC,            EMAIL_TOMADOR,
                   TELEFONE_TOMADOR,        CODIGO_ATIDADE,                    TIPO_RECOLHIMENTO,
                   MUNICIPIO_PRESTACAO_CD,  MUNICIPIO_PRESTACAO_DESC,          NATUREZA_OPERACAO,
                   /*DESCRICAO_RPS,*/                     DDD_PRESTADOR,
                   TELEFONE_PRESTADOR,      MOTIVO_CANCELAMENTO,               TIPO_RPS,
                   SERIE_RPS,               SITUACAO_RPS,                      SERIE_RPS_SUBSTITUIDO,
                   NUMERO_NFSE_SUBSTITUIDA, NUMERO_RPS_SUBSTITUIDO,            DATA_EMISSAO_NFSE_SUBSTITUIDA,
                   SERIE_PRESTACAO,         CAD_UNI_DS_MUNICIPIO,              CAD_TPE_CD_CODIGO,
                   DESCRICAO,               FAT_NOF_DS_DESCRICAO
                  ) 
                  VALUES
                  (GERA.FAT_NOF_ID,             V_FAT_NOF_FL_SITUACAO_ENVIO,   V_ID_RPS,
                   GERA.FAT_NOF_NR_NOTAFISCAL,  GERA.CAD_UNI_ID_UNIDADE,       GERA.FAT_NOF_FL_STATUS,
                   GERA.CAD_CNV_ID_CONVENIO,    GERA.CAD_PLA_ID_PLANO,         GERA.FAT_NFO_VL_FATURADO,
                   GERA.FAT_NFO_VL_RETENCAO,    GERA.FAT_NFO_VL_LIQUIDO,       GERA.FAT_NOF_VL_IR,
                   GERA.FAT_NOF_PC_IR,          GERA.FAT_NOF_VL_ISS,           GERA.FAT_NOF_PC_ISS,
                   GERA.FAT_NOF_VL_COFINS,      GERA.FAT_NOF_PC_COFINS,        GERA.FAT_NOF_VL_CSLL,
                   GERA.FAT_NOF_PC_CSLL,        GERA.FAT_NOF_VL_PIS,           GERA.FAT_NOF_PC_PIS,
                   GERA.FAT_NOF_VL_DESCONTO,    GERA.FAT_NOF_DS_DESCONTO,      GERA.FAT_NOF_FL_JURIDICA,
                   GERA.CAD_UNI_CD_INSCR_MUNIC, NULL,/*DATE ENVIO*/            SYSDATE,/*RPS GERADO*/
                   NULL, /*NOME*/               NULL, /*CPF CNPJ*/             NULL, /*INSC. MUN. TOMADOR*/
                   NULL, /*DDD TOMADOR*/        NULL, /*LOGRAD. TOMADOR*/
                   NULL, /*NR END TOMADOR*/     NULL, /*COMPL TOMADOR*/        NULL, /*TIPO BAIRRO TOMADOR*/
                   NULL, /*CD CIDADE TOMADOR*/  NULL, /*DS CIDADE TOMADOR*/    NULL, /*EMAIL TOMADOR*/
                   NULL, /*TEL TOMADOR*/        NULL, /*COD ATIV TOMADOR*/     NULL, /*TIPO RECOL.*/
                   NULL, /*MUN PREST. CD*/      NULL, /*MUN DESC DS*/          NULL, /*OPERACAO*/
                   /*NULL,DESC RPS*/             NULL, /*DDD PRESTADOR*/
                   NULL, /*TEL PRESTADOR*/      NULL, /*MOTIVO CANCELAMENTO*/  NULL, /*TIPO RPS*/
                   NULL, /*SERIE RPS*/          NULL, /*SITUACAO RPS*/         NULL, /*SERIE RPS SUBST*/
                   NULL, /*NR NF SUBST*/        NULL, /*NR RPS SUBST*/         NULL, /*DT EMISS NF SUBST*/
                   NULL, /*SERIE PRESTACA0*/    GERA.CAD_UNI_DS_MUNICIPIO,     GERA.CAD_TPE_CD_CODIGO,
                   V_DESCRICAO,                 GERA.FAT_NOF_DS_DESCRICAO
                  );
                  
                  INSERT INTO TB_NFSE_HISTORICO
                  ( FAT_NOF_ID,      FAT_NOF_FL_SITUACAO_ENVIO,    FAT_NOF_NR_RPS,   DATA_HISTORICO,   DESCRICAO )
                  VALUES
                  (GERA.FAT_NOF_ID,  V_FAT_NOF_FL_SITUACAO_ENVIO,  V_ID_RPS,         SYSDATE,          V_DESCRICAO);
                COMMIT;
            EXCEPTION 
              WHEN OTHERS THEN
                   ROLLBACK;
            END;          
        END LOOP;

END PRC_NFSE_GERA_RPS;