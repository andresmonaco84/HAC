create or replace procedure PRC_FAT_PRD_TCP_L
(
   pFAT_TCO_ID IN  TB_FAT_TCP_TP_COMANDA_PROD.FAT_TCO_ID%type,
   pCOMPLETO   IN  NUMBER DEFAULT NULL, -- Se = 1, faz join com outras tabelas para trazer as outras descrições
   io_cursor   OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_FAT_PRD_TCP_L
*
*    Data Criacao:   20/04/2010  Por: Marcus Relva
*    Data Alteracao: 26/04/2010  Por: André Souza Monaco
*         Alteracao: Adição do parâmetro pCOMPLETO para trazer uma
*                    query mais completa
*
*    Funcao: Controle HacProcedimento e tela FrmAssociacaoComandaProcedimento
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin

  IF (NVL(pCOMPLETO, 0) = 0) THEN
    OPEN v_cursor FOR
    SELECT PRD.CAD_PRD_ID,
           PRD.CAD_PRD_CD_CODIGO,
           PRD.CAD_PRD_DS_DESCRICAO,
           TCP.FAT_TCO_ID
      FROM TB_CAD_PRD_PRODUTO PRD, TB_FAT_TCP_TP_COMANDA_PROD TCP
     WHERE PRD.CAD_PRD_ID = TCP.CAD_PRD_ID
       AND TCP.FAT_TCO_ID = pFAT_TCO_ID
       AND TCP.FAT_TCP_FL_STATUS = 'A';
  ELSE
      OPEN v_cursor FOR
      SELECT TCP.CAD_PRD_ID,
             TCP.FAT_TCP_ID,
             TCP.FAT_TCO_ID,
             TCP.FAT_TCP_DT_ULTIMA_ATUALIZACAO,
             C.FAT_TCO_DS_COMANDA,
             PROD.CAD_PRD_CD_CODIGO,
             PROD.CAD_PRD_DS_DESCRICAO,
             PROD.CAD_TAP_TP_ATRIBUTO,
             CAD_TAP_DS_ATRIBUTO,
             TAB.TIS_MED_DS_TABELAMEDICA,
             ESP.AUX_EPP_DS_DESCRICAO,
             GR.AUX_GPC_DS_DESCRICAO,
             TAP.CAD_TAP_DS_ATRIBUTO,             
             'true' checkAssociacao -- CAMPO PARA FORÇAR SELEÇÃO DE CHECKBOX NA TELA FrmAssociacaoComandaProcedimento
        FROM            TB_FAT_TCP_TP_COMANDA_PROD TCP
             INNER JOIN TB_FAT_TCO_TIPO_COMANDA C       ON TCP.FAT_TCO_ID                   = C.FAT_TCO_ID
             INNER JOIN TB_CAD_PRD_PRODUTO PROD         ON TCP.CAD_PRD_ID                   = PROD.CAD_PRD_ID
             LEFT JOIN  TB_TIS_MED_TABELAMEDICA TAB     ON PROD.TIS_MED_CD_TABELAMEDICA     = TAB.TIS_MED_CD_TABELAMEDICA
             LEFT JOIN  TB_AUX_EPP_ESPECPROC ESP        ON (PROD.AUX_EPP_CD_ESPECPROC       = ESP.AUX_EPP_CD_ESPECPROC AND
                                                            PROD.TIS_MED_CD_TABELAMEDICA    = ESP.TIS_MED_CD_TABELAMEDICA)
             LEFT JOIN  TB_AUX_GPC_GRUPOPROC GR         ON (PROD.AUX_EPP_CD_ESPECPROC       = GR.AUX_EPP_CD_ESPECPROC AND
                                                            PROD.TIS_MED_CD_TABELAMEDICA    = GR.TIS_MED_CD_TABELAMEDICA AND
                                                            PROD.AUX_GPC_CD_GRUPOPROC       = GR.AUX_GPC_CD_GRUPOPROC)
             LEFT JOIN  TB_CAD_TAP_TP_ATRIB_PRODUTO TAP ON  PROD.CAD_TAP_TP_ATRIBUTO        = TAP.CAD_TAP_TP_ATRIBUTO
        WHERE TCP.FAT_TCO_ID        = pFAT_TCO_ID AND
              TCP.FAT_TCP_FL_STATUS = 'A'
        ORDER BY TAP.CAD_TAP_DS_ATRIBUTO, PROD.CAD_PRD_DS_DESCRICAO, TAB.TIS_MED_DS_TABELAMEDICA, ESP.AUX_EPP_DS_DESCRICAO;
  END IF;

  io_cursor := v_cursor;
end PRC_FAT_PRD_TCP_L;
