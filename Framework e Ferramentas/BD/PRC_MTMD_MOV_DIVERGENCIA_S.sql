create or replace procedure PRC_MTMD_MOV_DIVERGENCIA_S
(
   pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_FILIAL_ID%type default NULL,
   pMTMD_MOV_FL_FINALIZADO IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_FL_FINALIZADO%type default NULL,
   io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_MTMD_MOV_COMPLEMENTO_S
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao: data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
  SELECT MOV.MTMD_MOV_ID,
         UNIDADE.CAD_UNI_DS_UNIDADE,
         LOC.CAD_LAT_DS_LOCAL_ATENDIMENTO,
         SETOR.CAD_SET_DS_SETOR,
         PROD.CAD_MTMD_NOMEFANTASIA,
         MOV.MTMD_MOV_QTDE,
         MOV.MTMD_MOV_DATA,
         MOV.MTMD_REQ_ID,
         MOV.MTMD_MOV_FL_FINALIZADO
  FROM TB_MTMD_MOV_MOVIMENTACAO     MOV,
       TB_MTMD_MOV_COMPLEMENTO      COMP,
       TB_CAD_SET_SETOR             SETOR,
       TB_CAD_LAT_LOCAL_ATENDIMENTO LOC,
       TB_CAD_UNI_UNIDADE           UNIDADE,
       TB_CAD_MTMD_MAT_MED          PROD
  WHERE COMP.MTMD_MOV_ID           = MOV.MTMD_MOV_ID
    AND MOV.CAD_UNI_ID_UNIDADE     = UNIDADE.CAD_UNI_ID_UNIDADE
    AND MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO = LOC.CAD_LAT_ID_LOCAL_ATENDIMENTO
    AND MOV.CAD_SET_ID             = SETOR.CAD_SET_ID
    AND MOV.CAD_MTMD_ID            = PROD.CAD_MTMD_ID
    AND MOV.MTMD_MOV_FL_FINALIZADO = pMTMD_MOV_FL_FINALIZADO
    AND MOV.CAD_MTMD_FILIAL_ID     = pCAD_MTMD_FILIAL_ID
    AND MOV.MTMD_MOV_DATA >= SYSDATE-3
    ORDER BY MOV.MTMD_MOV_DATA;
  io_cursor := v_cursor;
end PRC_MTMD_MOV_DIVERGENCIA_S;