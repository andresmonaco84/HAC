--PRC_CTS_RES_RESUMO_GERAL_S
create or replace procedure PRC_CTS_RES_RESUMO_GERAL_S 
(
     pSEQ_CTS_RES_RESUMO_01 IN TB_CTS_RES_RESUMO_GERAL.SEQ_CTS_RES_RESUMO_01%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CTS_RES_RESUMO_GERAL_S
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
       SEQ_CTS_RES_RESUMO_01,
       CTS_RES_RESU_TIPO,
       CTS_RES_RESU_MES,
       CTS_RES_RESU_ANO,
       CTS_RES_RESU_CAD_CTS_PLC_ID,
       CTS_RES_RESU_CAD_CTS_CD_CONTA,
       CTS_RES_RESU_CAD_CTS_CD_NIVEL,
       CTS_RES_RESU_CAD_CTS_DS_DESCRI,
       CTS_RES_RESU_VL_REC_DIRETA,
       CTS_RES_RESU_VL_REC_INTERMEDI,
       CTS_RES_RESU_VL_REC_INDIRETA,
       CTS_RES_RESU_VL_DESP_DIRETA,
       CTS_RES_RESU_VL_DESP_INTERMEDI,
       CTS_RES_RESU_VL_DESP_INDIRETA,
       CTS_RES_RESU_SEG_USU_ID_INCLU,
       CTS_RES_RESU_DT_CRIACAO
FROM TB_CTS_RES_RESUMO_GERAL
WHERE
        SEQ_CTS_RES_RESUMO_01 = pSEQ_CTS_RES_RESUMO_01;          
io_cursor := v_cursor;
end PRC_CTS_RES_RESUMO_GERAL_S;
