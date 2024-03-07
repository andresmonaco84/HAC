

--PRC_FAT_LNF_LOTE_CTA_PARC_NF_I
create or replace procedure PRC_FAT_LNF_LOTE_CTA_PARC_NF_I
(
     pNewIdt OUT integer,
     pFAT_LNF_ID IN TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_ID%type default NULL,
     pFAT_LNF_DT_EMISSAO IN TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_DT_EMISSAO%type,
     pFAT_LNF_HR_EMISSAO IN TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_HR_EMISSAO%type,
     pFAT_LNF_VL_FATURADO IN TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_VL_FATURADO%type,
     pFAT_LNF_DT_ULTIMA_ATUALIZACAO IN TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_LNF_LOTE_CTA_PARC_NF.SEG_USU_ID_USUARIO%type	
) 
is
/********************************************************************
*    Procedure: PRC_FAT_LNF_LOTE_CTA_PARC_NF_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_FAT_LNF_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_FAT_LNF_LOTE_CTA_PARC_NF
(
       FAT_LNF_ID,
       FAT_LNF_DT_EMISSAO,
       FAT_LNF_HR_EMISSAO,
       FAT_LNF_VL_FATURADO,
       FAT_LNF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
)
VALUES
(
      lIdtRetorno,
	     pFAT_LNF_DT_EMISSAO,
	     pFAT_LNF_HR_EMISSAO,
	     pFAT_LNF_VL_FATURADO,
	     pFAT_LNF_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
);
    pNewIdt := lIdtRetorno;	
end PRC_FAT_LNF_LOTE_CTA_PARC_NF_I;

