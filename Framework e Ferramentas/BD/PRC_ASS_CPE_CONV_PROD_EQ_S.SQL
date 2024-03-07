  --PRC_ASS_CPE_CONV_PROD_EQUIVALE_S
  create or replace procedure PRC_ASS_CPE_CONV_PROD_EQ_S 
  (
     pASS_CPE_ID IN TB_ASS_CPE_CONV_PROD_EQUIVALE.ASS_CPE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CPE_CONV_PROD_EQ_S
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
       ASS_CPE_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_PRD_ID_ORIGEM,
       CAD_PRD_ID_DESTINO,
       CAD_CPE_DT_INICIO_VIGENCIA,
       CAD_CPE_DT_FIM_VIGENCIA,
       CAD_CPE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_CPE_CONV_PROD_EQUIVALE
    WHERE
        ASS_CPE_ID = pASS_CPE_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_CPE_CONV_PROD_EQ_S;

