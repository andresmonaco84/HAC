CREATE OR REPLACE PROCEDURE "PRC_TIS_CBO_CBOS_DISP" (
     pCAD_PLA_ID_PLANO in TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_CBOS_DISP
  *
  *    Data Criacao:  16/08/2007   Por: Andrea Cazuca
  *    Funcao: Lista as Especialidades disponiveis
  *
  *    Data Alteracao: 21/09/2007 Por Andrea Cazuca
  *    Alteracao: Inclusao dos campos TIS_CBO_CD_CBOS_HAC e TIS_CBO_DS_CBOS_HAC
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
      CBOS.TIS_CBO_CD_CBOS,
       CBOS.TIS_CBO_DS_CBOS,
       CBOS.TIS_CBO_FL_STATUS_ENCAMINHA,
       CBOS.TIS_CBO_CD_CBOS_HAC,
       CBOS.TIS_CBO_DS_CBOS_HAC,
       CBOS.TIS_CBO_FL_QTD_ATE_LIMITADA,
       CBOS.TIS_CBO_QT_ATEND_PERM_ANO,
       CBOS.TIS_CBO_VL_IDADE_LIMITE_ESP,
       CBOS.TIS_CBO_CD_CBOS_NOVO,
       CBOS.TIS_CBO_CD_CBOS_V3,
       CBOS.TIS_CBO_FL_STATUS
    FROM TB_TIS_CBO_CBOS CBOS
         WHERE
    NOT EXISTS (SELECT 1
                FROM    TB_ASS_PLC_PLANO_CBOS P
                WHERE   P.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
                AND     p.TIS_CBO_CD_CBOS = CBOS.TIS_CBO_CD_CBOS);
    io_cursor := v_cursor;
    end PRC_TIS_CBO_CBOS_DISP;
 