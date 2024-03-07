CREATE OR REPLACE FUNCTION FNC_MTMD_CALCULA_ROTATIVIDADE
(
 pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type DEFAULT NULL,
 pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,--SEM UTILIZAÇÃO MAIS
 pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,--SEM UTILIZAÇÃO MAIS
 pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type DEFAULT NULL,--SEM UTILIZAÇÃO MAIS
 pCAD_MTMD_FILIAL_ID           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_FILIAL_ID%TYPE,
 pDATA_INI                     IN DATE,--TEM QUE SER O 1° DIA DO MÊS REF.
 pDATA_FIM                     IN DATE --SEM UTILIZAÇÃO MAIS
)
RETURN  number IS
/********************************************************************
*    Procedure: FNC_MTMD_CALCULA_ROTATIVIDADE
*
*    Data Criacao: 	2009         Por: Ricardo
*    Data Alteração:17/03/2011   Por: André Souza Monaco
*         Alteração:Utilização da tabela TB_MTMD_MOV_MES para obter dados de cálculo
*
*    Funcao: Retorna indice de rotatividade
*******************************************************************/  
retorno NUMBER;
dData DATE;
nDias NUMBER;
nQtdeEntrada NUMBER;
nQtdeSaida NUMBER;
nMediaDiaEntrada NUMBER;
nMediaDiaSaida NUMBER;
dDataIni DATE := pDATA_INI;
sMes VARCHAR2(2):= to_char(dDataIni,'MM');
BEGIN   
   -- VERIFICA SE É MES ATUAL
   IF ( TO_CHAR(SYSDATE,'MM') = sMes ) THEN
      nDias := TO_NUMBER(TO_CHAR(SYSDATE,'DD'));
   ELSE
      dData := TO_DATE('01'||sMes||TO_CHAR(dDataIni,'YYYY'),'DDMMYYYY');
      nDias := TO_NUMBER(TO_CHAR(Last_day(dData),'DD'));
   END IF;
   
   -- MEDIA DE ENTRADA DO MES   
   BEGIN
      SELECT       
       MOV.MTMD_QTDE_ENTRADA,      
       MOV.MTMD_QTDE_SAIDA
      INTO    nQtdeEntrada,     nQtdeSaida
      FROM TB_MTMD_MOV_MES MOV
      WHERE MOV.MTMD_MOV_MES = sMes
      AND   MOV.MTMD_MOV_ANO = TO_NUMBER(TO_CHAR(dDataIni,'YYYY'))
      AND   MOV.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND   MOV.CAD_MTMD_ID = pCAD_MTMD_ID;  
    
      IF ( NVL(nQtdeEntrada,0) = 0 ) THEN
       nMediaDiaEntrada := 0;
      ELSE
       nMediaDiaEntrada := ROUND( NVL(nQtdeEntrada,0)/ nDias,2);
      END IF;
      
      IF ( NVL(nQtdeSaida,0) = 0  ) THEN
       nMediaDiaSaida := 0;
      ELSE
       nMediaDiaSaida := ROUND( NVL(nQtdeSaida,0)/ nDias,2 );
      END IF;
      
      IF ( NVL(nQtdeSaida,0) = 0 AND NVL(nQtdeEntrada,0) = 0 ) THEN
      retorno := 0;
      ELSIF ( NVL(nQtdeSaida,0) = 0 AND NVL(nQtdeEntrada,0) > 0 ) THEN
       -- COMPROU E NAO CONSUMIU
       retorno := 0;
      ELSIF ( NVL(nQtdeSaida,0) > 0 AND NVL(nQtdeEntrada,0) = 0 ) THEN
       -- CONSUMIU E NAO COMPROU
       retorno := 0;
      ELSE
       retorno := round(nMediaDiaSaida/nMediaDiaEntrada,2);
      END IF;
    EXCEPTION 
        WHEN OTHERS THEN
        retorno := 0;
    END;
   RETURN retorno;
END;
