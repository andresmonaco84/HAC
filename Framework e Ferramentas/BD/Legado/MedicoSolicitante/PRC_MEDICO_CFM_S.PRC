CREATE OR REPLACE PROCEDURE "PRC_MEDICO_CFM_S" (
     pCODMED IN TB_MEDICO_CFM.CODMED%type DEFAULT NULL,
     pUF IN TB_MEDICO_CFM.UF%type DEFAULT NULL,
     pNOMMED IN TB_MEDICO_CFM.NOMMED%type DEFAULT NULL,
     pCODSITMED IN TB_MEDICO_CFM.CODSITMED%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_MEDICO_CFM_S
  *
  *    Data Criacao:  16/01/2008   Por: Andrea Cazuca
  *    Data Alteracao: 12/06/2008  Por: Andrea Cazuca
  *    Alteracao:      Inclusao da tabela de profissional para identificar
  *                    o profissional do Corpo Clinico do HAC
  *
  *    Data Alteracao: 09/06/2009  Por: Davi Silvestre M. dos Reis
  *    Alteracao:      Inclusao do filtro para obter apenas 
  *                    profissionais ativos
  *
  *    Data Alteracao: 19/08/2009  Por: Davi Silvestre M. dos Reis
  *    Alteracao:      Possibilidade de deixar o filtro de situacao 
  *                    opcional. Se nao informar o filtro, por padrao
  *                    traz apenas os medicos ativos
  *
  *    Funcao: Obtem ou Lista Medicos Solicitantes
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CFM.CODMED,
       CFM.UF,
       CFM.NOMMED,
       CFM.CODSITMED,
       DECODE(PRO.CAD_PRO_NR_CONSELHO, NULL, '', 'Corpo Clinico HAC') CCHAC
    FROM TB_MEDICO_CFM CFM,
         TB_CAD_PRO_PROFISSIONAL PRO
    WHERE
        (pCODMED is null OR CFM.CODMED = pCODMED) AND
        (pUF is null OR CFM.UF = pUF) AND
        (pNOMMED is null OR CFM.NOMMED like pNOMMED) AND
        (CFM.CODSITMED like DECODE(pCODSITMED, NULL, 'A', pCODSITMED)) AND
        TO_CHAR(CFM.CODMED) = PRO.CAD_PRO_NR_CONSELHO(+);
    io_cursor := v_cursor;
  end PRC_MEDICO_CFM_S;
/
