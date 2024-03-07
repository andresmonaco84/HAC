

--PRC_AUX_FPG_FORMAPAGTO_D
create or replace procedure PRC_AUX_FPG_FORMAPAGTO_D 
(
     pAUX_FPG_CD_FORMAPAGTO IN TB_AUX_FPG_FORMAPAGTO.AUX_FPG_CD_FORMAPAGTO%type	
)
is
/********************************************************************
*    Procedure: PRC_AUX_FPG_FORMAPAGTO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_AUX_FPG_FORMAPAGTO
WHERE  
        AUX_FPG_CD_FORMAPAGTO = pAUX_FPG_CD_FORMAPAGTO;	   
end PRC_AUX_FPG_FORMAPAGTO_D;
