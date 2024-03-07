
--PRC_TIS_TTP_TPTECNICA_PROCED_I
create or replace procedure PRC_TIS_TTP_TPTECNICA_PROCED_I
(
     pTIS_TTP_CD_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_CD_TPTECNICA%type,
     pTIS_TTP_DS_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_DS_TPTECNICA%type	
) 
is
/********************************************************************
*    Procedure: PRC_TIS_TTP_TPTECNICA_PROCED_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_TIS_TTP_TPTECNICA_PROCED
(
       TIS_TTP_CD_TPTECNICA,
       TIS_TTP_DS_TPTECNICA
)
VALUES
(
	     pTIS_TTP_CD_TPTECNICA,
	     pTIS_TTP_DS_TPTECNICA
);
	
end PRC_TIS_TTP_TPTECNICA_PROCED_I;

