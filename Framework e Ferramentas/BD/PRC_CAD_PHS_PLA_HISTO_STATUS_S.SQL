create or replace procedure PRC_CAD_PHS_PLA_HISTO_STATUS_S
  (
     pCAD_PHS_ID IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_ID%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PLA_ID_PLANO%type default null,
     pCAD_PHS_DT_INI_VIGENCIA  IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_DT_INI_VIGENCIA%type default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PHS_PLA_HISTO_STATUS_S
  *
  *    Data Criacao: 10/08/2007   Por: Guilherme Holdack
  *
  *    Funcao: Selecionar registros na tabela TB_CAD_PHS_PLA_HISTO_STATUS
  *
  *    Data Alteracao: 17/09/2009 Por: Alexandre M. Muniz
  *    Descrição: Eliminar a data de início do filtro e fazer com que 
  *               apenas a 2ª linha mais recente do histórico seja 
  *               retornada quando se quiser saber o último registro
  *               do histórico.
  *******************************************************************/
    v_cursor PKG_CURSOR.t_cursor;
  begin
    IF (pCAD_PHS_ID IS NULL AND pCAD_PLA_ID_PLANO IS NOT NULL AND pCAD_PHS_DT_INI_VIGENCIA IS NOT NULL) THEN        
        OPEN v_cursor FOR
        SELECT CAD_PHS_ID,
               CAD_PLA_ID_PLANO,
               CAD_PHS_DT_INI_VIGENCIA,
               CAD_PHS_DT_FIM_VIGENCIA,
               CAD_PHS_FL_STATUS,
               CAD_PHS_DT_ULTIMA_ATUALIZACAO,
               SEG_USU_ID_USUARIO ,
               CAD_PHS_DT_INCLUSAO
          FROM (SELECT CAD_PHS_ID,
                       CAD_PLA_ID_PLANO,
                       CAD_PHS_DT_INI_VIGENCIA,
                       CAD_PHS_DT_FIM_VIGENCIA,
                       CAD_PHS_FL_STATUS,
                       CAD_PHS_DT_ULTIMA_ATUALIZACAO,
                       SEG_USU_ID_USUARIO,
                       CAD_PHS_DT_INCLUSAO
                  FROM (SELECT CAD_PHS_ID,
                               CAD_PLA_ID_PLANO,
                               CAD_PHS_DT_INI_VIGENCIA,
                               CAD_PHS_DT_FIM_VIGENCIA,
                               CAD_PHS_FL_STATUS,
                               CAD_PHS_DT_ULTIMA_ATUALIZACAO,
                               SEG_USU_ID_USUARIO,
                               CAD_PHS_DT_INCLUSAO
                          FROM (SELECT CAD_PHS_ID,
                                       CAD_PLA_ID_PLANO,
                                       CAD_PHS_DT_INI_VIGENCIA,
                                       CAD_PHS_DT_FIM_VIGENCIA,
                                       CAD_PHS_FL_STATUS,
                                       CAD_PHS_DT_ULTIMA_ATUALIZACAO,
                                       SEG_USU_ID_USUARIO,
                                       CAD_PHS_DT_INCLUSAO
                                  FROM TB_CAD_PHS_PLA_HISTO_STATUS
                                 WHERE (pCAD_PHS_ID is null OR CAD_PHS_ID = pCAD_PHS_ID)
                                   AND (pCAD_PLA_ID_PLANO is null or CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)                                   
                              ORDER BY CAD_PHS_ID DESC) HIST
                         WHERE ROWNUM < 3) HIST_A
              ORDER BY CAD_PHS_ID) HIST_B
         WHERE ROWNUM < 2;
    ELSE
        OPEN v_cursor FOR
        SELECT   CAD_PHS_ID,
                 CAD_PLA_ID_PLANO,
                 CAD_PHS_DT_INI_VIGENCIA,
                 CAD_PHS_DT_FIM_VIGENCIA,
                 CAD_PHS_FL_STATUS,
                 CAD_PHS_DT_ULTIMA_ATUALIZACAO,
                 SEG_USU_ID_USUARIO,
                 CAD_PHS_DT_INCLUSAO
          FROM   TB_CAD_PHS_PLA_HISTO_STATUS
         WHERE   (pCAD_PHS_ID is null OR CAD_PHS_ID = pCAD_PHS_ID)
           AND   (pCAD_PLA_ID_PLANO is null or CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
           AND   (pCAD_PHS_DT_INI_VIGENCIA is null OR CAD_PHS_DT_INI_VIGENCIA = pCAD_PHS_DT_INI_VIGENCIA)
        ORDER BY CAD_PHS_ID DESC;       
    END IF;
    io_cursor := v_cursor;
  end PRC_CAD_PHS_PLA_HISTO_STATUS_S;
 