CREATE OR REPLACE PROCEDURE "PRC_MTMD_MOV_MOVIMENTACAO_R"
   ( 
     pCAD_MTMD_ID                  IN  TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,   
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN  TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE           IN  TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
     pCAD_SET_ID                   IN  TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,  
     pCAD_MTMD_FILIAL_ID           IN  TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_FILIAL_ID%type,     
     pMTMD_MOV_DATA                IN  DATE,   
     pATD_ATE_ID                   IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
     pATD_ATE_TP_PACIENTE          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,     
     io_cursor                     OUT PKG_CURSOR.t_cursor
   ) IS
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_MOVIMENTACAO_R
  *
  *    Data Criacao: 	11/2009   Por: RICARDO COSTA
  *    Data Alteracao:	18/01/2010    Por: RICARDO COSTA
  *         Alterac?o: ADICIONAR NA DESCRIC?O DA MOVIMENTAC?O NOME DO SETOR DA REQUISIC?O, QUANDO FOR CENTRO DE DIPENSAC?O
  *    Data Alteracao:	02/03/2010    Por: RICARDO COSTA
  *         Alterac?o: ADICIONADA CHAMADA DA FUNC?O RETORNAFILIAL DENTRO DA CLAUSULA WHERE PARA TRAZER PRODUTOS CONFORME
                       TIPO DE EMPRESA DO PACIENTE, SE FOR PESQUISA POR PACIENTE
  *
  *    Funcao: GERAR RELATORIO DE MOVIMENTAC?O
  *
  *******************************************************************/
     v_cursor PKG_CURSOR.t_cursor;
     vMovData DATE;    
     nCentroDispensacao NUMBER;     
FUNCTION FNC_MTMD_VERIFICA_CNT_DISPENS
(     
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN  TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE           IN  TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
     pCAD_SET_ID                   IN  TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type
)
RETURN NUMBER IS
nCentroDisp NUMBER;
BEGIN
   nCentroDisp := 0;
   BEGIN
      SELECT 1
      INTO   nCentroDisp
      FROM TB_CAD_SET_SETOR SETOR
      WHERE SETOR.CAD_SET_SETOR_ALMOX   = pCAD_SET_ID
      AND   SETOR.CAD_SET_LOCAL_ALMOX   = pCAD_LAT_ID_LOCAL_ATENDIMENTO
      AND   SETOR.CAD_SET_UNIDADE_ALMOX = pCAD_UNI_ID_UNIDADE;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      -- N?O ACHOU VERIFICA SE E ALMOX CENTRAL
      nCentroDisp := 0;
      BEGIN
         SELECT 1
         INTO   nCentroDisp
         FROM TB_CAD_SET_SETOR SETOR
         WHERE SETOR.CAD_SET_ID                    = pCAD_SET_ID
         AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO  = pCAD_LAT_ID_LOCAL_ATENDIMENTO
         AND   SETOR.CAD_UNI_ID_UNIDADE            = pCAD_UNI_ID_UNIDADE
         AND   SETOR.CAD_SET_ALMOX_CENTRAL         = 1;
      EXCEPTION WHEN NO_DATA_FOUND THEN
        nCentroDisp := 0; 
      END;      
   WHEN TOO_MANY_ROWS THEN
      nCentroDisp := 1;
   END;
   RETURN nCentroDisp;
END FNC_MTMD_VERIFICA_CNT_DISPENS;
--================================================================================================
--  INICIO PROCEDURE
BEGIN
   IF ( pMTMD_MOV_DATA IS NULL ) THEN
--     vMovData := TO_DATE('04082009','DDMMYYYY');
     vMovData := TO_DATE('01012010','DDMMYYYY');
   ELSE
     vMovData := pMTMD_MOV_DATA;   
   END IF;
--   raise_application_error(-20000,' data '||to_char(vMovData));
   -- VERIFICA SE E CENTRO DE DISPENSAC?O
   nCentroDispensacao := FNC_MTMD_VERIFICA_CNT_DISPENS( pCAD_LAT_ID_LOCAL_ATENDIMENTO, pCAD_UNI_ID_UNIDADE, pCAD_SET_ID );
   OPEN v_cursor FOR
   SELECT MOV.MTMD_MOV_DATA,
          MOV.MTMD_REQ_ID,
          CASE  -- SELEC?O ENTRADA/SAIDA
             WHEN MOV.CAD_MTMD_TPMOV_ID  = 1 THEN SUBTP.CAD_MTMD_SUBTP_DESCRICAO -- ENTRADA
             WHEN MOV.CAD_MTMD_TPMOV_ID  = 2 THEN -- SAIDA
                CASE
                   -- MOSTRA DE QUAL ESTOQUE FOI CONSUMO O PRODUTO
                   WHEN MOV.cad_mtmd_subtp_id = 19  THEN    SUBTP.CAD_MTMD_SUBTP_DESCRICAO||' - '||  (SELECT CAD_SET_DS_SETOR
                                                                                                      FROM SGS.TB_CAD_SET_SETOR SETOR,
                                                                                                           SGS.TB_MTMD_MOV_MOVIMENTACAO MOVM
                                                                                                      WHERE MOVM.MTMD_MOV_ID                   = MOV.MTMD_MOV_ID_REF
                                                                                                      AND   SETOR.CAD_SET_ID                   = MOVM.CAD_SET_ID
                                                                                                      AND   SETOR.CAD_UNI_ID_UNIDADE           = MOVM.CAD_UNI_ID_UNIDADE
                                                                                                      AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOVM.CAD_LAT_ID_LOCAL_ATENDIMENTO)
                   WHEN nCentroDispensacao = 1 AND MOV.mtmd_req_id IS NULL AND MOV.cad_mtmd_subtp_id != 19 THEN 
                        '* '||SUBTP.CAD_MTMD_SUBTP_DESCRICAO -- SE FOR CENTRO DE DISPENSAC?O
                   WHEN nCentroDispensacao = 1 AND MOV.mtmd_req_id IS NOT NULL  AND MOV.cad_mtmd_subtp_id != 19 THEN 
                        SUBTP.CAD_MTMD_SUBTP_DESCRICAO||' '||(SELECT SETOR.cad_set_ds_setor
                                                              FROM TB_MTMD_REQ_REQUISICAO REQ,
                                                                   TB_CAD_SET_SETOR       SETOR
                                                              WHERE REQ.mtmd_req_id = MOV.MTMD_REQ_ID
                                                              AND   SETOR.cad_set_id = REQ.cad_set_id )
                   ELSE  SUBTP.CAD_MTMD_SUBTP_DESCRICAO        -- NAO E CENTRO DE DISPENSAC?O
                END -- END CASE SAIDA
          END CAD_MTMD_SUBTP_DESCRICAO, -- END CASE SELEC?O ENTRADA/SAIDA
          DECODE( MOV.CAD_MTMD_TPMOV_ID,1, MOV.MTMD_MOV_QTDE, NULL) QTDE_ENTRADA,
          DECODE( MOV.CAD_MTMD_TPMOV_ID,2, MOV.MTMD_MOV_QTDE, NULL) QTDE_SAIDA,
          NULL                           QTDE_ENTRADA_OUTROS,          
          NULL                           QTDE_SAIDA_OUTROS,
          NULL                           QTDE_ACERTO,
          MOV.ATD_ATE_ID,
          MOV.MTMD_MOV_ESTOQUE_ATUAL,
          MOV.CAD_SET_ID,
          MTMD.CAD_MTMD_NOMEFANTASIA,
          MOV.MTMD_MOV_ID,
          MOV.CAD_MTMD_SUBTP_ID,
          MOV.CAD_MTMD_TPMOV_ID,
          MOV.MTMD_MOV_DATA_FATURAMENTO,
          MOV.MTMD_MOV_HORA_FATURAMENTO,
          USU_MOVIMENTO.SEG_USU_DS_NOME DS_USUARIO,
          LOCATE.CAD_LAT_DS_LOCAL_ATENDIMENTO,
          SETOR.CAD_SET_DS_SETOR,
          UNIDADE.CAD_UNI_DS_UNIDADE,
          MOV.MTMD_MOV_FL_ESTORNO,
          MTMD.CAD_MTMD_FL_MAV
   FROM TB_MTMD_MOV_MOVIMENTACAO       MOV,
        TB_CAD_MTMD_MAT_MED            MTMD,
        TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBTP,
        TB_CAD_MTMD_TIPO_MOVIMENTACAO  TP,
        TB_SEG_USU_USUARIO             USU_MOVIMENTO,
        TB_CAD_LAT_LOCAL_ATENDIMENTO   LOCATE,
        TB_CAD_SET_SETOR               SETOR,
        TB_CAD_UNI_UNIDADE             UNIDADE
   WHERE ( pCAD_MTMD_ID                  IS NULL OR MOV.CAD_MTMD_ID                  = pCAD_MTMD_ID )
   AND   ( pCAD_SET_ID                   IS NULL OR MOV.CAD_SET_ID                   = pCAD_SET_ID )
   AND   ( pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO )
   AND   ( pCAD_UNI_ID_UNIDADE           IS NULL OR MOV.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE )
   AND   ( pCAD_MTMD_FILIAL_ID           IS NULL OR MOV.CAD_MTMD_FILIAL_ID           = FNC_MTMD_RETORNA_FILIAL( MTMD.CAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, NULL))
   AND   ( pATD_ATE_ID                   IS NULL OR MOV.ATD_ATE_ID                   = pATD_ATE_ID )
   AND   ( pATD_ATE_TP_PACIENTE          IS NULL OR MOV.ATD_ATE_TP_PACIENTE          = pATD_ATE_TP_PACIENTE )
   -- CENTRO DE DISPENSAC?O ENTRADA
 --  AND ( nCentroDispensacao = 0 OR  (MOV.CAD_MTMD_TPMOV_ID  = 1 AND MOV.cad_mtmd_subtp_id IN (1,2,7,29,31 )) )   -- 31 ACERTO ENTRADA
   AND SUBTP.CAD_MTMD_SUBTP_ID               = MOV.CAD_MTMD_SUBTP_ID
   AND SUBTP.cad_mtmd_tpmov_id               = MOV.cad_mtmd_tpmov_id
   AND TP.CAD_MTMD_TPMOV_ID                  = MOV.CAD_MTMD_TPMOV_ID
   AND MTMD.cad_mtmd_id                      = MOV.cad_mtmd_id
   AND USU_MOVIMENTO.seg_usu_id_usuario(+)   = MOV.seg_usu_id_usuario
   AND SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID
--   AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
--   AND SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE
   AND LOCATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
   AND UNIDADE.CAD_UNI_ID_UNIDADE          = MOV.CAD_UNI_ID_UNIDADE 
   AND MOV.MTMD_MOV_DATA                  >= vMovData
   ORDER BY MOV.MTMD_MOV_DATA;
   io_cursor := v_cursor;
END PRC_MTMD_MOV_MOVIMENTACAO_R;
 