  --PRC_INT_ASS_CTP_CUTA_PLA_S
  create or replace procedure PRC_CAD_ASS_CTP_CUTA_PLA_S 
  (
     pASS_CTP_ID IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_ID%type DEFAULT NULL,
     pASS_CUT_ID IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CUT_ID%type DEFAULT NULL,
     pASS_CTP_DT_INI_VIGENCIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_DT_INI_VIGENCIA%type DEFAULT NULL,
     pASS_CTP_DT_FIM_VIGENCIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_DT_FIM_VIGENCIA%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pASS_CTP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_ASS_CTP_CUTA_PLA_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       ASS_CTP_ID,
       ASS_CUT_ID,
       ASS_CTP_DT_INI_VIGENCIA,
       ASS_CTP_DT_FIM_VIGENCIA,
       CAD_PLA_ID_PLANO,
       ASS_CTP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_CTP_CNV_UN_TPACOM_PLA
    WHERE
        (pASS_CTP_ID is null OR ASS_CTP_ID = pASS_CTP_ID) AND 
        (pASS_CUT_ID is null OR ASS_CUT_ID = pASS_CUT_ID) AND 
        (pASS_CTP_DT_INI_VIGENCIA is null OR ASS_CTP_DT_INI_VIGENCIA = pASS_CTP_DT_INI_VIGENCIA) AND 
        (pASS_CTP_DT_FIM_VIGENCIA is null OR ASS_CTP_DT_FIM_VIGENCIA = pASS_CTP_DT_FIM_VIGENCIA) AND 
        (pCAD_PLA_ID_PLANO is null OR CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO) AND 
        (pASS_CTP_DT_ULTIMA_ATUALIZACAO is null OR ASS_CTP_DT_ULTIMA_ATUALIZACAO = pASS_CTP_DT_ULTIMA_ATUALIZACAO) AND 
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO);          
    io_cursor := v_cursor;
  end PRC_CAD_ASS_CTP_CUTA_PLA_S;
