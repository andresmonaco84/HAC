CREATE OR REPLACE PROCEDURE "PRC_TIS_CBO_CBOS_ASS" (
     pCAD_PLA_ID_PLANO in TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_CBOS_ASS
  *
  *    Data Criacao:  16/08/2007   Por: Andrea Cazuca
  *    Funcao: Lista as Especialidades associada ao Plano
  *
  *    Data Alteracao: 21/09/2007  Por: Andrea Cazuca
  *    Alteracao: Inclus?o dos campos TIS_CBO_CD_CBOS_HAC e TIS_CBO_DS_CBOS_HAC
  *
  *    Data Alterac?o: 29/07/2008  Por: Pedro Carvalho
  *    Func?o:   Inclus?o de novos campo na tabela (TIS_CBO_FL_QTD_ATE_LIMITADA CHAR(1), TIS_CBO_QT_ATEND_PERM_ANO NUMBER(3))
  *
  *    Data Alteração:  07/04/2014  Por:  Andréa Cazuca
  *    Alteração:  Inclusão de novos campos TIS_CBO_VL_IDADE_LIMITE_ESP, TIS_CBO_CD_CBOS_NOVO, TIS_CBO_CD_CBOS_V3
  *                TIS_CBO_FL_STATUS
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
      A.TIS_CBO_CD_CBOS,
       A.TIS_CBO_DS_CBOS,
       A.TIS_CBO_FL_STATUS_ENCAMINHA,
       A.TIS_CBO_CD_CBOS_HAC,
       A.TIS_CBO_DS_CBOS_HAC,
       A.TIS_CBO_FL_QTD_ATE_LIMITADA,
       A.TIS_CBO_QT_ATEND_PERM_ANO,
       A.TIS_CBO_VL_IDADE_LIMITE_ESP,
       A.TIS_CBO_CD_CBOS_NOVO,
       A.TIS_CBO_CD_CBOS_V3,
       A.TIS_CBO_FL_STATUS
    FROM TB_TIS_CBO_CBOS A , TB_ASS_PLC_PLANO_CBOS B
                WHERE   B.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
                AND     B.TIS_CBO_CD_CBOS  = A.TIS_CBO_CD_CBOS;
    io_cursor := v_cursor;
    end PRC_TIS_CBO_CBOS_ASS;