create or replace procedure PRC_CAD_HQL_HIS_SIT_QTO_LEI_I
(
     pNewIdt OUT integer,
     pCAD_HQL_ID IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_HQL_ID%type,
     pCAD_QLE_ID IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_QLE_ID%type,
     pCAD_SQL_CD_SIT_QUARTO_LEITO IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_SQL_CD_SIT_QUARTO_LEITO%type,
     pCAD_HQL_DT_HR_INICIO IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_HQL_DT_HR_INICIO%type,
     pCAD_HQL_DT_HR_FIM IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_HQL_DT_HR_FIM%type default NULL,
     pSEG_USU_ID_USU_REG_INICIO IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.SEG_USU_ID_USU_REG_INICIO%type,
     pSEG_USU_ID_USU_REG_FIM IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.SEG_USU_ID_USU_REG_FIM%type default NULL,
	 pCAD_HQL_DS_OBSERVACAO IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_HQL_DS_OBSERVACAO%TYPE DEFAULT NULL
)
is
/********************************************************************
*    Procedure: PRC_CAD_HQL_HIS_SIT_QTO_LEI_I
*
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
lIdtRetorno integer;

begin

SELECT SEQ_CAD_CAC_01.NextVal INTO lIdtRetorno FROM DUAL;

INSERT INTO TB_CAD_HQL_HIS_SIT_QTO_LEITO
(
       CAD_HQL_ID,
       CAD_QLE_ID,
       CAD_SQL_CD_SIT_QUARTO_LEITO,
       CAD_HQL_DT_HR_INICIO,
       CAD_HQL_DT_HR_FIM,
       SEG_USU_ID_USU_REG_INICIO,
       SEG_USU_ID_USU_REG_FIM,
	   CAD_HQL_DS_OBSERVACAO
)
VALUES
(
	     lIdtRetorno,
	     pCAD_QLE_ID,
	     pCAD_SQL_CD_SIT_QUARTO_LEITO,
	     pCAD_HQL_DT_HR_INICIO,
	     pCAD_HQL_DT_HR_FIM,
	     pSEG_USU_ID_USU_REG_INICIO,
	     pSEG_USU_ID_USU_REG_FIM,
		 pCAD_HQL_DS_OBSERVACAO
);

pNewIdt := lIdtRetorno;

end PRC_CAD_HQL_HIS_SIT_QTO_LEI_I;