
--PRC_SEG_FUN_FUNCIONALID_R_I
create or replace procedure PRC_SEG_FUN_FUNCIONALID_R_I
(
     pNewIdt OUT integer,
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_FUN_FUNCIONALIDADE.SEG_FUN_ID_FUNCIONALIDADE%type default NULL,
     pSEG_FUN_DS_DESCRICAO IN TB_SEG_FUN_FUNCIONALIDADE.SEG_FUN_DS_DESCRICAO%type default NULL,
     pSEG_FUN_FL_ITEM_MENU_OK IN TB_SEG_FUN_FUNCIONALIDADE.SEG_FUN_FL_ITEM_MENU_OK%type,
     pSEG_FUN_ID_FUNCIONALIDADE_PAI IN TB_SEG_FUN_FUNCIONALIDADE.SEG_FUN_ID_FUNCIONALIDADE_PAI%type default NULL,
     pSEG_FUN_DS_NOME_PAGINA IN TB_SEG_FUN_FUNCIONALIDADE.SEG_FUN_DS_NOME_PAGINA%type default NULL,
     pSEG_FUN_NM_NOME IN TB_SEG_FUN_FUNCIONALIDADE.SEG_FUN_NM_NOME%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_FUN_FUNCIONALIDADE.SEG_MOD_ID_MODULO%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_SEG_FUN_FUNCIONALID_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_SEG_FUNCIONALIDADE.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_SEG_FUN_FUNCIONALIDADE
(
       SEG_FUN_ID_FUNCIONALIDADE,
       SEG_FUN_DS_DESCRICAO,
       SEG_FUN_FL_ITEM_MENU_OK,
       SEG_FUN_ID_FUNCIONALIDADE_PAI,
       SEG_FUN_DS_NOME_PAGINA,
       SEG_FUN_NM_NOME,
       SEG_MOD_ID_MODULO
)
VALUES
(
      lIdtRetorno,
	     pSEG_FUN_DS_DESCRICAO,
	     pSEG_FUN_FL_ITEM_MENU_OK,
	     pSEG_FUN_ID_FUNCIONALIDADE_PAI,
	     pSEG_FUN_DS_NOME_PAGINA,
	     pSEG_FUN_NM_NOME,
	     pSEG_MOD_ID_MODULO
);
    pNewIdt := lIdtRetorno;	
end PRC_SEG_FUN_FUNCIONALID_R_I;

