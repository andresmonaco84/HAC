
--PRC_AUX_EPP_ESPECPROC_R_U
create or replace procedure PRC_AUX_EPP_ESPECPROC_R_U
(
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%type,
     pAUX_EPP_DS_DESCRICAO IN TB_AUX_EPP_ESPECPROC.AUX_EPP_DS_DESCRICAO%type,
     pAUX_EPP_FL_ATENDSADT IN TB_AUX_EPP_ESPECPROC.AUX_EPP_FL_ATENDSADT%type default NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_AUX_EPP_ESPECPROC.TIS_MED_CD_TABELAMEDICA%type
) 
is
/********************************************************************
*    Procedure: PRC_AUX_EPP_ESPECPROC_R_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_AUX_EPP_ESPECPROC
SET	   
        AUX_EPP_DS_DESCRICAO = pAUX_EPP_DS_DESCRICAO,
        AUX_EPP_FL_ATENDSADT = pAUX_EPP_FL_ATENDSADT 
WHERE
        AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC
    AND TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA;	
end PRC_AUX_EPP_ESPECPROC_R_U;

