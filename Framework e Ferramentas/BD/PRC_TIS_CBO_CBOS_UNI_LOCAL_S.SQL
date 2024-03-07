CREATE OR REPLACE PROCEDURE "PRC_TIS_CBO_CBOS_UNI_LOCAL_S"
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type  default null,
     pASS_ULC_FL_STATUS IN TB_ASS_ULC_UNID_LOCAL_CBOS.ASS_ULC_FL_STATUS%type default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_CBOS_S
  *
  *    Data Criacao:   10/07/2007    Por: Carlos Eduardo
  *    Funcao: Lista as especialidades por Unidade e Local de Atendimento
  *
  *    Data Alteracao: 21/09/2007   Por: Andrea Cazuca
  *    Alteracao: Inclus?o dos campo TIS_CBO_CD_CBOS_HAC e TIS_CBO_DS_CBOS_HAC
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alterac?o: Remoc?o de Upper em campo, no where
  *
  *    Data Alterac?o: 29/07/2008  Por: Pedro Carvalho
  *    Func?o:   Inclus?o de novos campo na tabela (TIS_CBO_FL_QTD_ATE_LIMITADA CHAR(1), TIS_CBO_QT_ATEND_PERM_ANO NUMBER(3))
  *
  *    Data Alterac?o:  07/04/2014  Por: Andrea Cazuca
  *    Alterac?o: Inclus?o dos campos TIS_CBO_VL_IDADE_LIMITE_ESP, TIS_CBO_CD_CBOS_NOVO, TIS_CBO_CD_CBOS_V3,
  *               TIS_CBO_FL_STATUS
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT DISTINCT
       CBO.TIS_CBO_CD_CBOS,
       CBO.TIS_CBO_DS_CBOS,
       CBO.TIS_CBO_FL_STATUS_ENCAMINHA,
       CBO.TIS_CBO_CD_CBOS_HAC,
       CBO.TIS_CBO_DS_CBOS_HAC,
       CBO.TIS_CBO_FL_QTD_ATE_LIMITADA,
       CBO.TIS_CBO_QT_ATEND_PERM_ANO,
       CBO.TIS_CBO_VL_IDADE_LIMITE_ESP,
       CBO.TIS_CBO_CD_CBOS_NOVO,
       CBO.TIS_CBO_CD_CBOS_V3,
       CBO.TIS_CBO_FL_STATUS
    FROM TB_TIS_CBO_CBOS CBO,
         TB_ASS_ULC_UNID_LOCAL_CBOS ULC
    WHERE
        CBO.TIS_CBO_CD_CBOS = ULC.TIS_CBO_CD_CBOS
    AND (ULC.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ULC.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
    AND (pASS_ULC_FL_STATUS is null OR ASS_ULC_FL_STATUS LIKE UPPER(pASS_ULC_FL_STATUS))
    ORDER BY TIS_CBO_DS_CBOS_HAC;

    io_cursor := v_cursor;
  end PRC_TIS_CBO_CBOS_UNI_LOCAL_S;
 