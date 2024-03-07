
--PRC_SEG_MOD_MODULO_R_U
create or replace procedure PRC_SEG_MOD_MODULO_R_U
(
     pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type,
     pSEG_MOD_NM_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_NM_MODULO%type,
     pSEG_MOD_DS_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_DS_MODULO%type,
     pSEG_MOD_CD_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_CD_MODULO%type,
     pSEG_MOD_DS_SISTEMA IN TB_SEG_MOD_MODULO.SEG_MOD_DS_SISTEMA%type,
     pSEG_MOD_DS_VERSAO IN TB_SEG_MOD_MODULO.SEG_MOD_DS_VERSAO%type default NULL,
     pSEG_MOD_DT_VERSAO IN TB_SEG_MOD_MODULO.SEG_MOD_DT_VERSAO%type default NULL
) 
is
/********************************************************************
*    Procedure: PRC_SEG_MOD_MODULO_R_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_SEG_MOD_MODULO
SET	   
        SEG_MOD_NM_MODULO = pSEG_MOD_NM_MODULO,
        SEG_MOD_DS_MODULO = pSEG_MOD_DS_MODULO,
        SEG_MOD_CD_MODULO = pSEG_MOD_CD_MODULO,
        SEG_MOD_DS_SISTEMA = pSEG_MOD_DS_SISTEMA,
        SEG_MOD_DS_VERSAO = pSEG_MOD_DS_VERSAO,
        SEG_MOD_DT_VERSAO = pSEG_MOD_DT_VERSAO 
WHERE
        SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO;	
end PRC_SEG_MOD_MODULO_R_U;

