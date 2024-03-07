--PRC_ATD_IFV_INT_FALTA_VAGA_S
create or replace procedure PRC_ATD_IFV_INT_FALTA_VAGA_S 
(
     pATD_IFV_ID IN TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ATD_IFV_INT_FALTA_VAGA_S
* 
*    Data Criacao: 	  24/01/2011           Por: Fabiola Lopes
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Obtem registro da TB_ATD_IFV_INT_FALTA_VAGA
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT ATD_IFV_ID,
       ATD_ATE_ID,
       ATD_IML_ID,
       ATD_IFV_DS_JUSTIFICATIVA,
       SEG_USU_ID_USUARIO_DESB,
       ATD_IFV_DT_FALTA_VAGA,
       SEG_USU_ID_USUARIO_REG,
       ATD_IFV_DT_ULTIMA_ATUALIZACAO
  FROM TB_ATD_IFV_INT_FALTA_VAGA
 WHERE ATD_IFV_ID = PATD_IFV_ID;
io_cursor := v_cursor;
end PRC_ATD_IFV_INT_FALTA_VAGA_S;
