create or replace procedure PRC_FAT_LOG_ERRO_EMISSAO_L
(
     pNR_SEQINTER IN FAT_LOG_ERRO_SGS.NR_SEQINTER%type DEFAULT NULL,
     pTP_ROTINA IN FAT_LOG_ERRO_SGS.TP_ROTINA%type DEFAULT NULL,
     pDS_ERRO IN FAT_LOG_ERRO_SGS.DS_ERRO%type DEFAULT NULL,
     pTP_COBRANCA IN FAT_LOG_ERRO_SGS.TP_COBRANCA%type DEFAULT NULL,
     pNR_CONTA IN FAT_LOG_ERRO_SGS.NR_CONTA%type DEFAULT NULL,
     pIDT_PACIENTE IN FAT_LOG_ERRO_SGS.IDT_PACIENTE%type DEFAULT NULL,
     pSEQ_LOG_ERRO IN FAT_LOG_ERRO_SGS.SEQ_LOG_ERRO%type DEFAULT NULL,
     pDT_ATUALIZACAO IN FAT_LOG_ERRO_SGS.DT_ATUALIZACAO%TYPE DEFAULT NULL,
     pIDT_USUARIO IN FAT_LOG_ERRO_SGS.IDT_USUARIO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_FAT_LOG_ERRO_EMISSAO_L
*
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       NR_SEQINTER,
       TP_ROTINA,
       DS_ERRO,
       TP_COBRANCA,
       NR_CONTA,
       IDT_PACIENTE,
       SEQ_LOG_ERRO,
       DT_ATUALIZACAO,
       IDT_USUARIO
FROM FAT_LOG_ERRO_SGS
WHERE
        (pNR_SEQINTER is null OR NR_SEQINTER = pNR_SEQINTER) AND
        (pTP_ROTINA is null OR TP_ROTINA = pTP_ROTINA) AND
        (pDS_ERRO is null OR DS_ERRO = pDS_ERRO) AND
        (pTP_COBRANCA is null OR TP_COBRANCA = pTP_COBRANCA) AND
        (pNR_CONTA is null OR NR_CONTA = pNR_CONTA) AND
        (pIDT_PACIENTE is null OR IDT_PACIENTE = pIDT_PACIENTE) AND
        (pSEQ_LOG_ERRO is null OR SEQ_LOG_ERRO = pSEQ_LOG_ERRO)  AND
        (pDT_ATUALIZACAO IS NULL OR DT_ATUALIZACAO = pDT_ATUALIZACAO) and
        (pIDT_USUARIO IS NULL OR IDT_USUARIO = pIDT_USUARIO) 
       ;
io_cursor := v_cursor;
end PRC_FAT_LOG_ERRO_EMISSAO_L;
/
