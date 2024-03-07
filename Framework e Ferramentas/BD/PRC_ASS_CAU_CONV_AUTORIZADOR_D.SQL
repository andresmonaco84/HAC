create or replace procedure PRC_ASS_CAU_CONV_AUTORIZADOR_D
(
     pASS_CAU_ID IN TB_ASS_CAU_CONV_AUTORIZADOR.ASS_CAU_ID%type
)
is
/********************************************************************
*    Procedure: PRC_ASS_CAU_CONV_AUTORIZADOR_D
*
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
DELETE TB_ASS_CAU_CONV_AUTORIZADOR
WHERE
        ASS_CAU_ID = pASS_CAU_ID;
end PRC_ASS_CAU_CONV_AUTORIZADOR_D;
/
