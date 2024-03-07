create or replace procedure sgs.PRC_AGE_ULT_PROF_ESP_S
(
  pTIS_CBO_CD_CBOS         IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE,
  pCAD_PAC_ID_PACIENTE     IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE,
  pNewIdt                  OUT integer
)
is
  /********************************************************************
  *    Procedure: PRC_AGE_ULT_PROF_ESP_S
  *
  *    Data Criacao: 	  30/08/2007           Por: Fabiola Lopes
  *    Funcao: Retorna o ultimo profissional que atendeu na especialidade e paciente
  *
  *	   Data Alterac?o:   08/01/2008				Por: Cristiane Gomes
  *	   Alterac?o:	1) Inclus?o de dois parametros (CODTIPATE IN 1,23,26 e CODSITATE = 'A')
  *               2) Inclus?o de TO_CHAR nos joins com a coluna CODMED
  *
   *	   Data Alterac?o:   23/02/2010			Por: Pedro
  *	   Alterac?o:	 AND    PAC.CAD_PAC_NR_PRONTUARIO != 7
  *
  *******************************************************************/


  lIdtRetorno number;
begin
    lIdtRetorno := 0;
    SELECT PRO.CAD_PRO_ID_PROFISSIONAL
    into   lIdtRetorno
    FROM   TB_ATD_ATE_ATENDIMENTO ATD,
           TB_CAD_PRO_PROFISSIONAL PRO,
           TB_TIS_CBO_CBOS CBO,
           TB_ASS_PAT_PACIEATEND PAT,
           TB_CAD_PAC_PACIENTE PAC, ( SELECT MAX(ATD.ATD_ATE_DT_ATENDIMENTO) DAT
                                      FROM   TB_ATD_ATE_ATENDIMENTO ATD,
                                             TB_ASS_PAT_PACIEATEND PAT,
                                             TB_CAD_PRO_PROFISSIONAL PRO,
                                             TB_TIS_CBO_CBOS CBO,                                            
                                             TB_CAD_PAC_PACIENTE PAC
                                      WHERE  CBO.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS                                   
                                      AND    PAC.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE                                      
                                      AND    ATD.CAD_PRO_ID_PROF_EXEC = PRO.CAD_PRO_ID_PROFISSIONAL
                                      AND    CBO.TIS_CBO_CD_CBOS = ATD.TIS_CBO_CD_CBOS
                                      AND    PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
                                      AND    PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
                                      AND    PAC.CAD_PAC_NR_PRONTUARIO != 7
                                      AND   ATD.TIS_TAT_CD_TPATENDIMENTO = 4
                                      AND    ATD.ATD_ATE_FL_STATUS = 'A' ) DTMAX
    WHERE  CBO.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS
    AND    ATD.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
    AND    PAC.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE    
    AND    PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
    AND    PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
    AND    ATD.CAD_PRO_ID_PROF_EXEC = PRO.CAD_PRO_ID_PROFISSIONAL;
    pNewIdt := lIdtRetorno;

    EXCEPTION
             WHEN OTHERS THEN
             pNewIdt := 0;

end PRC_AGE_ULT_PROF_ESP_S;
