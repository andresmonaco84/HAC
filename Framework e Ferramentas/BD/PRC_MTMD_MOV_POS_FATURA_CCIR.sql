CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_POS_FATURA_CCIR
(
  pMTMD_MOV_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type,
  pSEQ_PACIENTE                 IN TB_MTMD_MOV_MOVIMENTACAO.SEQ_PACIENTE%type,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
  pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
  pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
  pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
  pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
  pCAD_MTMD_SUBTP_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type,
  pMTMD_MOV_QTDE                IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_QTDE%type,
  pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type default NULL,
  pATD_ATE_TP_PACIENTE          IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_TP_PACIENTE%type default NULL,
  pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
  pMTMD_TP_FRACAO_ID            IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_TP_FRACAO_ID%TYPE  DEFAULT NULL,
  pMTMD_QTD_CONVERTIDA          IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_QTD_CONVERTIDA%type  DEFAULT NULL,     
  pMTMD_MOV_DATA_FATURAMENTO    IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA_FATURAMENTO%type  DEFAULT NULL,     
  pMTMD_MOV_HORA_FATURAMENTO    IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_HORA_FATURAMENTO%type  DEFAULT NULL
) IS
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_POS_FATURA_CCIR
  *
  *    Data Criacao: 29/09/2010     Por: André Souza Monaco
  *    Data Alteracao: 21/03/2011      Por: André Souza Monaco
  *         Descrição: Desativação do interface com o legado
  *
  *    Funcao: Operações realizadas após a realização do processo de
  *            faturamento do SGS p/ o Centro Cirurgico
  *
  *******************************************************************/
TIPO_BAIXA                  CONSTANT NUMBER :=2;
SUB_TIPO_FATURA_CCIRURGICO  CONSTANT NUMBER := 34;
SUB_TIPO_BAIXA_NAO_FATURADA CONSTANT NUMBER :=18;
SUB_TP_BAIXA_FRAC_NAO_FAT   CONSTANT NUMBER := 35;
BAIXA_CONSUMO_PACIENTE      CONSTANT NUMBER := 11;
SUB_TIPO_BAIXA_FRACIONADA   CONSTANT NUMBER := 14;
vCAD_MTMD_SUBTP_ID TB_CAD_MTMD_SUBTP_MOVIMENTACAO.cad_mtmd_subtp_id%TYPE;
vNewIdt            NUMBER;
BEGIN
   /* UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
      SEQ_PACIENTE = pSEQ_PACIENTE
      WHERE MTMD_MOV_ID = pMTMD_MOV_ID;*/
    --QUANDO O LEGADO FOR DESATIVADO, DESCOMENTAR A ROTINA ABAIXO, E TIRAR O UPDATE FEITO ACIMA
    IF ( pCAD_MTMD_SUBTP_ID = SUB_TIPO_BAIXA_NAO_FATURADA ) THEN
       vCAD_MTMD_SUBTP_ID := BAIXA_CONSUMO_PACIENTE;
    ELSIF ( pCAD_MTMD_SUBTP_ID = SUB_TP_BAIXA_FRAC_NAO_FAT ) THEN
       vCAD_MTMD_SUBTP_ID := SUB_TIPO_BAIXA_FRACIONADA;
    END IF;
    BEGIN
      -- GERA MOVIMENTAÇÃO PARA SABER QUEM SALVOU O PRODUTO
      PRC_MTMD_MOV_MOVIMENTACAO_I (pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                   pCAD_UNI_ID_UNIDADE,
                                   pCAD_SET_ID,
                                   NULL, --pMTMD_REQ_ID,
                                   NULL, -- pMTMD_LOTEST_ID,
                                   pCAD_MTMD_ID,
                                   pCAD_MTMD_FILIAL_ID,
                                   TIPO_BAIXA,
                                   SUB_TIPO_FATURA_CCIRURGICO,
                                   SYSDATE,
                                   pMTMD_MOV_QTDE, -- QTDE CONSUMIDA
                                   1, -- pMTMD_MOV_FL_FINALIZADO
                                   pATD_ATE_ID,
                                   pATD_ATE_TP_PACIENTE,
                                   pSEG_USU_ID_USUARIO,
                                   pMTMD_TP_FRACAO_ID,
                                   pMTMD_QTD_CONVERTIDA,
                                   pMTMD_MOV_DATA_FATURAMENTO,
                                   pMTMD_MOV_HORA_FATURAMENTO,
                                   vNewIdt
                                   );
      EXCEPTION WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(sqlcode,'FAT C.CIR '||' MOV ID '||TO_CHAR(pMTMD_MOV_ID)||' ' ||sqlerrm);
      END;
      UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
      MTMD_MOV_ID_REF      = vNewIdt,
      MTMD_MOV_FL_FATURADO = 1,
      CAD_MTMD_SUBTP_ID    = vCAD_MTMD_SUBTP_ID, -- ATUALIZA TIPO DE MOVIMENTO PARA MOVIMENTO DE CONSUMO NORMAL
      -- SEG_USU_ID_USUARIO        = pSEG_USU_ID_USUARIO, -- NAO ATUALIZA O USUARIO PARA SABER QUEM ADICIONOU O PRODUTO
      MTMD_MOV_DATA_FATURAMENTO = pMTMD_MOV_DATA_FATURAMENTO,
      MTMD_MOV_HORA_FATURAMENTO = pMTMD_MOV_HORA_FATURAMENTO,
      SEQ_PACIENTE              = pSEQ_PACIENTE
      WHERE MTMD_MOV_ID = pMTMD_MOV_ID;
      UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
      MTMD_MOV_ID_REF      = vNewIdt
      WHERE MTMD_MOV_ID = pMTMD_MOV_ID;
      UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
      MTMD_MOV_ID_REF      = pMTMD_MOV_ID
      WHERE MTMD_MOV_ID = vNewIdt;
END PRC_MTMD_MOV_POS_FATURA_CCIR;
