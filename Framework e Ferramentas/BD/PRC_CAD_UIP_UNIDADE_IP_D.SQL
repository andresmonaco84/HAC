  create or replace procedure PRC_CAD_UIP_UNIDADE_IP_D 
  (
     pCAD_UIP_ID_SEQUENCIA IN TB_CAD_UIP_UNIDADE_IP.CAD_UIP_ID_SEQUENCIA%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UIP_UNIDADE_IP.CAD_UNI_ID_UNIDADE%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_UIP_UNIDADE_IP_D
  * 
  *    Data Criacao: 	03/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:                       Por: 
  *
  *    Funcao: Exclui um IP de uma determinada Unidade
  *
  *******************************************************************/                
  begin
    DELETE TB_CAD_UIP_UNIDADE_IP
    WHERE  
        CAD_UIP_ID_SEQUENCIA = pCAD_UIP_ID_SEQUENCIA
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;	   
  end PRC_CAD_UIP_UNIDADE_IP_D;
/
