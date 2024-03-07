
--PRC_AUX_EPP_ESPECPROC_R_I
create or replace procedure PRC_AUX_EPP_ESPECPROC_R_I
(
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%type,
     pAUX_EPP_DS_DESCRICAO IN TB_AUX_EPP_ESPECPROC.AUX_EPP_DS_DESCRICAO%type,
     pAUX_EPP_FL_ATENDSADT IN TB_AUX_EPP_ESPECPROC.AUX_EPP_FL_ATENDSADT%type default NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_AUX_EPP_ESPECPROC.TIS_MED_CD_TABELAMEDICA%type	
) 
is
/********************************************************************
*    Procedure: PRC_AUX_EPP_ESPECPROC_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_AUX_EPP_ESPECPROC
(
       AUX_EPP_CD_ESPECPROC,
       AUX_EPP_DS_DESCRICAO,
       AUX_EPP_FL_ATENDSADT,
       TIS_MED_CD_TABELAMEDICA
)
VALUES
(
	     pAUX_EPP_CD_ESPECPROC,
	     pAUX_EPP_DS_DESCRICAO,
	     pAUX_EPP_FL_ATENDSADT,
	     pTIS_MED_CD_TABELAMEDICA
);
	
end PRC_AUX_EPP_ESPECPROC_R_I;

