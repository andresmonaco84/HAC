CREATE OR REPLACE PROCEDURE PRC_CAD_MTMD_MAT_MED_SID
  (
     pCAD_MTMD_ID IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MTMD_MAT_MED_SID
  *
  *    Data Criacao:   04/2009      Por: Ricardo Costa
  *    Data Alteracao: 07/04/2010  Por: Andre Souza Monaco
  *         Alteracao: Adic?o de campo mtmd_tp_fracao_id, CAD_MTMD_FL_FATURADO e MTMD_DS_TP_FRACAO
  *    Data Alteracao:  23/07/2012  Por: Andre S. Monaco
  *         Alteracao:  Adic?o do campo CAD_MTMD_CD_ANVISA
  *    Data Alteracao:  26/04/2017  Por: Andre S. Monaco
  *         Alteracao:  Adicao campo CAD_MTMD_CD_GRUPO_ANVISA
  *    Data Alteracao:  24/10/2017  Por: Andre S. Monaco
  *         Alteracao:  Adicao funcao SOUND ALIKE na descricao
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_MTMD_ID,
       CAD_MTMD_FILIAL_ID,
       CAD_MTMD_PRIATI_ID,
       CAD_MTMD_GRUPO_ID,
       CAD_MTMD_SUBGRUPO_ID,
       TIS_MED_CD_TABELAMEDICA,
       FNC_MTMD_SOUNDALIKE(MATMED.CAD_MTMD_NOMEFANTASIA,MATMED.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,
       CAD_MTMD_DESCRICAO,
       CAD_MTMD_UNIDADE_VENDA,
       CAD_MTMD_UNIDADE_COMPRA,
       CAD_MTMD_UNIDADE_CONTROLE,
       CAD_MTMD_CODMNE,
       CAD_MTMD_CURVA_ABC,
       CAD_MTMD_CD_FABRICANTE,
       CAD_MTMD_FL_FRACIONA,
       CAD_MTMD_FL_ATIVO,
       CAD_MTMD_FL_MANTER_ESTOQUE,
       CAD_MTMD_FL_REUTILIZAVEL,
       CAD_MTMD_DT_ATUALIZACAO,
       CAD_MTMD_CD_RM,
       MATMED.cad_mtmd_unidade_consumo,
       MATMED.cad_mtmd_unid_compra_ds,
       MATMED.cad_mtmd_unid_controle_ds,
       MATMED.cad_mtmd_unid_venda_ds,
       MATMED.CAD_MTMD_FL_BAIXA_AUTOMATICA,
       MATMED.mtmd_tp_fracao_id,
       MATMED.CAD_MTMD_FL_FATURADO,
       MATMED.CAD_MTMD_CD_ANVISA,
       CASE
           WHEN (MATMED.MTMD_TP_FRACAO_ID IS NOT NULL) THEN
              (SELECT MTMD_DS_TP_FRACAO FROM TB_MTMD_TIPO_FRACAO WHERE MTMD_TP_FRACAO_ID = MATMED.MTMD_TP_FRACAO_ID)
           ELSE NULL
         END  MTMD_DS_TP_FRACAO,
       MATMED.CAD_MTMD_FL_MAV,
       CAD_MTMD_CD_GRUPO_ANVISA,
       CAD_MTMD_FL_CONTROLA_LOTE,
       CAD_MTMD_FL_DILUENTE,
       MATMED.CAD_MTMD_PRIATI_SAL_DSC,
       MATMED.CAD_MTMD_FORMA_FARMACEUTICA,
       MATMED.CAD_MTMD_DOSAGEM_PADRONIZADA,
       MATMED.CAD_MTMD_FL_GELADEIRA MTMD_FL_GELADEIRA,
       CAD_MTMD_FL_PADRAO
    FROM TB_CAD_MTMD_MAT_MED MATMED
    WHERE
        CAD_MTMD_ID = pCAD_MTMD_ID;
    io_cursor := v_cursor;
  end PRC_CAD_MTMD_MAT_MED_SID;