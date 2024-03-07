
--PRC_AUX_GPC_GRUPOPROC_R_I
create or replace procedure PRC_AUX_GPC_GRUPOPROC_R_I
(
     pAUX_GPC_CD_GRUPOPROC IN TB_AUX_GPC_GRUPOPROC.AUX_GPC_CD_GRUPOPROC%type,
     pAUX_GPC_DS_DESCRICAO IN TB_AUX_GPC_GRUPOPROC.AUX_GPC_DS_DESCRICAO%type,
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_GPC_GRUPOPROC.AUX_EPP_CD_ESPECPROC%type,
     pTIS_MED_CD_TABELAMEDICA IN TB_AUX_GPC_GRUPOPROC.TIS_MED_CD_TABELAMEDICA%type	
) 
is
/********************************************************************
*    Procedure: PRC_AUX_GPC_GRUPOPROC_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_AUX_GPC_GRUPOPROC
(
       AUX_GPC_CD_GRUPOPROC,
       AUX_GPC_DS_DESCRICAO,
       AUX_EPP_CD_ESPECPROC,
       TIS_MED_CD_TABELAMEDICA
)
VALUES
(
	     pAUX_GPC_CD_GRUPOPROC,
	     pAUX_GPC_DS_DESCRICAO,
	     pAUX_EPP_CD_ESPECPROC,
	     pTIS_MED_CD_TABELAMEDICA
);
	
end PRC_AUX_GPC_GRUPOPROC_R_I;

