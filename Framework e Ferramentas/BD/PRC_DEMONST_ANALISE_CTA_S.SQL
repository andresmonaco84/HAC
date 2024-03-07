

--PRC__DEMONSTRATIVO_ANALISE_CTA_S
create or replace procedure PRC__DEMONSTRATIVO_ANALISE_CTA_S 
(
     pSEQUENCIALTRANSACAO IN TSS_DEMONSTRATIVO_ANALISE_CTA.SEQUENCIALTRANSACAO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC__DEMONSTRATIVO_ANALISE_CTA_S
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
       CD_REGISTRO_ANS,
       NR_DEMONSTRATIVO,
       NM_OPERADORA,
       CD_OPER_CNPJ,
       DT_EMISSAO,
       CD_CONTRATADO_OPERADORA,
       NM_PRESTADOR_CONTRATADO,
       CD_CNES,
       NR_LOTE,
       NR_PROTOCOLO,
       DT_PROTOCOLO,
       CD_GLOSA_PROTOCOLO,
       CD_STATUS_PROTOCOLO,
       NR_GUIA_PRESTADOR,
       NR_GUIA_OPERADORA,
       CD_SENHA,
       NM_BENEFICIARIO,
       NR_CARTEIRA_BENEFICIARIO,
       DT_INICIO_FATURAMENTO,
       HR_INICIO_FATURAMENTO,
       DT_FIM_FATURAMENTO,
       HR_FIM_FATURAMENTO,
       CD_GLOSA_GUIA,
       CD_STATUS_GUIA,
       DT_REALIZACAO,
       CD_TABELA,
       CD_PROCEDIMENTO,
       DS_PROCEDIMENTO,
       GRAU_PARTICIPACAO,
       VL_PROCEDIMENTO,
       QTD_PROCEDIMENTO,
       VL_PROCED_PROCESSADO,
       VL_PROCED_LIBERADO,
       VL_PROCED_GLOSA,
       CD_GLOSA_PROCEDIMENTO,
       VL_INFORMADO_GUIA,
       VL_PROCESSADO_GUIA,
       VL_LIBERADO_GUIA,
       VL_GLOSA_GUIA,
       VL_INFORMADO_PROTOCOLO,
       VL_PROCESSADO_PROTOCOLO,
       VL_LIBERADO_PROTOCOLO,
       VL_GLOSA_PROTOCOLO,
       VL_INFORMADO_GERAL,
       VL_PROCESSADO_GERAL,
       VL_LIBERADO_GERAL,
       VL_GLOSA_GERAL,
       SEQUENCIALTRANSACAO,
       DATAREGISTROTRANSACAO,
       HORAREGISTROTRANSACAO,
       NUMERO_LINHA
FROM TSS_DEMONSTRATIVO_ANALISE_CTA
WHERE
        SEQUENCIALTRANSACAO = pSEQUENCIALTRANSACAO;          
io_cursor := v_cursor;
end PRC__DEMONSTRATIVO_ANALISE_CTA_S;
