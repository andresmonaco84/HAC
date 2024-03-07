create or replace procedure PRC_FAT_LOG_ERRO_EMISSAO_S
(
    
     pSEQ_LOG_ERRO IN FAT_LOG_ERRO_SGS.SEQ_LOG_ERRO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_FAT_LOG_ERRO_EMISSAO_S
*
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT distinct
       NR_SEQINTER,
       TP_COBRANCA,
       NR_CONTA,
       IDT_PACIENTE,
       SEQ_LOG_ERRO

FROM FAT_LOG_ERRO_SGS
WHERE
        
        (SEQ_LOG_ERRO = pSEQ_LOG_ERRO)

       ;
io_cursor := v_cursor;
end PRC_FAT_LOG_ERRO_EMISSAO_S;
/
