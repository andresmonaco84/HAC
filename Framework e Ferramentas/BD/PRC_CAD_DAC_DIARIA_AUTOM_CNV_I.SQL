

--PRC_CAD_DAC_DIARIA_AUTOM_CNV_I
create or replace procedure PRC_CAD_DAC_DIARIA_AUTOM_CNV_I
(
     pNewIdt OUT integer,
     pCAD_DAC_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_ID%type default NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_PLA_ID_PLANO%type default NULL,
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.TIS_TAC_CD_TIPO_ACOMODACAO%type,
     pCAD_PRD_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_PRD_ID%type,
     pCAD_SPL_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_SPL_ID%type default NULL,
     pCAD_SET_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_SET_ID%type default NULL,
     pCAD_DAC_DT_INICIO_VIGENCIA IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_DT_INICIO_VIGENCIA%type,
     pCAD_DAC_DT_FIM_VIGENCIA IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.SEG_USU_ID_USUARIO%type,
     pCAD_DAC_DT_ULTIMA_ATUALIZACAO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_DT_ULTIMA_ATUALIZACAO%type,
     pCAD_DAC_FL_CONSIDERAOBITO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_FL_CONSIDERAOBITO%type default NULL,
     pCAD_DAC_HR_OBITO_MAIOR IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_HR_OBITO_MAIOR%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_CAD_DAC_DIARIA_AUTOM_CNV_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_CAD_DAC_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_CAD_DAC_DIARIA_AUTOM_CNV
(
       CAD_DAC_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       TIS_TAC_CD_TIPO_ACOMODACAO,
       CAD_PRD_ID,
       CAD_SPL_ID,
       CAD_SET_ID,
       CAD_DAC_DT_INICIO_VIGENCIA,
       CAD_DAC_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO,
       CAD_DAC_DT_ULTIMA_ATUALIZACAO,
       CAD_DAC_FL_CONSIDERAOBITO,
       CAD_DAC_HR_OBITO_MAIOR
)
VALUES
(
      lIdtRetorno,
	     pCAD_CNV_ID_CONVENIO,
	     pCAD_PLA_ID_PLANO,
	     pTIS_TAC_CD_TIPO_ACOMODACAO,
	     pCAD_PRD_ID,
	     pCAD_SPL_ID,
	     pCAD_SET_ID,
	     pCAD_DAC_DT_INICIO_VIGENCIA,
	     pCAD_DAC_DT_FIM_VIGENCIA,
	     pSEG_USU_ID_USUARIO,
	     pCAD_DAC_DT_ULTIMA_ATUALIZACAO,
	     pCAD_DAC_FL_CONSIDERAOBITO,
	     pCAD_DAC_HR_OBITO_MAIOR
);
    pNewIdt := lIdtRetorno;	
end PRC_CAD_DAC_DIARIA_AUTOM_CNV_I;

