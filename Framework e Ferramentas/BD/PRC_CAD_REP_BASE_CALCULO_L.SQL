CREATE OR REPLACE PROCEDURE PRC_CAD_REP_BASE_CALCULO_L
(
     pCAD_REP_TP_BASE_CALCULO IN TB_CAD_REP_BCP_BASE_CALCULO.CAD_REP_TP_BASE_CALCULO%type DEFAULT NULL,
     pREP_BCP_FL_ATIVO_OK IN TB_CAD_REP_BCP_BASE_CALCULO.REP_BCP_FL_ATIVO_OK%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_REP_BASE_CALCULO_L
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao: data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       CAD_REP_TP_BASE_CALCULO,
       REP_BCP_DS_BASE_CALCULO,
       REP_BCP_DS_CAMPO,
       REP_BCP_NM_CONTROLE,
       REP_BCP_FL_ATIVO_OK
FROM   TB_CAD_REP_BCP_BASE_CALCULO
WHERE
        (pCAD_REP_TP_BASE_CALCULO is null OR CAD_REP_TP_BASE_CALCULO = pCAD_REP_TP_BASE_CALCULO) AND
        (pREP_BCP_FL_ATIVO_OK is null OR REP_BCP_FL_ATIVO_OK = pREP_BCP_FL_ATIVO_OK);
io_cursor := v_cursor;
end PRC_CAD_REP_BASE_CALCULO_L;
