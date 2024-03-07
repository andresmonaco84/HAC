  --PRC_INT_CAD_QUARTO_LEITO_SID
  create or replace procedure PRC_INT_CAD_QUARTO_LEITO_SID
  (
     pCAD_QLE_ID IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_QUARTO_LEITO_SID
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
       CAD_QLE_ID,
       CAD_SET_ID,
       CAD_QLE_NR_QUARTO,
       CAD_QLE_NR_LEITO,
       CAD_QLE_NR_RAMAL,
       TIS_TAC_CD_TIPO_ACOMODACAO,
       CAD_QLE_TP_SEXO,
       TIS_TAC_CD_TIPO_ACOM_PROV,
       CAD_QLE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_SQL_CD_SIT_QUARTO_LEITO,
       CAD_QLE_TP_QUARTO_LEITO,
       CAD_QLE_FL_ALTERA_ACOMOD,
       TIS_CBO_CBOS,
       CAD_QLE_FL_LIMPEZA_LEITO,
       CAD_QLE_FL_CONS_SEX_PRIM_PAC,
       CAD_QLE_QT_VISITA_PERM_LEITO,
       CAD_QLE_FL_CONS_PATOLOGIA,
       CAD_QLE_DS_OBSERVACAO
    FROM TB_CAD_QLE_QUARTO_LEITO
    WHERE
        CAD_QLE_ID = pCAD_QLE_ID;          
    io_cursor := v_cursor;
  end PRC_INT_CAD_QUARTO_LEITO_SID;