

  --PRC_CAD_CID_CID10_U
  create or replace procedure PRC_CAD_CID_CID10_U
  (
     pCAD_CID_CD_CID10 IN TB_CAD_CID_CID10.CAD_CID_CD_CID10%type,
     pCAD_CID_DS_CID10 IN TB_CAD_CID_CID10.CAD_CID_DS_CID10%type default NULL,
     pCAD_CGR_CD_GRUPO IN TB_CAD_CID_CID10.CAD_CGR_CD_GRUPO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: {nome da procedure}
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	25/05/2007  Por: Silmara
  *    Alteraçao: Foi alterado os parâmetros para gravar em maiúsculo 
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_CID_CID10
    SET	   
        CAD_CID_DS_CID10 = UPPER(pCAD_CID_DS_CID10),
        CAD_CGR_CD_GRUPO = UPPER(pCAD_CGR_CD_GRUPO) 
    WHERE
        CAD_CID_CD_CID10 = pCAD_CID_CD_CID10;	
  end PRC_CAD_CID_CID10_U;

