create or replace procedure PRC_TIS_TFA_TP_FATURAMENTO_L 
(
     pTIS_TFA_CD_TPFATURAMENTO IN TB_TIS_TFA_TP_FATURAMENTO.TIS_TFA_CD_TPFATURAMENTO%type DEFAULT NULL,
     pTIS_TFA_DS_TPFATURAMENTO IN TB_TIS_TFA_TP_FATURAMENTO.TIS_TFA_DS_TPFATURAMENTO%type DEFAULT NULL,
     pTIS_TFA_CD_TPFATURAMENTO_V3 IN TB_TIS_TFA_TP_FATURAMENTO.TIS_TFA_CD_TPFATURAMENTO_V3%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_TIS_TFA_TP_FATURAMENTO_L
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*    Data Alteracao: 31/03/2014  Por: Andréa Cazuca
*    Alteracao:  Inclusão dos campos TIS_TFA_CD_TPFATURAMENTO_V3 e TIS_TFA_OBSERVACAO
*
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
begin
  V_WHERE := NULL;
  IF pTIS_TFA_CD_TPFATURAMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TFA_CD_TPFATURAMENTO = ' || CHR(39) || pTIS_TFA_CD_TPFATURAMENTO || CHR(39); END IF;
  IF pTIS_TFA_DS_TPFATURAMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TFA_DS_TPFATURAMENTO = ' || CHR(39) || pTIS_TFA_DS_TPFATURAMENTO || CHR(39); END IF;
  IF pTIS_TFA_CD_TPFATURAMENTO_V3 IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TFA_CD_TPFATURAMENTO_V3 = ' || CHR(39) || pTIS_TFA_CD_TPFATURAMENTO_V3 || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       TIS_TFA_CD_TPFATURAMENTO,
       TIS_TFA_DS_TPFATURAMENTO,
       TIS_TFA_CD_TPFATURAMENTO_V3,
       TIS_TFA_OBSERVACAO
FROM TB_TIS_TFA_TP_FATURAMENTO
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_TIS_TFA_TP_FATURAMENTO_L;
