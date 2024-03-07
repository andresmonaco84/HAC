CREATE OR REPLACE PROCEDURE PRC_CAD_ATENDIMENTO_S
(
pATD_ATE_ID                   IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
pATD_ATE_TP_PACIENTE          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
pCAD_SET_ID                   IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
pCAD_PES_NM_PESSOA            IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%TYPE DEFAULT NULL,
pCAD_CNV_CD_HAC_PRESTADOR     IN TB_CAD_CNV_CONVENIO.CAD_CNV_CD_HAC_PRESTADOR%TYPE DEFAULT NULL,
pCAD_PLA_CD_PLANO             IN TB_CAD_PLA_PLANO.CAD_PLA_CD_PLANO%TYPE DEFAULT NULL,
io_cursor                     OUT PKG_CURSOR.t_cursor
)  IS 
  /********************************************************************
  *    Procedure: PRC_CAD_ATENDIMENTO_S
  *
  *    Data Criacao:    06/2009	    Por: Ricardo Costa
  *    Data Alteracao:	11/01/2010  Por: Ricardo Costa
  *    Data Alteracao:	07/04/2010  Por: André Souza Monaco
  *         Alteracao:  Traz junto com internado do SGS
  *    Data Alteracao:	08/04/2010  Por: André Souza Monaco
  *         Alteracao:  Quando ambulatório, traz só atendimento de hoje
  *    Data Alteracao:	20/08/2010  Por: RICARDO COSTA
  *         Alteracao:  ATUALIZADO MIGRA2
  *    Data Alteracao:	01/09/2010  Por: RICARDO COSTA
  *         Alteracao:  DESATIVANDO PESQUISA NO LEGADO
  *    Data Alteracao:	14/10/2010      Por: André S. Monaco
  *         Alteracao:  Adição da regra de quando óbito, 
  *                     deixar mostrar atendimento por mais um período
  *    Data Alteracao:	12/05/2011      Por: André S. Monaco
  *         Alteracao:  Adição da chamada da função FNC_INT_PAC_BAIXA_HR_PERMITIR na query
  *    Data Alteracao:	07/06/2011      Por: André S. Monaco
  *         Alteracao:  Retirei a query do PRE-CADASTRO para Centro-Cirúrgico 
  *                     (pois se não traz muita coisa. terá que digitar a sequência)
  *    Data Alteracao:	12/09/2011      Por: Andre S. Monaco
  *         Alteracao:  Não trazer setor admissão na query
  *    Data Alteracao:	27/03/2013      Por: Andre S. Monaco
  *         Alteracao:  Adição de filtro de atendimentos ativos  
  *    Data Alteracao:	16/06/2014      Por: Andre S. Monaco
  *         Alteracao:  Ajuste query de Internação p/ padrão string dinamica
  *
  *    Funcao: Recupera atendimentos de determinado setor para faturar ou pedir
  *            produto ao paciente
  *******************************************************************/
SIM CONSTANT NUMBER :=1;
SETOR_ADMISSAO   CONSTANT NUMBER := 22;
v_cursor      PKG_CURSOR.t_cursor;
vSetor        VARCHAR2(5);
vUniHos       VARCHAR2(4);
vMTMD_ATENDE_PAC_TODOS_SETORES  TB_MTMD_MATMED_SETOR.MTMD_ATENDE_PAC_TODOS_SETORES%TYPE;
vMTMD_IGNORA_ALTA                TB_MTMD_MATMED_SETOR.MTMD_IGNORA_ALTA%TYPE;
vMTMD_IGNORA_ALTA_HORAS_ATE      TB_MTMD_MATMED_SETOR.MTMD_IGNORA_ALTA_HORAS_ATE%TYPE;
vMTMD_ATENDE_PAC_TODAS_UNID      TB_MTMD_MATMED_SETOR.MTMD_ATENDE_PAC_TODAS_UNIDADES%TYPE;
V_WHERE  varchar2(5000);
V_SELECT  varchar2(5000);
BEGIN
   IF ( pATD_ATE_TP_PACIENTE = 'I' ) THEN -- INTERNACAO SGS
      BEGIN
      SELECT CAD_SET_CD_SETOR, CAD_UNI_CD_UNID_HOSPITALAR
      INTO   vSetor,           vUniHos
      FROM TB_CAD_SET_SETOR SETOR,
           TB_CAD_UNI_UNIDADE UNID
      WHERE SETOR.cad_set_id                   = pCAD_SET_ID
      AND   SETOR.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE
      AND   SETOR.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
      AND   UNID.CAD_UNI_ID_UNIDADE            = SETOR.cad_uni_id_unidade;
      END;
      -- VERIFICA SE SETOR PODE ATENDER PACIENTES DE OUTROS SETORES OU UNIDADES
      BEGIN
         SELECT
              SETOR.MTMD_ATENDE_PAC_TODOS_SETORES,
              NVL(SETOR.MTMD_IGNORA_ALTA,0),
              SETOR.MTMD_ATENDE_PAC_TODAS_UNIDADES,
              NVL(SETOR.MTMD_IGNORA_ALTA_HORAS_ATE,0)
         INTO vMTMD_ATENDE_PAC_TODOS_SETORES,
              vMTMD_IGNORA_ALTA,
              vMTMD_ATENDE_PAC_TODAS_UNID,
              vMTMD_IGNORA_ALTA_HORAS_ATE
         FROM   TB_MTMD_MATMED_SETOR SETOR
         WHERE SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
         AND   SETOR.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
         AND   SETOR.CAD_SET_ID                   = pCAD_SET_ID;
      EXCEPTION
         WHEN NO_DATA_FOUND THEN
            vMTMD_ATENDE_PAC_TODOS_SETORES := 0;
            vMTMD_IGNORA_ALTA              := 0;
            vMTMD_ATENDE_PAC_TODAS_UNID    := 0;
            vMTMD_IGNORA_ALTA_HORAS_ATE    := 0;
         WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,' ERRO PESQUISANDO LOCAIS QUE PODE ATENDER  UNIDADE '||TO_CHAR(pCAD_UNI_ID_UNIDADE)||
                                           ' LOCAL '||TO_CHAR(pCAD_LAT_ID_LOCAL_ATENDIMENTO)||
                                           ' SETOR '||TO_CHAR(pCAD_SET_ID)||
                                           SQLERRM);
      END;
      IF ( vMTMD_ATENDE_PAC_TODOS_SETORES = SIM ) THEN
         vSetor := NULL;
      END IF;
      IF ( vMTMD_ATENDE_PAC_TODAS_UNID = SIM ) THEN
         vUniHos := NULL;
      END IF;
      V_WHERE:= ' AND SETOR.CAD_SET_ID != ' || SETOR_ADMISSAO;
      IF pCAD_PES_NM_PESSOA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND PESSOA.CAD_PES_NM_PESSOA = ' || CHR(39) || pCAD_PES_NM_PESSOA || CHR(39); END IF;      
      IF vSetor IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SETOR.CAD_SET_ID = ' || pCAD_SET_ID; END IF;
      IF vUniHos IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SETOR.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
      IF vUniHos IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;           
      --AND   ( vSetor   IS NULL OR SETOR.CAD_SET_ID                   = pCAD_SET_ID )
      --AND   ( vUniHos  IS NULL OR SETOR.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE )
      --AND   ( vUniHos  IS NULL OR SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO )     
      IF (vMTMD_IGNORA_ALTA = 0 OR (vMTMD_IGNORA_ALTA = 1 AND vMTMD_IGNORA_ALTA_HORAS_ATE != 0)) THEN
         V_WHERE := V_WHERE || ' AND ((MOV_LEITO.ATD_IML_DT_SAIDA IS NULL AND PAC_ATE.ASS_PAT_DT_SAIDA IS NULL) OR FNC_INT_PAC_OBITO_PERMITIR(ATENDIMENTO.ATD_ATE_ID, MOV_LEITO.ATD_IML_DT_SAIDA, MOV_LEITO.ATD_IML_HR_SAIDA) = 1) ';
      END IF;      
      --AND   ((' || vMTMD_IGNORA_ALTA || ' = 1 AND ' || vMTMD_IGNORA_ALTA_HORAS_ATE || ' = 0) OR
      --      ((MOV_LEITO.ATD_IML_DT_SAIDA IS NULL AND PAC_ATE.ASS_PAT_DT_SAIDA IS NULL) OR FNC_INT_PAC_OBITO_PERMITIR(ATENDIMENTO.ATD_ATE_ID, MOV_LEITO.ATD_IML_DT_SAIDA, MOV_LEITO.ATD_IML_HR_SAIDA) = 1)) -- Quando óbito e ainda no prazo, deixar consumir
      V_SELECT := 'SELECT ATENDIMENTO.ATD_ATE_ID,
                          PESSOA.CAD_PES_NM_PESSOA CAD_PES_NM_PESSOA,
                          PESSOA.CAD_PES_NM_RAZAOSOCIAL,
                          PES_CONV.CAD_PES_NM_PESSOA CAD_CNV_NM_CONVENIO,
                          CONVENIO.CAD_CNV_CD_HAC_PRESTADOR CAD_PLA_CD_PLANO,
                          SETOR.CAD_SET_DS_SETOR,
                          QUARTO_LEITO.CAD_QLE_NR_QUARTO COD_QUARTO,
                          QUARTO_LEITO.CAD_QLE_NR_LEITO COD_LEITO,
                          ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO DT_INT,
                          PESSOA.CAD_PES_DT_NASCIMENTO,
                          PLANO.CAD_PLA_CD_TIPOPLANO,
                          NULL DT_TRANSF,
                          NULL HR_TRANSF,
                          MOV_LEITO.ATD_IML_DT_SAIDA DT_ALTA,
                          ATENDIMENTO.ATD_ATE_TP_PACIENTE
                    FROM TB_ATD_ATE_ATENDIMENTO       ATENDIMENTO,
                         TB_CAD_SET_SETOR             SETOR,
                         TB_CAD_PES_PESSOA            PESSOA,
                         TB_CAD_PES_PESSOA            PES_CONV,
                         TB_CAD_CNV_CONVENIO          CONVENIO,
                         TB_CAD_PLA_PLANO             PLANO,
                         TB_ASS_PAT_PACIEATEND        PAC_ATE,
                         TB_CAD_PAC_PACIENTE          PACIENTE,
                         TB_ATD_IML_INT_MOV_LEITO     MOV_LEITO,
                         TB_CAD_QLE_QUARTO_LEITO      QUARTO_LEITO
                    WHERE QUARTO_LEITO.CAD_SET_ID                  = SETOR.CAD_SET_ID
                    AND   PAC_ATE.ATD_ATE_ID                       = ATENDIMENTO.ATD_ATE_ID
                    AND   PACIENTE.CAD_PAC_ID_PACIENTE             = PAC_ATE.CAD_PAC_ID_PACIENTE
                    AND   PESSOA.CAD_PES_ID_PESSOA                 = PACIENTE.CAD_PES_ID_PESSOA
                    AND   PES_CONV.CAD_PES_ID_PESSOA               = CONVENIO.CAD_PES_ID_PESSOA
                    AND   CONVENIO.CAD_CNV_ID_CONVENIO             = PACIENTE.CAD_CNV_ID_CONVENIO
                    AND   PLANO.CAD_PLA_ID_PLANO                   = PACIENTE.CAD_PLA_ID_PLANO
                    AND   ATENDIMENTO.ATD_ATE_ID                   = MOV_LEITO.ATD_ATE_ID
                    AND   MOV_LEITO.CAD_CAD_QLE_ID(+)              = QUARTO_LEITO.CAD_QLE_ID
                    AND   MOV_LEITO.ATD_IML_FL_STATUS              = ''A''
                    AND   ATENDIMENTO.ATD_ATE_FL_STATUS            = ''A'''
                    || V_WHERE ||
                   'ORDER BY 2 -- NOMPAC ';
      OPEN v_cursor FOR
      V_SELECT;           
   ELSE -- AMBULATORIO
      OPEN v_cursor FOR
      SELECT
             ATENDIMENTO.ATD_ATE_ID,
             '..'||PESSOA.CAD_PES_NM_PESSOA CAD_PES_NM_PESSOA,
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
             NULL DT_TRANSF,
             NULL HR_TRANSF,
             NULL DT_ALTA,
             ATENDIMENTO.ATD_ATE_TP_PACIENTE
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
      WHERE ( pATD_ATE_ID                   IS NULL  OR ATENDIMENTO.ATD_ATE_ID            = pATD_ATE_ID )
      AND   ( pATD_ATE_TP_PACIENTE          IS NULL OR ATENDIMENTO.atd_ate_tp_paciente    = pATD_ATE_TP_PACIENTE )
      AND   ( SETOR.CAD_SET_ID              != SETOR_ADMISSAO )
      AND   ( pCAD_SET_ID                   IS NULL OR SETOR.cad_set_id                   = pCAD_SET_ID )
      AND   ( pCAD_UNI_ID_UNIDADE           IS NULL OR SETOR.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE )
      AND   ( pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR SETOR.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO )
      AND   ( pCAD_PES_NM_PESSOA            IS NULL OR PESSOA.CAD_PES_NM_PESSOA        LIKE pCAD_PES_NM_PESSOA||'%' )
      AND   ( pCAD_CNV_CD_HAC_PRESTADOR     IS NULL OR CONVENIO.CAD_CNV_CD_HAC_PRESTADOR  = pCAD_CNV_CD_HAC_PRESTADOR )
      AND   ( pCAD_PLA_CD_PLANO             IS NULL OR PLANO.CAD_PLA_CD_PLANO             = pCAD_PLA_CD_PLANO )
      AND   ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
      AND   ATENDIMENTO.CAD_UNI_ID_UNIDADE           = SETOR.CAD_UNI_ID_UNIDADE
      AND   ATENDIMENTO.CAD_SET_ID                   = SETOR.CAD_SET_ID
      AND   UNIDADE.CAD_UNI_ID_UNIDADE               = SETOR.CAD_UNI_ID_UNIDADE
      AND   LOCAL_.CAD_LAT_ID_LOCAL_ATENDIMENTO      = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
      AND   PAC_ATE.atd_ate_id                       = ATENDIMENTO.atd_ate_id
      AND   PACIENTE.cad_pac_id_paciente             = PAC_ATE.cad_pac_id_paciente
      AND   PESSOA.CAD_PES_ID_PESSOA                 = PACIENTE.cad_pes_id_pessoa
      AND   PES_CONV.cad_pes_id_pessoa               = CONVENIO.cad_pes_id_pessoa
      AND   CONVENIO.cad_cnv_id_convenio             = PACIENTE.cad_cnv_id_convenio
      AND   PLANO.cad_pla_id_plano                   = PACIENTE.cad_pla_id_plano
      AND   TRUNC(ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO)= TRUNC(SYSDATE)
      AND   pATD_ATE_TP_PACIENTE IS NOT NULL
      AND   ATENDIMENTO.ATD_ATE_FL_STATUS = 'A'
      ORDER BY PESSOA.CAD_PES_NM_PESSOA;
   END IF;
  io_cursor := v_cursor;
END PRC_CAD_ATENDIMENTO_S;