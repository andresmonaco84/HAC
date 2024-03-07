CREATE OR REPLACE PROCEDURE PRC_MTMD_EMAIL_AVISO_VAR_CM
(
   pCAD_MTMD_ID                 IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_ID%type,
   pMTMD_NR_NOTA                IN TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_NR_NOTA%TYPE,
   pULTIMO_PRECO                IN TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_PRECO_UNITARIO%TYPE  DEFAULT 0,
   pNOVO_PRECO                  IN TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_PRECO_UNITARIO%TYPE DEFAULT 0
)
is
/********************************************************************
*    Procedure: PRC_MTMD_EMAIL_AVISO_VAR_CM
*
*    Data Criacao:   DEZ/2019  Por: Andre
*
*    Funcao: ENVIAR E-MAIL QUANDO HOUVER UMA GRANDE VARIACAO NO CUSTO MEDIO
*******************************************************************/
pEmail_Corpo   varchar2(5000);
vDSC_PRODUTO   TB_CAD_MTMD_MAT_MED.CAD_MTMD_NOMEFANTASIA%type;
nVariacao      DECIMAL := 0;
begin

  IF (pNOVO_PRECO > 5 or pULTIMO_PRECO > 5) THEN

    SELECT DECODE(pULTIMO_PRECO, 0, 0, ((100*pNOVO_PRECO)/pULTIMO_PRECO)-100) PERCETUAL_DIFERENCA
      INTO nVariacao
      FROM DUAL;

    IF (nVariacao > 50 OR nVariacao < -50) THEN

      SELECT M.CAD_MTMD_NOMEFANTASIA
      INTO   vDSC_PRODUTO
      FROM TB_CAD_MTMD_MAT_MED M
      WHERE M.CAD_MTMD_ID = pCAD_MTMD_ID;

      pEmail_Corpo :=  '<B>Aviso de grande variacao no custo medio na ultima Nota Fiscal. Verificar se nao entrou com unidade incorreta!</B><P>
                        PRODUTO: <B>#DSC_PRODUTO</B> ID: <B>#ID_PRODUTO</B><BR>
                        NUMERO NF: <B>#NUMERO_NF</B><BR>
                        VALOR NF: <B>#VAL_NF_ATUAL</B><BR>
                        VALOR NF ANTERIOR: <B>#VAL_NF_ANT</B><P>
                        ESTE E-MAIL FOI ENVIADO DE FORMA AUTOMATICA PELO SISTEMA DE GESTAO DE ESTOQUE (SGS)';
      pEmail_Corpo := Replace(pEmail_Corpo, '#DSC_PRODUTO', vDSC_PRODUTO);
      pEmail_Corpo := Replace(pEmail_Corpo, '#ID_PRODUTO',  TO_CHAR(pCAD_MTMD_ID));
      pEmail_Corpo := Replace(pEmail_Corpo, '#NUMERO_NF',   pMTMD_NR_NOTA);
      IF (pNOVO_PRECO) < 1 THEN
         pEmail_Corpo := Replace(pEmail_Corpo, '#VAL_NF_ATUAL', '0' || TRIM(REPLACE(TO_CHAR(pNOVO_PRECO, '99999D99'),'.',',')));
      ELSE
         pEmail_Corpo := Replace(pEmail_Corpo, '#VAL_NF_ATUAL', TRIM(REPLACE(TO_CHAR(pNOVO_PRECO, '99999D99'),'.',',')));
      END IF;
      IF (pULTIMO_PRECO) < 1 THEN
         pEmail_Corpo := Replace(pEmail_Corpo, '#VAL_NF_ANT', '0' || TRIM(REPLACE(TO_CHAR(pULTIMO_PRECO, '99999D99'),'.',',')));
      ELSE
         pEmail_Corpo := Replace(pEmail_Corpo, '#VAL_NF_ANT', TRIM(REPLACE(TO_CHAR(pULTIMO_PRECO, '99999D99'),'.',',')));
      END IF;

      PRC_ENVIA_EMAIL_CURTO('sgs@anacosta.com.br',
                        'paula.carvalho@anacosta.com.br,isabela.martins@anacosta.com.br,angela.cristina@anacosta.com.br',
                        'AVISO: GRANDE VARIACAO NO CUSTO MEDIO NA ENTRADA DE NF',
                        pEmail_Corpo);
    END IF;

  END IF;

end PRC_MTMD_EMAIL_AVISO_VAR_CM;