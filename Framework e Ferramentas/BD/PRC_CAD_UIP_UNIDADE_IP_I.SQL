  create or replace procedure PRC_CAD_UIP_UNIDADE_IP_I 
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UIP_UNIDADE_IP.CAD_UNI_ID_UNIDADE%type default NULL,
     pCAD_UIP_ID_SEQUENCIA IN TB_CAD_UIP_UNIDADE_IP.CAD_UIP_ID_SEQUENCIA%type default NULL,
     pCAD_UIP_NR_IP_INICIO IN TB_CAD_UIP_UNIDADE_IP.CAD_UIP_NR_IP_INICIO%type,
     pCAD_UIP_NR_IP_TERMINO IN TB_CAD_UIP_UNIDADE_IP.CAD_UIP_NR_IP_TERMINO%type	
  ) 
  is  
  /********************************************************************
  *    Procedure: PRC_CAD_UIP_UNIDADE_IP_I
  * 
  *    Data Criacao: 	03/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:                       Por: 
  *
  *    Funcao: Inclui um IP de uma determinada Unidade
  *
  *******************************************************************/              
  lIdtSequencia integer;
  begin

    --Recupera a próxima sequencia para a unidade informada
    SELECT nvl(MAX(CAD_UIP_ID_SEQUENCIA),0) + 1 
           INTO lIdtSequencia
    FROM   TB_CAD_UIP_UNIDADE_IP
    WHERE  CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;
    
    INSERT INTO TB_CAD_UIP_UNIDADE_IP
    (
       CAD_UNI_ID_UNIDADE,
       CAD_UIP_ID_SEQUENCIA,
       CAD_UIP_NR_IP_INICIO,
       CAD_UIP_NR_IP_TERMINO
    )
    VALUES
    (
	     pCAD_UNI_ID_UNIDADE,
	     lIdtSequencia,
	     pCAD_UIP_NR_IP_INICIO,
	     pCAD_UIP_NR_IP_TERMINO
    );
  end PRC_CAD_UIP_UNIDADE_IP_I;
/
