create or replace procedure PRC_ASS_CTP_CNV_UN_TPACO_PLA_S
  (
     pASS_CTP_ID IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_ID%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTP_CNV_UN_TPACO_PLA_S
  *
  *    Data Criacao: 	28/06/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da altera???#o  Por: Nome do Analista
  *    Funcao: Lista a Associacao Convenio X Plano X Tipo Acomodacao
  *
  *    Data Alteracao: 16/08/2010    Por: Rafael Coimbra
  *    Funcao: Incluidos os campos ASS_CTP_PC_HM_ACOMODACAO, 
  *    ASS_CTP_PC_HM_ARTROSCOPIA e ASS_CTP_PC_HM_LAPAROSCOPIA
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
       SEG_USU_ID_USUARIO,
       TRUNC(ASS_CTP_PC_HM_ACOMODACAO, 2) AS ASS_CTP_PC_HM_ACOMODACAO,
       TRUNC(ASS_CTP_PC_HM_ARTROSCOPIA, 2) AS ASS_CTP_PC_HM_ARTROSCOPIA,
       TRUNC(ASS_CTP_PC_HM_LAPAROSCOPIA, 2) AS ASS_CTP_PC_HM_LAPAROSCOPIA
    FROM TB_ASS_CTP_CNV_UN_TPACOM_PLA
    WHERE ( pCAD_PLA_ID_PLANO IS NULL OR CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
     AND    (pASS_CTP_ID is null OR ASS_CTP_ID = pASS_CTP_ID)
    ORDER BY ASS_CTP_DT_INI_VIGENCIA DESC, ASS_CTP_DT_FIM_VIGENCIA DESC;
    io_cursor := v_cursor;
  end PRC_ASS_CTP_CNV_UN_TPACO_PLA_S;
