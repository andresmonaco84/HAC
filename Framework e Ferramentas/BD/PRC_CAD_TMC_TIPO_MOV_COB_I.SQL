create or replace procedure PRC_CAD_TMC_TIPO_MOV_COB_I
(
     --pCAD_TMC_ID IN TB_CAD_TMC_TIPO_MOV_COBRANCA.CAD_TMC_ID%type,
     pCAD_TMC_DS_DESCRICAO IN TB_CAD_TMC_TIPO_MOV_COBRANCA.CAD_TMC_DS_DESCRICAO%type,
     --pCAD_TMC_DT_CRIACAO IN TB_CAD_TMC_TIPO_MOV_COBRANCA.CAD_TMC_DT_CRIACAO%type,
     pSEG_USU_ID_USUARIO_CRIACAO IN TB_CAD_TMC_TIPO_MOV_COBRANCA.SEG_USU_ID_USUARIO_CRIACAO%type,
     --pCAD_TMC_DT_ULTIMA_ATUALIZACAO IN TB_CAD_TMC_TIPO_MOV_COBRANCA.CAD_TMC_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO_ATUALIZ IN TB_CAD_TMC_TIPO_MOV_COBRANCA.SEG_USU_ID_USUARIO_ATUALIZ%type,
     pNewIdt OUT integer
)
is
/********************************************************************
*    Procedure: PRC_CAD_TMC_TIPO_MOV_COB_I
*
*    Data Criacao: 	30/03/2012   Por: André
*
*    Funcao: Insere tipo movimento cobrança
*******************************************************************/
lIdtRetorno integer;
begin
SELECT SEQ_CAD_TMC_01.NextVal INTO lIdtRetorno FROM DUAL;
INSERT INTO TB_CAD_TMC_TIPO_MOV_COBRANCA
(
       CAD_TMC_ID,
       CAD_TMC_DS_DESCRICAO,
       CAD_TMC_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_TMC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ
)
VALUES
(
	     lIdtRetorno,
	     pCAD_TMC_DS_DESCRICAO,
	     SYSDATE,
	     pSEG_USU_ID_USUARIO_CRIACAO,
	     SYSDATE,
	     pSEG_USU_ID_USUARIO_ATUALIZ
);
pNewIdt := lIdtRetorno;
end PRC_CAD_TMC_TIPO_MOV_COB_I;
