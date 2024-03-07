--PRC_ASS_RPG_REGRA_PAGTO_U
create or replace procedure PRC_ASS_RPG_REGRA_PAGTO_U
(
     pASS_CPR_ID IN TB_ASS_RPG_REGRA_PAGTO.ASS_CPR_ID%type,
     pCAD_REP_ID IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_ID%type,
     pCAD_REP_DT_INICIO_VIGENCIA IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_DT_INICIO_VIGENCIA%type,
     pCAD_REP_DT_FIM_VIGENCIA IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_RPG_REGRA_PAGTO.SEG_USU_ID_USUARIO%type,
     pCAD_REP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_DT_ULTIMA_ATUALIZACAO%type,
     pASS_RPG_ID IN TB_ASS_RPG_REGRA_PAGTO.ASS_RPG_ID%type
) 
is
/********************************************************************
*    Procedure: PRC_ASS_RPG_REGRA_PAGTO_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_ASS_RPG_REGRA_PAGTO
SET	   
        ASS_CPR_ID = pASS_CPR_ID,
        CAD_REP_ID = pCAD_REP_ID,
        CAD_REP_DT_INICIO_VIGENCIA = pCAD_REP_DT_INICIO_VIGENCIA,
        CAD_REP_DT_FIM_VIGENCIA = pCAD_REP_DT_FIM_VIGENCIA,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_REP_DT_ULTIMA_ATUALIZACAO = pCAD_REP_DT_ULTIMA_ATUALIZACAO 
WHERE
        ASS_RPG_ID = pASS_RPG_ID;	
end PRC_ASS_RPG_REGRA_PAGTO_U;