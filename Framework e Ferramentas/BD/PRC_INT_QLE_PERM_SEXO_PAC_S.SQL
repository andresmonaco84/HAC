create or replace procedure PRC_INT_QLE_PERM_SEXO_PAC_S
  (
       pCAD_UNI_ID_UNIDADE             IN TB_CAD_SET_SETOR.CAD_UNI_ID_UNIDADE%TYPE,
       pCAD_LAT_ID_LOCAL_ATENDIMENTO   IN TB_CAD_SET_SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
       pCAD_SET_ID                     IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE,
       pCAD_QLE_NR_QUARTO              IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_NR_QUARTO%TYPE,
       io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_QLE_PERM_SEXO_PAC_S
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
       SELECT PES.CAD_PES_TP_SEXO

         FROM TB_ATD_IML_INT_MOV_LEITO IML,
              TB_CAD_QLE_QUARTO_LEITO QLE,
              TB_CAD_SET_SETOR SETOR,
              TB_CAD_PAC_PACIENTE PAC,
              TB_CAD_PES_PESSOA PES

        WHERE IML.CAD_CAD_QLE_ID = QLE.CAD_QLE_ID
          AND QLE.CAD_SET_ID = SETOR.CAD_SET_ID
          AND IML.ATD_IML_DT_SAIDA IS NULL
          AND IML.ATD_IML_HR_SAIDA IS NULL
          AND SETOR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
          AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
          AND QLE.CAD_SET_ID = pCAD_SET_ID
          AND QLE.CAD_QLE_NR_QUARTO = pCAD_QLE_NR_QUARTO
          AND PAC.CAD_PAC_ID_PACIENTE = IML.CAD_PAC_ID_PACIENTE
          AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA;

    io_cursor := v_cursor;
  end PRC_INT_QLE_PERM_SEXO_PAC_S;

