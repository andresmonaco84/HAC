  --PRC_INT_TIS_INDACIDENTE_U
  create or replace procedure PRC_INT_TIS_INDACIDENTE_U
  (
     pTIS_IAC_CD_INDACIDENTE IN TB_TIS_IAC_INDACIDENTE.TIS_IAC_CD_INDACIDENTE%type,
     pTIS_IAC_DS_INDACIDENTE IN TB_TIS_IAC_INDACIDENTE.TIS_IAC_DS_INDACIDENTE%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_INDACIDENTE_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_TIS_IAC_INDACIDENTE
    SET	   
        TIS_IAC_DS_INDACIDENTE = pTIS_IAC_DS_INDACIDENTE 
    WHERE
        TIS_IAC_CD_INDACIDENTE = pTIS_IAC_CD_INDACIDENTE;	
  end PRC_INT_TIS_INDACIDENTE_U;

