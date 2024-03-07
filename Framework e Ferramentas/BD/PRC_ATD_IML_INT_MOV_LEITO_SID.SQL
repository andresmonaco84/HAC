create or replace procedure PRC_ATD_IML_INT_MOV_LEITO_SID
  (
     pATD_IML_ID IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATD_IML_INT_MOV_LEITO_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	24/01/2011           Por: Fabiola Lopes
  *    Data Alteracao:  14/05/2011           Por: Fabiola Lopes
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *    Alteracao: Inclus�o do campo ATD_IML_FL_FALTA_VAGA
  *    Alteracao: Inclus�o dos campos TIS_TAC_CD_TIPO_ACOMOD_AUT, ATD_IML_DT_INI_ACOMOD_AUT e ATD_IML_HR_INI_ACOMOD_AUT
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       ATD_ATE_ID,
       ATD_IML_DT_ENTRADA,
       ATD_IML_HR_ENTRADA,
       ATD_IML_DT_SAIDA,
       ATD_IML_HR_SAIDA,
       CAD_CAD_QLE_ID,
       ATD_IML_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PAC_ID_PACIENTE,
       TIS_TAC_CD_TIPO_ACOMODACAO,
       ATD_IML_FL_STATUS,
       ATD_IML_FL_CORTESIA,
       ATD_IML_FL_DIF_CLASSE,
       ATD_IML_ID,
       ATD_IML_FL_FALTA_VAGA,
       TIS_TAC_CD_TIPO_ACOMOD_AUT,
       ATD_IML_DT_INI_ACOMOD_AUT,
       ATD_IML_HR_INI_ACOMOD_AUT
    FROM TB_ATD_IML_INT_MOV_LEITO
    WHERE
        ATD_IML_ID = pATD_IML_ID;          
    io_cursor := v_cursor;
  end PRC_ATD_IML_INT_MOV_LEITO_SID;