CREATE OR REPLACE PROCEDURE "PRC_TIS_CBO_PLA_UNI_LAT_S"
  (
     pCAD_PLA_CD_PLANO_HAC IN TB_CAD_PLA_PLANO.CAD_PLA_CD_PLANO_HAC%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
     pASS_ULC_FL_STATUS IN TB_ASS_ULC_UNID_LOCAL_CBOS.ASS_ULC_FL_STATUS%type default null,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_PLA_PLANO.CAD_CNV_ID_CONVENIO%TYPE,
     pCAD_PRO_ID_PROFISSIONAL IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_PLA_UNI_LAT_S
  *    Func?o: Lista as Especialidades de acordo com Plano x Unidade x Local
  *
  *    Data Alteracao:  11/11/2008  Por: Andrea Cazuca
  *    Alterac?o:       Inclus?o do parametro CAD_PRO_ID_PROFISSIONAL e inclus?o da tabela TB_ASS_PCB_PROFISSIONAL_CBOS
  *
  *    Data Alteracao:  26/08/2009  Por: Pedro
  *    Alterac?o:       V_WHERE := V_WHERE || ' AND PCB.ASS_PCB_FL_STATUS = ' '||CHR(39)||A||CHR(39)||';
  *
  *    Data Alteração:  07/04/2014  Por:  Andréa Cazuca
  *    Alteração:  Inclusão de novos campos TIS_CBO_VL_IDADE_LIMITE_ESP, TIS_CBO_CD_CBOS_NOVO, TIS_CBO_CD_CBOS_V3
  *                TIS_CBO_FL_STATUS
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_FROM   varchar2(2000);
  V_SELECT  varchar2(2000);
  begin
    V_WHERE := NULL;
    V_FROM := NULL;
    IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND ULC.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE;
    END IF;
    IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND ULC.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO;
    END IF;
    IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND PLA.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;
    END IF;
    IF pCAD_PRO_ID_PROFISSIONAL IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CBO.TIS_CBO_CD_CBOS = PCB.TIS_CBO_CD_CBOS';
       V_WHERE := V_WHERE || ' AND PCB.CAD_PRO_ID_PROFISSIONAL = ' || pCAD_PRO_ID_PROFISSIONAL;
       V_WHERE := V_WHERE || ' AND PCB.ASS_PCB_FL_STATUS = '||CHR(39)||'A'||CHR(39);
       V_FROM := V_FROM ||
               ', TB_ASS_PCB_PROFISSIONAL_CBOS PCB';
    END IF;
    V_SELECT := 'SELECT CBO.TIS_CBO_CD_CBOS,
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
           TB_ASS_PLC_PLANO_CBOS PLC,
           TB_ASS_ULC_UNID_LOCAL_CBOS ULC,
           TB_CAD_PLA_PLANO PLA ' || V_FROM ||
   ' WHERE PLC.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
       AND CBO.TIS_CBO_CD_CBOS = ULC.TIS_CBO_CD_CBOS
       AND PLC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
       AND PLA.CAD_PLA_CD_PLANO_HAC = '||CHR(39)||pCAD_PLA_CD_PLANO_HAC||CHR(39)||'
       AND ('||CHR(39)||pASS_ULC_FL_STATUS||CHR(39)||' IS NULL OR ULC.ASS_ULC_FL_STATUS = '||CHR(39)||pASS_ULC_FL_STATUS||CHR(39)||')'
       || V_WHERE || '
  ORDER BY CBO.TIS_CBO_DS_CBOS_HAC';
  OPEN v_cursor FOR
    V_SELECT;
    io_cursor := v_cursor;
  end PRC_TIS_CBO_PLA_UNI_LAT_S;
 