

--PRC_AUX_FPG_FORMAPAGTO_S
create or replace procedure PRC_AUX_FPG_FORMAPAGTO_S 
(
     pAUX_FPG_CD_FORMAPAGTO IN TB_AUX_FPG_FORMAPAGTO.AUX_FPG_CD_FORMAPAGTO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_AUX_FPG_FORMAPAGTO_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       AUX_FPG_CD_FORMAPAGTO,
       AUX_FPG_DS_FORMAPAGTO
FROM TB_AUX_FPG_FORMAPAGTO
WHERE
        AUX_FPG_CD_FORMAPAGTO = pAUX_FPG_CD_FORMAPAGTO;          
io_cursor := v_cursor;
end PRC_AUX_FPG_FORMAPAGTO_S;
