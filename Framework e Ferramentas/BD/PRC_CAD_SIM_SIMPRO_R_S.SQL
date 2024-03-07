

--PRC_CAD_SIM_SIMPRO_R_S
create or replace procedure PRC_CAD_SIM_SIMPRO_R_S 
(
     pCAD_SIM_ID IN TB_CAD_SIM_SIMPRO.CAD_SIM_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_SIM_SIMPRO_R_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       CAD_SIM_ID,
       CAD_SIM_CD_SIMPRO,
       CAD_SIM_NM_MNEMONICO,
       CAD_SIM_DS_PRODUTO,
       CAD_SIM_DT_VIGENCIA,
       CAD_SIM_ID_IDENTIFICACAO,
       CAD_SIM_VL_PRECO_FABRICA,
       CAD_SIM_VL_PRECO_VENDA,
       CAD_SIM_VL_FRACAO_FABRICA,
       CAD_SIM_VL_FRACAO_VENDA,
       CAD_SIM_TP_EMBALAGEM,
       CAD_SIM_TP_FRACAO,
       CAD_SIM_QT_EMBALAGEM,
       CAD_SIM_QT_FRACAO,
       CAD_SIM_TP_ALTERACAO,
       CAD_SIM_TP_FABRICANTE,
       CAD_SIM_ID_INTEIRO,
       CAD_SIM_ID_FRACIONADO,
       CAD_SIM_QT_FRACIONADO,
       CAD_SIM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_SIM_TP_MATMED,
       CAD_CME_CLASSIF_MED,
       CAD_SIM_FL_RESTRITO,
       CAD_SIM_PC_IPI,
       CAD_SIM_CD_ANVISA,
       CAD_SIM_IN_NOVO,
       CAD_SIM_DT_CRIACAO,
	   CAD_SIM_CD_TUSS
FROM TB_CAD_SIM_SIMPRO
WHERE
        CAD_SIM_ID = pCAD_SIM_ID;          
io_cursor := v_cursor;
end PRC_CAD_SIM_SIMPRO_R_S;
