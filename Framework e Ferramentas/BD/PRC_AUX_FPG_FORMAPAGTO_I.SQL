

--PRC_AUX_FPG_FORMAPAGTO_I
create or replace procedure PRC_AUX_FPG_FORMAPAGTO_I
(
     pAUX_FPG_CD_FORMAPAGTO IN TB_AUX_FPG_FORMAPAGTO.AUX_FPG_CD_FORMAPAGTO%type,
     pAUX_FPG_DS_FORMAPAGTO IN TB_AUX_FPG_FORMAPAGTO.AUX_FPG_DS_FORMAPAGTO%type	
) 
is
/********************************************************************
*    Procedure: PRC_AUX_FPG_FORMAPAGTO_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_AUX_FPG_FORMAPAGTO
(
       AUX_FPG_CD_FORMAPAGTO,
       AUX_FPG_DS_FORMAPAGTO
)
VALUES
(
	     pAUX_FPG_CD_FORMAPAGTO,
	     pAUX_FPG_DS_FORMAPAGTO
);
	
end PRC_AUX_FPG_FORMAPAGTO_I;

