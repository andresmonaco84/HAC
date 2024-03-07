
--PRC_SEG_MPF_MODULO_PERFIL_R_D
create or replace procedure PRC_SEG_MPF_MODULO_PERFIL_R_D 
(
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type,
     pSEG_PER_ID_PERFIL IN TB_SEG_MPF_MODULO_PERFIL.SEG_PER_ID_PERFIL%type	
)
is
/********************************************************************
*    Procedure: PRC_SEG_MPF_MODULO_PERFIL_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_SEG_MPF_MODULO_PERFIL
WHERE  
        SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO
    AND SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;	   
end PRC_SEG_MPF_MODULO_PERFIL_R_D;
