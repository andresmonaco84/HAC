CREATE OR REPLACE PROCEDURE "PRC_CAD_MTMD_INVENTARIO_G"
(
     pCAD_MTMD_ID IN TB_CAD_MTMD_INVENTARIO.CAD_MTMD_ID%type,
     pCAD_MTMD_FILIAL_ID IN TB_CAD_MTMD_INVENTARIO.CAD_MTMD_FILIAL_ID%type,
     pCAD_SET_ID IN TB_CAD_MTMD_INVENTARIO.CAD_SET_ID%type,
     pCAD_MTMD_DT_INVENTARIO IN TB_CAD_MTMD_INVENTARIO.CAD_MTMD_DT_INVENTARIO%type,
     pCAD_MTMD_QTDE_1 IN TB_CAD_MTMD_INVENTARIO.CAD_MTMD_QTDE_1%type default NULL,
     pCAD_MTMD_QTDE_2 IN TB_CAD_MTMD_INVENTARIO.CAD_MTMD_QTDE_2%type default NULL,
     pCAD_MTMD_QTDE_3 IN TB_CAD_MTMD_INVENTARIO.CAD_MTMD_QTDE_3%type default NULL,
     pCAD_MTMD_QTDE_FINAL IN TB_CAD_MTMD_INVENTARIO.CAD_MTMD_QTDE_FINAL%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_MTMD_INVENTARIO.SEG_USU_ID_USUARIO%type default NULL,
     pMTMD_COD_LOTE IN TB_CAD_MTMD_INVENTARIO.MTMD_COD_LOTE%type DEFAULT NULL,
     pMTMD_NUM_LOTE IN TB_CAD_MTMD_INVENTARIO.MTMD_NUM_LOTE%type DEFAULT NULL,
     pLOG_DATA_INI_IMPORT IN TB_CAD_MTMD_INVENT_LOG_IMPORT.INV_LOG_DATA_INI_PROCESSO%type DEFAULT NULL, --Quando origem e txt importacao do Palm
     pLOG_CD_BARRA_IMPORT IN TB_CAD_MTMD_INVENT_LOG_IMPORT.INV_LOG_CD_BARRA%type DEFAULT NULL, --Quando origem e txt importacao do Palm
     pLOG_QTDE_IMPORT IN TB_CAD_MTMD_INVENT_LOG_IMPORT.CAD_MTMD_QTDE%type DEFAULT NULL, --Quando origem e txt importacao do Palm
     pCAD_MTMD_FECHAMENTO IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_FECHAMENTO%type DEFAULT NULL,
     pCAD_MTMD_GRUPO_ID IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_GRUPO_ID%type := 0
)
is
vCAD_MTMD_DT_QTDE_1 DATE;
vCAD_MTMD_DT_QTDE_2 DATE;
vCAD_MTMD_DT_QTDE_3 DATE;
vCAD_MTMD_ID TB_CAD_MTMD_INVENTARIO.CAD_MTMD_ID%type := pCAD_MTMD_ID;
vFL_EXCLUIDO TB_CAD_MTMD_INVENT_LOG_IMPORT.FL_EXCLUIDO%type := 0;
/*vID_UNIDADE NUMBER;
vID_LOCAL NUMBER;
vSALDO_ANTERIOR NUMBER;*/
/********************************************************************
*    Procedure: PRC_CAD_MTMD_INVENTARIO_G
*
*    Data Criacao:   10/8/11    Por: Andre
*    Data Alteracao: 18/05/16   Por: Andre
*         Alteracao: Add. campos CAD_MTMD_DT_QTDE_X
*
*    Funcao: Grava item digitado de inventario
*******************************************************************/
begin
IF (pLOG_CD_BARRA_IMPORT IS NULL) THEN
  -- SE INVENTARIO NAO ESTIVER EM ANDAMENTO, ABORTAR
  IF (NVL(pCAD_MTMD_GRUPO_ID,0) != 0) THEN
     IF (FNC_MTMD_SETOR_INVENTARIADO(pCAD_SET_ID, pCAD_MTMD_FILIAL_ID, 1, pCAD_MTMD_GRUPO_ID) = 0) THEN
        RAISE_APPLICATION_ERROR(-20020,'INVENTARIO INATIVADO');     
     END IF;
  ELSIF (FNC_MTMD_SETOR_INVENTARIADO(pCAD_SET_ID, pCAD_MTMD_FILIAL_ID, 1) = 0) THEN
     RAISE_APPLICATION_ERROR(-20020,'INVENTARIO INATIVADO');
  END IF;
END IF;
--SELECT CAD_UNI_ID_UNIDADE INTO vID_UNIDADE FROM TB_CAD_SET_SETOR WHERE CAD_SET_ID = pCAD_SET_ID;
--SELECT CAD_LAT_ID_LOCAL_ATENDIMENTO INTO vID_LOCAL FROM TB_CAD_SET_SETOR WHERE CAD_SET_ID = pCAD_SET_ID
IF (pCAD_MTMD_QTDE_1 IS NOT NULL) THEN vCAD_MTMD_DT_QTDE_1 := SYSDATE; END IF;
IF (pCAD_MTMD_QTDE_2 IS NOT NULL) THEN vCAD_MTMD_DT_QTDE_2 := SYSDATE; END IF;
IF (pCAD_MTMD_QTDE_3 IS NOT NULL) THEN vCAD_MTMD_DT_QTDE_3 := SYSDATE; END IF;
/*IF (NVL(pMTMD_COD_LOTE) <> 0) THEN
   vSALDO_ANTERIOR := FNC_MTMD_ESTOQUE_LOTE_SETOR(pCAD_MTMD_ID,
                                                  vID_UNIDADE,
                                                  vID_LOCAL,
                                                  pCAD_SET_ID,
                                                  pCAD_MTMD_FILIAL_ID,
                                                  NULL, -- pMTMD_LOTEST_ID (ja tem o Cod Lote nesse momento)
                                                  pMTMD_COD_LOTE,
                                                  1 --So lote com controle
                                                  );
ELSE
  vSALDO_ANTERIOR := FNC_MTMD_ESTOQUE_UNIDADE(pCAD_MTMD_ID,
                                              vID_UNIDADE,
                                              vID_LOCAL,
                                              pCAD_SET_ID,
                                              pCAD_MTMD_FILIAL_ID,
                                              NULL), -- LOTE
END IF;*/
IF (NVL(pCAD_MTMD_ID,0) != 0) THEN
  BEGIN
    INSERT INTO TB_CAD_MTMD_INVENTARIO
    (
           CAD_MTMD_ID,
           CAD_MTMD_FILIAL_ID,
           CAD_SET_ID,
           CAD_MTMD_DT_INVENTARIO,
           CAD_MTMD_QTDE_1,
           CAD_MTMD_QTDE_2,
           CAD_MTMD_QTDE_3,
           CAD_MTMD_QTDE_FINAL,
           CAD_MTMD_DT_ATUALIZACAO,
           SEG_USU_ID_USUARIO,
           CAD_MTMD_QTDE_ANTERIOR,
           CAD_MTMD_DT_QTDE_1,
           CAD_MTMD_DT_QTDE_2,
           CAD_MTMD_DT_QTDE_3,
           MTMD_COD_LOTE,
           MTMD_NUM_LOTE
    )
    VALUES
    (
          pCAD_MTMD_ID,
          pCAD_MTMD_FILIAL_ID,
          pCAD_SET_ID,
          TRUNC(pCAD_MTMD_DT_INVENTARIO),
          pCAD_MTMD_QTDE_1,
          pCAD_MTMD_QTDE_2,
          pCAD_MTMD_QTDE_3,
          pCAD_MTMD_QTDE_FINAL,
          SYSDATE,
          pSEG_USU_ID_USUARIO,
          NULL, --vSALDO_ANTERIOR,
          vCAD_MTMD_DT_QTDE_1,
          vCAD_MTMD_DT_QTDE_2,
          vCAD_MTMD_DT_QTDE_3,
          NVL(pMTMD_COD_LOTE, 0),
          pMTMD_NUM_LOTE
    );
  EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
             UPDATE TB_CAD_MTMD_INVENTARIO
                   SET
                        CAD_MTMD_QTDE_1 = DECODE(pCAD_MTMD_QTDE_1, NULL, CAD_MTMD_QTDE_1, pCAD_MTMD_QTDE_1),
                        CAD_MTMD_QTDE_2 = DECODE(pCAD_MTMD_QTDE_2, NULL, CAD_MTMD_QTDE_2, pCAD_MTMD_QTDE_2),
                        CAD_MTMD_QTDE_3 = DECODE(pCAD_MTMD_QTDE_3, NULL, CAD_MTMD_QTDE_3, pCAD_MTMD_QTDE_3),
                        CAD_MTMD_QTDE_FINAL = pCAD_MTMD_QTDE_FINAL,
                        CAD_MTMD_DT_QTDE_1 = NVL(vCAD_MTMD_DT_QTDE_1,CAD_MTMD_DT_QTDE_1),
                        CAD_MTMD_DT_QTDE_2 = NVL(vCAD_MTMD_DT_QTDE_2,CAD_MTMD_DT_QTDE_2),
                        CAD_MTMD_DT_QTDE_3 = NVL(vCAD_MTMD_DT_QTDE_3,CAD_MTMD_DT_QTDE_3),
                        CAD_MTMD_DT_ATUALIZACAO = SYSDATE,
                        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
                WHERE
                        CAD_MTMD_DT_INVENTARIO = TRUNC(pCAD_MTMD_DT_INVENTARIO)
                    AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                    AND CAD_MTMD_ID = pCAD_MTMD_ID
                    AND CAD_SET_ID = pCAD_SET_ID
                    AND NVL(MTMD_COD_LOTE,'0') = NVL(pMTMD_COD_LOTE,'0');
  END;
END IF;
IF (pLOG_DATA_INI_IMPORT IS NOT NULL AND pLOG_CD_BARRA_IMPORT IS NOT NULL AND pLOG_QTDE_IMPORT IS NOT NULL) THEN
  IF (NVL(pCAD_MTMD_ID,0) = 0) THEN
     vCAD_MTMD_ID := NULL;
     vFL_EXCLUIDO := 1;
  END IF;
  INSERT INTO TB_CAD_MTMD_INVENT_LOG_IMPORT
  (
    cad_mtmd_filial_id,
    cad_set_id        ,
    cad_mtmd_id       ,
    cad_mtmd_qtde     ,
    inv_log_cd_barra  ,
    inv_log_data_ini_processo,
    inv_log_data_registro    ,
    inv_seg_usu_id_usuario   ,
    fl_excluido,
    mtmd_cod_lote,
    cad_mtmd_fechamento
  )
  VALUES
  (
    pCAD_MTMD_FILIAL_ID ,
    pCAD_SET_ID         ,
    vCAD_MTMD_ID        ,
    pLOG_QTDE_IMPORT    ,
    pLOG_CD_BARRA_IMPORT,
    pLOG_DATA_INI_IMPORT,
    SYSDATE             ,
    pSEG_USU_ID_USUARIO ,
    vFL_EXCLUIDO,
    NVL(pMTMD_COD_LOTE,'0'),
    pCAD_MTMD_FECHAMENTO
  );
END IF;
end PRC_CAD_MTMD_INVENTARIO_G;