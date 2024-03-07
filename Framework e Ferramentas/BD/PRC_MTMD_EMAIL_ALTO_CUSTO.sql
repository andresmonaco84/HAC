CREATE OR REPLACE PROCEDURE PRC_MTMD_EMAIL_ALTO_CUSTO
(
   pMTMD_REQ_ID                 IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%type,
   pCAD_MTMD_ID                 IN TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%type,
   pMTMD_REQITEM_QTD_SOLICITADA IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQITEM_QTD_SOLICITADA%type
)
is
/********************************************************************
*    Procedure: PRC_MTMD_EMAIL_ALTO_CUSTO
*
*    Data Criacao: 29/2/2012  Por: Andre
*    Data Alteracao: 20/3/2012  Por: Andre
*         Alteracao: N?o enviar e-mail para este convenios:
*                    SD01, PA__, GG05, NP01, NR14
*    Data Alteracao: 18/7/2014  Por: Andre
*         Alteracao: Adic?o de regra para inserir exigencia de autorizac?o
*                    de acordo com as parametrizac?es do convenio
*    Data Alteracao: 06/02/2015  Por: Andre
*         Alteracao: Uniao dos produtos hardcode com seus similares
*
*    Funcao: ENVIAR E-MAIL DE SOLICITAC?O DE PRODUTO DE ALTO CUSTO
*            PARA A CENTRAL DE GUIAS
*******************************************************************/
pStatusReq       TB_MTMD_REQ_REQUISICAO.MTMD_REQ_FL_STATUS%type;
pTipoReq         TB_MTMD_REQ_REQUISICAO.MTM_TIPO_REQUISICAO%type;
pID_Unidade      TB_MTMD_REQ_REQUISICAO.CAD_UNI_ID_UNIDADE%type;
pID_Local        TB_MTMD_REQ_REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
pID_Setor        TB_MTMD_REQ_REQUISICAO.CAD_SET_ID%type;
pID_USUARIO_REQ  TB_MTMD_REQ_REQUISICAO.MTMD_ID_USUARIO_REQUISICAO%type;
pNUM_ATENDIMENTO TB_MTMD_REQ_REQUISICAO.ATD_ATE_ID%type;
pDSC_PRODUTO     TB_CAD_MTMD_MAT_MED.CAD_MTMD_NOMEFANTASIA%type;
pCOD_PRODUTO     TB_CAD_MTMD_MAT_MED.CAD_MTMD_CODMNE%type;
pID_CONVENIO     TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type;
pID_PACIENTE     TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%type;
pCOD_CONVENIO    TB_CAD_CNV_CONVENIO.CAD_CNV_CD_HAC_PRESTADOR%type;
pDSC_UNIDADE     TB_CAD_UNI_UNIDADE.CAD_UNI_DS_UNIDADE%type;
pDSC_SETOR       TB_CAD_SET_SETOR.CAD_SET_DS_SETOR%type;
pPRD_ID          TB_CAD_PRD_PRODUTO.CAD_PRD_ID%type;
pTP_ATRIBUTO     TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%type;
pCD_CARACMATMED  TB_CAD_PRD_PRODUTO.CAD_CMM_CD_CARACMATMED%type;
pNR_CONSELHO_SOLIC     TB_ATD_ATE_ATENDIMENTO.ATD_ATE_NR_CONSELHO_SOLIC%type;
pCD_UFCONSELHO_SOLIC   TB_ATD_ATE_ATENDIMENTO.ATD_ATE_CD_UFCONSELHO_SOLIC%type;
pCD_CONSELHOPROF_SOLIC TB_ATD_ATE_ATENDIMENTO.TIS_CPR_CD_CONSELHOPROF_SOLIC%type;
pFL_CARATER_SOLIC      TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%type;
pCBO_CD_CBOS           TB_ATD_ATE_ATENDIMENTO.TIS_CBO_CD_CBOS%type;
lIdtRetornoPAP integer;
nAte           integer;
pEmail_Corpo   varchar2(5000);
inserirPAP     boolean := false;
altoCusto      integer := 0; --0 ou 1
begin
SELECT R.MTMD_REQ_FL_STATUS, R.MTM_TIPO_REQUISICAO, R.ATD_ATE_ID,
       CAD_UNI_ID_UNIDADE,   CAD_SET_ID, CAD_LAT_ID_LOCAL_ATENDIMENTO,
       R.SEG_USU_ID_USUARIO
INTO   pStatusReq,           pTipoReq,              pNUM_ATENDIMENTO,
       pID_Unidade,          pID_Setor,             pID_Local,
       pID_USUARIO_REQ
FROM TB_MTMD_REQ_REQUISICAO R
WHERE R.MTMD_REQ_ID = pMTMD_REQ_ID;
IF (pTipoReq = 0) THEN -- PEDIDO PERSONALIZADO
  SELECT M.CAD_MTMD_NOMEFANTASIA, TRIM(M.CAD_MTMD_CODMNE)
  INTO   pDSC_PRODUTO           , pCOD_PRODUTO
  FROM TB_CAD_MTMD_MAT_MED M
  WHERE M.CAD_MTMD_ID = pCAD_MTMD_ID;
  SELECT C.CAD_CNV_ID_CONVENIO, C.CAD_CNV_CD_HAC_PRESTADOR, CAD_PAC_ID_PACIENTE
  INTO   pID_CONVENIO,          pCOD_CONVENIO,              pID_PACIENTE
     FROM TB_ASS_PAT_PACIEATEND PAT,
          TB_CAD_CNV_CONVENIO   C
     WHERE C.CAD_CNV_ID_CONVENIO = PAT.CAD_CNV_ID_CONVENIO AND
           PAT.ATD_ATE_ID = pNUM_ATENDIMENTO AND
           PAT.ASS_PAT_DT_SAIDA IS NULL AND
           PAT.ASS_PAT_FL_STATUS = 'A';
  -- REGRA ESPECIFICA DA PREVENT SENIOR SW94: ---------------------------------------------
  -- Na Hemodinamica, solicitar auto. para todos os MATERIAIS ESPECIAIS.
  -- Na Endoscopia, solicitar auto. para os MATERIAIS ESPECIAIS acima de 100 reais.
  IF (TRIM(pCOD_CONVENIO) = 'SW94') THEN
    BEGIN
      -- 113 = HEMODINAMICA, 87 = ENDOSCOPIA
      IF (pID_Setor IN (113,87)) THEN
         SELECT PRD.CAD_CMM_CD_CARACMATMED
           INTO pCD_CARACMATMED
           FROM TB_CAD_PRD_PRODUTO PRD
          WHERE TRIM(PRD.CAD_PRD_CD_CODIGO) = pCOD_PRODUTO AND ROWNUM = 1;
      END IF;
      -- 24 = MATERIAIS ESPECIAIS
      IF (NVL(pCD_CARACMATMED,0) = 24 AND pID_Setor = 113) THEN
         altoCusto := 1;
      ELSIF (NVL(pCD_CARACMATMED,0) = 24 AND pID_Setor = 87) THEN
         SELECT COUNT(M.CAD_MTMD_CODMNE)
           INTO altoCusto
          FROM TB_CAD_MTMD_MAT_MED M
         WHERE M.CAD_MTMD_ID = pCAD_MTMD_ID AND
               FNC_MTMD_PRECO_MEDIO(pCAD_MTMD_ID,1) >= 100;
      END IF;
    EXCEPTION WHEN NO_DATA_FOUND THEN
        NULL;
    END;
  END IF;
  -----------------------------------------------------------------------------------------
  IF (pStatusReq = 1 AND TRIM(pCOD_CONVENIO) NOT IN ('SD01','PA__','GG05','NP01','NR14')) THEN -- Nao incluir este convenios neste envio padrao
      IF (altoCusto = 0) THEN
        SELECT COUNT(CAD_MTMD_CODMNE)
          INTO altoCusto
          FROM (SELECT M.CAD_MTMD_CODMNE
                  FROM TB_CAD_MTMD_MAT_MED M
                 WHERE M.CAD_MTMD_CODMNE IN
                       ('19A1053','13A1379','19A1010','19C1920','19A1020','19A1107','13C1354','19Z1900','13S1700','19I1441','19E1998','19M1993','19M1992','19I1993',
                        '19A1010','13C1355','19G1101','19R1824','19E1003','19E1000','19E1303','19A1015','13B8004','19E1823')
          UNION --Unir com similares
          SELECT M.CAD_MTMD_CODMNE
          FROM TB_CAD_MTMD_MAT_MED M
          WHERE FNC_MTMD_PRINCIPIO_ATIVO(M.CAD_MTMD_ID) IN
                (SELECT DISTINCT FNC_MTMD_PRINCIPIO_ATIVO(M.CAD_MTMD_ID)
                 FROM TB_CAD_MTMD_MAT_MED M
                 WHERE M.CAD_MTMD_CODMNE IN
                       ('19A1053','13A1379','19A1010','19C1920','19A1020','19A1107','13C1354','19Z1900','13S1700','19I1441','19E1998','19M1993','19M1992','19I1993',
                        '19A1010','13C1355','19G1101','19R1824','19E1003','19E1000','19E1303','19A1015','13B8004','19E1823')
                 AND FNC_MTMD_PRINCIPIO_ATIVO(M.CAD_MTMD_ID) != 0))
          WHERE ROWNUM = 1 AND CAD_MTMD_CODMNE = pCOD_PRODUTO;
      END IF;
      IF (altoCusto = 0 AND TRIM(pCOD_CONVENIO) = 'SZ85') THEN
         SELECT COUNT(CAD_MTMD_CODMNE)
            INTO altoCusto
            FROM (SELECT M.CAD_MTMD_CODMNE
                    FROM TB_CAD_MTMD_MAT_MED M
                   WHERE M.CAD_MTMD_CODMNE IN
                         ('12A2100','19B5003','19C1920','13C1355','19K1500','19M1993','19R1501','19Z1003','19T1001'))
          WHERE ROWNUM = 1 AND CAD_MTMD_CODMNE = pCOD_PRODUTO;
      END IF;
      IF (altoCusto = 0 AND TRIM(pCOD_CONVENIO) = 'SW94') THEN
         SELECT COUNT(CAD_MTMD_ID)
            INTO altoCusto
            FROM (SELECT M.CAD_MTMD_ID
                    FROM TB_CAD_MTMD_MAT_MED M, TB_CAD_PRD_PRODUTO PRD, TB_CAD_VCM_VAL_COBR_MAT_MED VCM
                   WHERE TRIM(M.CAD_MTMD_CODMNE) = TRIM(PRD.CAD_PRD_CD_CODIGO)
                   AND PRD.CAD_TAP_TP_ATRIBUTO = 'MED'
                   AND PRD.CAD_PRD_ID = VCM.CAD_PRD_ID(+)
                   AND VCM.CAD_CNV_ID_CONVENIO(+) = 3262 -- SW94 PREVENT SENIOR 
                   AND VCM.CAD_VCM_DT_FIM_VIGENCIA(+) IS NULL
                   AND PRD.CAD_CMM_CD_CARACMATMED <> 26 -- DIETA
                   AND DECODE(NVL(VCM.CAD_VCM_VL_PRODUTO,0),0,NVL(PRD.CAD_PRD_VL_PRODUTO,0),NVL(VCM.CAD_VCM_VL_PRODUTO,0)) > 500)
           WHERE ROWNUM = 1 AND CAD_MTMD_ID = pCAD_MTMD_ID;
      END IF;
      IF (altoCusto = 0) THEN
         SELECT COUNT(M.CAD_MTMD_CODMNE)
           INTO altoCusto
          FROM TB_CAD_MTMD_MAT_MED M
         WHERE M.CAD_MTMD_ID = pCAD_MTMD_ID AND
               FNC_MTMD_PRECO_MEDIO(pCAD_MTMD_ID,1) >= 500;
      END IF;
      IF (altoCusto > 0) THEN
        pEmail_Corpo :=  'Produto solicitado: <B>#DSC_PRODUTO</B> Cod <B>#COD_PRODUTO</B><BR>
                          Quantidade: <B>#QTDE</B><BR>
                          Atendimento: <B>#NUM_ATENDIMENTO</B> Convenio <B>#COD_CONVENIO</B><BR>
                          Unidade: <B>#DSC_UNIDADE</B><BR>
                          Setor: <B>#DSC_SETOR</B><P>
                          ESTE E-MAIL FOI ENVIADO PELO SISTEMA DE GESTAO DE ESTOQUE (SGS)';
        SELECT U.CAD_UNI_DS_UNIDADE INTO pDSC_UNIDADE
        FROM TB_CAD_UNI_UNIDADE U
        WHERE U.CAD_UNI_ID_UNIDADE = pID_Unidade;
        SELECT S.CAD_SET_DS_SETOR INTO pDSC_SETOR
        FROM TB_CAD_SET_SETOR S
        WHERE S.CAD_SET_ID = pID_Setor;
        pEmail_Corpo := Replace(pEmail_Corpo, '#DSC_PRODUTO', pDSC_PRODUTO);
        pEmail_Corpo := Replace(pEmail_Corpo, '#COD_PRODUTO', pCOD_PRODUTO);
        pEmail_Corpo := Replace(pEmail_Corpo, '#QTDE', TO_CHAR(pMTMD_REQITEM_QTD_SOLICITADA));
        pEmail_Corpo := Replace(pEmail_Corpo, '#NUM_ATENDIMENTO', TO_CHAR(pNUM_ATENDIMENTO));
        pEmail_Corpo := Replace(pEmail_Corpo, '#COD_CONVENIO', pCOD_CONVENIO);
        pEmail_Corpo := Replace(pEmail_Corpo, '#DSC_UNIDADE', pDSC_UNIDADE);
        pEmail_Corpo := Replace(pEmail_Corpo, '#DSC_SETOR', pDSC_SETOR);
        /*PRC_ENVIA_EMAIL('centraldeguias@anacosta.com.br',
                       'centraldeguias@anacosta.com.br',
                       null,
                       'SOLICITACAO DE PRODUTO DE ALTO CUSTO (PEDIDO AO PACIENTE)',
                       pEmail_Corpo);*/
        PRC_ENVIA_EMAIL_N('centraldeguias@anacosta.com.br',
                          'centraldeguias@anacosta.com.br,secretarias.clinicas@anacosta.com.br',
                          'SOLICITACAO DE PRODUTO DE ALTO CUSTO (PEDIDO AO PACIENTE)',
                          pEmail_Corpo);
      END IF;
  END IF;
  --Busca nas parametrizac?es do conv. pelo produto/caracteristica, se produto exige autorizac?o
  BEGIN
    SELECT DISTINCT PRD.CAD_PRD_ID
      INTO pPRD_ID
      FROM TB_ASS_PPI_PLAPRODUTOINT PPI JOIN
           TB_CAD_PRD_PRODUTO PRD ON PRD.CAD_PRD_ID = PPI.CAD_PRD_ID
      WHERE --(PPI.ASS_PPI_FL_EXIGE_GUIA = 'S' OR PPI.ASS_PPI_FL_EXIGE_SENHA = 'S' OR PPI.ASS_PPI_FL_COBERTURA = 'S') AND
            PPI.ASS_PPI_FL_STATUS            = 'A' AND
            PPI.CAD_LAT_ID_LOCAL_ATENDIMENTO = pID_Local AND
            PPI.CAD_CNV_ID_CONVENIO          = pID_CONVENIO AND
            TRIM(PRD.CAD_PRD_CD_CODIGO)      = pCOD_PRODUTO AND ROWNUM = 1;
      inserirPAP := true;
  EXCEPTION WHEN NO_DATA_FOUND THEN
       BEGIN
          SELECT PRD.CAD_PRD_ID, PRD.CAD_TAP_TP_ATRIBUTO, PRD.CAD_CMM_CD_CARACMATMED
            INTO pPRD_ID,        pTP_ATRIBUTO,            pCD_CARACMATMED
            FROM TB_CAD_PRD_PRODUTO PRD
           WHERE TRIM(PRD.CAD_PRD_CD_CODIGO) = pCOD_PRODUTO AND
                  PRD.TIS_MED_CD_TABELAMEDICA IN (SELECT CTU.TIS_MED_CD_TABELAMEDICA
                                                    FROM TB_ASS_CTU_CNV_TAB_UTILIZA CTU
                                                   WHERE CTU.CAD_CNV_ID_CONVENIO = pID_CONVENIO AND
                                                         CTU.CAD_TAP_TP_ATRIBUTO = PRD.CAD_TAP_TP_ATRIBUTO AND
                                                         FNC_VALIDAR_VIGENCIA(CTU.ASS_CTU_DT_INICIO_VIGENCIA, CTU.ASS_CTU_DT_FIM_VIGENCIA) = 1);
          SELECT DISTINCT PPI.CAD_CNV_ID_CONVENIO
            INTO pID_CONVENIO
            FROM TB_ASS_PPI_PLAPRODUTOINT PPI
           WHERE PPI.CAD_PRD_ID IS NULL AND
                 PPI.ASS_PPI_FL_STATUS            = 'A' AND
                 PPI.CAD_LAT_ID_LOCAL_ATENDIMENTO = pID_Local AND
                 PPI.CAD_CNV_ID_CONVENIO          = pID_CONVENIO AND
                 PPI.CAD_TAP_TP_ATRIBUTO          = pTP_ATRIBUTO AND
                 PPI.CAD_CMM_CD_CARACMATMED       = pCD_CARACMATMED;
           inserirPAP := true;
       EXCEPTION WHEN NO_DATA_FOUND THEN
             NULL;
       END;
  END;
  IF (inserirPAP) THEN
     SELECT ATD_ATE_NR_CONSELHO_SOLIC, ATD_ATE_CD_UFCONSELHO_SOLIC, TIS_CPR_CD_CONSELHOPROF_SOLIC,
            ATD_ATE_FL_CARATER_SOLIC,  TIS_CBO_CD_CBOS
       INTO pNR_CONSELHO_SOLIC,        pCD_UFCONSELHO_SOLIC,        pCD_CONSELHOPROF_SOLIC,
            pFL_CARATER_SOLIC,         pCBO_CD_CBOS
       FROM TB_ATD_ATE_ATENDIMENTO
      WHERE ATD_ATE_ID = pNUM_ATENDIMENTO;
     --Inserir registros 1 a 1
     FOR nCount IN 1..pMTMD_REQITEM_QTD_SOLICITADA
     LOOP
       PRC_ASS_PAP_PAC_ATEN_PROC_I(lIdtRetornoPAP,
                                   nAte,
                                   pNUM_ATENDIMENTO,
                                   pPRD_ID,
                                   pID_PACIENTE,
                                   1,--pMTMD_REQITEM_QTD_SOLICITADA,
                                   SYSDATE,
                                   'A',
                                   TO_NUMBER(TO_CHAR(SYSDATE,'HH24MI')),
                                   NULL,
                                   NULL,
                                   NULL,
                                   'P',
                                   NULL,
                                   NULL,
                                   NULL,
                                   NULL,
                                   NULL,
                                   pID_USUARIO_REQ,
                                   NULL,
                                   'I',
                                   pID_Unidade,
                                   NULL,
                                   pNR_CONSELHO_SOLIC,
                                   pCD_UFCONSELHO_SOLIC,
                                   pCD_CONSELHOPROF_SOLIC,
                                   pID_Local,
                                   NULL,
                                   NULL,
                                   NULL,
                                   pID_Setor,
                                   NULL,
                                   pFL_CARATER_SOLIC,
                                   NULL,
                                   NULL,
                                   NULL,
                                   pCBO_CD_CBOS);
     END LOOP;
  END IF;
END IF;
end PRC_MTMD_EMAIL_ALTO_CUSTO;