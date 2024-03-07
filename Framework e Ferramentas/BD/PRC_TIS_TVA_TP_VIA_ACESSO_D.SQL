

--PRC_TIS_TVA_TP_VIA_ACESSO_D
create or replace procedure PRC_TIS_TVA_TP_VIA_ACESSO_D 
(
     pTIS_TVA_CD_VIAACESSO IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_CD_VIAACESSO%type	
)
is
/********************************************************************
*    Procedure: PRC_TIS_TVA_TP_VIA_ACESSO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_TIS_TVA_TP_VIA_ACESSO
WHERE  
        TIS_TVA_CD_VIAACESSO = pTIS_TVA_CD_VIAACESSO;	   
end PRC_TIS_TVA_TP_VIA_ACESSO_D;
