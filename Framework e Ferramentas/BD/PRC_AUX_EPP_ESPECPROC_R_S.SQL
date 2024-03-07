
--PRC_AUX_EPP_ESPECPROC_R_S
create or replace procedure PRC_AUX_EPP_ESPECPROC_R_S 
(
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%type,
     pTIS_MED_CD_TABELAMEDICA IN TB_AUX_EPP_ESPECPROC.TIS_MED_CD_TABELAMEDICA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_AUX_EPP_ESPECPROC_R_S
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
       AUX_EPP_CD_ESPECPROC,
       AUX_EPP_DS_DESCRICAO,
       AUX_EPP_FL_ATENDSADT,
       TIS_MED_CD_TABELAMEDICA
FROM TB_AUX_EPP_ESPECPROC
WHERE
        AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC
    AND TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA;          
io_cursor := v_cursor;
end PRC_AUX_EPP_ESPECPROC_R_S;
