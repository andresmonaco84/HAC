CREATE OR REPLACE PROCEDURE SGS.PRC_MTMD_MOV_FATURAR_ONLINE
(
pMTMD_MOV_ID IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type,
pACAO IN number   --Valores possíveis 0: Inclusão / 1: Exclusão
) IS
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_FATURAR_ONLINE
  *
  *    Data Criacao: 05/06/2009     Por: Alexandre M. Muniz
  *    Data Alteracao: 15/01/20110     Por: Ricardo Costa
  *         Alteração: Alterar data de faturamento
  *    Data Alteracao: 04/02/20110     Por: Ricardo Costa
  *         Alteração: Algumas correções e inclusão de exceptions
  *    Data Alteracao: 27/01/20110     Por: Ricardo Costa
  *    Alteração: Força data da tb_transferencia ou tb_internado
  *    Data Alteracao: 26/03/2010     Por: Ricardo Costa
  *    Alteração: Retirei checagem de chave duplicada no legal, ele já poderá existir
  *    Data Alteracao: 30/03/2010     Por: Ricardo Costa
  *         Alteração: Voltando para lógica anterior
  *    Data Alteracao: 06/04/2010     Por: André Souza Monaco  
  *         Alteração: Verificação de SEQ_PACIENTE (troca de 8999 p/ 9999)
  *    Data Alteracao: 06/04/2010     Por: André Souza Monaco
  *         Alteração: Volta para a versão anterior
  *    Data Alteracao: 06/04/2010     Por: André Souza Monaco
  *         Alteração: Volta para a versão anterior
  *    Data Alteracao: 23/08/2010     Por: RICARDO COSTA
  *         Alteração: ATUALIZADO MIGRA2
  *    Data Alteracao: 04/11/2010     Por: André S. Monaco
  *         Alteração: Inclusão no CC do André (eu) e da Mari quando conta estourar 8999 regs.
  *
  *    Funcao: Transfere os movimentos do estoque, que devem ser
  *         faturados, para as tabelas do sistema de estoque
  *         anterior nas quais os sistema de faturamento, legado,
  *         buscará os materiais e medicamentos a faturar.
  *
  *******************************************************************/
-- Recupera uma requisição (movimentação)
-- que será enviada para faturamento
CURSOR MOVFAT_CUR IS
SELECT MOV.ATD_ATE_ID,                -- Número do Atendimento
       MOV.MTMD_MOV_ID,               -- Código da Requisição
       MOV.MTMD_MOV_QTDE,             -- Quantidade Requisitada
       MOV.CAD_MTMD_ID,
       MOV.MTMD_REQ_ID,
       MOV.MTMD_MOV_DATA,
       MOV.CAD_MTMD_TPMOV_ID,
       MOV.CAD_MTMD_SUBTP_ID,
       MOV.mtmd_mov_data_faturamento,
       MOV.mtmd_mov_hora_faturamento,
       MOV.ATD_ATE_TP_PACIENTE,
       MOV.CAD_UNI_ID_UNIDADE,
       MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       MOV.CAD_SET_ID,
       MATMED.CAD_MTMD_CODMNE,        -- Código do Mneumônico do MAT/MED
       MATMED.TIS_MED_CD_TABELAMEDICA,
       SETOR.CD_SETOR,
       SETOR.AN_SETOR,
       SETOR.CODUNIHOS,
       SETOR.C_CUSTO
  FROM TB_MTMD_MOV_MOVIMENTACAO MOV,
       TB_CAD_MTMD_MAT_MED MATMED,
       TB_CAD_SET_SETOR CADSETOR,
       TB_SETOR SETOR,
       TB_CAD_UNI_UNIDADE UNI
 WHERE MOV.CAD_MTMD_ID             = MATMED.CAD_MTMD_ID
   AND MOV.CAD_SET_ID              = CADSETOR.CAD_SET_ID
   AND CADSETOR.CAD_SET_CD_SETOR   = SETOR.CD_SETOR
   AND CADSETOR.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
   AND SETOR.CODUNIHOS             = UNI.CAD_UNI_CD_UNID_HOSPITALAR
   AND MOV.MTMD_MOV_ID             = pMTMD_MOV_ID;
SIM                  CONSTANT NUMBER := 1;
NAO                  CONSTANT NUMBER := 0;
nSEQ_PACIENTE        NUMBER;
vSetor               VARCHAR2(5);
vUniHos              VARCHAR2(4);
vCodUnihos           NUMBER;
vCodClaDesAmb        MTM_REQ_PACIENTE.CODCLADESAMB%TYPE;
vCd_Setor            MTM_REQ_PACIENTE.CD_SETOR%TYPE;
Van_setor            MTM_REQ_PACIENTE.AN_SETOR%TYPE;
nTeste               NUMBER;
vData                DATE;
vHora                NUMBER ;
vFAT_CCI_ID          NUMBER; -- ID DE RETORNO DO FATURAMENTO - ID DO ITEM CCI
vFAT_TCO_ID          CONSTANT NUMBER := 1; -- TIPO DE COMANDA
nExisteAtendimanto   NUMBER;
nFaturou NUMBER;
--=================================================================================================
PROCEDURE PRC_MTMD_MOV_SETOR_FATURAMENTO
( 
   pATD_ATE_ID            IN  NUMBER,
   pCodUnihos             OUT MTM_REQ_PACIENTE.CODUNIHOS%TYPE,
   pCodClaDesAmb          OUT MTM_REQ_PACIENTE.CODCLADESAMB%TYPE, 
   pCd_Setor              OUT MTM_REQ_PACIENTE.CD_SETOR%TYPE,
   pVan_setor             OUT MTM_REQ_PACIENTE.AN_SETOR%TYPE
 ) IS
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_SETOR_FATURAMENTO
  *
  *    Data Criacao: 30/06/2010     Por: RICARDO COSTA
  *    Data Alteracao:              Por: 
  *         Alteração: 
  *
  *    Funcao: RETORNA SETOR ONDE DEVE SER FATURADO O PRODUTO CONSUMIDO
               ESTA FORÇANDO CLAS CONT 34
  *
  *******************************************************************/
BEGIN
   -- SO ESTA RETORNANDO PARA HEMODINAMICA
--   pCodUnihos     := 2;
     pCodClaDesAmb  := 34;
--   pCd_Setor      := 'CECI';
--   pVan_setor     := 4;
BEGIN
         SELECT SETOR.CD_SETOR,  SETOR.AN_SETOR, SETOR.CODUNIHOS
         INTO   pCd_Setor,       pVan_setor,     pCodUnihos
         FROM TB_QUARTO        QUARTO,
              TB_SETOR         SETOR,
              TB_TRANSFERENCIA TRANSF
         WHERE TRANSF.NR_SEQINTER  = pATD_ATE_ID 
         AND   QUARTO.COD_QUARTO  = TRANSF.COD_QUARTO
         AND   QUARTO.COD_LEITO   = TRANSF.COD_LEITO
         AND   QUARTO.CODUNIHOS   = TRANSF.CODUNIHOS
         AND   SETOR.CD_SETOR     = QUARTO.CD_SETOR
         AND   SETOR.AN_SETOR     = QUARTO.AN_SETOR
         AND   SETOR.CODUNIHOS    = QUARTO.CODUNIHOS
         AND   (TRANSF.HORA_SAIDA IS NULL AND TRANSF.DT_SAIDA IS NULL)
         AND ROWNUM = 1;       
      EXCEPTION WHEN NO_DATA_FOUND THEN        
         FOR ULTIMA IN (
            SELECT SETOR.CD_SETOR,  SETOR.AN_SETOR, SETOR.CODUNIHOS
            FROM TB_QUARTO        QUARTO,
                 TB_SETOR         SETOR,
                 TB_TRANSFERENCIA TRANSF
            WHERE TRANSF.NR_SEQINTER  = pATD_ATE_ID 
            AND   QUARTO.COD_QUARTO  = TRANSF.COD_QUARTO
            AND   QUARTO.COD_LEITO   = TRANSF.COD_LEITO
            AND   QUARTO.CODUNIHOS   = TRANSF.CODUNIHOS
            AND   SETOR.CD_SETOR     = QUARTO.CD_SETOR
            AND   SETOR.AN_SETOR     = QUARTO.AN_SETOR
            AND   SETOR.CODUNIHOS    = QUARTO.CODUNIHOS
           ORDER BY  TRANSF.DT_SAIDA DESC )
           LOOP
              pCd_Setor  := ULTIMA.CD_SETOR;              
              pVan_setor := ULTIMA.AN_SETOR;
              pCodUnihos := ULTIMA.CODUNIHOS; 
              EXIT;            
           END LOOP;
        END;
END PRC_MTMD_MOV_SETOR_FATURAMENTO;
--=================================================================================================
FUNCTION ATENDIMENTO_LEGADO
( 
  pNR_SEQINTER IN TB_INTERNADO.NR_SEQINTER%TYPE
) RETURN NUMBER IS
pRETORNO NUMBER := 0;
BEGIN
   pRETORNO := 0;
   BEGIN
      SELECT 1
      INTO pRETORNO
      FROM TB_INTERNADO
      WHERE NR_SEQINTER = pNR_SEQINTER;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      pRETORNO := 0;
   END;
   RETURN pRETORNO;
END ATENDIMENTO_LEGADO;
--=================================================================================================
FUNCTION ATENDIMENTO_SGS
( 
  pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE
) RETURN NUMBER IS
pRETORNO NUMBER := 0;
BEGIN
   pRETORNO := 0;
   BEGIN
      SELECT 1
      INTO pRETORNO
      FROM TB_ATD_ATE_ATENDIMENTO ATE
      WHERE ATE.ATD_ATE_ID   = pATD_ATE_ID;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      pRETORNO := 0;
   END;
   RETURN pRETORNO;
END ATENDIMENTO_SGS;
--=================================================================================================
--###### INICIO DA PROCEDURE ######################################################################
BEGIN
  FOR vrecMOVIMENTO IN MOVFAT_CUR LOOP    
    IF (pACAO = 0) THEN --Inclusão
       nFaturou := 0;
      --==================================================================================================================
      -- INICIO FATURAMENTO LEGADO
      --==================================================================================================================                
      -- VERIFICA SE EXISTE ATENDIMENTO NO LEGADO
      IF ( ATENDIMENTO_LEGADO(vrecMOVIMENTO.ATD_ATE_ID)=SIM  ) THEN
         IF ( vrecMOVIMENTO.MTMD_MOV_DATA_FATURAMENTO IS NULL  ) THEN
            BEGIN
            PRC_MTMD_FAT_DATA_FATURAMENTO(vrecMOVIMENTO.ATD_ATE_ID, 
                                          vrecMOVIMENTO.cad_uni_id_unidade ,
                                          vrecMOVIMENTO.cad_lat_id_local_atendimento  ,
                                          vrecMOVIMENTO.cad_set_id  ,
                                          vData, 
                                          vHora  );
            EXCEPTION WHEN OTHERS THEN
               RAISE_APPLICATION_ERROR(-20100,' FAT ON LINE - DT FAT '||SQLERRM);
            END;      
         ELSE
            vData := vrecMOVIMENTO.mtmd_mov_data_faturamento;
            vHora := vrecMOVIMENTO.mtmd_mov_hora_faturamento;
         END IF;
         IF ( vData IS NULL ) THEN
           vData := SYSDATE;
           -- NULL;
         END IF;
         BEGIN
         PRC_MTMD_MOV_INTERNADO_I(vrecMOVIMENTO.ATD_ATE_ID, pMTMD_MOV_ID, vrecMOVIMENTO.Cad_Mtmd_Id, nSEQ_PACIENTE);
         EXCEPTION WHEN OTHERS THEN
           RAISE_APPLICATION_ERROR(-20100,' ERRO MOV INT '||' SEQ PAC '||TO_CHAR(nSEQ_PACIENTE)||SQLERRM);
         END;
         IF (  vrecMOVIMENTO.Atd_Ate_Tp_Paciente = 'I' AND vrecMOVIMENTO.Codunihos = 6 ) THEN
            PRC_MTMD_MOV_SETOR_FATURAMENTO( vrecMOVIMENTO.Atd_Ate_Id,                                         
                                            vCodUnihos,
                                            vCodClaDesAmb,
                                            vCd_Setor,
                                            Van_setor );
         ELSE
            vCodUnihos    := vrecMOVIMENTO.Codunihos;
            vCodClaDesAmb := vrecMOVIMENTO.c_Custo;
            vCd_Setor     := vrecMOVIMENTO.Cd_Setor;
            Van_setor     := vrecMOVIMENTO.An_Setor;
         END IF;                                         
         --Inclui uma requisição (movimentação) na tabela
         --onde o faturamento busca informações.
         IF ( nSEQ_PACIENTE < 8999 ) THEN
            BEGIN
            INSERT INTO HOSPITAL.MTM_REQ_PACIENTE(nr_seqinter,
                                         nseq_pac,
                                         cd_matricula,
                                         codreq,
                                         dt_pedido,
                                         codcladesamb,
                                         cd_setor,
                                         an_setor,
                                         codunihos,
                                         pedido_fechado,
                                         pedido_atendido,
                                         pedido_administrado,
                                         in_impresso,
                                         in_emissao_conta)
                                         VALUES
                                         (vrecMOVIMENTO.ATD_ATE_ID,
                                          nSEQ_PACIENTE,
                                          99999,
                                          1,
                                          vData,                                       
                                          vCodClaDesAmb,
                                          vCd_Setor,
                                          Van_setor,
                                          vCodUnihos,
                                          1,
                                          1,
                                          1,
                                          'S',
                                          'N');
            exception when dup_val_on_index then
              IF ( nSEQ_PACIENTE = 9000 ) THEN
                 NULL;
              ELSE
                 RAISE_APPLICATION_ERROR(-20100, 'CHAVE DUPLICADA SEQ PAC '||TO_CHAR(nSEQ_PACIENTE)||
                                                 ' MOV '||TO_CHAR(pMTMD_MOV_ID)||
                                                 ' PRODUTO '||TO_CHAR(vrecMOVIMENTO.Cad_Mtmd_Id)
                                                 );        
              END IF;
              NULL;  -- ELE JA PODE EXISTIR NO LEGADO
              WHEN OTHERS THEN         
                PRC_ENVIA_EMAIL ('ricardo.costa@anacosta.com.br', -- origem
                                 'ricardo.costa@anacosta.com.br', --destino
                                 null  ,-- pemail_copia
                                 'FATURAMENTO ITEM TIPO INTEIRO ',-- pemail_assunto 
                                 'A Sequencia :'||TO_CHAR(vrecMOVIMENTO.ATD_ATE_ID)||
                                 ' CAUSOU UM ERRO TENTANDO FATURAR O ITEM '||vrecMOVIMENTO.CAD_MTMD_CODMNE||' '||
                                 ' NA TABELA PRINCIPAL MTM_REQ_PACIENTE ERRO '||SQLERRM);
               RAISE_APPLICATION_ERROR(-20000,' ERRO TENTANDO INSERIR MTM_REQ_PACIENTE '||SQLERRM);
               NULL;
            end;
            --Verifica se o mat/med é fracionado
            IF (vrecMOVIMENTO.CAD_MTMD_TPMOV_ID = 2 AND vrecMOVIMENTO.CAD_MTMD_SUBTP_ID = 14) THEN
               --Inclui um item da requisição (movimentação) nas tabelas
               --onde o faturamento busca informações.
               BEGIN         
              PRC_MATMED_FRACIONADO(vrecMOVIMENTO.ATD_ATE_ID,          
                                    nSEQ_PACIENTE,
                                    vrecMOVIMENTO.CAD_MTMD_CODMNE,    
                                    vrecMOVIMENTO.MTMD_MOV_QTDE,
                                    NULL,                          
                                    NULL,
                                    'N',
                                    NULL,
                                    NULL,
                                    'S');
              EXCEPTION WHEN NO_DATA_FOUND THEN
                  RAISE_APPLICATION_ERROR(-20100,'ERRO PRC_MATMED_FRACIONADO ' || SQLERRM);
              WHEN OTHERS THEN
                  RAISE_APPLICATION_ERROR(-20100,' ONLINE FRACIONADO '||SQLERRM);
              END;
            ELSE
               --Inclui um item da requisição (movimentação) nas tabelas
               --onde o faturamento busca informações.
               BEGIN
               PRC_MATMED(vrecMOVIMENTO.ATD_ATE_ID,
                          nSEQ_PACIENTE,
                          vrecMOVIMENTO.CAD_MTMD_CODMNE,
                          vrecMOVIMENTO.MTMD_MOV_QTDE,
                          NULL,
                          NULL,
                          'N',
                          NULL,
                          NULL);
              EXCEPTION WHEN NO_DATA_FOUND THEN
                  RAISE_APPLICATION_ERROR(-20100,'ERRO PRC_MATMED NO_DATA_FOUND ' || vrecMOVIMENTO.ATD_ATE_ID || ' ' || nSEQ_PACIENTE || ' ' || vrecMOVIMENTO.CAD_MTMD_CODMNE || ' ' || vrecMOVIMENTO.MTMD_MOV_QTDE || ' ' || SQLERRM);
              WHEN OTHERS THEN
                PRC_ENVIA_EMAIL ('ricardo.costa@anacosta.com.br', -- origem
                                 'ricardo.costa@anacosta.com.br', --destino
                                 null  ,-- pemail_copia
                                 'FATURAMENTO ITEM TIPO INTEIRO ',-- pemail_assunto 
                                 'A Sequencia :'||TO_CHAR(vrecMOVIMENTO.ATD_ATE_ID)||
                                 ' CAUSOU UM ERRO TENTANDO FATURAR O ITEM '||vrecMOVIMENTO.CAD_MTMD_CODMNE||' '||
                                 ' ERRO '||SQLERRM);
                RAISE_APPLICATION_ERROR(-20100,' ON LINE TP INTEIRO '||SQLERRM);                              
                NULL;
              END;
            END IF; -- FIM TESTE INTEIRO FRACIONADO
            -- ATUALIZA DATA DE FATURAMENTO NO MOVIMENTO
            UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
            MTMD_MOV_DATA_FATURAMENTO = vData,
            MTMD_MOV_HORA_FATURAMENTO = vHora,
            MTMD_MOV_FL_FATURADO      = 1
            WHERE MTMD_MOV_ID = pMTMD_MOV_ID;
         ELSIF ( nSEQ_PACIENTE = 8999  ) THEN
           PRC_ENVIA_EMAIL ('ricardo.costa@anacosta.com.br', -- origem
                            'ricardo.costa@anacosta.com.br', --destino
                             null  ,-- pemail_copia    IN varchar2,
                            'Sequencia de Faturamento',-- pemail_assunto  IN varchar2,
                            'A Sequencia :'||TO_CHAR(vrecMOVIMENTO.ATD_ATE_ID)||' acabou de gerar a requisição de número 9999 '); 
         END IF; -- FIM TESTE 9999
         nFaturou := 1;
      END IF; -- FIM DA VERIFICAÇÃO SE EXISTE ATENDIMENTO NO LEGADO
      --==================================================================================================================
      -- FIM FATURAMENTO LEGADO
      --==================================================================================================================            
      --==================================================================================================================
      -- INICIO FATURAMENTO SGS
      --==================================================================================================================            
      /*
      IF ( ATENDIMENTO_SGS(vrecMOVIMENTO.ATD_ATE_ID)=SIM)  THEN
          RAISE_APPLICATION_ERROR(-20000,' ATE '||TO_CHAR(vrecMOVIMENTO.ATD_ATE_ID)||
                                         ' MNE '||vrecMOVIMENTO.CAD_MTMD_CODMNE||
                                         ' DT  '||TO_CHAR(vrecMOVIMENTO.Mtmd_Mov_Data)||
                                         ' TIPO '||TO_CHAR(vFAT_TCO_ID)
                                 );
         BEGIN
         PRC_FAT_CALCULA_ITEM( vrecMOVIMENTO.MTMD_MOV_ID, -- pATS_ATE_ID,   -- REQUISICAO LAB/LDO SADT/MOV MATMED
                               vrecMOVIMENTO.ATD_ATE_ID,   -- ATENDIMENTO/ NO SADT SERÁ: ATS_ATE_CD_INTLIB
                               NULL, -- pCAD_PRD_ID,    -- IdtProduto     
                               NULL, -- pCAD_PRD_CD_CODIGO,    -- ATO MEDICO
                               vrecMOVIMENTO.CAD_MTMD_CODMNE,
                               vrecMOVIMENTO.MTMD_MOV_DATA, -- pDATA_REALIZACAO
                               'I', -- pACAO
                               9122, -- 8642, -- pSEG_USU_ID_USUARIO 9122 USUARIO INTERFACE MATMED
                               vFAT_TCO_ID, -- pFAT_TCO_ID TIPO DE COMANDA
                               vrecMOVIMENTO.MTMD_MOV_QTDE, -- QTDE CONSUMIDA
                               vrecMOVIMENTO.TIS_MED_CD_TABELAMEDICA, -- TABELA TISS
                               vFAT_CCI_ID            -- RETORNO DO ITEM CRIADO NA CONTA
                              ); 
                              NULL;
         EXCEPTION WHEN OTHERS THEN
            -- IGNORA QUALQUER ERRO
            -- RAISE_APPLICATION_ERROR(-20000,SQLERRM);
            NULL;
         END;
         nFaturou := 1;
      END IF;*/
      IF ( nFATUROU = 0 ) THEN
                PRC_ENVIA_EMAIL ('ricardo.costa@anacosta.com.br', -- origem
                                 'ricardo.costa@anacosta.com.br', --destino
                                 null  ,-- pemail_copia
                                 'TENTATIVA DE FATURAMENTO ',-- pemail_assunto 
                                 'A Sequencia :'||TO_CHAR(vrecMOVIMENTO.ATD_ATE_ID)||
                                 ' TENTOU FATURAR O ITEM '||vrecMOVIMENTO.CAD_MTMD_CODMNE||' MAS NÃO FOI ENCONTRADO ATENDIMENTO ');
         RAISE_APPLICATION_ERROR(-20100,' NAO FOI ENCONTRADO O ATENDIMENTO DESTE PACIENTE, SE FOR RESERVA OU AGENDAMENTO, AINDA NÃO FOI CONFIRMADO OU A SEQUENCIA ESTA ERRADA ');
      END IF;
      --==================================================================================================================      
      -- FIM FATURAMENTO SGS
      --==================================================================================================================      
    ELSIF (pACAO = 1) THEN  -- EXCLUSÃO 
      --==================================================================================================================
      -- INICIO FATURAMENTO LEGADO
      --==================================================================================================================                
       IF ( ATENDIMENTO_LEGADO(vrecMOVIMENTO.ATD_ATE_ID)=SIM  ) THEN
          BEGIN
                SELECT MOVINT.SEQ_PACIENTE
                INTO   nSEQ_PACIENTE
                FROM  TB_MTMD_MOV_INTERNADO MOVINT
                WHERE MOVINT.ATD_ATE_ID  = vrecMOVIMENTO.ATD_ATE_ID
                AND   MOVINT.MTMD_MOV_ID = vrecMOVIMENTO.MTMD_MOV_ID 
                AND   MOVINT.CAD_MTMD_ID = vrecMOVIMENTO.Cad_Mtmd_Id
                AND   ROWNUM = 1;            
          EXCEPTION WHEN NO_DATA_FOUND THEN
             -- RAISE_APPLICATION_ERROR(-20000,'ERRO TB_MTMD_MOV_INTERNADO '||TO_CHAR(vrecMOVIMENTO.ATD_ATE_ID)||' '||TO_CHAR(vrecMOVIMENTO.MTMD_MOV_ID)||' '||TO_CHAR(vrecMOVIMENTO.Cad_Mtmd_Id) || SQLERRM);
             NULL;
          WHEN OTHERS THEN
             RAISE_APPLICATION_ERROR(-20100,' EXCLUSAO FATURAR ON LINE ' || SQLERRM);          
          END;
          BEGIN
             SELECT (PPRESC.qtd_req - vrecMOVIMENTO.MTMD_MOV_QTDE)
             INTO nTeste
             FROM HOSPITAL.MTM_REQ_PACIENTE_PRESC PPRESC
             WHERE PPRESC.NR_SEQINTER = vrecMOVIMENTO.ATD_ATE_ID
             AND   PPRESC.NSEQ_PAC      = nSEQ_PACIENTE
             AND   PPRESC.CODMNEMAT     = vrecMOVIMENTO.CAD_MTMD_CODMNE;
             IF ( nTeste > 0 )  THEN
                UPDATE HOSPITAL.MTM_REQ_PACIENTE_PRESC SET
                qtd_req = qtd_req - vrecMOVIMENTO.MTMD_MOV_QTDE
                WHERE NR_SEQINTER = vrecMOVIMENTO.ATD_ATE_ID
                AND   NSEQ_PAC      = nSEQ_PACIENTE
                AND   CODMNEMAT     = vrecMOVIMENTO.CAD_MTMD_CODMNE;                
             ELSIF ( nTeste = 0 ) THEN
                DELETE HOSPITAL.MTM_REQ_PACIENTE_PRESC
                WHERE NR_SEQINTER = vrecMOVIMENTO.ATD_ATE_ID
                AND   NSEQ_PAC      = nSEQ_PACIENTE
                AND   CODMNEMAT     = vrecMOVIMENTO.CAD_MTMD_CODMNE;         
                BEGIN
                   DELETE HOSPITAL.MTM_REQ_PACIENTE_ITEM PITEM
                   WHERE PITEM.NR_SEQINTER = vrecMOVIMENTO.ATD_ATE_ID
                   AND PITEM.NSEQ_PAC      = nSEQ_PACIENTE
                   AND PITEM.CODMNEMAT     = vrecMOVIMENTO.CAD_MTMD_CODMNE;             
                EXCEPTION WHEN NO_DATA_FOUND THEN
                   NULL;
                WHEN OTHERS THEN             
                  RAISE_APPLICATION_ERROR(-20100,' EXCLUSÃO, REQ PACIENTE ITEM '||SQLERRM);
                END;    
                BEGIN            
                   DELETE HOSPITAL.MTM_REQ_PACIENTE PAC
                   WHERE PAC.NR_SEQINTER = vrecMOVIMENTO.ATD_ATE_ID
                   AND   PAC.NSEQ_PAC    = nSEQ_PACIENTE;
                EXCEPTION WHEN NO_DATA_FOUND THEN
                     RAISE_APPLICATION_ERROR(-20000,' EXCLUSÃO, ITEM NÃO ENCONTRADO NA ITEM');          
                     NULL;
                WHEN OTHERS THEN
                             SELECT COUNT(1)
                             INTO nTeste
                             FROM HOSPITAL.MTM_REQ_PACIENTE_ITEM PITEM
                             WHERE PITEM.NR_SEQINTER = vrecMOVIMENTO.ATD_ATE_ID
                             AND PITEM.NSEQ_PAC      = nSEQ_PACIENTE
                             AND PITEM.CODMNEMAT     = vrecMOVIMENTO.CAD_MTMD_CODMNE;
                   IF nTeste > 0 then
                      RAISE_APPLICATION_ERROR(-20100,' EXCLUINDO PACIENTE FATURAMENTO '||SQLERRM);
                   end if;
                END;                                                                   
             ELSIF ( nTeste < 0 ) THEN
                RAISE_APPLICATION_ERROR(-20000,' EXCLUSÃO, PROBLEMA NA  PRESC');          
             END IF;
          EXCEPTION WHEN NO_DATA_FOUND THEN
                NULL;
          WHEN OTHERS THEN
               RAISE_APPLICATION_ERROR(-20100,' EXCLUSÃO, PRESC '||SQLERRM);          
          END;
/*
*/          
          BEGIN
             -- MARCA MOVIMENTO COMO EXCLUIDO
             PRC_MTMD_MOV_INTERNADO_D( vrecMOVIMENTO.ATD_ATE_ID, nSEQ_PACIENTE);             
          EXCEPTION WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20100,SQLERRM);
          END;
       -- END IF; -- FIM TESTE ATENDIMENTO LEGADO
      --==================================================================================================================
      -- FIM FATURAMENTO LEGADO
      --==================================================================================================================            
      --==================================================================================================================
      -- INICIO FATURAMENTO SGS
      --==================================================================================================================            
      -- ELSIF ( ATENDIMENTO_SGS(vrecMOVIMENTO.ATD_ATE_ID)=SIM)  THEN      
      --   NULL;
         nFATUROU := 1;
      END IF;
      IF ( nFATUROU = 0 ) THEN
                PRC_ENVIA_EMAIL ('ricardo.costa@anacosta.com.br', -- origem
                                 'ricardo.costa@anacosta.com.br', --destino
                                 'andre.monaco@anacosta.com.br;maria.santos@anacosta.com.br',-- pemail_copia
                                 'TENTATIVA DE EXCLUSÃO DO FATURAMENTO ',-- pemail_assunto 
                                 'A Sequencia :'||TO_CHAR(vrecMOVIMENTO.ATD_ATE_ID)||
                                 ' TENTOU EXCLUIR O ITEM '||vrecMOVIMENTO.CAD_MTMD_CODMNE||' MAS NÃO FOI ENCONTRADO ATENDIMENTO ');
      END IF;
      --==================================================================================================================      
      -- FIM FATURAMENTO SGS
      --==================================================================================================================       
    ELSE
       RAISE_APPLICATION_ERROR(-20100,' NAO EXISTE NENHUMA AÇÃO ');    
    END IF; -- FIM TESTE ACAO
  END LOOP;
END PRC_MTMD_MOV_FATURAR_ONLINE;
