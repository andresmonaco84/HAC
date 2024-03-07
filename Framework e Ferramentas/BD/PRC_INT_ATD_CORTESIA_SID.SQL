  --PRC_INT_ATD_CORTESIA_SID
  create or replace procedure PRC_INT_ATD_CORTESIA_SID 
  (
     pATD_INC_ID IN TB_ATD_INC_INT_CORTESIA.ATD_INC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_CORTESIA_SID
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
       ATD_INC_ID,
       ATD_ATE_ID,
       ATD_IML_ID,
       ATD_INC_DS_CORTESIA,
       SEG_USU_ID_USUARIO_CORT,
       ATD_INC_DT_CORTESIA,
       SEG_USU_ID_USUARIO,
       ATD_INC_DT_ULTIMA_ATUALIZACAO
    FROM TB_ATD_INC_INT_CORTESIA
    WHERE
        ATD_INC_ID = pATD_INC_ID;          
    io_cursor := v_cursor;
  end PRC_INT_ATD_CORTESIA_SID;
