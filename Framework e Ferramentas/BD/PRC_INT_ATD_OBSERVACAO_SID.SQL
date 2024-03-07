  --PRC_INT_ATD_OBSERVACAO_SID
  create or replace procedure PRC_INT_ATD_OBSERVACAO_SID 
  (
     pATD_INO_ID IN TB_ATD_INO_INT_OBSERVACAO.ATD_INO_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_OBSERVACAO_SID
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
       ATD_ATE_ID,
       ATD_INO_DT_OBS,
       ATD_INO_HR_OBS,
       ATD_INO_OBSERVACAO,
       SEG_USU_ID_USUARIO,
       ATD_ION_DT_ULTIMA_ATUALIZACAO,
       ATD_INO_ID
    FROM TB_ATD_INO_INT_OBSERVACAO
    WHERE
        ATD_INO_ID = pATD_INO_ID;          
    io_cursor := v_cursor;
  end PRC_INT_ATD_OBSERVACAO_SID;
