

--PRC_FAT_FCL_CONTR_EMI_LOTE_D
create or replace procedure PRC_FAT_FCL_CONTR_EMI_LOTE_D 
(
     pFAT_FCL_NR_SEQ_LOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_FCL_CONTR_EMI_LOTE_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_FCL_CONTR_EMI_LOTE
WHERE  
        FAT_FCL_NR_SEQ_LOTE = pFAT_FCL_NR_SEQ_LOTE;	   
end PRC_FAT_FCL_CONTR_EMI_LOTE_D;
