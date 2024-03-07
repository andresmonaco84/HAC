create or replace procedure PRC_ASS_PPI_PLAPRODUTOINT_SID
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PPI_PLAPRODUTOINT.CAD_CNV_ID_CONVENIO%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PPI_PLAPRODUTOINT.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_PPI_PLAPRODUTOINT.CAD_PLA_ID_PLANO%type,
     pCAD_PRD_ID IN TB_ASS_PPI_PLAPRODUTOINT.CAD_PRD_ID%type     ,io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPI_PLAPRODUTOINT_SID
  *
  *    Data Criacao:   19/11/2009    Por: Fabíola
  *    Data Alteracao: 28/12/2010    Por: André S. Monaco
  *         Alteracao: Inclusão do campo ASS_PPI_DS_MSG_EXIGENCIA
  *
  *    Funcao: Lista exigência do convênio
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_PRD_ID,
       ASS_PPI_FL_EXIGE_GUIA,
       ASS_PPI_FL_EXIGE_SENHA,
       ASS_PPI_FL_AUTORIZATEL,
       ASS_PPI_FL_AUTORIZAFAX,
       ASS_PPI_FL_AUTORIZAPES,
       ASS_PPI_FL_AUTORIZAWEB,
       ASS_PPI_FL_COBERTURA,
       ASS_PPI_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_PPI_DT_ULTIMA_ATUALIZACAO,
       ASS_PPI_QT_MAXIMA_LANC_DIA,
       ASS_PPI_DS_MSG_EXIGENCIA
    FROM TB_ASS_PPI_PLAPRODUTOINT
    WHERE
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
    AND CAD_PRD_ID = pCAD_PRD_ID;
    io_cursor := v_cursor;
  end PRC_ASS_PPI_PLAPRODUTOINT_SID;
