CREATE OR REPLACE PROCEDURE PRC_CAD_ATENDIMENTO_SID (
pATD_ATE_ID                   IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
pATD_ATE_TP_PACIENTE          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
pCAD_SET_ID                   IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
io_cursor                     OUT PKG_CURSOR.t_cursor
)  IS
  /********************************************************************
  *    Procedure: PRC_CAD_ATENDIMENTO_SID
  *
  *    Data Criacao:    14/04/2010      Por: RICARDO COSTA
  *    Data Alteracao:  29/04/2010      Por: RICARDO COSTA
  *         Alteracao:  Ordenac?o data transferencia
  *    Data Alteracao:  25/08/2010      Por: RICARDO COSTA
  *         Alteracao:  ATUALIZADO MIGRA2
  *    Data Alteracao:  14/10/2010      Por: Andre S. Monaco
  *         Alteracao:  Adic?o da regra de quando obito,
  *                     deixar mostrar atendimento por mais um periodo
  *    Data Alteracao:  27/04/2011      Por: Andre S. Monaco
  *         Alteracao:  Adic?o do param. pCAD_UNI_ID_UNIDADE na query do ambulatorio
  *    Data Alteracao:  05/05/2011      Por: Andre S. Monaco
  *         Alteracao:  Adic?o da regra - Quando AMB SANTOS, liberar tambem PS SANTOS (para Externos)
  *    Data Alteracao:  12/05/2011      Por: Andre S. Monaco
  *         Alteracao:  Adic?o da chamada da func?o FNC_INT_PAC_BAIXA_HR_PERMITIR na query
  *    Data Alteracao:  07/06/2011      Por: Andre S. Monaco
  *         Alteracao:  Limitei o consumo dos externos em 24 horas
  *    Data Alteracao:  12/09/2011      Por: Andre S. Monaco
  *         Alteracao:  N?o trazer setor admiss?o na query
  *    Data Alteracao:  09/10/2012      Por: Andre S. Monaco
  *         Alteracao:  Desativado verificac?o e busca no legado
  *    Data Alteracao:  27/03/2013      Por: Andre S. Monaco
  *         Alteracao:  Adic?o de filtro de atendimentos ativos
  *    Data Alteracao:  24/01/2014      Por: Andre S. Monaco
  *         Alteracao:  Liberar atendimentos cadastrados na tabela TB_CAD_MTMD_ATD_ABERTURA
  *    Data Alteracao:  24/11/2014      Por: Andre S. Monaco
  *         Alteracao:  Abertura de atendimento para externos
  *                     e n?o trazer Atd. Domiciliar p/ outros setores
  *    Data Alteracao:  11/06/2015      Por: Andre S. Monaco
  *         Alteracao:  Nao trazer Setor Admissao p/ Externos
  *    Data Alteracao:  16/02/2017      Por: Andre S. Monaco
  *         Alteracao:  Ajuste Query Externos / Atendimento Domiciliar
  *
  *    Funcao: Recupera atendimentos de determinado setor para faturar ou pedir
  *            produto ao paciente Igual a procedure PRC_CAD_ATENDIMENTO_S
               so que n?o limita pela data da alta, e a pesquisa e obrigatoria pelo numero
               do atendimento
  *
  *******************************************************************/
SIM CONSTANT NUMBER :=1;
NAO CONSTANT NUMBER :=0;
CENTRO_CIRURGICO CONSTANT NUMBER := 61;
UNIDADE_AMB_SANTOS CONSTANT NUMBER := 248;
UNIDADE_PS_SANTOS CONSTANT NUMBER := 250;
SETOR_ADMISSAO CONSTANT NUMBER := 22;
SETOR_ATD_DOMICILIAR CONSTANT NUMBER := 2252;
v_cursor      PKG_CURSOR.t_cursor;
vSetor        VARCHAR2(5);
vUniHos       VARCHAR2(4);
cCONFIGSETOR  PKG_CURSOR.t_cursor;
lnCONFIGSETOR TB_MTMD_MATMED_SETOR%ROWTYPE;
vMTMD_ATENDE_PAC_TODOS_SETORES   TB_MTMD_MATMED_SETOR.MTMD_ATENDE_PAC_TODOS_SETORES%TYPE;
vMTMD_IGNORA_ALTA                TB_MTMD_MATMED_SETOR.MTMD_IGNORA_ALTA%TYPE;
vMTMD_IGNORA_ALTA_HORAS_ATE      TB_MTMD_MATMED_SETOR.MTMD_IGNORA_ALTA_HORAS_ATE%TYPE;
vMTMD_CONSOME_CENTRO_CUSTO       TB_MTMD_MATMED_SETOR.MTMD_CONSOME_CENTRO_CUSTO%TYPE;
vMTMD_ATENDE_PAC_TODAS_UNID      TB_MTMD_MATMED_SETOR.MTMD_ATENDE_PAC_TODAS_UNIDADES%TYPE;
vMTMD_CONSOME_DIRETO_PACIENTE    TB_MTMD_MATMED_SETOR.MTMD_CONSOME_DIRETO_PACIENTE%TYPE;
vABERTURA_ATD_ATE_ID             TB_CAD_MTMD_ATD_ABERTURA.ATD_ATE_ID%TYPE;
--=================================================================================================
BEGIN
   -- RAISE_APPLICATION_ERROR(-20000,' SID ');
   IF ( pATD_ATE_TP_PACIENTE = 'I' ) THEN
      BEGIN
         SELECT CAD_SET_CD_SETOR, CAD_UNI_CD_UNID_HOSPITALAR
         INTO   vSetor,           vUniHos
         FROM TB_CAD_SET_SETOR SETOR,
              TB_CAD_UNI_UNIDADE UNID
         WHERE SETOR.cad_set_id                   = pCAD_SET_ID
         AND   SETOR.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE
         AND   SETOR.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
         AND   UNID.CAD_UNI_ID_UNIDADE            = SETOR.CAD_UNI_ID_UNIDADE;
      END;
      -- VERIFICA SE SETOR PODE ATENDER PACIENTES DE OUTROS SETORES OU UNIDADES
      BEGIN
         SELECT
              SETOR.MTMD_ATENDE_PAC_TODOS_SETORES,
              SETOR.MTMD_IGNORA_ALTA,
              SETOR.MTMD_CONSOME_CENTRO_CUSTO,
              SETOR.MTMD_ATENDE_PAC_TODAS_UNIDADES,
              SETOR.MTMD_CONSOME_DIRETO_PACIENTE,
              NVL(SETOR.MTMD_IGNORA_ALTA_HORAS_ATE,0)
         INTO vMTMD_ATENDE_PAC_TODOS_SETORES,
              vMTMD_IGNORA_ALTA,
              vMTMD_CONSOME_CENTRO_CUSTO,
              vMTMD_ATENDE_PAC_TODAS_UNID,
              vMTMD_CONSOME_DIRETO_PACIENTE,
              vMTMD_IGNORA_ALTA_HORAS_ATE
         FROM   TB_MTMD_MATMED_SETOR SETOR
         WHERE SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
         AND   SETOR.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
         AND   SETOR.CAD_SET_ID                   = pCAD_SET_ID;
      EXCEPTION
         WHEN NO_DATA_FOUND THEN
            vMTMD_ATENDE_PAC_TODOS_SETORES := 0;
            vMTMD_IGNORA_ALTA              := 0;
            vMTMD_CONSOME_CENTRO_CUSTO     := 0;
            vMTMD_ATENDE_PAC_TODAS_UNID    := 0;
            vMTMD_CONSOME_DIRETO_PACIENTE  := 0;
            vMTMD_IGNORA_ALTA_HORAS_ATE    := 0;
         WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,' ERRO PESQUISANDO LOCAIS QUE PODE ATENDER  UNIDADE '||TO_CHAR(pCAD_UNI_ID_UNIDADE)||
                                           ' LOCAL '||TO_CHAR(pCAD_LAT_ID_LOCAL_ATENDIMENTO)||
                                           ' SETOR '||TO_CHAR(pCAD_SET_ID)||
                                           SQLERRM);
      END;
      --Verificar se atendimento esta liberado para ajuste
      BEGIN
            SELECT ATD_ATE_ID
              INTO vABERTURA_ATD_ATE_ID
              FROM TB_CAD_MTMD_ATD_ABERTURA
            WHERE ATD_FL_ABERTO = 1 AND
                  ATD_ATE_ID = pATD_ATE_ID;
            vMTMD_IGNORA_ALTA := 1;
            vMTMD_IGNORA_ALTA_HORAS_ATE := 0;
      EXCEPTION
         WHEN NO_DATA_FOUND THEN
              NULL;
      END;
      IF ( vMTMD_ATENDE_PAC_TODOS_SETORES = SIM ) THEN
         vSetor := NULL;
      END IF;
      IF ( vMTMD_ATENDE_PAC_TODAS_UNID = SIM ) THEN
         vUniHos := NULL;
      END IF;
     OPEN v_cursor FOR
      SELECT ATENDIMENTO.ATD_ATE_ID,
             PESSOA.CAD_PES_NM_PESSOA CAD_PES_NM_PESSOA,
             PESSOA.CAD_PES_NM_RAZAOSOCIAL,
             PES_CONV.CAD_PES_NM_PESSOA CAD_CNV_NM_CONVENIO,
             -- PLANO.CAD_PLA_CD_PLANO,
             CONVENIO.CAD_CNV_CD_HAC_PRESTADOR CAD_PLA_CD_PLANO,
             SETOR.CAD_SET_DS_SETOR,
             QUARTO_LEITO.CAD_QLE_NR_QUARTO COD_QUARTO,
             QUARTO_LEITO.CAD_QLE_NR_LEITO COD_LEITO,
             ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO DT_INT,
             PESSOA.CAD_PES_DT_NASCIMENTO,
             PLANO.CAD_PLA_CD_TIPOPLANO,
             CASE WHEN (FNC_INT_PAC_OBITO_PERMITIR(ATENDIMENTO.ATD_ATE_ID, MOV_LEITO.ATD_IML_DT_SAIDA, MOV_LEITO.ATD_IML_HR_SAIDA) = 1) THEN
                       NULL -- Quando obito e ainda no prazo, n?o popular a DT_TRANSF
                  ELSE
                       MOV_LEITO.ATD_IML_DT_SAIDA
                  END DT_TRANSF,
             MOV_LEITO.ATD_IML_HR_SAIDA HR_TRANSF,
             ALTA.ATD_INA_DT_ALTA_ADM DT_ALTA,
             ATENDIMENTO.ATD_ATE_TP_PACIENTE,
             PAC_ATE.ASS_PAT_DT_ENTRADA,
             PAC_ATE.ASS_PAT_HR_ENTRADA,
             PACIENTE.CAD_PAC_CD_CREDENCIAL,
             PESSOA.CAD_PES_NM_NOMEMAE
       FROM TB_ATD_ATE_ATENDIMENTO       ATENDIMENTO,
            TB_CAD_SET_SETOR             SETOR,
            TB_CAD_PES_PESSOA            PESSOA,
            TB_CAD_PES_PESSOA            PES_CONV,
            TB_CAD_CNV_CONVENIO          CONVENIO,
            TB_CAD_PLA_PLANO             PLANO,
            TB_ASS_PAT_PACIEATEND        PAC_ATE,
            TB_CAD_PAC_PACIENTE          PACIENTE,
            TB_ATD_IML_INT_MOV_LEITO     MOV_LEITO,
            TB_CAD_QLE_QUARTO_LEITO      QUARTO_LEITO,
            TB_ATD_INA_INT_ALTA          ALTA
       WHERE ATENDIMENTO.ATD_ATE_ID                                 = pATD_ATE_ID
       AND ( SETOR.CAD_SET_ID                                      != SETOR_ADMISSAO )
       AND ( vSetor   IS NULL OR SETOR.CAD_SET_ID                   = pCAD_SET_ID )
       AND ( vUniHos  IS NULL OR SETOR.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE )
       AND ( vUniHos  IS NULL OR SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO )
       AND   QUARTO_LEITO.CAD_SET_ID                  = SETOR.CAD_SET_ID
       AND   PAC_ATE.ATD_ATE_ID                       = ATENDIMENTO.ATD_ATE_ID
       AND   PACIENTE.CAD_PAC_ID_PACIENTE             = PAC_ATE.CAD_PAC_ID_PACIENTE
       AND   PESSOA.CAD_PES_ID_PESSOA                 = PACIENTE.CAD_PES_ID_PESSOA
       AND   PES_CONV.CAD_PES_ID_PESSOA               = CONVENIO.CAD_PES_ID_PESSOA
       AND   CONVENIO.CAD_CNV_ID_CONVENIO             = PACIENTE.CAD_CNV_ID_CONVENIO
       AND   PLANO.CAD_PLA_ID_PLANO                   = PACIENTE.CAD_PLA_ID_PLANO
       AND   ATENDIMENTO.ATD_ATE_ID                   = MOV_LEITO.ATD_ATE_ID
       AND   MOV_LEITO.CAD_CAD_QLE_ID                 = QUARTO_LEITO.CAD_QLE_ID
       AND   ALTA.ATD_ATE_ID(+)                       = ATENDIMENTO.ATD_ATE_ID
       AND   MOV_LEITO.ATD_IML_FL_STATUS              = 'A'
       AND   ((vMTMD_IGNORA_ALTA = 1 AND vMTMD_IGNORA_ALTA_HORAS_ATE = 0) OR
             ((MOV_LEITO.ATD_IML_DT_SAIDA IS NULL AND PAC_ATE.ASS_PAT_DT_SAIDA IS NULL) OR FNC_INT_PAC_OBITO_PERMITIR(ATENDIMENTO.ATD_ATE_ID, MOV_LEITO.ATD_IML_DT_SAIDA, MOV_LEITO.ATD_IML_HR_SAIDA) = 1)) -- Quando obito e ainda no prazo, deixar consumir
       UNION
       SELECT ATENDIMENTO.ATD_ATE_ID,
             PESSOA.CAD_PES_NM_PESSOA CAD_PES_NM_PESSOA,
             PESSOA.CAD_PES_NM_RAZAOSOCIAL,
             PES_CONV.CAD_PES_NM_PESSOA CAD_CNV_NM_CONVENIO,
             -- PLANO.CAD_PLA_CD_PLANO,
             CONVENIO.CAD_CNV_CD_HAC_PRESTADOR CAD_PLA_CD_PLANO,
             SETOR.CAD_SET_DS_SETOR,
             NULL COD_QUARTO,
             NULL COD_LEITO,
             ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO DT_INT,
             PESSOA.CAD_PES_DT_NASCIMENTO,
             PLANO.CAD_PLA_CD_TIPOPLANO,
             CASE WHEN (FNC_INT_PAC_OBITO_PERMITIR(ATENDIMENTO.ATD_ATE_ID, MOV_LEITO.ATD_IML_DT_SAIDA, MOV_LEITO.ATD_IML_HR_SAIDA) = 1) THEN
                       NULL -- Quando obito e ainda no prazo, n?o popular a DT_TRANSF
                  ELSE
                       MOV_LEITO.ATD_IML_DT_SAIDA
                  END DT_TRANSF,
             MOV_LEITO.ATD_IML_HR_SAIDA HR_TRANSF,
             ALTA.ATD_INA_DT_ALTA_ADM DT_ALTA,
             ATENDIMENTO.ATD_ATE_TP_PACIENTE,
             PAC_ATE.ASS_PAT_DT_ENTRADA,
             PAC_ATE.ASS_PAT_HR_ENTRADA,
             PACIENTE.CAD_PAC_CD_CREDENCIAL,
             PESSOA.CAD_PES_NM_NOMEMAE
       FROM TB_ATD_ATE_ATENDIMENTO       ATENDIMENTO,
            TB_CAD_SET_SETOR             SETOR,
            TB_CAD_PES_PESSOA            PESSOA,
            TB_CAD_PES_PESSOA            PES_CONV,
            TB_CAD_CNV_CONVENIO          CONVENIO,
            TB_CAD_PLA_PLANO             PLANO,
            TB_ASS_PAT_PACIEATEND        PAC_ATE,
            TB_CAD_PAC_PACIENTE          PACIENTE,
            TB_ATD_IML_INT_MOV_LEITO     MOV_LEITO,
            TB_CAD_QLE_QUARTO_LEITO      QUARTO_LEITO,
            TB_ATD_INA_INT_ALTA          ALTA
       WHERE ATENDIMENTO.ATD_ATE_ID                                 = pATD_ATE_ID
       AND ( SETOR.CAD_SET_ID                                      != SETOR_ADMISSAO )
       AND ( vSetor   IS NULL OR SETOR.CAD_SET_ID                   = pCAD_SET_ID )
       AND ( vUniHos  IS NULL OR SETOR.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE )
       AND ( vUniHos  IS NULL OR SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO )
       AND   QUARTO_LEITO.CAD_SET_ID                  = SETOR.CAD_SET_ID
       AND   PAC_ATE.ATD_ATE_ID                       = ATENDIMENTO.ATD_ATE_ID
       AND   PACIENTE.CAD_PAC_ID_PACIENTE             = PAC_ATE.CAD_PAC_ID_PACIENTE
       AND   PESSOA.CAD_PES_ID_PESSOA                 = PACIENTE.CAD_PES_ID_PESSOA
       AND   PES_CONV.CAD_PES_ID_PESSOA               = CONVENIO.CAD_PES_ID_PESSOA
       AND   CONVENIO.CAD_CNV_ID_CONVENIO             = PACIENTE.CAD_CNV_ID_CONVENIO
       AND   PLANO.CAD_PLA_ID_PLANO                   = PACIENTE.CAD_PLA_ID_PLANO
       AND   ATENDIMENTO.ATD_ATE_ID                   = MOV_LEITO.ATD_ATE_ID
       AND   MOV_LEITO.CAD_CAD_QLE_ID                 = QUARTO_LEITO.CAD_QLE_ID
       AND   ALTA.ATD_ATE_ID(+)                       = ATENDIMENTO.ATD_ATE_ID
       AND   ATENDIMENTO.ATD_ATE_FL_STATUS            = 'A'
       AND   (vMTMD_IGNORA_ALTA_HORAS_ATE != 0 OR MOV_LEITO.ATD_IML_FL_STATUS = 'X')
       AND   (vMTMD_IGNORA_ALTA_HORAS_ATE = 0 OR (FNC_INT_PAC_BAIXA_HR_PERMITIR(MOV_LEITO.ATD_IML_DT_SAIDA, MOV_LEITO.ATD_IML_HR_SAIDA, vMTMD_IGNORA_ALTA_HORAS_ATE) = 1))
       /*SELECT DISTINCT
          ATENDIMENTO.ATD_ATE_ID,
          PESSOA.CAD_PES_NM_PESSOA CAD_PES_NM_PESSOA,
          PES_CONV.CAD_PES_NM_PESSOA CAD_CNV_NM_CONVENIO,
          -- PLANO.CAD_PLA_CD_PLANO,
          CONVENIO.CAD_CNV_CD_HAC_PRESTADOR CAD_PLA_CD_PLANO,
          SETOR.CAD_SET_DS_SETOR,
          NULL COD_QUARTO,
          NULL COD_LEITO,
          ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO DT_INT,
          PESSOA.CAD_PES_DT_NASCIMENTO,
          PLANO.CAD_PLA_CD_TIPOPLANO,
          NULL DT_TRANSF,
          NULL HR_TRANSF,
          ALTA.ATD_INA_DT_ALTA_ADM DT_ALTA,
          ATENDIMENTO.ATD_ATE_TP_PACIENTE,
          PAC_ATE.ASS_PAT_DT_ENTRADA,
          PAC_ATE.ASS_PAT_HR_ENTRADA
    FROM TB_ATD_ATE_ATENDIMENTO       ATENDIMENTO,
         TB_CAD_SET_SETOR             SETOR,
         TB_CAD_PES_PESSOA            PESSOA,
         TB_CAD_PES_PESSOA            PES_CONV,
         TB_CAD_CNV_CONVENIO          CONVENIO,
         TB_CAD_PLA_PLANO             PLANO,
         TB_ASS_PAT_PACIEATEND        PAC_ATE,
         TB_CAD_PAC_PACIENTE          PACIENTE,
         TB_ATD_IML_INT_MOV_LEITO     MOV_LEITO,
         TB_CAD_QLE_QUARTO_LEITO      QUARTO_LEITO,
         TB_ATD_INA_INT_ALTA          ALTA
--      WHERE ( pATD_ATE_ID                   IS NULL  OR ATENDIMENTO.ATD_ATE_ID            = pATD_ATE_ID )
--      AND   ( pATD_ATE_TP_PACIENTE          IS NULL OR ATENDIMENTO.ATD_ATE_TP_PACIENTE    = pATD_ATE_TP_PACIENTE )
    WHERE ATENDIMENTO.ATD_ATE_ID                                   = pATD_ATE_ID
    AND   ( vSetor   IS NULL OR SETOR.CAD_SET_ID                   = pCAD_SET_ID )
    AND   ( vUniHos  IS NULL OR SETOR.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE )
    AND   ( vUniHos  IS NULL OR SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO )
--      AND PESSOA.CAD_PES_NM_PESSOA           LIKE pCAD_PES_NM_PESSOA||'%'
--      AND   ( pCAD_CNV_CD_HAC_PRESTADOR     IS NULL OR CONVENIO.CAD_CNV_CD_HAC_PRESTADOR  = pCAD_CNV_CD_HAC_PRESTADOR )
--      AND   ( pCAD_PLA_CD_PLANO             IS NULL OR PLANO.CAD_PLA_CD_PLANO             = pCAD_PLA_CD_PLANO )
    AND   QUARTO_LEITO.CAD_SET_ID                  = SETOR.CAD_SET_ID
    AND   PAC_ATE.ATD_ATE_ID                       = ATENDIMENTO.ATD_ATE_ID
    AND   PACIENTE.CAD_PAC_ID_PACIENTE             = PAC_ATE.CAD_PAC_ID_PACIENTE
    AND   PESSOA.CAD_PES_ID_PESSOA                 = PACIENTE.CAD_PES_ID_PESSOA
    AND   PES_CONV.CAD_PES_ID_PESSOA               = CONVENIO.CAD_PES_ID_PESSOA
    AND   CONVENIO.CAD_CNV_ID_CONVENIO             = PACIENTE.CAD_CNV_ID_CONVENIO
    AND   PLANO.CAD_PLA_ID_PLANO                   = PACIENTE.CAD_PLA_ID_PLANO
    AND   ATENDIMENTO.ATD_ATE_ID                   = MOV_LEITO.ATD_ATE_ID
    AND   MOV_LEITO.CAD_CAD_QLE_ID(+)              = QUARTO_LEITO.CAD_QLE_ID
    AND   ALTA.ATD_ATE_ID                          = ATENDIMENTO.ATD_ATE_ID
    and   (vMTMD_IGNORA_ALTA_HORAS_ATE != 0 OR ALTA.ATD_INA_DT_ALTA_ADM IS NULL)
    --AND   (vMTMD_IGNORA_ALTA_HORAS_ATE = 0  OR (SYSDATE <= TO_DATE(TO_CHAR(TO_DATE(ALTA.ATD_INA_DT_ALTA_ADM),'DD/MM/YYYY') || ' ' || TO_CHAR(LPAD(ALTA.ATD_INA_HR_ALTA_ADM, 4, 0)), 'DD/MM/YY HH24MI')+vMTMD_IGNORA_ALTA_HORAS_ATE/24))
    AND   (vMTMD_IGNORA_ALTA_HORAS_ATE = 0 OR (FNC_INT_PAC_BAIXA_HR_PERMITIR(ALTA.ATD_INA_DT_ALTA_ADM, ALTA.ATD_INA_HR_ALTA_ADM, vMTMD_IGNORA_ALTA_HORAS_ATE) = 1))*/
    UNION -- PRE CADASTRO
       SELECT IAE.ATD_IAE_ID,
             PESSOA.CAD_PES_NM_PESSOA CAD_PES_NM_PESSOA,
             PESSOA.CAD_PES_NM_RAZAOSOCIAL,
             PES_CONV.CAD_PES_NM_PESSOA||'[IAE]' CAD_CNV_NM_CONVENIO,
             CONVENIO.CAD_CNV_CD_HAC_PRESTADOR CAD_PLA_CD_PLANO,
             SETOR.CAD_SET_DS_SETOR,
             NULL COD_QUARTO,
             NULL COD_LEITO,
             IAE.ATD_IAE_DT_ATENDIMENTO DT_INT,
             PESSOA.CAD_PES_DT_NASCIMENTO,
             PLANO.CAD_PLA_CD_TIPOPLANO,
             NULL DT_TRANSF,
             NULL HR_TRANSF,
             NULL DT_ALTA,
             IAE.ATD_IAE_TP_PACIENTE ATD_ATE_TP_PACIENTE,
             NULL ASS_PAT_DT_ENTRADA,
             NULL ASS_PAT_HR_ENTRADA,
             PACIENTE.CAD_PAC_CD_CREDENCIAL,
             PESSOA.CAD_PES_NM_NOMEMAE
       FROM TB_ATD_IAE_INT_AGE_ELETIVA   IAE,
            TB_CAD_SET_SETOR             SETOR,
            TB_CAD_PES_PESSOA            PESSOA,
            TB_CAD_PES_PESSOA            PES_CONV,
            TB_CAD_CNV_CONVENIO          CONVENIO,
            TB_CAD_PLA_PLANO             PLANO,
            TB_CAD_PAC_PACIENTE          PACIENTE
       WHERE IAE.ATD_IAE_ID                          = pATD_ATE_ID
       AND   IAE.CAD_PAC_ID_PACIENTE                  = PACIENTE.CAD_PAC_ID_PACIENTE
       AND   PESSOA.CAD_PES_ID_PESSOA                 = PACIENTE.CAD_PES_ID_PESSOA
       AND   PES_CONV.CAD_PES_ID_PESSOA               = CONVENIO.CAD_PES_ID_PESSOA
       AND   CONVENIO.CAD_CNV_ID_CONVENIO             = PACIENTE.CAD_CNV_ID_CONVENIO
       AND   PLANO.CAD_PLA_ID_PLANO                   = PACIENTE.CAD_PLA_ID_PLANO
       AND   SETOR.CAD_SET_ID                         = IAE.CAD_SET_ID
       AND   IAE.ATD_IAE_FL_STATUS                    = 'A'
       AND   pCAD_SET_ID                              = CENTRO_CIRURGICO
       AND   NOT EXISTS ( SELECT ATD_ATE_ID FROM TB_ATD_IMS_INT_MOV_SETOR IMS WHERE IMS.ATD_ATE_ID = IAE.ATD_IAE_ID )
       AND   NOT EXISTS ( SELECT ATD_ATE_ID FROM TB_ATD_IML_INT_MOV_LEITO IML WHERE IML.ATD_ATE_ID = IAE.ATD_IAE_ID )
     UNION -- EXTERNOS
       SELECT ATENDIMENTO.ATD_ATE_ID,
             PESSOA.CAD_PES_NM_PESSOA CAD_PES_NM_PESSOA,
             PESSOA.CAD_PES_NM_RAZAOSOCIAL,
             PES_CONV.CAD_PES_NM_PESSOA CAD_CNV_NM_CONVENIO,
             CONVENIO.CAD_CNV_CD_HAC_PRESTADOR||'  [I]' CAD_PLA_CD_PLANO,
             SETOR.CAD_SET_DS_SETOR,
             NULL COD_QUARTO,
             NULL COD_LEITO,
             ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO DT_INT,
             PESSOA.CAD_PES_DT_NASCIMENTO,
             PLANO.CAD_PLA_CD_TIPOPLANO,
             NULL DT_TRANSF,
             NULL HR_TRANSF,
             NULL DT_ALTA,
             ATENDIMENTO.ATD_ATE_TP_PACIENTE,
             PAC_ATE.ASS_PAT_DT_ENTRADA,
             PAC_ATE.ASS_PAT_HR_ENTRADA,
             PACIENTE.CAD_PAC_CD_CREDENCIAL,
             PESSOA.CAD_PES_NM_NOMEMAE
       FROM TB_ATD_ATE_ATENDIMENTO       ATENDIMENTO,
            TB_CAD_SET_SETOR             SETOR,
            TB_CAD_PES_PESSOA            PESSOA,
            TB_CAD_PES_PESSOA            PES_CONV,
            TB_CAD_CNV_CONVENIO          CONVENIO,
            TB_CAD_PLA_PLANO             PLANO,
            TB_ASS_PAT_PACIEATEND        PAC_ATE,
            TB_CAD_PAC_PACIENTE          PACIENTE,
            TB_ATD_IMS_INT_MOV_SETOR     MOV_SET
       WHERE ATENDIMENTO.ATD_ATE_ID                   = pATD_ATE_ID
       AND   PAC_ATE.ATD_ATE_ID                       = ATENDIMENTO.ATD_ATE_ID
       AND   PACIENTE.CAD_PAC_ID_PACIENTE             = PAC_ATE.CAD_PAC_ID_PACIENTE
       AND   PESSOA.CAD_PES_ID_PESSOA                 = PACIENTE.CAD_PES_ID_PESSOA
       AND   PES_CONV.CAD_PES_ID_PESSOA               = CONVENIO.CAD_PES_ID_PESSOA
       AND   CONVENIO.CAD_CNV_ID_CONVENIO             = PACIENTE.CAD_CNV_ID_CONVENIO
       AND   PLANO.CAD_PLA_ID_PLANO                   = PACIENTE.CAD_PLA_ID_PLANO
       AND   SETOR.CAD_SET_ID                         = MOV_SET.CAD_SET_ID_SETOR
       AND   MOV_SET.ATD_ATE_ID                       = ATENDIMENTO.ATD_ATE_ID
       --AND   (ATENDIMENTO.ATD_ATE_TP_PACIENTE = 'E' OR (vUniHos IS NULL OR (vSetor IS NULL OR SETOR.CAD_SET_ID = pCAD_SET_ID)))
       --AND   (MOV_SET.ATD_IMS_DT_SAIDA IS NULL AND ATENDIMENTO.ATD_ATE_TP_PACIENTE = 'I'
       --       OR MOV_SET.ATD_IMS_DT_SAIDA IS NOT NULL AND ATENDIMENTO.ATD_ATE_TP_PACIENTE = 'E')
       AND   ((NVL(pCAD_SET_ID,0) = SETOR_ATD_DOMICILIAR AND FNC_INT_PAC_BAIXA_HR_PERMITIR(NVL(MOV_SET.ATD_IMS_DT_SAIDA,TRUNC(SYSDATE+1)), NVL(MOV_SET.ATD_IMS_HR_SAIDA,0), NVL(vMTMD_IGNORA_ALTA_HORAS_ATE,0)) = 1) OR MOV_SET.CAD_SET_ID_SETOR != SETOR_ATD_DOMICILIAR)
       AND   ((vMTMD_IGNORA_ALTA = 1 AND vMTMD_IGNORA_ALTA_HORAS_ATE = 0) OR
              (((ATENDIMENTO.ATD_ATE_TP_PACIENTE = 'E' OR MOV_SET.ATD_IMS_DT_SAIDA IS NULL OR NVL(pCAD_SET_ID,0) = SETOR_ATD_DOMICILIAR) AND
                (NVL(pCAD_SET_ID,0) IN (CENTRO_CIRURGICO) OR (vUniHos IS NULL OR SETOR.CAD_SET_ID = pCAD_SET_ID))) OR
              (ATENDIMENTO.ATD_ATE_TP_PACIENTE IN ('E','I') AND FNC_INT_PAC_BAIXA_HR_PERMITIR(MOV_SET.ATD_IMS_DT_ENTRADA, MOV_SET.ATD_IMS_HR_ENTRADA, vMTMD_IGNORA_ALTA_HORAS_ATE) = 1)))
       AND   MOV_SET.ATD_IMS_FL_STATUS     = 'A'
       AND   ATENDIMENTO.ATD_ATE_FL_STATUS = 'A'
       ORDER BY 15 DESC, 16 DESC, 11 DESC, 2;
      --ORDER BY 11 DESC ,2 ;-- NOMPAC;
   ELSE -- AMBULATORIO
      -- RAISE_APPLICATION_ERROR(-20000,' SID AMB');
      OPEN v_cursor FOR
      SELECT
             ATENDIMENTO.ATD_ATE_ID,
             '..'||PESSOA.CAD_PES_NM_PESSOA CAD_PES_NM_PESSOA,
             PESSOA.CAD_PES_NM_RAZAOSOCIAL,
             PES_CONV.CAD_PES_NM_PESSOA CAD_CNV_NM_CONVENIO,
             TO_CHAR(CONVENIO.CAD_CNV_CD_HAC_PRESTADOR)||' '||
             TO_CHAR(PLANO.CAD_PLA_CD_PLANO)||' '||
             PES_CONV.CAD_PES_NM_PESSOA CAD_PLA_NM_NOME_PLANO,
             -- PES_CONV.CAD_PES_NM_PESSOA CAD_PLA_NM_NOME_PLANO,
             -- PLANO.CAD_PLA_CD_PLANO,
            CONVENIO.CAD_CNV_CD_HAC_PRESTADOR CAD_PLA_CD_PLANO,
             SETOR.CAD_SET_DS_SETOR,
             NULL COD_QUARTO,
             NULL COD_LEITO,
             ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO DT_INT,
             PESSOA.CAD_PES_DT_NASCIMENTO,
             PLANO.CAD_PLA_CD_TIPOPLANO,
             NULL DT_TRANSF,
             ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO HR_TRANSF,
             NULL DT_ALTA,
             ATENDIMENTO.ATD_ATE_TP_PACIENTE,
             PACIENTE.CAD_PAC_CD_CREDENCIAL,
             PESSOA.CAD_PES_NM_NOMEMAE
      FROM TB_ATD_ATE_ATENDIMENTO       ATENDIMENTO,
           TB_CAD_SET_SETOR             SETOR,
           TB_CAD_UNI_UNIDADE           UNIDADE,
           TB_CAD_LAT_LOCAL_ATENDIMENTO LOCAL_,
           TB_CAD_PES_PESSOA            PESSOA,
           TB_CAD_PES_PESSOA            PES_CONV,
           TB_CAD_CNV_CONVENIO          CONVENIO,
           TB_CAD_PLA_PLANO             PLANO,
           TB_ASS_PAT_PACIEATEND        PAC_ATE,
           TB_CAD_PAC_PACIENTE          PACIENTE
      WHERE ATENDIMENTO.ATD_ATE_ID                   = pATD_ATE_ID
            -- Quando AMB SANTOS, liberar tambem PS SANTOS
      AND   (pCAD_UNI_ID_UNIDADE != UNIDADE_AMB_SANTOS OR SETOR.CAD_UNI_ID_UNIDADE IN (UNIDADE_AMB_SANTOS,UNIDADE_PS_SANTOS))
      AND   (pCAD_SET_ID = CENTRO_CIRURGICO OR pCAD_UNI_ID_UNIDADE = UNIDADE_AMB_SANTOS OR SETOR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
      AND   (ATENDIMENTO.CAD_SET_ID != SETOR_ADMISSAO )
      AND   ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
      AND   ATENDIMENTO.CAD_UNI_ID_UNIDADE           = SETOR.CAD_UNI_ID_UNIDADE
      AND   ATENDIMENTO.CAD_SET_ID                   = SETOR.CAD_SET_ID
      AND   UNIDADE.CAD_UNI_ID_UNIDADE               = SETOR.CAD_UNI_ID_UNIDADE
      AND   LOCAL_.CAD_LAT_ID_LOCAL_ATENDIMENTO      = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
      AND   PAC_ATE.atd_ate_id                       = ATENDIMENTO.atd_ate_id
      AND   PACIENTE.CAD_PAC_ID_PACIENTE             = PAC_ATE.CAD_PAC_ID_PACIENTE
      AND   PESSOA.CAD_PES_ID_PESSOA                 = PACIENTE.cad_pes_id_pessoa
      AND   PES_CONV.cad_pes_id_pessoa               = CONVENIO.cad_pes_id_pessoa
      AND   CONVENIO.cad_cnv_id_convenio             = PACIENTE.cad_cnv_id_convenio
      AND   PLANO.cad_pla_id_plano                   = PACIENTE.cad_pla_id_plano
      AND   (TRUNC(ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO)>= TRUNC(SYSDATE-60)
             OR ATENDIMENTO.ATD_ATE_ID IN (SELECT ATD_ATE_ID FROM TB_CAD_MTMD_ATD_ABERTURA
                                            WHERE ATD_FL_ABERTO = 1 AND ATD_ATE_ID = ATENDIMENTO.ATD_ATE_ID))
      AND   pATD_ATE_TP_PACIENTE IS NOT NULL
      AND   ATENDIMENTO.ATD_ATE_FL_STATUS = 'A'
      ORDER BY PESSOA.cad_pes_nm_pessoa;
   END IF;
  io_cursor := v_cursor;
END PRC_CAD_ATENDIMENTO_SID;