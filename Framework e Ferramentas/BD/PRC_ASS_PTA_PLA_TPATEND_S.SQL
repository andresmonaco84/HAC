create or replace procedure PRC_ASS_PTA_PLA_TPATEND_S
  (
     pASS_PTA_ID IN TB_ASS_PTA_PLA_TPATEND.ASS_PTA_ID%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_PTA_PLA_TPATEND.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PTA_PLA_TPATEND_S
  *
  *    Data Criacao:   14/09/2009   Por: Alexandre M. Muniz
  *    Funcao: Lista a Associac?o Plano X Tipo de Atendimento
  *
  *    Data Alteracao:  -  Por: -
  *    Alteracao: -
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  
  begin
  
    OPEN v_cursor FOR
    SELECT
       ASS_PTA_ID,
       ASS_CTA_ID,
       CAD_PLA_ID_PLANO,       
       ASS_PTA_DS_MOTIVO_FIM_VIGENCIA,
       ASS_PTA_DT_ULTIMA_ATUALIZACAO,
       ASS_PTA_DT_INI_VIGENCIA,
       ASS_PTA_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_PTA_PLA_TPATEND
    WHERE
        (pASS_PTA_ID is null OR ASS_PTA_ID = pASS_PTA_ID)
    AND (pCAD_PLA_ID_PLANO is null or CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
    ORDER BY ASS_PTA_DT_INI_VIGENCIA DESC, ASS_PTA_DT_FIM_VIGENCIA DESC;
    
    io_cursor := v_cursor;
    
  end PRC_ASS_PTA_PLA_TPATEND_S;
