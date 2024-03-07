  --PRC_CAD_CTX_COMPOSICAO_TAXA_U
  create or replace procedure PRC_CAD_CTX_COMPOSICAO_TAXA_U
  (
    pCAD_CTX_ID IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_CTX_ID%type,
     pCAD_PRD_ID_TX IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_PRD_ID_TX%type,
     pCAD_PRD_ID IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_PRD_ID%type,
     pCAD_CTX_DT_ULTIMA_ATUALIZACAO IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_CTX_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_CTX_COMPOSICAO_TAXA.SEG_USU_ID_USUARIO%type,
     pCAD_CTX_FL_STATUS IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_CTX_FL_STATUS%type
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CTX_COMPOSICAO_TAXA_U
* 
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_CAD_CTX_COMPOSICAO_TAXA
SET     
        CAD_PRD_ID_TX = pCAD_PRD_ID_TX,
        CAD_PRD_ID = pCAD_PRD_ID,
        CAD_CTX_DT_ULTIMA_ATUALIZACAO = pCAD_CTX_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_CTX_FL_STATUS = pCAD_CTX_FL_STATUS 
WHERE
        CAD_CTX_ID = pCAD_CTX_ID;	
  end PRC_CAD_CTX_COMPOSICAO_TAXA_U;

