--PRC_FAT_FCL_CONTR_EMI_LOTE_I
create or replace procedure PRC_FAT_FCL_CONTR_EMI_LOTE_I
(
     pFAT_FCL_NR_SEQ_LOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%type,
     pFAT_COC_ID IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_COC_ID%type,
     pFAT_CCP_ID IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_CCP_ID%type,
     pFAT_FCL_DT_ULTIMA_ATUALIZACAO IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_FCL_CONTR_EMI_LOTE.SEG_USU_ID_USUARIO%type,
     pATD_ATE_ID IN TB_FAT_FCL_CONTR_EMI_LOTE.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_FAT_FCL_CONTR_EMI_LOTE.CAD_PAC_ID_PACIENTE%type,
     pFAT_FCL_NR_SEQ_IMPRIME IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_IMPRIME%TYPE DEFAULT NULL
     
) 
is
/********************************************************************
*    Procedure: PRC_FAT_FCL_CONTR_EMI_LOTE_I
*
*    Data Criacao: 	data da  criação   Por: Pedro
*    Data Alteracao:	20/9/2010  Por: Pedro
*    Alteracao: FAT_FCL_NR_SEQ_IMPRIME
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_FAT_FCL_CONTR_EMI_LOTE
(
       FAT_FCL_NR_SEQ_LOTE,
       FAT_COC_ID,
       FAT_CCP_ID,
       FAT_FCL_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_ATE_ID,
       CAD_PAC_ID_PACIENTE,
       FAT_FCL_NR_SEQ_IMPRIME
)
VALUES
(
	     pFAT_FCL_NR_SEQ_LOTE,
	     pFAT_COC_ID,
	     pFAT_CCP_ID,
	     pFAT_FCL_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pATD_ATE_ID,
	     pCAD_PAC_ID_PACIENTE,
       pFAT_FCL_NR_SEQ_IMPRIME
);
	
end PRC_FAT_FCL_CONTR_EMI_LOTE_I;
/
