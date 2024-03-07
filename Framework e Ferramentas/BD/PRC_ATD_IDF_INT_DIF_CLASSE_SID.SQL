  --PRC_ATD_IDF_INT_DIF_CLASSE_SID
  create or replace procedure PRC_ATD_IDF_INT_DIF_CLASSE_SID 
  (
     pATD_IDF_ID IN TB_ATD_IDF_INT_DIF_CLASSE.ATD_IDF_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATD_IDF_INT_DIF_CLASSE_SID
  * 
  *    Data Criacao: 	31/08/2009         Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       ATD_IDF_ID,
       ATD_ATE_ID,
       ATD_IML_ID,
       ATD_IDF_DS_DIF_CLASSE,
       SEG_USU_ID_USUARIO_DIF_CLASSE,
       ATD_IDF_DT_DIF_CLASSE,
       SEG_USU_ID_USUARIO,
       ATD_INC_DT_ULTIMA_ATUALIZACAO
    FROM TB_ATD_IDF_INT_DIF_CLASSE
    WHERE
        ATD_IDF_ID = pATD_IDF_ID;          
    io_cursor := v_cursor;
  end PRC_ATD_IDF_INT_DIF_CLASSE_SID;