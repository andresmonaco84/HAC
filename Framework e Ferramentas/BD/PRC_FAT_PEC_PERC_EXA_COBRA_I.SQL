

--PRC_FAT_PEC_PERC_EXA_COBRA_I
create or replace procedure PRC_FAT_PEC_PERC_EXA_COBRA_I
(
     pNewIdt OUT integer,
     pAUX_EPP_CD_ESPECPROC IN TB_FAT_PEC_PERC_EXA_COBRA.AUX_EPP_CD_ESPECPROC%type,
     pFAT_PEC_DS_DESCRICAO IN TB_FAT_PEC_PERC_EXA_COBRA.FAT_PEC_DS_DESCRICAO%type,
     pFAT_PEC_PC_COBRADO_EXA IN TB_FAT_PEC_PERC_EXA_COBRA.FAT_PEC_PC_COBRADO_EXA%type,
     pCAD_CNV_ID_CONVENIO IN TB_FAT_PEC_PERC_EXA_COBRA.CAD_CNV_ID_CONVENIO%type default NULL,
     pFAT_PEC_DT_ULTIMA_ATUALIZACAO IN TB_FAT_PEC_PERC_EXA_COBRA.FAT_PEC_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_PEC_PERC_EXA_COBRA.SEG_USU_ID_USUARIO%type,
     pFAT_PEC_CD_CODIGO IN TB_FAT_PEC_PERC_EXA_COBRA.FAT_PEC_CD_CODIGO%type,
     pFAT_PEC_ID IN TB_FAT_PEC_PERC_EXA_COBRA.FAT_PEC_ID%type default NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_FAT_PEC_PERC_EXA_COBRA.TIS_MED_CD_TABELAMEDICA%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_FAT_PEC_PERC_EXA_COBRA_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_FAT_PEC_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_FAT_PEC_PERC_EXA_COBRA
(
       AUX_EPP_CD_ESPECPROC,
       FAT_PEC_DS_DESCRICAO,
       FAT_PEC_PC_COBRADO_EXA,
       CAD_CNV_ID_CONVENIO,
       FAT_PEC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       FAT_PEC_CD_CODIGO,
       FAT_PEC_ID,
       TIS_MED_CD_TABELAMEDICA
)
VALUES
(
	     pAUX_EPP_CD_ESPECPROC,
	     pFAT_PEC_DS_DESCRICAO,
	     pFAT_PEC_PC_COBRADO_EXA,
	     pCAD_CNV_ID_CONVENIO,
	     pFAT_PEC_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pFAT_PEC_CD_CODIGO,
	     lIdtRetorno,
	     pTIS_MED_CD_TABELAMEDICA
);
    pNewIdt := lIdtRetorno;	
end PRC_FAT_PEC_PERC_EXA_COBRA_I;

