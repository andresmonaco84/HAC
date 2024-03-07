CREATE OR REPLACE PROCEDURE "PRC_ASS_CDP_CNV_DC_LOC_PLANO_S" (
     pASS_CDP_ID_CNVDCPLANO IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDP_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CDP_CNV_DC_LOC_PLANO_S
  * 
  *    Data Criacao: 	28/06/2007         Por: Fabiola Lopes
  *    Data Alteracao:	data da alteracao  Por: Nome do Analista
  *
  *    Funcao: Descricao da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       ASS_CDP_ID,
       ASS_CDL_ID,
       CAD_PLA_ID_PLANO,
       ASS_CDP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_CDP_CNV_DC_LOC_PLANO
    WHERE
        (pASS_CDP_ID_CNVDCPLANO is null OR ASS_CDP_ID = pASS_CDP_ID_CNVDCPLANO);          
    io_cursor := v_cursor;
  end PRC_ASS_CDP_CNV_DC_LOC_PLANO_S;
