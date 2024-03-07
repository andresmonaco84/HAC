CREATE OR REPLACE PROCEDURE SGS.PRC_MTMD_MOV_BAIXA_CCIRURGICO
   (
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
     pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,     
     pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type default NULL,
     pMTMD_MOV_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type DEFAULT NULL,     
     pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL  
   )   IS
TIPO_ENTRADA                CONSTANT NUMBER :=1;   
TIPO_BAIXA                  CONSTANT NUMBER :=2;   
SUB_TIPO_ENT_PERSONALIZADA  CONSTANT NUMBER :=9;
SUB_TIPO_BAIXA_NAO_FATURADA CONSTANT NUMBER :=18;
SUB_TP_BAIXA_FRAC_NAO_FAT   CONSTANT NUMBER := 35;
SUB_TIPO_FATURA_CCIRURGICO  CONSTANT NUMBER := 34;
SUB_TIPO_BAIXA_FRACIONADA   CONSTANT NUMBER := 14;
BAIXA_CONSUMO_PACIENTE      CONSTANT NUMBER := 11;
SIM                         CONSTANT NUMBER :=1;
NAO                         CONSTANT NUMBER :=0;
vCAD_MTMD_SUBTP_ID          TB_CAD_MTMD_SUBTP_MOVIMENTACAO.cad_mtmd_subtp_id%TYPE;
vMTMD_MOV_ID                TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type;
vCAD_MTMD_ID                TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type;
vMTMD_ESTLOC_QTDE           TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type;
vNewIdt                     NUMBER;
nFilial                     NUMBER;
nCodeErro NUMBER;
  /************************************************************************************
  *    Procedure: PRC_MTMD_MOV_BAIXA_CCIRURGICO
  *
  *    Data Criacao: 05/06/2009        Por: Ricardo Costa
  *    Data Alteracao: 15/01/20110     Por: Ricardo Costa
  *         Alteração: Alteria data de faturamento
  *    Data Alteracao: 22/01/20110     Por: Ricardo Costa
  *         Alteração: Buscar data de alta quando for externo para faturar com data da alta       
  *    Data Alteracao: 04/02/2010     Por: Ricardo Costa
  *         Alteração: NOVA CHAMADA PROCEDURE FATURAMENTO
  *    Data Alteracao: 05/03/2010     Por: Ricardo Costa
  *         Alteração: NAO ATUALIZA USUÁRIO DO MOVIMENTO GERADO INICIALMENTE
                       GERA REGISTRO DE QUEM SALVOU OS ITENS NO C.CIRURGICO 
  *    Data Alteracao: 12/03/2010     Por: Ricardo Costa
  *         Alteração: ADICIONADO O PARAMETRO ID DO MOVIMENTO, PARA QUE EXISTA A
                       POSSIBILIDADE DE EXECUTAR ITEM POR ITEM                         
  *
  *    Funcao: REALIZA FATURAMENTO E ATUALIZAÇÃO DA MOVIMENTAÇÃO DOS PRODUTOS 
  *            JÁ BAIXADOS DO ESTOQUE NO CENTRO CIRURGICO
  *
  *************************************************************************************/
vData DATE   := SYSDATE;
vHora NUMBER := TO_CHAR(SYSDATE, 'HH24MI');
vDtInt DATE;
BEGIN
   -- BUSCA MOVIMENTOS
   FOR MOVIMENTO IN
   (  SELECT MOV.mtmd_mov_id,                    MOV.CAD_MTMD_ID,          
             MOV.MTMD_MOV_QTDE,                  MOV.mtmd_req_id, 
             MOV.atd_ate_tp_paciente,            
             MOV.CAD_MTMD_FILIAL_ID,             MOV.cad_mtmd_subtp_id,
             MOV.atd_ate_id,                     MOV.cad_uni_id_unidade,
             MOV.cad_lat_id_local_atendimento,   MOV.cad_set_id,
             MOV.mtmd_tp_fracao_id,              MOV.mtmd_qtd_convertida,
             MOV.mtmd_mov_data_faturamento,      MOV.mtmd_mov_hora_faturamento
      FROM TB_MTMD_MOV_MOVIMENTACAO MOV
      WHERE ( pMTMD_MOV_ID IS NULL OR MOV.mtmd_mov_id = pMTMD_MOV_ID)
      AND   MOV.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
      AND   MOV.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE
      AND   MOV.cad_set_id                   = pCAD_SET_ID
      -- AND   MOV.cad_mtmd_filial_id           = pCAD_MTMD_FILIAL_ID
      AND   MOV.cad_mtmd_tpmov_id            = TIPO_BAIXA
      AND   MOV.cad_mtmd_subtp_id            IN(SUB_TIPO_BAIXA_NAO_FATURADA, SUB_TP_BAIXA_FRAC_NAO_FAT )
      AND   MOV.atd_ate_id                   = pATD_ATE_ID
      AND   MOV.mtmd_mov_fl_estorno          = NAO
      AND   MOV.mtmd_mov_fl_faturado         = NAO )
   LOOP
      -- raise_application_error(-20000,' usuario '||to_char(pSEG_USU_ID_USUARIO));
      -- nFilial := FNC_MTMD_RETORNA_FILIAL( MOVIMENTO.CAD_MTMD_ID, pCAD_MTMD_FILIAL_ID);
      BEGIN
      PRC_MTMD_FAT_DATA_FATURAMENTO(MOVIMENTO.ATD_ATE_ID, 
                                    MOVIMENTO.cad_uni_id_unidade,
                                    MOVIMENTO.cad_lat_id_local_atendimento,
                                    MOVIMENTO.cad_set_id,
                                    vData, 
                                    vHora  );
      EXCEPTION WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(-20000,sqlerrm);
      END;
      -- vCAD_MTMD_SUBTP_ID
      IF ( MOVIMENTO.cad_mtmd_subtp_id = SUB_TIPO_BAIXA_NAO_FATURADA ) THEN
         vCAD_MTMD_SUBTP_ID := BAIXA_CONSUMO_PACIENTE;
      ELSIF ( MOVIMENTO.cad_mtmd_subtp_id = SUB_TP_BAIXA_FRAC_NAO_FAT ) THEN
         vCAD_MTMD_SUBTP_ID := SUB_TIPO_BAIXA_FRACIONADA;
      END IF;
      BEGIN
         -- AJUSTA MOVIMENTO COMO FATURADO
         UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
         -- MTMD_MOV_ID_REF      = vNewIdt, 
         MTMD_MOV_FL_FATURADO      = SIM,
         CAD_MTMD_SUBTP_ID         = vCAD_MTMD_SUBTP_ID, -- ATUALIZA TIPO DE MOVIMENTO PARA MOVIMENTO DE CONSUMO NORMAL
         -- SEG_USU_ID_USUARIO        = pSEG_USU_ID_USUARIO, -- NAO ATUALIZA O USUARIO PARA SABER QUEM ADICIONOU O PRODUTO
         MTMD_MOV_DATA_FATURAMENTO = vData,  
         MTMD_MOV_HORA_FATURAMENTO = vHora
         WHERE MTMD_MOV_ID = MOVIMENTO.mtmd_mov_id;
      EXCEPTION WHEN OTHERS THEN
        raise_application_error(-20002,' ERRO ATUALIZANDO MOVIMENTO '|| SQLERRM);
      END;      
      /*BEGIN
         -- PRC_MTMD_FAT_MOVIMENTO_I (MOVIMENTO.mtmd_mov_id, vNewIdt);
         PRC_MTMD_MOV_FATURAR_ONLINE( MOVIMENTO.mtmd_mov_id, 0 );
      EXCEPTION WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(sqlcode,'FAT C.CIR '||' MOV '||TO_CHAR(MOVIMENTO.mtmd_mov_id)||' ' ||sqlerrm);
      END;  */                                       
      BEGIN
      -- GERA MOVIMENTAÇÃO PARA SABER QUEM SALVOU O PRODUTO
      PRC_MTMD_MOV_MOVIMENTACAO_I (   MOVIMENTO.cad_lat_id_local_atendimento,
                                      MOVIMENTO.cad_uni_id_unidade,
                                      MOVIMENTO.cad_set_id,
                                      NULL, --pMTMD_REQ_ID,
                                      NULL, -- pMTMD_LOTEST_ID,
                                      MOVIMENTO.CAD_MTMD_ID,
                                      MOVIMENTO.CAD_MTMD_FILIAL_ID,
                                      TIPO_BAIXA,
                                      SUB_TIPO_FATURA_CCIRURGICO,
                                      SYSDATE,
                                      MOVIMENTO.mtmd_mov_qtde, -- QTDE CONSUMIDA
                                      SIM, -- pMTMD_MOV_FL_FINALIZADO
                                      MOVIMENTO.ATD_ATE_ID,
                                      MOVIMENTO.ATD_ATE_TP_PACIENTE,
                                      pSEG_USU_ID_USUARIO,
                                      MOVIMENTO.MTMD_TP_FRACAO_ID,
                                      MOVIMENTO.mtmd_qtd_convertida,
                                      MOVIMENTO.MTMD_MOV_DATA_FATURAMENTO,
                                      MOVIMENTO.MTMD_MOV_HORA_FATURAMENTO,
                                      vNewIdt
                                   );
      EXCEPTION WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(sqlcode,'FAT C.CIR '||' MOV '||TO_CHAR(MOVIMENTO.mtmd_mov_id)||' ' ||sqlerrm);      
      END;
      --- GERE REFERENCIAS
         UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
         MTMD_MOV_ID_REF      = vNewIdt
         WHERE MTMD_MOV_ID = MOVIMENTO.mtmd_mov_id;
         UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
         MTMD_MOV_ID_REF      = MOVIMENTO.mtmd_mov_id
         WHERE MTMD_MOV_ID = vNewIdt;
   END LOOP;
END PRC_MTMD_MOV_BAIXA_CCIRURGICO;
