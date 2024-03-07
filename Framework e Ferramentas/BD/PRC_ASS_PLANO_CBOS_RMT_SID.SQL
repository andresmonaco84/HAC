  --PRC_ASS_PLANO_CBOS_RMT_SID
  create or replace procedure PRC_ASS_PLANO_CBOS_RMT_SID 
  (
     pCAD_PLA_ID_PLANO IN TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_PLC_PLANO_CBOS.TIS_CBO_CD_CBOS%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLANO_CBOS_RMT_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_PLA_ID_PLANO,
       TIS_CBO_CD_CBOS,
       ASS_PLC_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_PLC_DT_ULTIMA_ATUALIZACAO,
       ASS_PLC_FL_ENCAMINHA_OK,
       ASS_PLC_FL_EXIGE_SENHA_OK
    FROM TB_ASS_PLC_PLANO_CBOS
    WHERE
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;          
    io_cursor := v_cursor;
  end PRC_ASS_PLANO_CBOS_RMT_SID;
