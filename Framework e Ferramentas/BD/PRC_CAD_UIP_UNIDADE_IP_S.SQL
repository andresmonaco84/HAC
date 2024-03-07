   create or replace procedure PRC_CAD_UIP_UNIDADE_IP_S 
  (
     pCAD_UIP_ID_SEQUENCIA IN TB_CAD_UIP_UNIDADE_IP.CAD_UIP_ID_SEQUENCIA%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UIP_UNIDADE_IP.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_UIP_UNIDADE_IP_S
  * 
  *    Data Criacao: 	03/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:                       Por: 
  *
  *    Funcao: Obtém o(s) IPs cadastrados de uma determinada Unidade
  *
  *******************************************************************/            
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_UNI_ID_UNIDADE,
       CAD_UIP_ID_SEQUENCIA,
       CAD_UIP_NR_IP_INICIO,
       CAD_UIP_NR_IP_TERMINO
    FROM TB_CAD_UIP_UNIDADE_IP
    WHERE
        (pCAD_UIP_ID_SEQUENCIA is null OR CAD_UIP_ID_SEQUENCIA = pCAD_UIP_ID_SEQUENCIA) AND 
        (pCAD_UNI_ID_UNIDADE is null OR CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    ORDER BY CAD_UIP_ID_SEQUENCIA;
    io_cursor := v_cursor;
  end PRC_CAD_UIP_UNIDADE_IP_S;
/
