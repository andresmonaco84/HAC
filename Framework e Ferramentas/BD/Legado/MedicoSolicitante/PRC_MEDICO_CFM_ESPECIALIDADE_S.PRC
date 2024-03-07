CREATE OR REPLACE PROCEDURE "PRC_MEDICO_CFM_ESPECIALIDADE_S" 
 (
     pCODMED IN TB_MEDICO_CFM.CODMED%type DEFAULT NULL,
     pUF IN TB_MEDICO_CFM.UF%type DEFAULT NULL,
     pNOMMED IN TB_MEDICO_CFM.NOMMED%type DEFAULT NULL,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_MEDICO_CFM_ESPECIALIDADE_S
  *
  *    Data Criacao:  25/09/2008   Por: Andrea Cazuca
  *
  *    Funcao: Obtem ou Lista Médicos Solicitantes por Especialidade
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
           CFM.CODMED,
           CFM.UF,
           CFM.NOMMED,
           CFM.CODSITMED
    FROM   TB_MEDICO_CFM CFM,
           TB_CAD_PRO_PROFISSIONAL PRO,
           TB_ASS_PCB_PROFISSIONAL_CBOS PCB
    WHERE
           (pCODMED is null OR CFM.CODMED = pCODMED) AND
           (pUF is null OR CFM.UF = pUF) AND
           (pNOMMED is null OR CFM.NOMMED like pNOMMED) AND
           CFM.CODSITMED = 'A' AND
           TO_CHAR(CFM.CODMED) = PRO.CAD_PRO_NR_CONSELHO(+) AND
           PCB.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL AND
           (pTIS_CBO_CD_CBOS IS NULL OR PCB.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS);
     io_cursor := v_cursor;
  end PRC_MEDICO_CFM_ESPECIALIDADE_S;
