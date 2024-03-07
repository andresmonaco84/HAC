--PRC_CAD_BAN_BANCO_U
create or replace procedure PRC_CAD_BAN_BANCO_U
(
     pCAD_BAN_ID IN TB_CAD_BAN_BANCO.CAD_BAN_ID%type,
     pCAD_BAN_CD_BANCO IN TB_CAD_BAN_BANCO.CAD_BAN_CD_BANCO%type,
     pCAD_BAN_NM_BANCO IN TB_CAD_BAN_BANCO.CAD_BAN_NM_BANCO%type,
     pCAD_BAN_CD_BANCO_LEG IN TB_CAD_BAN_BANCO.CAD_BAN_CD_BANCO_LEG%type default NULL,
     pCAD_BAN_DT_CRIACAO IN TB_CAD_BAN_BANCO.CAD_BAN_DT_CRIACAO%type,
     pSEG_USU_ID_USUARIO_CRIACAO IN TB_CAD_BAN_BANCO.SEG_USU_ID_USUARIO_CRIACAO%type,
     pCAD_BAN_DT_ULTIMA_ATUALIZACAO IN TB_CAD_BAN_BANCO.CAD_BAN_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO_ATUALIZ IN TB_CAD_BAN_BANCO.SEG_USU_ID_USUARIO_ATUALIZ%type
) 
is
/********************************************************************
*    Procedure: PRC_CAD_BAN_BANCO_U
* 
*    Data Criacao: 	12/8/2011   Por: Pedro
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_CAD_BAN_BANCO
SET	   
        CAD_BAN_CD_BANCO = pCAD_BAN_CD_BANCO,
        CAD_BAN_NM_BANCO = pCAD_BAN_NM_BANCO,
        CAD_BAN_CD_BANCO_LEG = pCAD_BAN_CD_BANCO_LEG,
        CAD_BAN_DT_CRIACAO = pCAD_BAN_DT_CRIACAO,
        SEG_USU_ID_USUARIO_CRIACAO = pSEG_USU_ID_USUARIO_CRIACAO,
        CAD_BAN_DT_ULTIMA_ATUALIZACAO = pCAD_BAN_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO_ATUALIZ = pSEG_USU_ID_USUARIO_ATUALIZ 
WHERE
        CAD_BAN_ID = pCAD_BAN_ID;	
end PRC_CAD_BAN_BANCO_U;
/
