--PRC_CAD_FER_FERIADO_S
  create or replace procedure PRC_CAD_FER_FERIADO_OBTER_S 
  (
     pCAD_FER_ID_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_ID_FERIADO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_FER_FERIADO_OBTER_S
  * 
  *    Data Criacao: 	05/10/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Obtem registros da tabela TB_CAD_FER_FERIADO
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_FER_ID_FERIADO,
       CAD_UNI_ID_UNIDADE,
       CAD_FER_DT_FERIADO,
       CAD_FER_TP_FERIADO,
       CAD_FER_DS_FERIADO,
       CAD_FER_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
       
    FROM TB_CAD_FER_FERIADO
    WHERE
    CAD_FER_ID_FERIADO = pCAD_FER_ID_FERIADO
    ORDER BY CAD_FER_DT_FERIADO;
    

    io_cursor := v_cursor;
  end PRC_CAD_FER_FERIADO_OBTER_S;
/
