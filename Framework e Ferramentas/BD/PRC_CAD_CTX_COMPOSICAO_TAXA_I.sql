  --PRC_CAD_CTX_COMPOSICAO_TAXA_I
  create or replace procedure PRC_CAD_CTX_COMPOSICAO_TAXA_I
  (
     pNewIdt OUT integer,
     pCAD_CTX_ID IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_CTX_ID%type,
     pCAD_PRD_ID_TX IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_PRD_ID_TX%type,
     pCAD_PRD_ID IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_PRD_ID%type,
     pCAD_CTX_DT_ULTIMA_ATUALIZACAO IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_CTX_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_CTX_COMPOSICAO_TAXA.SEG_USU_ID_USUARIO%type,
     pCAD_CTX_FL_STATUS IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_CTX_FL_STATUS%type	
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CTX_COMPOSICAO_TAXA_I
* 
*    Data Criacao: 	data da  criaÃ§Ã£o   Por: Nome do Analista
*    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
*
*    Funcao: DescriÃ§Ã£o da funcionalidade da Stored Procedure
*
*******************************************************************/  
	   lIdtRetorno integer;
begin
    SELECT SEQ_CAD_CTX_01.NextVal INTO lIdtRetorno FROM DUAL;
    
	    
INSERT INTO TB_CAD_CTX_COMPOSICAO_TAXA
(
       CAD_CTX_ID,
       CAD_PRD_ID_TX,
       CAD_PRD_ID,
       CAD_CTX_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_CTX_FL_STATUS
)
VALUES
(
       lIdtRetorno,
       pCAD_PRD_ID_TX,
	     pCAD_PRD_ID,
	     pCAD_CTX_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pCAD_CTX_FL_STATUS
);
     pNewIdt := lIdtRetorno;
  
  end PRC_CAD_CTX_COMPOSICAO_TAXA_I;
