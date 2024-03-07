

--PRC_COB_TXT_COBRANCA_D
create or replace procedure PRC_COB_TXT_COBRANCA_D 
(
     pASS_BCT_ID IN TB_COB_TXT_COBRANCA.ASS_BCT_ID%type,
     pCAD_PES_ID_PESSOA IN TB_COB_TXT_COBRANCA.CAD_PES_ID_PESSOA%type,
     pCOB_TXT_DT_CRIACAO IN TB_COB_TXT_COBRANCA.COB_TXT_DT_CRIACAO%type,
     pCOB_TXT_DT_PAGTO IN TB_COB_TXT_COBRANCA.COB_TXT_DT_PAGTO%type,
     pCOB_TXT_ID IN TB_COB_TXT_COBRANCA.COB_TXT_ID%type,
     pCOB_TXT_SEQ_GERAL IN TB_COB_TXT_COBRANCA.COB_TXT_SEQ_GERAL%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_TXT_COBRANCA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_TXT_COBRANCA
WHERE  
        ASS_BCT_ID = pASS_BCT_ID
    AND CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA
    AND COB_TXT_DT_CRIACAO = pCOB_TXT_DT_CRIACAO
    AND COB_TXT_DT_PAGTO = pCOB_TXT_DT_PAGTO
    AND COB_TXT_ID = pCOB_TXT_ID
    AND COB_TXT_SEQ_GERAL = pCOB_TXT_SEQ_GERAL;	   
end PRC_COB_TXT_COBRANCA_D;
