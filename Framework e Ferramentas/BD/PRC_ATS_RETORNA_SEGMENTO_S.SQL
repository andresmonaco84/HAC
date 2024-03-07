create or replace procedure PRC_ATS_RETORNA_SEGMENTO_S
(
   pATS_ATE_CD_INTLIB    IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_CD_INTLIB%TYPE DEFAULT NULL,
   pATS_ATE_IN_INTLIB    IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_IN_INTLIB%TYPE DEFAULT NULL,
   pATS_ATE_ID           IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_ID%TYPE DEFAULT NULL,
   pCAD_PRD_ID           IN TB_ATS_ATE_ATENDIMENTO_SADT.CAD_PRD_ID%TYPE DEFAULT NULL,
   pAUX_EPP_CD_ESPECPROC IN TB_ATS_ATE_ATENDIMENTO_SADT.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,
   pTIS_MED_CD_TABELAMEDICA IN TB_ATS_APS_ATEN_PROC_SEGMENTO.TIS_MED_CD_TABELAMEDICA%type	DEFAULT NULL,
   pATS_CPS_CD_SEGMENTO  OUT VARCHAR
)
  is
  /********************************************************************
  *    Procedure: PRC_ATS_RETORNA_SEGMENTO_S
  *
  *    Data Criacao:   17/02/2009            Por: Fabiola Lopes
  *    Funcao: Retorna os segmentos (um ao lado do outro)
  *
  *    Data Alteracao:	27/03/2010  Por: Pedro
  *    Alteração: pTIS_MED_CD_TABELAMEDICA
  *
  *******************************************************************/

  segmento varchar2(100);

  BEGIN
     FOR X IN (SELECT APS.ATS_CPS_CD_SEGMENTO
                 FROM TB_ATS_ATE_ATENDIMENTO_SADT ATE,
                      TB_ATS_APS_ATEN_PROC_SEGMENTO APS
                WHERE ATE.ATS_ATE_CD_INTLIB = APS.ATS_ATE_CD_INTLIB
                  AND ATE.ATS_ATE_IN_INTLIB = APS.ATS_ATE_IN_INTLIB
                  AND ATE.ATS_ATE_ID = APS.ATS_ATE_ID
                  AND ATE.CAD_PRD_ID = APS.CAD_PRD_ID
                  AND ATE.AUX_EPP_CD_ESPECPROC = APS.AUX_EPP_CD_ESPECPROC
                  AND ATE.ATS_ATE_CD_INTLIB = pATS_ATE_CD_INTLIB
                  AND ATE.ATS_ATE_IN_INTLIB = pATS_ATE_IN_INTLIB
                  AND ATE.ATS_ATE_ID = pATS_ATE_ID
                  AND ATE.CAD_PRD_ID = pCAD_PRD_ID
                  AND ATE.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC
                  AND ATE.TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA )
     LOOP
        IF (segmento IS NULL) THEN
           segmento := x.ATS_CPS_CD_SEGMENTO;
        ELSE
           segmento := segmento || ' , ' || x.ATS_CPS_CD_SEGMENTO;
        END IF;
     END LOOP;
     
     pATS_CPS_CD_SEGMENTO := segmento;
     
     EXCEPTION
        WHEN NO_DATA_FOUND THEN
           pATS_CPS_CD_SEGMENTO := '0';

  end PRC_ATS_RETORNA_SEGMENTO_S;
/
