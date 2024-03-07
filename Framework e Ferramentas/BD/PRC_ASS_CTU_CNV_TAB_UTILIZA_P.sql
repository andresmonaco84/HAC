create or replace procedure PRC_ASS_CTU_CNV_TAB_UTILIZA_P
(
   pCAD_CNV_ID_CONVENIO IN TB_ASS_CTU_CNV_TAB_UTILIZA.CAD_CNV_ID_CONVENIO%type,
   pCAD_PRD_CD_CODIGO IN TB_CAD_PRD_PRODUTO.CAD_PRD_CD_CODIGO%type DEFAULT NULL,
   pTIS_MED_CD_TABELAMEDICA IN TB_CAD_PRD_PRODUTO.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL,
   pCAD_TAP_TP_ATRIBUTO IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
   pCAD_CMM_CD_CARACMATMED IN TB_CAD_PRD_PRODUTO.CAD_CMM_CD_CARACMATMED%TYPE DEFAULT NULL,
   io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_CTU_CNV_TAB_UTILIZA_P
*
*    Data Criacao: 28/6/2010	   Por: Andr� S. Monaco
*    Data Alteracao:	           Por:
*
*    Funcao: Listar todos os produtos/procedimentos em vig�ncia
*            de acordo com a(s) tabela(s) utlizada(s) pelo conv�nio
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
     OPEN v_cursor FOR

      SELECT PROD.CAD_PRD_ID,
             PROD.CAD_PRD_CD_CODIGO,
             PROD.CAD_PRD_DS_DESCRICAO,
             TAB_UTILIZA.CAD_CNV_ID_CONVENIO
        FROM TB_ASS_CTU_CNV_TAB_UTILIZA TAB_UTILIZA INNER JOIN
             TB_CAD_PRD_PRODUTO PROD ON (PROD.CAD_TAP_TP_ATRIBUTO = TAB_UTILIZA.CAD_TAP_TP_ATRIBUTO AND
                                         PROD.TIS_MED_CD_TABELAMEDICA = TAB_UTILIZA.TIS_MED_CD_TABELAMEDICA)
      WHERE PROD.CAD_PRD_FL_STATUS = 'A' AND
            (TAB_UTILIZA.ASS_CTU_DT_INICIO_VIGENCIA <= SYSDATE AND NVL(TAB_UTILIZA.ASS_CTU_DT_FIM_VIGENCIA,SYSDATE) >= SYSDATE) AND
            (TAB_UTILIZA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO) AND
            (pCAD_PRD_CD_CODIGO IS NULL OR PROD.CAD_PRD_CD_CODIGO = pCAD_PRD_CD_CODIGO) AND
            (pTIS_MED_CD_TABELAMEDICA IS NULL OR PROD.TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA) AND
            (pCAD_TAP_TP_ATRIBUTO IS NULL OR PROD.CAD_TAP_TP_ATRIBUTO = pCAD_TAP_TP_ATRIBUTO) AND
            (pCAD_CMM_CD_CARACMATMED IS NULL OR PROD.CAD_CMM_CD_CARACMATMED = pCAD_CMM_CD_CARACMATMED)
      ORDER BY PROD.CAD_PRD_DS_DESCRICAO;

      io_cursor := v_cursor;
end PRC_ASS_CTU_CNV_TAB_UTILIZA_P;