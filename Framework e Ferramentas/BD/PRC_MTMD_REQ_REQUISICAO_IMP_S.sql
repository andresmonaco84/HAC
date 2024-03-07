CREATE OR REPLACE PROCEDURE PRC_MTMD_REQ_REQUISICAO_IMP_S
   (
     pMTMD_REQ_FL_STATUS           IN TB_MTMD_REQ_REQUISICAO.MTMD_REQ_FL_STATUS%type DEFAULT NULL,
     pMTM_TIPO_REQUISICAO          IN TB_MTMD_REQ_REQUISICAO.MTM_TIPO_REQUISICAO%type DEFAULT NULL,
     pCAD_SET_ID                   IN TB_CAD_SET_SETOR.CAD_SET_ID%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pMTMD_FL_PENDENTE             IN TB_MTMD_REQ_REQUISICAO.MTMD_FL_PENDENTE%type DEFAULT NULL,
     pSO_ATD_DOMICILIAR            IN NUMBER DEFAULT NULL, --0 ou 1
     io_cursor                     OUT PKG_CURSOR.t_cursor
   )  IS
  /********************************************************************
  *    Procedure: PRC_MTMD_REQ_REQUISICAO_IMP_S
  *
  *    Data Criacao:   01/2010     Por: RICARDO COSTA
  *    Data Alteracao:  21/06/2010  Por: RICARDO COSTA
  *    Data Alteracao:  10/11/2011  Por: Andre Souza Monaco
  *         Alteracao:  Coloquei a query no padr?o de string dinamica
  *    Data Alteracao:  07/10/2014  Por: Andre Souza Monaco
  *         Alteracao:  Add. param. pSO_ATD_DOMICILIAR
  *    Data Alteracao:  23/10/2015  Por: Andre Souza Monaco
  *         Alteracao:  Add. kit na query
  *    Data Alteracao:  20/07/2018  Por: Andre
  *         Alterac?o:  Quando Pedido Padrao verificar se nao e da Farmacia (novo campo Pedido Padrao)
  *                     Quando Pedido Personalizado s? trazer de acordo com novo campo Farmacia da tabela Setor
  *                     Atd. Domiciliar e CE tamb?m deverao sair apenas da farmacia
  *
  *    Funcao: Lista Requisic?es para impress?o no centro de dispensac?o
  *******************************************************************/
 AlmoxCentral NUMBER := 0;
 Farmacia     NUMBER := 0;
 Manutencao   NUMBER := 0;
 v_cursor                       PKG_CURSOR.t_cursor;
 vStatusRecebido                NUMBER DEFAULT NULL;
 V_WHERE  varchar2(5000);
 V_SELECT  varchar2(5000);
BEGIN
   IF (pMTM_TIPO_REQUISICAO = 9) THEN
     Manutencao := 1;
   ELSIF (pMTM_TIPO_REQUISICAO IN (PKG_MTMD_CONSTANTES.REQ_IMPRESSOS,PKG_MTMD_CONSTANTES.REQ_OUTROS,6)) THEN --6 = HIGIENIZACAO
     AlmoxCentral := 1;
   ELSE
     AlmoxCentral := 1; -- por padrao assume que e o central
      -- VERIFICO SE E CENTRAL OU CENTRO DE DISPENSACAO
     BEGIN
        SELECT 0
        INTO AlmoxCentral
        FROM TB_CAD_SET_SETOR SETOR
        WHERE SETOR.CAD_SET_SETOR_ALMOX    = pCAD_SET_ID
        AND   SETOR.CAD_SET_LOCAL_ALMOX    = pCAD_LAT_ID_LOCAL_ATENDIMENTO
        AND   SETOR.CAD_SET_UNIDADE_ALMOX  = pCAD_UNI_ID_UNIDADE;
     EXCEPTION
        WHEN NO_DATA_FOUND THEN
           AlmoxCentral := 1;
        WHEN TOO_MANY_ROWS THEN
           -- RETORNOU VARIOS N?O E CENTRAL
           AlmoxCentral := 0;
     END;
     --Verifica se e farmacia
     BEGIN
        SELECT 1
          INTO Farmacia
          FROM TB_CAD_SET_SETOR SETOR
         WHERE SETOR.CAD_SET_SETOR_FARMACIA = pCAD_SET_ID
           AND ROWNUM = 1;
     EXCEPTION
        WHEN NO_DATA_FOUND THEN
           Farmacia := 0;
     END;
   END IF;
   IF ( NOT pMTMD_REQ_FL_STATUS IS NULL ) THEN
       IF ( pMTMD_REQ_FL_STATUS = 3 ) THEN -- Dispensado
          vStatusRecebido := 4;
       END IF;
   END IF;
   V_WHERE := NULL;
   IF pMTMD_REQ_FL_STATUS IS NOT NULL THEN
       V_WHERE:= V_WHERE || ' AND (REQUISICAO.MTMD_REQ_FL_STATUS = ' || pMTMD_REQ_FL_STATUS;
       IF vStatusRecebido IS NOT NULL THEN V_WHERE:= V_WHERE || ' OR REQUISICAO.MTMD_REQ_FL_STATUS = ' || vStatusRecebido; END IF;
       V_WHERE:= V_WHERE || ') ';
   END IF;
   IF pMTM_TIPO_REQUISICAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND REQUISICAO.MTM_TIPO_REQUISICAO = ' || pMTM_TIPO_REQUISICAO; END IF;
   IF pMTMD_FL_PENDENTE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND REQUISICAO.MTMD_FL_PENDENTE = ' || pMTMD_FL_PENDENTE; END IF;
   IF (Farmacia = 1 OR (pCAD_SET_ID = 61 AND pMTM_TIPO_REQUISICAO = PKG_MTMD_CONSTANTES.REQ_PERSONALIZADA)) THEN --C.C. pode ser Farmacia de Personalizado
       V_WHERE:= V_WHERE || ' AND REQUISICAO.CAD_SET_SETOR_FARMACIA = ' || pCAD_SET_ID;
   ELSIF (AlmoxCentral = 1 AND pMTM_TIPO_REQUISICAO NOT IN (PKG_MTMD_CONSTANTES.REQ_IMPRESSOS,PKG_MTMD_CONSTANTES.REQ_OUTROS,6)) THEN --6 = HIGIENIZACAO
       -- ALMOXARIFADO CENTRAL / BUSCO TODAS AS REQUISIC?ES DOS SETORES SEM CENTRO DE DISPENSAC?O
       V_WHERE:= V_WHERE || ' AND (SETOR.CAD_SET_LOCAL_ALMOX   IS NULL AND
                                   SETOR.CAD_SET_UNIDADE_ALMOX IS NULL AND
                                   SETOR.CAD_SET_SETOR_ALMOX   IS NULL AND
                                   REQUISICAO.CAD_SET_SETOR_FARMACIA IS NULL) ';
   ELSIF (AlmoxCentral = 0 AND Manutencao = 0) THEN
       -- CENTRO DE DISPENSACAO / BUSCO TODAS AS REQUISIC?ES DOS SETORES QUE S?O DESTE CENTRO DE DISPENSAC?O
       V_WHERE:= V_WHERE || ' AND (SETOR.CAD_SET_LOCAL_ALMOX         = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO ||
                                   ' AND SETOR.CAD_SET_UNIDADE_ALMOX = ' || pCAD_UNI_ID_UNIDADE ||
                                   ' AND SETOR.CAD_SET_SETOR_ALMOX   = ' || pCAD_SET_ID || ') ';
       V_WHERE:= V_WHERE || ' AND REQUISICAO.CAD_SET_SETOR_FARMACIA IS NULL ';
   END IF;
   IF (NVL(pSO_ATD_DOMICILIAR, 0) = 1) THEN
       V_WHERE:= V_WHERE || ' AND (REQUISICAO.CAD_SET_ID = 2252) ';
   ELSE
       V_WHERE:= V_WHERE || ' AND (REQUISICAO.CAD_SET_ID != 2252) ';
   END IF;
   V_WHERE  := V_WHERE || ' ORDER BY REQUISICAO.MTMD_DATA_REQUISICAO';
   V_SELECT := '
    SELECT
       REQUISICAO.MTMD_REQ_ID,
       REQUISICAO.ATD_ATE_ID,
       REQUISICAO.ATD_ATE_TP_PACIENTE,
       REQUISICAO.MTMD_REQ_FL_STATUS,
       REQUISICAO.MTMD_REQ_DT_ATUALIZACAO,
       REQUISICAO.MTM_TIPO_REQUISICAO,
       REQUISICAO.CAD_MTMD_FILIAL_ID,
       SETOR.CAD_SET_ID,
       SETOR.CAD_SET_DS_SETOR,
       UNIDADE.CAD_UNI_ID_UNIDADE,
       UNIDADE.CAD_UNI_DS_UNIDADE,
       LOC.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       LOC.CAD_LAT_DS_LOCAL_ATENDIMENTO,
       USU_REQUISICAO.SEG_USU_DS_NOME DS_USUARIO_REQUISICAO,
       USU_DISPENSACAO.SEG_USU_DS_NOME DS_USUARIO_DISPENSACAO,
       REQUISICAO.MTMD_DATA_REQUISICAO,
       REQUISICAO.MTMD_FL_PENDENTE,
       REQUISICAO.MTMD_DATA_DISPENSACAO,
       REQUISICAO.MTMD_REQ_ID_REF,
       REQUISICAO.MTMD_ID_USUARIO_REQUISICAO,
       KIT.CAD_MTMD_KIT_ID,
       KIT.CAD_MTMD_KIT_DSC,
       REQUISICAO.MTMD_REQ_FL_URGENCIA,
       REQUISICAO.CAD_SET_SETOR_FARMACIA
    FROM TB_MTMD_REQ_REQUISICAO       REQUISICAO,
         TB_CAD_SET_SETOR             SETOR,
         TB_CAD_UNI_UNIDADE           UNIDADE,
         TB_CAD_LAT_LOCAL_ATENDIMENTO LOC,
         TB_SEG_USU_USUARIO           USU_REQUISICAO,
         TB_SEG_USU_USUARIO           USU_DISPENSACAO,
         TB_CAD_MTMD_KIT              KIT
    WHERE SETOR.CAD_SET_ID                      = REQUISICAO.CAD_SET_ID
    AND   UNIDADE.CAD_UNI_ID_UNIDADE            = REQUISICAO.CAD_UNI_ID_UNIDADE
    AND   LOC.CAD_LAT_ID_LOCAL_ATENDIMENTO      = REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO
    AND   KIT.CAD_MTMD_KIT_ID(+)                = REQUISICAO.CAD_MTMD_KIT_ID
    AND   USU_REQUISICAO.SEG_USU_ID_USUARIO(+)  = REQUISICAO.MTMD_ID_USUARIO_REQUISICAO
    AND   USU_DISPENSACAO.SEG_USU_ID_USUARIO(+) = REQUISICAO.MTMD_ID_USUARIO_DISPENSACAO ';
    OPEN v_cursor FOR
    V_SELECT || V_WHERE ;
    io_cursor := v_cursor;
END;