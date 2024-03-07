

--PRC_TIS_TTP_TPTECNICA_PROCED_D
create or replace procedure PRC_TIS_TTP_TPTECNICA_PROCED_D 
(
     pTIS_TTP_CD_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_CD_TPTECNICA%type	
)
is
/********************************************************************
*    Procedure: PRC_TIS_TTP_TPTECNICA_PROCED_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_TIS_TTP_TPTECNICA_PROCED
WHERE  
        TIS_TTP_CD_TPTECNICA = pTIS_TTP_CD_TPTECNICA;	   
end PRC_TIS_TTP_TPTECNICA_PROCED_D;
