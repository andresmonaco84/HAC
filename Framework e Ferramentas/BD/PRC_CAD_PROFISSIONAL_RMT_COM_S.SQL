create or replace procedure PRC_CAD_PROFISSIONAL_RMT_COM_S
  (
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_PRO_ID_PROFISSIONAL%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PROFISSIONAL_RMT_COM_S
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT CBO.TIS_CBO_CD_CBOS,
       CBO.TIS_CBO_DS_CBOS,
       CBO.TIS_CBO_FL_STATUS_ENCAMINHA,
       CBO.TIS_CBO_CD_CBOS_HAC,
       CBO.TIS_CBO_DS_CBOS_HAC,
       CBO.TIS_CBO_FL_QTD_ATE_LIMITADA,
       CBO.TIS_CBO_QT_ATEND_PERM_ANO,
       CBO.TIS_CBO_VL_IDADE_LIMITE_ESP
  FROM TB_CAD_PRO_PROFISSIONAL      PRO,
       TB_ASS_UCP_UNID_LOC_CBO_PROF UCP,
       TB_TIS_CBO_CBOS              CBO
 WHERE PRO.CAD_PRO_ID_PROFISSIONAL = UCP.CAD_PRO_ID_PROFISSIONAL
   AND UCP.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
   AND PRO.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL
   AND UCP.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
   and UCP.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29;

    io_cursor := v_cursor;
  end PRC_CAD_PROFISSIONAL_RMT_COM_S;

