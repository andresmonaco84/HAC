
--PRC_SEG_MOD_MODULO_R_D
create or replace procedure PRC_SEG_MOD_MODULO_R_D 
(
     pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type	
)
is
/********************************************************************
*    Procedure: PRC_SEG_MOD_MODULO_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_SEG_MOD_MODULO
WHERE  
        SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO;	   
end PRC_SEG_MOD_MODULO_R_D;
