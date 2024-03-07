
--PRC_TIS_TTP_TPTECNICA_PROCED_U
create or replace procedure PRC_TIS_TTP_TPTECNICA_PROCED_U
(
     pTIS_TTP_CD_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_CD_TPTECNICA%type,
     pTIS_TTP_DS_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_DS_TPTECNICA%type
) 
is
/********************************************************************
*    Procedure: PRC_TIS_TTP_TPTECNICA_PROCED_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_TIS_TTP_TPTECNICA_PROCED
SET	   
        TIS_TTP_DS_TPTECNICA = pTIS_TTP_DS_TPTECNICA 
WHERE
        TIS_TTP_CD_TPTECNICA = pTIS_TTP_CD_TPTECNICA;	
end PRC_TIS_TTP_TPTECNICA_PROCED_U;

