

--PRC_ATD_PRS_PREVISAO_SAIDA_S
create or replace procedure PRC_ATD_PRS_PREVISAO_SAIDA_S 
(
     pATD_PRS_ID IN TB_ATD_PRS_PREVISAO_SAIDA.ATD_PRS_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ATD_PRS_PREVISAO_SAIDA_S
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
       ATD_PRS_ID,
       ATD_ATE_ID,
       ATD_PRS_DT_SAIDA,
       ATD_PRS_DT_SAIDA_UTI,
       SEG_USU_ID_USUARIO,
       CAD_PRO_NR_CONSELHO,
       ATD_PRS_DT_CRIACAO--,
      -- ATD_PRS_FL_CONFIRMACAO,
      -- SEG_USU_ID_USUARIO_CONF,
      -- CAD_PRO_NR_CONSELHO_CONF
FROM TB_ATD_PRS_PREVISAO_SAIDA
WHERE
        ATD_PRS_ID = pATD_PRS_ID;          
io_cursor := v_cursor;
end PRC_ATD_PRS_PREVISAO_SAIDA_S;
