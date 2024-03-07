CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_ESTOQUE_TRANSF
(  pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
   pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type default null,
   pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
   pMTMD_REQ_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_REQ_ID%type,
   -- ENTRADA
   pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
   pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
   pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
   pCAD_MTMD_TPMOV_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%type,
   pCAD_MTMD_SUBTP_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type,
   -- SAIDA
   pCAD_UNI_ID_UNIDADE_S         IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
   pCAD_LAT_ID_LOCAL_S           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
   pCAD_SET_ID_S                 IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
   pCAD_MTMD_TPMOV_S             IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%type,
   pCAD_MTMD_SUBTP_S             IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type,
   pMTMD_ESTLOC_QTDE             IN TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type,
   pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type default NULL,
   pATD_ATE_TP_PACIENTE          IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_TP_PACIENTE%type default NULL,
   pMTMD_MOV_FL_FINALIZADO       IN TB_MTMD_MOV_MOVIMENTACAO.mtmd_mov_fl_finalizado%TYPE default NULL,
   pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
   pNewIdt                       OUT integer
)
IS
/***********************************************************************************************
*    Procedure: PRC_MTMD_MOV_ESTOQUE_BAIXA
*
*    Data Criacao:  06/2009      Por: Ricardo Costa
*    Data Alteracao:  16/06/2010   Por: RICARDO COSTA
*         Descric?o: Indicac?o de referencia entre as transferencias
*    Data Alteracao:  17/06/2010   Por: RICARDO COSTA
*         Descric?o: VERIFICAC?O SE SETOR DE DESTINO TEM ACESSO AO PRODUTO SENDO MOVIMENTADO
*    Data Alteracao: 06/08/2010      Por: RICARDO cOSTA
*         Descric?o: ATUALIZADO MIGRA2
*    Data Alteracao:  06/08/2010   Por: RICARDO COSTA
*         Descric?o: RETIRADA VERIFICAC?O DA RETORNA FILIAL, A FILIAL DEVE SER COTROLADA NAS PROCEDURES
                     DE ENTRADA/SAIDA
                     RETIRDA PRC_MTMD_ESTOQUE_DE_CONSUMO A VERIFICAC?O TEM QUE ACONTECER NAS PROCEDURES
                     DE ENTRADA/SAIDA
                     ** RETIREI AS PROCEDURES POIS ESTAVA SENDO REDUNDANTE NA VERIFICAC?O
*    Data Alteracao: 29/11/2011      Por: Andre S. Monaco
*         Descric?o: Registrar movimentac?es durante inventario, quando um dos setores ainda n?o teve inventario
*    Data Alteracao: 27/03/2012      Por: Andre S. Monaco
*         Descric?o: Ultima alterac?o (29/11/11) comentada
*    Data Alteracao: 08/07/2013      Por: Andre S. Monaco
*         Descric?o: Quando estoque unico origem, alimentar HAC,
*                    Quando estoque unico destino, alimentar CE (EU)
*    Data Alteracao: 09/02/2015      Por: Andre S. Monaco
*         Descricao: Enviar parametro pMTMD_ID_ORIGINAL na PRC_MTMD_MOV_ENTRADA_UNIDADE
*                    para atualizar percentual de consumo
*
*    Funcao: MOVIMENTO DE TRANSFERENCIA ENTRE LOCAIS DE ESTOQUES
*************************************************************************************************/
-- PARAPROCESSO        EXCEPTION;
-- IdtLote             TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type;
vMTMD_ID_ORIGINAL   NUMBER := NULL;
nFilialOrigem       NUMBER := pCAD_MTMD_FILIAL_ID;
nFilialDestino      NUMBER;
nEstoqueUnicoOrigem  NUMBER;
nEstoqueUnicoDestino NUMBER;
nIdEntrada          integer;
nQtdeTransf         NUMBER := 0;
nSetorFarmacia      NUMBER;

NAO        CONSTANT NUMBER :=0;
nTemAcesso NUMBER;
vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
BEGIN
   IF (pCAD_MTMD_SUBTP_ID != 58 AND pCAD_MTMD_FILIAL_ID != 5) THEN --58 = ENTRADA TRANSFERENCIA PACIENTE / LIBERAR CONSIGNADO
     IF (pMTMD_REQ_ID IS NULL) THEN
     -- VERIFICA SE SETOR DE ENTRADA TEM ACESSO AO PRODUTO SENDO TRANSFERIDO
       PRC_MTMD_SETOR_ACESSO( pCAD_LAT_ID_LOCAL_ATENDIMENTO, pCAD_UNI_ID_UNIDADE,
                              pCAD_SET_ID,                   pCAD_MTMD_ID,
                              nTemAcesso );
       IF ( nTemAcesso = 0  ) THEN
          RAISE_APPLICATION_ERROR( PKG_MTMD_CONSTANTES.ERR_SEM_ACESSO ,' SETOR DE DESTINO N?O TEM ACESSO AO MATERIAL OU MEDICAMENTO SENDO TRANSFERIDO ');
       END IF;
     END IF;
   END IF;
   SELECT NVL(MAX(MS.MTMD_ESTOQUE_UNIFICADO_HAC), 0)
     INTO nEstoqueUnicoDestino
     FROM TB_MTMD_MATMED_SETOR MS WHERE MS.CAD_SET_ID = pCAD_SET_ID;
   SELECT NVL(MAX(MS.MTMD_ESTOQUE_UNIFICADO_HAC), 0)
     INTO nEstoqueUnicoOrigem
     FROM TB_MTMD_MATMED_SETOR MS WHERE MS.CAD_SET_ID = pCAD_SET_ID_S;

   SELECT NVL(SUM(S.CAD_SET_SETOR_FARMACIA),0)
     INTO nSetorFarmacia
     FROM TB_CAD_SET_SETOR S
    WHERE S.CAD_SET_SETOR_FARMACIA = pCAD_SET_ID AND ROWNUM = 1;


   IF (nFilialOrigem != 4 AND nFilialOrigem != 5 AND --CE / Consignado
       (nEstoqueUnicoOrigem = 1 OR nEstoqueUnicoDestino = 1)) THEN
      nFilialDestino := 1; --HAC
   ELSIF (nFilialOrigem = 4 AND pMTMD_REQ_ID IS NOT NULL) THEN --Estorno de CE
      nFilialDestino := 1; --HAC
   ELSIF (nFilialOrigem = 4 AND (nSetorFarmacia <> 0 AND nSetorFarmacia = pCAD_SET_ID)) THEN --Quando CE transferir sempre para o HAC da Farmacia
      nFilialDestino := 1; --HAC
   ELSE
      nFilialDestino := pCAD_MTMD_FILIAL_ID;
   END IF;
   PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE,
                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                pCAD_SET_ID,
                                pCAD_MTMD_FILIAL_ID, -- USAR VALOR PASSADO COMO PARAMETRO
                                vUNIDADE_ESTOQUE_CONSUMO,
                                vLOCAL_ESTOQUE_CONSUMO,
                                vSETOR_ESTOQUE_CONSUMO
                               );
   BEGIN
      SELECT MATMED.CAD_MTMD_ID
        INTO vMTMD_ID_ORIGINAL
        FROM TB_MTMD_PEDIDO_PADRAO PADRAO,
             TB_MTMD_PEDIDO_PADRAO_ITENS ITENS,
             TB_CAD_MTMD_MAT_MED MATMED
        WHERE ITENS.MTMD_PEDPAD_ID                   = PADRAO.MTMD_PEDPAD_ID
        AND   ITENS.CAD_MTMD_ID                      = MATMED.CAD_MTMD_ID
        AND   PADRAO.CAD_SET_ID                      = vSETOR_ESTOQUE_CONSUMO
        AND   PADRAO.CAD_MTMD_FILIAL_ID              = nFilialDestino
        AND   FNC_MTMD_PRINCIPIO_ATIVO(pCAD_MTMD_ID)!= 0
        AND   ITENS.CAD_MTMD_ID                     != pCAD_MTMD_ID
        AND   FNC_MTMD_PRINCIPIO_ATIVO(pCAD_MTMD_ID) = FNC_MTMD_PRINCIPIO_ATIVO(MATMED.CAD_MTMD_ID) AND ROWNUM = 1;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      NULL;
   END;
   nQtdeTransf := pMTMD_ESTLOC_QTDE;
   -- REALIZA A ENTRADA DO PRODUTO NO ESTOQUE
   PRC_MTMD_MOV_ENTRADA_UNIDADE( pCAD_MTMD_ID,
                                 pMTMD_LOTEST_ID,
                                 nFilialDestino,
                                 pMTMD_REQ_ID,
                                 pCAD_UNI_ID_UNIDADE,
                                 pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 pCAD_SET_ID,
                                 pCAD_MTMD_TPMOV_ID,
                                 pCAD_MTMD_SUBTP_ID,
                                 nQtdeTransf,
                                 pATD_ATE_ID,
                                 NULL, -- pATD_ATE_TP_PACIENTE,
                                 1, --pMTMD_MOV_FL_FINALIZADO,
                                 pSEG_USU_ID_USUARIO,
                                 vMTMD_ID_ORIGINAL,
                                 nIdEntrada);
   PRC_MTMD_MOV_ESTOQUE_BAIXA(pCAD_MTMD_ID,
                               pMTMD_REQ_ID,
                               pMTMD_LOTEST_ID,
                               nFilialOrigem,
                               pCAD_UNI_ID_UNIDADE_S,
                               pCAD_LAT_ID_LOCAL_S,
                               pCAD_SET_ID_S,
                               nQtdeTransf,
                               pATD_ATE_ID,
                               NULL, --pATD_ATE_TP_PACIENTE,
                               pCAD_MTMD_TPMOV_S,
                               pCAD_MTMD_SUBTP_S,
                               NAO, --pCAD_MTMD_FL_FRACIONA,
                               pSEG_USU_ID_USUARIO,
                               NULL, -- DT_FAT
                               NULL, --HR_FAT
                               pNewIdt);
    -- SE SETOR DE ENTRADA JA TEVE INVENTARIO E O DE SAIDA N?O,
    -- OU VICE VERSA, INSERIR NA TABELA DE REGISTROS
    -- DE MOVIMENTAC?ES DURANTE INVENTARIO
    /*IF ((FNC_MTMD_SETOR_INVENTARIADO(pCAD_SET_ID, nFilial, 0) = 1 AND
         FNC_MTMD_SETOR_INVENTARIADO(pCAD_SET_ID_S, nFilial, 0) = 0) OR
        (FNC_MTMD_SETOR_INVENTARIADO(pCAD_SET_ID, nFilial, 0) = 0 AND
         FNC_MTMD_SETOR_INVENTARIADO(pCAD_SET_ID_S, nFilial, 0) = 1)) THEN
         INSERT INTO TB_MTMD_MOV_INVENTARIO VALUES( pCAD_MTMD_ID,
                                                    nFilial,
                                                    pCAD_SET_ID,
                                                    SYSDATE,
                                                    pCAD_MTMD_TPMOV_ID,
                                                    pCAD_MTMD_SUBTP_ID,
                                                    nQtdeTransf,
                                                    nIdEntrada);
         INSERT INTO TB_MTMD_MOV_INVENTARIO VALUES( pCAD_MTMD_ID,
                                                    nFilial,
                                                    pCAD_SET_ID_S,
                                                    SYSDATE,
                                                    pCAD_MTMD_TPMOV_S,
                                                    pCAD_MTMD_SUBTP_S,
                                                    nQtdeTransf,
                                                    pNewIdt);
    END IF;   */
    -- ATUALIZA REFENRENCIA DA MOVIMENTAC?O DE BAIXA APONTANDO PARA A  MOVIMENTAC?OD E ENTRADA
    UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
    MTMD_MOV_ID_REF = pNewIdt
    WHERE MTMD_MOV_ID = nIdEntrada;
    -- ATUALIZA REFERENCIA DA MOVIMENTAC?O DE ENTRADA APONTANDO PARA A MOVIMENTAC?O DE BAIXA
    UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
    MTMD_MOV_ID_REF = nIdEntrada
    WHERE MTMD_MOV_ID = pNewIdt;
     -- PARA BAIXA N?O EXISTE INSERT, SE PRODUTO N?O EXISTIR NO ESTOQUE PARA O PROCESSO
     --nConsumoOutros := 0;
     /*IF ( pCAD_MTMD_SUBTP_S IN (3,20) ) THEN -- 20 = ACERTO 3=TRANSFERENCIA
         nConsumoOutros := pMTMD_ESTLOC_QTDE;
     END IF;*/

    PRC_MTMD_EMAIL_FARM_ALMOX(pCAD_MTMD_FILIAL_ID, pCAD_SET_ID_S, pCAD_SET_ID, pCAD_MTMD_ID, nQtdeTransf, pSEG_USU_ID_USUARIO);

END PRC_MTMD_MOV_ESTOQUE_TRANSF;