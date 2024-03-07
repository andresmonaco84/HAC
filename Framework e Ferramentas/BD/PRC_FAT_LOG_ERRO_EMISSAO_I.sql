CREATE OR REPLACE PROCEDURE PRC_FAT_LOG_ERRO_EMISSAO_I (
     pNR_SEQINTER IN FAT_LOG_ERRO_SGS.NR_SEQINTER%type DEFAULT NULL,
     pTP_ROTINA IN FAT_LOG_ERRO_SGS.TP_ROTINA%type DEFAULT NULL,
     pDS_ERRO IN FAT_LOG_ERRO_SGS.DS_ERRO%type DEFAULT NULL,
     pTP_COBRANCA IN FAT_LOG_ERRO_SGS.TP_COBRANCA%type DEFAULT NULL,
     pNR_CONTA IN FAT_LOG_ERRO_SGS.NR_CONTA%type DEFAULT NULL,
     pIDT_PACIENTE IN FAT_LOG_ERRO_SGS.IDT_PACIENTE%type DEFAULT NULL,
     pSEQ_LOG_ERRO IN FAT_LOG_ERRO_SGS.SEQ_LOG_ERRO%type DEFAULT NULL,     
     pIDT_USUARIO IN FAT_LOG_ERRO_SGS.IDT_USUARIO%TYPE DEFAULT NULL
)
is
/********************************************************************
*    Procedure: PRC_FAT_LOG_ERRO_EMISSAO_I
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao: data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
******************************************************************/
begin

INSERT INTO FAT_LOG_ERRO_SGS LER
  (LER.NR_SEQINTER,
   LER.TP_ROTINA,
   LER.DS_ERRO,
   LER.TP_COBRANCA,
   LER.NR_CONTA,
   LER.IDT_PACIENTE,
   LER.SEQ_LOG_ERRO,
   LER.DT_ATUALIZACAO,
   LER.IDT_USUARIO)
VALUES
  (pNR_SEQINTER,
   pTP_ROTINA,
   pDS_ERRO,
   pTP_COBRANCA,
   pNR_CONTA,
   pIDT_PACIENTE,
   pSEQ_LOG_ERRO,
   sysdate,
   pIDT_USUARIO);

end PRC_FAT_LOG_ERRO_EMISSAO_I;
