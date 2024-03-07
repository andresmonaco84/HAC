  --PRC_INT_TIS_INDACIDENTE_I
  create or replace procedure PRC_INT_TIS_INDACIDENTE_I
  (
     pTIS_IAC_CD_INDACIDENTE IN TB_TIS_IAC_INDACIDENTE.TIS_IAC_CD_INDACIDENTE%type,
     pTIS_IAC_DS_INDACIDENTE IN TB_TIS_IAC_INDACIDENTE.TIS_IAC_DS_INDACIDENTE%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_INDACIDENTE_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_TIS_IAC_INDACIDENTE
    (
       TIS_IAC_CD_INDACIDENTE,
       TIS_IAC_DS_INDACIDENTE
    )
    VALUES
    (
	     pTIS_IAC_CD_INDACIDENTE,
	     pTIS_IAC_DS_INDACIDENTE
    );
	
  end PRC_INT_TIS_INDACIDENTE_I;

