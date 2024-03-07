 CREATE OR REPLACE PROCEDURE SGS.PRC_MTMD_MOV_INTERNADO_I
  (  
     pATD_ATE_ID IN TB_MTMD_MOV_INTERNADO.ATD_ATE_ID%type,
     pMTMD_MOV_ID IN TB_MTMD_MOV_INTERNADO.MTMD_MOV_ID%type,
     pCAD_MTMD_ID IN TB_MTMD_MOV_INTERNADO.CAD_MTMD_ID%type,
     pSEQ_PACIENTE OUT NUMBER
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_INTERNADO_I
  * 
  *    Data Criacao: 	15/07/2009   Por: André S. Monaco
       Data Alteração: 26/03/2010
            Alteração: incluida data na chave, para gerar uma sequencia por dia para cada paciente
       Data Alteração: 30/03/2010
            Alteração: voltando lógica de faturamento para 1 item 1 requisição no legado
       Data Alteração: 10/09/2010
            Alteração: ATUALIZADO MIGRA2
  *
  *    Funcao: Inserir registro
  *******************************************************************/  
	nSEQ_PACIENTE NUMBER;  
	nTeste NUMBER;
BEGIN
   BEGIN
   SELECT NVL(MAX(MOV.SEQ_PACIENTE ),0) + 1
   INTO nSEQ_PACIENTE
   FROM TB_MTMD_MOV_INTERNADO MOV
   WHERE MOV.atd_ate_id = pATD_ATE_ID;
   EXCEPTION WHEN OTHERS THEN
      RAISE_APPLICATION_ERROR(-20000,' BUSCANDO MAIOR SEQUENCIA ');
   END;
   -- VERIFICA SE NAO EXISTE NO LEGADO
   BEGIN
      SELECT NSEQ_PAC
      INTO nTeste
      FROM MTM_REQ_PACIENTE
      WHERE NR_SEQINTER = pATD_ATE_ID
      AND   NSEQ_PAC    = nSEQ_PACIENTE
      AND ROWNUM = 1;
      -- ACHOU VERIFICA ULTIMO NUMERO
      IF (  nSEQ_PACIENTE > 8999 ) THEN
         -- E ULTIMO NUMERO DA SEQUENCIA N?O ENCREMENTA
         -- IGUALA A ULTIMO NUMERO SUPORTADO NA BASE DE DADOS (4 DIGITOS)
         nSEQ_PACIENTE := 8999;
      ELSE
         BEGIN
          SELECT NVL(MAX(NSEQ_PAC), 0) + 1
          INTO   nSEQ_PACIENTE
          FROM HOSPITAL.MTM_REQ_PACIENTE REQ
          WHERE REQ.NR_SEQINTER = pATD_ATE_ID;         
         END;
      END IF;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      IF (  nSEQ_PACIENTE > 8999 ) THEN      
         -- MAIOR NUMERO SUPORTADO E DE 4 DIGITOS
         nSEQ_PACIENTE := 8999;
      END IF;
      -- NAO ACHOU PODE USAR SEQUENCIA
      NULL;
    WHEN OTHERS THEN
      RAISE_APPLICATION_ERROR(-20000,' BUSCANDO ULTIMA SEQUENCIA ');         
   END;      
    IF ( nSEQ_PACIENTE IS NULL ) THEN    
       SELECT NVL(MAX(NSEQ_PAC), 0) + 1
       INTO   nSEQ_PACIENTE
       -- FROM TB_MTMD_MOV_INTERNADO
       FROM HOSPITAL.MTM_REQ_PACIENTE REQ
       WHERE REQ.NR_SEQINTER = pATD_ATE_ID;
       -- WHERE ATD_ATE_ID = pATD_ATE_ID;     
     END IF;
    BEGIN	    
    INSERT INTO TB_MTMD_MOV_INTERNADO
    (ATD_ATE_ID,  SEQ_PACIENTE,   MTMD_MOV_ID,  CAD_MTMD_ID, CAD_MTMD_FL_EXCLUIDO  )
    VALUES
    (pATD_ATE_ID, nSEQ_PACIENTE,  pMTMD_MOV_ID, pCAD_MTMD_ID, 0);
    EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
       IF ( nSEQ_PACIENTE >= 9999  ) THEN
          -- MAIOR NUMERO SUPORTADO PELO LEGADO E DE 4 DIGITOS
          -- IGNORA ENTRADA DA SEQUENCIA MAIOR QUE 9999, PERDE A SEQUENCIA DE MOVIMENTAC?O
          NULL;
       ELSE
          BEGIN
             SELECT NVL(MAX(SEQ_PACIENTE), 0) + 1
             INTO   nSEQ_PACIENTE
             FROM TB_MTMD_MOV_INTERNADO
             WHERE ATD_ATE_ID = pATD_ATE_ID;     
             --
             INSERT INTO TB_MTMD_MOV_INTERNADO
             (ATD_ATE_ID,  SEQ_PACIENTE,   MTMD_MOV_ID,  CAD_MTMD_ID, CAD_MTMD_FL_EXCLUIDO  )
             VALUES
             (pATD_ATE_ID, nSEQ_PACIENTE,  pMTMD_MOV_ID, pCAD_MTMD_ID, 0);             
          EXCEPTION WHEN OTHERS THEN
              -- NULL;
              RAISE_APPLICATION_ERROR(-20000,' ERRO TENTANDO INSERIR MOV INTERNADO '||SQLERRM);
          END;
       END IF;
    END;
    pSEQ_PACIENTE := nSEQ_PACIENTE;
  end PRC_MTMD_MOV_INTERNADO_I;
