  --PRC_CAD_TEL_TELEFONE_RMT_SID
  create or replace procedure PRC_CAD_TEL_TELEFONE_RMT_SID 
  (
     pCAD_TEL_ID_TELEFONE IN TB_CAD_TEL_TELEFONE.CAD_TEL_ID_TELEFONE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TEL_TELEFONE_RMT_SID
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
       CAD_TEL_ID_TELEFONE,
       CAD_TEL_NR_NUM_TEL,
       CAD_TEL_NR_RAMAL_TEL,
       CAD_TEL_NM_CONTATO,
       CAD_TEL_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       AUX_TTE_CD_TP_TEL_END,
       CAD_PES_ID_PESSOA
    FROM TB_CAD_TEL_TELEFONE
    WHERE
        CAD_TEL_ID_TELEFONE = pCAD_TEL_ID_TELEFONE;          
    io_cursor := v_cursor;
  end PRC_CAD_TEL_TELEFONE_RMT_SID;
