 create or replace procedure PRC_CAD_TIH_TP_INDICE_HOSP_SID 
  (
     pCAD_TIH_TP_INDICE_HOSP IN TB_CAD_TIH_TP_INDICE_HOSP.CAD_TIH_TP_INDICE_HOSP%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TIH_TP_INDICE_HOSP_SID
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
    SELECT  
       CAD_TIH_TP_INDICE_HOSP,
       CAD_TIH_DS_INDICE_HOSP,
       CAD_TIH_FL_STATUS,
       CAD_TIH_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_CAD_TIH_TP_INDICE_HOSP
    WHERE
        CAD_TIH_TP_INDICE_HOSP = pCAD_TIH_TP_INDICE_HOSP;          
    io_cursor := v_cursor;
  end PRC_CAD_TIH_TP_INDICE_HOSP_SID;