CREATE OR REPLACE PROCEDURE "PRC_CAD_MTMD_INVENTARIO_ATIVAR"
(
     pCAD_MTMD_FILIAL_ID IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_FILIAL_ID%type,
     pCAD_SET_ID IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_SET_ID%type,
     pCAD_MTMD_DT_INVENTARIO IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_DT_INVENTARIO%type,
     pCAD_MTMD_ANDAMENTO IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_ANDAMENTO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_MTMD_INVENTARIO_FECHA.SEG_USU_ID_USUARIO%type,
     pAPENAS_MATERIAIS IN NUMBER := 0 --0 ou 1
     --pFL_MEDICAMENTO IN TB_CAD_MTMD_INVENTARIO_FECHA.FL_MEDICAMENTO%type DEFAULT NULL
)
is
vDT_INICIO_INV DATE;
vDT_FECHA_INV  DATE;
/********************************************************************
*    Procedure: PRC_CAD_MTMD_INVENTARIO_ATIVAR
*
*    Data Criacao:  10/8/11   Por: Andre
*  Data Alterac?o:  18/03/13  Por: Andre
*       Alterac?o:  N?o guardar mais itens com qtd. zerada na ativac?o
*  Data Alterac?o:  01/12/15  Por: Andre
*       Alterac?o:  Nova opcao de TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_ANDAMENTO = 2
*                   (andamento terceirizado)
*    Data Alteracao: 19/05/16   Por: Andre
*         Alteracao: Add. campo CAD_MTMD_DT_INICIO_INV e CAD_MTMD_DT_FECHA_INV
*
*    Funcao: Ativa inventario
*******************************************************************/
begin
  IF (pCAD_MTMD_ANDAMENTO IN (1,2)) THEN
    -- SE TIVER INVENTARIO EM ANDAMENTO DO SETOR ABORTAR ATIVAC?O
    IF (FNC_MTMD_SETOR_INVENTARIADO(pCAD_SET_ID, pCAD_MTMD_FILIAL_ID, 1) IN (1,2)) THEN
       RAISE_APPLICATION_ERROR(-20010,'N?O FOI POSSIVEL ATIVAR O INVENTARIO DO ESTOQUE DESTE SETOR NESTA DATA, POIS JA TEM UM EM ANDAMENTO');
    END IF;
    vDT_INICIO_INV := SYSDATE;
  ELSE
    vDT_FECHA_INV := SYSDATE;
  END IF;
  BEGIN
    INSERT INTO TB_CAD_MTMD_INVENTARIO_FECHA
    (
           CAD_MTMD_FILIAL_ID,
           CAD_SET_ID,
           CAD_MTMD_DT_INVENTARIO,
           CAD_MTMD_FECHAMENTO,
           CAD_MTMD_ANDAMENTO,
           CAD_MTMD_DT_ATUALIZACAO,
           SEG_USU_ID_USUARIO,
           CAD_MTMD_DT_INICIO_INV,
           FL_MEDICAMENTO,
           CAD_MTMD_GRUPO_ID
    )
    VALUES
    (
          pCAD_MTMD_FILIAL_ID,
          pCAD_SET_ID,
          TRUNC(pCAD_MTMD_DT_INVENTARIO),
          0,
          pCAD_MTMD_ANDAMENTO,
          SYSDATE,
          pSEG_USU_ID_USUARIO,
          vDT_INICIO_INV,
          0,
          0
    );
    IF (NVL(pAPENAS_MATERIAIS,0) = 0) THEN
      INSERT INTO TB_CAD_MTMD_INVENTARIO_FECHA
      (
             CAD_MTMD_FILIAL_ID,
             CAD_SET_ID,
             CAD_MTMD_DT_INVENTARIO,
             CAD_MTMD_FECHAMENTO,
             CAD_MTMD_ANDAMENTO,
             CAD_MTMD_DT_ATUALIZACAO,
             SEG_USU_ID_USUARIO,
             CAD_MTMD_DT_INICIO_INV,
             FL_MEDICAMENTO,
             CAD_MTMD_GRUPO_ID
      )
      VALUES
      (
            pCAD_MTMD_FILIAL_ID,
            pCAD_SET_ID,
            TRUNC(pCAD_MTMD_DT_INVENTARIO),
            0,
            pCAD_MTMD_ANDAMENTO,
            SYSDATE,
            pSEG_USU_ID_USUARIO,
            vDT_INICIO_INV,
            1,
            0
      );
    END IF;
  EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
             UPDATE TB_CAD_MTMD_INVENTARIO_FECHA
                   SET
                        CAD_MTMD_ANDAMENTO = pCAD_MTMD_ANDAMENTO,
                        CAD_MTMD_DT_ATUALIZACAO = SYSDATE,
                        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
                        CAD_MTMD_DT_INICIO_INV = NVL(CAD_MTMD_DT_INICIO_INV,vDT_INICIO_INV),
                        CAD_MTMD_DT_FECHA_INV = vDT_FECHA_INV
                WHERE
                        CAD_MTMD_DT_INVENTARIO = TRUNC(pCAD_MTMD_DT_INVENTARIO)
                    AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                    AND CAD_SET_ID = pCAD_SET_ID
                    AND CAD_MTMD_GRUPO_ID = 0;
                    --AND FL_MEDICAMENTO = pFL_MEDICAMENTO;
  END;
  --Importar qtd atual do estoque-online para futura consulta de relatorios deste inventario
  IF (pCAD_MTMD_ANDAMENTO IN (1,2)) THEN
    --INSERE PRIMEIRO MATERIAIS
    FOR ONLINE IN ( SELECT MTMD.CAD_MTMD_ID, ESTLOC.MTMD_ESTLOC_QTDE
                    FROM TB_MTMD_ESTOQUE_LOCAL ESTLOC,
                         TB_CAD_MTMD_MAT_MED   MTMD
                    WHERE ESTLOC.CAD_SET_ID                   = pCAD_SET_ID
                    AND   ESTLOC.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
                    AND   MTMD.CAD_MTMD_ID                    = ESTLOC.CAD_MTMD_ID
                    AND   MTMD.CAD_MTMD_FL_ATIVO              = 1
                    AND   MTMD.CAD_MTMD_GRUPO_ID              != 1)
                    --AND   ESTLOC.MTMD_ESTLOC_QTDE > 0 )
    LOOP
      BEGIN
        INSERT INTO TB_CAD_MTMD_INVENTARIO
        (
               CAD_MTMD_ID,
               CAD_MTMD_FILIAL_ID,
               CAD_SET_ID,
               CAD_MTMD_DT_INVENTARIO,
               CAD_MTMD_QTDE_ANTERIOR,
               CAD_MTMD_DT_ATUALIZACAO,
               SEG_USU_ID_USUARIO,
               CAD_MTMD_QTDE_1,
               CAD_MTMD_QTDE_FINAL,
               MTMD_COD_LOTE
        )
        VALUES
        (
              ONLINE.CAD_MTMD_ID,
              pCAD_MTMD_FILIAL_ID,
              pCAD_SET_ID,
              TRUNC(pCAD_MTMD_DT_INVENTARIO),
              ONLINE.MTMD_ESTLOC_QTDE,
              SYSDATE,
              pSEG_USU_ID_USUARIO,
              DECODE(pCAD_MTMD_ANDAMENTO, 2, 0, NULL),
              DECODE(pCAD_MTMD_ANDAMENTO, 2, 0, NULL),
              0
        );
      EXCEPTION
            WHEN DUP_VAL_ON_INDEX THEN
              NULL;
              /*UPDATE TB_CAD_MTMD_INVENTARIO
                 SET  CAD_MTMD_QTDE_ANTERIOR = ONLINE.MTMD_ESTLOC_QTDE,
                      CAD_MTMD_DT_ATUALIZACAO = SYSDATE,
                      SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
              WHERE
                      CAD_MTMD_DT_INVENTARIO = TRUNC(pCAD_MTMD_DT_INVENTARIO)
                  AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                  AND CAD_MTMD_ID = ONLINE.CAD_MTMD_ID
                  AND CAD_SET_ID = pCAD_SET_ID;*/
      END;
    END LOOP;
    IF (NVL(pAPENAS_MATERIAIS,0) = 0) THEN
      --AGORA MEDICAMENTOS / LOTE
      FOR ONLINE IN (SELECT PRODUTO.CAD_MTMD_ID,
                            ESTLOTE.MTMD_COD_LOTE,
                            ESTLOTE.MTMD_EST_QTDE MTMD_ESTLOC_QTDE,
                            (SELECT NVL(LL.MTMD_NUM_LOTE_ALT, LL.MTMD_NUM_LOTE)
                               FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL
                              WHERE LL.MTMD_COD_LOTE = ESTLOTE.MTMD_COD_LOTE AND
                                    LL.CAD_MTMD_ID   = ESTLOTE.CAD_MTMD_ID AND ROWNUM = 1) MTMD_NUM_LOTE
                       FROM TB_MTMD_ESTOQUE_LOTE ESTLOTE JOIN
                            TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = ESTLOTE.CAD_MTMD_ID JOIN
                            TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = ESTLOTE.CAD_SET_ID JOIN
                            TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE
                       WHERE PRODUTO.CAD_MTMD_FL_ATIVO  = 1
                         AND PRODUTO.CAD_MTMD_GRUPO_ID  = 1
                         AND FNC_MTMD_CONTROLA_LOTE_COD(ESTLOTE.CAD_MTMD_ID, ESTLOTE.MTMD_COD_LOTE) = 1
                         AND ESTLOTE.CAD_SET_ID         = pCAD_SET_ID
                         AND ESTLOTE.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                      UNION
                      SELECT  DISTINCT
                              PRODUTO.CAD_MTMD_ID,
                              '0' MTMD_COD_LOTE,
                              FNC_MTMD_EST_SEMLOTE_SETOR(PRODUTO.CAD_MTMD_ID,
                                                         SETOR.CAD_UNI_ID_UNIDADE,
                                                         SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                         SETOR.CAD_SET_ID,
                                                         ESTLOTE.CAD_MTMD_FILIAL_ID) MTMD_ESTLOC_QTDE,
                              NULL MTMD_NUM_LOTE
                       FROM TB_MTMD_ESTOQUE_LOTE ESTLOTE JOIN
                            TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = ESTLOTE.CAD_MTMD_ID JOIN
                            TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = ESTLOTE.CAD_SET_ID JOIN
                            TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE
                       WHERE PRODUTO.CAD_MTMD_FL_ATIVO  = 1
                         AND PRODUTO.CAD_MTMD_GRUPO_ID  = 1
                         AND ESTLOTE.CAD_SET_ID         = pCAD_SET_ID
                         AND ESTLOTE.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                       UNION
                       SELECT DISTINCT
                              MTMD.CAD_MTMD_ID,
                              '0' MTMD_COD_LOTE,
                              ESTLOC.MTMD_ESTLOC_QTDE,
                              NULL MTMD_NUM_LOTE
                        FROM TB_MTMD_ESTOQUE_LOCAL ESTLOC,
                             TB_CAD_MTMD_MAT_MED   MTMD
                        WHERE ESTLOC.CAD_SET_ID                   = pCAD_SET_ID
                        AND   ESTLOC.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
                        AND   MTMD.CAD_MTMD_ID                    = ESTLOC.CAD_MTMD_ID
                        AND   MTMD.CAD_MTMD_FL_ATIVO              = 1
                        AND   MTMD.CAD_MTMD_GRUPO_ID              = 1
                        AND   MTMD.CAD_MTMD_ID NOT IN (SELECT CAD_MTMD_ID
                                                         FROM TB_MTMD_ESTOQUE_LOTE
                                                         WHERE CAD_SET_ID = pCAD_SET_ID AND
                                                               CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID))
      LOOP
        BEGIN
          INSERT INTO TB_CAD_MTMD_INVENTARIO
          (
                 CAD_MTMD_ID,
                 CAD_MTMD_FILIAL_ID,
                 CAD_SET_ID,
                 CAD_MTMD_DT_INVENTARIO,
                 CAD_MTMD_QTDE_ANTERIOR,
                 CAD_MTMD_DT_ATUALIZACAO,
                 SEG_USU_ID_USUARIO,
                 CAD_MTMD_QTDE_1,
                 CAD_MTMD_QTDE_FINAL,
                 MTMD_COD_LOTE,
                 MTMD_NUM_LOTE
          )
          VALUES
          (
                ONLINE.CAD_MTMD_ID,
                pCAD_MTMD_FILIAL_ID,
                pCAD_SET_ID,
                TRUNC(pCAD_MTMD_DT_INVENTARIO),
                ONLINE.MTMD_ESTLOC_QTDE,
                SYSDATE,
                pSEG_USU_ID_USUARIO,
                DECODE(pCAD_MTMD_ANDAMENTO, 2, 0, NULL),
                DECODE(pCAD_MTMD_ANDAMENTO, 2, 0, NULL),
                ONLINE.MTMD_COD_LOTE,
                ONLINE.MTMD_NUM_LOTE
          );
        EXCEPTION
              WHEN DUP_VAL_ON_INDEX THEN
                NULL;
        END;
      END LOOP;
    END IF;
  END IF;
end PRC_CAD_MTMD_INVENTARIO_ATIVAR;