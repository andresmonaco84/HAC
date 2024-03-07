CREATE OR REPLACE PROCEDURE PRC_MTMD_MATMED_SETOR_S
   (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_SET_ID IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
   )   IS
  v_cursor PKG_CURSOR.t_cursor;
 /********************************************************************
  *    Procedure: PRC_MTMD_MATMED_SETOR_S
  *
  *    Data Criacao:    01/2010     Por: Ricardo Costa
  *    Data Alteracao: 14/04/2010   Por: Ricardo Costa
  *         Alteracao:  Adicionado campo ignora alta
  *    Data Alteracao: 10/05/2010   Por: Ricardo Costa
  *         Alteracao:  Adicionado campo Consome outros centro de custo
  *    Data Alteracao: 27/08/2010   Por: Ricardo Costa
  *         Alteracao:  ATUALIZADO MIGRA2
  *    Data Alteracao: 27/08/2010   Por: Ricardo Costa
  *         Alteracao:  Adicionado campos consumo direto e atende todas unidade
  *    Data Alteracao: 05/05/2011   Por: Andre S. Monaco
  *         Alteracao:  Adicionado campo MTMD_IGNORA_ALTA_HORAS_ATE
  *    Data Alteracao: 19/07/2011   Por: Andre S. Monaco
  *         Alteracao:  Adicionado campo MTMD_ESTOQUE_UNIFICADO_HAC
  *    Data Alteracao: 30/09/2015   Por: Andre S. Monaco
  *         Alteracao:  Adicionado campo MTMD_SOLICITA_KIT
*    Data Alteracao: 4/12/2017   Por: Andre S. Monaco
*         Alteracao:  Adicionado campos MTMD_CONTROLA_CONSUMO_PAC e MTMD_CONTROLA_CONS_PAC_DATA
  *
  *    Funcao: Recupera informac?es sobre permiss?es do setor
  *
  *******************************************************************/
BEGIN
    OPEN v_cursor FOR
    SELECT SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           SETOR.CAD_UNI_ID_UNIDADE,
           SETOR.CAD_SET_ID,
           SETOR.MTMD_ATENDE_PAC_TODOS_SETORES,
           SETOR.MTMD_IGNORA_ALTA,
           SETOR.MTMD_CONSOME_CENTRO_CUSTO,
           SETOR.MTMD_ATENDE_PAC_TODAS_UNIDADES,
           SETOR.MTMD_CONSOME_DIRETO_PACIENTE,
           SETOR.MTMD_IGNORA_ALTA_HORAS_ATE,
           SETOR.MTMD_ESTOQUE_UNIFICADO_HAC,
           SETOR.MTMD_SOLICITA_KIT,
           SETOR.MTMD_CONTROLA_CONSUMO_PAC,
           SETOR.MTMD_CONTROLA_CONS_PAC_DATA,
           SETOR.MTMD_FUN_ID_FUNCIONALIDADE
    FROM   TB_MTMD_MATMED_SETOR SETOR
    WHERE --SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO AND
          --SETOR.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE AND
          SETOR.CAD_SET_ID                   = pCAD_SET_ID;
    io_cursor := v_cursor;
END PRC_MTMD_MATMED_SETOR_S;