

--PRC_TIS_MED_TABELAMEDICA_R_S
create or replace procedure PRC_TIS_MED_TABELAMEDICA_R_S 
(
     pTIS_MED_CD_TABELAMEDICA IN TB_TIS_MED_TABELAMEDICA.TIS_MED_CD_TABELAMEDICA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_TIS_MED_TABELAMEDICA_R_S
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
       TIS_MED_CD_TABELAMEDICA,
       TIS_MED_DS_TABELAMEDICA,
       TIS_MED_DT_INICIO_VIGENCIA,
       TIS_MED_DT_FIM_VIGENCIA,
       TIS_MED_FL_STATUS,
       TIS_MED_FL_UTILIZA_LANCAMENTO,
       TIS_MED_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_TIS_MED_TABELAMEDICA
WHERE
        TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA;          
io_cursor := v_cursor;
end PRC_TIS_MED_TABELAMEDICA_R_S;
