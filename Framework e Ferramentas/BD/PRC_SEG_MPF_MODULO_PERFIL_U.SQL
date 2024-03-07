

--PRC_SEG_MPF_MODULO_PERFIL_U
create or replace procedure PRC_SEG_MPF_MODULO_PERFIL_U
(
     pSEG_PER_ID_PERFIL IN TB_SEG_MPF_MODULO_PERFIL.SEG_PER_ID_PERFIL%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type
) 
is
/********************************************************************
*    Procedure: PRC_SEG_MPF_MODULO_PERFIL_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_SEG_MPF_MODULO_PERFIL
SET	   
 
WHERE
        SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO
    AND SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;	
end PRC_SEG_MPF_MODULO_PERFIL_U;

