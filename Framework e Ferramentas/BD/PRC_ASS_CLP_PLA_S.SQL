create or replace procedure PRC_ASS_CLP_PLA_S
  (
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CLP_PLA_S
  *
  *    Data Criacao: 	17/10/2007   Por: Fabiola R. Lopes
  *    Funcao:        Seleciona o Local de Atendimento por Plano
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CLP.ASS_CLP_ID,
       CLP.ASS_CUL_ID,
       CLP.ASS_CLP_DT_INI_VIGENCIA,
       CLP.ASS_CLP_DT_FIM_VIGENCIA,
       CLP.CAD_PLA_ID_PLANO,
       CLP.ASS_CLP_FL_BLOQUEIA_UNIDADE_OK,
       CLP.ASS_CLP_DT_ULTIMA_ATUALIZACAO,
       CLP.SEG_USU_ID_USUARIO
    FROM TB_ASS_CLP_CNV_UND_LOC_PLANO CLP,
         TB_ASS_CUL_CONV_UNI_LOCATEND CUL,
         TB_ASS_CNU_CONVENIO_UNIDADE CNU
    WHERE
          CLP.ASS_CUL_ID = CUL.ASS_CUL_ID
    AND   CUL.ASS_CNU_ID = CNU.ASS_CNU_ID
    AND   (CLP.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO);
    io_cursor := v_cursor;
  end PRC_ASS_CLP_PLA_S;
/
