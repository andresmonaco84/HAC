

--PRC_DEMONST_ANALISE_CTA_D
create or replace procedure PRC_DEMONST_ANALISE_CTA_D 
(
     pSEQUENCIALTRANSACAO IN TSS_DEMONSTRATIVO_ANALISE_CTA.SEQUENCIALTRANSACAO%type	
)
is
/********************************************************************
*    Procedure: PRC_DEMONST_ANALISE_CTA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TSS_DEMONSTRATIVO_ANALISE_CTA
WHERE  
        SEQUENCIALTRANSACAO = pSEQUENCIALTRANSACAO;	   
end PRC_DEMONST_ANALISE_CTA_D;
