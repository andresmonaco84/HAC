  --PRC_INT_ATD_MOV_CLINICA_SID
  create or replace procedure PRC_INT_ATD_MOV_CLINICA_SID 
  (
     pATD_IMC_ID IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_IMC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_MOV_CLINICA_SID
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
       ATD_IMC_DT_ENTRADA,
       ATD_IMC_HR_ENTRADA,
       ATD_IMC_DT_SAIDA,
       CAD_CLC_ID,
       ATD_IMC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_IMC_DS_OBSERVACAO,
       ATD_IMC_HR_SAIDA,
       ATD_IMC_ID
    FROM TB_ATD_IMC_INT_MOV_CLINICA
    WHERE
        ATD_IMC_ID = pATD_IMC_ID;          
    io_cursor := v_cursor;
  end PRC_INT_ATD_MOV_CLINICA_SID;
