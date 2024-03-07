

--PRC_AUX_FPG_FORMAPAGTO_U
create or replace procedure PRC_AUX_FPG_FORMAPAGTO_U
(
     pAUX_FPG_CD_FORMAPAGTO IN TB_AUX_FPG_FORMAPAGTO.AUX_FPG_CD_FORMAPAGTO%type,
     pAUX_FPG_DS_FORMAPAGTO IN TB_AUX_FPG_FORMAPAGTO.AUX_FPG_DS_FORMAPAGTO%type
) 
is
/********************************************************************
*    Procedure: PRC_AUX_FPG_FORMAPAGTO_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_AUX_FPG_FORMAPAGTO
SET	   
        AUX_FPG_DS_FORMAPAGTO = pAUX_FPG_DS_FORMAPAGTO 
WHERE
        AUX_FPG_CD_FORMAPAGTO = pAUX_FPG_CD_FORMAPAGTO;	
end PRC_AUX_FPG_FORMAPAGTO_U;

