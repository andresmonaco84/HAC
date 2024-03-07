CREATE OR REPLACE PROCEDURE "PRC_CAD_LAT_LOCATE_CNV_UNI_S" (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pDATABASE DATE,
     pCAD_LAT_FL_ATIVO_OK IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_FL_ATIVO_OK%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_LAT_LOCATE_CNV_UNI_S
  *
  *    Data Criacao: 	  25/07/2007  Por: Carlos Araujo
  *    Funcao: Lista os Locais de Atendimentos por Convênio x Unidade e Vigência
  *
  *    Data Alteracao:	            Por:
  *    Alteracao:
  *
  *    Data Alteracao: 25/03/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do campo CAD_LAT_FL_PERMITE_ATEND (tarefa 8107)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
           LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
           LAT.CAD_LAT_FL_ATIVO_OK,
           LAT.CAD_LAT_DT_ULTIMA_ATUALIZACAO,
           LAT.SEG_USU_ID_USUARIO,
           LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,
           LAT.CAD_LAT_FL_PERMITE_ATEND
    FROM   TB_ASS_CUL_CONV_UNI_LOCATEND CUL,
           TB_ASS_CNU_CONVENIO_UNIDADE CNU,
           TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
    WHERE CUL.ASS_CNU_ID = CNU.ASS_CNU_ID
    AND   CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    AND   CNU.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND   CNU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND   (pCAD_LAT_FL_ATIVO_OK is null OR LAT.CAD_LAT_FL_ATIVO_OK = pCAD_LAT_FL_ATIVO_OK)
    AND   (
            (pDATABASE BETWEEN  CUL.ASS_CUL_DT_INI_VIGENCIA AND CUL.ASS_CUL_DT_FIM_VIGENCIA) OR
            (CUL.ASS_CUL_DT_INI_VIGENCIA <= pDATABASE AND CUL.ASS_CUL_DT_FIM_VIGENCIA IS NULL)
          )
    ORDER BY LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO;
    io_cursor := v_cursor;
  end PRC_CAD_LAT_LOCATE_CNV_UNI_S;
/
