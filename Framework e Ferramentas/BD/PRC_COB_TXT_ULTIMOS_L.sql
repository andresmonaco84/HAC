create or replace procedure PRC_COB_TXT_ULTIMOS_L
(
     pCAD_PES_ID_PESSOA IN TB_COB_TXT_COBRANCA.CAD_PES_ID_PESSOA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_COB_TXT_ULTIMOS_L
*
*    Data Criacao:   17/07/2012   Por: PEDRO
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;

begin

   OPEN v_cursor FOR
SELECT *
FROM (SELECT
             TXT.COB_TXT_ID,
             TRUNC(TXT.COB_TXT_DT_CRIACAO) COB_TXT_DT_CRIACAO
           
      FROM  TB_COB_TXT_COBRANCA TXT
      WHERE TXT.CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA     
      GROUP BY TXT.COB_TXT_ID , TRUNC(TXT.COB_TXT_DT_CRIACAO)  
      ORDER BY TXT.COB_TXT_ID  DESC
      ) a
WHERE rownum <= 12
ORDER BY rownum;


  io_cursor := v_cursor;
end PRC_COB_TXT_ULTIMOS_L;
 