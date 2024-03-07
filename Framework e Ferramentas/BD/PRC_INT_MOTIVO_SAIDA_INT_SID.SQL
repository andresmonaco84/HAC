  --PRC_INT_MOTIVO_SAIDA_INT_SID
  create or replace procedure PRC_INT_MOTIVO_SAIDA_INT_SID 
  (
     pTIS_MSI_CD_MOTIVOSAIDAINT IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_CD_MOTIVOSAIDAINT%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_MOTIVO_SAIDA_INT_SID
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
       TIS_MSI_CD_MOTIVOSAIDAINT,
       TIS_MSI_CD_TIPOALTA,
       TIS_MSI_DS_MOTIVOSAIDAINT,
       TIS_MSI_FL_STATUS
    FROM TB_TIS_MSI_MOTIVO_SAIDA_INT
    WHERE
        TIS_MSI_CD_MOTIVOSAIDAINT = pTIS_MSI_CD_MOTIVOSAIDAINT;          
    io_cursor := v_cursor;
  end PRC_INT_MOTIVO_SAIDA_INT_SID;
