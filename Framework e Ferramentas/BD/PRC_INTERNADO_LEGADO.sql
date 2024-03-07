CREATE OR REPLACE PROCEDURE PRC_INTERNADO_LEGADO
   ( pNR_SEQINTER IN  TB_INTERNADO.NR_SEQINTER%type DEFAULT NULL,
     pCAD_SET_ID                   IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,   
     pNOMPAC      IN  TB_INTERNADO.NOMPAC%type DEFAULT NULL,
     io_cursor    OUT PKG_CURSOR.t_cursor ) IS


  /********************************************************************
  *    Procedure: InformacoesInternado
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/

  v_cursor PKG_CURSOR.t_cursor;      
  vSetor VARCHAR2(4);
BEGIN 

-- busca info do setor
   IF (  pCAD_SET_ID IS NOT NULL ) THEN
      BEGIN
      SELECT CAD_SET_CD_SETOR
      INTO   vSetor
      FROM TB_CAD_SET_SETOR SETOR
      WHERE SETOR.cad_set_id                   = pCAD_SET_ID
      AND   SETOR.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE
      AND   SETOR.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO;
      END;
      
   END IF;

   IF ( pNR_SEQINTER IS NOT NULL ) THEN
    OPEN v_cursor FOR
        SELECT INTER.NR_SEQINTER, INTER.NOMPAC,      EMPRES.NOMEMP, 
               EMPRES.CODCON,     SETOR.DS_SETOR,
               QUARTO.COD_QUARTO, QUARTO.COD_LEITO,  INTER.DT_INT,
               INTER.DATNASPAC, PLANO.CAD_PLA_CD_TIPOPLANO
        FROM TB_INTERNADO     INTER,
             TB_QUARTO        QUARTO,
             TB_SETOR         SETOR,
             TB_TRANSFERENCIA TRANSF,
             EMPRESA          EMPRES,
             TB_CAD_CNV_CONVENIO CONVENIO,
             TB_CAD_PLA_PLANO PLANO
        WHERE INTER.NR_SEQINTER  = pNR_SEQINTER
        AND   TRANSF.NR_SEQINTER = INTER.nr_seqinter
        AND   TRANSF.CODUNIHOS   = INTER.CODUNIHOS
        AND   QUARTO.COD_QUARTO  = TRANSF.COD_QUARTO
        AND   QUARTO.COD_LEITO   = TRANSF.COD_LEITO
        AND   QUARTO.CODUNIHOS   = TRANSF.CODUNIHOS
        AND   SETOR.CD_SETOR     = QUARTO.CD_SETOR
        AND   SETOR.AN_SETOR     = QUARTO.AN_SETOR
        AND   SETOR.CODUNIHOS    = QUARTO.CODUNIHOS
        AND   ( vSetor IS NULL OR SETOR.cd_setor = vSetor )
        AND   EMPRES.CODCON      = INTER.CODCON    
        AND   PLANO.cad_pla_cd_plano_hac = INTER.CODCON        
        AND   PLANO.CAD_CNV_ID_CONVENIO = CONVENIO.CAD_CNV_ID_CONVENIO
        AND   TRANSF.DT_SAIDA IS NULL
        AND   TRANSF.HORA_SAIDA IS NULL;       
   ELSE
    OPEN v_cursor FOR   
        SELECT INTER.NOMPAC,      EMPRES.NOMEMP, 
               EMPRES.CODCON,     SETOR.DS_SETOR,
               QUARTO.COD_QUARTO, QUARTO.COD_LEITO 
        FROM TB_INTERNADO     INTER,
             TB_QUARTO        QUARTO,
             TB_SETOR         SETOR,
             TB_TRANSFERENCIA TRANSF,
             EMPRESA          EMPRES
        WHERE INTER.NOMPAC  LIKE ( pNOMPAC||'%')
        AND   TRANSF.NR_SEQINTER = INTER.nr_seqinter
        AND   TRANSF.CODUNIHOS   = INTER.CODUNIHOS
        AND   QUARTO.COD_QUARTO  = TRANSF.COD_QUARTO
        AND   QUARTO.COD_LEITO   = TRANSF.COD_LEITO
        AND   QUARTO.CODUNIHOS   = TRANSF.CODUNIHOS
        AND   SETOR.CD_SETOR     = QUARTO.CD_SETOR
        and   SETOR.AN_SETOR     = QUARTO.AN_SETOR
        AND   SETOR.CODUNIHOS    = QUARTO.CODUNIHOS
        AND   ( vSetor IS NULL OR SETOR.cd_setor = vSetor )
        AND   EMPRES.CODCON      = INTER.CODCON     
        AND   TRANSF.DT_SAIDA IS NULL
        AND   TRANSF.HORA_SAIDA IS NULL;
   
   END IF;
       io_cursor := v_cursor;

   END PRC_INTERNADO_LEGADO; 
