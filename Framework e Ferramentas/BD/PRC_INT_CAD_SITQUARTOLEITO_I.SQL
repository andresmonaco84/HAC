  --PRC_INT_CAD_SITQUARTOLEITO_I
  create or replace procedure PRC_INT_CAD_SITQUARTOLEITO_I
  (
     pCAD_SQL_CD_SIT_QUARTO_LEITO IN TB_CAD_SQL_SIT_QUARTO_LEITO.CAD_SQL_CD_SIT_QUARTO_LEITO%type,
     pCAD_SQL_DS_SIT_QUARTO_LEITO IN TB_CAD_SQL_SIT_QUARTO_LEITO.CAD_SQL_DS_SIT_QUARTO_LEITO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_SITQUARTOLEITO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_CAD_SQL_SIT_QUARTO_LEITO
    (
       CAD_SQL_CD_SIT_QUARTO_LEITO,
       CAD_SQL_DS_SIT_QUARTO_LEITO
    )
    VALUES
    (
	     pCAD_SQL_CD_SIT_QUARTO_LEITO,
	     pCAD_SQL_DS_SIT_QUARTO_LEITO
    );
	
  end PRC_INT_CAD_SITQUARTOLEITO_I;