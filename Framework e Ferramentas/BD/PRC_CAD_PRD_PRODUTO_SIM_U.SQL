CREATE OR REPLACE PROCEDURE PRC_CAD_PRD_PRODUTO_SIM_U (pCAD_PRD_ID                     IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE,
                                                        pCAD_PRD_VL_PRODUTO         IN TB_CAD_PRD_PRODUTO.CAD_PRD_VL_PRODUTO%TYPE,
                                                        pCAD_PRD_VL_CUSTO           IN TB_CAD_PRD_PRODUTO.CAD_PRD_VL_CUSTO%TYPE,
                                                        pCAD_PRD_VL_MATMED_FABRICA  IN TB_CAD_PRD_PRODUTO.CAD_PRD_VL_MATMED_FABRICA%TYPE,
                                                        pCAD_PRD_VL_VENDA           IN TB_CAD_PRD_PRODUTO.CAD_PRD_VL_VENDA%TYPE,
                                                        pCAD_PRD_NM_FABR_MATMED     IN TB_CAD_PRD_PRODUTO.CAD_PRD_NM_FABR_MATMED%TYPE,
                                                        pCAD_PRD_VL_MATMED_VEND_FRA IN TB_CAD_PRD_PRODUTO.CAD_PRD_VL_MATMED_VEND_FRA%TYPE,
                                                        pCAD_PRD_VL_MATMED_FABR_FRA IN TB_CAD_PRD_PRODUTO.CAD_PRD_VL_MATMED_FABR_FRA%TYPE,
                                                        pCAD_PRD_CD_TABELA_MATMED   IN TB_CAD_PRD_PRODUTO.CAD_PRD_CD_TABELA_MATMED%TYPE,
                                                        pTIS_MED_CD_TABELAMEDICA    IN TB_CAD_PRD_PRODUTO.TIS_MED_CD_TABELAMEDICA%TYPE,
                                                        pSEG_USU_ID_USUARIO         IN TB_CAD_PRD_PRODUTO.SEG_USU_ID_USUARIO%TYPE,
                                                        pCAD_CME_CLASSIF_MED        IN TB_CAD_PRD_PRODUTO.CAD_CME_CLASSIF_MED%TYPE DEFAULT NULL,
                                                        pCAD_PRD_FL_USORESTRITOMED  IN TB_CAD_PRD_PRODUTO.CAD_PRD_FL_USORESTRITOMED%TYPE DEFAULT NULL,
                                                        pCAD_PRD_CD_TUSS            IN TB_CAD_PRD_PRODUTO.CAD_PRD_CD_TUSS%TYPE DEFAULT NULL) is
  /*********************************************************************************
  * Procedure: PRC_CAD_PRD_PRODUTO_SIM_U
  * Data Criacao:  25/08/2010   Por: RAMIRO
  * Funcao: ATUALIZAR DADOS DA SIMPRO NA TABELA DE PRODUTOS SGS.PRC_CAD_PRD_PRODUTO
  * Data Alterac?o:  28/10/2010   Por: Rafael Coimbra
  * Funcao: Incluido o parametro pCAD_PRD_VL_CUSTO
  * Data Alterac?o:  23/12/2010   Por: Rafael Coimbra
  * Funcao: Incluido o parametro pCAD_CME_CLASSIF_MED
  * Data Alterac?o:  17/03/2014   Por: Andre S. Monaco
  * Funcao: Incluido o parametro pCAD_PRD_CD_TUSS
  * Data Alterac?o:  07/08/2014   Por: Andrea Cazuca
  * Funcao: Incluido os campos CAD_HIP_CD_ANVISA e CAD_HIP_CD_TUSS
  * Data Alterac?o:  16/12/2015   Por: Andre S. Monaco
  * Funcao: Incluido o campo CAD_PRD_FL_TUSS_RM
  **********************************************************************************/
  v_contador                   number;
  ex_produtoinexistente        exception;
  --v_error_code                 number;
  v_error_message              varchar2(900);
  v_CAD_PRD_CD_CODIGO          varchar2(8);
  v_CAD_PRD_DS_DESCRICAO       varchar2(200);
  v_CAD_PRD_FL_STATUS          char(1);
  v_CAD_PRD_NM_MNEMONICO       varchar2(8);
  v_CAD_TAP_TP_ATRIBUTO        varchar2(3);
  v_CAD_UMC_CD_MEDIDA_CONSUMO  varchar2(4);
  v_CAD_PRD_NM_FANTASIA        varchar2(100);
  v_CAD_PRD_FL_FRACIONADO      char(1);
  v_CAD_APM_ID_MATMED          number(10);
  v_CAD_PRD_QT_APR_MATMED      number(15, 5);
  v_CAD_PRD_FL_ISENTO_COBRANCA char(1);
  v_CAD_PRD_FL_ESTOQUE_ACS     char(1);
  v_CAD_PRD_FL_ALTO_CUSTO      char(1);
  v_CAD_CMM_CD_CARACMATMED     number(3);
  v_CAD_PRD_CD_FABR_MATMED     varchar2(5);
  v_CAD_CME_CLASSIF_MED        number(1);
  v_CAD_PRD_FL_USORESTRITOMED  char(1);
  v_CAD_PRD_CD_AVISA           varchar2(18);
  v_CAD_PRD_CD_TUSS            varchar2(10);
  v_CAD_PRD_FL_TUSS_RM         char(1);
BEGIN
  -- atualiza dados do produto.
  SELECT COUNT(*),   MAX(NVL(CAD_PRD_FL_TUSS_RM,'N')), MAX(CAD_PRD_CD_TUSS)
    INTO v_contador, v_CAD_PRD_FL_TUSS_RM,             v_CAD_PRD_CD_TUSS
    FROM TB_CAD_PRD_PRODUTO PRD
   WHERE PRD.CAD_PRD_ID = pCAD_PRD_ID;
  IF v_contador = 0 THEN
    raise ex_produtoinexistente;
  ELSE
    IF (v_CAD_PRD_FL_TUSS_RM = 'N') THEN
       v_CAD_PRD_CD_TUSS := pCAD_PRD_CD_TUSS;
    ELSIF (v_CAD_PRD_FL_TUSS_RM = 'S' AND pCAD_PRD_CD_TUSS IS NOT NULL) THEN
       v_CAD_PRD_CD_TUSS := pCAD_PRD_CD_TUSS;
       v_CAD_PRD_FL_TUSS_RM := 'N';
    END IF;
    UPDATE TB_CAD_PRD_PRODUTO
       SET CAD_PRD_VL_PRODUTO            = pCAD_PRD_VL_PRODUTO,
           CAD_PRD_VL_CUSTO              = pCAD_PRD_VL_CUSTO,
           CAD_PRD_VL_MATMED_FABRICA     = pCAD_PRD_VL_MATMED_FABRICA,
           CAD_PRD_VL_VENDA              = pCAD_PRD_VL_VENDA,
           CAD_PRD_NM_FABR_MATMED        = pCAD_PRD_NM_FABR_MATMED,
           CAD_PRD_VL_MATMED_VEND_FRA    = pCAD_PRD_VL_MATMED_VEND_FRA,
           CAD_PRD_VL_MATMED_FABR_FRA    = pCAD_PRD_VL_MATMED_FABR_FRA,
           CAD_PRD_CD_TABELA_MATMED      = pCAD_PRD_CD_TABELA_MATMED,
           CAD_DT_INICIO_VIGENCIA        = SYSDATE,
           TIS_MED_CD_TABELAMEDICA       = pTIS_MED_CD_TABELAMEDICA,
           CAD_PRD_DT_ULTIMA_ATUALIZACAO = SYSDATE,
           CAD_CME_CLASSIF_MED           = pCAD_CME_CLASSIF_MED,
           SEG_USU_ID_USUARIO            = pSEG_USU_ID_USUARIO,
           CAD_PRD_FL_USORESTRITOMED     = pCAD_PRD_FL_USORESTRITOMED,
           CAD_PRD_CD_TUSS               = v_CAD_PRD_CD_TUSS,
           CAD_PRD_FL_TUSS_RM            = v_CAD_PRD_FL_TUSS_RM
     WHERE CAD_PRD_ID = pCAD_PRD_ID;
  END IF;
  -- fecha vigencia antiga se existir.
  SELECT COUNT(*)
    INTO v_contador
    FROM TB_CAD_HIP_HISTORICO_PRODUTO HIS
   WHERE HIS.CAD_PRD_ID = pCAD_PRD_ID
     AND HIS.TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA
     AND CAD_HIP_DT_FIM_VIGENCIA IS NULL;
  IF v_contador > 0 THEN
    UPDATE TB_CAD_HIP_HISTORICO_PRODUTO
       SET CAD_HIP_DT_FIM_VIGENCIA       = SYSDATE,
           CAD_HIP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
           SEG_USU_ID_USUARIO            = pSEG_USU_ID_USUARIO
     WHERE CAD_PRD_ID = pCAD_PRD_ID
       AND TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA
       AND CAD_HIP_DT_FIM_VIGENCIA IS NULL;
  END IF;
  -- insere nova vigencia.
  SELECT PRD.CAD_PRD_CD_CODIGO,
         PRD.CAD_PRD_DS_DESCRICAO,
         PRD.CAD_PRD_FL_STATUS,
         PRD.CAD_PRD_NM_MNEMONICO,
         PRD.CAD_TAP_TP_ATRIBUTO,
         PRD.CAD_UMC_CD_MEDIDA_CONSUMO,
         PRD.CAD_PRD_NM_FANTASIA,
         PRD.CAD_PRD_FL_FRACIONADO,
         PRD.CAD_APM_ID_MATMED,
         PRD.CAD_PRD_QT_APR_MATMED,
         PRD.CAD_PRD_FL_ISENTO_COBRANCA,
         PRD.CAD_PRD_FL_ESTOQUE_ACS,
         PRD.CAD_PRD_FL_ALTO_CUSTO,
         PRD.CAD_CMM_CD_CARACMATMED,
         PRD.CAD_PRD_CD_FABR_MATMED,
         PRD.CAD_CME_CLASSIF_MED,
         PRD.CAD_PRD_FL_USORESTRITOMED,
         PRD.CAD_PRD_CD_ANVISA,
         PRD.CAD_PRD_CD_TUSS
    INTO v_CAD_PRD_CD_CODIGO,
         v_CAD_PRD_DS_DESCRICAO,
         v_CAD_PRD_FL_STATUS,
         v_CAD_PRD_NM_MNEMONICO,
         v_CAD_TAP_TP_ATRIBUTO,
         v_CAD_UMC_CD_MEDIDA_CONSUMO,
         v_CAD_PRD_NM_FANTASIA,
         v_CAD_PRD_FL_FRACIONADO,
         v_CAD_APM_ID_MATMED,
         v_CAD_PRD_QT_APR_MATMED,
         v_CAD_PRD_FL_ISENTO_COBRANCA,
         v_CAD_PRD_FL_ESTOQUE_ACS,
         v_CAD_PRD_FL_ALTO_CUSTO,
         v_CAD_CMM_CD_CARACMATMED,
         v_CAD_PRD_CD_FABR_MATMED,
         v_CAD_CME_CLASSIF_MED,
         v_CAD_PRD_FL_USORESTRITOMED,
         v_CAD_PRD_CD_AVISA,
         v_CAD_PRD_CD_TUSS
    FROM TB_CAD_PRD_PRODUTO PRD
   WHERE PRD.CAD_PRD_ID = pCAD_PRD_ID;
  INSERT INTO TB_CAD_HIP_HISTORICO_PRODUTO
    (CAD_PRD_ID,
     CAD_HIP_CD_CODIGO,
     CAD_HIP_DS_DESCRICAO,
     CAD_HIP_FL_STATUS,
     CAD_HIP_NM_MNEMONICO,
     CAD_TAP_TP_ATRIBUTO,
     CAD_HIP_DT_INICIO_VIGENCIA,
     CAD_HIP_VL_PRODUTO,
     CAD_UMC_CD_MEDIDA_CONSUMO,
     TIS_MED_CD_TABELAMEDICA,
     CAD_HIP_NM_FANTASIA,
     CAD_HIP_FL_FRACIONADO,
     CAD_HIP_VL_CUSTO,
     CAD_HIP_VL_VENDA,
     CAD_APM_ID_MATMED,
     CAD_HIP_QT_APR_MATMED,
     CAD_HIP_FL_ISENTO_COBRANCA,
     CAD_HIP_FL_ESTOQUE_ACS,
     CAD_HIP_FL_ALTO_CUSTO,
     CAD_CMM_CD_CARACMATMED,
     CAD_HIP_CD_FABR_MATMED,
     CAD_HIP_NM_FABR_MATMED,
     CAD_HIP_VL_MATMED_VEND_FRA,
     CAD_HIP_VL_MATMED_FABR_FRA,
     CAD_HIP_CD_TABELA_MATMED,
     SEG_USU_ID_USUARIO,
     CAD_HIP_DT_ULTIMA_ATUALIZACAO,
     CAD_CME_CLASSIF_MED,
     CAD_HIP_TP_ATUALIZACAO,
     CAD_HIP_FL_USORESTRITOMED,
     CAD_HIP_CD_ANVISA,
     CAD_HIP_CD_TUSS)
  values
    (pCAD_PRD_ID,
     v_CAD_PRD_CD_CODIGO,
     v_CAD_PRD_DS_DESCRICAO,
     v_CAD_PRD_FL_STATUS,
     v_CAD_PRD_NM_MNEMONICO,
     v_CAD_TAP_TP_ATRIBUTO,
     SYSDATE,
     pCAD_PRD_VL_PRODUTO,
     v_CAD_UMC_CD_MEDIDA_CONSUMO,
     pTIS_MED_CD_TABELAMEDICA,
     v_CAD_PRD_NM_FANTASIA,
     v_CAD_PRD_FL_FRACIONADO,
     pCAD_PRD_VL_CUSTO,
     pCAD_PRD_VL_VENDA,
     v_CAD_APM_ID_MATMED,
     v_CAD_PRD_QT_APR_MATMED,
     v_CAD_PRD_FL_ISENTO_COBRANCA,
     v_CAD_PRD_FL_ESTOQUE_ACS,
     v_CAD_PRD_FL_ALTO_CUSTO,
     v_CAD_CMM_CD_CARACMATMED,
     v_CAD_PRD_CD_FABR_MATMED,
     pCAD_PRD_NM_FABR_MATMED,
     pCAD_PRD_VL_MATMED_VEND_FRA,
     pCAD_PRD_VL_MATMED_FABR_FRA,
     pCAD_PRD_CD_TABELA_MATMED,
     pSEG_USU_ID_USUARIO,
     SYSDATE,
     v_CAD_CME_CLASSIF_MED,
     'P',
     v_CAD_PRD_FL_USORESTRITOMED,
     v_CAD_PRD_CD_AVISA,
     v_CAD_PRD_CD_TUSS);
  -- trata erro se codigo do produto n?o existir.
EXCEPTION
  WHEN ex_produtoinexistente THEN
    raise_application_error('-20000', 'PRODUTO INEXISTENTE');
  WHEN OTHERS THEN
    v_error_message:= SQLERRM;
    BEGIN
      insert into tb_cad_log_erro_processo l
       (l.cad_log_ate_atd,
       l.cad_log_data_processo,
        l.cad_log_prd_id,
        l.cad_log_msg_erro,
        l.cad_log_origem)
      values
        (9,
        sysdate,
        pCAD_PRD_ID,
        v_error_message,
        'PRC_CAD_PRD_PRODUTO_SIM_U');
    EXCEPTION   WHEN OTHERS THEN
        raise_application_error(-20005, v_error_message);
    END;
END PRC_CAD_PRD_PRODUTO_SIM_U;