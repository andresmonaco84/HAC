

--PRC_CAD_FER_FERIADO_RMT_U
create or replace procedure PRC_CAD_FER_FERIADO_RMT_U
(
     pCAD_FER_ID_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_ID_FERIADO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_FER_FERIADO.CAD_UNI_ID_UNIDADE%type default NULL,
     pCAD_FER_DT_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_DT_FERIADO%type,
     pCAD_FER_TP_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_TP_FERIADO%type,
     pCAD_FER_DS_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_DS_FERIADO%type,
     pCAD_FER_DT_ULTIMA_ATUALIZACAO IN TB_CAD_FER_FERIADO.CAD_FER_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_FER_FERIADO.SEG_USU_ID_USUARIO%type
) 
is
/********************************************************************
*    Procedure: PRC_CAD_FER_FERIADO_RMT_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_CAD_FER_FERIADO
SET	   
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        CAD_FER_DT_FERIADO = pCAD_FER_DT_FERIADO,
        CAD_FER_TP_FERIADO = pCAD_FER_TP_FERIADO,
        CAD_FER_DS_FERIADO = pCAD_FER_DS_FERIADO,
        CAD_FER_DT_ULTIMA_ATUALIZACAO = pCAD_FER_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
WHERE
        CAD_FER_ID_FERIADO = pCAD_FER_ID_FERIADO;	
end PRC_CAD_FER_FERIADO_RMT_U;

