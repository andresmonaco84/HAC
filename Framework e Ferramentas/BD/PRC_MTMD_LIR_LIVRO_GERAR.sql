CREATE OR REPLACE PROCEDURE PRC_MTMD_LIR_LIVRO_GERAR (
  pCAD_MTMD_FILIAL_ID IN TB_MTMD_LIR_LIVRO_REGISTRO.CAD_MTMD_FILIAL_ID%type,
  pCAD_UNI_ID_UNIDADE IN TB_MTMD_LIR_LIVRO_REGISTRO.CAD_UNI_ID_UNIDADE%type := 244, --SANTOS
  pANO_REF IN NUMBER,
  pMES_REF IN NUMBER,
  pCAD_MTMD_ID IN TB_MTMD_LIR_LIVRO_REGISTRO.CAD_MTMD_ID%type default null,
  pSEG_USU_ID_USUARIO IN TB_MTMD_LIR_LIVRO_REGISTRO.SEG_USU_ID_USUARIO_CRIACAO%type,
  pEXCLUIR_DADO_POSTERIOR IN NUMBER := 0 --0 (nao) ou 1 (sim)
) is
/********************************************************************
*    Procedure: PRC_MTMD_LIR_LIVRO_GERAR
*
*    Data Criacao:   25/04/2017   Por: Andre S. Monaco
*
*    Data Alteracao: 05/2020   Por: Andre S. Monaco
*         Alteracao: Fixado para gerar a partir de movimentos apenas
*                    da Farmacia e Unitarizacao          
*
*    Funcao: Gerar dados do Livro Registro (Psicotropicos)
*******************************************************************/
--vCAD_MTMD_ID TB_MTMD_LIR_LIVRO_REGISTRO.CAD_MTMD_ID%TYPE := pCAD_MTMD_ID;
vMTMD_LIR_ID TB_MTMD_LIR_LIVRO_REGISTRO.MTMD_LIR_ID%TYPE;
vQTD_ESTOQUE NUMBER;
vDataIni DATE;
vDataFim DATE;
sMes VARCHAR2(2);
HOSPITAL_SANTOS  CONSTANT NUMBER := 244;
FARMACIA_CENTRAL CONSTANT NUMBER := 2592;
UNITARIZACAO     CONSTANT NUMBER := 2632;
CENTRO_DISP      NUMBER := 0;
BEGIN
  IF (pCAD_UNI_ID_UNIDADE != HOSPITAL_SANTOS) THEN --Busca Almox. do Regional
     BEGIN
         SELECT SETOR.CAD_SET_ID
           INTO CENTRO_DISP
         FROM TB_CAD_SET_SETOR SETOR
         WHERE SETOR.CAD_SET_FL_ATIVO_OK = 'S' AND
               SETOR.CAD_SET_FL_SUBSTALMOX_OK = 'S' AND
               SETOR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;
     EXCEPTION WHEN NO_DATA_FOUND THEN
         RAISE_APPLICATION_ERROR(-20000, 'UNIDADE SEM REFERENCIA DE ALMOXARIFADO PARA GERACAO DE DADOS.');
     END;  
  END IF;
  IF (  LENGTH(TO_CHAR(pMES_REF)) = 1 ) THEN
     sMes := '0' || TO_CHAR(pMES_REF);
  ELSE
     sMes := TO_CHAR(pMES_REF);
  END IF;
  vDataIni := TO_DATE('01' || sMes || TO_CHAR(pANO_REF)||' 0000','DDMMYYYY HH24MI');
  vDataFim := TO_DATE(TO_CHAR(LAST_DAY(vDataIni),'DDMMYYYY')||' 2359','DDMMYYYY HH24MI');

  IF (vDataIni < TO_DATE('01122021 0000','DDMMYYYY HH24MI')) THEN
    RAISE_APPLICATION_ERROR(-20000, 'DADOS LIBERADOS PARA SEREM GERADOS SO A PARTIR DE DEZEMBRO/2021.');
  END IF;

  FOR PRODUTO_GERAR IN (SELECT M.CAD_MTMD_ID, M.CAD_MTMD_NOMEFANTASIA
                          FROM TB_CAD_MTMD_MAT_MED M
                         WHERE M.CAD_MTMD_FL_ATIVO = 1 AND
                               ((pCAD_MTMD_ID IS NULL AND M.CAD_MTMD_CD_GRUPO_ANVISA IS NOT NULL) OR
                                (pCAD_MTMD_ID IS NOT NULL AND M.CAD_MTMD_ID = pCAD_MTMD_ID))
                        ORDER BY M.CAD_MTMD_NOMEFANTASIA)
  LOOP

    BEGIN
      SELECT LIR.MTMD_LIR_ID
        INTO vMTMD_LIR_ID
        FROM TB_MTMD_LIR_LIVRO_REGISTRO LIR
       WHERE LIR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE AND
             LIR.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
             LIR.CAD_MTMD_ID = PRODUTO_GERAR.CAD_MTMD_ID AND
             LIR.MTMD_LIR_DT_REGISTRO > vDataFim AND
             ROWNUM = 1;

       IF (NVL(pEXCLUIR_DADO_POSTERIOR,0) = 1) THEN
         DELETE TB_MTMD_LIR_LIVRO_REGISTRO LIR
          WHERE LIR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE AND
                LIR.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
                LIR.CAD_MTMD_ID = PRODUTO_GERAR.CAD_MTMD_ID AND
                LIR.MTMD_LIR_DT_REGISTRO > vDataFim;

         PRC_MTMD_LIR_LIVRO_GERAR(pCAD_MTMD_FILIAL_ID, pCAD_UNI_ID_UNIDADE, pANO_REF, pMES_REF, pCAD_MTMD_ID,pSEG_USU_ID_USUARIO, 0);
       ELSIF (pCAD_MTMD_ID IS NOT NULL) THEN
         RAISE_APPLICATION_ERROR(-20000, 'ITEM ' || PRODUTO_GERAR.CAD_MTMD_NOMEFANTASIA || ' JA TEM DADO POSTERIOR E NAO PODE SER PROCESSADO NESTE MES,
                                                                                            FAVOR ENTRAR EM CONTATO COM UM ADMINISTRADOR, OU MARCAR OPCAO
                                                                                            PARA EXCLUSAO DE DADOS POSTERIORES.');
       END IF;
    EXCEPTION
       WHEN NO_DATA_FOUND THEN

        DELETE TB_MTMD_LIR_LIVRO_REGISTRO LIR
          WHERE LIR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE AND
                LIR.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
                LIR.CAD_MTMD_ID = PRODUTO_GERAR.CAD_MTMD_ID AND
                LIR.MTMD_LIR_DT_REGISTRO >= vDataIni AND
                LIR.MTMD_LIR_DT_REGISTRO <= TRUNC(vDataFim);

        FOR GERAR_LIR IN (SELECT MTMD_MOV_DATA,
                                 CAD_MTMD_ID,
                                 CAD_MTMD_NOMEFANTASIA,
                                 CAD_MTMD_CD_GRUPO_ANVISA,
                                 MTMD_MOV_FL_ESTORNO,
                                 CAD_MTMD_SUBTP_DESCRICAO,
                                 CASE
                                   WHEN (TB_MOV.CAD_MTMD_TPMOV_ID = 1) THEN
                                     SUM(TB_MOV.MTMD_MOV_QTDE)
                                 END QT_ENTRADA,
                                 CASE
                                   WHEN (TB_MOV.CAD_MTMD_TPMOV_ID = 2 AND TB_MOV.CAD_MTMD_SUBTP_ID != 6) THEN
                                     SUM(TB_MOV.MTMD_MOV_QTDE)
                                 END QT_SAIDA,
                                 CASE
                                   WHEN (TB_MOV.CAD_MTMD_TPMOV_ID = 2 AND TB_MOV.CAD_MTMD_SUBTP_ID = 6) THEN
                                     SUM(TB_MOV.MTMD_MOV_QTDE)
                                 END QT_PERDA,
                                 CAD_MTMD_TPMOV_ID
                          FROM (
                          SELECT TRUNC(MOVIMENTACAO.MTMD_MOV_DATA) MTMD_MOV_DATA,
                                 MOVIMENTACAO.CAD_MTMD_ID,
                                 PRODUTO.CAD_MTMD_NOMEFANTASIA,
                                 PRODUTO.CAD_MTMD_CD_GRUPO_ANVISA,
                                 MOVIMENTACAO.MTMD_MOV_FL_ESTORNO,
                                 CASE
                                  WHEN MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 1 THEN -- ENTRADA
                                     CASE
                                        WHEN (MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 1 AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 1) THEN --ENTRADA NF
                                           'ENTRADA NF ' || NF.MTMD_NR_NOTA || ' - ' || NF.DS_FORNECEDOR
                                        WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 2 THEN -- TRANSFERENCIA
                                           SUBT.CAD_MTMD_SUBTP_DESCRICAO||' '||
                                           ( SELECT SETOR.CAD_SET_DS_SETOR
                                             FROM TB_MTMD_MOV_MOVIMENTACAO MOV,
                                                  TB_CAD_SET_SETOR       SETOR
                                             WHERE MTMD_MOV_ID                        = MOVIMENTACAO.MTMD_MOV_ID_REF
                                             AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID
                                             AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                             AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE )
                                        WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 29 THEN
                                           SUBT.CAD_MTMD_SUBTP_DESCRICAO||': '||
                                           (SELECT SETOR_HORA FROM
                                            (SELECT UNI.CAD_UNI_DS_RESUMIDA || '/' || SETOR.CAD_SET_CD_SETOR || ' ' || TO_CHAR(MOV.MTMD_MOV_DATA,'(DD/MM/YY HH24:MI:SS)') SETOR_HORA
                                             FROM TB_MTMD_MOV_MOVIMENTACAO MOV,
                                                  TB_CAD_SET_SETOR       SETOR,
                                                  TB_CAD_UNI_UNIDADE     UNI
                                             WHERE MOV.MTMD_MOV_ID_REF                = MOVIMENTACAO.MTMD_MOV_ID_REF
                                             AND   UNI.CAD_UNI_ID_UNIDADE             = MOV.CAD_UNI_ID_UNIDADE
                                             AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID
                                             AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                             AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE
                                             ORDER BY MOV.CAD_MTMD_TPMOV_ID DESC)
                                             WHERE ROWNUM = 1)
                                        ELSE
                                           SUBT.CAD_MTMD_SUBTP_DESCRICAO
                                      END
                                  WHEN MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2 THEN -- SAIDA
                                     CASE
                                        WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (5, 8, 10, 22, 68) THEN
                                           'DISPENSADO P/ '||
                                           ( SELECT SETOR.CAD_SET_DS_SETOR||' '||
                                                    CASE
                                                       WHEN REQ.CAD_UNI_ID_UNIDADE != MOVIMENTACAO.CAD_UNI_ID_UNIDADE THEN
                                                          (SELECT UNI.CAD_UNI_DS_UNIDADE
                                                           FROM TB_CAD_UNI_UNIDADE UNI
                                                           WHERE UNI.CAD_UNI_ID_UNIDADE = REQ.CAD_UNI_ID_UNIDADE )
                                                       ELSE NULL
                                                    END ||
                                                    CASE
                                                       WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 5  THEN ' (AVULSO)'
                                                       WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 8  THEN ' (PADRAO)'
                                                         WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 22  THEN ' (CARR. EMERG.)'
                                                       WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 10 THEN ' - PACIENTE ' || MOVIMENTACAO.ATD_ATE_ID
                                                       WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 68 THEN ' (ESTOQUE LOCAL)'
                                                    END
                                             FROM TB_MTMD_REQ_REQUISICAO REQ,
                                                  TB_CAD_SET_SETOR       SETOR
                                             WHERE REQ.MTMD_REQ_ID                    = MOVIMENTACAO.MTMD_REQ_ID
                                             AND   SETOR.CAD_SET_ID                   = REQ.CAD_SET_ID
                                             AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = REQ.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                             AND   SETOR.CAD_UNI_ID_UNIDADE           = REQ.CAD_UNI_ID_UNIDADE )
                                        WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 3 THEN -- TRANSFERENCIA
                                           SUBT.CAD_MTMD_SUBTP_DESCRICAO||', DESTINO: '||
                                           ( SELECT UNI.CAD_UNI_DS_RESUMIDA || '/' || SETOR.CAD_SET_CD_SETOR
                                             FROM TB_MTMD_MOV_MOVIMENTACAO MOV,
                                                  TB_CAD_SET_SETOR       SETOR,
                                                  TB_CAD_UNI_UNIDADE     UNI
                                             WHERE MTMD_MOV_ID                        = MOVIMENTACAO.MTMD_MOV_ID_REF
                                             AND   UNI.CAD_UNI_ID_UNIDADE             = MOV.CAD_UNI_ID_UNIDADE
                                             AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID
                                             AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                             AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE )
                                        WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 19 THEN -- CONSUMO CENTRO CUSTO
                                           'BAIXA CENT. CUSTO, DESTINO: '||
                                           (SELECT SETOR FROM
                                            (SELECT UNI.CAD_UNI_DS_RESUMIDA || '/' || SETOR.CAD_SET_CD_SETOR ||' '||
                                                    (DECODE(MOV.CAD_MTMD_SUBTP_ID,28,' (HOME CARE)','')) SETOR
                                             FROM TB_MTMD_MOV_MOVIMENTACAO MOV,
                                                  TB_CAD_SET_SETOR       SETOR,
                                                  TB_CAD_UNI_UNIDADE     UNI
                                             WHERE ((MOV.MTMD_MOV_FL_ESTORNO = 1 AND MOV.MTMD_MOV_ID_REF = MOVIMENTACAO.MTMD_MOV_ID) OR
                                                    (MOV.MTMD_MOV_FL_ESTORNO = 0 AND MOV.MTMD_MOV_ID = MOVIMENTACAO.MTMD_MOV_ID_REF))
                                             AND   UNI.CAD_UNI_ID_UNIDADE             = MOV.CAD_UNI_ID_UNIDADE
                                             AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID
                                             AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                             AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE
                                             ORDER BY MOV.CAD_MTMD_TPMOV_ID DESC)
                                             WHERE ROWNUM = 1)   
                                        WHEN (MOVIMENTACAO.ATD_ATE_ID IS NOT NULL) THEN
                                          SUBT.CAD_MTMD_SUBTP_DESCRICAO || ' - PACIENTE ' || MOVIMENTACAO.ATD_ATE_ID           
                                        ELSE
                                          SUBT.CAD_MTMD_SUBTP_DESCRICAO
                                     END
                                 END CAD_MTMD_SUBTP_DESCRICAO,
                                 NF.MTMD_NR_NOTA,
                                 NF.DS_FORNECEDOR,       
                                 MOVIMENTACAO.MTMD_MOV_QTDE,
                                 MOVIMENTACAO.CAD_MTMD_TPMOV_ID,
                                 MOVIMENTACAO.CAD_MTMD_SUBTP_ID,
                                 MOVIMENTACAO.ATD_ATE_ID,     
                                 MOVIMENTACAO.CAD_SET_ID,       
                                 CASE WHEN MOVIMENTACAO.MTMD_MOV_ID_REF IS NOT NULL THEN
                                           ( SELECT CAD_SET_ID
                                             FROM TB_MTMD_MOV_MOVIMENTACAO
                                             WHERE MTMD_MOV_ID = MOVIMENTACAO.MTMD_MOV_ID_REF )
                                 END CAD_SET_ID_DESTINO       
                          FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO JOIN
                               TB_CAD_MTMD_MAT_MED PRODUTO ON MOVIMENTACAO.CAD_MTMD_ID = PRODUTO.CAD_MTMD_ID JOIN
                               TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBT ON (SUBT.CAD_MTMD_TPMOV_ID = MOVIMENTACAO.CAD_MTMD_TPMOV_ID AND
                                                                       SUBT.CAD_MTMD_SUBTP_ID = MOVIMENTACAO.CAD_MTMD_SUBTP_ID) LEFT JOIN
                               TB_MTMD_HISTORICO_NOTA_FISCAL NF ON NF.MTMD_MOV_ID = MOVIMENTACAO.MTMD_MOV_ID
                          WHERE SUBT.CAD_MTMD_FL_GERAR_LIVRO = 1
                            AND MOVIMENTACAO.CAD_MTMD_FILIAL_ID IN (1,4) --HAC/CE
                            AND MOVIMENTACAO.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
                            AND (pCAD_UNI_ID_UNIDADE != HOSPITAL_SANTOS OR MOVIMENTACAO.CAD_SET_ID IN (FARMACIA_CENTRAL, UNITARIZACAO))
                            AND (pCAD_UNI_ID_UNIDADE = HOSPITAL_SANTOS  OR MOVIMENTACAO.CAD_SET_ID IN (CENTRO_DISP))
                            AND MOVIMENTACAO.CAD_MTMD_ID        = PRODUTO_GERAR.CAD_MTMD_ID
                            AND MOVIMENTACAO.MTMD_MOV_DATA     >= vDataIni
                            AND MOVIMENTACAO.MTMD_MOV_DATA     <= vDataFim
                          ) TB_MOV
                          WHERE ((pCAD_UNI_ID_UNIDADE != HOSPITAL_SANTOS) OR
                                 (CAD_SET_ID = FARMACIA_CENTRAL AND NVL(CAD_SET_ID_DESTINO,0) != UNITARIZACAO) OR
                                 (CAD_SET_ID = UNITARIZACAO     AND NVL(CAD_SET_ID_DESTINO,0) != FARMACIA_CENTRAL))
                            --AND MTMD_MOV_FL_ESTORNO = 0  
                          GROUP BY MTMD_MOV_DATA,
                                   CAD_MTMD_TPMOV_ID,
                                   CAD_MTMD_SUBTP_ID,
                                   CAD_MTMD_SUBTP_DESCRICAO,
                                   MTMD_NR_NOTA,
                                   DS_FORNECEDOR,
                                   ATD_ATE_ID,
                                   CAD_MTMD_ID,
                                   CAD_MTMD_NOMEFANTASIA,
                                   CAD_MTMD_CD_GRUPO_ANVISA,
                                   MTMD_MOV_FL_ESTORNO,
                                   CAD_MTMD_SUBTP_ID
                          ORDER BY 3, 1, 10)
        LOOP

          SELECT NVL(MAX(MTMD_LIR_QT_ESTOQUE),0)
            INTO vQTD_ESTOQUE
            FROM (SELECT LIR.MTMD_LIR_QT_ESTOQUE
                    FROM TB_MTMD_LIR_LIVRO_REGISTRO LIR
                   WHERE LIR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE AND
                         LIR.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
                         LIR.CAD_MTMD_ID = PRODUTO_GERAR.CAD_MTMD_ID
                   ORDER BY LIR.MTMD_LIR_DT_REGISTRO DESC, LIR.MTMD_LIR_ID DESC)
           WHERE ROWNUM = 1;

          IF (GERAR_LIR.QT_ENTRADA > 0) THEN
            vQTD_ESTOQUE := vQTD_ESTOQUE + GERAR_LIR.QT_ENTRADA;
          ELSIF (GERAR_LIR.QT_SAIDA > 0) THEN
            vQTD_ESTOQUE := vQTD_ESTOQUE - GERAR_LIR.QT_SAIDA;
          ELSIF (GERAR_LIR.QT_PERDA > 0) THEN
            vQTD_ESTOQUE := vQTD_ESTOQUE - GERAR_LIR.QT_PERDA;
          END IF;

          IF (vQTD_ESTOQUE < 0) THEN --NAO DEIXAR NEGATIVAR ESTOQUE
            vQTD_ESTOQUE := 0;
          END IF;

          SELECT SEQ_MTMD_LIR_01.NextVal INTO vMTMD_LIR_ID FROM DUAL;

          INSERT INTO TB_MTMD_LIR_LIVRO_REGISTRO
          (MTMD_LIR_ID,                        CAD_UNI_ID_UNIDADE,   CAD_MTMD_ID,                MTMD_LIR_DT_REGISTRO,
           MTMD_LIR_DS_HISTORICO,              MTMD_LIR_QT_ENTRADA,  MTMD_LIR_QT_SAIDA,          MTMD_LIR_QT_PERDA,
           MTMD_LIR_QT_ESTOQUE,                MTMD_LIR_DT_CRIACAO,  SEG_USU_ID_USUARIO_CRIACAO, MTMD_LIR_DT_ATUALIZACAO,
           SEG_USU_ID_USUARIO_ATUALIZACAO,     CAD_MTMD_FILIAL_ID)
          VALUES
          (vMTMD_LIR_ID,                       pCAD_UNI_ID_UNIDADE,  GERAR_LIR.CAD_MTMD_ID,      GERAR_LIR.MTMD_MOV_DATA,
           GERAR_LIR.CAD_MTMD_SUBTP_DESCRICAO, GERAR_LIR.QT_ENTRADA, GERAR_LIR.QT_SAIDA,         GERAR_LIR.QT_PERDA,
           vQTD_ESTOQUE,                       SYSDATE,              pSEG_USU_ID_USUARIO,        SYSDATE,
           pSEG_USU_ID_USUARIO,                pCAD_MTMD_FILIAL_ID);

           COMMIT;

        END LOOP;
    END;

  END LOOP;

end PRC_MTMD_LIR_LIVRO_GERAR;